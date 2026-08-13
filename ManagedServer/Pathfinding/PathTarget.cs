namespace ManagedServer.Pathfinding;

/// <summary>
/// Somewhere the search is trying to get to, vanilla's <c>Target</c>.
/// <p/>
/// It is a <see cref="Node"/> itself so it can be measured against nodes, and it remembers the
/// closest anything ever came to it. That memory is what makes an unreachable destination still
/// produce a path: <c>PathFinder</c> reconstructs from <see cref="BestNode"/>, so a mob walks as far
/// towards a target it cannot get to as it can.
/// </summary>
public class PathTarget : Node {
    public PathTarget(int x, int y, int z) : base(x, y, z) { }

    public PathTarget(Node node) : base(node.X, node.Y, node.Z) { }

    private float _bestHeuristic = float.MaxValue;

    /// <summary>The node that came closest. Null only if the search never scored anything.</summary>
    public Node? BestNode { get; private set; }

    /// <summary>Whether anything got within the reach range, <c>Target.isReached</c>.</summary>
    public bool Reached { get; private set; }

    public void UpdateBest(float heuristic, Node node) {
        if (heuristic >= _bestHeuristic) {
            return;
        }

        _bestHeuristic = heuristic;
        BestNode = node;
    }

    public void SetReached() {
        Reached = true;
    }
}
