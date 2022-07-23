using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using System;

namespace LabOfKiwi.Html.Elements;

public partial class INPUT : HtmlVoidElement
{
    private readonly InputType _expectedType;

    internal INPUT()
    {
        _expectedType = InputTypeUtility.GetInputType(GetType());
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

    internal sealed override string ExpectedTagName => "input";

    internal sealed override void OnCoreNodeSet()
    {
        if (_expectedType != InputType.Unknown)
        {
            CoreNode.SetAttributeValue("type", _expectedType.ToWebString());
        }
    }
}
