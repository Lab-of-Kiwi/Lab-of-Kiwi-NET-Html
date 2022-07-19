using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class DateTimeLocal : INPUT
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

        public DateTime? Max
        {
            get => GetStruct<DateTimeParser, DateTime>("max");
            set => SetStruct<DateTimeParser, DateTime>("max", value);
        }

        public DateTime? Min
        {
            get => GetStruct<DateTimeParser, DateTime>("min");
            set => SetStruct<DateTimeParser, DateTime>("min", value);
        }

        public Step? Step
        {
            get => GetStruct<StepParser, Step>("step");
            set => SetStruct<StepParser, Step>("step", value);
        }

        public new DateTime? Value
        {
            get => GetStruct<DateTimeParser, DateTime>("value");
            set => SetStruct<DateTimeParser, DateTime>("value", value);
        }
    }
}
