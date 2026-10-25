namespace ClientLib.Particles;

/// <summary>
/// A xorshift generator for particle draws. Particles only have to look right, so this replaces vanilla's
/// per particle <c>RandomSource</c>s with one cheap stream.
/// </summary>
public sealed class ParticleRandom(ulong seed) {
    private ulong _state = seed == 0 ? 0x9E3779B97F4A7C15UL : seed;
    private double _nextGaussian;
    private bool _haveGaussian;

    public ParticleRandom() : this((ulong)Environment.TickCount64 * 0x9E3779B97F4A7C15UL ^ (ulong)System.Diagnostics.Stopwatch.GetTimestamp()) { }

    private ulong Next() {
        ulong x = _state;
        x ^= x << 13;
        x ^= x >> 7;
        x ^= x << 17;
        _state = x;
        return x;
    }

    /// <summary>0 inclusive to 1 exclusive.</summary>
    public float NextFloat() => (Next() >> 40) * (1.0F / (1 << 24));

    public double NextDouble() => (Next() >> 11) * (1.0 / (1UL << 53));

    /// <summary>0 inclusive to <paramref name="bound"/> exclusive.</summary>
    public int NextInt(int bound) => (int)((Next() >> 33) * (ulong)bound >> 31);

    public bool NextBool() => (Next() & 1) != 0;

    public float Between(float min, float max) => min + NextFloat() * (max - min);

    public double NextGaussian() {
        if (_haveGaussian) {
            _haveGaussian = false;
            return _nextGaussian;
        }
        double v1, v2, s;
        do {
            v1 = 2 * NextDouble() - 1;
            v2 = 2 * NextDouble() - 1;
            s = v1 * v1 + v2 * v2;
        } while (s >= 1 || s == 0);
        double multiplier = Math.Sqrt(-2 * Math.Log(s) / s);
        _nextGaussian = v2 * multiplier;
        _haveGaussian = true;
        return v1 * multiplier;
    }
}
