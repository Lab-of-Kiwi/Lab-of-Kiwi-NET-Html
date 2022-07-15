using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class LABEL : HtmlContainerElement
{
    internal LABEL(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }
    public string? For
    {
        get => GetObject<TokenParser, string>("for");
        set => SetObject<TokenParser, string>("for", value);
    }

}
