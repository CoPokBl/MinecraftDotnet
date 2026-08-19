using ManagedServer.Terrain.Features.Values;
using ManagedServer.Terrain.Structures;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>FossilFeature</c>: a skeleton buried under the ground, in two layers.
/// </summary>
/// <remarks>
/// The <b>same index</b> picks the base and the overlay, so a spine's bones and the ore inside them
/// match. The two are placed as separate templates with different processor lists, which is what makes
/// the ore variant a rot processor away from the plain one.
/// </remarks>
public sealed record FossilFeature(
    StructureTemplateManager Templates,
    IReadOnlyList<Identifier> FossilStructures,
    IReadOnlyList<Identifier> OverlayStructures,
    IReadOnlyList<IStructureProcessor> FossilProcessors,
    IReadOnlyList<IStructureProcessor> OverlayProcessors,
    int MaxEmptyCornersAllowed) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        RandomSource random = context.Random;
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        BlockRotation rotation = (BlockRotation)random.NextInt(4);
        int index = random.NextInt(FossilStructures.Count);

        StructureTemplate fossil = Templates.Get(FossilStructures[index]);
        StructureTemplate overlay = Templates.Get(OverlayStructures[index]);

        // The writable area is the chunk and a ring of sixteen around it, so a fossil across a border
        // writes its far half. Those writes reach through the generation API's forks.
        int chunkX = origin.X >> 4;
        int chunkZ = origin.Z >> 4;

        BoundingBox area = new((chunkX << 4) - 16, level.MinY, (chunkZ << 4) - 16,
            (chunkX << 4) + 31, level.MaxY, (chunkZ << 4) + 31);

        StructurePlaceSettings settings = new() {
            Rotation = rotation,
            BoundingBox = area,
            Random = random
        };

        Vec3<int> size = fossil.SizeAfter(rotation);
        Vec3<int> lowCorner = new(origin.X - size.X / 2, origin.Y, origin.Z - size.Z / 2);

        int lowestSurface = origin.Y;

        for (int x = 0; x < size.X; x++) {
            for (int z = 0; z < size.Z; z++) {
                lowestSurface = Math.Min(lowestSurface, level.GetHeight(
                    HeightmapType.OceanFloorWorldgen, lowCorner.X + x, lowCorner.Z + z));
            }
        }

        int targetY = Math.Max(lowestSurface - 15 - random.NextInt(10), level.MinY + 10);

        Vec3<int> target = fossil.ZeroPositionWithTransform(
            new Vec3<int>(lowCorner.X, targetY, lowCorner.Z), BlockMirror.None, rotation);

        if (CountEmptyCorners(level, fossil.GetBoundingBox(settings, target))
            > MaxEmptyCornersAllowed) {

            return false;
        }

        settings.ClearProcessors().AddProcessors(FossilProcessors);
        fossil.PlaceInWorld(level, target, target, settings, random);

        settings.ClearProcessors().AddProcessors(OverlayProcessors);
        overlay.PlaceInWorld(level, target, target, settings, random);

        return true;
    }

    /// <summary>
    /// How many of the box's eight corners are open, which is how a fossil avoids a cave.
    /// </summary>
    private static int CountEmptyCorners(IFeatureLevel level, BoundingBox box) {
        int count = 0;

        foreach (int x in (int[])[box.MinX, box.MaxX]) {
            foreach (int y in (int[])[box.MinY, box.MaxY]) {
                foreach (int z in (int[])[box.MinZ, box.MaxZ]) {
                    uint state = level.GetState(x, y, z);
                    Identifier id = level.Registry.Blocks.GetByStateId(state).Identifier;

                    if (level.Blocks.IsAir(state) || id.Equals(Block.Lava.Identifier)
                        || id.Equals(Block.Water.Identifier)) {

                        count++;
                    }
                }
            }
        }

        return count;
    }
}

/// <summary>
/// <c>TemplateFeature</c>: one drawn template placed centred on the origin.
/// </summary>
/// <remarks>
/// No vanilla file uses this type; it exists for a datapack that wants to drop a saved build in as a
/// feature. It is transcribed anyway, because the alternative is a name on
/// <c>FeatureParser.NotTranscribed</c> that no longer needs anything.
/// <p/>
/// The offset is the template's half size sent the <b>negative</b> way along each axis and then
/// turned, which is what centres a rotated template on the position rather than hanging it off one
/// corner.
/// </remarks>
public sealed record TemplateFeature(
    StructureTemplateManager Templates,
    WeightedList<TemplateFeatureEntry> Entries) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        RandomSource random = context.Random;

        TemplateFeatureEntry entry = Entries.GetRandomOrThrow(random);
        BlockRotation rotation = entry.Rotations[random.NextInt(entry.Rotations.Count)];

        StructureTemplate template = Templates.Get(entry.Template);

        Vec3<int> offsetX = RotatedOffset(rotation, Axis.X, template);
        Vec3<int> offsetZ = RotatedOffset(rotation, Axis.Z, template);

        Vec3<int> pos = new(context.Origin.X + offsetX.X + offsetZ.X,
            context.Origin.Y + offsetX.Y + offsetZ.Y, context.Origin.Z + offsetX.Z + offsetZ.Z);

        StructurePlaceSettings settings = new() { Rotation = rotation, Random = random };

        return template.PlaceInWorld(context.Level, pos, pos, settings, random);
    }

    private static Vec3<int> RotatedOffset(BlockRotation rotation, Axis axis,
        StructureTemplate template) {

        (Vec3<int> negative, int size) = axis switch {
            Axis.X => (new Vec3<int>(-1, 0, 0), template.Size.X),
            Axis.Z => (new Vec3<int>(0, 0, -1), template.Size.Z),
            _ => (new Vec3<int>(0, -1, 0), template.Size.Y)
        };

        Vec3<int> turned = rotation switch {
            BlockRotation.Clockwise90 => new Vec3<int>(-negative.Z, negative.Y, negative.X),
            BlockRotation.Clockwise180 => new Vec3<int>(-negative.X, negative.Y, -negative.Z),
            BlockRotation.CounterClockwise90 => new Vec3<int>(negative.Z, negative.Y, -negative.X),
            _ => negative
        };

        int half = size / 2;
        return new Vec3<int>(turned.X * half, turned.Y * half, turned.Z * half);
    }
}

/// <summary>One template a <see cref="TemplateFeature"/> may draw, and the ways it may be turned.</summary>
public sealed record TemplateFeatureEntry(Identifier Template, IReadOnlyList<BlockRotation> Rotations);

/// <summary>
/// <c>DesertWellFeature</c>: the little sandstone well, which is drawn in code rather than saved.
/// </summary>
/// <remarks>
/// Placed here rather than with the other features because it is the desert's counterpart to the
/// fossil and reads the same way: sink to the ground, refuse if it is not sand, then build.
/// <p/>
/// The two suspicious sand blocks are placed and left empty, the same gap every container in this
/// build has.
/// </remarks>
public sealed record DesertWellFeature : ConfiguredFeature {
    public static readonly DesertWellFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = new(context.Origin.X, context.Origin.Y + 1, context.Origin.Z);

        while (level.IsEmptyBlock(origin.X, origin.Y, origin.Z) && origin.Y > level.MinY + 2) {
            origin = new Vec3<int>(origin.X, origin.Y - 1, origin.Z);
        }

        if (!level.Registry.Blocks.GetByStateId(level.GetState(origin.X, origin.Y, origin.Z))
            .Identifier.Equals(Block.Sand.Identifier)) {

            return false;
        }

        // Refuses over a two block hole anywhere under its footprint, which is what stops a well
        // hanging over a cave.
        for (int x = -2; x <= 2; x++) {
            for (int z = -2; z <= 2; z++) {
                if (level.IsEmptyBlock(origin.X + x, origin.Y - 1, origin.Z + z)
                    && level.IsEmptyBlock(origin.X + x, origin.Y - 2, origin.Z + z)) {

                    return false;
                }
            }
        }

        uint sandstone = Block.Sandstone.StateId;
        uint slab = Block.SandstoneSlab.StateId;
        uint water = Block.Water.StateId;
        uint sand = Block.Sand.StateId;

        for (int y = -2; y <= 0; y++) {
            for (int x = -2; x <= 2; x++) {
                for (int z = -2; z <= 2; z++) {
                    level.SetState(origin.X + x, origin.Y + y, origin.Z + z, sandstone);
                }
            }
        }

        level.SetState(origin.X, origin.Y, origin.Z, water);

        foreach ((int dx, int dz) in Horizontals) {
            level.SetState(origin.X + dx, origin.Y, origin.Z + dz, water);
        }

        level.SetState(origin.X, origin.Y - 1, origin.Z, sand);

        foreach ((int dx, int dz) in Horizontals) {
            level.SetState(origin.X + dx, origin.Y - 1, origin.Z + dz, sand);
        }

        for (int x = -2; x <= 2; x++) {
            for (int z = -2; z <= 2; z++) {
                if (x is -2 or 2 || z is -2 or 2) {
                    level.SetState(origin.X + x, origin.Y + 1, origin.Z + z, sandstone);
                }
            }
        }

        level.SetState(origin.X + 2, origin.Y + 1, origin.Z, slab);
        level.SetState(origin.X - 2, origin.Y + 1, origin.Z, slab);
        level.SetState(origin.X, origin.Y + 1, origin.Z + 2, slab);
        level.SetState(origin.X, origin.Y + 1, origin.Z - 2, slab);

        for (int x = -1; x <= 1; x++) {
            for (int z = -1; z <= 1; z++) {
                level.SetState(origin.X + x, origin.Y + 4, origin.Z + z,
                    x == 0 && z == 0 ? sandstone : slab);
            }
        }

        for (int y = 1; y <= 3; y++) {
            level.SetState(origin.X - 1, origin.Y + y, origin.Z - 1, sandstone);
            level.SetState(origin.X - 1, origin.Y + y, origin.Z + 1, sandstone);
            level.SetState(origin.X + 1, origin.Y + y, origin.Z - 1, sandstone);
            level.SetState(origin.X + 1, origin.Y + y, origin.Z + 1, sandstone);
        }

        // The order is the well's own centre then east, south, west, north, which is what the two
        // draws index into.
        Vec3<int>[] waterPositions = [
            origin,
            new Vec3<int>(origin.X + 1, origin.Y, origin.Z),
            new Vec3<int>(origin.X, origin.Y, origin.Z + 1),
            new Vec3<int>(origin.X - 1, origin.Y, origin.Z),
            new Vec3<int>(origin.X, origin.Y, origin.Z - 1)
        ];

        PlaceSuspiciousSand(level, waterPositions[context.Random.NextInt(waterPositions.Length)], 1);
        PlaceSuspiciousSand(level, waterPositions[context.Random.NextInt(waterPositions.Length)], 2);

        return true;
    }

    private static void PlaceSuspiciousSand(IFeatureLevel level, Vec3<int> pos, int below) {
        level.SetState(pos.X, pos.Y - below, pos.Z, Block.SuspiciousSand.StateId);
    }

    /// <summary>The four horizontal offsets, in <c>Plane.HORIZONTAL</c>'s order.</summary>
    private static readonly (int Dx, int Dz)[] Horizontals = [(0, -1), (1, 0), (0, 1), (-1, 0)];
}
