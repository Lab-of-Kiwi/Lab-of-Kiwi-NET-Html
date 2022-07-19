using LabOfKiwi.Collections;
using LabOfKiwi.Text;
using System;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Attributes.Parsers;

internal interface IAttributeParser<T> : IParser<T> where T : notnull
{
    IList<T> AsList(HtmlAgilityPack.HtmlNode element, string attributeName, string delimiter)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        if (attributeName == null)
        {
            throw new ArgumentNullException(attributeName);
        }

        if (delimiter == null)
        {
            throw new ArgumentNullException(delimiter);
        }

        if (delimiter.Length == 0)
        {
            throw new ArgumentException("Delimiter cannot be empty.", nameof(delimiter));
        }

        return new AttributeParserList<T>(element, attributeName, this, delimiter);
    }

    ISet<T> AsSet(HtmlAgilityPack.HtmlNode element, string attributeName, string delimiter)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        if (attributeName == null)
        {
            throw new ArgumentNullException(attributeName);
        }

        if (delimiter == null)
        {
            throw new ArgumentNullException(delimiter);
        }

        if (delimiter.Length == 0)
        {
            throw new ArgumentException("Delimiter cannot be empty.", nameof(delimiter));
        }

        return new AttributeParserSet<T>(element, attributeName, this, delimiter);
    }

    IOrderedSet<T> AsOrderedSet(HtmlAgilityPack.HtmlNode element, string attributeName, string delimiter)
    {
        if (element == null)
        {
            throw new ArgumentNullException(nameof(element));
        }

        if (attributeName == null)
        {
            throw new ArgumentNullException(attributeName);
        }

        if (delimiter == null)
        {
            throw new ArgumentNullException(delimiter);
        }

        if (delimiter.Length == 0)
        {
            throw new ArgumentException("Delimiter cannot be empty.", nameof(delimiter));
        }

        return new AttributeParserOrderedSet<T>(element, attributeName, this, delimiter);
    }
}

internal interface IAttributeParser<T, TParent> : IAttributeParser<T>, IParser<T, TParent>
    where T : notnull
    where TParent :  IAttributeParser<T>, new()
{
}