using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>StrongholdStructure</c>: the stronghold, whose corridors are grown breadth first from a spiral
/// staircase and which is not finished until it has an end portal room.
/// </summary>
/// <remarks>
/// <b>The layout is retried until it works.</b> A stronghold whose portal room never got placed is
/// thrown away whole and rebuilt from the next seed, which is what the <c>seed + attempt</c> in the
/// loop is for. Nothing else here does that, and it is why the piece list is cleared rather than added
/// to.
/// <p/>
/// Its placement is the only concentric rings one in the game, so it is also the only structure whose
/// chunks are not arithmetic. See <see cref="RingPositions"/>.
/// </remarks>
public sealed class StrongholdStructure(Structure.StructureSettings settings) : Structure(settings) {
    protected override GenerationStub FindGenerationPoint(StructureGenerationContext context) {
        return new GenerationStub(new Vec3<int>(context.ChunkX << 4, 0, context.ChunkZ << 4),
            builder => GeneratePieces(builder, context));
    }

    private static void GeneratePieces(StructurePiecesBuilder builder,
        StructureGenerationContext context) {

        int attempt = 0;
        StrongholdStartPiece start;

        do {
            builder.Clear();
            context.Random.SetLargeFeatureSeed(context.Seed + attempt++, context.ChunkX,
                context.ChunkZ);

            start = new StrongholdStartPiece(context.Random, (context.ChunkX << 4) + 2,
                (context.ChunkZ << 4) + 2);

            builder.AddPiece(start);
            start.AddChildren(start, builder, context.Random);

            // Breadth first, and the order within it is a draw: a piece is pulled out of the pending
            // list at random rather than in the order it was added. That is what makes a stronghold
            // sprawl instead of growing one corridor at a time.
            List<StructurePiece> pending = start.Layout.PendingChildren;

            while (pending.Count > 0) {
                int index = context.Random.NextInt(pending.Count);
                StructurePiece piece = pending[index];
                pending.RemoveAt(index);
                piece.AddChildren(start, builder, context.Random);
            }

            builder.MoveBelowSeaLevel(context.SeaLevel, context.MinY, context.Random, 10);
        } while (builder.IsEmpty || start.Layout.PortalRoom is null);
    }
}

/// <summary>Which of the twelve stronghold pieces one of the weighted entries stands for.</summary>
public enum StrongholdPieceKind {
    Straight,
    PrisonHall,
    LeftTurn,
    RightTurn,
    RoomCrossing,
    StraightStairsDown,
    StairsDown,
    FiveCrossing,
    ChestCorridor,
    Library,
    PortalRoom
}

/// <summary>
/// One entry of the weighted table a stronghold picks its next piece from.
/// </summary>
/// <remarks>
/// <see cref="PlaceCount"/> is mutable and counted per stronghold, which is what keeps a stronghold to
/// one portal room and two libraries.
/// </remarks>
public sealed class StrongholdPieceWeight(StrongholdPieceKind kind, int weight, int maxPlaceCount,
    int minDepth = 0) {

    public StrongholdPieceKind Kind => kind;
    public int Weight => weight;
    public int PlaceCount { get; set; }

    /// <summary>Whether the piece may still be placed at this depth.</summary>
    public bool DoPlace(int depth) => IsValid && depth >= minDepth;

    /// <summary>Whether the piece has any placements left at all, whatever the depth.</summary>
    public bool IsValid => maxPlaceCount == 0 || PlaceCount < maxPlaceCount;

    /// <summary>Whether the piece is limited at all, which is what decides if a stronghold is done.</summary>
    public bool HasLimit => maxPlaceCount > 0;
}

/// <summary>
/// The state one stronghold's layout carries while it is being built.
/// </summary>
/// <remarks>
/// <b>Held on the start piece, where vanilla holds most of it in static fields.</b> Statics would be a
/// race between two chunks laying out strongholds at once, and the pass generates on the thread pool.
/// The start piece is already what <c>addChildren</c> is handed, and vanilla already keeps
/// <c>previousPiece</c> and <c>pendingChildren</c> there, so this is where the rest belongs.
/// </remarks>
public sealed class StrongholdLayout {
    /// <summary>
    /// The weighted table, vanilla's <c>STRONGHOLD_PIECE_WEIGHTS</c> rebuilt per stronghold.
    /// </summary>
    /// <remarks>
    /// An entry is <b>removed</b> once it runs out of placements, which changes the total weight and
    /// therefore every later draw. Zeroing its weight instead would generate a different stronghold.
    /// </remarks>
    public readonly List<StrongholdPieceWeight> Available = [
        new(StrongholdPieceKind.Straight, 40, 0),
        new(StrongholdPieceKind.PrisonHall, 5, 5),
        new(StrongholdPieceKind.LeftTurn, 20, 0),
        new(StrongholdPieceKind.RightTurn, 20, 0),
        new(StrongholdPieceKind.RoomCrossing, 10, 6),
        new(StrongholdPieceKind.StraightStairsDown, 5, 5),
        new(StrongholdPieceKind.StairsDown, 5, 5),
        new(StrongholdPieceKind.FiveCrossing, 5, 4),
        new(StrongholdPieceKind.ChestCorridor, 5, 4),

        // The two that also have a minimum depth, so a stronghold cannot open onto its own portal.
        new(StrongholdPieceKind.Library, 10, 2, 5),
        new(StrongholdPieceKind.PortalRoom, 20, 1, 6)
    ];

    /// <summary>
    /// A piece the previous one insisted on, which only the source staircase sets and which is
    /// consumed by the next draw whether or not it could be built.
    /// </summary>
    public StrongholdPieceKind? Imposed { get; set; }

    /// <summary>The entry the last piece came from, which may not be drawn again immediately.</summary>
    public StrongholdPieceWeight? Previous { get; set; }

    public StrongholdPortalRoom? PortalRoom { get; set; }

    public readonly List<StructurePiece> PendingChildren = [];

    public int TotalWeight { get; private set; }

    /// <summary>
    /// Recomputes the total and answers whether any limited piece is still available.
    /// </summary>
    /// <remarks>
    /// The answer ignores the unlimited pieces entirely: a stronghold that has used up its rooms,
    /// libraries and portal room stops growing rather than filling the world with corridors.
    /// </remarks>
    public bool UpdatePieceWeight() {
        bool any = false;
        TotalWeight = 0;

        foreach (StrongholdPieceWeight piece in Available) {
            if (piece.HasLimit && piece.IsValid) {
                any = true;
            }

            TotalWeight += piece.Weight;
        }

        return any;
    }
}

/// <summary>
/// <c>StrongholdPieces.StrongholdPiece</c>: the doorway kinds and the child placement every stronghold
/// piece shares.
/// </summary>
public abstract class StrongholdPiece(int genDepth, BoundingBox boundingBox)
    : StructurePiece(genDepth, boundingBox) {

    /// <summary>How a piece's own entrance is finished off.</summary>
    public enum SmallDoorType {
        Opening,
        WoodDoor,
        Grates,
        IronDoor
    }

    protected SmallDoorType EntryDoor { get; set; } = SmallDoorType.Opening;

    protected static uint StoneBricks => Block.StoneBricks.StateId;

    protected static uint CaveAir => Block.CaveAir.StateId;

    /// <summary>
    /// The doorway itself, which is written in the piece's own coordinates and therefore turns with
    /// it.
    /// </summary>
    protected void GenerateSmallDoor(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        SmallDoorType doorType, int x, int y, int z) {

        switch (doorType) {
            case SmallDoorType.Opening:
                GenerateBox(level, chunkBox, x, y, z, x + 2, y + 2, z, CaveAir, CaveAir, false);
                break;

            case SmallDoorType.WoodDoor:
                Frame(level, chunkBox, x, y, z);
                PlaceBlock(level, Block.OakDoor.StateId, x + 1, y, z, chunkBox);
                PlaceBlock(level, Upper(Block.OakDoor), x + 1, y + 1, z, chunkBox);
                break;

            case SmallDoorType.Grates:
                PlaceBlock(level, CaveAir, x + 1, y, z, chunkBox);
                PlaceBlock(level, CaveAir, x + 1, y + 1, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.NegX), x, y, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.NegX), x, y + 1, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.PosX, BlockFace.NegX), x, y + 2, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.PosX, BlockFace.NegX), x + 1, y + 2, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.PosX, BlockFace.NegX), x + 2, y + 2, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.PosX), x + 2, y + 1, z, chunkBox);
                PlaceBlock(level, Bars(BlockFace.PosX), x + 2, y, z, chunkBox);
                break;

            case SmallDoorType.IronDoor:
                Frame(level, chunkBox, x, y, z);
                PlaceBlock(level, Block.IronDoor.StateId, x + 1, y, z, chunkBox);
                PlaceBlock(level, Upper(Block.IronDoor), x + 1, y + 1, z, chunkBox);

                // The two buttons are on the far side of the frame from each other, one block outside
                // the piece's own doorway plane.
                PlaceBlock(level, Button(Direction.North), x + 2, y + 1, z + 1, chunkBox);
                PlaceBlock(level, Button(Direction.South), x + 2, y + 1, z - 1, chunkBox);
                break;
        }
    }

    /// <summary>The seven stone bricks around a door, which is the same for both door kinds.</summary>
    private void Frame(IFeatureLevel level, BoundingBox chunkBox, int x, int y, int z) {
        PlaceBlock(level, StoneBricks, x, y, z, chunkBox);
        PlaceBlock(level, StoneBricks, x, y + 1, z, chunkBox);
        PlaceBlock(level, StoneBricks, x, y + 2, z, chunkBox);
        PlaceBlock(level, StoneBricks, x + 1, y + 2, z, chunkBox);
        PlaceBlock(level, StoneBricks, x + 2, y + 2, z, chunkBox);
        PlaceBlock(level, StoneBricks, x + 2, y + 1, z, chunkBox);
        PlaceBlock(level, StoneBricks, x + 2, y, z, chunkBox);
    }

    private static uint Upper(IBlock door) {
        return ((IDoubleHalved)door).WithHalf(BlockHalf.Upper).StateId;
    }

    private static uint Button(Direction facing) {
        return ((IHorizontalFacing)Block.StoneButton).WithFacing(facing).StateId;
    }

    protected static uint Bars(params BlockFace[] sides) {
        IBlock bars = Block.IronBars;

        foreach (BlockFace side in sides) {
            bars = ((IFaceConnected)bars).WithConnection(side, true);
        }

        return bars.StateId;
    }

    /// <summary>
    /// Which doorway this piece got. Two in five are a plain opening, and the other three kinds are
    /// one each.
    /// </summary>
    protected static SmallDoorType RandomSmallDoor(RandomSource random) {
        return random.NextInt(5) switch {
            2 => SmallDoorType.WoodDoor,
            3 => SmallDoorType.Grates,
            4 => SmallDoorType.IronDoor,
            _ => SmallDoorType.Opening
        };
    }

    /// <summary>The piece straight on from this one.</summary>
    protected StructurePiece? GenerateSmallDoorChildForward(StrongholdStartPiece start,
        StructurePiecesBuilder builder, RandomSource random, int xOff, int yOff) {

        return Orientation switch {
            Direction.South => StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX + xOff, BoundingBox.MinY + yOff, BoundingBox.MaxZ + 1,
                Direction.South, GenDepth),

            Direction.West => StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX - 1, BoundingBox.MinY + yOff, BoundingBox.MinZ + xOff,
                Direction.West, GenDepth),

            Direction.East => StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MaxX + 1, BoundingBox.MinY + yOff, BoundingBox.MinZ + xOff,
                Direction.East, GenDepth),

            Direction.North => StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX + xOff, BoundingBox.MinY + yOff, BoundingBox.MinZ - 1,
                Direction.North, GenDepth),

            _ => null
        };
    }

    /// <summary>
    /// The piece out of this one's left wall.
    /// </summary>
    /// <remarks>
    /// North and south give the same answer, and so do west and east: what decides the branch is the
    /// <b>axis</b> the piece runs along, not which way along it. Vanilla writes all four cases out and
    /// two pairs of them are identical.
    /// </remarks>
    protected StructurePiece? GenerateSmallDoorChildLeft(StrongholdStartPiece start,
        StructurePiecesBuilder builder, RandomSource random, int yOff, int zOff) {

        if (Orientation is Direction.North or Direction.South) {
            return StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX - 1, BoundingBox.MinY + yOff, BoundingBox.MinZ + zOff,
                Direction.West, GenDepth);
        }

        if (Orientation is Direction.West or Direction.East) {
            return StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX + zOff, BoundingBox.MinY + yOff, BoundingBox.MinZ - 1,
                Direction.North, GenDepth);
        }

        return null;
    }

    /// <summary>The piece out of this one's right wall, on <see cref="GenerateSmallDoorChildLeft"/>'s rule.</summary>
    protected StructurePiece? GenerateSmallDoorChildRight(StrongholdStartPiece start,
        StructurePiecesBuilder builder, RandomSource random, int yOff, int zOff) {

        if (Orientation is Direction.North or Direction.South) {
            return StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MaxX + 1, BoundingBox.MinY + yOff, BoundingBox.MinZ + zOff,
                Direction.East, GenDepth);
        }

        if (Orientation is Direction.West or Direction.East) {
            return StrongholdPieces.GenerateAndAddPiece(start, builder, random,
                BoundingBox.MinX + zOff, BoundingBox.MinY + yOff, BoundingBox.MaxZ + 1,
                Direction.South, GenDepth);
        }

        return null;
    }

    /// <summary>
    /// Whether a box is deep enough into the world to build in.
    /// </summary>
    /// <remarks>
    /// Ten is an absolute y and not a depth below the surface, and it is tested <b>before</b> the
    /// whole stronghold is dropped by <c>moveBelowSeaLevel</c>. So it is measuring against the layout
    /// height of 64 rather than against where the piece ends up.
    /// </remarks>
    protected static bool IsOkBox(BoundingBox box) => box.MinY > 10;

    /// <summary>
    /// <c>SmoothStoneSelector</c>: the mix of cracked, mossy and infested bricks a stronghold wall is
    /// built from, with air inside.
    /// </summary>
    /// <remarks>
    /// One per placement rather than the single static instance vanilla keeps, because the field it
    /// carries between the two calls makes a shared one a race between chunks generating at once. It
    /// draws exactly the same numbers either way.
    /// </remarks>
    public sealed class SmoothStoneSelector : IBlockSelector {
        public uint Current { get; private set; }

        public void Next(RandomSource random, int x, int y, int z, bool edge) {
            if (!edge) {
                Current = Block.CaveAir.StateId;
                return;
            }

            float selection = random.NextFloat();

            Current = selection switch {
                < 0.2f => Block.CrackedStoneBricks.StateId,
                < 0.5f => Block.MossyStoneBricks.StateId,
                < 0.55f => Block.InfestedStoneBricks.StateId,
                _ => Block.StoneBricks.StateId
            };
        }
    }
}
