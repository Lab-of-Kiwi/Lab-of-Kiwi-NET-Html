using System.IO;
using System.Xml;

namespace LabOfKiwi.Html;

public sealed partial class HtmlDocument : HtmlNode
{
    public enum DocType
    {
        None,
        Html5
    }

    public HtmlDocument(DocType docType = DocType.Html5) : this(new HtmlAgilityPack.HtmlDocument())
    {
        string? docTypeString = docType switch
        {
            DocType.Html5 => "html",
            _ => null
        };

        if (docTypeString != null)
        {
            var comment = CoreDocument.CreateComment($"<!DOCTYPE {docTypeString}>");
            CoreNode.AppendChild(comment);
        }
    }

    internal HtmlDocument(HtmlAgilityPack.HtmlDocument coreDocument) : base(coreDocument.DocumentNode)
    {
        CoreDocument = coreDocument;
    }

    public override XmlNodeType NodeType => XmlNodeType.Document;

    public override HtmlDocument OwnerDocument => this;

    public string GetHtml()
    {
        using var writer = new StringWriter();
        CoreDocument.Save(writer);
        return writer.ToString();
    }

    internal HtmlAgilityPack.HtmlDocument CoreDocument { get; }
}