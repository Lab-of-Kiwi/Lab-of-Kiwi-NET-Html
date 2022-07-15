using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class SubmitButton : INPUT
    {
        internal SubmitButton(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public bool AllowFormValidation
        {
            get => !GetBoolean("formnovalidate");
            set => SetBoolean("formnovalidate", !value);
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

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
