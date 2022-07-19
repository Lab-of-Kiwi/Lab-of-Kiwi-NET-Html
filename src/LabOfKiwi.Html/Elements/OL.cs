using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class OL : HtmlContainerElement
{
    public bool IsReversed
    {
        get => GetBoolean("reversed");
        set => SetBoolean("reversed", value);
    }

    public long? Start
    {
        get => GetStruct<LongParser, long>("start");
        set => SetStruct<LongParser, long>("start", value);
    }

    public UnorderedListMarkerType? Type
    {
        get => GetStruct<ULMarkerTypeParser, UnorderedListMarkerType>("type");
        set => SetStruct<ULMarkerTypeParser, UnorderedListMarkerType>("type", value);
    }
}
