using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Color : INPUT
    {
        internal Color(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        // TODO
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

        public new System.Drawing.Color? Value
        {
            get => GetStruct<ColorParser, System.Drawing.Color>("value");
            set => SetStruct<ColorParser, System.Drawing.Color>("value", value);
        }
    }
}
