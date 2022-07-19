using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class Color : INPUT
    {
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
