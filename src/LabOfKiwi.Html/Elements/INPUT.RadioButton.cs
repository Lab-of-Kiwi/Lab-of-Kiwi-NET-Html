using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class RadioButton : INPUT
    {
        internal RadioButton(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public bool IsChecked
        {
            get => GetBoolean("checked");
            set => SetBoolean("checked", value);
        }

        public bool IsRequired
        {
            get => GetBoolean("required");
            set => SetBoolean("required", value);
        }

        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
