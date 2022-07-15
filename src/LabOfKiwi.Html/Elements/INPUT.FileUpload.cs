using LabOfKiwi.Html.Attributes.Parsers;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public sealed class FileUpload : INPUT
    {
        internal FileUpload(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
        {
        }

        public string? Accept
        {
            get => GetObject<AcceptParser, string>("accept");
            set => SetObject<AcceptParser, string>("accept", value);
        }

        public bool AllowMultiple
        {
            get => GetBoolean("multiple");
            set => SetBoolean("multiple", value);
        }

        public bool IsRequired
        {
            get => GetBoolean("required");
            set => SetBoolean("required", value);
        }

        // TODO
        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
