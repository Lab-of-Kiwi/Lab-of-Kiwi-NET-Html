using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class SLOT : HtmlContainerElement
{
    internal SLOT(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
}
