using Minecraft.Schemas;
using Minecraft.Schemas.Advancements;

namespace ClientLib.Advancements;

/// <summary><c>AdvancementNode</c>: an advancement in the tree, with the parent it hangs off.</summary>
public sealed class AdvancementNode(Identifier id, Advancement advancement, AdvancementNode? parent) {
    private readonly List<AdvancementNode> _children = [];

    public Identifier Id { get; } = id;
    public Advancement Advancement { get; } = advancement;
    public AdvancementNode? Parent { get; } = parent;
    public AdvancementDisplay? Display => Advancement.Display;
    public IReadOnlyList<AdvancementNode> Children => _children;

    public AdvancementNode Root {
        get {
            AdvancementNode root = this;
            while (root.Parent != null) {
                root = root.Parent;
            }
            return root;
        }
    }

    internal void AddChild(AdvancementNode child) => _children.Add(child);

    public override string ToString() => Id.ToString();
}

/// <summary>What an <see cref="AdvancementTree"/> tells whoever draws it, <c>AdvancementTree.Listener</c>.</summary>
public interface IAdvancementTreeListener {
    void OnAddAdvancementRoot(AdvancementNode root);
    void OnRemoveAdvancementRoot(AdvancementNode root);
    void OnAddAdvancementTask(AdvancementNode task);
    void OnRemoveAdvancementTask(AdvancementNode task);
    void OnAdvancementsCleared();
}

/// <summary>
/// <c>AdvancementTree</c>: the advancements by id, with the roots and the rest each kept in the order they
/// were added, which is the order the screen's tabs and widgets are made in.
/// </summary>
public sealed class AdvancementTree {
    private readonly Dictionary<Identifier, AdvancementNode> _nodes = new();
    private readonly List<AdvancementNode> _roots = [];
    private readonly List<AdvancementNode> _tasks = [];
    private IAdvancementTreeListener? _listener;

    public event Action<string>? Log;

    public IReadOnlyList<AdvancementNode> Roots => _roots;
    public IEnumerable<AdvancementNode> Nodes => _nodes.Values;
    public int Count => _nodes.Count;

    public AdvancementNode? Get(Identifier id) => _nodes.GetValueOrDefault(id);

    private void Remove(AdvancementNode node) {
        foreach (AdvancementNode child in node.Children) {
            Remove(child);
        }
        _nodes.Remove(node.Id);
        if (node.Parent == null) {
            _roots.Remove(node);
            _listener?.OnRemoveAdvancementRoot(node);
        }
        else {
            _tasks.Remove(node);
            _listener?.OnRemoveAdvancementTask(node);
        }
    }

    public void Remove(IEnumerable<Identifier> ids) {
        foreach (Identifier id in ids) {
            if (_nodes.TryGetValue(id, out AdvancementNode? node)) {
                Remove(node);
            }
            else {
                Log?.Invoke($"Told to remove advancement {id} but I don't know what that is");
            }
        }
    }

    /// <summary>
    /// <c>addAll</c>: passes over what is left until a pass inserts nothing, each pass in the packet's order, so
    /// a child sent before its parent goes in on the pass after the parent does.
    /// </summary>
    public void AddAll(IEnumerable<KeyValuePair<Identifier, Advancement>> advancements) {
        List<KeyValuePair<Identifier, Advancement>> toAdd = advancements.ToList();
        while (toAdd.Count > 0) {
            if (toAdd.RemoveAll(TryInsert) == 0) {
                Log?.Invoke($"Couldn't load advancements: {string.Join(", ", toAdd.Select(entry => entry.Key))}");
                break;
            }
        }
    }

    private bool TryInsert(KeyValuePair<Identifier, Advancement> entry) {
        Identifier? parentId = entry.Value.Parent;
        AdvancementNode? parent = parentId is { } id ? _nodes.GetValueOrDefault(id) : null;
        if (parent == null && parentId != null) {
            return false;
        }
        AdvancementNode node = new(entry.Key, entry.Value, parent);
        parent?.AddChild(node);
        _nodes[entry.Key] = node;
        if (parent == null) {
            _roots.Add(node);
            _listener?.OnAddAdvancementRoot(node);
        }
        else {
            _tasks.Add(node);
            _listener?.OnAddAdvancementTask(node);
        }
        return true;
    }

    public void Clear() {
        _nodes.Clear();
        _roots.Clear();
        _tasks.Clear();
        _listener?.OnAdvancementsCleared();
    }

    /// <summary><c>setListener</c>: a new listener is told of every root, then every other advancement.</summary>
    public void SetListener(IAdvancementTreeListener? listener) {
        _listener = listener;
        if (listener == null) {
            return;
        }
        foreach (AdvancementNode root in _roots) {
            listener.OnAddAdvancementRoot(root);
        }
        foreach (AdvancementNode task in _tasks) {
            listener.OnAddAdvancementTask(task);
        }
    }
}
