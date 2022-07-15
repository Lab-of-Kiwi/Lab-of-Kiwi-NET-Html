using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class HTML : HtmlContainerElement
{
    internal HTML(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }
}
