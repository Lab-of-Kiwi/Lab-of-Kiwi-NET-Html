using System;

namespace LabOfKiwi.Html;

public abstract partial class HtmlContainerElement : IHtmlContainerNode
{
    public void Invoke<THtmlElementProcessor>() where THtmlElementProcessor : IHtmlElementProcessor, new()
    {
        new THtmlElementProcessor().Invoke(this);
    }

    public void Invoke(IHtmlElementProcessor? processor)
    {
        processor?.Invoke(this);
    }

    #region Prepends
    public void PrependComment(string? text)
    {
        if (text != null)
        {
            AddComment(PrependNode, text);
        }
    }

    public void Prepend<TElement>() where TElement : HtmlElement, new()
    {
        AddElement<TElement>(PrependNode, null, null);
    }

    public void Prepend<TElement>(string? text) where TElement : HtmlElement, new()
    {
        AddElement<TElement>(PrependNode, text, null);
    }

    public void Prepend<TElement>(Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        AddElement(PrependNode, null, callback);
    }

    public void Prepend<TElement>(string? text, Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        AddElement(PrependNode, text, callback);
    }

    public void PrependElement(string tagName)
    {
        PrependElement(tagName, null, null);
    }

    public void PrependElement(string tagName, string? text)
    {
        PrependElement(tagName, text, null);
    }

    public void PrependElement(string tagName, Action<HtmlElement>? callback)
    {
        PrependElement(tagName, null, callback);
    }

    public void PrependElement(string tagName, string? text, Action<HtmlElement>? callback)
    {
        if (tagName == null)
        {
            throw new ArgumentNullException(nameof(tagName));
        }

        if (!HtmlHelper.IsValidPotentialCustomElementName(tagName, false))
        {
            throw new ArgumentException("Invalid tag name.", nameof(tagName));
        }

        AddElement(PrependNode, tagName, text, callback);
    }

    public void PrependRawText(string? text)
    {
        if (text != null)
        {
            AddText(PrependNode, text, false);
        }
    }

    public void PrependText(string? text)
    {
        if (text != null)
        {
            AddText(PrependNode, text, true);
        }
    }
    #endregion

    #region Inserts
    public void InsertComment(int index, string? text)
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (text != null)
        {
            AddComment(index, text);
        }
    }

    public void Insert<TElement>(int index) where TElement : HtmlElement, new()
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        AddElement<TElement>(index, null, null);
    }

    public void Insert<TElement>(int index, string? text) where TElement : HtmlElement, new()
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        AddElement<TElement>(index, text, null);
    }

    public void Insert<TElement>(int index, Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        AddElement(index, null, callback);
    }

    public void Insert<TElement>(int index, string? text, Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        AddElement(index, text, callback);
    }

    public void InsertElement(int index, string tagName)
    {
        InsertElement(index, tagName, null, null);
    }

    public void InsertElement(int index, string tagName, string? text)
    {
        InsertElement(index, tagName, text, null);
    }

    public void InsertElement(int index, string tagName, Action<HtmlElement>? callback)
    {
        InsertElement(index, tagName, null, callback);
    }

    public void InsertElement(int index, string tagName, string? text, Action<HtmlElement>? callback)
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (tagName == null)
        {
            throw new ArgumentNullException(nameof(tagName));
        }

        if (!HtmlHelper.IsValidPotentialCustomElementName(tagName, false))
        {
            throw new ArgumentException("Invalid tag name.", nameof(tagName));
        }

        AddElement(index, tagName, text, callback);
    }

    public void InsertRawText(int index, string? text)
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (text != null)
        {
            AddText(index, text, false);
        }
    }

    public void InsertText(int index, string? text)
    {
        if ((uint)index > (uint)Nodes.Children.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (text != null)
        {
            AddText(index, text, true);
        }
    }
    #endregion

    #region Appends
    public void AppendComment(string? text)
    {
        if (text != null)
        {
            AddComment(AppendNode, text);
        }
    }

    public void Append<TElement>() where TElement : HtmlElement, new()
    {
        AddElement<TElement>(AppendNode, null, null);
    }

    public void Append<TElement>(string? text) where TElement : HtmlElement, new()
    {
        AddElement<TElement>(AppendNode, text, null);
    }

    public void Append<TElement>(Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        AddElement(AppendNode, null, callback);
    }

    public void Append<TElement>(string? text, Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        AddElement(AppendNode, text, callback);
    }

    public void AppendElement(string tagName)
    {
        AppendElement(tagName, null, null);
    }

    public void AppendElement(string tagName, string? text)
    {
        AppendElement(tagName, text, null);
    }

    public void AppendElement(string tagName, Action<HtmlElement>? callback)
    {
        AppendElement(tagName, null, callback);
    }

    public void AppendElement(string tagName, string? text, Action<HtmlElement>? callback)
    {
        if (tagName == null)
        {
            throw new ArgumentNullException(nameof(tagName));
        }

        if (!HtmlHelper.IsValidPotentialCustomElementName(tagName, false))
        {
            throw new ArgumentException("Invalid tag name.", nameof(tagName));
        }

        AddElement(AppendNode, tagName, text, callback);
    }

    public void AppendRawText(string? text)
    {
        if (text != null)
        {
            AddText(AppendNode, text, false);
        }
    }

    public void AppendText(string? text)
    {
        if (text != null)
        {
            AddText(AppendNode, text, true);
        }
    }
    #endregion
}
