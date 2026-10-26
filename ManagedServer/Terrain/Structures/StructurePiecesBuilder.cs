using Minecraft.Schemas;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>StructurePiecesBuilder</c>: the list a structure's pieces are added to while it decides what it
/// is, and <c>StructurePieceAccessor</c>'s collision test over that list.
/// </summary>
/// <remarks>
/// The collision test is what keeps a mineshaft from growing a corridor through a room it already
/// placed, and it is a linear scan of everything added so far, as upstream. A structure is a few
/// hundred pieces at most.
/// </remarks>
public sealed class StructurePiecesBuilder {
    private readonly List<StructurePiece> _pieces = [];

    public IReadOnlyList<StructurePiece> Pieces => _pieces;

    public bool IsEmpty => _pieces.Count == 0;

    public void AddPiece(StructurePiece piece) {
        _pieces.Add(piece);
    }

    /// <summary>The first piece already placed that overlaps the box, or null.</summary>
    public StructurePiece? FindCollisionPiece(BoundingBox box) {
        return StructurePiece.FindCollisionPiece(_pieces, box);
    }

    /// <summary>The box holding every piece. Throws for a builder with none.</summary>
    public BoundingBox BoundingBox {
        get {
            BoundingBox? box = Structures.BoundingBox.Encapsulating(
                _pieces.Select(piece => piece.BoundingBox));

            return box ?? throw new InvalidOperationException(
                "A structure's bounding box was asked for before it had any pieces.");
        }
    }

    /// <summary>Shifts every piece, which is how a whole structure is dropped to a new height.</summary>
    public void OffsetPiecesVertically(int dy) {
        foreach (StructurePiece piece in _pieces) {
            piece.Move(0, dy, 0);
        }
    }

    /// <summary>
    /// <c>moveBelowSeaLevel</c>: drops the structure so its top sits a given distance under the sea,
    /// and randomly further down if there is room. Answers how far it moved.
    /// </summary>
    public int MoveBelowSeaLevel(int seaLevel, int minY, RandomSource random, int offset) {
        int highestAllowed = seaLevel - offset;
        BoundingBox box = BoundingBox;
        int top = box.YSpan + minY + 1;

        if (top < highestAllowed) {
            top += random.NextInt(highestAllowed - top);
        }

        int dy = top - box.MaxY;
        OffsetPiecesVertically(dy);
        return dy;
    }

    /// <summary>
    /// <c>moveInsideHeights</c>: puts the structure at a random height inside a band, or at the
    /// bottom of it where the band is no taller than the structure.
    /// </summary>
    public void MoveInsideHeights(RandomSource random, int lowestAllowed, int highestAllowed) {
        BoundingBox box = BoundingBox;
        int span = highestAllowed - lowestAllowed + 1 - box.YSpan;
        int bottom = span > 1 ? lowestAllowed + random.NextInt(span) : lowestAllowed;

        OffsetPiecesVertically(bottom - box.MinY);
    }

    public void Clear() {
        _pieces.Clear();
    }

    public PiecesContainer Build() {
        return new PiecesContainer([.._pieces]);
    }
}

/// <summary>
/// <c>PiecesContainer</c>: a structure's finished piece list, which is what a start holds.
/// </summary>
public sealed record PiecesContainer(IReadOnlyList<StructurePiece> Pieces) {
    public bool IsEmpty => Pieces.Count == 0;

    public bool IsInsidePiece(int x, int y, int z) {
        foreach (StructurePiece piece in Pieces) {
            if (piece.BoundingBox.IsInside(x, y, z)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>The box holding every piece. Throws for a container with none.</summary>
    public BoundingBox CalculateBoundingBox() {
        BoundingBox? box = Structures.BoundingBox.Encapsulating(
            Pieces.Select(piece => piece.BoundingBox));

        return box ?? throw new InvalidOperationException(
            "A structure's bounding box was asked for before it had any pieces.");
    }
}
