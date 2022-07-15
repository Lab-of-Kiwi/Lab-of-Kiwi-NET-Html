using System.Collections.Generic;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal sealed class AttributeParserSet<T> : AttributeParserCollection<T>, ISet<T> where T : notnull
{
    public AttributeParserSet(HtmlAgilityPack.HtmlNode element, string name, IAttributeParser<T> parser, string delimiter) : base(element, name, parser, delimiter)
    {
    }

    public override void Add(T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetSet();

        if (values.Add(item))
        {
            SetCollection(values);
        }
    }

    public void ExceptWith(IEnumerable<T> other)
    {
        var values = GetSet();
        values.ExceptWith(other);
        SetCollection(values);
    }

    public void IntersectWith(IEnumerable<T> other)
    {
        var values = GetSet();
        values.IntersectWith(other);
        SetCollection(values);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return GetSet().IsProperSubsetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return GetSet().IsProperSupersetOf(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return GetSet().IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return GetSet().IsSupersetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return GetSet().Overlaps(other);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return GetSet().SetEquals(other);
    }

    public void SymmetricExceptWith(IEnumerable<T> other)
    {
        var values = GetSet();
        values.SymmetricExceptWith(other);
        SetCollection(values);
    }

    public void UnionWith(IEnumerable<T> other)
    {
        var values = GetSet();
        values.UnionWith(other);
        SetCollection(values);
    }

    protected override ICollection<T> GetCollection()
    {
        return GetSet();
    }

    bool ISet<T>.Add(T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetSet();
        bool result = values.Add(item);

        if (result)
        {
            SetCollection(values);
        }

        return result;
    }

    private ISet<T> GetSet()
    {
        HashSet<T> values = new();
        Populate(values);
        return values;
    }
}
