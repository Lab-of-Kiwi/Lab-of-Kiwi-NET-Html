using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Range : INPUT
    {
        internal Range(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public string? AutoComplete
        {
            get => Get("autocomplete");
            set => Set("autocomplete", value);
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
