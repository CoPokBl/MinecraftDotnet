namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// <c>CarvingMask</c>: every position some carver reached in one chunk, which the pass applies only
/// once all of them have run. A carver writes nothing to the chunk itself.
/// </summary>
/// <remarks>
/// A bit per position over the inclusive y range, indexed <c>y - minY + (z + (x &lt;&lt; 4)) * height</c>
/// so a column is contiguous. <see cref="Visit"/> walks the set runs in ascending index order, which is
/// column by column from x 0, z 0, and within a column from the lowest run up.
/// </remarks>
public sealed class CarvingMask {
    private readonly int _height;
    private readonly ulong[] _bits;

    public CarvingMask(int minY, int maxY) {
        MinY = minY;
        MaxY = maxY;
        _height = maxY - minY + 1;
        _bits = new ulong[(256 * Math.Max(_height, 0) + 63) / 64];
    }

    public int MinY { get; }

    public int MaxY { get; }

    public delegate void Visitor(int x, int z, int bottomY, int topY);

    private int IndexOf(int x, int y, int z) => y - MinY + (z + (x << 4)) * _height;

    public void Carve(int x, int y, int z) {
        int index = IndexOf(x, y, z);
        _bits[index >> 6] |= 1UL << (index & 63);
    }

    public bool IsEmpty => _bits.All(word => word == 0UL);

    private bool Get(int index) => (_bits[index >> 6] & (1UL << (index & 63))) != 0;

    public void Visit(Visitor visitor) {
        int size = 256 * _height;
        int index = 0;
        while (index < size) {
            if (!Get(index)) {
                index++;
                continue;
            }

            int start = index;
            while (index < size && Get(index)) {
                index++;
            }

            VisitSegment(visitor, start, index - 1);
        }
    }

    private void VisitSegment(Visitor visitor, int startIndex, int endIndex) {
        int startColumn = startIndex / _height;
        int endColumn = endIndex / _height;
        for (int column = startColumn; column <= endColumn; column++) {
            int columnX = (column >> 4) & 15;
            int columnZ = column & 15;
            int columnBaseIndex = column * _height;
            int bottomY = Math.Max(startIndex - columnBaseIndex, 0) + MinY;
            int topY = Math.Min(endIndex - columnBaseIndex, _height - 1) + MinY;
            visitor(columnX, columnZ, bottomY, topY);
        }
    }
}
