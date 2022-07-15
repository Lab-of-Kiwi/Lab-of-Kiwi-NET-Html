using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class DATA : HtmlContainerElement
{
    internal DATA(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public string? Value
    {
        get => Get("value");
        set => Set("value", value);
    }
}
