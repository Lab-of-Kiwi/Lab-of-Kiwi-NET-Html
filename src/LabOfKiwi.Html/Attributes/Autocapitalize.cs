namespace LabOfKiwi.Html.Attributes;

/// <summary>
/// Recommended autocapitalization behavior for supported input methods.
/// </summary>
public enum Autocapitalize
{
    /// <summary>
    /// No autocapitalization should be applied (all letters should default to lowercase).
    /// </summary>
    None,

    /// <summary>
    /// Alias for <see cref="None"/>.
    /// </summary>
    Off,

    /// <summary>
    /// The first letter of each sentence should default to a capital letter;
    /// all other letters should default to lowercase.
    /// </summary>
    Sentences,

    /// <summary>
    /// Alias for <see cref="Sentences"/>.
    /// </summary>
    On,
    
    /// <summary>
    /// The first letter of each word should default to a capital letter;
    /// all other letters should default to lowercase.
    /// </summary>
    Words,

    /// <summary>
    /// All letters should default to uppercase.
    /// </summary>
    Characters
}
