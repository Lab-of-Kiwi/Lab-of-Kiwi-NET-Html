namespace LabOfKiwi.Html;

public interface IHtmlSelectorProvider
{
    HtmlSelector AllTypes();

    HtmlSelector AllTypesWithAnyNamespace();

    HtmlSelector AllTypesWithNamespace(string ns);

    HtmlSelector AllTypesWithoutNamespace();

    HtmlSelector OfType<TElement>() where TElement : HtmlElement, new();

    HtmlSelector OfType(string type);

    HtmlSelector WithId(string id);

    HtmlSelector WithClasses(params string[] classes);
}
