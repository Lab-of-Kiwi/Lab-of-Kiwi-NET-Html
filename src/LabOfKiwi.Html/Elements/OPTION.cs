namespace LabOfKiwi.Html.Elements;

public class OPTION : HtmlContainerElement
{
    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public bool IsSelected
    {
        get => GetBoolean("selected");
        set => SetBoolean("selected", value);
    }

    public string? Label
    {
        get => Get("label");
        set => Set("label", value);
    }

    public string? Value
    {
        get => Get("value");
        set => Set("value", value);
    }

    internal sealed override string ExpectedTagName => "option";
}
