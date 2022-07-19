using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Elements;

public class TD : HtmlContainerElement
{
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
}
