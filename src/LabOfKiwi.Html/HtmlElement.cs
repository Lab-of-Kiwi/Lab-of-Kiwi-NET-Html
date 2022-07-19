using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Elements;
using System;
using System.Diagnostics;
using System.Xml;

namespace LabOfKiwi.Html;

public abstract partial class HtmlElement : HtmlNode
{
    internal HtmlElement()
    {
    }

    public abstract bool IsVoidElement { get; }

    public sealed override string NodeName => base.NodeName;

    public sealed override XmlNodeType NodeType => XmlNodeType.Element;

    public sealed override HtmlDocument OwnerDocument => base.OwnerDocument;

    internal virtual string ExpectedTagName => GetType().Name.ToLowerInvariant();

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

        string tagName = coreElement.Name;
        Type? elementClass;

        if (tagName == "input")
        {
            string inputTypeRaw = coreElement.GetAttributeValue("type", "");
            InputType inputType = InputTypeUtility.Parse(inputTypeRaw);
            elementClass = inputType.GetClassType();
        }
        else
        {
            elementClass = Type.GetType($"{typeof(INPUT).Namespace}.{tagName.ToUpperInvariant()}");
        }

        HtmlElement htmlElement;

        if (elementClass != null)
        {
            htmlElement = (HtmlElement)Activator.CreateInstance(elementClass)!;
            Debug.Assert(htmlElement != null);
        }
        else
        {
            htmlElement = new CustomElement(tagName);
        }

        htmlElement.CoreNode = coreElement;
        return htmlElement;
    }
}
