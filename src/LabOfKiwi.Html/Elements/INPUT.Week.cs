using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Week : INPUT
    {
        internal Week(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
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
            get => GetStruct<WeekParser, DateOnly>("max");
            set => SetStruct<WeekParser, DateOnly>("max", value);
        }

        public DateOnly? Min
        {
            get => GetStruct<WeekParser, DateOnly>("min");
            set => SetStruct<WeekParser, DateOnly>("min", value);
        }

        public Step? Step
        {
            get => GetStruct<StepParser, Step>("step");
            set => SetStruct<StepParser, Step>("step", value);
        }

        public new DateOnly? Value
        {
            get => GetStruct<WeekParser, DateOnly>("value");
            set => SetStruct<WeekParser, DateOnly>("value", value);
        }
    }
}
