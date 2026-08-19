using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Features;

/// <summary>Shared pieces of <c>Util</c> that more than one feature reaches for.</summary>
public static class FeatureUtil {
    /// <summary>
    /// <c>Util.shuffle</c>, a Fisher-Yates walking <b>downwards</b>.
    /// </summary>
    /// <remarks>
    /// The direction decides which element ends up where for a given sequence of draws, so it is not
    /// interchangeable with the upward form even though both are uniform.
    /// </remarks>
    public static List<T> Shuffled<T>(IReadOnlyList<T> values, RandomSource random) {
        List<T> copy = [..values];

        for (int i = copy.Count; i > 1; i--) {
            int swap = random.NextInt(i);
            (copy[i - 1], copy[swap]) = (copy[swap], copy[i - 1]);
        }

        return copy;
    }

    /// <summary>
    /// A set of positions that iterates in <c>java.util.HashSet</c>'s order.
    /// </summary>
    /// <remarks>
    /// Vanilla collects positions into a <c>HashSet</c> and then loops over it drawing per entry, so
    /// the set's order decides which position each draw lands on while the draw count is identical
    /// either way. A tree's logs and leaves and a vegetation patch's surface are both this.
    /// </remarks>
    public static JavaHashSet<Vec3<int>> PositionSet() => new(JavaBlockPosHash);

    /// <summary><c>Vec3i.hashCode</c>, which is what decides that order.</summary>
    public static int JavaBlockPosHash(Vec3<int> pos) => (pos.Y + pos.Z * 31) * 31 + pos.X;

    /// <summary><c>Direction.values()</c>, which <see cref="BlockFace"/> matches ordinal for ordinal.</summary>
    public static readonly BlockFace[] AllDirections = [
        BlockFace.NegY, BlockFace.PosY, BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX
    ];
}
