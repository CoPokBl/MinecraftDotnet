using ManagedServer.Terrain.Density;

namespace ManagedServer.Terrain;

/// <summary>
/// The fifteen density functions a dimension's terrain is described by, vanilla's <c>NoiseRouter</c>.
/// </summary>
/// <remarks>
/// Not a bag of noises: each entry answers one question, and everything else in the generator reads
/// them rather than sampling noise directly. <see cref="FinalDensity"/> decides whether a position is
/// solid; the six climate entries decide which biome it is; the aquifer and the ore veins take four
/// each.
/// </remarks>
public sealed record NoiseRouter(
    IDensityFunction Barrier,
    IDensityFunction FluidLevelFloodedness,
    IDensityFunction FluidLevelSpread,
    IDensityFunction Lava,
    IDensityFunction Temperature,
    IDensityFunction Vegetation,
    IDensityFunction Continents,
    IDensityFunction Erosion,
    IDensityFunction Depth,
    IDensityFunction Ridges,
    IDensityFunction PreliminarySurfaceLevel,
    IDensityFunction FinalDensity,
    IDensityFunction VeinToggle,
    IDensityFunction VeinRidged,
    IDensityFunction VeinGap) {

    /// <summary>
    /// The visitor applied to every entry, which is how a router gets bound to a seed and then to a
    /// chunk.
    /// </summary>
    /// <remarks>
    /// All fifteen go through <b>one</b> <see cref="DensityFunctionRewrite"/>. The entries overlap
    /// heavily: the climate six, the aquifer's four and the final density are largely the same
    /// continents, erosion and depth subtrees, and a rewrite per entry would give each of them its
    /// own copy of every cache under it.
    /// </remarks>
    public NoiseRouter MapAll(IDensityFunctionVisitor visitor) {
        DensityFunctionRewrite rewrite = DensityFunctionRewrite.Of(visitor);

        return new NoiseRouter(
            rewrite.Apply(Barrier),
            rewrite.Apply(FluidLevelFloodedness),
            rewrite.Apply(FluidLevelSpread),
            rewrite.Apply(Lava),
            rewrite.Apply(Temperature),
            rewrite.Apply(Vegetation),
            rewrite.Apply(Continents),
            rewrite.Apply(Erosion),
            rewrite.Apply(Depth),
            rewrite.Apply(Ridges),
            rewrite.Apply(PreliminarySurfaceLevel),
            rewrite.Apply(FinalDensity),
            rewrite.Apply(VeinToggle),
            rewrite.Apply(VeinRidged),
            rewrite.Apply(VeinGap));
    }
}
