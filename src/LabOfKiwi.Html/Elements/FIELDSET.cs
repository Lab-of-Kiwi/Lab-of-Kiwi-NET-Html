using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class FIELDSET : HtmlContainerElement
{
    internal FIELDSET(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public string? Form
    {
        get => GetObject<TokenParser, string>("form");
        set => SetObject<TokenParser, string>("form", value);
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
}
