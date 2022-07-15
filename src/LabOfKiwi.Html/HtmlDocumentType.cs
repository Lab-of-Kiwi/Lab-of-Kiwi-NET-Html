using System.Xml;

namespace LabOfKiwi.Html;

public sealed class HtmlDocumentType : HtmlNode
{
    internal HtmlDocumentType(HtmlAgilityPack.HtmlCommentNode coreDocumentType) : base(coreDocumentType)
    {
    }

    public override string NodeName => CoreNode.InnerText[10..^1];

    public override XmlNodeType NodeType => XmlNodeType.DocumentType;

    public override HtmlDocument OwnerDocument => new(CoreNode.OwnerDocument);

    internal new HtmlAgilityPack.HtmlCommentNode CoreNode => (HtmlAgilityPack.HtmlCommentNode)base.CoreNode;
}
