using LabOfKiwi.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal abstract class AttributeParserCollection<T> : ICollection<T> where T : notnull
{
    private readonly HtmlAgilityPack.HtmlNode _element;
    protected readonly string _name;
    protected readonly IAttributeParser<T> _parser;
    protected readonly string _delimiter;

    protected AttributeParserCollection(HtmlAgilityPack.HtmlNode element, string name, IAttributeParser<T> parser, string delimiter)
    {
        Debug.Assert(element != null);
        Debug.Assert(name != null);
        Debug.Assert(parser != null);
        Debug.Assert(!string.IsNullOrEmpty(delimiter));
        _element = element;
        _name = name;
        _parser = parser;
        _delimiter = delimiter;
    }

    public int Count => GetCollection().Count;

    public bool IsReadOnly => false;

    public virtual void Add(T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetCollection();
        values.Add(item);
        SetCollection(values);
    }

    public void Clear()
    {
        _element.Attributes.Remove(_name);
    }

    public bool Contains(T item)
    {
        if (_parser.IsValid(item))
        {
            return GetCollection().Contains(item);
        }

        Debug.Assert(!GetCollection().Contains(item));
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        GetCollection().CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetCollection().GetEnumerator();
    }

    public bool Remove(T item)
    {
        if (_parser.IsValid(item))
        {
            var values = GetCollection();
            bool result = values.Remove(item);

            if (result)
            {
                SetCollection(values);
            }

            return result;
        }

        Debug.Assert(!GetCollection().Contains(item));
        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)GetCollection()).GetEnumerator();
    }

    protected abstract ICollection<T> GetCollection();

    protected void SetCollection(ICollection<T> values)
    {
        if (values.Count == 0)
        {
            Clear();
            return;
        }

        StringJoiner sj = new(_delimiter);

        foreach (var value in values)
        {

            Debug.Assert(_parser.IsValid(value));
            bool parseResult = _parser.TryToString(value, out string? rawValue);
            Debug.Assert(parseResult && rawValue != null);

            rawValue = HttpUtility.HtmlAttributeEncode(rawValue);

            if (rawValue.Contains(_delimiter))
            {
                HtmlHelper.ThrowInvalidAttributeStateException(_name, string.Format("Encoded raw string value of {0} contains delimiter {1}.", value, _delimiter));
            }

            sj.Add(rawValue);
        }

        string rawValues = sj.ToString();

        _element.SetAttributeValue(_name, rawValues);
    }

    protected HtmlAgilityPack.HtmlAttribute? GetAttributeNode()
    {
        return _element.Attributes[_name];
    }

    protected void Populate(ICollection<T> values)
    {
        var xmlAttribute = GetAttributeNode();

        if (xmlAttribute != null)
        {
            string[] rawValues = xmlAttribute.Value.Split(_delimiter, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (string rawValue in rawValues)
            {
                string decodedRawValue = HttpUtility.HtmlDecode(rawValue);

                if (_parser.TryParse(decodedRawValue, out var value))
                {
                    Debug.Assert(_parser.IsValid(value));
                    values.Add(value);
                }
                else
                {
                    HtmlHelper.ThrowInvalidAttributeStateException(_name, string.Format("Unable to parse value {0}", decodedRawValue));
                }
            }
        }
    }
}
