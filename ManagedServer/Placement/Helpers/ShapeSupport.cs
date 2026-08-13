using System.Collections.Concurrent;
using ManagedServer.Physics;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;

namespace ManagedServer.Placement.Helpers;

/// <summary>
/// Vanilla's <c>SupportType</c>: how much of a face a block has to present before something may
/// attach to it. The three are not degrees of the same test, they are three different regions the
/// face has to cover, and which one a block asks for is part of that block's rule.
/// </summary>
public enum SupportType {
    /// <summary>
    /// The whole face. Ladders, doors, wall torches, buttons, levers and every fence, wall and pane
    /// connection want this, which is why none of them attach to the side of a slab.
    /// </summary>
    Full,

    /// <summary>
    /// A two pixel column up the middle, ten pixels tall. Standing torches, candles, lanterns,
    /// hanging signs and bells want this, which is why a torch stands on a fence post.
    /// </summary>
    Center,

    /// <summary>
    /// Everything except a twelve pixel column up the middle, ie. the outer frame. Pressure plates
    /// and repeaters want this. Only ever asked of an upward face.
    /// </summary>
    Rigid
}

/// <summary>
/// The voxel shape questions the placement rules ask: whether a shape covers a region, and the
/// cases of that vanilla has names for.
/// <p/>
/// Vanilla poses all of them as one operation,
/// <c>Shapes.joinIsNotEmpty(shape, region, ONLY_SECOND)</c>, which is "is any of the region outside
/// the shape". <see cref="Contains"/> is that operation over boxes, and everything else here is a
/// region to put through it. This replaces three separate approximations that stood in for it while
/// there was no way to ask: face sturdiness, <c>isCollisionShapeFullBlock</c> and the wall side
/// test each used to be "blocks motion and occludes", which is right for full cubes and for air and
/// wrong for the whole middle ground, and the middle ground is what these are asked about.
/// <p/>
/// Two details of <c>VoxelShape.getFaceShape</c> carry over into <see cref="IsFaceSturdy"/> and are
/// the reason it is not a bounding box comparison. The slice is taken at the <b>block boundary</b>,
/// not at the top of the shape, so the up face of a bottom slab is empty and nothing stands on it.
/// And the slice is <b>extruded</b> along the face's axis, so a shallow tray in the middle of a
/// block still presents a full face.
/// </summary>
public static class ShapeSupport {
    /// <summary>Vanilla's own tolerance, from <c>VoxelShape.getFaceShape</c>.</summary>
    private const double Epsilon = 1.0E-7;

    /// <summary><c>Shapes.block()</c>, which is what <c>isShapeFullBlock</c> compares against.</summary>
    public static readonly Box[] FullCube = [new Box(0, 0, 0, 1, 1, 1)];

    /// <summary><c>Block.column(2.0, 0.0, 10.0)</c>, <c>SupportType.CENTER</c>'s region.</summary>
    private static readonly Box[] CenterColumn = [
        new Box(7 / 16.0, 0, 7 / 16.0, 9 / 16.0, 10 / 16.0, 9 / 16.0)
    ];

    /// <summary>
    /// <c>Shapes.join(Shapes.block(), Block.column(12.0, 0.0, 16.0), ONLY_FIRST)</c>: the full cube
    /// with a twelve wide column taken out of it, written as the four boxes that leaves.
    /// </summary>
    private static readonly Box[] RigidFrame = [
        new Box(0, 0, 0, 2 / 16.0, 1, 1),
        new Box(14 / 16.0, 0, 0, 1, 1, 1),
        new Box(2 / 16.0, 0, 0, 14 / 16.0, 1, 2 / 16.0),
        new Box(2 / 16.0, 0, 14 / 16.0, 14 / 16.0, 1, 1)
    ];

    /// <summary>
    /// All eighteen face answers for a state, as a bit each, worked out once. Attachment searches
    /// ask up to six times per placement and the connection rules ask four times per neighbour, so
    /// this is on the same footing as <see cref="BlockPhysicsData"/>'s caches and keyed the same way.
    /// </summary>
    private static readonly ConcurrentDictionary<uint, int> FaceAnswers = new();

    /// <summary>
    /// <c>BlockState.isFaceSturdy(level, pos, face, type)</c>, over the block's <b>support</b> shape,
    /// which is the collision shape for most blocks and deliberately not for leaves, mud, soul sand
    /// or an open fence gate.
    /// </summary>
    public static bool IsFaceSturdy(IBlock block, BlockFace face, SupportType type = SupportType.Full) {
        int mask = FaceAnswers.GetOrAdd(block.StateId, _ => ComputeFaces(block));
        return (mask & (1 << FaceBit(face, type))) != 0;
    }

    /// <summary>
    /// <c>Block.isShapeFullBlock</c>: whether the shape is the whole cube. Reached as
    /// <c>isCollisionShapeFullBlock</c>, which is what a door asks of its neighbour to decide which
    /// way round to hang.
    /// </summary>
    public static bool IsShapeFullBlock(ICollisionBox shape) {
        return Contains(BlockPhysicsData.ShapeBoxesOf(shape), FullCube);
    }

    /// <summary>
    /// <c>!Shapes.joinIsNotEmpty(shape, region, ONLY_SECOND)</c>: whether every part of the region
    /// lies inside the shape.
    /// <p/>
    /// Coordinate compression. Every box edge from either side becomes a grid plane, and a cell of
    /// that grid is wholly inside or wholly outside each box, so testing its centre decides it. That
    /// is exact for axis aligned boxes, which is all either side holds, and it is why this is a port
    /// rather than another approximation.
    /// </summary>
    public static bool Contains(Box[] shape, Box[] region) {
        if (region.Length == 0) {
            return true;
        }

        if (shape.Length == 0) {
            return false;
        }

        double[] xs = Breaks(shape, region, 0);
        double[] ys = Breaks(shape, region, 1);
        double[] zs = Breaks(shape, region, 2);

        for (int i = 0; i + 1 < xs.Length; i++) {
            double x = (xs[i] + xs[i + 1]) / 2;
            for (int j = 0; j + 1 < ys.Length; j++) {
                double y = (ys[j] + ys[j + 1]) / 2;
                for (int k = 0; k + 1 < zs.Length; k++) {
                    double z = (zs[k] + zs[k + 1]) / 2;
                    if (Inside(region, x, y, z) && !Inside(shape, x, y, z)) {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    /// <summary>
    /// <c>VoxelShape.getFaceShape</c> over an arbitrary shape, for the callers that slice something
    /// other than a support shape. <c>WallBlock</c> takes the down face of the block above's
    /// collision shape this way.
    /// </summary>
    public static Box[] FaceShape(ICollisionBox shape, BlockFace face) {
        return FaceShape(BlockPhysicsData.ShapeBoxesOf(shape), face);
    }

    /// <summary>
    /// <c>Block.isFaceFull(shape, face)</c>: whether that face of an arbitrary shape covers the whole
    /// of it.
    /// <p/>
    /// Not the same call as <see cref="IsFaceSturdy"/> even though both end up asking about a full
    /// face. That one always slices the block's <b>support</b> shape, which is what a block standing
    /// on another asks. This takes the shape as an argument because its callers name a different one:
    /// <c>MultifaceBlock.canAttachTo</c> accepts either the support shape or the collision shape, and
    /// <c>SnowLayerBlock</c> and <c>CeilingHangingSignBlock</c> both ask the collision shape alone.
    /// </summary>
    public static bool IsFaceFull(ICollisionBox shape, BlockFace face) {
        return Contains(FaceShape(shape, face), FullCube);
    }

    private static int ComputeFaces(IBlock block) {
        Box[] boxes = BlockPhysicsData.ShapeBoxesOf(block.SupportShape);
        int mask = 0;

        foreach (BlockFace face in Directions.All) {
            Box[] slice = FaceShape(boxes, face);
            foreach (SupportType type in Enum.GetValues<SupportType>()) {
                if (Contains(slice, RegionOf(type))) {
                    mask |= 1 << FaceBit(face, type);
                }
            }
        }

        return mask;
    }

    /// <summary>
    /// <c>VoxelShape.getFaceShape</c>: the boxes that reach the boundary at that face, stretched to
    /// span the face's own axis. A box reaches the boundary cell exactly when it reaches the
    /// boundary, because every box edge lands on a line of the grid the shape was built on.
    /// </summary>
    private static Box[] FaceShape(Box[] boxes, BlockFace face) {
        int axis = AxisOf(face);
        bool positive = ((int)face & 1) == 1;

        List<Box> slice = [];
        foreach (Box box in boxes) {
            bool touches = positive
                ? box.Max(axis) >= 1.0 - Epsilon
                : box.Min(axis) <= Epsilon;
            if (!touches) {
                continue;
            }

            slice.Add(axis switch {
                0 => new Box(0, box.MinY, box.MinZ, 1, box.MaxY, box.MaxZ),
                1 => new Box(box.MinX, 0, box.MinZ, box.MaxX, 1, box.MaxZ),
                _ => new Box(box.MinX, box.MinY, 0, box.MaxX, box.MaxY, 1)
            });
        }

        return slice.ToArray();
    }

    private static int AxisOf(BlockFace face) => (int)face switch {
        0 or 1 => 1,
        2 or 3 => 2,
        _ => 0
    };

    private static int FaceBit(BlockFace face, SupportType type) => (int)face * 3 + (int)type;

    private static Box[] RegionOf(SupportType type) => type switch {
        SupportType.Center => CenterColumn,
        SupportType.Rigid => RigidFrame,
        _ => FullCube
    };

    private static double[] Breaks(Box[] shape, Box[] region, int axis) {
        SortedSet<double> breaks = [];

        foreach (Box box in shape) {
            breaks.Add(box.Min(axis));
            breaks.Add(box.Max(axis));
        }

        foreach (Box box in region) {
            breaks.Add(box.Min(axis));
            breaks.Add(box.Max(axis));
        }

        return breaks.ToArray();
    }

    private static bool Inside(Box[] boxes, double x, double y, double z) {
        foreach (Box box in boxes) {
            if (x > box.MinX && x < box.MaxX
                && y > box.MinY && y < box.MaxY
                && z > box.MinZ && z < box.MaxZ) {
                return true;
            }
        }

        return false;
    }
}
