using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public class OBJECT : HtmlContainerElement
{
    public Uri? Data
    {
        get => GetObject<UrlParser, Uri>("data");
        set => SetObject<UrlParser, Uri>("data", value);
    }

    public string? Form
    {
        get => GetObject<TokenParser, string>("form");
        set => SetObject<TokenParser, string>("form", value);
    }

    public long? Height
    {
        get => GetStruct<LongParser.NonNegative, long>("height");
        set => SetStruct<LongParser.NonNegative, long>("height", value);
    }

    // TODO
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    // TODO
    public string? Type
    {
        get => Get("type");
        set => Set("type", value);
    }

    public long? Width
    {
        get => GetStruct<LongParser.NonNegative, long>("width");
        set => SetStruct<LongParser.NonNegative, long>("width", value);
    }

    internal sealed override string ExpectedTagName => "object";
}
