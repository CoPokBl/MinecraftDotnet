using ManagedServer.Entities.Types;
using ManagedServer.Physics;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;
using Entry = ManagedServer.Fluids.FluidBlockData.Entry;

namespace ManagedServer.Fluids;

/// <summary>
/// A port of <c>BlockGetter.clip</c> and the <c>Item.getPlayerPOVHitResult</c> that calls it, which a
/// bucket needs because it acts on <c>use_item</c> rather than on the block the client said it clicked.
/// A filled bucket looks with <c>ClipContext.Fluid.NONE</c> and sees straight through fluids, an empty
/// one looks with <c>SOURCE_ONLY</c> and stops at the surface of one.
/// <p/>
/// Three things about the vanilla clip are easy to get wrong and all three change which block a bucket
/// fills. It reads the <b>outline</b> shape (<c>ClipContext.Block.OUTLINE</c> is
/// <c>BlockStateBase::getShape</c>), not the collision shape, so a torch or a flower stops the ray even
/// though nothing collides with them. The face comes from the box that was actually struck, not from
/// the block boundary the ray last crossed, which is a different answer for every shape that does not
/// reach its own boundary. And the interaction shape can override that face without moving the hit.
/// </summary>
public static class FluidRaycast {
    /// <param name="Pos">The block that was hit.</param>
    /// <param name="Face">
    /// The side of it the ray came in through, which is the side a bucket empties onto.
    /// </param>
    public readonly record struct Hit(Vec3<int> Pos, BlockFace Face);

    /// <summary>Where along the ray a shape was struck, and through which of its faces.</summary>
    private readonly record struct ShapeHit(double Scale, BlockFace Face);

    private const double Epsilon = 1.0E-7;

    /// <summary>
    /// What the player is aiming at, or null when nothing is within reach.
    /// </summary>
    /// <param name="stopAtFluidSources">
    /// Whether a fluid source counts as something to hit, which is the difference between an empty
    /// bucket and a full one.
    /// </param>
    public static Hit? Look(FluidSimulation fluids, Player player, bool stopAtFluidSources) {
        Vec3<double> from = player.Position.WithY(player.Position.Y + player.EyeHeight);

        // Player.blockInteractionRange, which is 4.5 and half a block more in creative.
        double reach = player.GetAttributeValue(Attribute.BlockInteractionRange);
        return Clip(fluids, from, from + player.Direction * reach, stopAtFluidSources);
    }

    /// <summary>
    /// <c>BlockGetter.clip</c>: the nearest of the block shape and the fluid shape, over the blocks the
    /// ray passes through in order.
    /// </summary>
    public static Hit? Clip(FluidSimulation fluids, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        return Clip(fluids.GetState, from, to, stopAtFluidSources);
    }

    /// <inheritdoc cref="Clip(FluidSimulation,Vec3{double},Vec3{double},bool)"/>
    /// <param name="states">
    /// The block at a position. Taking the lookup rather than a world is what lets the conformance
    /// fixture replay a scene without standing one up.
    /// </param>
    public static Hit? Clip(Func<Vec3<int>, Entry> states, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        return TraverseBlocks(from, to, pos => ClipBlock(states, pos, from, to, stopAtFluidSources));
    }

    /// <summary>
    /// <c>BlockGetter.traverseBlocks</c>, the walk that visits every block the segment crosses in the
    /// order it crosses them, so the first shape that answers is the nearest one.
    /// </summary>
    private static Hit? TraverseBlocks(Vec3<double> from, Vec3<double> to, Func<Vec3<int>, Hit?> visit) {
        if (from == to) {
            return null;
        }

        // Both ends are pulled a hair inwards, which is what keeps a ray starting or ending exactly on a
        // block boundary out of the block it only touches.
        double toX = Lerp(-Epsilon, to.X, from.X);
        double toY = Lerp(-Epsilon, to.Y, from.Y);
        double toZ = Lerp(-Epsilon, to.Z, from.Z);
        double fromX = Lerp(-Epsilon, from.X, to.X);
        double fromY = Lerp(-Epsilon, from.Y, to.Y);
        double fromZ = Lerp(-Epsilon, from.Z, to.Z);

        int x = (int)Math.Floor(fromX), y = (int)Math.Floor(fromY), z = (int)Math.Floor(fromZ);

        Hit? first = visit(new Vec3<int>(x, y, z));
        if (first != null) {
            return first;
        }

        double dx = toX - fromX, dy = toY - fromY, dz = toZ - fromZ;
        int signX = Math.Sign(dx), signY = Math.Sign(dy), signZ = Math.Sign(dz);

        double deltaX = signX == 0 ? double.MaxValue : signX / dx;
        double deltaY = signY == 0 ? double.MaxValue : signY / dy;
        double deltaZ = signZ == 0 ? double.MaxValue : signZ / dz;

        double tX = deltaX * (signX > 0 ? 1.0 - Frac(fromX) : Frac(fromX));
        double tY = deltaY * (signY > 0 ? 1.0 - Frac(fromY) : Frac(fromY));
        double tZ = deltaZ * (signZ > 0 ? 1.0 - Frac(fromZ) : Frac(fromZ));

        while (tX <= 1.0 || tY <= 1.0 || tZ <= 1.0) {
            if (tX < tY) {
                if (tX < tZ) {
                    x += signX;
                    tX += deltaX;
                }
                else {
                    z += signZ;
                    tZ += deltaZ;
                }
            }
            else if (tY < tZ) {
                y += signY;
                tY += deltaY;
            }
            else {
                z += signZ;
                tZ += deltaZ;
            }

            Hit? hit = visit(new Vec3<int>(x, y, z));
            if (hit != null) {
                return hit;
            }
        }

        return null;
    }

    /// <summary>
    /// One block's worth of <c>BlockGetter.clip</c>: the block shape and the fluid shape are clipped
    /// separately and the nearer one wins, the block shape taking a tie.
    /// </summary>
    private static Hit? ClipBlock(Func<Vec3<int>, Entry> states, Vec3<int> pos, Vec3<double> from, Vec3<double> to, bool stopAtFluidSources) {
        Entry state = states(pos);

        ShapeHit? block = ClipWithInteractionOverride(state, pos, from, to);
        ShapeHit? fluid = stopAtFluidSources && state.Fluid.Source
            ? ClipShape(FluidBoxes(states, state, pos), pos, from, to)
            : null;

        double blockScale = block?.Scale ?? double.MaxValue;
        double fluidScale = fluid?.Scale ?? double.MaxValue;

        ShapeHit? nearest = blockScale <= fluidScale ? block : fluid;
        return nearest == null ? null : new Hit(pos, nearest.Value.Face);
    }

    /// <summary>
    /// <c>BlockGetter.clipWithInteractionOverride</c>: a nearer interaction shape replaces the face of
    /// the hit without replacing the hit itself.
    /// </summary>
    private static ShapeHit? ClipWithInteractionOverride(Entry state, Vec3<int> pos, Vec3<double> from, Vec3<double> to) {
        ShapeHit? result = ClipShape(Moved(state, state.OutlineBoxes, BlockShapeOffsets.Block, pos), pos, from, to);
        if (result == null) {
            return null;
        }

        ShapeHit? over = ClipShape(Moved(state, state.InteractionBoxes, BlockShapeOffsets.Interaction, pos), pos, from, to);
        return over != null && over.Value.Scale < result.Value.Scale
            ? result.Value with { Face = over.Value.Face }
            : result;
    }

    /// <summary>
    /// The shape a fluid presents to a ray, <c>FlowingFluid.getShape</c>: a box as tall as the fluid,
    /// which is the whole block when the same fluid sits above it.
    /// <p/>
    /// Vanilla caches that box per fluid state with the level and position of whichever call built it
    /// first, so upstream the height is really decided once per fluid and reused everywhere. That is a
    /// bug rather than a rule, and it is not reproducible anyway since it depends on which block the
    /// server happened to ask about first, so this answers per position as the method reads.
    /// </summary>
    private static Box[] FluidBoxes(Func<Vec3<int>, Entry> states, Entry state, Vec3<int> pos) {
        bool sameAbove = states(FluidDirections.Above(pos)).Fluid.IsSame(state.Fluid.Kind);
        double height = sameAbove ? 1.0 : state.Fluid.OwnHeight;
        return [new Box(0, 0, 0, 1, height, 1)];
    }

    /// <summary>
    /// The shape moved by the hash of the position it sits at, which the stored shapes have taken out.
    /// <p/>
    /// Only for the shapes that actually carry the offset. Having one is a property of the block and
    /// using it is a property of each shape: <c>short_grass</c> has an offset and its <c>getShape</c>
    /// returns the unmoved shape, so moving it here would put the outline somewhere vanilla never
    /// clips against.
    /// </summary>
    private static Box[] Moved(Entry state, Box[] boxes, BlockShapeOffsets shape, Vec3<int> pos) {
        if (state.Offsets == null || boxes.Length == 0 || !state.Offsets.Offsets(shape)) {
            return boxes;
        }

        Vec3<double> offset = state.Offsets.ShapeOffset(pos);
        Box[] moved = new Box[boxes.Length];
        for (int i = 0; i < boxes.Length; i++) {
            moved[i] = boxes[i].Translate(offset);
        }

        return moved;
    }

    /// <summary>
    /// <c>VoxelShape.clip</c>. A ray that starts inside the shape hits it at once, through the face it
    /// is most nearly travelling away from, which is what stops a bucket used inside a block from
    /// reaching through it.
    /// </summary>
    private static ShapeHit? ClipShape(Box[] boxes, Vec3<int> pos, Vec3<double> from, Vec3<double> to) {
        if (boxes.Length == 0) {
            return null;
        }

        double dx = to.X - from.X, dy = to.Y - from.Y, dz = to.Z - from.Z;
        if (dx * dx + dy * dy + dz * dz < Epsilon) {
            return null;
        }

        double testX = from.X + dx * 0.001 - pos.X;
        double testY = from.Y + dy * 0.001 - pos.Y;
        double testZ = from.Z + dz * 0.001 - pos.Z;

        foreach (Box box in boxes) {
            // Vanilla asks the voxel grid whether the cell holding the point is filled, so a point on a
            // box's far boundary belongs to the next cell along rather than to this box.
            if (testX >= box.MinX && testX < box.MaxX &&
                testY >= box.MinY && testY < box.MaxY &&
                testZ >= box.MinZ && testZ < box.MaxZ) {
                return new ShapeHit(0.001, Opposite(ApproximateNearest(dx, dy, dz)));
            }
        }

        return ClipBoxes(boxes, pos, from, dx, dy, dz);
    }

    /// <summary><c>AABB.clip</c>: the nearest face any of the boxes offers, sharing one running scale.</summary>
    private static ShapeHit? ClipBoxes(Box[] boxes, Vec3<int> pos, Vec3<double> from, double dx, double dy, double dz) {
        double scale = 1.0;
        BlockFace? face = null;

        foreach (Box box in boxes) {
            double minX = box.MinX + pos.X, minY = box.MinY + pos.Y, minZ = box.MinZ + pos.Z;
            double maxX = box.MaxX + pos.X, maxY = box.MaxY + pos.Y, maxZ = box.MaxZ + pos.Z;

            if (dx > Epsilon) {
                face = ClipPoint(ref scale, face, dx, dy, dz, minX, minY, maxY, minZ, maxZ, BlockFace.NegX, from.X, from.Y, from.Z);
            }
            else if (dx < -Epsilon) {
                face = ClipPoint(ref scale, face, dx, dy, dz, maxX, minY, maxY, minZ, maxZ, BlockFace.PosX, from.X, from.Y, from.Z);
            }

            if (dy > Epsilon) {
                face = ClipPoint(ref scale, face, dy, dz, dx, minY, minZ, maxZ, minX, maxX, BlockFace.NegY, from.Y, from.Z, from.X);
            }
            else if (dy < -Epsilon) {
                face = ClipPoint(ref scale, face, dy, dz, dx, maxY, minZ, maxZ, minX, maxX, BlockFace.PosY, from.Y, from.Z, from.X);
            }

            if (dz > Epsilon) {
                face = ClipPoint(ref scale, face, dz, dx, dy, minZ, minX, maxX, minY, maxY, BlockFace.NegZ, from.Z, from.X, from.Y);
            }
            else if (dz < -Epsilon) {
                face = ClipPoint(ref scale, face, dz, dx, dy, maxZ, minX, maxX, minY, maxY, BlockFace.PosZ, from.Z, from.X, from.Y);
            }
        }

        return face == null ? null : new ShapeHit(scale, face.Value);
    }

    /// <summary>
    /// <c>AABB.clipPoint</c>: where the ray meets one plane of a box, kept only when it lands inside the
    /// face and nearer than anything found so far.
    /// </summary>
    private static BlockFace? ClipPoint(ref double scale, BlockFace? face, double da, double db, double dc,
        double point, double minB, double maxB, double minC, double maxC, BlockFace newFace,
        double fromA, double fromB, double fromC) {

        double s = (point - fromA) / da;
        double b = fromB + s * db;
        double c = fromC + s * dc;

        if (0.0 < s && s < scale &&
            minB - Epsilon < b && b < maxB + Epsilon &&
            minC - Epsilon < c && c < maxC + Epsilon) {
            scale = s;
            return newFace;
        }

        return face;
    }

    /// <summary><c>Direction.getApproximateNearest</c>, in vanilla's declaration order so ties match.</summary>
    private static BlockFace ApproximateNearest(double dx, double dy, double dz) {
        BlockFace result = BlockFace.NegZ;
        float highest = float.MinValue;

        foreach ((BlockFace face, int nx, int ny, int nz) in Normals) {
            float dot = (float)dx * nx + (float)dy * ny + (float)dz * nz;
            if (dot > highest) {
                highest = dot;
                result = face;
            }
        }

        return result;
    }

    /// <summary><c>Direction.VALUES</c>, which is declaration order: down, up, north, south, west, east.</summary>
    private static readonly (BlockFace Face, int X, int Y, int Z)[] Normals = [
        (BlockFace.NegY, 0, -1, 0),
        (BlockFace.PosY, 0, 1, 0),
        (BlockFace.NegZ, 0, 0, -1),
        (BlockFace.PosZ, 0, 0, 1),
        (BlockFace.NegX, -1, 0, 0),
        (BlockFace.PosX, 1, 0, 0)
    ];

    private static BlockFace Opposite(BlockFace face) => FluidDirections.Opposite(face);

    /// <summary><c>Mth.lerp</c>.</summary>
    private static double Lerp(double delta, double start, double end) => start + delta * (end - start);

    /// <summary><c>Mth.frac</c>.</summary>
    private static double Frac(double value) => value - Math.Floor(value);
}
