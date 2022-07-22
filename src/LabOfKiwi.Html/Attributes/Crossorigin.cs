namespace LabOfKiwi.Html.Attributes;

/// <summary>
/// Represents how the element handles crossorigin requests.
/// </summary>
public enum Crossorigin
{
    /// <summary>
    /// Requests will have their mode set to "cors" and their credentials mode set to
    /// "same-origin".
    /// </summary>
    Anonymous,

    /// <summary>
    /// Requests will have their mode set to "cors" and their credentials mode set to
    /// "include".
    /// </summary>
    UseCredentials
}
