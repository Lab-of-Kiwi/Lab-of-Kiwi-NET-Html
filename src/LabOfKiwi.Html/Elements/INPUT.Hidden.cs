namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class Hidden : INPUT
    {
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
