using LabOfKiwi.Html.Attributes;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class BODY : HtmlContainerElement
{
    internal BODY(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public new BodyEvents Events => new(this);
}
