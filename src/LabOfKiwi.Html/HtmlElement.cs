using System;
using System.Diagnostics;
using System.Xml;

namespace LabOfKiwi.Html;

public abstract partial class HtmlElement : HtmlNode
{
    internal HtmlElement(HtmlAgilityPack.HtmlNode coreElement) : base(coreElement)
    {
        Debug.Assert(coreElement.NodeType == HtmlAgilityPack.HtmlNodeType.Element);
    }

    public abstract bool IsVoidElement { get; }

    public sealed override string NodeName => base.NodeName;

    public sealed override XmlNodeType NodeType => XmlNodeType.Element;

    public sealed override HtmlDocument OwnerDocument => base.OwnerDocument;

    public string? GetAttributeValue(string attributeName)
    {
        if (attributeName == null)
        {
            throw new ArgumentNullException(nameof(attributeName));
        }

        return Get(attributeName);
    }

    internal static HtmlElement WrapElement(HtmlAgilityPack.HtmlNode coreElement)
    {
        Debug.Assert(coreElement != null && coreElement.NodeType == HtmlAgilityPack.HtmlNodeType.Element);
        var element = ElementRegistry.Instantiate(coreElement);
        return element;
    }
}
