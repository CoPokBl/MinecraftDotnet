using ManagedServer.Terrain.Features;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>CastleSmallCorridorPiece</c>: five by five of enclosed corridor with a barred window each side.
/// </summary>
/// <remarks>
/// The castle pieces are shorter than the bridge ones and enclosed rather than open, which is the
/// whole visual difference between the inside of a fortress and the outside.
/// </remarks>
public sealed class CastleSmallCorridor : NetherBridgePiece {
    public CastleSmallCorridor(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleSmallCorridor? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, 0, 0, 5, 7, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleSmallCorridor(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildForward((NetherFortressStart)start, builder, random, 1, 0, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 1, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 4, 5, 4, Air, Air, false);

        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 0, 2, 0, 0, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 2, 0, 4, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 3, 1, 0, 4, 1, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 0, 3, 3, 0, 4, 3, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 4, 3, 1, 4, 4, 1, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 4, 3, 3, 4, 4, 3, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 0, 6, 0, 4, 6, 4, Bricks, Bricks, false);

        FillColumnsDown(level, chunkBox, 0, 4, 0, 4);
    }
}

/// <summary><c>CastleSmallCorridorCrossingPiece</c>: the same corridor with three ways out.</summary>
public sealed class CastleSmallCorridorCrossing : NetherBridgePiece {
    public CastleSmallCorridorCrossing(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleSmallCorridorCrossing? Create(StructurePiecesBuilder builder, int footX,
        int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, 0, 0, 5, 7, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleSmallCorridorCrossing(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        NetherFortressStart origin = (NetherFortressStart)start;
        GenerateChildForward(origin, builder, random, 1, 0, true);
        GenerateChildLeft(origin, builder, random, 0, 1, true);
        GenerateChildRight(origin, builder, random, 0, 1, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 1, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 4, 5, 4, Air, Air, false);

        // Only the four corner posts, since all four walls have to be open.
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 2, 0, 4, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 4, 0, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 2, 4, 4, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 6, 0, 4, 6, 4, Bricks, Bricks, false);

        FillColumnsDown(level, chunkBox, 0, 4, 0, 4);
    }
}

/// <summary>
/// <c>CastleSmallCorridorLeftTurnPiece</c>: a corner, with a one in three chance of a chest in it.
/// </summary>
public sealed class CastleSmallCorridorLeftTurn : NetherBridgePiece {
    private bool _isNeedingChest;

    public CastleSmallCorridorLeftTurn(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        _isNeedingChest = random.NextInt(3) == 0;
    }

    public static CastleSmallCorridorLeftTurn? Create(StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, 0, 0, 5, 7, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleSmallCorridorLeftTurn(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildLeft((NetherFortressStart)start, builder, random, 0, 1, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 1, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 4, 5, 4, Air, Air, false);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 4, 2, 0, 4, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 4, 3, 1, 4, 4, 1, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 4, 3, 3, 4, 4, 3, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 4, 3, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 3, 4, 1, 4, 4, westEast, westEast, false);
        GenerateBox(level, chunkBox, 3, 3, 4, 3, 4, 4, westEast, westEast, false);

        // Cleared on the first chunk that actually holds the corner, so a piece split across a border
        // does not place a chest in each half.
        Vec3<int> chest = GetWorldPos(3, 2, 3);

        if (_isNeedingChest && chunkBox.IsInside(chest.X, chest.Y, chest.Z)) {
            _isNeedingChest = false;
            CreateChest(level, chunkBox, random, 3, 2, 3);
        }

        GenerateBox(level, chunkBox, 0, 6, 0, 4, 6, 4, Bricks, Bricks, false);

        FillColumnsDown(level, chunkBox, 0, 4, 0, 4);
    }
}

/// <summary><c>CastleSmallCorridorRightTurnPiece</c>: the mirror of the left turn.</summary>
public sealed class CastleSmallCorridorRightTurn : NetherBridgePiece {
    private bool _isNeedingChest;

    public CastleSmallCorridorRightTurn(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction) : base(genDepth, boundingBox) {

        Orientation = direction;
        _isNeedingChest = random.NextInt(3) == 0;
    }

    public static CastleSmallCorridorRightTurn? Create(StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, 0, 0, 5, 7, 5, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleSmallCorridorRightTurn(genDepth, random, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildRight((NetherFortressStart)start, builder, random, 0, 1, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 0, 0, 4, 1, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 4, 5, 4, Air, Air, false);

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 0, 2, 0, 0, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 3, 1, 0, 4, 1, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 0, 3, 3, 0, 4, 3, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 4, 2, 0, 4, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 2, 4, 4, 5, 4, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 3, 4, 1, 4, 4, westEast, westEast, false);
        GenerateBox(level, chunkBox, 3, 3, 4, 3, 4, 4, westEast, westEast, false);

        // The mirror of the left turn puts its chest in the other corner.
        Vec3<int> chest = GetWorldPos(1, 2, 3);

        if (_isNeedingChest && chunkBox.IsInside(chest.X, chest.Y, chest.Z)) {
            _isNeedingChest = false;
            CreateChest(level, chunkBox, random, 1, 2, 3);
        }

        GenerateBox(level, chunkBox, 0, 6, 0, 4, 6, 4, Bricks, Bricks, false);

        FillColumnsDown(level, chunkBox, 0, 4, 0, 4);
    }
}

/// <summary>
/// <c>CastleCorridorStairsPiece</c>: a corridor that drops seven blocks over its ten of length.
/// </summary>
/// <remarks>
/// Built a slice at a time rather than as boxes: each slice has its own floor and roof height, and
/// the roof is clamped so the corridor never gets shorter than five blocks or taller than the piece.
/// </remarks>
public sealed class CastleCorridorStairs : NetherBridgePiece {
    public CastleCorridorStairs(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleCorridorStairs? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -1, -7, 0, 5, 14, 10, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleCorridorStairs(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        GenerateChildForward((NetherFortressStart)start, builder, random, 1, 0, true);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        uint stairs = Stairs(Direction.South);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        for (int step = 0; step <= 9; step++) {
            int floor = Math.Max(1, 7 - step);
            int roof = Math.Min(Math.Max(floor + 5, 14 - step), 13);

            GenerateBox(level, chunkBox, 0, 0, step, 4, floor, step, Bricks, Bricks, false);
            GenerateBox(level, chunkBox, 1, floor + 1, step, 3, roof - 1, step, Air, Air, false);

            // The stairs stop after the seventh slice, where the floor has bottomed out at one.
            if (step <= 6) {
                PlaceBlock(level, stairs, 1, floor + 1, step, chunkBox);
                PlaceBlock(level, stairs, 2, floor + 1, step, chunkBox);
                PlaceBlock(level, stairs, 3, floor + 1, step, chunkBox);
            }

            GenerateBox(level, chunkBox, 0, roof, step, 4, roof, step, Bricks, Bricks, false);
            GenerateBox(level, chunkBox, 0, floor + 1, step, 0, roof - 1, step, Bricks, Bricks, false);
            GenerateBox(level, chunkBox, 4, floor + 1, step, 4, roof - 1, step, Bricks, Bricks, false);

            if ((step & 1) == 0) {
                GenerateBox(level, chunkBox, 0, floor + 2, step, 0, floor + 3, step, northSouth,
                    northSouth, false);
                GenerateBox(level, chunkBox, 4, floor + 2, step, 4, floor + 3, step, northSouth,
                    northSouth, false);
            }

            for (int x = 0; x <= 4; x++) {
                FillColumnDown(level, Bricks, x, -1, step, chunkBox);
            }
        }
    }
}

/// <summary>
/// <c>CastleCorridorTBalconyPiece</c>: the T junction with a balcony over the drop behind it.
/// </summary>
public sealed class CastleCorridorTBalcony : NetherBridgePiece {
    public CastleCorridorTBalcony(int genDepth, BoundingBox boundingBox, Direction direction)
        : base(genDepth, boundingBox) {

        Orientation = direction;
    }

    public static CastleCorridorTBalcony? Create(StructurePiecesBuilder builder, int footX, int footY,
        int footZ, Direction direction, int genDepth) {

        BoundingBox box = BoundingBox.Orient(footX, footY, footZ, -3, 0, 0, 9, 7, 9, direction);

        return IsOkBox(box) && builder.FindCollisionPiece(box) is null
            ? new CastleCorridorTBalcony(genDepth, box, direction)
            : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int zOff = Orientation is Direction.West or Direction.North ? 5 : 1;

        // The two draws happen whichever way the branches go, and each decides whether that arm is a
        // castle piece or falls back to the bridge table. That is the one place the fortress crosses
        // back from the inside to the outside.
        NetherFortressStart origin = (NetherFortressStart)start;
        GenerateChildLeft(origin, builder, random, 0, zOff, random.NextInt(8) > 0);
        GenerateChildRight(origin, builder, random, 0, zOff, random.NextInt(8) > 0);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        uint westEast = Fence(BlockFace.NegX, BlockFace.PosX);
        uint northSouth = Fence(BlockFace.NegZ, BlockFace.PosZ);

        GenerateBox(level, chunkBox, 0, 0, 0, 8, 1, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 8, 5, 8, Air, Air, false);
        GenerateBox(level, chunkBox, 0, 6, 0, 8, 6, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 2, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 2, 0, 8, 5, 0, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 3, 0, 1, 4, 0, westEast, westEast, false);
        GenerateBox(level, chunkBox, 7, 3, 0, 7, 4, 0, westEast, westEast, false);
        GenerateBox(level, chunkBox, 0, 2, 4, 8, 2, 8, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 1, 4, 2, 2, 4, Air, Air, false);
        GenerateBox(level, chunkBox, 6, 1, 4, 7, 2, 4, Air, Air, false);

        // The balcony rail, whose two ends turn the corner.
        GenerateBox(level, chunkBox, 1, 3, 8, 7, 3, 8, westEast, westEast, false);
        PlaceBlock(level, Fence(BlockFace.PosX, BlockFace.PosZ), 0, 3, 8, chunkBox);
        PlaceBlock(level, Fence(BlockFace.NegX, BlockFace.PosZ), 8, 3, 8, chunkBox);
        GenerateBox(level, chunkBox, 0, 3, 6, 0, 3, 7, northSouth, northSouth, false);
        GenerateBox(level, chunkBox, 8, 3, 6, 8, 3, 7, northSouth, northSouth, false);

        GenerateBox(level, chunkBox, 0, 3, 4, 0, 5, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 8, 3, 4, 8, 5, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 3, 5, 2, 5, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 6, 3, 5, 7, 5, 5, Bricks, Bricks, false);
        GenerateBox(level, chunkBox, 1, 4, 5, 1, 5, 5, westEast, westEast, false);
        GenerateBox(level, chunkBox, 7, 4, 5, 7, 5, 5, westEast, westEast, false);

        // Only the corridor half gets legs; the balcony half deliberately hangs over the drop.
        FillColumnsDown(level, chunkBox, 0, 8, 0, 5);
    }
}
