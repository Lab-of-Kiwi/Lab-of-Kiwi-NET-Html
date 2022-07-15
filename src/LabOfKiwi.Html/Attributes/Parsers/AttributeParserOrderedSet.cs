using LabOfKiwi.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal sealed class AttributeParserOrderedSet<T> : AttributeParserCollection<T>, IOrderedSet<T> where T : notnull
{
    public AttributeParserOrderedSet(HtmlAgilityPack.HtmlNode element, string name, IAttributeParser<T> parser, string delimiter) : base(element, name, parser, delimiter)
    {
    }

    public T this[int index]
    {
        get => GetList()[index];

        set
        {
            if (!_parser.IsValid(value))
            {
                HtmlHelper.ThrowInvalidAttributeValueException(_name, value);
            }

            var values = GetList();
            T currentValue = values[index];

            if (Equals(currentValue, value))
            {
                return;
            }

            if (values.Contains(value))
            {
                throw new ArgumentException("Value already exists in set.", nameof(value));
            }

            values[index] = value;
            SetCollection(values);
        }
    }

    public override void Add(T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetList();

        if (!values.Contains(item))
        {
            values.Add(item);
            SetCollection(values);
        }
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            Clear();
            return;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        int origCount = values.Count;
        values.RemoveAll(e => other.Contains(e));

        if (values.Count != origCount)
        {
            SetCollection(values);
        }
    }

    public int IndexOf(T item)
    {
        if (_parser.IsValid(item))
        {
            return GetList().IndexOf(item);
        }

        return -1;
    }

    public bool Insert(int index, T item)
    {
        if (!_parser.IsValid(item))
        {
            return false;
        }

        var values = GetList();

        if ((uint)index > (uint)values.Count)
        {
            return false;
        }

        if (values.Contains(item))
        {
            return false;
        }

        values.Insert(index, item);
        SetCollection(values);
        return true;
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        int origCount = values.Count;
        values.RemoveAll(e => !other.Contains(e));

        if (values.Count != origCount)
        {
            SetCollection(values);
        }
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return false;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        return values.TrueForAll(e => other.Contains(e)) && other.Any(e => !values.Contains(e));
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return false;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        return values.Exists(e => !other.Contains(e)) && other.All(e => values.Contains(e));
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        return values.TrueForAll(e => other.Contains(e));
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        return other.All(e => values.Contains(e));
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return Count != 0;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if (other.TryGetNonEnumeratedCount(out int otherCount) && otherCount == 0)
        {
            return false;
        }

        var values = GetList();

        if (values.Count == 0)
        {
            return false;
        }

        return values.Exists(e => other.Contains(e));
    }

    public T RemoveAt(int index)
    {
        var values = GetList();
        T oldValue = values[index];
        values.RemoveAt(index);
        SetCollection(values);
        return oldValue;
    }

    public bool Set(int index, T item)
    {
        if (!_parser.IsValid(item))
        {
            return false;
        }

        var values = GetList();

        if ((uint)index >= values.Count)
        {
            return false;
        }

        if (values.Contains(item))
        {
            return false;
        }

        values[index] = item;
        SetCollection(values);
        return true;
    }

    public bool Set(int index, T item, [MaybeNullWhen(false)] out T oldValue)
    {
        if (!_parser.IsValid(item))
        {
            oldValue = default;
            return false;
        }

        var values = GetList();

        if ((uint)index >= values.Count)
        {
            oldValue = default;
            return false;
        }

        if (values.Contains(item))
        {
            oldValue = default;
            return false;
        }

        oldValue = values[index];
        values[index] = item;
        SetCollection(values);
        return true;
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();

        return values.TrueForAll(e => other.Contains(e)) && other.All(e => values.Contains(e));
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            Clear();
            return;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }
        
        var otherFiltered = other.Distinct().ToList();

        // No need to move on.
        if (otherFiltered.Count == 0)
        {
            return;
        }

        var values = GetList();

        // We can just add the other collection.
        if (values.Count == 0)
        {
            foreach (var e in otherFiltered)
            {
                // Elements from other have not been validated.
                if (!_parser.IsValid(e))
                {
                    HtmlHelper.ThrowInvalidAttributeValueException(_name, e);
                }
            }

            SetCollection(otherFiltered);
        }
        else
        {
            var newValues = new List<T>();

            foreach (var e in values)
            {
                if (!otherFiltered.Contains(e))
                {
                    newValues.Add(e);
                }
            }

            foreach (var e in otherFiltered)
            {
                if (!values.Contains(e))
                {
                    // Elements from other have not been validated.
                    if (!_parser.IsValid(e))
                    {
                        HtmlHelper.ThrowInvalidAttributeValueException(_name, e);
                    }

                    newValues.Add(e);
                }
            }

            SetCollection(newValues);
        }
    }

    public void UnionWith(IEnumerable<T> other)
    {
        if (ReferenceEquals(this, other))
        {
            return;
        }

        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        var values = GetList();
        int origCount = values.Count;

        foreach (var item in other)
        {
            if (!values.Contains(item))
            {
                if (!_parser.IsValid(item))
                {
                    HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
                }

                values.Add(item);
            }
        }

        if (values.Count != origCount)
        {
            SetCollection(values);
        }
    }

    protected override ICollection<T> GetCollection()
    {
        return GetList();
    }

    bool ISet<T>.Add(T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetList();

        if (!values.Contains(item))
        {
            values.Add(item);
            SetCollection(values);
            return true;
        }

        return false;
    }

    void IList<T>.Insert(int index, T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetList();

        if (index == values.Count)
        {
            if (values.Contains(item))
            {
                throw new ArgumentException("Value already exists in set.", nameof(item));
            }

            values.Add(item);
        }
        else
        {
            T currentValue = values[index];

            if (Equals(currentValue, item))
            {
                return;
            }
            else if (values.Contains(item))
            {
                throw new ArgumentException("Value already exists in set.", nameof(item));
            }
            else
            {
                values.Insert(index, item);
            }
        }

        SetCollection(values);
    }

    void IList<T>.RemoveAt(int index)
    {
        var values = GetList();
        values.RemoveAt(index);
        SetCollection(values);
    }

    private List<T> GetList()
    {
        List<T> values = new();
        Populate(values);
        Debug.Assert(values.Distinct().Count() == values.Count);
        return values.ToList();
    }
}
