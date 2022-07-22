using System;

namespace LabOfKiwi.Html;

public enum PseudoElement
{
    After,
    Backdrop,
    Before,
    Cue,
    CueRegion,
    FileSelectorButton,
    FirstLetter,
    FirstLine,
    Marker,
    Placeholder,
    Selection,
    TargetText
}

internal static class PseudoElementExtensions
{
    public static string ToWebString(this PseudoElement value) => value switch
    {
        PseudoElement.After => "after",
        PseudoElement.Backdrop => "backdrop",
        PseudoElement.Before => "before",
        PseudoElement.Cue => "cue",
        PseudoElement.CueRegion => "cue-region",
        PseudoElement.FileSelectorButton => "file-selector-button",
        PseudoElement.FirstLetter => "first-letter",
        PseudoElement.FirstLine => "first-line",
        PseudoElement.Marker => "marker",
        PseudoElement.Placeholder => "placeholder",
        PseudoElement.Selection => "selection",
        PseudoElement.TargetText => "target-text",
        _ => throw new NotImplementedException(),
    };
}