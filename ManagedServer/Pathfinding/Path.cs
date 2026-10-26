using ManagedServer.Entities.Types;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// A route, vanilla's <c>Path</c>: the nodes to walk through and how far along them the mob is.
/// <p/>
/// The cursor (<see cref="NextNodeIndex"/>) is part of the path rather than of the navigation,
/// which is why <see cref="IsDone"/> means "walked to the end" and not "has no nodes".
/// </summary>
/// <param name="nodes">
/// The route, start first. Mutable, because the navigation trims and replaces nodes in place after
/// the search has finished.
/// </param>
/// <param name="target">
/// Where the search was asked to go, which is not the same as the last node when it could not get
/// there.
/// </param>
/// <param name="reached">Whether the search actually got within reach of the target.</param>
public sealed class Path(List<Node> nodes, Vec3<int> target, bool reached) {
    private readonly List<Node> _nodes = nodes;

    /// <summary>Where the search was asked to go.</summary>
    public Vec3<int> Target { get; } = target;

    /// <summary>
    /// How far the last node fell short of the target. <c>float.MaxValue</c> for an empty path, which
    /// is what makes an empty path lose every comparison in <c>PathFinder</c>.
    /// </summary>
    public float DistanceToTarget { get; } =
        nodes.Count == 0 ? float.MaxValue : nodes[^1].DistanceManhattan(target);

    /// <summary>
    /// Whether the search got there, <c>Path.canReach</c>. A goal uses this to decide whether the
    /// destination is worth walking to at all; a path that cannot reach is still walkable and simply
    /// stops short.
    /// </summary>
    public bool CanReach { get; } = reached;

    public int NextNodeIndex { get; set; }

    public int NodeCount => _nodes.Count;

    public void Advance() {
        NextNodeIndex++;
    }

    public bool NotStarted => NextNodeIndex <= 0;

    public bool IsDone => NextNodeIndex >= _nodes.Count;

    public Node? EndNode => _nodes.Count > 0 ? _nodes[^1] : null;

    public Node GetNode(int index) {
        return _nodes[index];
    }

    public Vec3<int> GetNodePos(int index) {
        return _nodes[index].AsBlockPos();
    }

    public Node NextNode => _nodes[NextNodeIndex];

    public Vec3<int> NextNodePos => _nodes[NextNodeIndex].AsBlockPos();

    public Node? PreviousNode => NextNodeIndex > 0 ? _nodes[NextNodeIndex - 1] : null;

    public void TruncateNodes(int index) {
        if (_nodes.Count > index) {
            _nodes.RemoveRange(index, _nodes.Count - index);
        }
    }

    public void ReplaceNode(int index, Node with) {
        _nodes[index] = with;
    }

    /// <summary>
    /// Where the entity should stand to be at a node, <c>Path.getEntityPosAtNode</c>.
    /// <p/>
    /// The offset is <b>not</b> half a block. It is <c>(int)(width + 1) * 0.5</c>, so a mob under one
    /// block wide gets 0.5 and a two block wide one gets 1.5: nodes for a wide mob name the corner of
    /// the space it occupies rather than its centre. Getting this wrong puts every waypoint half a
    /// block off for exactly the mobs that can least afford it.
    /// </summary>
    public Vec3<double> GetEntityPosAtNode(Entity entity, int index) {
        Node node = _nodes[index];
        double offset = (int)(entity.BbWidth + 1.0f) * 0.5;
        return new Vec3<double>(node.X + offset, node.Y, node.Z + offset);
    }

    public Vec3<double> GetNextEntityPos(Entity entity) {
        return GetEntityPosAtNode(entity, NextNodeIndex);
    }

    /// <summary>
    /// Whether two paths visit the same nodes, <c>Path.sameAs</c>. Used to decide whether a fresh
    /// search is worth swapping in: an identical route is left alone so the cursor is not reset.
    /// </summary>
    public bool SameAs(Path? other) {
        if (other == null || other._nodes.Count != _nodes.Count) {
            return false;
        }

        for (int i = 0; i < _nodes.Count; i++) {
            if (!_nodes[i].Equals(other._nodes[i])) {
                return false;
            }
        }

        return true;
    }

    public override string ToString() {
        return $"Path(length={_nodes.Count})";
    }
}
