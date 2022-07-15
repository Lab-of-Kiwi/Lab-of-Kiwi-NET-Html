using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class ImageButton : INPUT
    {
        internal ImageButton(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public bool AllowFormValidation
        {
            get => !GetBoolean("formnovalidate");
            set => SetBoolean("formnovalidate", !value);
        }

        public string? Alt
        {
            get => Get("alt");
            set => Set("alt", value);
        }

        public Uri? FormAction
        {
            get => GetObject<UrlParser, Uri>("formaction");
            set => SetObject<UrlParser, Uri>("formaction", value);
        }

        public EncodingType? FormEncodingType
        {
            get => GetStruct<EncodingTypeParser, EncodingType>("formenctype");
            set => SetStruct<EncodingTypeParser, EncodingType>("formenctype", value);
        }

        public FormSubmissionMethod? FormMethod
        {
            get => GetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("formmethod");
            set => SetStruct<FormSubmissionMethodParser, FormSubmissionMethod>("formmethod", value);
        }

        public BrowsingContext? FormTarget
        {
            get => GetStruct<BrowsingContextParser, BrowsingContext>("formtarget");
            set => SetStruct<BrowsingContextParser, BrowsingContext>("formtarget", value);
        }

        public long? Height
        {
            get => GetStruct<LongParser.NonNegative, long>("height");
            set => SetStruct<LongParser.NonNegative, long>("height", value);
        }

        public Uri? Source
        {
            get => GetObject<UrlParser, Uri>("src");
            set => SetObject<UrlParser, Uri>("src", value);
        }

        public long? Width
        {
            get => GetStruct<LongParser.NonNegative, long>("width");
            set => SetStruct<LongParser.NonNegative, long>("width", value);
        }

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
