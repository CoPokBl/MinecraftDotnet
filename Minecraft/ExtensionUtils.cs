using System.Collections;

namespace Minecraft;

public static class ExtensionUtils {

    // a long array containing a little-endian representation of all the bits in this bit set
    // Returns a new long array containing all the bits in this bit set.
    // More precisely, if
    // long[] longs = s.toLongArray();
    // then longs.length == (s.length()+63)/64 and
    // s.get(n) == ((longs[n/64] & (1L<<(n%64))) != 0)
    // for all n < 64 * longs.length.
    // Should mimic the behavior of Java's BitSet.toLongArray() method.
    // https://docs.oracle.com/javase/8/docs/api/java/util/BitSet.html#toLongArray--
    public static long[] ToLongArray(this BitArray bits) {
        int length = bits.Length;
        int longCount = (length + 63) / 64; // Calculate how many longs we need
        long[] result = new long[longCount];

        for (int i = 0; i < length; i++) {
            if (bits[i]) {
                result[i / 64] |= 1L << (i % 64);
            }
        }

        return result;
    }

    public static T LogVal<T>(this T val, Func<T, Object> thing) {
        Console.WriteLine(thing.Invoke(val));
        return val;
    }

    // gets the minimum amount of bits required to store this value (unsigned)
    public static int MinBitsToStore(this int v) {
        return v switch {
            < 0 => throw new ArgumentOutOfRangeException(nameof(v), "Value must be non-negative."),
            0 => 1,
            _ => (int)Math.Ceiling(Math.Log2(v + 1))
        };
    }
}