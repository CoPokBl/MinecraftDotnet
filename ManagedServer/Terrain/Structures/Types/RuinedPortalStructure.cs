using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Features.Types;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Data.Biomes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>Where in the terrain a ruined portal setup puts its portal.</summary>
public enum RuinedPortalPlacement {
    OnLandSurface,
    PartlyBuried,
    OnOceanFloor,
    InMountain,
    Underground,
    InNether
}

/// <summary>One weighted alternative of a ruined portal structure file.</summary>
public sealed record RuinedPortalSetup(
    RuinedPortalPlacement Placement,
    float AirPocketProbability,
    float Mossiness,
    bool Overgrown,
    bool Vines,
    bool CanBeCold,
    bool ReplaceWithBlackstone,
    float Weight);

/// <summary>What a particular portal turned out to be, once its setup has been rolled for.</summary>
public sealed record RuinedPortalProperties(
    bool Cold,
    float Mossiness,
    bool AirPocket,
    bool Overgrown,
    bool Vines,
    bool ReplaceWithBlackstone);

/// <summary>
/// <c>RuinedPortalStructure</c>: a broken portal frame, buried at a depth its setup decides.
/// </summary>
/// <remarks>
/// The most processor driven structure there is: one of thirteen templates goes through a rule
/// processor that strips gold and turns lava, an age processor that mosses it, a protection processor
/// and a lava processor, with a blackstone swap on top in the nether. Almost nothing about how a
/// portal looks is in its template.
/// </remarks>
public sealed class RuinedPortalStructure(Structure.StructureSettings settings,
    StructureTemplateManager templates, IReadOnlyList<RuinedPortalSetup> setups) : Structure(settings) {

    private const float GiantPortalProbability = 0.05f;

    /// <summary>How far above the world's bottom a portal may be put.</summary>
    private const int MinYIndex = 15;

    private static readonly Identifier[] Portals = Enumerable.Range(1, 10)
        .Select(i => (Identifier)$"minecraft:ruined_portal/portal_{i}").ToArray();

    private static readonly Identifier[] GiantPortals = Enumerable.Range(1, 3)
        .Select(i => (Identifier)$"minecraft:ruined_portal/giant_portal_{i}").ToArray();

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        WorldgenRandom random = context.Random;
        RuinedPortalSetup setup = ChooseSetup(random);

        bool airPocket = Sample(random, setup.AirPocketProbability);

        Identifier templateLocation = random.NextFloat() < GiantPortalProbability
            ? GiantPortals[random.NextInt(GiantPortals.Length)]
            : Portals[random.NextInt(Portals.Length)];

        StructureTemplate template = templates.Get(templateLocation);

        BlockRotation rotation = (BlockRotation)random.NextInt(4);
        BlockMirror mirror = random.NextFloat() < 0.5f ? BlockMirror.None : BlockMirror.FrontBack;

        Vec3<int> pivot = new(template.Size.X / 2, 0, template.Size.Z / 2);
        Vec3<int> basePosition = new(context.ChunkX << 4, 0, context.ChunkZ << 4);

        BoundingBox box = StructureTemplate.GetBoundingBox(basePosition, rotation, pivot, mirror,
            template.Size);

        Vec3<int> centre = box.Center;

        int surfaceY = context.Heights(centre.X, centre.Z, HeightmapFor(setup.Placement)) - 1;

        int y = FindSuitableY(context, random, setup.Placement, airPocket, surfaceY, box.YSpan, box);

        Vec3<int> origin = new(basePosition.X, y, basePosition.Z);

        return new GenerationStub(origin, builder => {
            IBiome biome = context.Registry.Biomes[
                context.Biomes(origin.X >> 2, origin.Y >> 2, origin.Z >> 2)];

            RuinedPortalProperties properties = new(
                setup.CanBeCold && BiomeClimate.ColdEnoughToSnow(biome, origin.X, origin.Y, origin.Z,
                    context.SeaLevel),
                setup.Mossiness,
                airPocket,
                setup.Overgrown,
                setup.Vines,
                setup.ReplaceWithBlackstone);

            builder.AddPiece(new RuinedPortalPiece(templates, origin, setup.Placement, properties,
                templateLocation, rotation, mirror, pivot));
        });
    }

    /// <summary>
    /// The weighted draw between a file's setups.
    /// </summary>
    /// <remarks>
    /// A file with one setup <b>takes no draw at all</b>, which is what keeps the desert portal's
    /// sequence different from the standard one's despite them sharing everything after this.
    /// </remarks>
    private RuinedPortalSetup ChooseSetup(WorldgenRandom random) {
        if (setups.Count <= 1) {
            return setups[0];
        }

        float total = setups.Sum(setup => setup.Weight);
        float pick = random.NextFloat();

        foreach (RuinedPortalSetup setup in setups) {
            pick -= setup.Weight / total;

            if (pick < 0.0f) {
                return setup;
            }
        }

        throw new InvalidOperationException("A ruined portal's setup weights did not sum to one.");
    }

    /// <summary>
    /// A roll that <b>does not draw</b> at either extreme, which keeps the sequence the same for a
    /// setup whose probability is zero or one.
    /// </summary>
    private static bool Sample(WorldgenRandom random, float limit) {
        if (limit == 0.0f) {
            return false;
        }

        return limit == 1.0f || random.NextFloat() < limit;
    }

    /// <summary>
    /// Where the portal sits: a drawn height for the placement, then lowered until three of its four
    /// bottom corners are in solid ground.
    /// </summary>
    /// <remarks>
    /// Three of four rather than all four, which is what lets a portal hang off the edge of a cliff.
    /// The corner columns are terrain columns rather than heightmaps, because the test is whether the
    /// ground is solid <b>at that y</b> and not how high it reaches.
    /// </remarks>
    private static int FindSuitableY(StructureGenerationContext context, RandomSource random,
        RuinedPortalPlacement placement, bool airPocket, int surfaceYAtCentre, int ySpan,
        BoundingBox box) {

        int minY = context.MinY + MinYIndex;

        int start = placement switch {
            RuinedPortalPlacement.InNether when airPocket =>
                random.NextIntBetweenInclusive(32, 100),

            RuinedPortalPlacement.InNether => random.NextFloat() < 0.5f
                ? random.NextIntBetweenInclusive(27, 29)
                : random.NextIntBetweenInclusive(29, 100),

            RuinedPortalPlacement.InMountain =>
                WithinInterval(random, 70, surfaceYAtCentre - ySpan),

            RuinedPortalPlacement.Underground =>
                WithinInterval(random, minY, surfaceYAtCentre - ySpan),

            RuinedPortalPlacement.PartlyBuried =>
                surfaceYAtCentre - ySpan + random.NextIntBetweenInclusive(2, 8),

            _ => surfaceYAtCentre
        };

        uint[][] corners = [
            context.Columns(box.MinX, box.MinZ),
            context.Columns(box.MaxX, box.MinZ),
            context.Columns(box.MinX, box.MaxZ),
            context.Columns(box.MaxX, box.MaxZ)
        ];

        bool oceanFloor = placement == RuinedPortalPlacement.OnOceanFloor;

        int y;

        for (y = start; y > minY; y--) {
            int solidCorners = 0;

            foreach (uint[] column in corners) {
                int index = y - context.MinY;
                uint state = index >= 0 && index < column.Length ? column[index] : Block.Air.StateId;

                if (!IsOpaque(context, state, oceanFloor)) {
                    continue;
                }

                if (++solidCorners == 3) {
                    return y;
                }
            }
        }

        return y;
    }

    private static bool IsOpaque(StructureGenerationContext context, uint stateId, bool oceanFloor) {
        IBlock block = context.Registry.Blocks.GetByStateId(stateId);
        return oceanFloor ? block.BlocksMotion : !block.Air;
    }

    private static int WithinInterval(RandomSource random, int preferredMin, int max) {
        return preferredMin < max ? random.NextIntBetweenInclusive(preferredMin, max) : max;
    }

    internal static HeightmapType HeightmapFor(RuinedPortalPlacement placement) {
        return placement == RuinedPortalPlacement.OnOceanFloor
            ? HeightmapType.OceanFloorWorldgen
            : HeightmapType.WorldSurfaceWorldgen;
    }
}
