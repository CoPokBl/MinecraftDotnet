using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>StrongholdPieces</c>: how a stronghold picks the next piece to attach.
/// </summary>
/// <remarks>
/// The draw is weighted, and the weights <b>change as the stronghold grows</b>: an entry that runs out
/// of placements is removed from the table entirely, which moves every later draw. That plus the
/// breadth first order is the whole of why two strongholds look different.
/// </remarks>
public static class StrongholdPieces {
    private const int MaxDepth = 50;

    /// <summary>How far from the staircase a piece may be, on either horizontal axis.</summary>
    private const int MaxDistanceFromStart = 112;

    /// <summary>Builds one piece of a named kind, or null where it will not fit.</summary>
    private static StrongholdPiece? Create(StrongholdPieceKind kind, StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int depth) {

        return kind switch {
            StrongholdPieceKind.Straight =>
                StrongholdStraight.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.PrisonHall =>
                StrongholdPrisonHall.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.LeftTurn =>
                StrongholdLeftTurn.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.RightTurn =>
                StrongholdRightTurn.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.RoomCrossing =>
                StrongholdRoomCrossing.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.StraightStairsDown =>
                StrongholdStraightStairsDown.Create(builder, random, footX, footY, footZ, direction,
                    depth),
            StrongholdPieceKind.StairsDown =>
                StrongholdStairsDown.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.FiveCrossing =>
                StrongholdFiveCrossing.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.ChestCorridor =>
                StrongholdChestCorridor.Create(builder, random, footX, footY, footZ, direction, depth),
            StrongholdPieceKind.Library =>
                StrongholdLibrary.Create(builder, random, footX, footY, footZ, direction, depth),

            // The one that takes no random: its shape has nothing to vary.
            StrongholdPieceKind.PortalRoom =>
                StrongholdPortalRoom.Create(builder, footX, footY, footZ, direction, depth),

            _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, "Unknown stronghold piece.")
        };
    }

    /// <summary>
    /// The weighted draw, and the filler corridor it falls back to.
    /// </summary>
    /// <remarks>
    /// Five attempts, and each attempt walks the table subtracting weights until it goes negative.
    /// Hitting a piece the table itself refuses, by its own limit or by being the one just placed,
    /// <b>breaks out of the walk</b> rather than carrying on, so that attempt is spent: the table is not
    /// a distribution over placeable pieces, it is a distribution over all of them with the refused
    /// ones wasting a try. A piece that is allowed and simply does not fit is the other case and does
    /// not end the attempt: the walk goes on to the next entry with the total already negative, so the
    /// rest of the table is tried in order.
    /// <p/>
    /// The fallback is a filler corridor, which is the short stub that seals a passage against a piece
    /// already standing there. Without it a stronghold would have corridors ending in open stone.
    /// </remarks>
    private static StrongholdPiece? GenerateFromSmallDoor(StrongholdStartPiece start,
        StructurePiecesBuilder builder, RandomSource random, int footX, int footY, int footZ,
        Direction direction, int depth) {

        StrongholdLayout layout = start.Layout;

        if (!layout.UpdatePieceWeight()) {
            return null;
        }

        if (layout.Imposed is { } imposed) {
            StrongholdPiece? forced = Create(imposed, builder, random, footX, footY, footZ, direction,
                depth);

            // Cleared whether or not it could be built, so a staircase that could not open onto a
            // five way crossing does not force one on the next piece instead.
            layout.Imposed = null;

            if (forced is not null) {
                return forced;
            }
        }

        for (int attempt = 0; attempt < 5; attempt++) {
            int selection = random.NextInt(layout.TotalWeight);

            foreach (StrongholdPieceWeight piece in layout.Available) {
                selection -= piece.Weight;

                if (selection >= 0) {
                    continue;
                }

                if (!piece.DoPlace(depth) || piece == layout.Previous) {
                    break;
                }

                StrongholdPiece? built = Create(piece.Kind, builder, random, footX, footY, footZ,
                    direction, depth);

                // A piece that will not fit does not end the attempt: the walk carries on to the next
                // entry, and the running total is already negative, so every remaining entry is tried
                // in table order until one builds. Only a piece refused by its own limit or by being
                // the previous one breaks out.
                if (built is null) {
                    continue;
                }

                piece.PlaceCount++;
                layout.Previous = piece;

                if (!piece.IsValid) {
                    layout.Available.Remove(piece);
                }

                return built;
            }
        }

        BoundingBox? filler = StrongholdFillerCorridor.FindPieceBox(builder, random, footX, footY,
            footZ, direction);

        return filler is not null && filler.MinY > 1
            ? new StrongholdFillerCorridor(depth, filler, direction)
            : null;
    }

    /// <summary>
    /// Builds the next piece, adds it, and queues it to grow its own children later.
    /// </summary>
    /// <remarks>
    /// Unlike the mineshaft this does <b>not</b> recurse. The new piece goes on the pending list and
    /// the structure drains that list in a random order afterwards, which is what makes a stronghold
    /// spread out from the staircase rather than running one corridor to its depth limit first.
    /// </remarks>
    public static StructurePiece? GenerateAndAddPiece(StrongholdStartPiece start,
        StructurePiecesBuilder builder, RandomSource random, int footX, int footY, int footZ,
        Direction direction, int depth) {

        if (depth > MaxDepth) {
            return null;
        }

        if (Math.Abs(footX - start.BoundingBox.MinX) > MaxDistanceFromStart
            || Math.Abs(footZ - start.BoundingBox.MinZ) > MaxDistanceFromStart) {

            return null;
        }

        StrongholdPiece? piece = GenerateFromSmallDoor(start, builder, random, footX, footY, footZ,
            direction, depth + 1);

        if (piece is null) {
            return null;
        }

        builder.AddPiece(piece);
        start.Layout.PendingChildren.Add(piece);
        return piece;
    }
}

/// <summary>
/// <c>StrongholdPieces.Straight</c>: five by five by seven of plain corridor, with up to two side
/// openings.
/// </summary>
public sealed class StrongholdStraight : StrongholdPiece {
    private readonly bool _leftChild;
    private readonly bool _rightChild;

    public StrongholdStraight(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
        _leftChild = random.NextInt(2) == 0;
        _rightChild = random.NextInt(2) == 0;
    }

    public static StrongholdStraight? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, 7, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdStraight(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        StrongholdStartPiece origin = (StrongholdStartPiece)start;
        GenerateSmallDoorChildForward(origin, builder, random, 1, 1);

        if (_leftChild) {
            GenerateSmallDoorChildLeft(origin, builder, random, 1, 2);
        }

        if (_rightChild) {
            GenerateSmallDoorChildRight(origin, builder, random, 1, 2);
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 4, 6, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 1, 0);
        GenerateSmallDoor(level, random, chunkBox, SmallDoorType.Opening, 1, 1, 6);

        uint east = Torch(Direction.East);
        uint west = Torch(Direction.West);

        MaybeGenerateBlock(level, chunkBox, random, 0.1f, 1, 2, 1, east);
        MaybeGenerateBlock(level, chunkBox, random, 0.1f, 3, 2, 1, west);
        MaybeGenerateBlock(level, chunkBox, random, 0.1f, 1, 2, 5, east);
        MaybeGenerateBlock(level, chunkBox, random, 0.1f, 3, 2, 5, west);

        if (_leftChild) {
            GenerateBox(level, chunkBox, 0, 1, 2, 0, 3, 4, CaveAir, CaveAir, false);
        }

        if (_rightChild) {
            GenerateBox(level, chunkBox, 4, 1, 2, 4, 3, 4, CaveAir, CaveAir, false);
        }
    }

    internal static uint Torch(Direction facing) {
        return ((IHorizontalFacing)Block.WallTorch).WithFacing(facing).StateId;
    }
}

/// <summary>
/// <c>StrongholdPieces.PrisonHall</c>: the barred cells, the one piece with iron doors in it.
/// </summary>
public sealed class StrongholdPrisonHall : StrongholdPiece {
    public StrongholdPrisonHall(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    public static StrongholdPrisonHall? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 9, 5, 11, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdPrisonHall(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateSmallDoorChildForward((StrongholdStartPiece)start, builder, random, 1, 1);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        SmoothStoneSelector selector = new();

        GenerateBox(level, chunkBox, 0, 0, 0, 8, 4, 10, true, random, selector);
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 1, 0);
        GenerateBox(level, chunkBox, 1, 1, 10, 3, 3, 10, CaveAir, CaveAir, false);

        // The four stubs of wall the cell fronts hang between.
        GenerateBox(level, chunkBox, 4, 1, 1, 4, 3, 1, false, random, selector);
        GenerateBox(level, chunkBox, 4, 1, 3, 4, 3, 3, false, random, selector);
        GenerateBox(level, chunkBox, 4, 1, 7, 4, 3, 7, false, random, selector);
        GenerateBox(level, chunkBox, 4, 1, 9, 4, 3, 9, false, random, selector);

        uint northSouth = Bars(BlockFace.NegZ, BlockFace.PosZ);
        uint westEast = Bars(BlockFace.NegX, BlockFace.PosX);

        for (int y = 1; y <= 3; y++) {
            PlaceBlock(level, northSouth, 4, y, 4, chunkBox);
            PlaceBlock(level, Bars(BlockFace.NegZ, BlockFace.PosZ, BlockFace.PosX), 4, y, 5, chunkBox);
            PlaceBlock(level, northSouth, 4, y, 6, chunkBox);
            PlaceBlock(level, westEast, 5, y, 5, chunkBox);
            PlaceBlock(level, westEast, 6, y, 5, chunkBox);
            PlaceBlock(level, westEast, 7, y, 5, chunkBox);
        }

        PlaceBlock(level, northSouth, 4, 3, 2, chunkBox);
        PlaceBlock(level, northSouth, 4, 3, 8, chunkBox);

        uint lower = ((IHorizontalFacing)Block.IronDoor).WithFacing(Direction.West).StateId;
        uint upper = ((IDoubleHalved)((IHorizontalFacing)Block.IronDoor).WithFacing(Direction.West))
            .WithHalf(BlockHalf.Upper).StateId;

        PlaceBlock(level, lower, 4, 1, 2, chunkBox);
        PlaceBlock(level, upper, 4, 2, 2, chunkBox);
        PlaceBlock(level, lower, 4, 1, 8, chunkBox);
        PlaceBlock(level, upper, 4, 2, 8, chunkBox);
    }
}

/// <summary>
/// <c>StrongholdPieces.LeftTurn</c>: a five cube with one wall opened, and its mirror image.
/// </summary>
/// <remarks>
/// Which wall opens depends on the facing, and the two turn classes are the same body with the test
/// inverted. Both sit on <c>Turn</c> upstream, which adds nothing but the shared dimensions.
/// </remarks>
public sealed class StrongholdLeftTurn : StrongholdPiece {
    public StrongholdLeftTurn(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    public static StrongholdLeftTurn? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdLeftTurn(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        StrongholdStartPiece origin = (StrongholdStartPiece)start;

        if (Orientation is Direction.North or Direction.East) {
            GenerateSmallDoorChildLeft(origin, builder, random, 1, 1);
        } else {
            GenerateSmallDoorChildRight(origin, builder, random, 1, 1);
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 4, 4, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 1, 0);

        if (Orientation is Direction.North or Direction.East) {
            GenerateBox(level, chunkBox, 0, 1, 1, 0, 3, 3, CaveAir, CaveAir, false);
        } else {
            GenerateBox(level, chunkBox, 4, 1, 1, 4, 3, 3, CaveAir, CaveAir, false);
        }
    }
}

/// <summary><c>StrongholdPieces.RightTurn</c>: <see cref="StrongholdLeftTurn"/> the other way round.</summary>
public sealed class StrongholdRightTurn : StrongholdPiece {
    public StrongholdRightTurn(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    public static StrongholdRightTurn? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdRightTurn(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        StrongholdStartPiece origin = (StrongholdStartPiece)start;

        if (Orientation is Direction.North or Direction.East) {
            GenerateSmallDoorChildRight(origin, builder, random, 1, 1);
        } else {
            GenerateSmallDoorChildLeft(origin, builder, random, 1, 1);
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 4, 4, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 1, 0);

        if (Orientation is Direction.North or Direction.East) {
            GenerateBox(level, chunkBox, 4, 1, 1, 4, 3, 3, CaveAir, CaveAir, false);
        } else {
            GenerateBox(level, chunkBox, 0, 1, 1, 0, 3, 3, CaveAir, CaveAir, false);
        }
    }
}

/// <summary>
/// <c>StrongholdPieces.RoomCrossing</c>: the big room, in one of five decorations.
/// </summary>
/// <remarks>
/// Five types are drawn for and only three of them furnish anything, so two in five rooms are simply
/// empty. That is upstream rather than a gap: the switch has no cases for three and four.
/// </remarks>
public sealed class StrongholdRoomCrossing : StrongholdPiece {
    private readonly int _type;

    public StrongholdRoomCrossing(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
        _type = random.NextInt(5);
    }

    public static StrongholdRoomCrossing? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -4, -1, 0, 11, 7, 11, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdRoomCrossing(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        StrongholdStartPiece origin = (StrongholdStartPiece)start;
        GenerateSmallDoorChildForward(origin, builder, random, 4, 1);
        GenerateSmallDoorChildLeft(origin, builder, random, 1, 4);
        GenerateSmallDoorChildRight(origin, builder, random, 1, 4);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 10, 6, 10, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 4, 1, 0);
        GenerateBox(level, chunkBox, 4, 1, 10, 6, 3, 10, CaveAir, CaveAir, false);
        GenerateBox(level, chunkBox, 0, 1, 4, 0, 3, 6, CaveAir, CaveAir, false);
        GenerateBox(level, chunkBox, 10, 1, 4, 10, 3, 6, CaveAir, CaveAir, false);

        switch (_type) {
            case 0:
                PlaceCentrePillar(level, chunkBox);
                break;

            case 1:
                PlaceFountain(level, chunkBox);
                break;

            case 2:
                PlaceUpperFloor(level, random, chunkBox);
                break;
        }
    }

    /// <summary>A stone brick pillar with a torch on each face and slabs around its foot.</summary>
    private void PlaceCentrePillar(IFeatureLevel level, BoundingBox chunkBox) {
        PlaceBlock(level, StoneBricks, 5, 1, 5, chunkBox);
        PlaceBlock(level, StoneBricks, 5, 2, 5, chunkBox);
        PlaceBlock(level, StoneBricks, 5, 3, 5, chunkBox);

        PlaceBlock(level, StrongholdStraight.Torch(Direction.West), 4, 3, 5, chunkBox);
        PlaceBlock(level, StrongholdStraight.Torch(Direction.East), 6, 3, 5, chunkBox);
        PlaceBlock(level, StrongholdStraight.Torch(Direction.South), 5, 3, 4, chunkBox);
        PlaceBlock(level, StrongholdStraight.Torch(Direction.North), 5, 3, 6, chunkBox);

        uint slab = Block.SmoothStoneSlab.StateId;
        PlaceBlock(level, slab, 4, 1, 4, chunkBox);
        PlaceBlock(level, slab, 4, 1, 5, chunkBox);
        PlaceBlock(level, slab, 4, 1, 6, chunkBox);
        PlaceBlock(level, slab, 6, 1, 4, chunkBox);
        PlaceBlock(level, slab, 6, 1, 5, chunkBox);
        PlaceBlock(level, slab, 6, 1, 6, chunkBox);
        PlaceBlock(level, slab, 5, 1, 4, chunkBox);
        PlaceBlock(level, slab, 5, 1, 6, chunkBox);
    }

    /// <summary>A square of bricks with a water source on a pillar in the middle.</summary>
    private void PlaceFountain(IFeatureLevel level, BoundingBox chunkBox) {
        for (int offset = 0; offset < 5; offset++) {
            PlaceBlock(level, StoneBricks, 3, 1, 3 + offset, chunkBox);
            PlaceBlock(level, StoneBricks, 7, 1, 3 + offset, chunkBox);
            PlaceBlock(level, StoneBricks, 3 + offset, 1, 3, chunkBox);
            PlaceBlock(level, StoneBricks, 3 + offset, 1, 7, chunkBox);
        }

        PlaceBlock(level, StoneBricks, 5, 1, 5, chunkBox);
        PlaceBlock(level, StoneBricks, 5, 2, 5, chunkBox);
        PlaceBlock(level, StoneBricks, 5, 3, 5, chunkBox);

        // The source block and not the flow. There is no block tick scheduler here, so it never
        // spreads down the pillar; the same gap the springs and the carvers document.
        PlaceBlock(level, Block.Water.StateId, 5, 4, 5, chunkBox);
    }

    /// <summary>The cobblestone frame, the plank mezzanine, its ladder and the chest on top of it.</summary>
    private void PlaceUpperFloor(IFeatureLevel level, RandomSource random, BoundingBox chunkBox) {
        uint cobble = Block.Cobblestone.StateId;

        for (int z = 1; z <= 9; z++) {
            PlaceBlock(level, cobble, 1, 3, z, chunkBox);
            PlaceBlock(level, cobble, 9, 3, z, chunkBox);
        }

        for (int x = 1; x <= 9; x++) {
            PlaceBlock(level, cobble, x, 3, 1, chunkBox);
            PlaceBlock(level, cobble, x, 3, 9, chunkBox);
        }

        PlaceBlock(level, cobble, 5, 1, 4, chunkBox);
        PlaceBlock(level, cobble, 5, 1, 6, chunkBox);
        PlaceBlock(level, cobble, 5, 3, 4, chunkBox);
        PlaceBlock(level, cobble, 5, 3, 6, chunkBox);
        PlaceBlock(level, cobble, 4, 1, 5, chunkBox);
        PlaceBlock(level, cobble, 6, 1, 5, chunkBox);
        PlaceBlock(level, cobble, 4, 3, 5, chunkBox);
        PlaceBlock(level, cobble, 6, 3, 5, chunkBox);

        for (int y = 1; y <= 3; y++) {
            PlaceBlock(level, cobble, 4, y, 4, chunkBox);
            PlaceBlock(level, cobble, 6, y, 4, chunkBox);
            PlaceBlock(level, cobble, 4, y, 6, chunkBox);
            PlaceBlock(level, cobble, 6, y, 6, chunkBox);
        }

        // The default wall torch, which faces north. Vanilla writes it without a facing here and with
        // one everywhere else.
        PlaceBlock(level, Block.WallTorch.StateId, 5, 3, 5, chunkBox);

        uint planks = Block.OakPlanks.StateId;

        for (int z = 2; z <= 8; z++) {
            PlaceBlock(level, planks, 2, 3, z, chunkBox);
            PlaceBlock(level, planks, 3, 3, z, chunkBox);

            // The middle three columns are left open around the pillar, which is the hole the ladder
            // comes up through.
            if (z <= 3 || z >= 7) {
                PlaceBlock(level, planks, 4, 3, z, chunkBox);
                PlaceBlock(level, planks, 5, 3, z, chunkBox);
                PlaceBlock(level, planks, 6, 3, z, chunkBox);
            }

            PlaceBlock(level, planks, 7, 3, z, chunkBox);
            PlaceBlock(level, planks, 8, 3, z, chunkBox);
        }

        uint ladder = ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.West).StateId;
        PlaceBlock(level, ladder, 9, 1, 3, chunkBox);
        PlaceBlock(level, ladder, 9, 2, 3, chunkBox);
        PlaceBlock(level, ladder, 9, 3, 3, chunkBox);

        CreateChest(level, chunkBox, random, 3, 4, 8);
    }
}

/// <summary>
/// <c>StrongholdPieces.ChestCorridor</c>: a straight run with an alcove and a chest in it.
/// </summary>
public sealed class StrongholdChestCorridor : StrongholdPiece {
    private bool _hasPlacedChest;

    public StrongholdChestCorridor(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    public static StrongholdChestCorridor? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, 7, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdChestCorridor(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateSmallDoorChildForward((StrongholdStartPiece)start, builder, random, 1, 1);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 4, 6, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 1, 0);
        GenerateSmallDoor(level, random, chunkBox, SmallDoorType.Opening, 1, 1, 6);
        GenerateBox(level, chunkBox, 3, 1, 2, 3, 1, 4, StoneBricks, StoneBricks, false);

        uint slab = Block.StoneBrickSlab.StateId;
        PlaceBlock(level, slab, 3, 1, 1, chunkBox);
        PlaceBlock(level, slab, 3, 1, 5, chunkBox);
        PlaceBlock(level, slab, 3, 2, 2, chunkBox);
        PlaceBlock(level, slab, 3, 2, 4, chunkBox);

        for (int z = 2; z <= 4; z++) {
            PlaceBlock(level, slab, 2, 1, z, chunkBox);
        }

        // Guarded so a corridor spanning two chunks does not place two chests. Vanilla persists the
        // flag; here it lives for as long as the cached start does, which is the same thing.
        if (_hasPlacedChest) {
            return;
        }

        Vec3<int> chest = GetWorldPos(3, 2, 3);

        if (chunkBox.IsInside(chest.X, chest.Y, chest.Z)) {
            _hasPlacedChest = true;
            CreateChest(level, chunkBox, random, 3, 2, 3);
        }
    }
}

/// <summary>
/// <c>StrongholdPieces.StraightStairsDown</c>: a flight of cobblestone stairs dropping six.
/// </summary>
public sealed class StrongholdStraightStairsDown : StrongholdPiece {
    public StrongholdStraightStairsDown(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    public static StrongholdStraightStairsDown? Create(StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -7, 0, 5, 11, 8, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdStraightStairsDown(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateSmallDoorChildForward((StrongholdStartPiece)start, builder, random, 1, 1);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 10, 7, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 7, 0);
        GenerateSmallDoor(level, random, chunkBox, SmallDoorType.Opening, 1, 1, 7);

        uint stairs = ((IHorizontalFacing)Block.CobblestoneStairs).WithFacing(Direction.South).StateId;

        for (int step = 0; step < 6; step++) {
            PlaceBlock(level, stairs, 1, 6 - step, 1 + step, chunkBox);
            PlaceBlock(level, stairs, 2, 6 - step, 1 + step, chunkBox);
            PlaceBlock(level, stairs, 3, 6 - step, 1 + step, chunkBox);

            // The last step needs nothing under it: it lands on the piece's own floor.
            if (step < 5) {
                PlaceBlock(level, StoneBricks, 1, 5 - step, 1 + step, chunkBox);
                PlaceBlock(level, StoneBricks, 2, 5 - step, 1 + step, chunkBox);
                PlaceBlock(level, StoneBricks, 3, 5 - step, 1 + step, chunkBox);
            }
        }
    }
}

/// <summary>
/// <c>StrongholdPieces.StairsDown</c>: the spiral staircase, which is also the shape the whole
/// stronghold starts as.
/// </summary>
public class StrongholdStairsDown : StrongholdPiece {
    private readonly bool _isSource;

    /// <summary>The one at the top of the stronghold, laid out around y 64 in world coordinates.</summary>
    protected StrongholdStairsDown(int genDepth, int west, int north, Direction direction)
        : base(genDepth, MakeBoundingBox(west, MagicStartY, north, direction, 5, 11, 5)) {

        _isSource = true;
        Orientation = direction;
        EntryDoor = SmallDoorType.Opening;
    }

    public StrongholdStairsDown(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        _isSource = false;
        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
    }

    /// <summary>The height the whole stronghold is laid out around before it is dropped.</summary>
    public const int MagicStartY = 64;

    public static StrongholdStairsDown? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -7, 0, 5, 11, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdStairsDown(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        StrongholdStartPiece origin = (StrongholdStartPiece)start;

        // The staircase at the top of the stronghold always opens onto a five way crossing, which is
        // the only use of the imposed piece.
        if (_isSource) {
            origin.Layout.Imposed = StrongholdPieceKind.FiveCrossing;
        }

        GenerateSmallDoorChildForward(origin, builder, random, 1, 1);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 10, 4, true, random, new SmoothStoneSelector());
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 1, 7, 0);
        GenerateSmallDoor(level, random, chunkBox, SmallDoorType.Opening, 1, 1, 4);

        // The spiral, written out step by step: a brick to stand on and a slab as the half step above
        // it, turning a quarter each time.
        uint slab = Block.SmoothStoneSlab.StateId;

        PlaceBlock(level, StoneBricks, 2, 6, 1, chunkBox);
        PlaceBlock(level, StoneBricks, 1, 5, 1, chunkBox);
        PlaceBlock(level, slab, 1, 6, 1, chunkBox);
        PlaceBlock(level, StoneBricks, 1, 5, 2, chunkBox);
        PlaceBlock(level, StoneBricks, 1, 4, 3, chunkBox);
        PlaceBlock(level, slab, 1, 5, 3, chunkBox);
        PlaceBlock(level, StoneBricks, 2, 4, 3, chunkBox);
        PlaceBlock(level, StoneBricks, 3, 3, 3, chunkBox);
        PlaceBlock(level, slab, 3, 4, 3, chunkBox);
        PlaceBlock(level, StoneBricks, 3, 3, 2, chunkBox);
        PlaceBlock(level, StoneBricks, 3, 2, 1, chunkBox);
        PlaceBlock(level, slab, 3, 3, 1, chunkBox);
        PlaceBlock(level, StoneBricks, 2, 2, 1, chunkBox);
        PlaceBlock(level, StoneBricks, 1, 1, 1, chunkBox);
        PlaceBlock(level, slab, 1, 2, 1, chunkBox);
        PlaceBlock(level, StoneBricks, 1, 1, 2, chunkBox);
        PlaceBlock(level, slab, 1, 1, 3, chunkBox);
    }
}

/// <summary>
/// <c>StrongholdPieces.StartPiece</c>: the staircase the stronghold grows from, and the owner of the
/// layout state.
/// </summary>
public sealed class StrongholdStartPiece(RandomSource random, int west, int north)
    : StrongholdStairsDown(0, west, north, RandomHorizontalDirection(random)) {

    /// <summary>
    /// The weighted table, the imposed piece and the pending list for this one stronghold.
    /// </summary>
    /// <remarks>
    /// Vanilla keeps most of this in static fields on <c>StrongholdPieces</c> and resets them at the
    /// top of each attempt. Two chunks laying strongholds out at once would interleave those, and the
    /// pass runs on the thread pool, so it lives on the piece that every <c>addChildren</c> is already
    /// handed.
    /// </remarks>
    public StrongholdLayout Layout { get; } = new();
}

/// <summary>
/// <c>StrongholdPieces.FiveCrossing</c>: the two level junction with up to five ways out.
/// </summary>
public sealed class StrongholdFiveCrossing : StrongholdPiece {
    private readonly bool _leftLow;
    private readonly bool _leftHigh;
    private readonly bool _rightLow;
    private readonly bool _rightHigh;

    public StrongholdFiveCrossing(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
        _leftLow = random.NextBoolean();
        _leftHigh = random.NextBoolean();
        _rightLow = random.NextBoolean();

        // Two in three rather than one in two, which is the only asymmetry among the four.
        _rightHigh = random.NextInt(3) > 0;
    }

    public static StrongholdFiveCrossing? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -4, -3, 0, 10, 9, 11, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdFiveCrossing(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int lowOffset = 3;
        int highOffset = 5;

        // The two side offsets are mirrored for the facings whose local z runs the other way, so the
        // openings line up with the holes the body actually cuts.
        if (Orientation is Direction.West or Direction.North) {
            lowOffset = 8 - lowOffset;
            highOffset = 8 - highOffset;
        }

        StrongholdStartPiece origin = (StrongholdStartPiece)start;
        GenerateSmallDoorChildForward(origin, builder, random, 5, 1);

        if (_leftLow) {
            GenerateSmallDoorChildLeft(origin, builder, random, lowOffset, 1);
        }

        if (_leftHigh) {
            GenerateSmallDoorChildLeft(origin, builder, random, highOffset, 7);
        }

        if (_rightLow) {
            GenerateSmallDoorChildRight(origin, builder, random, lowOffset, 1);
        }

        if (_rightHigh) {
            GenerateSmallDoorChildRight(origin, builder, random, highOffset, 7);
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        SmoothStoneSelector selector = new();

        GenerateBox(level, chunkBox, 0, 0, 0, 9, 8, 10, true, random, selector);
        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 4, 3, 0);

        if (_leftLow) {
            GenerateBox(level, chunkBox, 0, 3, 1, 0, 5, 3, CaveAir, CaveAir, false);
        }

        if (_rightLow) {
            GenerateBox(level, chunkBox, 9, 3, 1, 9, 5, 3, CaveAir, CaveAir, false);
        }

        if (_leftHigh) {
            GenerateBox(level, chunkBox, 0, 5, 7, 0, 7, 9, CaveAir, CaveAir, false);
        }

        if (_rightHigh) {
            GenerateBox(level, chunkBox, 9, 5, 7, 9, 7, 9, CaveAir, CaveAir, false);
        }

        GenerateBox(level, chunkBox, 5, 1, 10, 7, 3, 10, CaveAir, CaveAir, false);
        GenerateBox(level, chunkBox, 1, 2, 1, 8, 2, 6, false, random, selector);
        GenerateBox(level, chunkBox, 4, 1, 5, 4, 4, 9, false, random, selector);
        GenerateBox(level, chunkBox, 8, 1, 5, 8, 4, 9, false, random, selector);
        GenerateBox(level, chunkBox, 1, 4, 7, 3, 4, 9, false, random, selector);
        GenerateBox(level, chunkBox, 1, 3, 5, 3, 3, 6, false, random, selector);

        uint slab = Block.SmoothStoneSlab.StateId;
        uint doubleSlab = ((ISlabTyped)Block.SmoothStoneSlab).WithType(SlabType.Double).StateId;

        GenerateBox(level, chunkBox, 1, 3, 4, 3, 3, 4, slab, slab, false);
        GenerateBox(level, chunkBox, 1, 4, 6, 3, 4, 6, slab, slab, false);
        GenerateBox(level, chunkBox, 5, 1, 7, 7, 1, 8, false, random, selector);
        GenerateBox(level, chunkBox, 5, 1, 9, 7, 1, 9, slab, slab, false);
        GenerateBox(level, chunkBox, 5, 2, 7, 7, 2, 7, slab, slab, false);
        GenerateBox(level, chunkBox, 4, 5, 7, 4, 5, 9, slab, slab, false);
        GenerateBox(level, chunkBox, 8, 5, 7, 8, 5, 9, slab, slab, false);
        GenerateBox(level, chunkBox, 5, 5, 7, 7, 5, 9, doubleSlab, doubleSlab, false);

        PlaceBlock(level, StrongholdStraight.Torch(Direction.South), 6, 5, 6, chunkBox);
    }
}

/// <summary>
/// <c>StrongholdPieces.Library</c>: the bookshelves, in a one or two storey form.
/// </summary>
/// <remarks>
/// The tall form is <b>tried first</b> and falls back to the short one if it does not fit, so which
/// you get is decided by the room around it rather than by a draw.
/// </remarks>
public sealed class StrongholdLibrary : StrongholdPiece {
    private readonly bool _isTall;

    public StrongholdLibrary(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        EntryDoor = RandomSmallDoor(random);
        _isTall = boundingBox.YSpan > 6;
    }

    public static StrongholdLibrary? Create(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -4, -1, 0, 14, 11, 15, direction);

        if (!IsOkBox(box) || builder.FindCollisionPiece(box) is not null) {
            box = BoundingBox.Orient(footX, footY, footZ, -4, -1, 0, 14, 6, 15, direction);

            if (!IsOkBox(box) || builder.FindCollisionPiece(box) is not null) {
                return null;
            }
        }

        return new StrongholdLibrary(genDepth, random, box, direction);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        int height = _isTall ? 11 : 6;

        GenerateBox(level, chunkBox, 0, 0, 0, 13, height - 1, 14, true, random,
            new SmoothStoneSelector());

        GenerateSmallDoor(level, random, chunkBox, EntryDoor, 4, 1, 0);
        GenerateMaybeBox(level, chunkBox, random, 0.07f, 2, 1, 1, 11, 4, 13, Block.Cobweb.StateId,
            Block.Cobweb.StateId, false, false);

        uint planks = Block.OakPlanks.StateId;
        uint shelf = Block.Bookshelf.StateId;

        // The two long walls, in bays of four: a plank column with a torch every fourth slot and
        // bookshelves in the rest.
        for (int z = 1; z <= 13; z++) {
            if ((z - 1) % 4 == 0) {
                GenerateBox(level, chunkBox, 1, 1, z, 1, 4, z, planks, planks, false);
                GenerateBox(level, chunkBox, 12, 1, z, 12, 4, z, planks, planks, false);
                PlaceBlock(level, StrongholdStraight.Torch(Direction.East), 2, 3, z, chunkBox);
                PlaceBlock(level, StrongholdStraight.Torch(Direction.West), 11, 3, z, chunkBox);

                if (_isTall) {
                    GenerateBox(level, chunkBox, 1, 6, z, 1, 9, z, planks, planks, false);
                    GenerateBox(level, chunkBox, 12, 6, z, 12, 9, z, planks, planks, false);
                }
            } else {
                GenerateBox(level, chunkBox, 1, 1, z, 1, 4, z, shelf, shelf, false);
                GenerateBox(level, chunkBox, 12, 1, z, 12, 4, z, shelf, shelf, false);

                if (_isTall) {
                    GenerateBox(level, chunkBox, 1, 6, z, 1, 9, z, shelf, shelf, false);
                    GenerateBox(level, chunkBox, 12, 6, z, 12, 9, z, shelf, shelf, false);
                }
            }
        }

        for (int z = 3; z < 12; z += 2) {
            GenerateBox(level, chunkBox, 3, 1, z, 4, 3, z, shelf, shelf, false);
            GenerateBox(level, chunkBox, 6, 1, z, 7, 3, z, shelf, shelf, false);
            GenerateBox(level, chunkBox, 9, 1, z, 10, 3, z, shelf, shelf, false);
        }

        if (_isTall) {
            PlaceUpperFloor(level, chunkBox);
        }

        CreateChest(level, chunkBox, random, 3, 3, 5);

        if (_isTall) {
            PlaceBlock(level, CaveAir, 12, 9, 1, chunkBox);
            CreateChest(level, chunkBox, random, 12, 8, 1);
        }
    }

    /// <summary>The plank balcony, its fence rail, the ladder up to it and the chandelier.</summary>
    private void PlaceUpperFloor(IFeatureLevel level, BoundingBox chunkBox) {
        uint planks = Block.OakPlanks.StateId;

        GenerateBox(level, chunkBox, 1, 5, 1, 3, 5, 13, planks, planks, false);
        GenerateBox(level, chunkBox, 10, 5, 1, 12, 5, 13, planks, planks, false);
        GenerateBox(level, chunkBox, 4, 5, 1, 9, 5, 2, planks, planks, false);
        GenerateBox(level, chunkBox, 4, 5, 12, 9, 5, 13, planks, planks, false);
        PlaceBlock(level, planks, 9, 5, 11, chunkBox);
        PlaceBlock(level, planks, 8, 5, 11, chunkBox);
        PlaceBlock(level, planks, 9, 5, 10, chunkBox);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 3, 6, 3, 3, 6, 11, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 10, 6, 3, 10, 6, 9, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 4, 6, 2, 9, 6, 2, westEast, westEast, false);
        GenerateBox(level, chunkBox, 4, 6, 12, 7, 6, 12, westEast, westEast, false);

        PlaceBlock(level, Fence(BlockFace.NegZ, BlockFace.PosX), 3, 6, 2, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosZ, BlockFace.PosX), 3, 6, 12, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegZ, BlockFace.NegX), 10, 6, 2, chunkBox);

        // The diagonal run of rail across the corner, which is a staircase of corner posts.
        for (int step = 0; step <= 2; step++) {
            PlaceBlock(level, Fence(BlockFace.PosZ, BlockFace.NegX), 8 + step, 6, 12 - step, chunkBox);

            if (step != 2) {
                PlaceBlock(level, Fence(BlockFace.NegZ, BlockFace.PosX), 8 + step, 6, 11 - step,
                    chunkBox);
            }
        }

        uint ladder = ((IHorizontalFacing)Block.Ladder).WithFacing(Direction.South).StateId;

        for (int y = 1; y <= 7; y++) {
            PlaceBlock(level, ladder, 10, y, 13, chunkBox);
        }

        uint east = Fence(BlockFace.PosX);
        uint west = Fence(BlockFace.NegX);

        PlaceBlock(level, east, 6, 9, 7, chunkBox);
        PlaceBlock(level, west, 7, 9, 7, chunkBox);
        PlaceBlock(level, east, 6, 8, 7, chunkBox);
        PlaceBlock(level, west, 7, 8, 7, chunkBox);

        uint all = Fence(BlockFace.NegZ, BlockFace.PosZ, BlockFace.NegX, BlockFace.PosX);
        PlaceBlock(level, all, 6, 7, 7, chunkBox);
        PlaceBlock(level, all, 7, 7, 7, chunkBox);
        PlaceBlock(level, east, 5, 7, 7, chunkBox);
        PlaceBlock(level, west, 8, 7, 7, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosX, BlockFace.NegZ), 6, 7, 6, chunkBox);
        PlaceBlock(level, Fence(BlockFace.PosX, BlockFace.PosZ), 6, 7, 8, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX, BlockFace.NegZ), 7, 7, 6, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX, BlockFace.PosZ), 7, 7, 8, chunkBox);

        uint torch = Block.Torch.StateId;
        PlaceBlock(level, torch, 5, 8, 7, chunkBox);
        PlaceBlock(level, torch, 8, 8, 7, chunkBox);
        PlaceBlock(level, torch, 6, 8, 6, chunkBox);
        PlaceBlock(level, torch, 6, 8, 8, chunkBox);
        PlaceBlock(level, torch, 7, 8, 6, chunkBox);
        PlaceBlock(level, torch, 7, 8, 8, chunkBox);
    }

    private static uint Fence(params BlockFace[] sides) {
        IBlock fence = Block.OakFence;

        foreach (BlockFace side in sides) {
            fence = ((IFaceConnected)fence).WithConnection(side, true);
        }

        return fence.StateId;
    }
}

/// <summary>
/// <c>StrongholdPieces.PortalRoom</c>: the end portal, and what makes a stronghold a stronghold.
/// </summary>
/// <remarks>
/// Placed at most once per stronghold, and a stronghold that did not get one is rebuilt from scratch.
/// It is also the only piece that takes no random in its constructor: nothing about its shape varies.
/// </remarks>
public sealed class StrongholdPortalRoom : StrongholdPiece {
    private bool _hasPlacedSpawner;

    public StrongholdPortalRoom(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static StrongholdPortalRoom? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -4, -1, 0, 11, 8, 16, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new StrongholdPortalRoom(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        ((StrongholdStartPiece)start).Layout.PortalRoom = this;
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        SmoothStoneSelector selector = new();

        GenerateBox(level, chunkBox, 0, 0, 0, 10, 7, 15, false, random, selector);
        GenerateSmallDoor(level, random, chunkBox, SmallDoorType.Grates, 4, 1, 0);

        GenerateBox(level, chunkBox, 1, 6, 1, 1, 6, 14, false, random, selector);
        GenerateBox(level, chunkBox, 9, 6, 1, 9, 6, 14, false, random, selector);
        GenerateBox(level, chunkBox, 2, 6, 1, 8, 6, 2, false, random, selector);
        GenerateBox(level, chunkBox, 2, 6, 14, 8, 6, 14, false, random, selector);
        GenerateBox(level, chunkBox, 1, 1, 1, 2, 1, 4, false, random, selector);
        GenerateBox(level, chunkBox, 8, 1, 1, 9, 1, 4, false, random, selector);

        uint lava = Block.Lava.StateId;
        GenerateBox(level, chunkBox, 1, 1, 1, 1, 1, 3, lava, lava, false);
        GenerateBox(level, chunkBox, 9, 1, 1, 9, 1, 3, lava, lava, false);
        GenerateBox(level, chunkBox, 3, 1, 8, 7, 1, 12, false, random, selector);
        GenerateBox(level, chunkBox, 4, 1, 9, 6, 1, 11, lava, lava, false);

        uint northSouth = Bars(BlockFace.NegZ, BlockFace.PosZ);
        uint westEast = Bars(BlockFace.NegX, BlockFace.PosX);

        for (int z = 3; z < 14; z += 2) {
            GenerateBox(level, chunkBox, 0, 3, z, 0, 4, z, northSouth, northSouth, false);
            GenerateBox(level, chunkBox, 10, 3, z, 10, 4, z, northSouth, northSouth, false);
        }

        for (int x = 2; x < 9; x += 2) {
            GenerateBox(level, chunkBox, x, 3, 15, x, 4, 15, westEast, westEast, false);
        }

        uint stairs = ((IHorizontalFacing)Block.StoneBrickStairs).WithFacing(Direction.North).StateId;

        GenerateBox(level, chunkBox, 4, 1, 5, 6, 1, 7, false, random, selector);
        GenerateBox(level, chunkBox, 4, 2, 6, 6, 2, 7, false, random, selector);
        GenerateBox(level, chunkBox, 4, 3, 7, 6, 3, 7, false, random, selector);

        for (int x = 4; x <= 6; x++) {
            PlaceBlock(level, stairs, x, 1, 4, chunkBox);
            PlaceBlock(level, stairs, x, 2, 5, chunkBox);
            PlaceBlock(level, stairs, x, 3, 6, chunkBox);
        }

        // One in ten frames gets an eye, drawn for all twelve whichever way the earlier ones went.
        bool allEyes = true;
        bool[] eyes = new bool[12];

        for (int i = 0; i < eyes.Length; i++) {
            eyes[i] = random.NextFloat() > 0.9f;
            allEyes &= eyes[i];
        }

        PlaceBlock(level, Frame(Direction.North, eyes[0]), 4, 3, 8, chunkBox);
        PlaceBlock(level, Frame(Direction.North, eyes[1]), 5, 3, 8, chunkBox);
        PlaceBlock(level, Frame(Direction.North, eyes[2]), 6, 3, 8, chunkBox);
        PlaceBlock(level, Frame(Direction.South, eyes[3]), 4, 3, 12, chunkBox);
        PlaceBlock(level, Frame(Direction.South, eyes[4]), 5, 3, 12, chunkBox);
        PlaceBlock(level, Frame(Direction.South, eyes[5]), 6, 3, 12, chunkBox);
        PlaceBlock(level, Frame(Direction.East, eyes[6]), 3, 3, 9, chunkBox);
        PlaceBlock(level, Frame(Direction.East, eyes[7]), 3, 3, 10, chunkBox);
        PlaceBlock(level, Frame(Direction.East, eyes[8]), 3, 3, 11, chunkBox);
        PlaceBlock(level, Frame(Direction.West, eyes[9]), 7, 3, 9, chunkBox);
        PlaceBlock(level, Frame(Direction.West, eyes[10]), 7, 3, 10, chunkBox);
        PlaceBlock(level, Frame(Direction.West, eyes[11]), 7, 3, 11, chunkBox);

        // A one in a trillion world, but vanilla writes the portal blocks for it and so does this.
        if (allEyes) {
            uint portal = Block.EndPortal.StateId;

            for (int x = 4; x <= 6; x++) {
                for (int z = 9; z <= 11; z++) {
                    PlaceBlock(level, portal, x, 3, z, chunkBox);
                }
            }
        }

        if (_hasPlacedSpawner) {
            return;
        }

        Vec3<int> spawner = GetWorldPos(5, 3, 6);

        if (!chunkBox.IsInside(spawner.X, spawner.Y, spawner.Z)) {
            return;
        }

        _hasPlacedSpawner = true;

        // The block and not the silverfish. A spawner's entity type lives on a block entity and there
        // is no port of one, the same gap that leaves every structure chest empty.
        level.SetState(spawner.X, spawner.Y, spawner.Z, Block.Spawner.StateId);
    }

    private static uint Frame(Direction facing, bool eye) {
        return (Block.EndPortalFrame with { Eye = eye, Facing = facing }).StateId;
    }
}

/// <summary>
/// <c>StrongholdPieces.FillerCorridor</c>: the stub that seals a passage running into a piece that is
/// already there.
/// </summary>
/// <remarks>
/// The only piece that is not chosen: it is what the weighted draw falls back to after five failed
/// attempts. Its length comes from how much room is left before the piece in the way, and it is one
/// block longer than that gap so the two meet.
/// </remarks>
public sealed class StrongholdFillerCorridor : StrongholdPiece {
    private readonly int _steps;

    public StrongholdFillerCorridor(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;

        _steps = direction is Direction.North or Direction.South
            ? boundingBox.ZSpan
            : boundingBox.XSpan;
    }

    /// <summary>
    /// The box for a stub, or null where one is not wanted.
    /// </summary>
    /// <remarks>
    /// Null when nothing is in the way, since then a real piece could have gone there and the corridor
    /// is simply left open. Also null when the piece in the way sits at a different height, which is
    /// the <c>minY</c> comparison: two corridors passing at different levels do not need sealing off
    /// from each other.
    /// </remarks>
    public static BoundingBox? FindPieceBox(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, 4, direction);
        StructurePiece? collision = builder.FindCollisionPiece(box);

        if (collision is null || collision.BoundingBox.MinY != box.MinY) {
            return null;
        }

        for (int depth = 2; depth >= 1; depth--) {
            box = BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, depth, direction);

            if (!collision.BoundingBox.Intersects(box)) {
                return BoundingBox.Orient(footX, footY, footZ, -1, -1, 0, 5, 5, depth + 1, direction);
            }
        }

        return null;
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        for (int z = 0; z < _steps; z++) {
            for (int x = 0; x <= 4; x++) {
                PlaceBlock(level, StoneBricks, x, 0, z, chunkBox);
            }

            for (int y = 1; y <= 3; y++) {
                PlaceBlock(level, StoneBricks, 0, y, z, chunkBox);
                PlaceBlock(level, CaveAir, 1, y, z, chunkBox);
                PlaceBlock(level, CaveAir, 2, y, z, chunkBox);
                PlaceBlock(level, CaveAir, 3, y, z, chunkBox);
                PlaceBlock(level, StoneBricks, 4, y, z, chunkBox);
            }

            for (int x = 0; x <= 4; x++) {
                PlaceBlock(level, StoneBricks, x, 4, z, chunkBox);
            }
        }
    }
}
