using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace LabOfKiwi.Html.Attributes;

internal sealed class AttributeDictionary : IReadOnlyDictionary<string, string>, IDictionary<string, string>
{
    private readonly string _prefix;
    private readonly HtmlAgilityPack.HtmlNode _element;

    private enum InsertionBehavior
    {
        None,
        OverwriteExisting,
        ThrowOnExisting
    }

    public AttributeDictionary(string prefix, HtmlAgilityPack.HtmlNode element)
    {
        _prefix = prefix;
        _element = element;
    }

    #region Public Properties
    public int Count => FilteredAttributes().Count();

    public bool IsReadOnly => false;

    public ICollection<string> Keys => FilteredAttributes()
        .Select(attr => attr.Name[_prefix.Length..]).ToArray();

    public ICollection<string> Values => FilteredAttributes()
        .Select(attr => HttpUtility.HtmlDecode(attr.Value)).ToArray();

    public string this[string name]
    {
        get
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (IsValid(name) && _element.Attributes.Contains(_prefix + name))
            {
                return HttpUtility.HtmlDecode(_element.GetAttributeValue(_prefix + name, ""));
            }

            throw new KeyNotFoundException(string.Format("The given key '{0}' was not present in the dictionary.", name));
        }

        set
        {
            bool modified = TryInsert(name, value, InsertionBehavior.OverwriteExisting);
            Debug.Assert(modified);
        }
    }
    #endregion

    #region Public Methods
    public void Add(string name, string value)
    {
        bool modified = TryInsert(name, value, InsertionBehavior.ThrowOnExisting);
        Debug.Assert(modified);
    }

    public void Clear()
    {
        string[] keysToRemove = FilteredAttributes().Select(e => e.Name).ToArray();

        for (int i = 0; i < keysToRemove.Length; i++)
        {
            _element.Attributes.Remove(keysToRemove[i]);
        }
    }

    public bool ContainsKey(string name)
    {
        if (name == null || !IsValid(name))
        {
            return false;
        }

        return _element.Attributes.Contains(_prefix + name);
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        foreach (var attr in FilteredAttributes())
        {
            yield return new KeyValuePair<string, string>(attr.Name[_prefix.Length..], HttpUtility.HtmlDecode(attr.Value));
        }
    }

    public bool Remove(string name)
    {
        if (name == null || !IsValid(name))
        {
            return false;
        }

        if (_element.Attributes.Contains(_prefix + name))
        {
            _element.Attributes.Remove(_prefix + name);
            return true;
        }

        return false;
    }

    public bool TryGetValue(string name, [MaybeNullWhen(false)] out string value)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        ThrowIfNotValid(name);

        if (_element.Attributes.Contains(_prefix + name))
        {
            value = HttpUtility.HtmlDecode(_element.GetAttributeValue(_prefix + name, ""));
            return true;
        }

        value = default;
        return false;
    }
    #endregion

    #region Explicit Interface Implementations
    IEnumerable<string> IReadOnlyDictionary<string, string>.Keys => Keys.ToList().AsReadOnly();

    IEnumerable<string> IReadOnlyDictionary<string, string>.Values => Values.ToList().AsReadOnly();

    void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
    {
        Add(item.Key, item.Value);
    }

    bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
    {
        string name = item.Key;
        string value = item.Value;

        if (name == null || value == null || !IsValid(name))
        {
            return false;
        }

        if (_element.Attributes.Contains(_prefix + name))
        {
            string currValue = HttpUtility.HtmlDecode(_element.GetAttributeValue(_prefix + name, ""));
            return string.Equals(value, currValue);
        }

        return false;
    }

    void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        var thisArray = this.ToArray();
        Array.Copy(thisArray, 0, array, arrayIndex, thisArray.Length);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
    {
        string name = item.Key;
        string value = item.Value;

        if (name == null || value == null || !IsValid(name))
        {
            return false;
        }

        if (_element.Attributes.Contains(_prefix + name))
        {
            string currValue = HttpUtility.HtmlDecode(_element.GetAttributeValue(_prefix + name, ""));

            if (string.Equals(value, currValue))
            {
                _element.Attributes.Remove(_prefix + name);
            }
        }

        return false;
    }
    #endregion

    private bool TryInsert(string name, string value, InsertionBehavior insertionBehavior)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        ThrowIfNotValid(name);

        if (insertionBehavior != InsertionBehavior.OverwriteExisting && _element.Attributes.Contains(_prefix + name))
        {
            if (insertionBehavior == InsertionBehavior.ThrowOnExisting)
            {
                throw new ArgumentException(string.Format("An item with the same key has already been added. Key: {0}", name));
            }

            Debug.Assert(insertionBehavior == InsertionBehavior.None);
            return false;
        }

        _element.SetAttributeValue(_prefix + name, HttpUtility.HtmlAttributeEncode(value));
        return true;
    }

    private IEnumerable<HtmlAgilityPack.HtmlAttribute> FilteredAttributes()
    {
        foreach (HtmlAgilityPack.HtmlAttribute attribute in _element.Attributes)
        {
            if (attribute.Name.StartsWith(_prefix))
            {
                yield return attribute;
            }
        }
    }

    private void ThrowIfNotValid(string name)
    {
        if (!IsValid(name))
        {
            throw new ArgumentException($"Invalid attribute name: {_prefix}{name}.");
        }
    }

    private static bool IsValid(string name)
    {
        return !(name.Length == 0 || HtmlHelper.HasASCIIWhitespace(name));
    }
}
