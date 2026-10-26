using ManagedServer.Terrain.Features.Blocks;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>WeightedRandomSelectorFeature</c>: one of a weighted list, or nothing.
/// </summary>
/// <remarks>
/// Unlike <c>random_selector</c> there is no fallback: an empty draw places nothing and reports
/// failure, which is what lets a list of low weights leave most positions bare.
/// </remarks>
public sealed record WeightedRandomSelectorFeature(
    IReadOnlyList<(PlacedFeature Feature, int Weight)> Features) : ConfiguredFeature {

    public override bool Place(FeaturePlaceContext context) {
        int total = Features.Sum(entry => entry.Weight);
        if (total <= 0) {
            return false;
        }

        int roll = context.Random.NextInt(total);

        foreach ((PlacedFeature feature, int weight) in Features) {
            roll -= weight;
            if (roll < 0) {
                return feature.Place(context.Placement.Nested(), context.Random, context.Origin);
            }
        }

        return false;
    }
}
