namespace LabOfKiwi.Html.Elements;

public class TIME : HtmlContainerElement
{
    // TODO
    public string? Datetime
    {
        get => Get("datetime");
        set => Set("datatime", value);
    }
}
