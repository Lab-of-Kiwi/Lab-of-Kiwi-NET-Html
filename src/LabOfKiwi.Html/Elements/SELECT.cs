using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class SELECT : HtmlContainerElement
{
    public bool AllowMultiple
    {
        get => GetBoolean("multiple");
        set => SetBoolean("multiple", value);
    }

    // TODO
    public string? AutoComplete
    {
        get => Get("autocomplete");
        set => Set("autocomplete", value);
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

    public bool IsRequired
    {
        get => GetBoolean("required");
        set => SetBoolean("required", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public long? Size
    {
        get => GetStruct<LongParser.Positive, long>("size");
        set => SetStruct<LongParser.Positive, long>("size", value);
    }
}
