using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class ResetButton : INPUT
    {
        internal ResetButton(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
