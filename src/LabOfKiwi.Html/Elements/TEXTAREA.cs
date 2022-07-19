using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class TEXTAREA : HtmlContainerElement
{
    // TODO
    public string? AutoComplete
    {
        get => Get("autocomplete");
        set => Set("autocomplete", value);
    }

    public long? Cols
    {
        get => GetStruct<LongParser.Positive, long>("cols");
        set => SetStruct<LongParser.Positive, long>("cols", value);
    }

    public string? DirName
    {
        get => Get("dirname");
        set => Set("dirname", value);
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

    public bool IsReadOnly
    {
        get => GetBoolean("readonly");
        set => SetBoolean("readonly", value);
    }

    public bool IsRequired
    {
        get => GetBoolean("required");
        set => SetBoolean("required", value);
    }

    public long? MaxLength
    {
        get => GetStruct<LongParser.NonNegative, long>("maxlength");
        set => SetStruct<LongParser.NonNegative, long>("maxlength", value);
    }

    public long? MinLength
    {
        get => GetStruct<LongParser.NonNegative, long>("minlength");
        set => SetStruct<LongParser.NonNegative, long>("minlength", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public string? Placeholder
    {
        get => Get("placeholder");
        set => Set("placeholder", value);
    }

    public long? Rows
    {
        get => GetStruct<LongParser.Positive, long>("rows");
        set => SetStruct<LongParser.Positive, long>("rows", value);
    }

    public Wrap? Wrap
    {
        get => GetEnum<Wrap>("wrap");
        set => SetEnum("wrap", value);
    }
}
