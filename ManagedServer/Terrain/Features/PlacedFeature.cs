using ManagedServer.Terrain.Features.Placement;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Biomes;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features;

/// <summary>Whether a biome's feature list holds a placed feature, which is what the biome filter asks.</summary>
public delegate bool BiomeHasFeature(IBiome biome, PlacedFeature feature);

/// <summary>
/// <c>PlacementContext</c>: what a placement modifier can see.
/// </summary>
/// <remarks>
/// <see cref="TopFeature"/> is null for a feature placed by another feature rather than off a biome's
/// list. That is not an omission: vanilla's <c>place</c> and <c>placeWithBiomeCheck</c> differ in
/// exactly this, and a nested feature carrying a biome filter is a datapack error rather than
/// something to answer.
/// </remarks>
public sealed record PlacementContext(IFeatureLevel Level, GenerationHeightContext Heights,
    BiomeHasFeature HasFeature, PlacedFeature? TopFeature) {

    public bool BiomeHasFeature(IBiome biome, PlacedFeature feature) => HasFeature(biome, feature);

    /// <summary>The same context with no biome check, for a feature placing another feature.</summary>
    public PlacementContext Nested() => this with { TopFeature = null };
}

/// <summary>What a feature is handed when it is asked to place itself.</summary>
public sealed record FeaturePlaceContext(PlacementContext Placement, RandomSource Random, Vec3<int> Origin) {
    public IFeatureLevel Level => Placement.Level;

    public FeaturePlaceContext At(Vec3<int> origin) => this with { Origin = origin };
}

/// <summary>
/// <c>ConfiguredFeature</c>: a feature type together with the configuration a datapack gave it.
/// </summary>
/// <remarks>
/// Vanilla splits this into a <c>Feature&lt;FC&gt;</c> singleton and an <c>FC</c> record. Folded into
/// one type here, because the split only exists upstream to give the codec something to dispatch on
/// and it costs a generic parameter on every call site.
/// </remarks>
public abstract record ConfiguredFeature {
    /// <summary>
    /// Vanilla's <c>Feature.place</c>. The return says whether anything was placed, which the
    /// selectors and <c>sequence</c> read.
    /// </summary>
    public abstract bool Place(FeaturePlaceContext context);
}

/// <summary>
/// <c>PlacedFeature</c>: a configured feature and the chain of modifiers that decides where it goes.
/// </summary>
/// <remarks>
/// The walk is depth first, and that is load bearing rather than an implementation detail. Vanilla
/// chains lazy streams, so the whole tail of the chain runs for a modifier's first position before
/// its second is produced, and every modifier and the feature itself draw from one random. Running
/// the modifiers breadth first would consume the same numbers in a different order and generate a
/// different, still plausible looking, world.
/// </remarks>
public sealed class PlacedFeature(ConfiguredFeature feature, IReadOnlyList<PlacementModifier> placement,
    Identifier? id = null) {

    public ConfiguredFeature Feature => feature;

    public IReadOnlyList<PlacementModifier> Placement => placement;

    /// <summary>
    /// What the datapack called it, or null for one written inline inside another feature.
    /// </summary>
    /// <remarks>
    /// Nothing generating reads this: two features are told apart by reference, since an inline one has
    /// no name to be told apart by. It is what a report names, and what the global order is compared
    /// against vanilla's by.
    /// </remarks>
    public Identifier? Id => id;

    /// <summary><c>placeWithBiomeCheck</c>, which is how a biome's own list is placed.</summary>
    public bool PlaceWithBiomeCheck(PlacementContext context, RandomSource random, Vec3<int> origin) {
        return Place(context with { TopFeature = this }, random, origin);
    }

    /// <summary><c>place</c>: no biome check, which is how a feature places another feature.</summary>
    public bool Place(PlacementContext context, RandomSource random, Vec3<int> origin) {
        return Descend(context, random, origin, 0);
    }

    private bool Descend(PlacementContext context, RandomSource random, Vec3<int> pos, int modifier) {
        if (modifier == placement.Count) {
            if (!FeatureLevelDump.Tracing) {
                return feature.Place(new FeaturePlaceContext(context, random, pos));
            }

            // The same table the decoration parity harness prints under PARITY_TRACE, so the two are
            // diffed rather than read. Only the line before the first difference means anything: the
            // whole feature draws from one random, so everything after it is a different sequence.
            int before = random is WorldgenRandom worldgen ? worldgen.Count : 0;
            bool placed = feature.Place(new FeaturePlaceContext(context, random, pos));
            int after = random is WorldgenRandom done ? done.Count : 0;

            Console.Error.WriteLine($"CAND {pos.X,4} {pos.Y,4} {pos.Z,4}  placed={placed,-5} "
                + $"draws={after - before}");

            return placed;
        }

        bool placedAny = false;
        foreach (Vec3<int> next in placement[modifier].GetPositions(context, random, pos)) {
            if (FeatureLevelDump.Tracing) {
                uint at = context.Level.GetState(next.X, next.Y, next.Z);

                Console.Error.WriteLine($"STAGE {placement[modifier].GetType().Name} "
                    + $"{next.X} {next.Y} {next.Z} "
                    + context.Level.Registry.Blocks.GetByStateId(at).Identifier + " "
                    + context.Level.GetBiome(next.X, next.Y, next.Z).Identifier);
            }

            placedAny |= Descend(context, random, next, modifier + 1);
        }

        return placedAny;
    }
}
