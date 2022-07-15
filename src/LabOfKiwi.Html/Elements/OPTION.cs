using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class OPTION : HtmlContainerElement
{
    internal OPTION(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public bool IsSelected
    {
        get => GetBoolean("selected");
        set => SetBoolean("selected", value);
    }

    public string? Label
    {
        get => Get("label");
        set => Set("label", value);
    }

    public string? Value
    {
        get => Get("value");
        set => Set("value", value);
    }
}
