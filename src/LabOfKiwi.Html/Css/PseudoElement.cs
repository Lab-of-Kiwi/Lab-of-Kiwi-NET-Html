using System;

namespace LabOfKiwi.Html.Css;

public class PseudoElement : SimpleSelector
{
    public static readonly PseudoElement After              = new("after");
    public static readonly PseudoElement Backdrop           = new("backdrop");
    public static readonly PseudoElement Before             = new("before");
    public static readonly PseudoElement Cue                = new("cue");
    public static readonly PseudoElement CueRegion          = new("cue-region");
    public static readonly PseudoElement FileSelectorButton = new("file-selector-button");
    public static readonly PseudoElement FirstLetter        = new("first-letter");
    public static readonly PseudoElement FirstLine          = new("first-line");
    public static readonly PseudoElement Marker             = new("marker");
    public static readonly PseudoElement Placeholder        = new("placeholder");
    public static readonly PseudoElement Selection          = new("selection");
    public static readonly PseudoElement TargetText         = new("target-text");

    internal PseudoElement(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public sealed override CompoundSelector Add(AttributeSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
    }

    public sealed override CompoundSelector Add(ClassSelector selector)
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

    public sealed override CompoundSelector Add(PseudoClass selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new CompoundSelector(selector, this);
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

    public static PseudoElement Part(string part)
    {
        if (part == null)
        {
            throw new ArgumentNullException(nameof(part));
        }

        return new FunctionPseudoElement("part", part);
    }

    public static PseudoElement Slotted(SubComplexSelector selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        return new FunctionPseudoElement("slotted", selector.ToString());
    }

    public override string ToString()
    {
        return $"::{Name}";
    }

    private sealed class FunctionPseudoElement : PseudoElement
    {
        private readonly string _argumentString;

        public FunctionPseudoElement(string name, string argumentString) : base(name)
        {
            _argumentString = argumentString;
        }

        public override string ToString()
        {
            return $"{base.ToString()}({_argumentString})";
        }
    }
}
