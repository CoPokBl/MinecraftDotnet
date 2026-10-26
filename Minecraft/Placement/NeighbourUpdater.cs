using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace Minecraft.Placement;

/// <summary>
/// Vanilla's <c>CollectingNeighborUpdater</c>, the thing that turns one block change into the cascade
/// of shape updates around it. One per level, driven from its <see cref="IPlacementLevel.SetBlock"/>.
/// <p/>
/// It is a <b>queue rather than recursion</b>, and that is the whole reason it is a class instead of a
/// method. A block whose neighbour changed can change itself, which notifies its own neighbours, and
/// the order those land in is visible: a fence line or a wall of stairs settles into a different
/// arrangement under a plain depth first walk. Vanilla's rule is that the six neighbours of the block
/// that started it are each run to completion in turn, and that inside a run a block's own children
/// jump ahead of its siblings.
/// <p/>
/// Only the shape half of vanilla's updater is here. The other three kinds it collects
/// (<c>neighborChanged</c>, the multi direction form, the analog signal form) are the redstone pass,
/// and there is no redstone engine, so <c>UPDATE_NEIGHBORS</c> is accepted and does nothing.
/// </summary>
public sealed class NeighbourUpdater(IPlacementLevel world) {
    /// <summary><c>MinecraftServer.getMaxChainedNeighborUpdates</c>.</summary>
    private const int MaxChainedUpdates = 1_000_000;

    /// <summary>
    /// One block being told that the neighbour across <see cref="Direction"/> has become
    /// <see cref="NeighbourState"/>.
    /// </summary>
    private readonly record struct ShapeUpdate(
        BlockFace Direction, Vec3<int> Pos, Vec3<int> NeighbourPos, IBlock NeighbourState,
        int Flags, int Limit);

    private readonly Stack<ShapeUpdate> _stack = new();
    private readonly List<ShapeUpdate> _addedThisLayer = [];
    private int _count;

    /// <summary>
    /// <c>BlockState.updateNeighbourShapes</c>: tell all six neighbours that this position is now
    /// <paramref name="state"/>.
    /// <p/>
    /// The order is <c>UPDATE_SHAPE_ORDER</c>, west east north south down up, which is deliberately
    /// not <c>Direction.values()</c>. Each neighbour is told the direction <b>back</b> towards the
    /// block that changed, because that is the direction its own rule reasons about.
    /// </summary>
    public void UpdateNeighbourShapes(Vec3<int> pos, IBlock state, int flags, int limit) {
        foreach (BlockFace face in Directions.UpdateShapeOrder) {
            Vec3<int> neighbour = pos.GetBlockTowards(face);
            Enqueue(new ShapeUpdate(face.Opposite(), neighbour, pos, state, flags, limit));
        }
    }

    /// <summary>
    /// <c>addAndRun</c>. The first update in from outside runs the whole queue down before returning;
    /// anything raised while that is happening is added to the current layer instead, which is what
    /// keeps this a loop rather than a recursion.
    /// </summary>
    private void Enqueue(ShapeUpdate update) {
        bool runningAlready = _count > 0;
        bool tooMany = _count >= MaxChainedUpdates;
        _count++;

        if (!tooMany) {
            if (runningAlready) {
                _addedThisLayer.Add(update);
            }
            else {
                _stack.Push(update);
            }
        }

        if (!runningAlready) {
            RunUpdates();
        }
    }

    /// <summary>
    /// <c>runUpdates</c>. Vanilla's inner loop keeps asking the top of the stack for another step;
    /// a shape update is one shot, its <c>runNext</c> always answers false, so that loop runs exactly
    /// once and the entry is popped. Written that way here rather than with the extra loop, since
    /// there is no multi step update to need it.
    /// <p/>
    /// The reversed push is what preserves the order a block asked for its neighbours in: pushing the
    /// last one first leaves the first one on top.
    /// </summary>
    private void RunUpdates() {
        try {
            while (_stack.Count > 0 || _addedThisLayer.Count > 0) {
                for (int i = _addedThisLayer.Count - 1; i >= 0; i--) {
                    _stack.Push(_addedThisLayer[i]);
                }

                _addedThisLayer.Clear();
                Execute(_stack.Peek());
                _stack.Pop();
            }
        }
        finally {
            _stack.Clear();
            _addedThisLayer.Clear();
            _count = 0;
        }
    }

    /// <summary>
    /// <c>NeighborUpdater.executeShapeUpdate</c>.
    /// <p/>
    /// The read has to tolerate being off the end of the world, because a block written at the floor
    /// or the ceiling notifies a neighbour that is not there. Vanilla answers void air for those and
    /// void air has no rule, so nothing happens; air here does the same thing. It also covers a
    /// neighbour in a chunk that is not loaded, which vanilla would load and this deliberately does
    /// not: a cascade is not a reason to drag chunks in.
    /// </summary>
    private void Execute(ShapeUpdate update) {
        IBlock current = world.GetBlockOr(update.Pos, Block.Air);
        IBlockPlacementRule? rule = world.PlacementRuleFor(current);
        if (rule is null) {
            return;
        }

        IBlock updated = rule.UpdateShape(current, world, update.Pos, update.Direction,
            update.NeighbourPos, update.NeighbourState);
        UpdateOrDestroy(current, updated, update.Pos, update.Flags, update.Limit);
    }

    /// <summary>
    /// <c>Block.updateOrDestroy</c>. Vanilla compares the two states by reference, which works because
    /// block states are interned; the state id is that comparison here.
    /// <p/>
    /// A rule that answers air is asking for the block to be <b>destroyed</b>, not overwritten, which
    /// is a different thing: it drops, and it leaves water behind if it was waterlogged.
    /// </summary>
    private void UpdateOrDestroy(IBlock current, IBlock updated, Vec3<int> pos, int flags, int limit) {
        if (updated.StateId == current.StateId) {
            return;
        }

        if (updated.Air) {
            if (world.IsClientSide) {
                return;
            }
            world.DestroyBlock(pos, (flags & BlockUpdateFlags.SuppressDrops) == 0, limit);
            return;
        }

        world.SetBlock(pos, updated, flags: flags & ~BlockUpdateFlags.MoveByPiston, updateLimit: limit);
    }
}
