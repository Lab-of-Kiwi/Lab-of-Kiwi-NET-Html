using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class Time : INPUT
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

        public TimeOnly? Max
        {
            get => GetStruct<TimeParser, TimeOnly>("max");
            set => SetStruct<TimeParser, TimeOnly>("max", value);
        }

        public TimeOnly? Min
        {
            get => GetStruct<TimeParser, TimeOnly>("min");
            set => SetStruct<TimeParser, TimeOnly>("min", value);
        }

        public Step? Step
        {
            get => GetStruct<StepParser, Step>("step");
            set => SetStruct<StepParser, Step>("step", value);
        }

        public new TimeOnly? Value
        {
            get => GetStruct<TimeParser, TimeOnly>("value");
            set => SetStruct<TimeParser, TimeOnly>("value", value);
        }
    }
}
