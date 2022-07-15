using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class DETAILS : HtmlContainerElement
{
    internal DETAILS(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool IsOpen
    {
        get => GetBoolean("open");
        set => SetBoolean("open", value);
    }
}
