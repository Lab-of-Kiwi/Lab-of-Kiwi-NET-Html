using LabOfKiwi.Html.Attributes;
using LabOfKiwi.Html.Attributes.Parsers;
using LabOfKiwi.Numerics;
using System;
using System.Diagnostics;
using System.Globalization;

namespace LabOfKiwi.Html.Css;

public class PseudoClass : SimpleSelector
{
    public static readonly PseudoClass Active           = new("active");
    public static readonly PseudoClass AnyLink          = new("any-link");
    public static readonly PseudoClass Autofill         = new("autofill");
    public static readonly PseudoClass Checked          = new("checked");
    public static readonly PseudoClass Default          = new("default");
    public static readonly PseudoClass Defined          = new("defined");
    public static readonly PseudoClass Disabled         = new("disabled");
    public static readonly PseudoClass Empty            = new("empty");
    public static readonly PseudoClass Enabled          = new("enabled");
    public static readonly PseudoClass First            = new("first");
    public static readonly PseudoClass FirstChild       = new("first-child");
    public static readonly PseudoClass FirstOfType      = new("first-of-type");
    public static readonly PseudoClass Focus            = new("focus");
    public static readonly PseudoClass FocusVisible     = new("focus-visible");
    public static readonly PseudoClass FocusWithin      = new("focus-within");
    public static readonly PseudoClass Fullscreen       = new("fullscreen");
    public static readonly PseudoClass Hover            = new("hover");
    public static readonly PseudoClass InRange          = new("in-range");
    public static readonly PseudoClass Indeterminate    = new("indeterminate");
    public static readonly PseudoClass Invalid          = new("invalid");
    public static readonly PseudoClass LastChild        = new("last-child");
    public static readonly PseudoClass LastOfType       = new("last-of-type");
    public static readonly PseudoClass Left             = new("left");
    public static readonly PseudoClass Link             = new("link");
    public static readonly PseudoClass OnlyChild        = new("only-child");
    public static readonly PseudoClass OnlyOfType       = new("only-of-type");
    public static readonly PseudoClass Optional         = new("optional");
    public static readonly PseudoClass OutOfRange       = new("out-of-range");
    public static readonly PseudoClass Paused           = new("paused");
    public static readonly PseudoClass PictureInPicture = new("picture-in-picture");
    public static readonly PseudoClass PlaceholderShown = new("placholder-shown");
    public static readonly PseudoClass Playing          = new("playing");
    public static readonly PseudoClass ReadOnly         = new("read-only");
    public static readonly PseudoClass ReadWrite        = new("read-write");
    public static readonly PseudoClass Required         = new("required");
    public static readonly PseudoClass Right            = new("right");
    public static readonly PseudoClass Root             = new("root");
    public static readonly PseudoClass Scope            = new("scope");
    public static readonly PseudoClass Target           = new("target");
    public static readonly PseudoClass UserInvalid      = new("user-invalid");
    public static readonly PseudoClass UseValid         = new("use-valid");
    public static readonly PseudoClass Valid            = new("valid");
    public static readonly PseudoClass Visited          = new("visited");

    private static readonly PseudoClass s_ltr  = new FunctionPseudoClass("dir", "ltr");
    private static readonly PseudoClass s_rtl  = new FunctionPseudoClass("dir", "rtl");
    private static readonly PseudoClass s_host = new("host");

    internal PseudoClass(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public override CompoundSelector Add(AttributeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public override CompoundSelector Add(ClassSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public CompoundSelector Add(IdSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public override CompoundSelector Add(PseudoClass selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public CompoundSelector Add(PseudoElement selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(this, selector);
    }

    public CompoundSelector Add(TypeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public CompoundSelector Add(UniversalSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public static PseudoClass Dir(TextDirection value) => value switch
    {
        TextDirection.LeftToRight => s_ltr,
        TextDirection.RightToLeft => s_rtl,
        _ => throw new ArgumentException("Must use LTR or RTL."),
    };

    public static PseudoClass Has(RelativeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("has", selector.ToString());
    }

    public static PseudoClass Host()
    {
        return s_host;
    }

    public static PseudoClass Host(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("host", selector.ToString());
    }

    public static PseudoClass HostContext(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("host-context", selector.ToString());
    }

    public static PseudoClass Is(Selector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("is", selector.ToString());
    }

    public static PseudoClass Lang(CultureInfo cultureInfo)
    {
        if (cultureInfo == null)
        {
            throw new ArgumentNullException(nameof(cultureInfo));
        }

        new CultureInfoParser().TryToString(cultureInfo, out string? output);
        Debug.Assert(output != null);
        return new FunctionPseudoClass("lang", output);
    }

    public static PseudoClass Not(Selector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("not", selector.ToString());
    }

    public static PseudoClass NthChild(Parity parity, Selector? selector = null)
    {
        string parityString = parity == Parity.Even ? "even" : "odd";

        if (selector == null)
        {
            return new FunctionPseudoClass("nth-child", parityString);
        }

        return new FunctionPseudoClass("nth-child", $"{parityString} of {selector}");
    }

    public static PseudoClass NthChild(int a, int b, Selector? selector = null)
    {
        string parityString;

        if (a == 0)
        {
            parityString = b.ToString();
        }
        else if (b == 0)
        {
            parityString = $"{a}n";
        }
        else
        {
            parityString = $"{a}n+{b}";
        }

        if (selector == null)
        {
            return new FunctionPseudoClass("nth-child", parityString);
        }

        return new FunctionPseudoClass("nth-child", $"{parityString} of {selector}");
    }

    public static PseudoClass NthLastChild(Parity parity, Selector? selector = null)
    {
        string parityString = parity == Parity.Even ? "even" : "odd";

        if (selector == null)
        {
            return new FunctionPseudoClass("nth-last-child", parityString);
        }

        return new FunctionPseudoClass("nth-last-child", $"{parityString} of {selector}");
    }

    public static PseudoClass NthLastChild(int a, int b, Selector? selector = null)
    {
        string parityString;

        if (a == 0)
        {
            parityString = b.ToString();
        }
        else if (b == 0)
        {
            parityString = $"{a}n";
        }
        else
        {
            parityString = $"{a}n+{b}";
        }

        if (selector == null)
        {
            return new FunctionPseudoClass("nth-last-child", parityString);
        }

        return new FunctionPseudoClass("nth-last-child", $"{parityString} of {selector}");
    }

    public static PseudoClass NthLastOfType(Parity parity)
    {
        return new FunctionPseudoClass("nth-last-of-type", parity == Parity.Even ? "even" : "odd");
    }

    public static PseudoClass NthLastOfType(int a, int b)
    {
        string parityString;

        if (a == 0)
        {
            parityString = b.ToString();
        }
        else if (b == 0)
        {
            parityString = $"{a}n";
        }
        else
        {
            parityString = $"{a}n+{b}";
        }

        return new FunctionPseudoClass("nth-last-of-type", parityString);
    }

    public static PseudoClass NthOfType(Parity parity)
    {
        return new FunctionPseudoClass("nth-of-type", parity == Parity.Even ? "even" : "odd");
    }

    public static PseudoClass NthOfType(int a, int b)
    {
        string parityString;

        if (a == 0)
        {
            parityString = b.ToString();
        }
        else if (b == 0)
        {
            parityString = $"{a}n";
        }
        else
        {
            parityString = $"{a}n+{b}";
        }

        return new FunctionPseudoClass("nth-of-type", parityString);
    }

    public static PseudoClass Where(Selector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoClass("where", selector.ToString());
    }

    public override string ToString()
    {
        return $":{Name}";
    }

    private sealed class FunctionPseudoClass : PseudoClass
    {
        private readonly string _argumentString;

        public FunctionPseudoClass(string name, string argumentString) : base(name)
        {
            _argumentString = argumentString;
        }

        public override string ToString()
        {
            return $"{base.ToString()}({_argumentString})";
        }
    }
}