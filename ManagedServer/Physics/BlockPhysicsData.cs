using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Shapes;

namespace ManagedServer.Physics;

/// <summary>
/// Everything the physics loop reads off a block, resolved once per block state.
/// <p/>
/// The generated block types expose their shapes as <c>ICollisionBox.ParseAabbArrayString("…")</c>
/// and their identifiers as string literals, so every property access re-parses a string and
/// allocates. That is fine for the occasional lookup and ruinous inside a collision sweep.
/// </summary>
public static class BlockPhysicsData {
    /// <param name="Collision">Block local collision boxes; empty when the block has no collision.</param>
    /// <param name="LargeCollisionShape">
    /// Whether the shape leaves its own cube, as fences and walls do. Vanilla scans one block
    /// further out for these, see <see cref="EntityPhysics"/>.
    /// </param>
    /// <param name="WallLike">
    /// Walls and fence gates, which vanilla refuses to step down from when it looks for the block
    /// that governs an entity's movement.
    /// </param>
    /// <param name="WaterLike">
    /// Water and bubble columns, which vanilla never lets defer their speed factor downwards.
    /// </param>
    public readonly record struct Entry(
        Box[] Collision,
        bool LargeCollisionShape,
        double Friction,
        double SpeedFactor,
        bool WallLike,
        bool WaterLike);

    private static readonly Entry Missing = new([], false, 0.6, 1.0, false, false);

    private static readonly Identifier WallCategory = "minecraft:wall";
    private static readonly Identifier FenceGateCategory = "minecraft:fence_gate";
    private static readonly Identifier Water = "minecraft:water";
    private static readonly Identifier BubbleColumn = "minecraft:bubble_column";

    private static readonly ConcurrentDictionary<uint, Entry> Cache = new();

    public static Entry Get(MinecraftRegistry registry, uint stateId) {
        return Cache.GetOrAdd(stateId, static (state, reg) =>
            reg.Blocks.StatesByStateId.TryGetValue(state, out IBlock? block)
                ? Build(block.WithState(state))
                : Missing, registry);
    }

    private static Entry Build(IBlock block) {
        Box[] boxes = CollisionBoxesOf(block.CollisionShape);

        bool large = false;
        foreach (Box box in boxes) {
            if (box.MinX < 0 || box.MinY < 0 || box.MinZ < 0 || box.MaxX > 1 || box.MaxY > 1 || box.MaxZ > 1) {
                large = true;
                break;
            }
        }

        Identifier category = block.Category;
        Identifier identifier = block.Identifier;

        return new Entry(
            boxes,
            large,
            block.Friction,
            block.SpeedFactor,
            category.Equals(WallCategory) || category.Equals(FenceGateCategory),
            identifier.Equals(Water) || identifier.Equals(BubbleColumn));
    }

    /// <summary>
    /// Flattens a collision shape into the boxes the sweep works on, quantised the way vanilla's voxel
    /// grid quantises them. Block states go through <see cref="Get"/>, which caches the result; reach
    /// for this directly only for a shape you built yourself.
    /// </summary>
    public static Box[] CollisionBoxesOf(ICollisionBox shape) {
        List<Box> boxes = [];
        Flatten(shape, boxes);
        return boxes.Count == 0 ? [] : boxes.ToArray();
    }

    private static void Flatten(ICollisionBox shape, List<Box> into) {
        switch (shape) {
            case Aabb aabb:
                Split(new Box(aabb), into);
                break;
            case CompositeBox composite:
                foreach (ICollisionBox child in composite.Children) {
                    Flatten(child, into);
                }
                break;
        }
    }

    /// <summary>
    /// Vanilla stores a block's shape as a voxel grid (<c>Shapes.create</c>), so a box spanning more
    /// than one cell of that grid has internal faces: an entity already inside it is pushed to the next
    /// cell boundary rather than straight out. Splitting the box along the same grid up front gives the
    /// sweep those faces while letting it keep working on plain boxes.
    /// <p/>
    /// Coordinates that do not land on an eighths grid inside the unit cube stay whole, which is the
    /// exact fallback vanilla takes for them.
    /// </summary>
    private static void Split(Box box, List<Box> into) {
        // Shapes.create calls anything this thin empty, and an empty shape collides with nothing.
        if (box.MaxX - box.MinX < 1.0E-7 || box.MaxY - box.MinY < 1.0E-7 || box.MaxZ - box.MinZ < 1.0E-7) {
            return;
        }

        int bitsX = FindBits(box.MinX, box.MaxX);
        int bitsY = FindBits(box.MinY, box.MaxY);
        int bitsZ = FindBits(box.MinZ, box.MaxZ);

        if (bitsX < 0 || bitsY < 0 || bitsZ < 0) {
            into.Add(box);
            return;
        }

        int sizeX = 1 << bitsX, sizeY = 1 << bitsY, sizeZ = 1 << bitsZ;
        int x0 = (int)Math.Round(box.MinX * sizeX), x1 = (int)Math.Round(box.MaxX * sizeX);
        int y0 = (int)Math.Round(box.MinY * sizeY), y1 = (int)Math.Round(box.MaxY * sizeY);
        int z0 = (int)Math.Round(box.MinZ * sizeZ), z1 = (int)Math.Round(box.MaxZ * sizeZ);

        for (int x = x0; x < x1; x++) {
            for (int y = y0; y < y1; y++) {
                for (int z = z0; z < z1; z++) {
                    into.Add(new Box(
                        (double)x / sizeX, (double)y / sizeY, (double)z / sizeZ,
                        (x + 1.0) / sizeX, (y + 1.0) / sizeY, (z + 1.0) / sizeZ));
                }
            }
        }
    }

    /// <summary><c>Shapes.findBits</c>: the grid a box's coordinates land on, or -1 for none.</summary>
    private static int FindBits(double min, double max) {
        if (min < -1.0E-7 || max > 1.0000001) {
            return -1;
        }

        for (int bits = 0; bits <= 3; bits++) {
            int intervals = 1 << bits;
            double scaledMin = min * intervals;
            double scaledMax = max * intervals;
            if (Math.Abs(scaledMin - Math.Round(scaledMin)) < 1.0E-7 * intervals &&
                Math.Abs(scaledMax - Math.Round(scaledMax)) < 1.0E-7 * intervals) {
                return bits;
            }
        }

        return -1;
    }
}
