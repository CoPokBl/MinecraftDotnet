using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Pathfinding;

/// <summary>
/// A*, vanilla's <c>PathFinder</c>. Knows nothing about blocks: everything terrain shaped is behind
/// <see cref="NodeEvaluator"/>, which is why this is short and the evaluator is not.
/// <p/>
/// Three things about it are not textbook A* and all three are load bearing:
/// <list type="bullet">
/// <item>The heuristic on a neighbour is multiplied by <see cref="Fudging"/>, 1.5. That makes it
/// inadmissible, so the path is not guaranteed shortest; it is what keeps the search from expanding
/// a wide frontier and is why vanilla mobs take slightly odd routes.</item>
/// <item>It stops at the <b>first</b> node within the reach range rather than at the target, which
/// is what lets a mob path to a target inside a wall by stopping next to it.</item>
/// <item>When nothing is reached it still returns a path, reconstructed from whichever node came
/// closest. A mob therefore walks as far towards an unreachable target as it can, and
/// <c>Path.CanReach</c> is how a caller tells the difference.</item>
/// </list>
/// </summary>
public class PathFinder(NodeEvaluator nodeEvaluator, int maxVisitedNodes) {
    /// <summary>
    /// What a neighbour's heuristic is scaled by. Greater than one on purpose: see the class
    /// summary.
    /// </summary>
    private const float Fudging = 1.5f;

    /// <summary>
    /// Reused across calls, and sized for the most neighbours any evaluator returns. The ground
    /// evaluator emits at most eight; vanilla sizes it at 32 for the flying one.
    /// </summary>
    private readonly Node[] _neighbors = new Node[32];

    private readonly BinaryHeap _openSet = new();

    public NodeEvaluator NodeEvaluator { get; } = nodeEvaluator;

    public int MaxVisitedNodes { get; set; } = maxVisitedNodes;

    public Path? FindPath(World world, Mob mob, HashSet<Vec3<int>> targets, float maxPathLength,
        int reachRange, float maxVisitedNodesMultiplier) {
        _openSet.Clear();
        NodeEvaluator.Prepare(world, mob);

        Node? from = NodeEvaluator.GetStart();
        if (from == null) {
            NodeEvaluator.Done();
            return null;
        }

        // One target node per requested position. Vanilla collects to a map, which silently drops a
        // duplicate; the same happens here because two positions in one block give the same node.
        Dictionary<PathTarget, Vec3<int>> targetMap = [];
        foreach (Vec3<int> target in targets) {
            targetMap[NodeEvaluator.GetTarget(target.X, target.Y, target.Z)] = target;
        }

        Path? path = FindPath(from, targetMap, maxPathLength, reachRange, maxVisitedNodesMultiplier);
        NodeEvaluator.Done();
        return path;
    }

    private Path? FindPath(Node from, Dictionary<PathTarget, Vec3<int>> targetMap, float maxPathLength,
        int reachRange, float maxVisitedNodesMultiplier) {
        List<PathTarget> targets = [.. targetMap.Keys];

        from.G = 0.0f;
        from.H = GetBestH(from, targets);
        from.F = from.H;

        _openSet.Clear();
        _openSet.Insert(from);

        int count = 0;
        List<PathTarget> reachedTargets = [];
        int maxVisitedNodesAdjusted = (int)(MaxVisitedNodes * maxVisitedNodesMultiplier);

        while (!_openSet.IsEmpty) {
            if (++count >= maxVisitedNodesAdjusted) {
                break;
            }

            Node current = _openSet.Pop();
            current.Closed = true;

            // Manhattan, not euclidean, and measured against the target node rather than the
            // position asked for. A reach range of one therefore accepts a diagonal neighbour only
            // in the plane, which is what stops a mob claiming to have arrived from a corner.
            foreach (PathTarget target in targets) {
                if (current.DistanceManhattan(target) <= reachRange) {
                    target.SetReached();
                    reachedTargets.Add(target);
                }
            }

            if (reachedTargets.Count > 0) {
                break;
            }

            // Measured from the start rather than along the path, so this bounds how far the search
            // spreads and not how long the route is. Node.WalkedDistance below is the other one.
            if (current.DistanceTo(from) >= maxPathLength) {
                continue;
            }

            int neighborCount = NodeEvaluator.GetNeighbors(_neighbors, current);

            for (int i = 0; i < neighborCount; i++) {
                Node neighbor = _neighbors[i];
                float distance = Distance(current, neighbor);
                neighbor.WalkedDistance = current.WalkedDistance + distance;
                float tentativeG = current.G + distance + neighbor.CostMalus;

                if (neighbor.WalkedDistance >= maxPathLength ||
                    (neighbor.InOpenSet && tentativeG >= neighbor.G)) {
                    continue;
                }

                neighbor.CameFrom = current;
                neighbor.G = tentativeG;
                neighbor.H = GetBestH(neighbor, targets) * Fudging;

                if (neighbor.InOpenSet) {
                    _openSet.ChangeCost(neighbor, neighbor.G + neighbor.H);
                }
                else {
                    neighbor.F = neighbor.G + neighbor.H;
                    _openSet.Insert(neighbor);
                }
            }
        }

        // A reached target wins on node count, an unreached one on how close it got. Both loops run
        // over targets that may have no best node at all, which happens only if the start scored
        // nothing, and those are skipped rather than producing an empty path.
        Path? best = null;

        if (reachedTargets.Count > 0) {
            foreach (PathTarget target in reachedTargets) {
                if (target.BestNode is not { } node) {
                    continue;
                }

                Path candidate = ReconstructPath(node, targetMap[target], true);
                if (best == null || candidate.NodeCount < best.NodeCount) {
                    best = candidate;
                }
            }
        }
        else {
            foreach (PathTarget target in targets) {
                if (target.BestNode is not { } node) {
                    continue;
                }

                Path candidate = ReconstructPath(node, targetMap[target], false);
                if (best == null || candidate.DistanceToTarget < best.DistanceToTarget ||
                    (candidate.DistanceToTarget == best.DistanceToTarget && candidate.NodeCount < best.NodeCount)) {
                    best = candidate;
                }
            }
        }

        return best;
    }

    /// <summary>The step cost between two neighbours. Straight line, so a diagonal costs its length.</summary>
    protected virtual float Distance(Node from, Node to) {
        return from.DistanceTo(to);
    }

    /// <summary>
    /// The best heuristic over every target, <b>and</b> the point at which each target records the
    /// closest anything came to it. Those two jobs being one method is why an unreachable target
    /// still has a best node: the side effect happens on every node the search scores.
    /// </summary>
    private static float GetBestH(Node from, List<PathTarget> targets) {
        float bestH = float.MaxValue;

        foreach (PathTarget target in targets) {
            float h = from.DistanceTo(target);
            target.UpdateBest(h, from);
            bestH = Math.Min(h, bestH);
        }

        return bestH;
    }

    private static Path ReconstructPath(Node closest, Vec3<int> target, bool reached) {
        List<Node> nodes = [closest];

        Node node = closest;
        while (node.CameFrom != null) {
            node = node.CameFrom;
            nodes.Insert(0, node);
        }

        return new Path(nodes, target, reached);
    }
}
