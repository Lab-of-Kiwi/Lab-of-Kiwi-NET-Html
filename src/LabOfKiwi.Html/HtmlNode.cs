using System;
using System.Diagnostics;
using System.Xml;

namespace LabOfKiwi.Html;

public abstract partial class HtmlNode
{
    private HtmlAgilityPack.HtmlNode _coreNode = null!;

    internal HtmlNode()
    {
    }

    public IRelatives<HtmlNode> Nodes => new RelativeNodes(this);

    public IRelatives<HtmlElement> Elements => new RelativeElements(this);

    public virtual string NodeName => CoreNode.Name;

    public abstract XmlNodeType NodeType { get; }

    public virtual HtmlDocument OwnerDocument => new(CoreNode.OwnerDocument);

    internal HtmlAgilityPack.HtmlNode CoreNode
    {
        get
        {
            if (_coreNode == null)
            {
                throw new InvalidOperationException("Html Agility Pack node not set.");
            }

            return _coreNode;
        }

        set
        {
            if (_coreNode != null)
            {
                throw new InvalidOperationException("Html Agility Pack node already set.");
            }

            _coreNode = value;
        }
    }

    internal bool IsCoreNodeSet => _coreNode != null;

    public sealed override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is HtmlNode other)
        {
            return Equals(CoreNode, other.CoreNode);
        }

        return false;
    }

    public sealed override int GetHashCode()
    {
        return CoreNode.GetHashCode();
    }

    internal static HtmlNode? NullableWrapNode(object? node)
    {
        if (node == null)
        {
            return null;
        }

        return WrapNode(node);
    }

    internal static HtmlNode WrapNode(object node)
    {
        Debug.Assert(node != null);

        if (node is HtmlAgilityPack.HtmlTextNode coreText)
        {
            return new HtmlText(coreText);
        }

        if (node is HtmlAgilityPack.HtmlCommentNode coreComment)
        {
            if (Equals(coreComment.OwnerDocument.DocumentNode.FirstChild, coreComment))
            {
                var comment = coreComment.Comment;

                if (comment.EndsWith('>') && comment.ToUpperInvariant().StartsWith("<!DOCTYPE"))
                {
                    return new HtmlDocumentType(coreComment);
                }
            }

            return new HtmlComment(coreComment);
        }

        if (node is HtmlAgilityPack.HtmlNode coreElement)
        {
            if (coreElement.NodeType == HtmlAgilityPack.HtmlNodeType.Document)
            {
                return new HtmlDocument(coreElement.OwnerDocument);
            }

            Debug.Assert(coreElement.NodeType == HtmlAgilityPack.HtmlNodeType.Element);
            return HtmlElement.WrapElement(coreElement);
        }

        if (node is HtmlAgilityPack.HtmlDocument coreDocument)
        {
            return new HtmlDocument(coreDocument);
        }

        if (node is HtmlAgilityPack.HtmlAttribute coreAttribute)
        {
            return new HtmlAttribute(coreAttribute);
        }

        throw new NotImplementedException("HTML Agility Pack object not implemented: " + node.GetType());
    }
}
