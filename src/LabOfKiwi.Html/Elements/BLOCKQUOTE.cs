using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class BLOCKQUOTE : HtmlContainerElement
{
    internal BLOCKQUOTE(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public Uri? Cite
    {
        get => GetObject<UrlParser, Uri>("cite");
        set => SetObject<UrlParser, Uri>("cite", value);
    }
}
