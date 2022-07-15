using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class DIALOG : HtmlContainerElement
{
    internal DIALOG(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool IsOpen
    {
        get => GetBoolean("open");
        set => SetBoolean("open", value);
    }
}
