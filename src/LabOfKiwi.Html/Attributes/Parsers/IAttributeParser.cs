using LabOfKiwi.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LabOfKiwi.Html.Attributes.Parsers;

public interface IAttributeParser<T> where T : notnull
{
    bool IsValid(T input);

    bool TryParse(string input, [MaybeNullWhen(false)] out T output);

    bool TryToString(T input, [MaybeNullWhen(false)] out string output);

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

public interface IAttributeParser<T, TParent> : IAttributeParser<T> where T : notnull where TParent : struct, IAttributeParser<T>
{
    private static readonly TParent Parent = default;

    bool IAttributeParser<T>.TryParse(string input, [MaybeNullWhen(false)] out T output)
    {
        return Parent.TryParse(input, out output);
    }

    bool IAttributeParser<T>.TryToString(T input, [MaybeNullWhen(false)] out string output)
    {
        return Parent.TryToString(input, out output);
    }
}