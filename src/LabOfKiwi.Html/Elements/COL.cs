using LabOfKiwi.Html.Attributes.Parsers;

namespace LabOfKiwi.Html.Elements;

public class COL : HtmlVoidElement
{
    public long? Span
    {
        get => GetStruct<LongParser.Positive, long>("span");
        set => SetStruct<LongParser.Positive, long>("span", value);
    }

    internal sealed override string ExpectedTagName => "col";
}
