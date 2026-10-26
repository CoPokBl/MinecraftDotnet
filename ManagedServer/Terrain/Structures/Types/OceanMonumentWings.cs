using ManagedServer.Terrain.Features;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>OceanMonumentSimpleRoom</c>: an ordinary cell, in one of three decorations.
/// </summary>
/// <remarks>
/// The design is drawn at layout time and the centre pillar is drawn at <b>write</b> time, from the
/// pass's per chunk random. So a room split across a chunk border can get its pillar in one half and
/// not the other; that is vanilla's own arrangement rather than a consequence of generating one chunk
/// at a time.
/// </remarks>
public sealed class MonumentSimpleRoom : MonumentPiece {
    private readonly int _mainDesign;

    public MonumentSimpleRoom(Direction orientation, MonumentRoom room, RandomSource random)
        : base(1, orientation, room, 1, 1, 1) {

        _mainDesign = random.NextInt(3);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (Room!.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 0, 0, Room.HasOpening[(int)BlockFace.NegY]);
        }

        if (Room.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 4, 1, 6, 4, 6, BaseGray);
        }

        bool centrePillar = _mainDesign != 0
            && random.NextBoolean()
            && !Room.HasOpening[(int)BlockFace.NegY]
            && !Room.HasOpening[(int)BlockFace.PosY]
            && Room.CountOpenings() > 1;

        switch (_mainDesign) {
            case 0:
                FourLamps(level, chunkBox);
                break;

            case 1:
                CornerPillars(level, chunkBox);
                break;

            case 2:
                BandedWalls(level, chunkBox);
                break;
        }

        if (centrePillar) {
            GenerateBox(level, chunkBox, 3, 1, 3, 4, 1, 4, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 3, 2, 3, 4, 2, 4, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 3, 3, 3, 4, 3, 4, BaseLight, BaseLight, false);
        }
    }

    /// <summary>A lamp set into each of the four corners, and a recess in every closed wall.</summary>
    private void FourLamps(IFeatureLevel level, BoundingBox chunkBox) {
        GenerateBox(level, chunkBox, 0, 1, 0, 2, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 3, 0, 2, 3, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 2, 2, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 2, 2, 0, BaseGray, BaseGray, false);
        PlaceBlock(level, Lamp, 1, 2, 1, chunkBox);
        GenerateBox(level, chunkBox, 5, 1, 0, 7, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 3, 0, 7, 3, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 2, 0, 7, 2, 2, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 5, 2, 0, 6, 2, 0, BaseGray, BaseGray, false);
        PlaceBlock(level, Lamp, 6, 2, 1, chunkBox);
        GenerateBox(level, chunkBox, 0, 1, 5, 2, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 3, 5, 2, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 5, 0, 2, 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 7, 2, 2, 7, BaseGray, BaseGray, false);
        PlaceBlock(level, Lamp, 1, 2, 6, chunkBox);
        GenerateBox(level, chunkBox, 5, 1, 5, 7, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 3, 5, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 2, 5, 7, 2, 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 5, 2, 7, 6, 2, 7, BaseGray, BaseGray, false);
        PlaceBlock(level, Lamp, 6, 2, 6, chunkBox);

        if (Open(BlockFace.PosZ)) {
            GenerateBox(level, chunkBox, 3, 3, 0, 4, 3, 0, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 3, 3, 0, 4, 3, 1, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 3, 2, 0, 4, 2, 0, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 3, 1, 0, 4, 1, 1, BaseLight, BaseLight, false);
        }

        if (Open(BlockFace.NegZ)) {
            GenerateBox(level, chunkBox, 3, 3, 7, 4, 3, 7, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 3, 3, 6, 4, 3, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 3, 2, 7, 4, 2, 7, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 3, 1, 6, 4, 1, 7, BaseLight, BaseLight, false);
        }

        if (Open(BlockFace.NegX)) {
            GenerateBox(level, chunkBox, 0, 3, 3, 0, 3, 4, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 0, 3, 3, 1, 3, 4, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, 2, 3, 0, 2, 4, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 0, 1, 3, 1, 1, 4, BaseLight, BaseLight, false);
        }

        if (Open(BlockFace.PosX)) {
            GenerateBox(level, chunkBox, 7, 3, 3, 7, 3, 4, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 6, 3, 3, 7, 3, 4, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 7, 2, 3, 7, 2, 4, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 6, 1, 3, 7, 1, 4, BaseLight, BaseLight, false);
        }
    }

    /// <summary>Four free standing lit posts, and solid walls wherever the room does not open.</summary>
    private void CornerPillars(IFeatureLevel level, BoundingBox chunkBox) {
        GenerateBox(level, chunkBox, 2, 1, 2, 2, 3, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 1, 5, 2, 3, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 5, 5, 3, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 2, 5, 3, 2, BaseLight, BaseLight, false);
        PlaceBlock(level, Lamp, 2, 2, 2, chunkBox);
        PlaceBlock(level, Lamp, 2, 2, 5, chunkBox);
        PlaceBlock(level, Lamp, 5, 2, 5, chunkBox);
        PlaceBlock(level, Lamp, 5, 2, 2, chunkBox);
        GenerateBox(level, chunkBox, 0, 1, 0, 1, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 1, 0, 3, 1, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 7, 1, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 6, 0, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 7, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 6, 7, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 0, 7, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 1, 7, 3, 1, BaseLight, BaseLight, false);
        PlaceBlock(level, BaseGray, 1, 2, 0, chunkBox);
        PlaceBlock(level, BaseGray, 0, 2, 1, chunkBox);
        PlaceBlock(level, BaseGray, 1, 2, 7, chunkBox);
        PlaceBlock(level, BaseGray, 0, 2, 6, chunkBox);
        PlaceBlock(level, BaseGray, 6, 2, 7, chunkBox);
        PlaceBlock(level, BaseGray, 7, 2, 6, chunkBox);
        PlaceBlock(level, BaseGray, 6, 2, 0, chunkBox);
        PlaceBlock(level, BaseGray, 7, 2, 1, chunkBox);

        if (!Open(BlockFace.PosZ)) {
            GenerateBox(level, chunkBox, 1, 3, 0, 6, 3, 0, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 2, 0, 6, 2, 0, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 1, 1, 0, 6, 1, 0, BaseLight, BaseLight, false);
        }

        if (!Open(BlockFace.NegZ)) {
            GenerateBox(level, chunkBox, 1, 3, 7, 6, 3, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 2, 7, 6, 2, 7, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 1, 1, 7, 6, 1, 7, BaseLight, BaseLight, false);
        }

        if (!Open(BlockFace.NegX)) {
            GenerateBox(level, chunkBox, 0, 3, 1, 0, 3, 6, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, 2, 1, 0, 2, 6, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 0, 1, 1, 0, 1, 6, BaseLight, BaseLight, false);
        }

        if (!Open(BlockFace.PosX)) {
            GenerateBox(level, chunkBox, 7, 3, 1, 7, 3, 6, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 7, 2, 1, 7, 2, 6, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 7, 1, 1, 7, 1, 6, BaseLight, BaseLight, false);
        }
    }

    /// <summary>
    /// A dark band around the room at head height, with the doorways cut back out of it afterwards.
    /// </summary>
    private void BandedWalls(IFeatureLevel level, BoundingBox chunkBox) {
        GenerateBox(level, chunkBox, 0, 1, 0, 0, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 0, 7, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 0, 6, 1, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 7, 6, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 7, 2, 0, 7, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 6, 2, 0, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 1, 2, 7, 6, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 0, 3, 0, 0, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 3, 0, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 0, 6, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 7, 6, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 3, 0, 2, 4, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 7, 1, 3, 7, 2, 4, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 3, 1, 0, 4, 2, 0, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 3, 1, 7, 4, 2, 7, BaseBlack, BaseBlack, false);

        if (Open(BlockFace.PosZ)) {
            GenerateWaterBox(level, chunkBox, 3, 1, 0, 4, 2, 0);
        }

        if (Open(BlockFace.NegZ)) {
            GenerateWaterBox(level, chunkBox, 3, 1, 7, 4, 2, 7);
        }

        if (Open(BlockFace.NegX)) {
            GenerateWaterBox(level, chunkBox, 0, 1, 3, 0, 2, 4);
        }

        if (Open(BlockFace.PosX)) {
            GenerateWaterBox(level, chunkBox, 7, 1, 3, 7, 2, 4);
        }
    }
}

/// <summary>
/// <c>OceanMonumentSimpleTopRoom</c>: the sponge room, the only reason to break into a monument.
/// </summary>
/// <remarks>
/// The sponges are drawn from the pass's per chunk random at <b>write</b> time, so a sponge room
/// straddling a chunk border has a different pattern in each half. Vanilla is the same.
/// </remarks>
public sealed class MonumentSimpleTopRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 1, 1, 1) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (Room!.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 0, 0, Room.HasOpening[(int)BlockFace.NegY]);
        }

        if (Room.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 4, 1, 6, 4, 6, BaseGray);
        }

        // Two in three columns get sponge, and one in four of those hangs a block lower.
        uint sponge = Block.WetSponge.StateId;

        for (int x = 1; x <= 6; x++) {
            for (int z = 1; z <= 6; z++) {
                if (random.NextInt(3) == 0) {
                    continue;
                }

                int y0 = 2 + (random.NextInt(4) == 0 ? 0 : 1);
                GenerateBox(level, chunkBox, x, y0, z, x, 3, z, sponge, sponge, false);
            }
        }

        GenerateBox(level, chunkBox, 0, 1, 0, 0, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 0, 7, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 0, 6, 1, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 7, 6, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 7, 2, 0, 7, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 6, 2, 0, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 1, 2, 7, 6, 2, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 0, 3, 0, 0, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 3, 0, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 0, 6, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 7, 6, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 3, 0, 2, 4, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 7, 1, 3, 7, 2, 4, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 3, 1, 0, 4, 2, 0, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 3, 1, 7, 4, 2, 7, BaseBlack, BaseBlack, false);

        // Only the south wall is ever reopened, because the fitter only accepts a cell whose other
        // five faces are already closed.
        if (Open(BlockFace.PosZ)) {
            GenerateWaterBox(level, chunkBox, 3, 1, 0, 4, 2, 0);
        }
    }
}

/// <summary>
/// <c>OceanMonumentWingRoom</c>: one of the two halls under the arms, in one of two designs.
/// </summary>
/// <remarks>
/// The design comes from the low bit of a single draw shared with the other wing, which is bumped
/// between them, so the two wings always differ.
/// </remarks>
public sealed class MonumentWingRoom(Direction orientation, BoundingBox boundingBox, int randomValue)
    : MonumentPiece(orientation, 1, boundingBox) {

    private readonly int _mainDesign = randomValue & 1;

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (_mainDesign == 0) {
            OpenHall(level, chunkBox);
        } else {
            PillaredHall(level, chunkBox);
        }
    }

    /// <summary>The tall hall with the stepped entrance and lamps down both walls.</summary>
    private void OpenHall(IFeatureLevel level, BoundingBox chunkBox) {
        for (int i = 0; i < 4; i++) {
            GenerateBox(level, chunkBox, 10 - i, 3 - i, 20 - i, 12 + i, 3 - i, 20, BaseLight,
                BaseLight, false);
        }

        GenerateBox(level, chunkBox, 7, 0, 6, 15, 0, 16, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 0, 6, 6, 3, 20, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 16, 0, 6, 16, 3, 20, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 7, 7, 1, 20, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 15, 1, 7, 15, 1, 20, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 6, 9, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 1, 6, 15, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 8, 1, 7, 9, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 1, 7, 14, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 0, 5, 13, 0, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 0, 7, 12, 0, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 8, 0, 10, 8, 0, 12, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 14, 0, 10, 14, 0, 12, BaseBlack, BaseBlack, false);

        for (int z = 18; z >= 7; z -= 3) {
            PlaceBlock(level, Lamp, 6, 3, z, chunkBox);
            PlaceBlock(level, Lamp, 16, 3, z, chunkBox);
        }

        PlaceBlock(level, Lamp, 10, 0, 10, chunkBox);
        PlaceBlock(level, Lamp, 12, 0, 10, chunkBox);
        PlaceBlock(level, Lamp, 10, 0, 12, chunkBox);
        PlaceBlock(level, Lamp, 12, 0, 12, chunkBox);
        PlaceBlock(level, Lamp, 8, 3, 6, chunkBox);
        PlaceBlock(level, Lamp, 14, 3, 6, chunkBox);

        // The four corner sconces, each a lamp sandwiched between two bricks.
        PlaceBlock(level, BaseLight, 4, 2, 4, chunkBox);
        PlaceBlock(level, Lamp, 4, 1, 4, chunkBox);
        PlaceBlock(level, BaseLight, 4, 0, 4, chunkBox);
        PlaceBlock(level, BaseLight, 18, 2, 4, chunkBox);
        PlaceBlock(level, Lamp, 18, 1, 4, chunkBox);
        PlaceBlock(level, BaseLight, 18, 0, 4, chunkBox);
        PlaceBlock(level, BaseLight, 4, 2, 18, chunkBox);
        PlaceBlock(level, Lamp, 4, 1, 18, chunkBox);
        PlaceBlock(level, BaseLight, 4, 0, 18, chunkBox);
        PlaceBlock(level, BaseLight, 18, 2, 18, chunkBox);
        PlaceBlock(level, Lamp, 18, 1, 18, chunkBox);
        PlaceBlock(level, BaseLight, 18, 0, 18, chunkBox);

        PlaceBlock(level, BaseLight, 9, 7, 20, chunkBox);
        PlaceBlock(level, BaseLight, 13, 7, 20, chunkBox);
        GenerateBox(level, chunkBox, 6, 0, 21, 7, 4, 21, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 15, 0, 21, 16, 4, 21, BaseLight, BaseLight, false);

        SpawnElder(level, chunkBox, 11, 2, 16);
    }

    /// <summary>The lower hall broken up by four lit columns.</summary>
    private void PillaredHall(IFeatureLevel level, BoundingBox chunkBox) {
        GenerateBox(level, chunkBox, 9, 3, 18, 13, 3, 20, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 0, 18, 9, 2, 18, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 0, 18, 13, 2, 18, BaseLight, BaseLight, false);

        for (int x = 9; x <= 13; x += 4) {
            PlaceBlock(level, BaseLight, x, 6, 20, chunkBox);
            PlaceBlock(level, Lamp, x, 5, 20, chunkBox);
            PlaceBlock(level, BaseLight, x, 4, 20, chunkBox);
        }

        GenerateBox(level, chunkBox, 7, 3, 7, 15, 3, 14, BaseLight, BaseLight, false);

        for (int x = 10; x <= 12; x += 2) {
            GenerateBox(level, chunkBox, x, 0, 10, x, 6, 10, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, x, 0, 12, x, 6, 12, BaseLight, BaseLight, false);
            PlaceBlock(level, Lamp, x, 0, 10, chunkBox);
            PlaceBlock(level, Lamp, x, 0, 12, chunkBox);
            PlaceBlock(level, Lamp, x, 4, 10, chunkBox);
            PlaceBlock(level, Lamp, x, 4, 12, chunkBox);
        }

        for (int x = 8; x <= 14; x += 6) {
            GenerateBox(level, chunkBox, x, 0, 7, x, 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, x, 0, 14, x, 2, 14, BaseLight, BaseLight, false);
        }

        GenerateBox(level, chunkBox, 8, 3, 8, 8, 3, 13, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 14, 3, 8, 14, 3, 13, BaseBlack, BaseBlack, false);

        SpawnElder(level, chunkBox, 11, 5, 13);
    }
}

/// <summary>
/// <c>OceanMonumentPenthouse</c>: the open room under the roof pyramid, and where the third elder
/// guardian would be.
/// </summary>
public sealed class MonumentPenthouse(Direction orientation, BoundingBox boundingBox)
    : MonumentPiece(orientation, 1, boundingBox) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 2, -1, 2, 11, -1, 11, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, -1, 0, 1, -1, 11, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 12, -1, 0, 13, -1, 11, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 2, -1, 0, 11, -1, 1, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 2, -1, 12, 11, -1, 13, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 0, 0, 0, 0, 0, 13, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 0, 0, 13, 0, 13, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 0, 0, 12, 0, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 0, 13, 12, 0, 13, BaseLight, BaseLight, false);

        // The back wall gets no lamps: the loop covers the two sides and the front only.
        for (int i = 2; i <= 11; i += 3) {
            PlaceBlock(level, Lamp, 0, 0, i, chunkBox);
            PlaceBlock(level, Lamp, 13, 0, i, chunkBox);
            PlaceBlock(level, Lamp, i, 0, 0, chunkBox);
        }

        GenerateBox(level, chunkBox, 2, 0, 3, 4, 0, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 0, 3, 11, 0, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 4, 0, 9, 9, 0, 11, BaseLight, BaseLight, false);
        PlaceBlock(level, BaseLight, 5, 0, 8, chunkBox);
        PlaceBlock(level, BaseLight, 8, 0, 8, chunkBox);
        PlaceBlock(level, BaseLight, 10, 0, 10, chunkBox);
        PlaceBlock(level, BaseLight, 3, 0, 10, chunkBox);
        GenerateBox(level, chunkBox, 3, 0, 3, 3, 0, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 10, 0, 3, 10, 0, 7, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 6, 0, 10, 7, 0, 10, BaseBlack, BaseBlack, false);

        for (int x = 3; x <= 10; x += 7) {
            for (int z = 2; z <= 8; z += 3) {
                GenerateBox(level, chunkBox, x, 0, z, x, 2, z, BaseLight, BaseLight, false);
            }
        }

        GenerateBox(level, chunkBox, 5, 0, 10, 5, 2, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 8, 0, 10, 8, 2, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, -1, 7, 7, -1, 8, BaseBlack, BaseBlack, false);
        GenerateWaterBox(level, chunkBox, 6, -1, 3, 7, -1, 4);

        SpawnElder(level, chunkBox, 6, 1, 6);
    }
}
