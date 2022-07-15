using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class BASE : HtmlVoidElement
{
    internal BASE(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public Uri? Href
    {
        get => GetObject<UrlParser, Uri>("href");
        set => SetObject<UrlParser, Uri>("href", value);
    }

    public BrowsingContext? Target
    {
        get => GetStruct<BrowsingContextParser, BrowsingContext>("target");
        set => SetStruct<BrowsingContextParser, BrowsingContext>("target", value);
    }
}
