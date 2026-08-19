using System.Security.Cryptography;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Biomes;

/// <summary>
/// Turns the biome grid, which is one entry per 4x4x4 cell, into a biome per block. Vanilla's
/// <c>BiomeManager</c> and its fuzzy offset zoomer.
/// </summary>
/// <remarks>
/// A position does not simply take the cell it falls in. Each of the eight surrounding cell centres is
/// jittered by a hash of its own coordinates and the nearest one wins, which is what makes a biome
/// boundary a ragged line rather than a straight edge on a four block grid. Surface rules ask this
/// rather than the grid, so skipping it puts visible steps along every beach.
/// <p/>
/// The seed is <b>the SHA-256 of the world seed</b>, not the world seed. Passing the raw seed produces
/// a different, equally plausible looking wobble.
/// </remarks>
public sealed class BiomeZoom(long biomeZoomSeed) {
    private const long Multiplier = 6364136223846793005L;
    private const long Increment = 1442695040888963407L;

    /// <summary><c>BiomeManager.obfuscateSeed</c>: the first eight bytes of the seed's SHA-256.</summary>
    public static long ObfuscateSeed(long seed) {
        // Guava hashes a long little endian and reads the result back little endian, so both ends of
        // this are the opposite way round from the usual big endian convention.
        byte[] input = BitConverter.GetBytes(seed);
        if (!BitConverter.IsLittleEndian) {
            Array.Reverse(input);
        }

        byte[] hash = SHA256.HashData(input);

        long result = 0L;
        for (int i = 7; i >= 0; i--) {
            result = (result << 8) | hash[i];
        }

        return result;
    }

    /// <summary>A resolver holding its own jitter cache. One per chunk being generated.</summary>
    public Resolver NewResolver() => new(biomeZoomSeed);

    /// <summary>The quart cell a block position belongs to, once the jitter has been applied.</summary>
    public (int QuartX, int QuartY, int QuartZ) Resolve(int blockX, int blockY, int blockZ) {
        return NewResolver().Resolve(blockX, blockY, blockZ);
    }

    /// <summary>
    /// The zoom itself, plus the jitter it has already worked out.
    /// </summary>
    /// <remarks>
    /// How far a cell centre is displaced depends on that cell's coordinates and the seed and nothing
    /// else, so the eight lookups a position needs are worth keeping. Surface rules ask for a biome at
    /// every position of every column, and a column's hundred and fifty of them share two x corners
    /// and two z corners and step through y four blocks at a time, so almost every one is a repeat.
    /// <p/>
    /// Direct mapped and per chunk rather than shared: an entry is three doubles, a collision costs
    /// exactly what having no cache costs, and a shared one would need a lock on the hottest path
    /// there is in generation.
    /// </remarks>
    public sealed class Resolver(long seed) {
        private const int CacheSlots = 512;

        private readonly int[] _keys = new int[CacheSlots * 3];
        private readonly double[] _offsets = new double[CacheSlots * 3];
        private readonly bool[] _filled = new bool[CacheSlots];

        public (int QuartX, int QuartY, int QuartZ) Resolve(int blockX, int blockY, int blockZ) {
            // Offset by two so the cell centres, not their corners, are what the position is measured
            // against.
            int absX = blockX - 2;
            int absY = blockY - 2;
            int absZ = blockZ - 2;

            int parentX = absX >> 2;
            int parentY = absY >> 2;
            int parentZ = absZ >> 2;

            double fractX = (absX & 3) / 4.0;
            double fractY = (absY & 3) / 4.0;
            double fractZ = (absZ & 3) / 4.0;

            int minI = 0;
            double minFiddledDistance = double.PositiveInfinity;

            for (int i = 0; i < 8; i++) {
                bool xEven = (i & 4) == 0;
                bool yEven = (i & 2) == 0;
                bool zEven = (i & 1) == 0;

                int cornerX = xEven ? parentX : parentX + 1;
                int cornerY = yEven ? parentY : parentY + 1;
                int cornerZ = zEven ? parentZ : parentZ + 1;

                double distanceX = xEven ? fractX : fractX - 1.0;
                double distanceY = yEven ? fractY : fractY - 1.0;
                double distanceZ = zEven ? fractZ : fractZ - 1.0;

                Offsets(cornerX, cornerY, cornerZ, out double fiddleX, out double fiddleY, out double fiddleZ);

                double next = Mth.Square(distanceZ + fiddleZ)
                    + Mth.Square(distanceY + fiddleY)
                    + Mth.Square(distanceX + fiddleX);

                if (minFiddledDistance > next) {
                    minI = i;
                    minFiddledDistance = next;
                }
            }

            return ((minI & 4) == 0 ? parentX : parentX + 1,
                (minI & 2) == 0 ? parentY : parentY + 1,
                (minI & 1) == 0 ? parentZ : parentZ + 1);
        }

        /// <summary>
        /// How far the cell's centre is displaced on each axis, up to 0.45 of a cell.
        /// </summary>
        /// <remarks>
        /// The generator is stepped six times over the three coordinates before the first offset is
        /// taken, and the coordinates go in twice in the same order. That redundancy is what
        /// decorrelates neighbouring cells, so it is not a loop to shorten.
        /// </remarks>
        private void Offsets(int cornerX, int cornerY, int cornerZ,
            out double offsetX, out double offsetY, out double offsetZ) {

            int slot = (int)((uint)(cornerX * 0x9E3779B1 ^ cornerY * 0x85EBCA6B ^ cornerZ * -1028477387)
                % CacheSlots);
            int at = slot * 3;

            if (_filled[slot] && _keys[at] == cornerX && _keys[at + 1] == cornerY
                && _keys[at + 2] == cornerZ) {

                offsetX = _offsets[at];
                offsetY = _offsets[at + 1];
                offsetZ = _offsets[at + 2];
                return;
            }

            long rval = Next(seed, cornerX);
            rval = Next(rval, cornerY);
            rval = Next(rval, cornerZ);
            rval = Next(rval, cornerX);
            rval = Next(rval, cornerY);
            rval = Next(rval, cornerZ);

            offsetX = Fiddle(rval);
            rval = Next(rval, seed);
            offsetY = Fiddle(rval);
            rval = Next(rval, seed);
            offsetZ = Fiddle(rval);

            _filled[slot] = true;
            _keys[at] = cornerX;
            _keys[at + 1] = cornerY;
            _keys[at + 2] = cornerZ;
            _offsets[at] = offsetX;
            _offsets[at + 1] = offsetY;
            _offsets[at + 2] = offsetZ;
        }
    }

    /// <summary>
    /// <c>LinearCongruentialGenerator.next</c>. Note the square: it is <c>rval * (rval * m + i)</c>,
    /// not the usual <c>rval * m + i</c>.
    /// </summary>
    private static long Next(long rval, long c) {
        rval *= rval * Multiplier + Increment;
        return rval + c;
    }

    private static double Fiddle(long rval) {
        double uniform = Mth.FloorMod(rval >> 24, 1024L) / 1024.0;
        return (uniform - 0.5) * 0.9;
    }
}
