namespace LabOfKiwi.Html.Elements;

public class DETAILS : HtmlContainerElement
{
    public bool IsOpen
    {
        get => GetBoolean("open");
        set => SetBoolean("open", value);
    }

    internal sealed override string ExpectedTagName => "details";
}
