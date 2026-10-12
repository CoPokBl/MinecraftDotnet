using System.Collections.Concurrent;
using Minecraft.Physics;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Fluids;

namespace ManagedServer.Fluids;

/// <summary>
/// Everything the fluid simulation reads off a block state, resolved once per state id.
/// <p/>
/// The expensive part is the faces: <c>FlowingFluid.canPassThroughWall</c> asks whether the two
/// collision faces meeting at a boundary cover it between them, which vanilla answers by merging two
/// voxel shapes. Both faces are fixed per state, so they are flattened into rectangles here and the
/// question becomes whether a handful of rectangles tile the unit square.
/// </summary>
public static class FluidBlockData {
    /// <summary>A face of a collision shape, in the plane of the two axes that are not its own.</summary>
    public readonly record struct Rect(double U0, double V0, double U1, double V1);

    public sealed class Entry {
        public required IBlock Block { get; init; }
        public required FluidState Fluid { get; init; }

        /// <summary>Vanilla compares the shape against <c>Shapes.block()</c> by identity; a full cube is the same test.</summary>
        public required bool FullCube { get; init; }

        public required bool EmptyShape { get; init; }
        public required bool BlocksMotion { get; init; }
        public required bool Solid { get; init; }
        public required bool Air { get; init; }

        /// <summary>Whether the block is a <c>LiquidBlockContainer</c>, which here means it can be waterlogged.</summary>
        public required bool Container { get; init; }

        /// <summary>Whether the state is already waterlogged, so it cannot take another source.</summary>
        public required bool Waterlogged { get; init; }

        public required bool CanHoldAnyFluid { get; init; }

        /// <summary>The collision boxes, before the shape is moved by the block's position.</summary>
        public required Box[] Boxes { get; init; }

        /// <summary>
        /// <c>BlockStateBase.getShape</c>, the outline the crosshair picks against, which is what
        /// <c>ClipContext.Block.OUTLINE</c> reads and is not the collision shape: a torch has an outline
        /// and no collision. Before the shape is moved by the block's position, like the rest.
        /// </summary>
        public required Box[] OutlineBoxes { get; init; }

        /// <summary><c>BlockStateBase.getInteractionShape</c>, which can only override a hit's face.</summary>
        public required Box[] InteractionBoxes { get; init; }

        /// <summary>
        /// The block's offset bounds when its shape is moved by a hash of the position it sits at, and
        /// null for everything else. Bamboo and dripstone are the two that collide, and vanilla asks
        /// about the moved shape, so a boundary against one is a question about where it is.
        /// </summary>
        public required BlockInfo? Offsets { get; init; }

        /// <summary>The face at coordinate 1 on each axis, or null when the shape does not reach it.</summary>
        public required Rect[]?[] FaceMax { get; init; }

        /// <summary>The face at coordinate 0 on each axis, or null when the shape does not start there.</summary>
        public required Rect[]?[] FaceMin { get; init; }
    }

    private const double Epsilon = 1.0E-7;

    private static readonly Identifier DoorCategory = "minecraft:door";
    private static readonly Identifier SignsTag = "minecraft:signs";

    private static readonly Identifier[] NeverHoldsFluid = [
        "minecraft:ladder",
        "minecraft:sugar_cane",
        "minecraft:bubble_column",
        "minecraft:nether_portal",
        "minecraft:end_portal",
        "minecraft:end_gateway",
        "minecraft:structure_void"
    ];

    private static readonly ConcurrentDictionary<uint, Entry> Cache = new();

    public static Entry Get(MinecraftRegistry registry, uint stateId) {
        return Cache.GetOrAdd(stateId, static (state, reg) =>
            reg.Blocks.StatesByStateId.TryGetValue(state, out IBlock? block)
                ? Build(reg, block.WithState(state))
                : Missing(), registry);
    }

    public static Entry Get(MinecraftRegistry registry, IBlock block) => Get(registry, block.StateId);

    /// <summary>
    /// <c>FlowingFluid.canPassThroughWall</c>: whether a fluid moving from <paramref name="source"/>
    /// towards <paramref name="face"/> is stopped by the wall between it and <paramref name="target"/>.
    /// <p/>
    /// The positions are only read for a block whose shape is moved by where it sits, which vanilla
    /// asks about through <c>getCollisionShape(level, pos)</c>.
    /// </summary>
    public static bool CanPassThroughWall(Entry source, Vec3<int> sourcePos, Entry target, Vec3<int> targetPos, BlockFace face) {
        if (target.FullCube || source.FullCube) {
            return false;
        }

        if (source.EmptyShape && target.EmptyShape) {
            return true;
        }

        // Shapes.mergedFaceOccludes: the two faces meeting at the boundary are OR'd together and the
        // fluid is stopped only when the union covers the whole square.
        int axis = FluidDirections.Axis(face);
        (Entry lower, Vec3<int> lowerPos, Entry upper, Vec3<int> upperPos) = FluidDirections.IsPositive(face)
            ? (source, sourcePos, target, targetPos)
            : (target, targetPos, source, sourcePos);

        return !CoversUnitSquare(FaceOf(lower, lowerPos, axis, max: true), FaceOf(upper, upperPos, axis, max: false));
    }

    /// <summary>
    /// The face of a block that may have been moved by where it sits.
    /// <p/>
    /// An axis it moved along contributes nothing. Vanilla slices a shape on the shape's <i>own</i>
    /// coordinate grid, which the move takes with it, so the outermost slice of a moved shape is the
    /// cell that used to sit against the boundary and is now beyond it. Dripstone is the block that
    /// shows it: its widest form fills eight sixteenths to fourteen, and moved to the corner of its
    /// range it starts at exactly zero and still contributes no face, because the slice vanilla reads
    /// is the empty one that moved to minus an eighth. The horizontal offsets are sixteen values
    /// spread either side of centre and none of them is zero, so in practice this is every offset
    /// block on both horizontal axes and no block at all on the vertical one.
    /// </summary>
    private static Rect[]? FaceOf(Entry entry, Vec3<int> pos, int axis, bool max) {
        // Only the shapes that carry the offset, not every shape of a block that has one: short grass
        // has an offset and does not move its shapes with it.
        if (entry.Offsets == null || !entry.Offsets.Offsets(BlockShapeOffsets.Collision)) {
            return max ? entry.FaceMax[axis] : entry.FaceMin[axis];
        }

        Vec3<double> offset = entry.Offsets.ShapeOffset(pos);
        if (Math.Abs(offset[axis]) > Epsilon) {
            return null;
        }

        Box[] moved = new Box[entry.Boxes.Length];
        for (int i = 0; i < moved.Length; i++) {
            moved[i] = entry.Boxes[i].Translate(offset);
        }

        return FaceAt(moved, axis, max);
    }

    private static Entry Missing() {
        // An unknown state stands in for the void outside the world, which nothing passes through.
        return new Entry {
            Block = Minecraft.Data.Generated.Block.Air,
            Fluid = FluidState.Empty,
            Boxes = [],
            OutlineBoxes = [],
            InteractionBoxes = [],
            Offsets = null,
            FullCube = true,
            EmptyShape = false,
            BlocksMotion = true,
            Solid = true,
            Air = false,
            Container = false,
            Waterlogged = false,
            CanHoldAnyFluid = false,
            FaceMax = [null, null, null],
            FaceMin = [null, null, null]
        };
    }

    private static Entry Build(MinecraftRegistry registry, IBlock block) {
        Box[] boxes = BlockPhysicsData.Get(registry, block.StateId).Collision;

        bool container = block.ToStateNbt().Contains("waterlogged");
        bool waterlogged = container && block.Fluid != null;
        BlockInfo? offsets = block.Info.OffsetType == BlockOffsetType.None ? null : block.Info;

        return new Entry {
            Block = block,
            Fluid = FluidState.Of(block),
            Boxes = boxes,
            OutlineBoxes = BlockPhysicsData.ShapeBoxesOf(block.BlockShape),
            InteractionBoxes = BlockPhysicsData.ShapeBoxesOf(block.InteractionShape),
            Offsets = offsets,
            // A shape that gets moved is a new object rather than Shapes.block(), so vanilla's identity
            // check against it never holds for one.
            FullCube = offsets == null && IsFullCube(boxes),
            EmptyShape = boxes.Length == 0,
            BlocksMotion = block.BlocksMotion,
            Solid = block.Solid,
            Air = block.Air,
            Container = container,
            Waterlogged = waterlogged,
            CanHoldAnyFluid = CanHoldAnyFluid(registry, block, container),
            FaceMax = [FaceAt(boxes, 0, true), FaceAt(boxes, 1, true), FaceAt(boxes, 2, true)],
            FaceMin = [FaceAt(boxes, 0, false), FaceAt(boxes, 1, false), FaceAt(boxes, 2, false)]
        };
    }

    private static bool IsFullCube(Box[] boxes) {
        if (boxes.Length != 1) {
            return false;
        }

        Box box = boxes[0];
        return Math.Abs(box.MinX) < Epsilon && Math.Abs(box.MinY) < Epsilon && Math.Abs(box.MinZ) < Epsilon &&
               Math.Abs(box.MaxX - 1) < Epsilon && Math.Abs(box.MaxY - 1) < Epsilon && Math.Abs(box.MaxZ - 1) < Epsilon;
    }

    /// <summary><c>FlowingFluid.canHoldAnyFluid</c>.</summary>
    private static bool CanHoldAnyFluid(MinecraftRegistry registry, IBlock block, bool container) {
        if (container) {
            return true;
        }

        if (block.BlocksMotion) {
            return false;
        }

        if (block.Category.Equals(DoorCategory)) {
            return false;
        }

        Identifier identifier = block.Identifier;
        foreach (Identifier excluded in NeverHoldsFluid) {
            if (excluded.Equals(identifier)) {
                return false;
            }
        }

        return !InTag(registry, SignsTag, identifier);
    }

    private static bool InTag(MinecraftRegistry registry, Identifier tag, Identifier block) {
        if (!registry.Blocks.Tags.Contains(tag)) {
            return false;
        }

        foreach (Identifier value in registry.Blocks.Tags[tag].GetValueIds(registry)) {
            if (value.Equals(block)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// The slice of the shape lying against the boundary of the block on <paramref name="axis"/>, as
    /// rectangles in the plane of the other two axes. Null when the shape does not reach the boundary,
    /// which is vanilla replacing the shape with an empty one before slicing it.
    /// <p/>
    /// Only boxes that end exactly at the boundary contribute: vanilla takes the outermost layer of the
    /// shape's own coordinate grid, and a box stopping short of the boundary stops at a coordinate that
    /// bounds that layer rather than crossing it.
    /// </summary>
    private static Rect[]? FaceAt(Box[] boxes, int axis, bool max) {
        if (boxes.Length == 0) {
            return null;
        }

        double bound = max ? double.NegativeInfinity : double.PositiveInfinity;
        foreach (Box box in boxes) {
            bound = max ? Math.Max(bound, box.Max(axis)) : Math.Min(bound, box.Min(axis));
        }

        if (Math.Abs(bound - (max ? 1.0 : 0.0)) > Epsilon) {
            return null;
        }

        int u = axis == 0 ? 1 : 0;
        int v = axis == 2 ? 1 : 2;

        List<Rect> rects = [];
        foreach (Box box in boxes) {
            double edge = max ? box.Max(axis) : box.Min(axis);
            if (Math.Abs(edge - (max ? 1.0 : 0.0)) > Epsilon) {
                continue;
            }

            rects.Add(new Rect(box.Min(u), box.Min(v), box.Max(u), box.Max(v)));
        }

        return rects.Count == 0 ? null : rects.ToArray();
    }

    /// <summary>
    /// Whether the two faces cover the unit square between them, which is
    /// <c>!joinIsNotEmpty(block(), a | b, ONLY_FIRST)</c>. Both coordinate lists are merged and every
    /// cell of the resulting grid has to be inside one of the rectangles.
    /// </summary>
    private static bool CoversUnitSquare(Rect[]? a, Rect[]? b) {
        if (a == null && b == null) {
            return false;
        }

        List<double> us = [0.0, 1.0];
        List<double> vs = [0.0, 1.0];
        AddCoords(a, us, vs);
        AddCoords(b, us, vs);

        us.Sort();
        vs.Sort();

        for (int i = 0; i + 1 < us.Count; i++) {
            double u0 = us[i], u1 = us[i + 1];
            if (u1 - u0 < Epsilon || u1 <= 0.0 || u0 >= 1.0) {
                continue;
            }

            for (int j = 0; j + 1 < vs.Count; j++) {
                double v0 = vs[j], v1 = vs[j + 1];
                if (v1 - v0 < Epsilon || v1 <= 0.0 || v0 >= 1.0) {
                    continue;
                }

                if (!Covered(a, u0, v0, u1, v1) && !Covered(b, u0, v0, u1, v1)) {
                    return false;
                }
            }
        }

        return true;
    }

    private static void AddCoords(Rect[]? rects, List<double> us, List<double> vs) {
        if (rects == null) {
            return;
        }

        foreach (Rect rect in rects) {
            us.Add(rect.U0);
            us.Add(rect.U1);
            vs.Add(rect.V0);
            vs.Add(rect.V1);
        }
    }

    private static bool Covered(Rect[]? rects, double u0, double v0, double u1, double v1) {
        if (rects == null) {
            return false;
        }

        foreach (Rect rect in rects) {
            if (rect.U0 - Epsilon <= u0 && rect.U1 + Epsilon >= u1 &&
                rect.V0 - Epsilon <= v0 && rect.V1 + Epsilon >= v1) {
                return true;
            }
        }

        return false;
    }
}
