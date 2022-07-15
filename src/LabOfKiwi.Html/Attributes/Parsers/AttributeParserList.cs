using System.Collections.Generic;
using System.Diagnostics;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal sealed class AttributeParserList<T> : AttributeParserCollection<T>, IList<T> where T : notnull
{
    public AttributeParserList(HtmlAgilityPack.HtmlNode element, string name, IAttributeParser<T> parser, string delimiter) : base(element, name, parser, delimiter)
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
            values[index] = value;
            SetCollection(values);
        }
    }

    public int IndexOf(T item)
    {
        if (_parser.IsValid(item))
        {
            return GetList().IndexOf(item);
        }

        Debug.Assert(!GetList().Contains(item));
        return -1;
    }

    public void Insert(int index, T item)
    {
        if (!_parser.IsValid(item))
        {
            HtmlHelper.ThrowInvalidAttributeValueException(_name, item);
        }

        var values = GetList();
        values.Insert(index, item);
        SetCollection(values);
    }

    public void RemoveAt(int index)
    {
        var values = GetList();
        values.RemoveAt(index);
        SetCollection(values);
    }

    protected override ICollection<T> GetCollection()
    {
        return GetList();
    }

    private IList<T> GetList()
    {
        List<T> values = new();
        Populate(values);
        return values;
    }
}
