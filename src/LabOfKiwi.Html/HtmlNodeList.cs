using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace LabOfKiwi.Html;

internal sealed class HtmlNodeList : IReadOnlyList<HtmlNode>
{
    private readonly HtmlAgilityPack.HtmlNodeCollection _xmlNodeList;

    internal HtmlNodeList(HtmlAgilityPack.HtmlNodeCollection xmlNodeList)
    {
        Debug.Assert(xmlNodeList != null);
        _xmlNodeList = xmlNodeList;
    }

    public HtmlNode this[int index]
    {
        get
        {
            if ((uint)index >= (uint)_xmlNodeList.Count)
            {
                throw new IndexOutOfRangeException();
            }

            var node = _xmlNodeList[index];
            Debug.Assert(node != null);
            return HtmlNode.WrapNode(node);
        }
    }

    public int Count => _xmlNodeList.Count;

    public IEnumerator<HtmlNode> GetEnumerator()
    {
        foreach (var node in _xmlNodeList)
        {
            yield return HtmlNode.WrapNode(node);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
