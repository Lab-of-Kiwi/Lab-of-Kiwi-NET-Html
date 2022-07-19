using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Attributes;

public readonly struct ItemAttributes
{
    private readonly HtmlElement _element;

    internal ItemAttributes(HtmlElement element)
    {
        _element = element;
    }

    public Uri? Id
    {
        get => _element.GetObject<UrlParser, Uri>("itemid");
        set => _element.SetObject<UrlParser, Uri>("itemid", value);
    }

    public ISet<string> Properties => _element.GetSet<TokenParser, string>("itemprop", delimiter: " ");

    public ISet<string> ReferencedElements => _element.GetSet<TokenParser, string>("itemref", delimiter: " ");

    public bool IsScope
    {
        get => _element.GetBoolean("itemscope");
        set => _element.SetBoolean("itemscope", value);
    }

    public ISet<string> Types => _element.GetSet<TokenParser, string>("itemtype", delimiter: " ");
}
