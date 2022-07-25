using System;
using System.IO;
using System.Text;
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

    internal HtmlDocument(HtmlAgilityPack.HtmlDocument coreDocument)
    {
        CoreNode = coreDocument.DocumentNode;
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

    public static HtmlDocument Load(Stream stream)
    {
        return Load(new StreamReader(stream));
    }

    public static HtmlDocument Load(Stream stream, bool detectEncodingFromByteOrderMarks)
    {
        return Load(new StreamReader(stream, detectEncodingFromByteOrderMarks));
    }

    public static HtmlDocument Load(Stream stream, Encoding encoding)
    {
        return Load(new StreamReader(stream, encoding));
    }

    public static HtmlDocument Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks)
    {
        return Load(new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks));
    }

    public static HtmlDocument Load(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
    {
        return Load(new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, buffersize));
    }

    public static HtmlDocument Load(string path)
    {
        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var coreDocument = new HtmlAgilityPack.HtmlDocument();
        coreDocument.Load(path);
        return new HtmlDocument(coreDocument);
    }

    public static HtmlDocument Load(TextReader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }

        var coreDocument = new HtmlAgilityPack.HtmlDocument();
        coreDocument.Load(reader);
        return new HtmlDocument(coreDocument);
    }

    public static HtmlDocument LoadHtml(string html)
    {
        if (html == null)
        {
            throw new ArgumentNullException(nameof(html));
        }

        var coreDocument = new HtmlAgilityPack.HtmlDocument();
        coreDocument.LoadHtml(html);
        return new HtmlDocument(coreDocument);
    }

    internal HtmlAgilityPack.HtmlDocument CoreDocument { get; }
}