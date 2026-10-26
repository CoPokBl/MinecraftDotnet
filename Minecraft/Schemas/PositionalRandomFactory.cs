namespace Minecraft.Schemas;

/// <summary>
/// Vanilla's <c>PositionalRandomFactory</c>: a generator per position, per name or per seed, derived
/// from one parent so the whole set is reproducible from the world seed alone.
/// </summary>
/// <remarks>
/// Terrain generation runs a chunk at a time in any order and on any thread, so nothing in it can
/// depend on a running sequence. Every random decision is instead seeded from what it is about: a
/// noise octave from its name, a surface block from its position. That is what makes a chunk generate
/// the same whether it was the first or the thousandth.
/// </remarks>
public interface IPositionalRandomFactory {
    RandomSource At(int x, int y, int z);

    /// <summary>
    /// Seeded from a name, which is how each noise octave gets its own generator. The hash is part of
    /// the seed, so the two implementations here deliberately hash differently.
    /// </summary>
    RandomSource FromHashOf(string name);

    RandomSource FromSeed(long seed);
}
