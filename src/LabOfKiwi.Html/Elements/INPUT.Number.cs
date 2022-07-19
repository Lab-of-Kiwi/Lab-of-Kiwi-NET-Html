using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class Number : INPUT
    {
        public string? AutoComplete
        {
            get => Get("autocomplete");
            set => Set("autocomplete", value);
        }

        public bool IsReadOnly
        {
            get => GetBoolean("readonly");
            set => SetBoolean("readonly", value);
        }

        public bool IsRequired
        {
            get => GetBoolean("required");
            set => SetBoolean("required", value);
        }

        public string? List
        {
            get => GetObject<TokenParser, string>("list");
            set => SetObject<TokenParser, string>("list", value);
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

        public string? Placeholder
        {
            get => Get("placeholder");
            set => Set("placeholder", value);
        }

        public Step? Step
        {
            get => GetStruct<StepParser, Step>("step");
            set => SetStruct<StepParser, Step>("step", value);
        }

        public new float? Value
        {
            get => GetStruct<FloatParser, float>("value");
            set => SetStruct<FloatParser, float>("value", value);
        }
    }
}
