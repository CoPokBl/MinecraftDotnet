using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>HugeFungusFeature</c>: a crimson or warped fungus grown to full size.
/// </summary>
/// <remarks>
/// The hat is three bands and each is written by a different rule. The bottom three layers are the
/// <b>drop</b>, which only continues downwards where the block above it is already hat, so the hat
/// hangs in strands rather than being a flat underside. Above that the interior, the corners and the
/// edges each get their own pair of probabilities, and the corners are the sparsest by an order of
/// magnitude, which is what rounds the hat off.
/// <p/>
/// <b>Planted is always false here.</b> It is the flag for a fungus grown from bone meal, which
/// destroys what it grows through and skips the height limit; a generated one does neither. The branch
/// is kept so the difference is visible rather than assumed.
/// </remarks>
public sealed record HugeFungusFeature(uint ValidBaseState, uint StemState, uint HatState,
    uint DecorState, BlockPredicate ReplaceableBlocks, bool Planted) : ConfiguredFeature {

    /// <summary>How often a wild fungus comes out with the wider stem and hat.</summary>
    private const float HugeProbability = 0.06f;

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;

        Identifier baseBlock = level.Registry.Blocks.GetByStateId(ValidBaseState).Identifier;
        Identifier below = level.Registry.Blocks
            .GetByStateId(level.GetState(origin.X, origin.Y - 1, origin.Z)).Identifier;

        if (!below.Equals(baseBlock)) {
            return false;
        }

        int height = Mth.NextInt(random, 4, 13);

        if (random.NextInt(12) == 0) {
            height *= 2;
        }

        if (!Planted && origin.Y + height + 1 >= level.MaxY) {
            return false;
        }

        bool huge = !Planted && random.NextFloat() < HugeProbability;

        level.SetState(origin.X, origin.Y, origin.Z, Block.Air.StateId);

        PlaceStem(level, random, origin, height, huge);
        PlaceHat(level, random, origin, height, huge);

        return true;
    }

    /// <summary>
    /// Either a single column or a two by two thickened to three by three, where the four corners are
    /// only filled one time in ten so the stem looks gnarled rather than square.
    /// </summary>
    private void PlaceStem(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height,
        bool huge) {

        int radius = huge ? 1 : 0;

        for (int dx = -radius; dx <= radius; dx++) {
            for (int dz = -radius; dz <= radius; dz++) {
                bool corner = huge && Math.Abs(dx) == radius && Math.Abs(dz) == radius;

                for (int dy = 0; dy < height; dy++) {
                    int x = origin.X + dx;
                    int y = origin.Y + dy;
                    int z = origin.Z + dz;

                    if (!IsReplaceable(level, x, y, z, true)) {
                        continue;
                    }

                    if (corner) {
                        if (random.NextFloat() < 0.1f) {
                            level.SetState(x, y, z, StemState);
                        }

                        continue;
                    }

                    level.SetState(x, y, z, StemState);
                }
            }
        }
    }

    private void PlaceHat(IFeatureLevel level, RandomSource random, Vec3<int> origin, int height,
        bool huge) {

        bool placeVines = HatState == Block.NetherWartBlock.StateId;

        int hatHeight = Math.Min(random.NextInt(1 + height / 3) + 5, height);
        int hatStart = height - hatHeight;

        for (int dy = hatStart; dy <= height; dy++) {
            // Drawn every layer whether it is used or not, so the sequence does not depend on the
            // hat's height.
            int radius = dy < height - random.NextInt(3) ? 2 : 1;

            if (hatHeight > 8 && dy < hatStart + 4) {
                radius = 3;
            }

            if (huge) {
                radius++;
            }

            for (int dx = -radius; dx <= radius; dx++) {
                for (int dz = -radius; dz <= radius; dz++) {
                    bool edgeX = dx == -radius || dx == radius;
                    bool edgeZ = dz == -radius || dz == radius;
                    bool inside = !edgeX && !edgeZ && dy != height;
                    bool corner = edgeX && edgeZ;
                    bool bottom = dy < hatStart + 3;

                    int x = origin.X + dx;
                    int y = origin.Y + dy;
                    int z = origin.Z + dz;

                    if (!IsReplaceable(level, x, y, z, false)) {
                        continue;
                    }

                    if (bottom) {
                        if (!inside) {
                            PlaceHatDropBlock(level, random, x, y, z, placeVines);
                        }
                    } else if (inside) {
                        PlaceHatBlock(level, random, x, y, z, 0.1f, 0.2f, placeVines ? 0.1f : 0.0f);
                    } else if (corner) {
                        PlaceHatBlock(level, random, x, y, z, 0.01f, 0.7f, placeVines ? 0.083f : 0.0f);
                    } else {
                        PlaceHatBlock(level, random, x, y, z, 5.0E-4f, 0.98f, placeVines ? 0.07f : 0.0f);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Shroomlight first and hat second, as an else branch, so the decoration is taken out of the hat's
    /// share rather than added on top of it.
    /// </summary>
    private void PlaceHatBlock(IFeatureLevel level, RandomSource random, int x, int y, int z,
        float decorChance, float hatChance, float vineChance) {

        if (random.NextFloat() < decorChance) {
            level.SetState(x, y, z, DecorState);
            return;
        }

        if (!(random.NextFloat() < hatChance)) {
            return;
        }

        level.SetState(x, y, z, HatState);

        if (random.NextFloat() < vineChance) {
            TryPlaceWeepingVines(level, random, x, y, z);
        }
    }

    /// <summary>
    /// The underside: free where there is already hat above, and otherwise a rare start of a new
    /// strand. That asymmetry is what makes the drops hang in connected runs.
    /// </summary>
    private void PlaceHatDropBlock(IFeatureLevel level, RandomSource random, int x, int y, int z,
        bool placeVines) {

        if (level.GetState(x, y - 1, z) == HatState) {
            level.SetState(x, y, z, HatState);
            return;
        }

        if (!(random.NextFloat() < 0.15)) {
            return;
        }

        level.SetState(x, y, z, HatState);

        if (placeVines && random.NextInt(11) == 0) {
            TryPlaceWeepingVines(level, random, x, y, z);
        }
    }

    private static void TryPlaceWeepingVines(IFeatureLevel level, RandomSource random, int x, int y,
        int z) {

        if (!level.IsEmptyBlock(x, y - 1, z)) {
            return;
        }

        int height = Mth.NextInt(random, 1, 5);

        if (random.NextInt(7) == 0) {
            height *= 2;
        }

        // Aged 23 to 25 rather than the 17 to 25 a wild vine gets, so one hanging off a fungus is
        // nearly done growing.
        WeepingVinesFeature.PlaceColumn(level, random, x, y - 1, z, height, 23, 25);
    }

    /// <summary>
    /// Anything the block itself calls replaceable, plus the configured predicate for the stem, which
    /// is what lets it grow up through the plants on a nylium floor.
    /// </summary>
    private bool IsReplaceable(IFeatureLevel level, int x, int y, int z, bool checkPlants) {
        if (level.Blocks.IsReplaceable(level.GetState(x, y, z))) {
            return true;
        }

        return checkPlants && ReplaceableBlocks.Test(level, x, y, z);
    }
}
