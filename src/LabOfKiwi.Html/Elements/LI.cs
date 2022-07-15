using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class LI : HtmlContainerElement
{
    internal LI(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public long? Value
    {
        get => GetStruct<LongParser, long>("value");
        set => SetStruct<LongParser, long>("value", value);
    }
}
