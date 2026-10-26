namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// The room a jigsaw structure has left to grow into: one region minus the pieces already in it.
/// </summary>
/// <remarks>
/// Vanilla carries this as a <c>VoxelShape</c> and asks two questions of it: whether a candidate box
/// lies wholly inside, and then subtract that box. Every shape it ever builds is a single box minus a
/// list of boxes, so this holds exactly that instead, and the two questions are set arithmetic rather
/// than a voxel join:
/// <p/>
/// <c>X subset of (outer \ removed)</c> is <c>X subset of outer</c> and <c>X</c> meets no removed box.
/// That is an identity rather than an approximation, so the answers match whatever the shapes would
/// have said.
/// <p/>
/// <b>Mutable and shared, as the <c>MutableObject</c> upstream is.</b> A piece hands the same instance
/// to every child it queues, so a box one child takes is gone for its siblings. A copy would let two
/// branches of the same structure grow through each other.
/// </remarks>
public sealed class JigsawFreeSpace {
    /// <summary>How far a candidate box is shrunk before being tested, vanilla's <c>deflate</c>.</summary>
    /// <remarks>
    /// What makes two pieces allowed to share a face: their boxes touch, and a quarter block of slack
    /// on each side is enough to separate them without letting a real overlap through, since every box
    /// here is on integer bounds.
    /// </remarks>
    private const double Slack = 0.25;

    private readonly double _minX;
    private readonly double _minY;
    private readonly double _minZ;
    private readonly double _maxX;
    private readonly double _maxY;
    private readonly double _maxZ;

    private readonly List<BoundingBox> _removed = [];

    private JigsawFreeSpace(double minX, double minY, double minZ, double maxX, double maxY,
        double maxZ) {

        _minX = minX;
        _minY = minY;
        _minZ = minZ;
        _maxX = maxX;
        _maxY = maxY;
        _maxZ = maxZ;
    }

    /// <summary>
    /// The region a structure may grow in: a box in world coordinates, exclusive at its far corner.
    /// </summary>
    public static JigsawFreeSpace Within(double minX, double minY, double minZ, double maxX,
        double maxY, double maxZ) {

        return new JigsawFreeSpace(minX, minY, minZ, maxX, maxY, maxZ);
    }

    /// <summary>
    /// The whole of one piece's box, which is what a connection pointing back into its own piece grows
    /// inside.
    /// </summary>
    /// <remarks>
    /// Positive rather than a subtraction: a jigsaw block whose target cell is inside its own piece is
    /// filling that piece rather than the space around it, so the piece's box is the room available.
    /// </remarks>
    public static JigsawFreeSpace Of(BoundingBox box) {
        return new JigsawFreeSpace(box.MinX, box.MinY, box.MinZ, box.MaxX + 1, box.MaxY + 1,
            box.MaxZ + 1);
    }

    /// <summary>Whether a candidate box fits in what is left.</summary>
    public bool Fits(BoundingBox box) {
        if (box.MinX + Slack < _minX || box.MaxX + 1 - Slack > _maxX
            || box.MinY + Slack < _minY || box.MaxY + 1 - Slack > _maxY
            || box.MinZ + Slack < _minZ || box.MaxZ + 1 - Slack > _maxZ) {

            return false;
        }

        foreach (BoundingBox taken in _removed) {
            if (Overlaps(box, taken)) {
                return false;
            }
        }

        return true;
    }

    /// <summary>Takes a box out of what is left.</summary>
    public void Remove(BoundingBox box) {
        _removed.Add(new BoundingBox(box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ));
    }

    /// <summary>
    /// Whether the deflated candidate meets a box already taken.
    /// </summary>
    /// <remarks>
    /// The slack is on the candidate alone, matching the deflate upstream, so two boxes sharing a face
    /// do not count as meeting while an overlap of a whole block does.
    /// </remarks>
    private static bool Overlaps(BoundingBox candidate, BoundingBox taken) {
        return candidate.MinX + Slack < taken.MaxX + 1 && candidate.MaxX + 1 - Slack > taken.MinX
            && candidate.MinY + Slack < taken.MaxY + 1 && candidate.MaxY + 1 - Slack > taken.MinY
            && candidate.MinZ + Slack < taken.MaxZ + 1 && candidate.MaxZ + 1 - Slack > taken.MinZ;
    }
}
