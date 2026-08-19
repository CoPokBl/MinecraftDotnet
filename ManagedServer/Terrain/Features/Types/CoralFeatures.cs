using ManagedServer.Placement;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>CoralFeature</c>: the block placement and the trimmings the three coral shapes share.
/// </summary>
/// <remarks>
/// The colour is drawn <b>once</b> for the whole structure, so a coral formation is one colour with
/// fans and pickles of other colours hanging off it rather than a mixture throughout.
/// <p/>
/// Every one of the three stops growing at the first block it cannot place, which is what makes coral
/// hug the sea floor instead of growing out over open water.
/// </remarks>
public abstract record CoralFeature : ConfiguredFeature {
    private static readonly Identifier CoralBlocks = "minecraft:coral_blocks";
    private static readonly Identifier Corals = "minecraft:corals";
    private static readonly Identifier WallCorals = "minecraft:wall_corals";

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;

        if (RandomOf(level, CoralBlocks, random) is not { } coral) {
            return false;
        }

        return PlaceFeature(level, random, context.Origin, coral);
    }

    protected abstract bool PlaceFeature(IFeatureLevel level, RandomSource random, Vec3<int> origin,
        IBlock state);

    /// <summary>
    /// One block of coral, and what grows on it: a fan or a sea pickle on top, and wall fans on the
    /// sides.
    /// </summary>
    /// <remarks>
    /// The two rolls for the top are an <b>else if</b>, so the sea pickle only gets its 5% of the 75%
    /// the coral fan did not take. The four side rolls happen whatever the top did.
    /// </remarks>
    protected bool PlaceCoralBlock(IFeatureLevel level, RandomSource random, Vec3<int> pos, IBlock state) {
        uint here = level.GetState(pos.X, pos.Y, pos.Z);
        IBlock hereBlock = level.Registry.Blocks.GetByStateId(here);

        bool replaceable = hereBlock.Identifier.Equals(Block.Water.Identifier)
            || level.Blocks.IsIn(Corals, here);

        if (!replaceable || !IsWater(level, pos.X, pos.Y + 1, pos.Z)) {
            return false;
        }

        level.SetState(pos.X, pos.Y, pos.Z, state.StateId);

        if (random.NextFloat() < 0.25f) {
            if (RandomOf(level, Corals, random) is { } fan) {
                level.SetState(pos.X, pos.Y + 1, pos.Z, fan.StateId);
            }
        } else if (random.NextFloat() < 0.05f) {
            IBlock pickle = Block.SeaPickle;
            if (pickle is IStackable stackable) {
                pickle = stackable.WithCount(random.NextInt(4) + 1);
            }

            level.SetState(pos.X, pos.Y + 1, pos.Z, pickle.StateId);
        }

        foreach (BlockFace face in Directions.Horizontal) {
            if (!(random.NextFloat() < 0.2f)) {
                continue;
            }

            Vec3<int> beside = pos + Placement.PlacementParser.Step(face);

            if (!IsWater(level, beside.X, beside.Y, beside.Z)) {
                continue;
            }

            if (RandomOf(level, WallCorals, random) is not { } wallFan) {
                continue;
            }

            if (wallFan is IHorizontalFacing facing) {
                wallFan = facing.WithFacing(face.ToDirection());
            }

            level.SetState(beside.X, beside.Y, beside.Z, wallFan.StateId);
        }

        return true;
    }

    /// <summary>
    /// <c>HolderSet.getRandomElement</c>: one member of a tag by index.
    /// </summary>
    /// <remarks>
    /// The index is into the tag's <b>resolved order</b>, which is the order the tag file lists its
    /// entries with nested tags expanded in place. Reordering the tag data therefore changes which
    /// coral a seed grows, the same way it does upstream.
    /// </remarks>
    private static IBlock? RandomOf(IFeatureLevel level, Identifier tag, RandomSource random) {
        if (!level.Registry.Blocks.Tags.Contains(tag)) {
            return null;
        }

        Identifier[] members = level.Registry.Blocks.Tags[tag].GetValueIds(level.Registry);

        return members.Length == 0 ? null : level.Registry.Blocks[members[random.NextInt(members.Length)]];
    }

    protected static bool IsWater(IFeatureLevel level, int x, int y, int z) {
        return level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier
            .Equals(Block.Water.Identifier);
    }
}

/// <summary>
/// <c>CoralTreeFeature</c>: a short trunk with two to four branches leaning off the top of it.
/// </summary>
/// <remarks>
/// A branch steps sideways on its first block and then again at one in four, which is what gives the
/// branches their outward lean rather than growing straight up.
/// </remarks>
public sealed record CoralTreeFeature : CoralFeature {
    public static readonly CoralTreeFeature Instance = new();

    protected override bool PlaceFeature(IFeatureLevel level, RandomSource random, Vec3<int> origin,
        IBlock state) {

        Vec3<int> cursor = origin;
        int trunkHeight = random.NextInt(3) + 1;

        for (int grown = 0; grown < trunkHeight; grown++) {
            if (!PlaceCoralBlock(level, random, cursor, state)) {
                return true;
            }

            cursor = cursor.WithY(cursor.Y + 1);
        }

        Vec3<int> top = cursor;
        int branches = random.NextInt(3) + 2;
        List<BlockFace> order = FeatureUtil.Shuffled(Directions.Horizontal, random);

        foreach (BlockFace direction in order.Take(branches)) {
            Vec3<int> branch = top + Placement.PlacementParser.Step(direction);
            int height = random.NextInt(5) + 2;
            int sinceStep = 0;

            for (int grown = 0; grown < height
                && PlaceCoralBlock(level, random, branch, state); grown++) {

                sinceStep++;
                branch = branch.WithY(branch.Y + 1);

                if (grown == 0 || (sinceStep >= 2 && random.NextFloat() < 0.25f)) {
                    branch += Placement.PlacementParser.Step(direction);
                    sinceStep = 0;
                }
            }
        }

        return true;
    }
}

/// <summary>
/// <c>CoralClawFeature</c>: two or three arms curling out from one block and back inwards.
/// </summary>
/// <remarks>
/// The arms are picked from the claw's own direction and its two sides, so a claw always opens one
/// way. The arm on the claw's own direction runs level while the two side arms start a block higher
/// and may climb, which is what makes a claw asymmetric.
/// </remarks>
public sealed record CoralClawFeature : CoralFeature {
    public static readonly CoralClawFeature Instance = new();

    protected override bool PlaceFeature(IFeatureLevel level, RandomSource random, Vec3<int> origin,
        IBlock state) {

        if (!PlaceCoralBlock(level, random, origin, state)) {
            return false;
        }

        BlockFace claw = Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)];
        int arms = random.NextInt(2) + 2;

        List<BlockFace> candidates = FeatureUtil.Shuffled(
            [claw, Clockwise(claw), CounterClockwise(claw)], random);

        foreach (BlockFace direction in candidates.Take(arms)) {
            Vec3<int> cursor = origin + Placement.PlacementParser.Step(direction);

            int outward = random.NextInt(2) + 1;
            int inward;
            BlockFace segment;

            if (direction == claw) {
                segment = claw;
                inward = random.NextInt(3) + 2;
            } else {
                cursor = cursor.WithY(cursor.Y + 1);
                BlockFace[] choices = [direction, BlockFace.PosY];
                segment = choices[random.NextInt(choices.Length)];
                inward = random.NextInt(3) + 3;
            }

            for (int grown = 0; grown < outward
                && PlaceCoralBlock(level, random, cursor, state); grown++) {

                cursor += Placement.PlacementParser.Step(segment);
            }

            cursor += Placement.PlacementParser.Step(segment.Opposite());
            cursor = cursor.WithY(cursor.Y + 1);

            for (int grown = 0; grown < inward; grown++) {
                cursor += Placement.PlacementParser.Step(claw);

                if (!PlaceCoralBlock(level, random, cursor, state)) {
                    break;
                }

                if (random.NextFloat() < 0.25f) {
                    cursor = cursor.WithY(cursor.Y + 1);
                }
            }
        }

        return true;
    }

    private static BlockFace Clockwise(BlockFace face) {
        return face.ToDirection().ClockWise().ToFace();
    }

    private static BlockFace CounterClockwise(BlockFace face) {
        return face.ToDirection().CounterClockWise().ToFace();
    }
}

/// <summary>
/// <c>CoralMushroomFeature</c>: a hollow box of coral sunk partway into the floor.
/// </summary>
/// <remarks>
/// The four conditions before the placement carve the shape: the first three drop the box's twelve
/// edges, the fourth keeps only its faces, and a one in ten roll punches holes in what is left. Both
/// the roll and the placement are inside one short circuiting chain, so a position that fails an
/// earlier test costs no random at all.
/// </remarks>
public sealed record CoralMushroomFeature : CoralFeature {
    public static readonly CoralMushroomFeature Instance = new();

    protected override bool PlaceFeature(IFeatureLevel level, RandomSource random, Vec3<int> origin,
        IBlock state) {

        int height = random.NextInt(3) + 3;
        int width = random.NextInt(3) + 3;
        int length = random.NextInt(3) + 3;
        int sink = random.NextInt(3) + 1;

        for (int x = 0; x <= width; x++) {
            for (int y = 0; y <= height; y++) {
                for (int z = 0; z <= length; z++) {
                    bool xEdge = x == 0 || x == width;
                    bool yEdge = y == 0 || y == height;
                    bool zEdge = z == 0 || z == length;

                    if ((xEdge && yEdge) || (zEdge && yEdge) || (xEdge && zEdge)) {
                        continue;
                    }

                    if (!xEdge && !yEdge && !zEdge) {
                        continue;
                    }

                    if (random.NextFloat() < 0.1f) {
                        continue;
                    }

                    PlaceCoralBlock(level, random,
                        new Vec3<int>(origin.X + x, origin.Y + y - sink, origin.Z + z), state);
                }
            }
        }

        return true;
    }
}
