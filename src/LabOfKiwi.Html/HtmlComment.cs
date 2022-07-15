using System.Xml;

namespace LabOfKiwi.Html;

public sealed class HtmlComment : HtmlNode
{
    internal HtmlComment(HtmlAgilityPack.HtmlCommentNode coreComment) : base(coreComment)
    {
    }

    public override string NodeName => CoreNode.Name;

    public override XmlNodeType NodeType => XmlNodeType.Comment;

    public override HtmlDocument OwnerDocument => new(CoreNode.OwnerDocument);

    internal new HtmlAgilityPack.HtmlCommentNode CoreNode => (HtmlAgilityPack.HtmlCommentNode)base.CoreNode;
}
