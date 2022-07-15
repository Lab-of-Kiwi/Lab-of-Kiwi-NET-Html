using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class OL : HtmlContainerElement
{
    internal OL(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

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
