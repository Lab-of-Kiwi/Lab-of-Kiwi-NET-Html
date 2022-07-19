using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class PROGRESS : HtmlContainerElement
{
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
