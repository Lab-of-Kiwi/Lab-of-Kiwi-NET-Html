using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class OPTGROUP : HtmlContainerElement
{
    internal OPTGROUP(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public string? Label
    {
        get => Get("label");
        set => Set("label", value);
    }
}
