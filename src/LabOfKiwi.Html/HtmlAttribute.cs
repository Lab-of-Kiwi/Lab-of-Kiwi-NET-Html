using System.Xml;

namespace LabOfKiwi.Html;

public sealed class HtmlAttribute : HtmlNode
{
    internal HtmlAttribute(HtmlAgilityPack.HtmlAttribute coreAttribute) : base(coreAttribute.OwnerNode)
    {
        CoreAttribute = coreAttribute;
    }

    public override XmlNodeType NodeType => XmlNodeType.Attribute;

    public override HtmlDocument OwnerDocument => new(CoreNode.OwnerDocument);

    internal HtmlAgilityPack.HtmlAttribute CoreAttribute { get; }
}
