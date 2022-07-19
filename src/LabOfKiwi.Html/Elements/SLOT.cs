namespace LabOfKiwi.Html.Elements;

public class SLOT : HtmlContainerElement
{
    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    internal sealed override string ExpectedTagName => "slot";
}
