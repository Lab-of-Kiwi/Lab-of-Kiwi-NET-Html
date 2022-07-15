using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class TIME : HtmlContainerElement
{
    internal TIME(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    // TODO
    public string? Datetime
    {
        get => Get("datetime");
        set => Set("datatime", value);
    }
}
