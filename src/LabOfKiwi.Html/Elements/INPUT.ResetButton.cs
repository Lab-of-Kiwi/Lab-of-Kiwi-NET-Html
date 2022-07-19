namespace LabOfKiwi.Html.Elements;

public partial class INPUT
{
    public class ResetButton : INPUT
    {
        public new string? Value
        {
            get => Get("value");
            set => Set("value", value);
        }
    }
}
