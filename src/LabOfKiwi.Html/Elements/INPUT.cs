using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;
using System.Xml;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT : HtmlVoidElement
{
    private readonly InputType _expectedType;

    internal INPUT(HtmlAgilityPack.HtmlNode xmlElement) : base(xmlElement)
    {
        _expectedType = InputTypeUtility.GetInputType(GetType());

        if (_expectedType != InputType.Unknown)
        {
            CoreNode.SetAttributeValue("type", _expectedType.ToWebString());
        }
    }

    public string? Form
    {
        get => GetObject<TokenParser, string>("form");
        set => SetObject<TokenParser, string>("form", value);
    }

    public bool IsDisabled
    {
        get => GetBoolean("disabled");
        set => SetBoolean("disabled", value);
    }

    public string? Name
    {
        get => Get("name");
        set => Set("name", value);
    }

    public InputType Type
    {
        get => _expectedType;
    }

    public string? TypeString
    {
        get
        {
            if (_expectedType == InputType.Unknown)
            {
                return Get("type");
            }

            return _expectedType.ToWebString();
        }

        set
        {
            if (GetType() != typeof(INPUT))
            {
                throw new InvalidOperationException("Cannot set type of a derived input element.");
            }

            Set("type", value);
        }
    }

    public string? Value => Get("value");
}
