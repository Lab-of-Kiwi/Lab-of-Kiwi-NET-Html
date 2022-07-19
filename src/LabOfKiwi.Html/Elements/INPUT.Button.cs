namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class Button : INPUT
    {
        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
