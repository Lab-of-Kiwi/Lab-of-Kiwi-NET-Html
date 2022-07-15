using LabOfKiwi.Html.Elements;
using System.Collections.Generic;

namespace LabOfKiwi.Html.Processors;

public abstract class SelectProcessor<TValue> : IHtmlElementProcessor
{
    internal SelectProcessor()
    {
    }

    public void Invoke(IHtmlContainerNode node)
    {
        node.Append<SELECT>(select =>
        {
            select.AllowMultiple = IsMultiple;
            int index = 0;

            foreach (var item in GetItems())
            {
                select.Append<OPTION>(opt =>
                {
                    opt.Value = ValueString(item.Key);

                    if (IsSelected(item.Key))
                    {
                        opt.IsSelected = true;
                    }

                    opt.AppendText(item.Value);

                    Callback(select, opt, index++, item);
                });
            }

            Callback(select, index);
        });
    }

    public abstract bool IsSelected(TValue item);

    protected abstract IEnumerable<KeyValuePair<TValue, string>> GetItems();

    protected virtual void Callback(SELECT selectElement, int itemCount)
    {
        // Do nothing.
    }

    protected virtual void Callback(SELECT selectElement, OPTION option, int index, KeyValuePair<TValue, string> item)
    {
        // Do nothing.
    }

    protected abstract string ValueString(TValue value);

    internal abstract bool IsMultiple { get; }
}
