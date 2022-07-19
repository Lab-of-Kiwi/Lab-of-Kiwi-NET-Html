using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class FIELDSET : HtmlContainerElement
{
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

    internal sealed override string ExpectedTagName => "fieldset";
}
