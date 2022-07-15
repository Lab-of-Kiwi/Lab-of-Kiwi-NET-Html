using System.Xml;

namespace LabOfKiwi.Html;

public sealed class HtmlText : HtmlNode
{
    internal HtmlText(HtmlAgilityPack.HtmlTextNode coreText) : base(coreText)
    {
    }

    public override XmlNodeType NodeType => XmlNodeType.Text;

    public override HtmlDocument OwnerDocument => new(CoreNode.OwnerDocument);

    internal new HtmlAgilityPack.HtmlTextNode CoreNode => (HtmlAgilityPack.HtmlTextNode)base.CoreNode;
}
