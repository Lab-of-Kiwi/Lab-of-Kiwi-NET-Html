using System;

namespace LabOfKiwi.Html;

public interface IHtmlContainerNode
{
    void Invoke<THtmlElementProcessor>() where THtmlElementProcessor : IHtmlElementProcessor, new();

    void Invoke(IHtmlElementProcessor? processor);

    #region Prepends
    void PrependComment(string? text);

    void PrependElement(string tagName);

    void PrependElement(string tagName, string? text);

    void PrependElement(string tagName, Action<HtmlElement>? callback);

    void PrependElement(string tagName, string? text, Action<HtmlElement>? callback);

    void Prepend<TElement>() where TElement : HtmlElement, new();

    void Prepend<TElement>(string? text) where TElement : HtmlElement, new();

    void Prepend<TElement>(Action<TElement>? callback) where TElement : HtmlElement, new();

    void Prepend<TElement>(string? text, Action<TElement>? callback) where TElement : HtmlElement, new();

    void PrependRawText(string? text);

    void PrependText(string? text);
    #endregion

    #region Inserts
    void InsertComment(int index, string? text);

    void InsertElement(int index, string tagName);

    void InsertElement(int index, string tagName, string? text);

    void InsertElement(int index, string tagName, Action<HtmlElement>? callback);

    void InsertElement(int index, string tagName, string? text, Action<HtmlElement>? callback);

    void Insert<TElement>(int index) where TElement : HtmlElement, new();

    void Insert<TElement>(int index, string? text) where TElement : HtmlElement, new();

    void Insert<TElement>(int index, Action<TElement>? callback) where TElement : HtmlElement, new();

    void Insert<TElement>(int index, string? text, Action<TElement>? callback) where TElement : HtmlElement, new();

    void InsertRawText(int index, string? text);

    void InsertText(int index, string? text);
    #endregion

    #region Appends
    void AppendComment(string? text);

    void AppendElement(string tagName);

    void AppendElement(string tagName, string? text);

    void AppendElement(string tagName, Action<HtmlElement>? callback);

    void AppendElement(string tagName, string? text, Action<HtmlElement>? callback);

    void Append<TElement>() where TElement : HtmlElement, new();

    void Append<TElement>(string? text) where TElement : HtmlElement, new();

    void Append<TElement>(Action<TElement>? callback) where TElement : HtmlElement, new();

    void Append<TElement>(string? text, Action<TElement>? callback) where TElement : HtmlElement, new();

    void AppendRawText(string? text);

    void AppendText(string? text);
    #endregion
}
