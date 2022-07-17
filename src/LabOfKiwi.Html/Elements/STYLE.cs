using LabOfKiwi.Html.Attributes.Parsers;
using System.Collections.Generic;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public sealed class STYLE : HtmlElement
{
    internal STYLE(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
    }

    public ISet<string> Blocking => GetSet<TokenParser, string>("blocking", delimiter: " ");

    public string? Content
    {
        get
        {
            if (!CoreNode.HasChildNodes)
            {
                return null;
            }

            return CoreNode.ChildNodes[0].InnerText;
        }

        set
        {
            CoreNode.ChildNodes.Clear();

            if (value != null)
            {
                var textNode = CoreNode.OwnerDocument.CreateTextNode(value);
                CoreNode.AppendChild(textNode);
            }
        }
    }

    public sealed override bool IsVoidElement => false;

    // TODO
    public string? Media
    {
        get => Get("media");
        set => Set("media", value);
    }
}
