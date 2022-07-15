using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class TH : HtmlContainerElement
{
    internal TH(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

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
}
