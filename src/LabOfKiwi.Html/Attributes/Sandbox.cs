using LabOfKiwi.Collections;
using System;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Attributes;

[Flags]
public enum Sandbox : ushort
{
    None = 0x0000,
    AllowDownloads = 0x0001,
    AllowForms = 0x0002,
    AllowModals = 0x0004,
    AllowOrientationLock = 0x0008,
    AllowPointerLock = 0x0010,
    AllowPopups = 0x0020,
    AllowPopupsToEscapeSandbox = 0x0040,
    AllowPresentation = 0x0080,
    AllowSameOrigin = 0x0100,
    AllowScripts = 0x0200,
    AllowTopNavigation = 0x0400,
    AllowTopNavigationByUserActivation = 0x0800,
    AllowTopNavigationToCustomProtocols = 0x1000,
    AllowAll = 0x1FFF
}

internal static class SandboxUtility
{
    private static readonly Map<Sandbox, string> _optionMap = new();

    static SandboxUtility()
    {
        _optionMap.Add(Sandbox.AllowDownloads, "allow-downloads");
        _optionMap.Add(Sandbox.AllowForms, "allow-forms");
        _optionMap.Add(Sandbox.AllowModals, "allow-modals");
        _optionMap.Add(Sandbox.AllowOrientationLock, "allow-orientation-lock");
        _optionMap.Add(Sandbox.AllowPointerLock, "allow-pointer-lock");
        _optionMap.Add(Sandbox.AllowPopups, "allow-popups");
        _optionMap.Add(Sandbox.AllowPopupsToEscapeSandbox, "allow-popups-to-escape-sandbox");
        _optionMap.Add(Sandbox.AllowPresentation, "allow-presentation");
        _optionMap.Add(Sandbox.AllowSameOrigin, "allow-same-origin");
        _optionMap.Add(Sandbox.AllowScripts, "allow-scripts");
        _optionMap.Add(Sandbox.AllowTopNavigation, "allow-top-navigation");
        _optionMap.Add(Sandbox.AllowTopNavigationByUserActivation, "allow-top-navigation-by-user-activation");
        _optionMap.Add(Sandbox.AllowTopNavigationToCustomProtocols, "allow-top-navigation-to-custom-protocols");
    }

    public static string? ToHTMLString(Sandbox value, string delimiter)
    {
        if (value == Sandbox.None)
        {
            return null;
        }

        List<string> stringValues = new();

        for (int i = 0; i < 13; i++)
        {
            Sandbox optionToAdd = (Sandbox)(ushort)(1U << i);

            if (value.HasFlag(optionToAdd))
            {
                stringValues.Add(_optionMap[optionToAdd]);
            }
        }

        return string.Join(delimiter, stringValues);
    }

    public static bool TryParse(string? stringValue, string delimiter, out Sandbox result)
    {
        if (string.IsNullOrEmpty(stringValue))
        {
            result = Sandbox.None;
            return true;
        }

        result = Sandbox.None;

        string[] rawValues = stringValue.Split(delimiter, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        foreach (string rawValue in rawValues)
        {
            if (_optionMap.Reverse.TryGetValue(rawValue, out Sandbox value))
            {
                result |= value;
            }
            else
            {
                result = default;
                return false;
            }
        }

        return true;
    }
}
