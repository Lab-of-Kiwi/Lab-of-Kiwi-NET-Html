using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Month : INPUT
    {
        internal Month(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

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

        public DateOnly? Max
        {
            get => GetStruct<MonthParser, DateOnly>("max");
            set => SetStruct<MonthParser, DateOnly>("max", value);
        }

        public DateOnly? Min
        {
            get => GetStruct<MonthParser, DateOnly>("min");
            set => SetStruct<MonthParser, DateOnly>("min", value);
        }

        public Step? Step
        {
            get => GetStruct<StepParser, Step>("step");
            set => SetStruct<StepParser, Step>("step", value);
        }

        public new DateOnly? Value
        {
            get => GetStruct<MonthParser, DateOnly>("value");
            set => SetStruct<MonthParser, DateOnly>("value", value);
        }
    }
}
