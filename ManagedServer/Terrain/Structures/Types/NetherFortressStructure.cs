using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>NetherFortressStructure</c>: the fortress, a bridge network with a castle hanging off it.
/// </summary>
/// <remarks>
/// <b>Two weighted tables, not one.</b> A piece asks for a bridge piece or a castle piece depending on
/// which side of the entrance it is, and the entrance is what crosses over. That is the whole of why a
/// fortress has an outside and an inside.
/// <p/>
/// Unlike the stronghold there is no retry: whatever the layout came out as is what the fortress is,
/// and it is dropped into a band rather than under the sea.
/// </remarks>
public sealed class NetherFortressStructure(Structure.StructureSettings settings)
    : Structure(settings) {

    /// <summary>The height the network is laid out around, before it is moved into its band.</summary>
    public const int MagicStartY = 64;

    protected override GenerationStub FindGenerationPoint(StructureGenerationContext context) {
        return new GenerationStub(
            new Vec3<int>(context.ChunkX << 4, MagicStartY, context.ChunkZ << 4),
            builder => GeneratePieces(builder, context));
    }

    private static void GeneratePieces(StructurePiecesBuilder builder,
        StructureGenerationContext context) {

        NetherFortressStart start = new(context.Random, (context.ChunkX << 4) + 2,
            (context.ChunkZ << 4) + 2);

        builder.AddPiece(start);
        start.AddChildren(start, builder, context.Random);

        // Breadth first with the order drawn for, as the stronghold does it.
        List<StructurePiece> pending = start.PendingChildren;

        while (pending.Count > 0) {
            int index = context.Random.NextInt(pending.Count);
            StructurePiece piece = pending[index];
            pending.RemoveAt(index);
            piece.AddChildren(start, builder, context.Random);
        }

        // A band rather than a depth below the sea: the nether has no sea level worth measuring
        // against, so a fortress simply sits somewhere in the middle of it.
        builder.MoveInsideHeights(context.Random, 48, 70);
    }
}

/// <summary>Which of the thirteen fortress pieces a weighted entry stands for.</summary>
public enum FortressPieceKind {
    BridgeStraight,
    BridgeCrossing,
    RoomCrossing,
    StairsRoom,
    MonsterThrone,
    CastleEntrance,
    CastleSmallCorridor,
    CastleSmallCorridorCrossing,
    CastleSmallCorridorRightTurn,
    CastleSmallCorridorLeftTurn,
    CastleCorridorStairs,
    CastleCorridorTBalcony,
    CastleStalkRoom
}

/// <summary>
/// One entry of a fortress's weighted table.
/// </summary>
/// <remarks>
/// <see cref="AllowInRow"/> is the fortress's own: most pieces may not follow themselves, and the two
/// straight runs plus the corridor stairs may, which is what lets a bridge actually be long.
/// </remarks>
public sealed class FortressPieceWeight(FortressPieceKind kind, int weight, int maxPlaceCount,
    bool allowInRow = false) {

    public FortressPieceKind Kind => kind;
    public int Weight => weight;
    public int PlaceCount { get; set; }
    public bool AllowInRow => allowInRow;

    public bool IsValid => maxPlaceCount == 0 || PlaceCount < maxPlaceCount;

    public bool HasLimit => maxPlaceCount > 0;
}

/// <summary>
/// <c>NetherFortressPieces.NetherBridgePiece</c>: the child placement every fortress piece shares.
/// </summary>
public abstract class NetherBridgePiece(int genDepth, BoundingBox boundingBox)
    : StructurePiece(genDepth, boundingBox) {

    private const int MaxDepth = 30;

    /// <summary>How far from the start crossing a piece may be, on either horizontal axis.</summary>
    private const int MaxDistanceFromStart = 112;

    protected static uint Bricks => Block.NetherBricks.StateId;

    protected static uint Air => Block.Air.StateId;

    /// <summary>A nether brick fence connected on the named sides.</summary>
    protected static uint Fence(params BlockFace[] sides) {
        IBlock fence = Block.NetherBrickFence;

        foreach (BlockFace side in sides) {
            fence = ((IFaceConnected)fence).WithConnection(side, true);
        }

        return fence.StateId;
    }

    protected static uint Stairs(Direction facing) {
        return ((IHorizontalFacing)Block.NetherBrickStairs).WithFacing(facing).StateId;
    }

    protected static bool IsOkBox(BoundingBox box) => box.MinY > 10;

    /// <summary>
    /// The weighted draw over one of the two tables.
    /// </summary>
    /// <remarks>
    /// Five attempts, and a piece the table refuses, by its own limit or by being the one just placed,
    /// breaks the walk rather than falling through to the next entry, so an attempt can be spent on
    /// nothing. A piece that is allowed and does not fit is a different case and the walk continues.
    /// The fallback is a <b>bridge end filler</b>, the ragged stub that makes a bridge look broken off
    /// rather than cut square.
    /// </remarks>
    private NetherBridgePiece? GeneratePiece(NetherFortressStart start,
        List<FortressPieceWeight> available, StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int depth) {

        int totalWeight = UpdatePieceWeight(available);
        bool anyLeft = totalWeight > 0 && depth <= MaxDepth;

        for (int attempt = 0; attempt < 5 && anyLeft; attempt++) {
            int selection = random.NextInt(totalWeight);

            foreach (FortressPieceWeight piece in available) {
                selection -= piece.Weight;

                if (selection >= 0) {
                    continue;
                }

                if (!piece.IsValid || (piece == start.Previous && !piece.AllowInRow)) {
                    break;
                }

                NetherBridgePiece? built = FortressPieces.Create(piece.Kind, builder, random, footX,
                    footY, footZ, direction, depth);

                // The walk carries on where a piece is allowed and simply will not fit, with the
                // running total already negative, so the rest of the table is tried in order. Only the
                // table's own refusals above end the attempt.
                if (built is null) {
                    continue;
                }

                piece.PlaceCount++;
                start.Previous = piece;

                if (!piece.IsValid) {
                    available.Remove(piece);
                }

                return built;
            }
        }

        return BridgeEndFiller.Create(builder, random, footX, footY, footZ, direction, depth);
    }

    /// <summary>
    /// The total weight, or -1 where nothing limited is left to place.
    /// </summary>
    /// <remarks>
    /// The negative is what stops the draw entirely, so a table whose limited pieces are all used up
    /// stops the fortress growing rather than filling it with corridors.
    /// </remarks>
    private static int UpdatePieceWeight(List<FortressPieceWeight> available) {
        bool any = false;
        int total = 0;

        foreach (FortressPieceWeight piece in available) {
            if (piece.HasLimit && piece.IsValid) {
                any = true;
            }

            total += piece.Weight;
        }

        return any ? total : -1;
    }

    /// <summary>
    /// Builds and queues the next piece, from whichever table this side of the fortress uses.
    /// </summary>
    /// <remarks>
    /// A piece too far from the start still <b>builds</b> a filler, which is thrown away without being
    /// added. That draw happens either way, so skipping it moves every later piece.
    /// </remarks>
    private StructurePiece? GenerateAndAddPiece(NetherFortressStart start,
        StructurePiecesBuilder builder, RandomSource random, int footX, int footY, int footZ,
        Direction direction, int depth, bool isCastle) {

        if (Math.Abs(footX - start.BoundingBox.MinX) > MaxDistanceFromStart
            || Math.Abs(footZ - start.BoundingBox.MinZ) > MaxDistanceFromStart) {

            return BridgeEndFiller.Create(builder, random, footX, footY, footZ, direction, depth);
        }

        List<FortressPieceWeight> available = isCastle ? start.CastlePieces : start.BridgePieces;

        NetherBridgePiece? piece = GeneratePiece(start, available, builder, random, footX, footY,
            footZ, direction, depth + 1);

        if (piece is null) {
            return null;
        }

        builder.AddPiece(piece);
        start.PendingChildren.Add(piece);
        return piece;
    }

    protected StructurePiece? GenerateChildForward(NetherFortressStart start,
        StructurePiecesBuilder builder, RandomSource random, int xOff, int yOff, bool isCastle) {

        return Orientation switch {
            Direction.South => GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + xOff,
                BoundingBox.MinY + yOff, BoundingBox.MaxZ + 1, Direction.South, GenDepth, isCastle),

            Direction.West => GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                BoundingBox.MinY + yOff, BoundingBox.MinZ + xOff, Direction.West, GenDepth, isCastle),

            Direction.East => GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                BoundingBox.MinY + yOff, BoundingBox.MinZ + xOff, Direction.East, GenDepth, isCastle),

            Direction.North => GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + xOff,
                BoundingBox.MinY + yOff, BoundingBox.MinZ - 1, Direction.North, GenDepth, isCastle),

            _ => null
        };
    }

    /// <summary>
    /// The piece out of this one's left side. Which of the two answers is given depends on the axis
    /// rather than on the direction along it, as the stronghold's does.
    /// </summary>
    protected StructurePiece? GenerateChildLeft(NetherFortressStart start,
        StructurePiecesBuilder builder, RandomSource random, int yOff, int zOff, bool isCastle) {

        if (Orientation is Direction.North or Direction.South) {
            return GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                BoundingBox.MinY + yOff, BoundingBox.MinZ + zOff, Direction.West, GenDepth, isCastle);
        }

        if (Orientation is Direction.West or Direction.East) {
            return GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + zOff,
                BoundingBox.MinY + yOff, BoundingBox.MinZ - 1, Direction.North, GenDepth, isCastle);
        }

        return null;
    }

    protected StructurePiece? GenerateChildRight(NetherFortressStart start,
        StructurePiecesBuilder builder, RandomSource random, int yOff, int zOff, bool isCastle) {

        if (Orientation is Direction.North or Direction.South) {
            return GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                BoundingBox.MinY + yOff, BoundingBox.MinZ + zOff, Direction.East, GenDepth, isCastle);
        }

        if (Orientation is Direction.West or Direction.East) {
            return GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + zOff,
                BoundingBox.MinY + yOff, BoundingBox.MaxZ + 1, Direction.South, GenDepth, isCastle);
        }

        return null;
    }

    /// <summary>Fills the whole floor of the piece down to whatever it is standing over.</summary>
    protected void FillColumnsDown(IFeatureLevel level, BoundingBox chunkBox, int x0, int x1, int z0,
        int z1) {

        for (int x = x0; x <= x1; x++) {
            for (int z = z0; z <= z1; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
            }
        }
    }

    /// <summary>
    /// The thirteen block tower the castle entrance and the stalk room are both built inside.
    /// </summary>
    /// <remarks>
    /// Vanilla writes this out twice, block for block the same but for the one fence over the gate. It
    /// is one method here because a difference introduced upstream would otherwise be invisible in
    /// whichever of the two nobody looked at.
    /// </remarks>
    protected void BuildTowerShell(IFeatureLevel level, BoundingBox chunkBox, bool gateFence) {
        GenerateBox(level, chunkBox, 0, 3, 0, 12, 4, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 5, 0, 12, 13, 12, Air, Air, false);
        GenerateBox(level, chunkBox, 0, 5, 0, 1, 12, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 11, 5, 0, 12, 12, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 11, 4, 12, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 8, 5, 11, 10, 12, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 9, 11, 7, 12, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 0, 4, 12, 1, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 8, 5, 0, 10, 12, 1, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 9, 0, 7, 12, 1, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 11, 2, 10, 12, 10, Bricks, Bricks, false);

        // The portcullis over the entrance's gate, which the stalk room does not have.
        if (gateFence) {
            uint plain = Block.NetherBrickFence.StateId;
            GenerateBox(level, chunkBox, 5, 8, 0, 7, 8, 0, plain, plain, false);
        }

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        // The battlements: a fence pair every other block, with a brick merlon between them and a
        // connecting fence in the gaps.
        for (int i = 1; i <= 11; i += 2) {
            GenerateBox(level, chunkBox, i, 10, 0, i, 11, 0, westEast, westEast, false);
            GenerateBox(level, chunkBox, i, 10, 12, i, 11, 12, westEast, westEast, false);
            GenerateBox(level, chunkBox, 0, 10, i, 0, 11, i, northSouth, northSouth, false);
            GenerateBox(level, chunkBox, 12, 10, i, 12, 11, i, northSouth, northSouth, false);
            PlaceBlock(level, Bricks, i, 13, 0, chunkBox);
            PlaceBlock(level, Bricks, i, 13, 12, chunkBox);
            PlaceBlock(level, Bricks, 0, 13, i, chunkBox);
            PlaceBlock(level, Bricks, 12, 13, i, chunkBox);

            if (i != 11) {
                PlaceBlock(level, westEast, i + 1, 13, 0, chunkBox);
                PlaceBlock(level, westEast, i + 1, 13, 12, chunkBox);
                PlaceBlock(level, northSouth, 0, 13, i + 1, chunkBox);
                PlaceBlock(level, northSouth, 12, 13, i + 1, chunkBox);
            }
        }

        PlaceBlock(level, Fence(BlockFace.NegZ, BlockFace.PosX), 0, 13, 0, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosZ, BlockFace.PosX), 0, 13, 12, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosZ, BlockFace.NegX), 12, 13, 12, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegZ, BlockFace.NegX), 12, 13, 0, chunkBox);

        uint westSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX);
        uint eastSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.PosX);

        for (int z = 3; z <= 9; z += 2) {
            GenerateBox(level, chunkBox, 1, 7, z, 1, 8, z, westSide, westSide, false);
            GenerateBox(level, chunkBox, 11, 7, z, 11, 8, z, eastSide, eastSide, false);
        }
    }

    /// <summary>The tower's cross shaped base and the legs under it.</summary>
    protected void BuildTowerFooting(IFeatureLevel level, BoundingBox chunkBox) {
        GenerateBox(level, chunkBox, 4, 2, 0, 8, 2, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 4, 12, 2, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 0, 0, 8, 1, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 0, 9, 8, 1, 12, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 0, 4, 3, 1, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 9, 0, 4, 12, 1, 8, Bricks, Bricks, false);

        for (int x = 4; x <= 8; x++) {
            for (int z = 0; z <= 2; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
                FillColumnDown(level, Bricks, x, -1, 12 - z, chunkBox);
            }
        }

        for (int x = 0; x <= 2; x++) {
            for (int z = 4; z <= 8; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
                FillColumnDown(level, Bricks, 12 - x, -1, z, chunkBox);
            }
        }
    }
}

/// <summary>
/// <c>NetherFortressPieces.StartPiece</c>: the first crossing, and the owner of both weighted tables.
/// </summary>
/// <remarks>
/// The tables live here rather than being static arrays reset per fortress, which is what vanilla
/// does. Two chunks laying fortresses out at once would share those counters, and the pass runs on the
/// thread pool.
/// </remarks>
public sealed class NetherFortressStart : BridgeCrossing {
    public NetherFortressStart(RandomSource random, int west, int north)
        : base(west, north, RandomHorizontalDirection(random)) { }

    /// <summary>
    /// The outside of the fortress: bridges, the rooms hanging off them, and the one castle entrance.
    /// </summary>
    public readonly List<FortressPieceWeight> BridgePieces = [
        new(FortressPieceKind.BridgeStraight, 30, 0, true),
        new(FortressPieceKind.BridgeCrossing, 10, 4),
        new(FortressPieceKind.RoomCrossing, 10, 4),
        new(FortressPieceKind.StairsRoom, 10, 3),
        new(FortressPieceKind.MonsterThrone, 5, 2),
        new(FortressPieceKind.CastleEntrance, 5, 1)
    ];

    /// <summary>The inside, which nothing reaches until a castle entrance has been placed.</summary>
    public readonly List<FortressPieceWeight> CastlePieces = [
        new(FortressPieceKind.CastleSmallCorridor, 25, 0, true),
        new(FortressPieceKind.CastleSmallCorridorCrossing, 15, 5),
        new(FortressPieceKind.CastleSmallCorridorRightTurn, 5, 10),
        new(FortressPieceKind.CastleSmallCorridorLeftTurn, 5, 10),
        new(FortressPieceKind.CastleCorridorStairs, 10, 3, true),
        new(FortressPieceKind.CastleCorridorTBalcony, 7, 2),
        new(FortressPieceKind.CastleStalkRoom, 5, 2)
    ];

    public FortressPieceWeight? Previous { get; set; }

    public readonly List<StructurePiece> PendingChildren = [];
}

/// <summary>Builds a fortress piece of a named kind.</summary>
public static class FortressPieces {
    public static NetherBridgePiece? Create(FortressPieceKind kind, StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int depth) {

        return kind switch {
            FortressPieceKind.BridgeStraight =>
                BridgeStraight.Create(builder, random, footX, footY, footZ, direction, depth),
            FortressPieceKind.BridgeCrossing =>
                BridgeCrossing.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.RoomCrossing =>
                FortressRoomCrossing.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.StairsRoom =>
                FortressStairsRoom.Create(builder, footX, footY, footZ, depth, direction),
            FortressPieceKind.MonsterThrone =>
                MonsterThrone.Create(builder, footX, footY, footZ, depth, direction),
            FortressPieceKind.CastleEntrance =>
                CastleEntrance.Create(builder, random, footX, footY, footZ, direction, depth),
            FortressPieceKind.CastleSmallCorridor =>
                CastleSmallCorridor.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.CastleSmallCorridorCrossing =>
                CastleSmallCorridorCrossing.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.CastleSmallCorridorRightTurn =>
                CastleSmallCorridorRightTurn.Create(builder, random, footX, footY, footZ, direction,
                    depth),
            FortressPieceKind.CastleSmallCorridorLeftTurn =>
                CastleSmallCorridorLeftTurn.Create(builder, random, footX, footY, footZ, direction,
                    depth),
            FortressPieceKind.CastleCorridorStairs =>
                CastleCorridorStairs.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.CastleCorridorTBalcony =>
                CastleCorridorTBalcony.Create(builder, footX, footY, footZ, direction, depth),
            FortressPieceKind.CastleStalkRoom =>
                CastleStalkRoom.Create(builder, footX, footY, footZ, direction, depth),

            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Unknown fortress piece.")
        };
    }
}

/// <summary><c>BridgeCrossing</c>: where two bridges meet, and the shape a fortress starts as.</summary>
public class BridgeCrossing : NetherBridgePiece {
    public BridgeCrossing(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    /// <summary>The start crossing, laid out around y 64 in world coordinates.</summary>
    protected BridgeCrossing(int west, int north, Direction direction)
        : base(0, MakeBoundingBox(west, NetherFortressStructure.MagicStartY, north, direction, 19, 10,
            19)) {

        Orientation = direction;
    }

    public static BridgeCrossing? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -8, -3, 0, 19, 10, 19, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new BridgeCrossing(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        NetherFortressStart origin = (NetherFortressStart)start;
        GenerateChildForward(origin, builder, random, 8, 3, false);
        GenerateChildLeft(origin, builder, random, 3, 8, false);
        GenerateChildRight(origin, builder, random, 3, 8, false);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        // The two decks, crossed, then the walkway hollowed out of each.
        GenerateBox(level, chunkBox, 7, 3, 0, 11, 4, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 3, 7, 18, 4, 11, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 8, 5, 0, 10, 7, 18, Air, Air, false);
        GenerateBox(level, chunkBox, 0, 5, 8, 18, 7, 10, Air, Air, false);

        GenerateBox(level, chunkBox, 7, 5, 0, 7, 5, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 7, 5, 11, 7, 5, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 11, 5, 0, 11, 5, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 11, 5, 11, 11, 5, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 5, 7, 7, 5, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 11, 5, 7, 18, 5, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 5, 11, 7, 5, 11, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 11, 5, 11, 18, 5, 11, Bricks, Bricks, false);

        // The thickened ends, which is what the legs are driven down from.
        GenerateBox(level, chunkBox, 7, 2, 0, 11, 2, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 7, 2, 13, 11, 2, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 7, 0, 0, 11, 1, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 7, 0, 15, 11, 1, 18, Bricks, Bricks, false);

        for (int x = 7; x <= 11; x++) {
            for (int z = 0; z <= 2; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
                FillColumnDown(level, Bricks, x, -1, 18 - z, chunkBox);
            }
        }

        GenerateBox(level, chunkBox, 0, 2, 7, 5, 2, 11, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 13, 2, 7, 18, 2, 11, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 0, 7, 3, 1, 11, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 15, 0, 7, 18, 1, 11, Bricks, Bricks, false);

        for (int x = 0; x <= 2; x++) {
            for (int z = 7; z <= 11; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
                FillColumnDown(level, Bricks, 18 - x, -1, z, chunkBox);
            }
        }
    }
}

/// <summary><c>BridgeStraight</c>: nineteen blocks of bridge with a railing.</summary>
public sealed class BridgeStraight : NetherBridgePiece {
    public BridgeStraight(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static BridgeStraight? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -3, 0, 5, 10, 19, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new BridgeStraight(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildForward((NetherFortressStart)start, builder, random, 1, 3, false);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 3, 0, 4, 4, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 5, 0, 3, 7, 18, Air, Air, false);
        GenerateBox(level, chunkBox, 0, 5, 0, 0, 5, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 5, 0, 4, 5, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 4, 2, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 13, 4, 2, 18, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 0, 0, 4, 1, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 0, 15, 4, 1, 18, Bricks, Bricks, false);

        for (int x = 0; x <= 4; x++) {
            for (int z = 0; z <= 2; z++) {
                FillColumnDown(level, Bricks, x, -1, z, chunkBox);
                FillColumnDown(level, Bricks, x, -1, 18 - z, chunkBox);
            }
        }

        uint westSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.PosX);
        uint eastSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX);

        GenerateBox(level, chunkBox, 0, 1, 1, 0, 4, 1, westSide, westSide, false);
        GenerateBox(level, chunkBox, 0, 3, 4, 0, 4, 4, westSide, westSide, false);
        GenerateBox(level, chunkBox, 0, 3, 14, 0, 4, 14, westSide, westSide, false);
        GenerateBox(level, chunkBox, 0, 1, 17, 0, 4, 17, westSide, westSide, false);
        GenerateBox(level, chunkBox, 4, 1, 1, 4, 4, 1, eastSide, eastSide, false);
        GenerateBox(level, chunkBox, 4, 3, 4, 4, 4, 4, eastSide, eastSide, false);
        GenerateBox(level, chunkBox, 4, 3, 14, 4, 4, 14, eastSide, eastSide, false);
        GenerateBox(level, chunkBox, 4, 1, 17, 4, 4, 17, eastSide, eastSide, false);
    }
}

/// <summary>
/// <c>BridgeEndFiller</c>: the ragged stub a bridge is left ending in.
/// </summary>
/// <remarks>
/// The only piece with a random of its own. It stores a seed at layout time and draws its jagged edge
/// from that at write time, so both halves of a stub across a chunk border tear the same way. That is
/// what a piece taking the pass's per chunk random could not do.
/// </remarks>
public sealed class BridgeEndFiller : NetherBridgePiece {
    private readonly int _selfSeed;

    public BridgeEndFiller(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        _selfSeed = random.NextInt();
    }

    public static BridgeEndFiller? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -3, 0, 5, 10, 8, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new BridgeEndFiller(genDepth, random, box, direction)
            : null;
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        // Vanilla's SingleThreadedRandomSource, which is LegacyRandomSource without the atomic: the
        // same scramble and the same next.
        RandomSource own = new LegacyRandomSource(_selfSeed);

        for (int x = 0; x <= 4; x++) {
            for (int y = 3; y <= 4; y++) {
                int length = own.NextInt(8);
                GenerateBox(level, chunkBox, x, y, 0, x, y, length, Bricks, Bricks, false);
            }
        }

        GenerateBox(level, chunkBox, 0, 5, 0, 0, 5, own.NextInt(8), Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 5, 0, 4, 5, own.NextInt(8), Bricks, Bricks, false);

        for (int x = 0; x <= 4; x++) {
            GenerateBox(level, chunkBox, x, 2, 0, x, 2, own.NextInt(5), Bricks, Bricks, false);
        }

        for (int x = 0; x <= 4; x++) {
            for (int y = 0; y <= 1; y++) {
                GenerateBox(level, chunkBox, x, y, 0, x, y, own.NextInt(3), Bricks, Bricks, false);
            }
        }
    }
}

/// <summary><c>RoomCrossing</c>: the open box where three bridges meet.</summary>
public sealed class FortressRoomCrossing : NetherBridgePiece {
    public FortressRoomCrossing(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static FortressRoomCrossing? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -2, 0, 0, 7, 9, 7, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new FortressRoomCrossing(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        NetherFortressStart origin = (NetherFortressStart)start;
        GenerateChildForward(origin, builder, random, 2, 0, false);
        GenerateChildLeft(origin, builder, random, 0, 2, false);
        GenerateChildRight(origin, builder, random, 0, 2, false);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 6, 1, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 6, 7, 6, Air, Air, false);

        // The four corner piers, leaving a gap in the middle of each wall for a doorway.
        GenerateBox(level, chunkBox, 0, 2, 0, 1, 6, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 6, 1, 6, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 2, 0, 6, 6, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 2, 6, 6, 6, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 6, 1, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 5, 0, 6, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 2, 0, 6, 6, 1, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 2, 5, 6, 6, 6, Bricks, Bricks, false);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 2, 6, 0, 4, 6, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 0, 4, 5, 0, westEast, westEast, false);
        GenerateBox(level, chunkBox, 2, 6, 6, 4, 6, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 6, 4, 5, 6, westEast, westEast, false);
        GenerateBox(level, chunkBox, 0, 6, 2, 0, 6, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 5, 2, 0, 5, 4, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 6, 6, 2, 6, 6, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 5, 2, 6, 5, 4, northSouth, northSouth, false);

        FillColumnsDown(level, chunkBox, 0, 6, 0, 6);
    }
}

/// <summary><c>StairsRoom</c>: the room whose staircase climbs to a doorway one storey up.</summary>
public sealed class FortressStairsRoom : NetherBridgePiece {
    public FortressStairsRoom(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static FortressStairsRoom? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, int genDepth, Direction direction) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -2, 0, 0, 7, 11, 7, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new FortressStairsRoom(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        // The only exit is out of the right wall, six blocks up, which is where the stairs arrive.
        GenerateChildRight((NetherFortressStart)start, builder, random, 6, 2, false);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 6, 1, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 6, 10, 6, Air, Air, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 1, 8, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 2, 0, 6, 8, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 1, 0, 8, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 2, 1, 6, 8, 6, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 2, 6, 5, 8, 6, Bricks, Bricks, false);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 0, 3, 2, 0, 5, 4, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 6, 3, 2, 6, 5, 2, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 6, 3, 4, 6, 5, 4, northSouth, northSouth, false);

        // The staircase, as five columns of decreasing height rather than as stair blocks.
        PlaceBlock(level, Bricks, 5, 2, 5, chunkBox);
        GenerateBox(level, chunkBox, 4, 2, 5, 4, 3, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 3, 2, 5, 3, 4, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 2, 5, 2, 5, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 2, 5, 1, 6, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 7, 1, 5, 7, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 8, 2, 6, 8, 4, Air, Air, false);
        GenerateBox(level, chunkBox, 2, 6, 0, 4, 8, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 0, 4, 5, 0, westEast, westEast, false);

        FillColumnsDown(level, chunkBox, 0, 6, 0, 6);
    }
}

/// <summary>
/// <c>MonsterThrone</c>: the blaze spawner platform, reached across an open span.
/// </summary>
public sealed class MonsterThrone : NetherBridgePiece {
    private bool _hasPlacedSpawner;

    public MonsterThrone(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static MonsterThrone? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, int genDepth, Direction direction) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -2, 0, 0, 7, 8, 9, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new MonsterThrone(genDepth, box, direction)
            : null;
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 2, 0, 6, 7, 7, Air, Air, false);
        GenerateBox(level, chunkBox, 1, 0, 0, 5, 1, 7, Bricks, Bricks, false);

        // The four stepped tiers of the throne.
        GenerateBox(level, chunkBox, 1, 2, 1, 5, 2, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 3, 2, 5, 3, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 4, 3, 5, 4, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 1, 4, 2, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 2, 0, 5, 4, 2, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 5, 2, 1, 5, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 5, 5, 2, 5, 5, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 5, 3, 0, 5, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 5, 3, 6, 5, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 5, 8, 5, 5, 8, Bricks, Bricks, false);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        PlaceBlock(level, Fence(BlockFace.NegX), 1, 6, 3, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosX), 5, 6, 3, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosX, BlockFace.NegZ), 0, 6, 3, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX, BlockFace.NegZ), 6, 6, 3, chunkBox);
        GenerateBox(level, chunkBox, 0, 6, 4, 0, 6, 7, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 6, 6, 4, 6, 6, 7, northSouth, northSouth, false);
        PlaceBlock(level, Fence(BlockFace.PosX, BlockFace.PosZ), 0, 6, 8, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX, BlockFace.PosZ), 6, 6, 8, chunkBox);
        GenerateBox(level, chunkBox, 1, 6, 8, 5, 6, 8, westEast, westEast, false);
        PlaceBlock(level, Fence(BlockFace.PosX), 1, 7, 8, chunkBox);
        GenerateBox(level, chunkBox, 2, 7, 8, 4, 7, 8, westEast, westEast, false);
        PlaceBlock(level, Fence(BlockFace.NegX), 5, 7, 8, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosX), 2, 8, 8, chunkBox);
        PlaceBlock(level, westEast, 3, 8, 8, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX), 4, 8, 8, chunkBox);

        if (!_hasPlacedSpawner) {
            Vec3<int> spawner = GetWorldPos(3, 5, 5);

            if (chunkBox.IsInside(spawner.X, spawner.Y, spawner.Z)) {
                _hasPlacedSpawner = true;

                // The block and not the blaze. A spawner's entity type lives on a block entity and
                // there is no port of one, the same gap that leaves every structure chest empty.
                level.SetState(spawner.X, spawner.Y, spawner.Z, Block.Spawner.StateId);
            }
        }

        FillColumnsDown(level, chunkBox, 0, 6, 0, 6);
    }
}

/// <summary>
/// <c>CastleEntrance</c>: the tower that turns a bridge into the castle, and the only piece that
/// switches which weighted table its children come from.
/// </summary>
public sealed class CastleEntrance : NetherBridgePiece {
    public CastleEntrance(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleEntrance? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -5, -3, 0, 13, 14, 13, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleEntrance(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildForward((NetherFortressStart)start, builder, random, 5, 3, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        BuildTowerShell(level, chunkBox, gateFence: true);
        BuildTowerFooting(level, chunkBox);

        // The lava well in the middle, which is what makes an entrance rather than a stalk room.
        GenerateBox(level, chunkBox, 5, 5, 5, 7, 5, 7, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 1, 6, 6, 4, 6, Air, Air, false);
        PlaceBlock(level, Bricks, 6, 0, 6, chunkBox);

        // The source block and not the fall. Vanilla schedules a fluid tick here and there is no block
        // tick scheduler in the generator, so the lava stays exactly where it is written.
        PlaceBlock(level, Block.Lava.StateId, 6, 5, 6, chunkBox);
    }
}

/// <summary>
/// <c>CastleStalkRoom</c>: the nether wart farm, which is the castle entrance's shell with a staircase
/// and two beds of soul sand in it.
/// </summary>
public sealed class CastleStalkRoom : NetherBridgePiece {
    public CastleStalkRoom(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleStalkRoom? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -5, -3, 0, 13, 14, 13, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleStalkRoom(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        // Two exits out of the same wall at different heights, which is what the staircase connects.
        NetherFortressStart origin = (NetherFortressStart)start;
        GenerateChildForward(origin, builder, random, 5, 3, true);
        GenerateChildForward(origin, builder, random, 5, 11, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        BuildTowerShell(level, chunkBox, gateFence: false);

        uint westSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX);
        uint eastSide = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.PosX);
        uint north = Stairs(Direction.North);

        // The staircase, climbing one block per step with the wall behind it growing to match.
        for (int step = 0; step <= 6; step++) {
            int z = step + 4;

            for (int x = 5; x <= 7; x++) {
                PlaceBlock(level, north, x, 5 + step, z, chunkBox);
            }

            if (z is >= 5 and <= 8) {
                GenerateBox(level, chunkBox, 5, 5, z, 7, step + 4, z, Bricks, Bricks, false);
            } else if (z is >= 9 and <= 10) {
                GenerateBox(level, chunkBox, 5, 8, z, 7, step + 4, z, Bricks, Bricks, false);
            }

            if (step >= 1) {
                GenerateBox(level, chunkBox, 5, 6 + step, z, 7, 9 + step, z, Air, Air, false);
            }
        }

        for (int x = 5; x <= 7; x++) {
            PlaceBlock(level, north, x, 12, 11, chunkBox);
        }

        GenerateBox(level, chunkBox, 5, 6, 7, 5, 7, 7, eastSide, eastSide, false);
        GenerateBox(level, chunkBox, 7, 6, 7, 7, 7, 7, westSide, westSide, false);
        GenerateBox(level, chunkBox, 5, 13, 12, 7, 13, 12, Air, Air, false);

        GenerateBox(level, chunkBox, 2, 5, 2, 3, 5, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 9, 3, 5, 10, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 2, 5, 4, 2, 5, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 9, 5, 2, 10, 5, 3, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 9, 5, 9, 10, 5, 10, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 10, 5, 4, 10, 5, 8, Bricks, Bricks, false);

        uint east = Stairs(Direction.East);
        uint west = Stairs(Direction.West);

        PlaceBlock(level, west, 4, 5, 2, chunkBox);
        PlaceBlock(level, west, 4, 5, 3, chunkBox);
        PlaceBlock(level, west, 4, 5, 9, chunkBox);
        PlaceBlock(level, west, 4, 5, 10, chunkBox);
        PlaceBlock(level, east, 8, 5, 2, chunkBox);
        PlaceBlock(level, east, 8, 5, 3, chunkBox);
        PlaceBlock(level, east, 8, 5, 9, chunkBox);
        PlaceBlock(level, east, 8, 5, 10, chunkBox);

        uint soulSand = Block.SoulSand.StateId;
        uint wart = Block.NetherWart.StateId;

        GenerateBox(level, chunkBox, 3, 4, 4, 4, 4, 8, soulSand, soulSand, false);
        GenerateBox(level, chunkBox, 8, 4, 4, 9, 4, 8, soulSand, soulSand, false);

        // Age zero, since there is no growth tick to advance it. Same choice the growing plants make.
        GenerateBox(level, chunkBox, 3, 5, 4, 4, 5, 8, wart, wart, false);
        GenerateBox(level, chunkBox, 8, 5, 4, 9, 5, 8, wart, wart, false);

        BuildTowerFooting(level, chunkBox);
    }
}
