namespace LabOfKiwi.Html;

public class PseudoElement
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

    public override string ToString()
    {
        return Name;
    }
}
