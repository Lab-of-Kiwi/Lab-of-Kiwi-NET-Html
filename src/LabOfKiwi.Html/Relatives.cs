using LabOfKiwi.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LabOfKiwi.Html;

public interface IRelatives<THtmlNode> where THtmlNode : HtmlNode
{
    INonSiblings<THtmlNode> Ancestors { get; }

    INonSiblings<THtmlNode> Children { get; }

    INonSiblings<THtmlNode> Descendents { get; }

    THtmlNode? Parent { get; }

    ISiblings<THtmlNode> Siblings { get; }
}

public interface INonSiblings<THtmlNode> : IReadOnlyList<THtmlNode> where THtmlNode : HtmlNode
{
    bool IsEmpty { get; }

    THtmlNode? First { get; }

    THtmlNode? Last { get; }
}

public interface ISiblings<THtmlNode> : INonSiblings<THtmlNode> where THtmlNode : HtmlNode
{
    THtmlNode? Next { get; }

    THtmlNode? Previous { get; }

    int PrecedingCount { get; }

    int SubsequentCount { get; }

    IReadOnlyList<THtmlNode> GetPreceding();

    IReadOnlyList<THtmlNode> GetSubsequent();
}

internal readonly struct RelativeElements : IRelatives<HtmlElement>
{
    private readonly HtmlNode _htmlNode;

    public RelativeElements(HtmlNode htmlNode)
    {
        _htmlNode = htmlNode;
    }

    public INonSiblings<HtmlElement> Ancestors => new AncestorElements(_htmlNode.CoreNode);

    public INonSiblings<HtmlElement> Children => new ChildElements(_htmlNode.CoreNode);

    public INonSiblings<HtmlElement> Descendents => new DescendentElements(_htmlNode.CoreNode);

    public HtmlElement? Parent => Ancestors.First;

    public ISiblings<HtmlElement> Siblings => throw new System.NotImplementedException();
}

internal readonly struct RelativeNodes : IRelatives<HtmlNode>
{
    private readonly HtmlNode _htmlNode;

    public RelativeNodes(HtmlNode htmlNode)
    {
        _htmlNode = htmlNode;
    }

    public INonSiblings<HtmlNode> Ancestors => new AncestorNodes(_htmlNode.CoreNode);

    public INonSiblings<HtmlNode> Children => new ChildNodes(_htmlNode.CoreNode);

    public INonSiblings<HtmlNode> Descendents => new DescendentNodes(_htmlNode.CoreNode);

    public HtmlNode? Parent => HtmlNode.NullableWrapNode(_htmlNode.CoreNode.ParentNode);

    public ISiblings<HtmlNode> Siblings => new SiblingNodes(_htmlNode);
}

internal readonly struct AncestorElements : INonSiblings<HtmlElement>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public AncestorElements(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlElement this[int index] => Raw.ElementAt(index);

    public bool IsEmpty => !Raw.Any();

    public HtmlElement? First => Raw.FirstOrDefault();

    public HtmlElement? Last => Raw.LastOrDefault();

    public int Count => Raw.Count();

    public IEnumerator<HtmlElement> GetEnumerator() => Raw.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<HtmlElement> Raw => new AncestorNodes(_xmlNode).Raw.OfType<HtmlElement>();
}

internal readonly struct AncestorNodes : INonSiblings<HtmlNode>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public AncestorNodes(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlNode this[int index] => Raw.ElementAt(index);

    public int Count => Raw.Count();

    public bool IsEmpty => _xmlNode.ParentNode != null;

    public HtmlNode? First => Raw.FirstOrDefault();

    public HtmlNode? Last => Raw.LastOrDefault();

    public IEnumerator<HtmlNode> GetEnumerator() => Raw.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    internal IEnumerable<HtmlNode> Raw
    {
        get
        {
            var parentNode = _xmlNode.ParentNode;

            while (parentNode != null)
            {
                yield return HtmlNode.WrapNode(parentNode);
                parentNode = parentNode.ParentNode;
            }
        }
    }
}

internal readonly struct ChildElements : INonSiblings<HtmlElement>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public ChildElements(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlElement this[int index] => Raw.ElementAt(index);

    public bool IsEmpty => !Raw.Any();

    public HtmlElement? First => Raw.FirstOrDefault();

    public HtmlElement? Last => Raw.LastOrDefault();

    public int Count => Raw.Count();

    public IEnumerator<HtmlElement> GetEnumerator() => Raw.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<HtmlElement> Raw => new HtmlNodeList(_xmlNode.ChildNodes).OfType<HtmlElement>();
}

internal readonly struct ChildNodes : INonSiblings<HtmlNode>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public ChildNodes(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlNode this[int index] => new HtmlNodeList(_xmlNode.ChildNodes)[index];

    public int Count => _xmlNode.ChildNodes.Count;

    public bool IsEmpty => _xmlNode.HasChildNodes;

    public HtmlNode? First => HtmlNode.NullableWrapNode(_xmlNode.FirstChild);

    public HtmlNode? Last => HtmlNode.NullableWrapNode(_xmlNode.LastChild);

    public IEnumerator<HtmlNode> GetEnumerator() => new HtmlNodeList(_xmlNode.ChildNodes).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal readonly struct DescendentElements : INonSiblings<HtmlElement>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public DescendentElements(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlElement this[int index] => Raw.ElementAt(index);

    public bool IsEmpty => !Raw.Any();

    public HtmlElement? First => Raw.FirstOrDefault();

    public HtmlElement? Last => Raw.LastOrDefault();

    public int Count => Raw.Count();

    public IEnumerator<HtmlElement> GetEnumerator() => Raw.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<HtmlElement> Raw => new DescendentNodes(_xmlNode).Raw.OfType<HtmlElement>();
}

internal readonly struct DescendentNodes : INonSiblings<HtmlNode>
{
    private readonly HtmlAgilityPack.HtmlNode _xmlNode;

    public DescendentNodes(HtmlAgilityPack.HtmlNode xmlNode)
    {
        _xmlNode = xmlNode;
    }

    public HtmlNode this[int index] => Raw.ElementAt(index);

    public int Count => Raw.Count();

    public bool IsEmpty => _xmlNode.HasChildNodes;

    public HtmlNode? First => HtmlNode.NullableWrapNode(_xmlNode.FirstChild);

    public HtmlNode? Last => Raw.LastOrDefault();

    public IEnumerator<HtmlNode> GetEnumerator() => Raw.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    internal IEnumerable<HtmlNode> Raw => GetDescendents(_xmlNode);

    private IEnumerable<HtmlNode> GetDescendents(HtmlAgilityPack.HtmlNode xmlNode)
    {
        var nodeList = new HtmlNodeList(xmlNode.ChildNodes);

        foreach (var node in nodeList)
        {
            yield return node;

            foreach (var descendent in GetDescendents(node.CoreNode))
            {
                yield return descendent;
            }
        }
    }
}

internal readonly struct SiblingElements : ISiblings<HtmlElement>
{
    private readonly HtmlNode _htmlNode;

    public SiblingElements(HtmlNode htmlNode)
    {
        _htmlNode = htmlNode;
    }

    public HtmlElement this[int index] => Raw.ElementAt(index);

    public HtmlElement? Next => RawSubsequent.FirstOrDefault();

    public HtmlElement? Previous => RawPreceding.LastOrDefault();

    public int PrecedingCount => RawPreceding.Count();

    public int SubsequentCount => RawSubsequent.Count();

    public bool IsEmpty
    {
        get
        {
            if (_htmlNode.CoreNode.ParentNode == null)
            {
                return false;
            }

            return Count == 0;
        }
    }

    public HtmlElement? First => Raw.FirstOrDefault();

    public HtmlElement? Last => Raw.LastOrDefault();

    public int Count => Raw.Count();

    public IEnumerator<HtmlElement> GetEnumerator() => Raw.GetEnumerator();

    public IReadOnlyList<HtmlElement> GetPreceding() => RawPreceding.AsReadOnlyList();
    
    public IReadOnlyList<HtmlElement> GetSubsequent() => RawSubsequent.AsReadOnlyList();
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private IEnumerable<HtmlElement> Raw => new SiblingNodes(_htmlNode).Raw.OfType<HtmlElement>();

    private IEnumerable<HtmlElement> RawPreceding => new SiblingNodes(_htmlNode).RawPreceding.OfType<HtmlElement>();

    private IEnumerable<HtmlElement> RawSubsequent => new SiblingNodes(_htmlNode).RawSubsequent.OfType<HtmlElement>();
}

internal readonly struct SiblingNodes : ISiblings<HtmlNode>
{
    private readonly HtmlNode _htmlNode;

    public SiblingNodes(HtmlNode htmlNode)
    {
        _htmlNode = htmlNode;
    }

    public HtmlNode this[int index] => Raw.ElementAt(index);

    public int Count => Raw.Count();

    public bool IsEmpty
    {
        get
        {
            var parentNode = _htmlNode.CoreNode.ParentNode;

            if (parentNode == null)
            {
                return false;
            }

            int parentChildCount = parentNode.ChildNodes.Count;
            Debug.Assert(parentChildCount != 0);
            return parentChildCount > 1;
        }
    }

    public int PrecedingCount => RawPreceding.Count();

    public int SubsequentCount => RawSubsequent.Count();

    public HtmlNode? First => Raw.FirstOrDefault();

    public HtmlNode? Last => Raw.LastOrDefault();

    public HtmlNode? Next => RawSubsequent.FirstOrDefault();

    public HtmlNode? Previous => RawPreceding.LastOrDefault();

    public IEnumerator<HtmlNode> GetEnumerator() => Raw.GetEnumerator();

    public IReadOnlyList<HtmlNode> GetPreceding() => RawPreceding.AsReadOnlyList();

    public IReadOnlyList<HtmlNode> GetSubsequent() => RawSubsequent.AsReadOnlyList();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    internal IEnumerable<HtmlNode> Raw
    {
        get
        {
            var parentNode = _htmlNode.CoreNode.ParentNode;

            if (parentNode != null)
            {
                foreach (var node in new HtmlNodeList(parentNode.ChildNodes))
                {
                    if (!_htmlNode.CoreNode.Equals(node.CoreNode))
                    {
                        yield return node;
                    }
                }
            }
        }
    }

    internal IEnumerable<HtmlNode> RawPreceding
    {
        get
        {
            var searchNode = _htmlNode.CoreNode;
            return RawAll.TakeWhile(n => !searchNode.Equals(n.CoreNode));
        }
    }

    internal IEnumerable<HtmlNode> RawSubsequent
    {
        get
        {
            var searchNode = _htmlNode.CoreNode;
            return RawAll.SkipWhile(n => !searchNode.Equals(n.CoreNode)).Skip(1);
        }
    }

    private IEnumerable<HtmlNode> RawAll
    {
        get
        {
            var parentNode = _htmlNode.CoreNode.ParentNode;

            if (parentNode != null)
            {
                foreach (var node in new HtmlNodeList(parentNode.ChildNodes))
                {
                    yield return node;
                }
            }
            else
            {
                yield return _htmlNode;
            }
        }
    }
}
