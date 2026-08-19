using ManagedServer.Placement;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>How far from its centre a jigsaw structure may reach.</summary>
public readonly record struct MaxDistance(int Horizontal, int Vertical);

/// <summary>How much room a jigsaw structure leaves at the top and bottom of the world.</summary>
public readonly record struct DimensionPadding(int Bottom, int Top) {
    public static readonly DimensionPadding Zero = new(0, 0);

    public bool IsZero => Bottom == 0 && Top == 0;
}

/// <summary>
/// <c>JigsawPlacement</c>: grows a structure outward from one starting piece by joining jigsaw blocks.
/// </summary>
/// <remarks>
/// The whole algorithm is one loop over a priority queue. A piece is taken off it, every jigsaw block
/// on that piece is tried in turn, and for each the first candidate that both attaches and fits is
/// placed and queued. So the shape of a village is decided by the shuffle of each pool and by the
/// order the jigsaw blocks come out in, which is why both of those are drawn.
/// <p/>
/// <b>The queue is by placement priority and then insertion order.</b> A connection with a higher
/// priority expands before everything queued earlier, which is what lets a trial chamber lay its
/// corridors out before the rooms hanging off them.
/// </remarks>
public static class JigsawPlacement {
    /// <summary>The height a jigsaw's own column has not been measured at yet.</summary>
    private const int UnsetHeight = int.MinValue;

    public sealed record Settings(
        Identifier StartPool,
        Identifier? StartJigsawName,
        int MaxDepth,
        bool UseExpansionHack,
        HeightmapType? ProjectStartToHeightmap,
        MaxDistance MaxDistanceFromCentre,
        DimensionPadding Padding,
        bool ApplyWaterlogging);

    /// <summary>
    /// Everything the placer needs that is not the structure's own settings.
    /// </summary>
    /// <remarks>
    /// The level is here because a template's jigsaw blocks are read through the block registry, which
    /// the placer reaches through an <see cref="IFeatureLevel"/>. Nothing is written during layout.
    /// </remarks>
    public sealed record Context(
        StructureTemplateManager Templates,
        TemplatePools Pools,
        MinecraftRegistry Registry,
        BaseHeightAt Heights,
        int MinY,
        int MaxY);

    public static GenerationStub? AddPieces(StructureGenerationContext generation, Context context,
        Settings settings, Vec3<int> position, PoolAliasLookup aliases) {

        WorldgenRandom random = generation.Random;
        BlockRotation centreRotation = (BlockRotation)random.NextInt(4);

        StructureTemplatePool? centrePool = context.Pools.Get(aliases.Lookup(settings.StartPool));

        if (centrePool is null) {
            return null;
        }

        IStructurePoolElement centreElement = centrePool.RandomTemplate(random);

        if (ReferenceEquals(centreElement, EmptyPoolElement.Instance)) {
            return null;
        }

        Vec3<int> anchored = position;

        if (settings.StartJigsawName is { } wanted) {
            Vec3<int>? found = RandomNamedJigsaw(context, centreElement, wanted, position,
                centreRotation, random);

            if (found is null) {
                return null;
            }

            anchored = found.Value;
        }

        Vec3<int> localAnchor = new(anchored.X - position.X, anchored.Y - position.Y,
            anchored.Z - position.Z);

        Vec3<int> adjusted = new(position.X - localAnchor.X, position.Y - localAnchor.Y,
            position.Z - localAnchor.Z);

        PoolElementStructurePiece centrePiece = new(context.Templates, centreElement, adjusted,
            centreElement.GroundLevelDelta, centreRotation,
            centreElement.GetBoundingBox(context.Templates, adjusted, centreRotation),
            settings.ApplyWaterlogging);

        BoundingBox box = centrePiece.BoundingBox;
        int centreX = (box.MaxX + box.MinX) / 2;
        int centreZ = (box.MaxZ + box.MinZ) / 2;

        int bottomY = settings.ProjectStartToHeightmap is { } heightmap
            ? position.Y + context.Heights(centreX, centreZ, heightmap)
            : adjusted.Y;

        centrePiece.Move(0, bottomY - (box.MinY + centrePiece.GroundLevelDelta), 0);

        if (TooCloseToWorldHeightLimits(context, settings.Padding, centrePiece.BoundingBox)) {
            return null;
        }

        int centreY = bottomY + localAnchor.Y;

        return new GenerationStub(new Vec3<int>(centreX, centreY, centreZ), builder => {
            List<PoolElementStructurePiece> pieces = [centrePiece];

            if (settings.MaxDepth > 0) {
                JigsawFreeSpace free = JigsawFreeSpace.Within(
                    centreX - settings.MaxDistanceFromCentre.Horizontal,
                    Math.Max(centreY - settings.MaxDistanceFromCentre.Vertical,
                        context.MinY + settings.Padding.Bottom),
                    centreZ - settings.MaxDistanceFromCentre.Horizontal,
                    centreX + settings.MaxDistanceFromCentre.Horizontal + 1,
                    Math.Min(centreY + settings.MaxDistanceFromCentre.Vertical + 1,
                        context.MaxY - settings.Padding.Top),
                    centreZ + settings.MaxDistanceFromCentre.Horizontal + 1);

                free.Remove(centrePiece.BoundingBox);

                Placer placer = new(context, settings, pieces, random);
                placer.Run(centrePiece, free, aliases);
            }

            foreach (PoolElementStructurePiece piece in pieces) {
                builder.AddPiece(piece);
            }
        });
    }

    private static bool TooCloseToWorldHeightLimits(Context context, DimensionPadding padding,
        BoundingBox box) {

        if (padding.IsZero) {
            return false;
        }

        return box.MinY < context.MinY + padding.Bottom || box.MaxY > context.MaxY - 1 - padding.Top;
    }

    private static Vec3<int>? RandomNamedJigsaw(Context context, IStructurePoolElement element,
        Identifier wanted, Vec3<int> position, BlockRotation rotation, RandomSource random) {

        foreach (JigsawBlockInfo jigsaw in element.GetShuffledJigsawBlocks(context.Templates,
            position, rotation, random, context.Registry)) {

            if (jigsaw.Name.Equals(wanted)) {
                return jigsaw.Info.Pos;
            }
        }

        return null;
    }

    /// <summary>One piece waiting to have its own connections filled.</summary>
    private readonly record struct PieceState(PoolElementStructurePiece Piece, JigsawFreeSpace Free,
        int Depth);

    /// <summary>
    /// <c>JigsawPlacement.Placer</c>: the expansion loop.
    /// </summary>
    private sealed class Placer(Context context, Settings settings,
        List<PoolElementStructurePiece> pieces, RandomSource random) {

        private readonly SequencedPriorityQueue<PieceState> _placing = new();

        public void Run(PoolElementStructurePiece centre, JigsawFreeSpace free,
            PoolAliasLookup aliases) {

            TryPlacingChildren(centre, free, 0, aliases);

            while (_placing.TryTake(out PieceState state)) {
                TryPlacingChildren(state.Piece, state.Free, state.Depth, aliases);
            }
        }

        /// <summary>
        /// Fills every connection on one piece, taking the first candidate that fits each.
        /// </summary>
        /// <remarks>
        /// The candidate list is the target pool's shuffled elements followed by its fallback's, and
        /// the target pool is left out entirely at the depth limit, so a structure at its limit is
        /// closed off by the fallback rather than truncated. <b>Reaching the empty element stops the
        /// walk</b>, so an empty entry in a pool hides everything the shuffle put after it.
        /// </remarks>
        private void TryPlacingChildren(PoolElementStructurePiece sourcePiece, JigsawFreeSpace free,
            int depth, PoolAliasLookup aliases) {

            IStructurePoolElement sourceElement = sourcePiece.Element;
            Vec3<int> sourcePosition = sourcePiece.Position;
            BlockRotation sourceRotation = sourcePiece.Rotation;
            bool sourceRigid = sourceElement.Projection == PoolProjection.Rigid;

            BoundingBox sourceBox = sourcePiece.BoundingBox;
            int sourceBoxY = sourceBox.MinY;

            // Built on the first connection that points back into the source's own box, and shared by
            // every later one that does, so two such connections cannot fill the same space.
            JigsawFreeSpace? sourceFree = null;

            foreach (JigsawBlockInfo sourceJigsaw in sourceElement.GetShuffledJigsawBlocks(
                context.Templates, sourcePosition, sourceRotation, random, context.Registry)) {

                BlockFace sourceFacing = JigsawBlockInfo.FrontFacing(context.Registry,
                    sourceJigsaw.Info.StateId);

                Vec3<int> sourceJigsawPos = sourceJigsaw.Info.Pos;
                Vec3<int> targetJigsawPos = sourceJigsawPos.GetBlockTowards(sourceFacing);
                int sourceJigsawLocalY = sourceJigsawPos.Y - sourceBoxY;
                int sourceColumnHeight = UnsetHeight;

                Identifier poolName = aliases.Lookup(sourceJigsaw.Pool);
                StructureTemplatePool? targetPool = context.Pools.Get(poolName);

                if (targetPool is null || (targetPool.Size == 0 && !poolName.Equals(TemplatePools.Empty))) {
                    continue;
                }

                StructureTemplatePool? fallback = context.Pools.Get(targetPool.FallbackId);

                if (fallback is null
                    || (fallback.Size == 0 && !targetPool.FallbackId.Equals(TemplatePools.Empty))) {

                    continue;
                }

                bool attachInsideSource = sourceBox.IsInside(targetJigsawPos.X, targetJigsawPos.Y,
                    targetJigsawPos.Z);

                JigsawFreeSpace childrenFree;

                if (attachInsideSource) {
                    sourceFree ??= JigsawFreeSpace.Of(sourceBox);
                    childrenFree = sourceFree;
                } else {
                    childrenFree = free;
                }

                List<IStructurePoolElement> candidates = [];

                if (depth != settings.MaxDepth) {
                    candidates.AddRange(targetPool.ShuffledTemplates(random));
                }

                candidates.AddRange(fallback.ShuffledTemplates(random));

                TryFill(sourcePiece, sourceJigsaw, sourceFacing, sourceJigsawPos, targetJigsawPos,
                    sourceJigsawLocalY, sourceBoxY, sourceRigid, candidates, childrenFree, depth,
                    aliases, ref sourceColumnHeight);
            }
        }

        /// <summary>
        /// Tries every candidate and rotation for one connection, keeping the first that works.
        /// </summary>
        private void TryFill(PoolElementStructurePiece sourcePiece, JigsawBlockInfo sourceJigsaw,
            BlockFace sourceFacing, Vec3<int> sourceJigsawPos, Vec3<int> targetJigsawPos,
            int sourceJigsawLocalY, int sourceBoxY, bool sourceRigid,
            List<IStructurePoolElement> candidates, JigsawFreeSpace childrenFree, int depth,
            PoolAliasLookup aliases, ref int sourceColumnHeight) {

            foreach (IStructurePoolElement targetElement in candidates) {
                if (ReferenceEquals(targetElement, EmptyPoolElement.Instance)) {
                    return;
                }

                foreach (BlockRotation targetRotation in ShuffledRotations(random)) {
                    List<JigsawBlockInfo> targetJigsaws = targetElement.GetShuffledJigsawBlocks(
                        context.Templates, new Vec3<int>(0, 0, 0), targetRotation, random,
                        context.Registry);

                    BoundingBox rawBox = targetElement.GetBoundingBox(context.Templates,
                        new Vec3<int>(0, 0, 0), targetRotation);

                    int expandTo = settings.UseExpansionHack && rawBox.YSpan <= 16
                        ? ExpansionSize(targetJigsaws, rawBox, aliases)
                        : 0;

                    foreach (JigsawBlockInfo targetJigsaw in targetJigsaws) {
                        if (!JigsawBlockInfo.CanAttach(context.Registry, sourceJigsaw, targetJigsaw)) {
                            continue;
                        }

                        if (Join(sourcePiece, sourceJigsaw, sourceFacing, sourceJigsawPos,
                            targetJigsawPos, sourceJigsawLocalY, sourceBoxY, sourceRigid,
                            targetElement, targetRotation, targetJigsaw, expandTo, childrenFree,
                            depth, ref sourceColumnHeight)) {

                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Works out where a candidate would sit and places it if it fits.
        /// </summary>
        /// <remarks>
        /// The height is the load bearing part. <b>Two rigid pieces keep the offset their jigsaw
        /// blocks imply</b>, so a house joined to a house stays level with it; anything else is dropped
        /// onto the terrain under the <b>source's</b> jigsaw column, which is what makes a path follow
        /// the ground. That column is measured at most once per connection, which is why it is carried
        /// in and out by reference.
        /// </remarks>
        private bool Join(PoolElementStructurePiece sourcePiece, JigsawBlockInfo sourceJigsaw,
            BlockFace sourceFacing, Vec3<int> sourceJigsawPos, Vec3<int> targetJigsawPos,
            int sourceJigsawLocalY, int sourceBoxY, bool sourceRigid,
            IStructurePoolElement targetElement, BlockRotation targetRotation,
            JigsawBlockInfo targetJigsaw, int expandTo, JigsawFreeSpace childrenFree, int depth,
            ref int sourceColumnHeight) {

            Vec3<int> targetLocal = targetJigsaw.Info.Pos;

            Vec3<int> rawTargetPos = new(targetJigsawPos.X - targetLocal.X,
                targetJigsawPos.Y - targetLocal.Y, targetJigsawPos.Z - targetLocal.Z);

            BoundingBox rawTargetBox = targetElement.GetBoundingBox(context.Templates, rawTargetPos,
                targetRotation);

            bool targetRigid = targetElement.Projection == PoolProjection.Rigid;
            int targetJigsawLocalY = targetLocal.Y;
            int deltaY = sourceJigsawLocalY - targetJigsawLocalY + StepY(sourceFacing);

            int targetBoxY;

            if (sourceRigid && targetRigid) {
                targetBoxY = sourceBoxY + deltaY;
            } else {
                sourceColumnHeight = SourceColumnHeight(sourceJigsawPos, sourceColumnHeight);
                targetBoxY = sourceColumnHeight - targetJigsawLocalY;
            }

            int yOffset = targetBoxY - rawTargetBox.MinY;
            BoundingBox targetBox = rawTargetBox.Moved(0, yOffset, 0);

            Vec3<int> targetPos = new(rawTargetPos.X, rawTargetPos.Y + yOffset, rawTargetPos.Z);

            if (expandTo > 0) {
                int newSize = Math.Max(expandTo + 1, targetBox.MaxY - targetBox.MinY);

                targetBox.Encapsulate(new BoundingBox(targetBox.MinX, targetBox.MinY + newSize,
                    targetBox.MinZ));
            }

            if (!childrenFree.Fits(targetBox)) {
                return false;
            }

            childrenFree.Remove(targetBox);

            int sourceGroundLevelDelta = sourcePiece.GroundLevelDelta;

            int targetGroundLevelDelta = targetRigid
                ? sourceGroundLevelDelta - deltaY
                : targetElement.GroundLevelDelta;

            PoolElementStructurePiece targetPiece = new(context.Templates, targetElement, targetPos,
                targetGroundLevelDelta, targetRotation, targetBox, settings.ApplyWaterlogging);

            int junctionY;

            if (sourceRigid) {
                junctionY = sourceBoxY + sourceJigsawLocalY;
            } else if (targetRigid) {
                junctionY = targetBoxY + targetJigsawLocalY;
            } else {
                sourceColumnHeight = SourceColumnHeight(sourceJigsawPos, sourceColumnHeight);
                junctionY = sourceColumnHeight + deltaY / 2;
            }

            sourcePiece.AddJunction(new JigsawJunction(targetJigsawPos.X,
                junctionY - sourceJigsawLocalY + sourceGroundLevelDelta, targetJigsawPos.Z, deltaY,
                targetElement.Projection));

            targetPiece.AddJunction(new JigsawJunction(sourceJigsawPos.X,
                junctionY - targetJigsawLocalY + targetGroundLevelDelta, sourceJigsawPos.Z, -deltaY,
                sourcePiece.Element.Projection));

            pieces.Add(targetPiece);

            if (depth + 1 <= settings.MaxDepth) {
                _placing.Add(new PieceState(targetPiece, childrenFree, depth + 1),
                    sourceJigsaw.PlacementPriority);
            }

            return true;
        }

        private int SourceColumnHeight(Vec3<int> sourceJigsawPos, int cached) {
            return cached != UnsetHeight
                ? cached
                : context.Heights(sourceJigsawPos.X, sourceJigsawPos.Z,
                    HeightmapType.WorldSurfaceWorldgen);
        }

        /// <summary>
        /// How much taller a candidate should be treated as, for the expansion hack.
        /// </summary>
        /// <remarks>
        /// The hack is a village's alone. A short piece whose own connections lead to tall pools has
        /// its box inflated to the tallest of them <b>before</b> the fit test, which reserves the room
        /// those children will need.
        /// <p/>
        /// <b>Only a connection pointing back into the candidate's own box counts.</b> That is what a
        /// village street's house entrances are: they sit on the road and face along it, so the cell
        /// ahead of one is road rather than open ground, and a house joined to it is grown inside the
        /// street's box. Counting the connections pointing outward instead inflates a street by the
        /// street pool's own two blocks, and then no house fits inside it and every entrance falls
        /// through to the terminator pool, which is a village of roads with nothing on them.
        /// </remarks>
        private int ExpansionSize(List<JigsawBlockInfo> targetJigsaws, BoundingBox rawBox,
            PoolAliasLookup aliases) {

            int expandTo = 0;

            foreach (JigsawBlockInfo jigsaw in targetJigsaws) {
                BlockFace facing = JigsawBlockInfo.FrontFacing(context.Registry, jigsaw.Info.StateId);
                Vec3<int> ahead = jigsaw.Info.Pos.GetBlockTowards(facing);

                if (!rawBox.IsInside(ahead.X, ahead.Y, ahead.Z)) {
                    continue;
                }

                StructureTemplatePool? childPool = context.Pools.Get(aliases.Lookup(jigsaw.Pool));

                int childSize = childPool?.MaxSize(context.Templates) ?? 0;

                StructureTemplatePool? childFallback = childPool is null
                    ? null
                    : context.Pools.Get(childPool.FallbackId);

                int fallbackSize = childFallback?.MaxSize(context.Templates) ?? 0;

                expandTo = Math.Max(expandTo, Math.Max(childSize, fallbackSize));
            }

            return expandTo;
        }
    }

    /// <summary>The four rotations in a drawn order, <c>Rotation.getShuffled</c>.</summary>
    private static List<BlockRotation> ShuffledRotations(RandomSource random) {
        List<BlockRotation> rotations = [
            BlockRotation.None, BlockRotation.Clockwise90, BlockRotation.Clockwise180,
            BlockRotation.CounterClockwise90
        ];

        StructurePiece.Shuffle(rotations, random);
        return rotations;
    }

    private static int StepY(BlockFace face) {
        return face switch {
            BlockFace.PosY => 1,
            BlockFace.NegY => -1,
            _ => 0
        };
    }
}

/// <summary>
/// <c>SequencedPriorityIterator</c>: a queue that hands out the highest priority first and keeps
/// insertion order within one priority.
/// </summary>
/// <remarks>
/// Items are added <b>while it is being drained</b>, and one added at a higher priority than the
/// current one jumps the queue, which is the whole reason it is not an ordinary queue: a jigsaw
/// connection with a high placement priority expands before everything already waiting.
/// </remarks>
public sealed class SequencedPriorityQueue<T> {
    private readonly SortedDictionary<int, Queue<T>> _byPriority =
        new(Comparer<int>.Create((a, b) => b.CompareTo(a)));

    public void Add(T item, int priority) {
        if (!_byPriority.TryGetValue(priority, out Queue<T>? queue)) {
            queue = new Queue<T>();
            _byPriority[priority] = queue;
        }

        queue.Enqueue(item);
    }

    public bool TryTake(out T item) {
        int? found = null;

        foreach ((int priority, Queue<T> queue) in _byPriority) {
            if (queue.Count > 0) {
                found = priority;
                break;
            }
        }

        if (found is not { } highest) {
            item = default!;
            return false;
        }

        Queue<T> from = _byPriority[highest];
        item = from.Dequeue();

        if (from.Count == 0) {
            _byPriority.Remove(highest);
        }

        return true;
    }
}
