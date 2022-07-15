namespace LabOfKiwi.Html.Attributes;

public class Events
{
    protected readonly HtmlElement _element;

    internal Events(HtmlElement element)
    {
        _element = element;
    }

    public string? OnAuxClick
    {
        get => _element.Get("onauxclick");
        set => _element.Set("onauxclick", value);
    }

    public string? OnBeforeMatch
    {
        get => _element.Get("onbeforematch");
        set => _element.Set("onbeforematch", value);
    }

    public string? OnBlur
    {
        get => _element.Get("onblur");
        set => _element.Set("onblur", value);
    }

    public string? OnCancel
    {
        get => _element.Get("oncancel");
        set => _element.Set("oncancel", value);
    }

    public string? OnCanPlay
    {
        get => _element.Get("oncanplay");
        set => _element.Set("oncanplay", value);
    }

    public string? OnCanPlaythrough
    {
        get => _element.Get("oncanplaythrough");
        set => _element.Set("oncanplaythrough", value);
    }

    public string? OnChange
    {
        get => _element.Get("onchange");
        set => _element.Set("onchange", value);
    }

    public string? OnClick
    {
        get => _element.Get("onclick");
        set => _element.Set("onclick", value);
    }

    public string? OnClose
    {
        get => _element.Get("onclose");
        set => _element.Set("onclose", value);
    }

    public string? OnContextLost
    {
        get => _element.Get("oncontextlost");
        set => _element.Set("oncontextlost", value);
    }

    public string? OnContextMenu
    {
        get => _element.Get("oncontextmenu");
        set => _element.Set("oncontextmenu", value);
    }

    public string? OnContextRestored
    {
        get => _element.Get("oncontextrestored");
        set => _element.Set("oncontextrestored", value);
    }

    public string? OnCopy
    {
        get => _element.Get("oncopy");
        set => _element.Set("oncopy", value);
    }

    public string? OnCueChange
    {
        get => _element.Get("oncuechange");
        set => _element.Set("oncuechange", value);
    }

    public string? OnCut
    {
        get => _element.Get("oncut");
        set => _element.Set("oncut", value);
    }

    public string? OnDblClick
    {
        get => _element.Get("ondblclick");
        set => _element.Set("ondblclick", value);
    }

    public string? OnDrag
    {
        get => _element.Get("ondrag");
        set => _element.Set("ondrag", value);
    }

    public string? OnDragEnd
    {
        get => _element.Get("ondragend");
        set => _element.Set("ondragend", value);
    }

    public string? OnDragEnter
    {
        get => _element.Get("ondragenter");
        set => _element.Set("ondragenter", value);
    }

    public string? OnDragLeave
    {
        get => _element.Get("ondragleave");
        set => _element.Set("ondragleave", value);
    }

    public string? OnDragOver
    {
        get => _element.Get("ondragover");
        set => _element.Set("ondragover", value);
    }

    public string? OnDragStart
    {
        get => _element.Get("ondragstart");
        set => _element.Set("ondragstart", value);
    }

    public string? OnDrop
    {
        get => _element.Get("ondrop");
        set => _element.Set("ondrop", value);
    }

    public string? OnDurationChange
    {
        get => _element.Get("ondurationchange");
        set => _element.Set("ondurationchange", value);
    }

    public string? OnEmptied
    {
        get => _element.Get("onemptied");
        set => _element.Set("onemptied", value);
    }

    public string? OnEnded
    {
        get => _element.Get("onended");
        set => _element.Set("onended", value);
    }

    public string? OnError
    {
        get => _element.Get("onerror");
        set => _element.Set("onerror", value);
    }

    public string? OnFocus
    {
        get => _element.Get("onfocus");
        set => _element.Set("onfocus", value);
    }

    public string? OnFormData
    {
        get => _element.Get("onformdata");
        set => _element.Set("onformdata", value);
    }

    public string? OnInput
    {
        get => _element.Get("oninput");
        set => _element.Set("oninput", value);
    }

    public string? OnInvalid
    {
        get => _element.Get("oninvalid");
        set => _element.Set("oninvalid", value);
    }

    public string? OnKeyDown
    {
        get => _element.Get("onkeydown");
        set => _element.Set("onkeydown", value);
    }

    public string? OnKeyPress
    {
        get => _element.Get("onkeypress");
        set => _element.Set("onkeypress", value);
    }

    public string? OnKeyUp
    {
        get => _element.Get("onkeyup");
        set => _element.Set("onkeyup", value);
    }

    public string? OnLoad
    {
        get => _element.Get("onload");
        set => _element.Set("onload", value);
    }

    public string? OnLoadedData
    {
        get => _element.Get("onloadeddata");
        set => _element.Set("onloadeddata", value);
    }

    public string? OnLoadedMetadata
    {
        get => _element.Get("onloadedmetadata");
        set => _element.Set("onloadedmetadata", value);
    }

    public string? OnLoadStart
    {
        get => _element.Get("onloadstart");
        set => _element.Set("onloadstart", value);
    }

    public string? OnMouseDown
    {
        get => _element.Get("onmousedown");
        set => _element.Set("onmousedown", value);
    }

    public string? OnMouseEnter
    {
        get => _element.Get("onmouseenter");
        set => _element.Set("onmouseenter", value);
    }

    public string? OnMouseLeave
    {
        get => _element.Get("onmouseleave");
        set => _element.Set("onmouseleave", value);
    }

    public string? OnMouseMove
    {
        get => _element.Get("onmousemove");
        set => _element.Set("onmousemove", value);
    }

    public string? OnMouseOut
    {
        get => _element.Get("onmouseout");
        set => _element.Set("onmouseout", value);
    }

    public string? OnMouseOver
    {
        get => _element.Get("onmouseover");
        set => _element.Set("onmouseover", value);
    }

    public string? OnMouseUp
    {
        get => _element.Get("onmouseup");
        set => _element.Set("onmouseup", value);
    }

    public string? OnPaste
    {
        get => _element.Get("onpaste");
        set => _element.Set("onpaste", value);
    }

    public string? OnPause
    {
        get => _element.Get("onpause");
        set => _element.Set("onpause", value);
    }

    public string? OnPlay
    {
        get => _element.Get("onplay");
        set => _element.Set("onplay", value);
    }

    public string? OnPlaying
    {
        get => _element.Get("onplaying");
        set => _element.Set("onplaying", value);
    }

    public string? OnProgress
    {
        get => _element.Get("onprogress");
        set => _element.Set("onprogress", value);
    }

    public string? OnRateChange
    {
        get => _element.Get("onratechange");
        set => _element.Set("onratechange", value);
    }

    public string? OnReset
    {
        get => _element.Get("onreset");
        set => _element.Set("onreset", value);
    }

    public string? OnResize
    {
        get => _element.Get("onresize");
        set => _element.Set("onresize", value);
    }

    public string? OnScroll
    {
        get => _element.Get("onscroll");
        set => _element.Set("onscroll", value);
    }

    public string? OnSecurityPolicyViolation
    {
        get => _element.Get("onsecuritypolicyviolation");
        set => _element.Set("onsecuritypolicyviolation", value);
    }

    public string? OnSeeked
    {
        get => _element.Get("onseeked");
        set => _element.Set("onseeked", value);
    }

    public string? OnSeeking
    {
        get => _element.Get("onseeking");
        set => _element.Set("onseeking", value);
    }

    public string? OnSelect
    {
        get => _element.Get("onselect");
        set => _element.Set("onselect", value);
    }

    public string? OnSlotChange
    {
        get => _element.Get("onslotchange");
        set => _element.Set("onslotchange", value);
    }

    public string? OnStalled
    {
        get => _element.Get("onstalled");
        set => _element.Set("onstalled", value);
    }

    public string? OnSubmit
    {
        get => _element.Get("onsubmit");
        set => _element.Set("onsubmit", value);
    }

    public string? OnSuspend
    {
        get => _element.Get("onsuspend");
        set => _element.Set("onsuspend", value);
    }

    public string? OnTimeUpdate
    {
        get => _element.Get("ontimeupdate");
        set => _element.Set("ontimeupdate", value);
    }

    public string? OnToggle
    {
        get => _element.Get("ontoggle");
        set => _element.Set("ontoggle", value);
    }

    public string? OnVolumeChange
    {
        get => _element.Get("onvolumechange");
        set => _element.Set("onvolumechange", value);
    }

    public string? OnWaiting
    {
        get => _element.Get("onwaiting");
        set => _element.Set("onwaiting", value);
    }

    public string? OnWheel
    {
        get => _element.Get("onwheel");
        set => _element.Set("onwheel", value);
    }
}
