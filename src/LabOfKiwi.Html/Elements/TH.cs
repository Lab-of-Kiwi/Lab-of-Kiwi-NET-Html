using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Elements;

public class TH : HtmlContainerElement
{
    public string? Abbr
    {
        get => Get("abbr");
        set => Set("abbr", value);
    }

    public long? Colspan
    {
        get => GetStruct<LongParser.Positive, long>("colspan");
        set => SetStruct<LongParser.Positive, long>("colspan", value);
    }

    public ISet<string> Headers => GetSet<TokenParser, string>("headers", delimiter: " ");

    public long? Rowspan
    {
        get => GetStruct<LongParser.NonNegative, long>("rowspan");
        set => SetStruct<LongParser.NonNegative, long>("rowspan", value);
    }

    public Scope? Scope
    {
        get => GetEnum<Scope>("scope");
        set => SetEnum("scope", value);
    }

    internal sealed override string ExpectedTagName => "th";
}
