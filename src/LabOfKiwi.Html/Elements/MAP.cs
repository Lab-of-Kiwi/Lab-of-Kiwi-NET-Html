namespace LabOfKiwi.Html.Elements;

public class MAP : HtmlContainerElement
{
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }
}
