using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class PROGRESS : HtmlContainerElement
{
    internal PROGRESS(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public float? Max
    {
        get => GetStruct<FloatParser, float>("max");
        set => SetStruct<FloatParser, float>("max", value);
    }

    public float? Value
    {
        get => GetStruct<FloatParser, float>("value");
        set => SetStruct<FloatParser, float>("value", value);
    }
}
