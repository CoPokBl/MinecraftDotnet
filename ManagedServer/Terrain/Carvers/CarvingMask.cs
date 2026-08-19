namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CarvingMask</c>: which positions of a chunk some carver has already reached.
/// </summary>
/// <remarks>
/// One per chunk, shared by every carver that runs over it, and the reason a chunk crossed by two
/// tunnels does not have its blocks decided twice. That matters beyond the wasted work: the second
/// visit would read the air the first one left, so a position under a grass block would no longer see
/// the dirt the surface fix-up needs.
/// <p/>
/// Indexed the way vanilla indexes it, x then z then y, so the bit for a position is
/// <c>x | z &lt;&lt; 4 | (y - minY) &lt;&lt; 8</c>.
/// </remarks>
public sealed class CarvingMask(int height, int minY) {
    private readonly ulong[] _bits = new ulong[(256 * height + 63) / 64];

    private int IndexOf(int localX, int blockY, int localZ) {
        return (localX & 15) | ((localZ & 15) << 4) | ((blockY - minY) << 8);
    }

    public void Set(int localX, int blockY, int localZ) {
        int index = IndexOf(localX, blockY, localZ);
        _bits[index >> 6] |= 1UL << (index & 63);
    }

    public bool Get(int localX, int blockY, int localZ) {
        int index = IndexOf(localX, blockY, localZ);
        return (_bits[index >> 6] & (1UL << (index & 63))) != 0;
    }
}
