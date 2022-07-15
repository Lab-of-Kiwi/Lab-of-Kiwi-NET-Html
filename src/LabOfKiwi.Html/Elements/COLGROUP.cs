using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class COLGROUP : HtmlContainerElement
{
    internal COLGROUP(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public long? Span
    {
        get => GetStruct<LongParser.Positive, long>("span");
        set => SetStruct<LongParser.Positive, long>("span", value);
    }
}
