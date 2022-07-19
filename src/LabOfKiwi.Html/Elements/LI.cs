using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class LI : HtmlContainerElement
{
    public long? Value
    {
        get => GetStruct<LongParser, long>("value");
        set => SetStruct<LongParser, long>("value", value);
    }

    internal sealed override string ExpectedTagName => "li";
}
