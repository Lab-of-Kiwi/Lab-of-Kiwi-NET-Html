using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class Hidden : INPUT
    {
        internal Hidden(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public string? AutoComplete
        {
            get => Get("autocomplete");
            set => Set("autocomplete", value);
        }

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
