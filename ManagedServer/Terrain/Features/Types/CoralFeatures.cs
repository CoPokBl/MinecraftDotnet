using ManagedServer.Terrain.Features.Values;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>CoralTreeFeature</c>: a short trunk with two to four branches leaning off the top of it, each
/// block of it the nested feature.
/// </summary>
/// <remarks>
/// The colour, the fans and the pickles are all the nested feature's, and so is the decision whether a
/// position takes coral at all: a branch stops at the first position where it reports nothing placed.
/// A branch steps sideways on its first block and then again at one in four, which is what gives the
/// branches their outward lean rather than growing straight up.
/// </remarks>
public sealed record CoralTreeFeature(PlacedFeature Feature) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        PlacementContext nested = context.Placement.Nested();
        RandomSource random = context.Random;

        Vec3<int> cursor = context.Origin;
        int trunkHeight = random.NextInt(3) + 1;

        for (int grown = 0; grown < trunkHeight; grown++) {
            if (!Feature.Place(nested, random, cursor)) {
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

            for (int grown = 0; grown < height && Feature.Place(nested, random, branch); grown++) {
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
/// <c>CoralClawFeature</c>: two or three arms curling out from one block and back inwards, each block
/// of it the nested feature.
/// </summary>
/// <remarks>
/// The arms are picked from the claw's own direction and its two sides, so a claw always opens one
/// way. The arm on the claw's own direction runs level while the two side arms start a block higher
/// and may climb, which is what makes a claw asymmetric.
/// </remarks>
public sealed record CoralClawFeature(PlacedFeature Feature) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        PlacementContext nested = context.Placement.Nested();
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        if (!Feature.Place(nested, random, origin)) {
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

            for (int grown = 0; grown < outward && Feature.Place(nested, random, cursor); grown++) {
                cursor += Placement.PlacementParser.Step(segment);
            }

            cursor += Placement.PlacementParser.Step(segment.Opposite());
            cursor = cursor.WithY(cursor.Y + 1);

            for (int grown = 0; grown < inward; grown++) {
                cursor += Placement.PlacementParser.Step(claw);

                if (!Feature.Place(nested, random, cursor)) {
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
