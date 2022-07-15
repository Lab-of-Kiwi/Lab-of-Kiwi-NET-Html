namespace LabOfKiwi.Html.Attributes;

public sealed class BodyEvents : Events
{
    internal BodyEvents(HtmlElement element) : base(element)
    {
    }

    public string? OnAfterPrint
    {
        get => _element.Get("onafterprint");
        set => _element.Set("onafterprint", value);
    }

    public string? OnBeforePrint
    {
        get => _element.Get("onbeforeprint");
        set => _element.Set("onbeforeprint", value);
    }

    public string? OnBeforeUnload
    {
        get => _element.Get("onbeforeunload");
        set => _element.Set("onbeforeunload", value);
    }

    public string? OnHashChange
    {
        get => _element.Get("onhashchange");
        set => _element.Set("onhashchange", value);
    }

    public string? OnLanguageChange
    {
        get => _element.Get("onlanguagechange");
        set => _element.Set("onlanguagechange", value);
    }

    public string? OnMessage
    {
        get => _element.Get("onmessage");
        set => _element.Set("onmessage", value);
    }

    public string? OnMessageError
    {
        get => _element.Get("onmessageerror");
        set => _element.Set("onmessageerror", value);
    }

    public string? OnOffline
    {
        get => _element.Get("onoffline");
        set => _element.Set("onoffline", value);
    }

    public string? OnOnline
    {
        get => _element.Get("ononline");
        set => _element.Set("ononline", value);
    }

    public string? OnPageHide
    {
        get => _element.Get("onpagehide");
        set => _element.Set("onpagehide", value);
    }

    public string? OnPageShow
    {
        get => _element.Get("onpageshow");
        set => _element.Set("onpageshow", value);
    }

    public string? OnPopState
    {
        get => _element.Get("onpopstate");
        set => _element.Set("onpopstate", value);
    }

    public string? OnRejectionHandled
    {
        get => _element.Get("onrejectionhandled");
        set => _element.Set("onrejectionhandled", value);
    }

    public string? OnStorage
    {
        get => _element.Get("onstorage");
        set => _element.Set("onstorage", value);
    }

    public string? OnUnhandledRejection
    {
        get => _element.Get("onunhandledrejection");
        set => _element.Set("onunhandledrejection", value);
    }

    public string? OnUnload
    {
        get => _element.Get("onunload");
        set => _element.Set("onunload", value);
    }
}
