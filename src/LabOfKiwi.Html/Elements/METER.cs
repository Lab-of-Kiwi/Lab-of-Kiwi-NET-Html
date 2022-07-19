using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class METER : HtmlContainerElement
{
    public float? High
    {
        get => GetStruct<FloatParser, float>("high");
        set => SetStruct<FloatParser, float>("high", value);
    }

    public float? Low
    {
        get => GetStruct<FloatParser, float>("low");
        set => SetStruct<FloatParser, float>("low", value);
    }

    public float? Max
    {
        get => GetStruct<FloatParser, float>("max");
        set => SetStruct<FloatParser, float>("max", value);
    }

    public float? Min
    {
        get => GetStruct<FloatParser, float>("min");
        set => SetStruct<FloatParser, float>("min", value);
    }

    public float? Optimum
    {
        get => GetStruct<FloatParser, float>("optimum");
        set => SetStruct<FloatParser, float>("optimum", value);
    }

    public float? Value
    {
        get => GetStruct<FloatParser, float>("value");
        set => SetStruct<FloatParser, float>("value", value);
    }
}
