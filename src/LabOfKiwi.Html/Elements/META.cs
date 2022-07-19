using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System.Text;

namespace LabOfKiwi.Html.Elements;

public class META : HtmlVoidElement
{
    public Encoding? Charset
    {
        get => GetObject<CharsetParser, Encoding>("charset");
        set => SetObject<CharsetParser, Encoding>("charset", value);
    }

    public string? Content
    {
        get => Get("content");
        set => Set("content", value);
    }

    public PragmaDirective? HttpEquiv
    {
        get => GetStruct<PragmaDirectiveParser, PragmaDirective>("http-equiv");
        set => SetStruct<PragmaDirectiveParser, PragmaDirective>("http-equiv", value);
    }

    // TODO
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    internal sealed override string ExpectedTagName => "meta";
}
