using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;

namespace LabOfKiwi.Html;

public abstract partial class HtmlNode
{
    internal const int AppendNode = -1;
    internal const int PrependNode = -2;

    internal void AddComment(int index, string text)
    {
        Debug.Assert(text != null);
        var xmlComment = CreateComment(text);
        AddNode(index, xmlComment);
    }

    internal void AddElement(int index, string tagName, string? text, Action<HtmlElement>? callback)
    {
        HtmlElement htmlElement = CreateElement(tagName);
        AddNode(index, htmlElement.CoreNode);

        if (text != null)
        {
            htmlElement.AddText(AppendNode, text, true);
        }

        callback?.Invoke(htmlElement);
    }

    internal void AddElement<TElement>(int index, string? text, Action<TElement>? callback) where TElement : HtmlElement, new()
    {
        TElement htmlElement = CreateElement<TElement>();
        AddNode(index, htmlElement.CoreNode);

        if (text != null)
        {
            htmlElement.AddText(AppendNode, text, true);
        }

        callback?.Invoke(htmlElement);
    }

    private void AddNode(int index, HtmlAgilityPack.HtmlNode node)
    {
        Debug.Assert(PrependNode <= index && index <= CoreNode.ChildNodes.Count);

        if (index == AppendNode || index == CoreNode.ChildNodes.Count)
        {
            CoreNode.AppendChild(node);
        }
        else if (index == PrependNode)
        {
            CoreNode.PrependChild(node);
        }
        else
        {
            var currentNodeAtIndex = CoreNode.ChildNodes[index];
            Debug.Assert(currentNodeAtIndex != null);
            CoreNode.InsertBefore(node, currentNodeAtIndex);
        }
    }

    protected void AddNodes(int index, IEnumerable<HtmlNode> htmlNodes)
    {
        Debug.Assert(PrependNode <= index && index <= CoreNode.ChildNodes.Count);

        if (index == AppendNode || index == CoreNode.ChildNodes.Count)
        {
            foreach (var htmlNode in htmlNodes)
            {
                CoreNode.AppendChild(htmlNode.CoreNode);
            }

            return;
        }

        if (index == PrependNode)
        {
            index = 0;
        }

        foreach (var htmlNode in htmlNodes)
        {
            var currentNodeAtIndex = CoreNode.ChildNodes[index++];
            Debug.Assert(currentNodeAtIndex != null);
            CoreNode.InsertBefore(htmlNode.CoreNode, currentNodeAtIndex);
        }
    }

    internal void AddText(int index, string text, bool requiresEncoding)
    {
        Debug.Assert(text != null);
        var xmlText = CreateText(text, requiresEncoding);
        AddNode(index, xmlText);
    }

    internal HtmlAgilityPack.HtmlCommentNode CreateComment(string text)
    {
        return OwnerDocument.CoreDocument.CreateComment(text);
    }

    internal HtmlElement CreateElement(string tagName)
    {
        HtmlAgilityPack.HtmlNode node = OwnerDocument.CoreDocument.CreateElement(tagName);
        return HtmlElement.WrapElement(node);
    }

    internal TElement CreateElement<TElement>() where TElement : HtmlElement, new()
    {
        TElement htmlElement = new();
        HtmlAgilityPack.HtmlNode node = OwnerDocument.CoreDocument.CreateElement(htmlElement.ExpectedTagName);
        htmlElement.CoreNode = node;
        //xmlElement.IsEmpty = htmlElement.IsVoidElement;
        return htmlElement;
    }

    internal HtmlAgilityPack.HtmlTextNode CreateText(string text, bool requiresEncoding)
    {
        if (requiresEncoding)
        {
            text = HttpUtility.HtmlEncode(text);
        }

        return OwnerDocument.CoreDocument.CreateTextNode(text);
    }
}
