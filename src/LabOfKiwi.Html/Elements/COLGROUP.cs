using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class COLGROUP : HtmlContainerElement
{
    public long? Span
    {
        get => GetStruct<LongParser.Positive, long>("span");
        set => SetStruct<LongParser.Positive, long>("span", value);
    }
}
