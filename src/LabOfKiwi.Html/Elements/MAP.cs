using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class MAP : HtmlContainerElement
{
    internal MAP(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
}
