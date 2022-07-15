using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Password : INPUT
    {
        internal Password(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
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

        public long? MaxLength
        {
            get => GetStruct<LongParser.NonNegative, long>("maxlength");
            set => SetStruct<LongParser.NonNegative, long>("maxlength", value);
        }

        public long? MinLength
        {
            get => GetStruct<LongParser.NonNegative, long>("minlength");
            set => SetStruct<LongParser.NonNegative, long>("minlength", value);
        }

        public string? Pattern
        {
            get => Get("pattern");
            set => Set("pattern", value);
        }

        public string? Placeholder
        {
            get => Get("placeholder");
            set => Set("placeholder", value);
        }

        public long? Size
        {
            get => GetStruct<LongParser.Positive, long>("size");
            set => SetStruct<LongParser.Positive, long>("size", value);
        }

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
