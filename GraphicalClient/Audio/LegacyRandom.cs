using GraphicalClient.Assets.ResourcePacks;

namespace GraphicalClient.Audio;

/// <summary>
/// <c>RandomSource.create(seed)</c>, which is <c>LegacyRandomSource</c>: a server sends the seed with a
/// sound so every client picks the same variant of it.
/// </summary>
public sealed class LegacyRandom(long seed) {
    private JavaRandom _random = new(seed);

    /// <summary><c>RandomSource.create()</c>, seeded from nothing in particular.</summary>
    public LegacyRandom() : this(System.Random.Shared.NextInt64()) { }

    public int NextInt(int bound) => _random.NextInt(bound);
    public float NextFloat() => _random.NextFloat();
    public long NextLong() => _random.NextLong();

    /// <summary><c>nextBoolean</c>, which is <c>next(1)</c>: what <c>nextInt(2)</c> is for a power of two bound.</summary>
    public bool NextBoolean() => _random.NextInt(2) != 0;

    /// <summary>
    /// <c>BitRandomSource.nextDouble</c>. A power of two bound makes <c>nextInt</c> exactly <c>next(bits)</c>,
    /// which is how the 26 and 27 bit draws are reached; the multiplier is a float constant upstream.
    /// </summary>
    public double NextDouble() => (((long)_random.NextInt(1 << 26) << 27) + _random.NextInt(1 << 27)) * (double)1.110223E-16F;

    /// <summary><c>RandomSource.triangle</c>.</summary>
    public float Triangle(float mean, float spread) => mean + spread * (NextFloat() - NextFloat());

    /// <summary><c>Mth.randomBetween</c>.</summary>
    public float RandomBetween(float min, float maxExclusive) => NextFloat() * (maxExclusive - min) + min;

    /// <summary><c>Mth.nextInt</c>, which draws nothing when the range holds one value.</summary>
    public int MthNextInt(int minInclusive, int maxInclusive) =>
        minInclusive >= maxInclusive ? minInclusive : NextInt(maxInclusive - minInclusive + 1) + minInclusive;
}
