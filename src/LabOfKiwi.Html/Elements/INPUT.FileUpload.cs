using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class FileUpload : INPUT
    {
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
