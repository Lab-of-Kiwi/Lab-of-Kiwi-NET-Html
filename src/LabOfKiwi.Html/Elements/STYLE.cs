using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class STYLE : HtmlContainerElement
{
    internal STYLE(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public ISet<string> Blocking => GetSet<TokenParser, string>("blocking", delimiter: " ");

    // TODO
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }
}
