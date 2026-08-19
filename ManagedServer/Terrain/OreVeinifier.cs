using ManagedServer.Terrain.Density;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace ManagedServer.Terrain;

/// <summary>
/// Decides the state at a position once the terrain density is known, vanilla's
/// <c>NoiseChunk.BlockStateFiller</c>. Null means "leave it to the next filler".
/// </summary>
public interface IBlockStateFiller {
    uint? Calculate(IFunctionContext context);
}

/// <summary>
/// The large copper and iron veins, vanilla's <c>OreVeinifier</c>.
/// </summary>
/// <remarks>
/// Not a feature and not a decoration: veins are part of the terrain pass, and they overwrite stone
/// that has already been decided rather than being placed into it afterwards. Which of the two vein
/// types a position belongs to is the <b>sign</b> of the toggle noise, and how far the position is
/// from that type's height band decides whether it is in one at all.
/// <p/>
/// Most of a vein is filler rock rather than ore, which is what makes finding one look like a band of
/// granite or tuff with ore scattered through it.
/// </remarks>
public sealed class OreVeinifier : IBlockStateFiller {
    private const float VeininessThreshold = 0.4f;
    private const int EdgeRoundoffBegin = 20;
    private const double MaxEdgeRoundoff = 0.2;
    private const float VeinSolidness = 0.7f;
    private const float MinRichness = 0.1f;
    private const float MaxRichness = 0.3f;
    private const float MaxRichnessThreshold = 0.6f;
    private const float ChanceOfRawOreBlock = 0.02f;
    private const float SkipOreIfGapNoiseIsBelow = -0.3f;

    private readonly IDensityFunction _veinToggle;
    private readonly IDensityFunction _veinRidged;
    private readonly IDensityFunction _veinGap;
    private readonly IPositionalRandomFactory _random;

    private readonly VeinType _copper;
    private readonly VeinType _iron;

    public OreVeinifier(IDensityFunction veinToggle, IDensityFunction veinRidged, IDensityFunction veinGap,
        IPositionalRandomFactory random) {

        _veinToggle = veinToggle;
        _veinRidged = veinRidged;
        _veinGap = veinGap;
        _random = random;

        _copper = new VeinType(Block.CopperOre.StateId, Block.RawCopperBlock.StateId,
            Block.Granite.StateId, 0, 50);
        _iron = new VeinType(Block.DeepslateIronOre.StateId, Block.RawIronBlock.StateId,
            Block.Tuff.StateId, -60, -8);
    }

    public uint? Calculate(IFunctionContext context) {
        double veininess = _veinToggle.Compute(context);
        int posY = context.BlockY;

        VeinType veinType = veininess > 0.0 ? _copper : _iron;
        double veininessRidged = Math.Abs(veininess);

        int distanceFromTop = veinType.MaxY - posY;
        int distanceFromBottom = posY - veinType.MinY;
        if (distanceFromBottom < 0 || distanceFromTop < 0) {
            return null;
        }

        // Faded out over the last twenty blocks of the band so a vein does not stop at a flat plane.
        int distanceFromEdge = Math.Min(distanceFromTop, distanceFromBottom);
        double edgeRoundoff = Mth.ClampedMap(distanceFromEdge, 0.0, EdgeRoundoffBegin, -MaxEdgeRoundoff, 0.0);
        if (veininessRidged + edgeRoundoff < VeininessThreshold) {
            return null;
        }

        // The three draws come off one generator in this order, so the solidness roll happens even
        // where the ridge check would have rejected the position anyway.
        RandomSource random = _random.At(context.BlockX, posY, context.BlockZ);
        if (random.NextFloat() > VeinSolidness) {
            return null;
        }

        if (_veinRidged.Compute(context) >= 0.0) {
            return null;
        }

        double richness = Mth.ClampedMap(veininessRidged, VeininessThreshold, MaxRichnessThreshold,
            MinRichness, MaxRichness);

        if (random.NextFloat() < richness && _veinGap.Compute(context) > SkipOreIfGapNoiseIsBelow) {
            return random.NextFloat() < ChanceOfRawOreBlock ? veinType.RawOreBlock : veinType.Ore;
        }

        return veinType.Filler;
    }

    private readonly record struct VeinType(uint Ore, uint RawOreBlock, uint Filler, int MinY, int MaxY);
}

/// <summary>Runs a list of fillers in order, taking the first that has an answer.</summary>
public sealed class MaterialRuleList(IReadOnlyList<IBlockStateFiller> fillers) : IBlockStateFiller {
    public uint? Calculate(IFunctionContext context) {
        foreach (IBlockStateFiller filler in fillers) {
            uint? state = filler.Calculate(context);
            if (state != null) {
                return state;
            }
        }

        return null;
    }
}
