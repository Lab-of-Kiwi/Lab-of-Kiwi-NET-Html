namespace LabOfKiwi.Html.Elements;

public class DATA : HtmlContainerElement
{
    public string? Value
    {
        get => Get("value");
        set => Set("value", value);
    }
}
