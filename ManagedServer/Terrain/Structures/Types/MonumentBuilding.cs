using ManagedServer.Terrain.Features;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>OceanMonumentPieces.MonumentBuilding</c>: the whole monument, walls and rooms together.
/// </summary>
/// <remarks>
/// The rooms are <b>children this piece owns</b> rather than pieces the pass sees, so they are written
/// from inside this one's <c>PostProcess</c> and are never collision tested against anything.
/// </remarks>
public sealed class MonumentBuilding : MonumentPiece {
    private const int GridSize = 75;
    private const int GridFloorCount = 25;

    private static readonly int SourceIndex = RoomIndex(2, 0, 0);
    private static readonly int TopConnectIndex = RoomIndex(2, 2, 0);
    private static readonly int LeftWingConnectIndex = RoomIndex(0, 1, 0);
    private static readonly int RightWingConnectIndex = RoomIndex(4, 1, 0);

    private readonly List<MonumentPiece> _childPieces = [];

    private MonumentRoom _sourceRoom = null!;
    private MonumentRoom _coreRoom = null!;

    /// <summary>
    /// <c>createTopPiece</c>: the facing is drawn before anything else the building draws.
    /// </summary>
    public static MonumentBuilding Create(RandomSource random, int west, int north) {
        return new MonumentBuilding(random, west, north, RandomHorizontalDirection(random));
    }

    private MonumentBuilding(RandomSource random, int west, int north, Direction direction)
        : base(direction, 0, MakeBoundingBox(west, 39, north, direction, 58, 23, 58)) {

        List<MonumentRoom> rooms = GenerateRoomGraph(random);

        _sourceRoom.Claimed = true;
        _childPieces.Add(new MonumentEntryRoom(direction, _sourceRoom));
        _childPieces.Add(new MonumentCoreRoom(direction, _coreRoom));

        // The order is what decides a room's shape: the first fitter that accepts a cell claims it,
        // and the double rooms are tried before the single ones so a pair is used where one exists.
        IMonumentRoomFitter[] fitters = [
            new FitDoubleXYRoom(),
            new FitDoubleYZRoom(),
            new FitDoubleZRoom(),
            new FitDoubleXRoom(),
            new FitDoubleYRoom(),
            new FitSimpleTopRoom(),
            new FitSimpleRoom()
        ];

        foreach (MonumentRoom room in rooms) {
            if (room.Claimed || room.IsSpecial) {
                continue;
            }

            foreach (IMonumentRoomFitter fitter in fitters) {
                if (!fitter.Fits(room)) {
                    continue;
                }

                _childPieces.Add(fitter.Create(direction, room, random));
                break;
            }
        }

        // The room grid is laid out from its own origin and then shifted into the building, which is
        // why every room box is built at zero and moved here.
        Vec3<int> offset = GetWorldPos(9, 0, 22);

        foreach (MonumentPiece child in _childPieces) {
            child.BoundingBox.Move(offset.X, offset.Y, offset.Z);
        }

        BoundingBox leftWing = FromCorners(GetWorldPos(1, 1, 1), GetWorldPos(23, 8, 21));
        BoundingBox rightWing = FromCorners(GetWorldPos(34, 1, 1), GetWorldPos(56, 8, 21));
        BoundingBox penthouse = FromCorners(GetWorldPos(22, 13, 22), GetWorldPos(35, 17, 35));

        // One draw for both wings, and the second wing gets the incremented value. So the two wings
        // are never the same design as each other by chance: they always differ in the low bit.
        int wingRandom = random.NextInt();

        _childPieces.Add(new MonumentWingRoom(direction, leftWing, wingRandom++));
        _childPieces.Add(new MonumentWingRoom(direction, rightWing, wingRandom));
        _childPieces.Add(new MonumentPenthouse(direction, penthouse));
    }

    private static BoundingBox FromCorners(Vec3<int> a, Vec3<int> b) {
        return new BoundingBox(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z),
            Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
    }

    private static int RoomIndex(int roomX, int roomY, int roomZ) {
        return roomY * GridFloorCount + roomZ * 5 + roomX;
    }

    /// <summary>
    /// Builds the room graph and knocks doorways out of it.
    /// </summary>
    /// <remarks>
    /// The grid is not a cuboid: five by four on the bottom two floors and three by two on the top,
    /// which is what gives the monument its stepped profile.
    /// <p/>
    /// <b>The doorway closing is the load bearing part.</b> Each room tries up to five times to shut
    /// two of its own doorways, and a doorway is only kept shut if <b>both</b> sides can still reach
    /// the entrance afterwards. That is what makes a monument a maze that is nonetheless connected.
    /// </remarks>
    private List<MonumentRoom> GenerateRoomGraph(RandomSource random) {
        MonumentRoom?[] grid = new MonumentRoom?[GridSize];

        for (int x = 0; x < 5; x++) {
            for (int z = 0; z < 4; z++) {
                int index = RoomIndex(x, 0, z);
                grid[index] = new MonumentRoom(index);
            }
        }

        for (int x = 0; x < 5; x++) {
            for (int z = 0; z < 4; z++) {
                int index = RoomIndex(x, 1, z);
                grid[index] = new MonumentRoom(index);
            }
        }

        for (int x = 1; x < 4; x++) {
            for (int z = 0; z < 2; z++) {
                int index = RoomIndex(x, 2, z);
                grid[index] = new MonumentRoom(index);
            }
        }

        _sourceRoom = grid[SourceIndex]!;

        for (int x = 0; x < 5; x++) {
            for (int z = 0; z < 5; z++) {
                for (int y = 0; y < 3; y++) {
                    if (grid[RoomIndex(x, y, z)] is not { } room) {
                        continue;
                    }

                    foreach (BlockFace face in Directions.All) {
                        (int stepX, int stepY, int stepZ) = Step(face);
                        int nx = x + stepX;
                        int ny = y + stepY;
                        int nz = z + stepZ;

                        if (nx < 0 || nx >= 5 || nz < 0 || nz >= 5 || ny < 0 || ny >= 3) {
                            continue;
                        }

                        if (grid[RoomIndex(nx, ny, nz)] is not { } neighbour) {
                            continue;
                        }

                        // The z neighbours are linked through the opposite face, which flips the
                        // grid's z against the world's. Getting this the same way round for both
                        // gives a monument whose rooms open onto the wrong sides.
                        room.SetConnection(nz == z ? face : face.Opposite(), neighbour);
                    }
                }
            }
        }

        MonumentRoom roof = new(1003);
        MonumentRoom leftWing = new(1001);
        MonumentRoom rightWing = new(1002);

        grid[TopConnectIndex]!.SetConnection(BlockFace.PosY, roof);
        grid[LeftWingConnectIndex]!.SetConnection(BlockFace.PosZ, leftWing);
        grid[RightWingConnectIndex]!.SetConnection(BlockFace.PosZ, rightWing);

        roof.Claimed = true;
        leftWing.Claimed = true;
        rightWing.Claimed = true;
        _sourceRoom.IsSource = true;

        // The core is a two by two by two block of cells, so all eight are claimed at once.
        _coreRoom = grid[RoomIndex(random.NextInt(4), 0, 2)]!;
        _coreRoom.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.PosX]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.NegZ]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.PosX]!.Connections[(int)BlockFace.NegZ]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.PosY]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.PosX]!.Connections[(int)BlockFace.PosY]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.NegZ]!.Connections[(int)BlockFace.PosY]!.Claimed = true;
        _coreRoom.Connections[(int)BlockFace.PosX]!.Connections[(int)BlockFace.NegZ]!
            .Connections[(int)BlockFace.PosY]!.Claimed = true;

        List<MonumentRoom> rooms = [];

        foreach (MonumentRoom? room in grid) {
            if (room is null) {
                continue;
            }

            room.UpdateOpenings();
            rooms.Add(room);
        }

        roof.UpdateOpenings();

        Shuffle(rooms, random);

        int scan = 1;

        foreach (MonumentRoom room in rooms) {
            int closed = 0;
            int attempts = 0;

            while (closed < 2 && attempts < 5) {
                attempts++;
                int face = random.NextInt(6);

                if (!room.HasOpening[face]) {
                    continue;
                }

                int opposite = (int)((BlockFace)face).Opposite();
                room.HasOpening[face] = false;
                room.Connections[face]!.HasOpening[opposite] = false;

                // Both walks happen and both have to succeed, and the scan number is bumped for each
                // whichever way the first one went.
                if (room.FindSource(scan++) && room.Connections[face]!.FindSource(scan++)) {
                    closed++;
                } else {
                    room.HasOpening[face] = true;
                    room.Connections[face]!.HasOpening[opposite] = true;
                }
            }
        }

        rooms.Add(roof);
        rooms.Add(leftWing);
        rooms.Add(rightWing);
        return rooms;
    }

    /// <summary><c>Util.shuffle</c>, a Fisher-Yates walk downwards.</summary>
    private static void Shuffle<T>(List<T> items, RandomSource random) {
        for (int i = items.Count; i > 1; i--) {
            int swap = random.NextInt(i);
            (items[i - 1], items[swap]) = (items[swap], items[i - 1]);
        }
    }

    /// <summary><c>Direction.getStepX/Y/Z</c> for a face.</summary>
    private static (int X, int Y, int Z) Step(BlockFace face) {
        return face switch {
            BlockFace.NegY => (0, -1, 0),
            BlockFace.PosY => (0, 1, 0),
            BlockFace.NegZ => (0, 0, -1),
            BlockFace.PosZ => (0, 0, 1),
            BlockFace.NegX => (-1, 0, 0),
            _ => (1, 0, 0)
        };
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        // Everything the building occupies is cleared to water first, up to the sea, so the rooms
        // written into it can tell empty from solid by looking for water.
        int waterHeight = Math.Max(level.SeaLevel, 64) - BoundingBox.MinY;
        GenerateWaterBox(level, chunkBox, 0, 0, 0, 58, waterHeight, 58);

        GenerateWing(false, 0, level, chunkBox);
        GenerateWing(true, 33, level, chunkBox);
        GenerateEntranceArchs(level, chunkBox);
        GenerateEntranceWall(level, chunkBox);
        GenerateRoofPiece(level, chunkBox);
        GenerateLowerWall(level, chunkBox);
        GenerateMiddleWall(level, chunkBox);
        GenerateUpperWall(level, chunkBox);

        // The legs, on a nine block grid with the middle of the front row skipped, driven down to
        // whatever the sea floor is.
        for (int pillarX = 0; pillarX < 7; pillarX++) {
            int pillarZ = 0;

            while (pillarZ < 7) {
                if (pillarZ == 0 && pillarX == 3) {
                    pillarZ = 6;
                }

                int baseX = pillarX * 9;
                int baseZ = pillarZ * 9;

                for (int w = 0; w < 4; w++) {
                    for (int d = 0; d < 4; d++) {
                        PlaceBlock(level, BaseLight, baseX + w, 0, baseZ + d, chunkBox);
                        FillColumnDown(level, BaseLight, baseX + w, -1, baseZ + d, chunkBox);
                    }
                }

                if (pillarX != 0 && pillarX != 6) {
                    pillarZ += 6;
                } else {
                    pillarZ++;
                }
            }
        }

        // A stepped skirt of water around the whole thing, which is what stops the sea floor pressing
        // up against the walls.
        for (int i = 0; i < 5; i++) {
            GenerateWaterBox(level, chunkBox, -1 - i, i * 2, -1 - i, -1 - i, 23, 58 + i);
            GenerateWaterBox(level, chunkBox, 58 + i, i * 2, -1 - i, 58 + i, 23, 58 + i);
            GenerateWaterBox(level, chunkBox, -i, i * 2, -1 - i, 57 + i, 23, -1 - i);
            GenerateWaterBox(level, chunkBox, -i, i * 2, 58 + i, 57 + i, 23, 58 + i);
        }

        foreach (MonumentPiece child in _childPieces) {
            if (child.BoundingBox.Intersects(chunkBox)) {
                child.PostProcess(level, random, chunkBox, chunkX, chunkZ, referencePos);
            }
        }
    }

    /// <summary>One of the two arms, mirrored for the right hand one.</summary>
    private void GenerateWing(bool flipped, int xOff, IFeatureLevel level, BoundingBox chunkBox) {
        if (!ChunkIntersects(chunkBox, xOff, 0, xOff + 23, 20)) {
            return;
        }

        GenerateBox(level, chunkBox, xOff, 0, 0, xOff + 24, 0, 20, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, xOff, 1, 0, xOff + 24, 10, 20);

        for (int i = 0; i < 4; i++) {
            GenerateBox(level, chunkBox, xOff + i, i + 1, i, xOff + i, i + 1, 20, BaseLight, BaseLight,
                false);
            GenerateBox(level, chunkBox, xOff + i + 7, i + 5, i + 7, xOff + i + 7, i + 5, 20,
                BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, xOff + 17 - i, i + 5, i + 7, xOff + 17 - i, i + 5, 20,
                BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, xOff + 24 - i, i + 1, i, xOff + 24 - i, i + 1, 20, BaseLight,
                BaseLight, false);
            GenerateBox(level, chunkBox, xOff + i + 1, i + 1, i, xOff + 23 - i, i + 1, i, BaseLight,
                BaseLight, false);
            GenerateBox(level, chunkBox, xOff + i + 8, i + 5, i + 7, xOff + 16 - i, i + 5, i + 7,
                BaseLight, BaseLight, false);
        }

        GenerateBox(level, chunkBox, xOff + 4, 4, 4, xOff + 6, 4, 20, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, xOff + 7, 4, 4, xOff + 17, 4, 6, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, xOff + 18, 4, 4, xOff + 20, 4, 20, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, xOff + 11, 8, 11, xOff + 13, 8, 20, BaseGray, BaseGray, false);

        PlaceBlock(level, DotDeco, xOff + 12, 9, 12, chunkBox);
        PlaceBlock(level, DotDeco, xOff + 12, 9, 15, chunkBox);
        PlaceBlock(level, DotDeco, xOff + 12, 9, 18, chunkBox);

        // The two rows of studs down the arm swap over for the mirrored wing, which is the only place
        // the flip is visible.
        int left = xOff + (flipped ? 19 : 5);
        int right = xOff + (flipped ? 5 : 19);

        for (int z = 20; z >= 5; z -= 3) {
            PlaceBlock(level, DotDeco, left, 5, z, chunkBox);
        }

        for (int z = 19; z >= 7; z -= 3) {
            PlaceBlock(level, DotDeco, right, 5, z, chunkBox);
        }

        for (int i = 0; i < 4; i++) {
            int x = flipped ? xOff + 24 - (17 - i * 3) : xOff + 17 - i * 3;
            PlaceBlock(level, DotDeco, x, 5, 5, chunkBox);
        }

        PlaceBlock(level, DotDeco, right, 5, 5, chunkBox);
        GenerateBox(level, chunkBox, xOff + 11, 1, 12, xOff + 13, 7, 12, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, xOff + 12, 1, 11, xOff + 12, 7, 13, BaseGray, BaseGray, false);
    }

    /// <summary>The four lit arches over the front approach.</summary>
    private void GenerateEntranceArchs(IFeatureLevel level, BoundingBox chunkBox) {
        if (!ChunkIntersects(chunkBox, 22, 5, 35, 17)) {
            return;
        }

        GenerateWaterBox(level, chunkBox, 25, 0, 0, 32, 8, 20);

        for (int i = 0; i < 4; i++) {
            int z = 5 + i * 4;

            GenerateBox(level, chunkBox, 24, 2, z, 24, 4, z, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 22, 4, z, 23, 4, z, BaseLight, BaseLight, false);
            PlaceBlock(level, BaseLight, 25, 5, z, chunkBox);
            PlaceBlock(level, BaseLight, 26, 6, z, chunkBox);
            PlaceBlock(level, Lamp, 26, 5, z, chunkBox);
            GenerateBox(level, chunkBox, 33, 2, z, 33, 4, z, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 34, 4, z, 35, 4, z, BaseLight, BaseLight, false);
            PlaceBlock(level, BaseLight, 32, 5, z, chunkBox);
            PlaceBlock(level, BaseLight, 31, 6, z, chunkBox);
            PlaceBlock(level, Lamp, 31, 5, z, chunkBox);
            GenerateBox(level, chunkBox, 27, 6, z, 30, 6, z, BaseGray, BaseGray, false);
        }
    }

    /// <summary>The front face, with the dark prismarine chevrons over the doorway.</summary>
    private void GenerateEntranceWall(IFeatureLevel level, BoundingBox chunkBox) {
        if (!ChunkIntersects(chunkBox, 15, 20, 42, 21)) {
            return;
        }

        GenerateBox(level, chunkBox, 15, 0, 21, 42, 0, 21, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, 26, 1, 21, 31, 3, 21);
        GenerateBox(level, chunkBox, 21, 12, 21, 36, 12, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 17, 11, 21, 40, 11, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 16, 10, 21, 41, 10, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 15, 7, 21, 42, 9, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 16, 6, 21, 41, 6, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 17, 5, 21, 40, 5, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 21, 4, 21, 36, 4, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 22, 3, 21, 26, 3, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 31, 3, 21, 35, 3, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 23, 2, 21, 25, 2, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 32, 2, 21, 34, 2, 21, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 28, 4, 20, 29, 4, 21, BaseLight, BaseLight, false);

        PlaceBlock(level, BaseLight, 27, 3, 21, chunkBox);
        PlaceBlock(level, BaseLight, 30, 3, 21, chunkBox);
        PlaceBlock(level, BaseLight, 26, 2, 21, chunkBox);
        PlaceBlock(level, BaseLight, 31, 2, 21, chunkBox);
        PlaceBlock(level, BaseLight, 25, 1, 21, chunkBox);
        PlaceBlock(level, BaseLight, 32, 1, 21, chunkBox);

        for (int i = 0; i < 7; i++) {
            PlaceBlock(level, BaseBlack, 28 - i, 6 + i, 21, chunkBox);
            PlaceBlock(level, BaseBlack, 29 + i, 6 + i, 21, chunkBox);
        }

        for (int i = 0; i < 4; i++) {
            PlaceBlock(level, BaseBlack, 28 - i, 9 + i, 21, chunkBox);
            PlaceBlock(level, BaseBlack, 29 + i, 9 + i, 21, chunkBox);
        }

        PlaceBlock(level, BaseBlack, 28, 12, 21, chunkBox);
        PlaceBlock(level, BaseBlack, 29, 12, 21, chunkBox);

        for (int i = 0; i < 3; i++) {
            PlaceBlock(level, BaseBlack, 22 - i * 2, 8, 21, chunkBox);
            PlaceBlock(level, BaseBlack, 22 - i * 2, 9, 21, chunkBox);
            PlaceBlock(level, BaseBlack, 35 + i * 2, 8, 21, chunkBox);
            PlaceBlock(level, BaseBlack, 35 + i * 2, 9, 21, chunkBox);
        }

        // The stepped opening either side of the doorway, cut out afterwards rather than left unbuilt.
        GenerateWaterBox(level, chunkBox, 15, 13, 21, 42, 15, 21);
        GenerateWaterBox(level, chunkBox, 15, 1, 21, 15, 6, 21);
        GenerateWaterBox(level, chunkBox, 16, 1, 21, 16, 5, 21);
        GenerateWaterBox(level, chunkBox, 17, 1, 21, 20, 4, 21);
        GenerateWaterBox(level, chunkBox, 21, 1, 21, 21, 3, 21);
        GenerateWaterBox(level, chunkBox, 22, 1, 21, 22, 2, 21);
        GenerateWaterBox(level, chunkBox, 23, 1, 21, 24, 1, 21);
        GenerateWaterBox(level, chunkBox, 42, 1, 21, 42, 6, 21);
        GenerateWaterBox(level, chunkBox, 41, 1, 21, 41, 5, 21);
        GenerateWaterBox(level, chunkBox, 37, 1, 21, 40, 4, 21);
        GenerateWaterBox(level, chunkBox, 36, 1, 21, 36, 3, 21);
        GenerateWaterBox(level, chunkBox, 33, 1, 21, 34, 1, 21);
        GenerateWaterBox(level, chunkBox, 35, 1, 21, 35, 2, 21);
    }

    /// <summary>The stepped pyramid on top, and the four lamps at its corners.</summary>
    private void GenerateRoofPiece(IFeatureLevel level, BoundingBox chunkBox) {
        if (!ChunkIntersects(chunkBox, 21, 21, 36, 36)) {
            return;
        }

        GenerateBox(level, chunkBox, 21, 0, 22, 36, 0, 36, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, 21, 1, 22, 36, 23, 36);

        for (int i = 0; i < 4; i++) {
            GenerateBox(level, chunkBox, 21 + i, 13 + i, 21 + i, 36 - i, 13 + i, 21 + i, BaseLight,
                BaseLight, false);
            GenerateBox(level, chunkBox, 21 + i, 13 + i, 36 - i, 36 - i, 13 + i, 36 - i, BaseLight,
                BaseLight, false);
            GenerateBox(level, chunkBox, 21 + i, 13 + i, 22 + i, 21 + i, 13 + i, 35 - i, BaseLight,
                BaseLight, false);
            GenerateBox(level, chunkBox, 36 - i, 13 + i, 22 + i, 36 - i, 13 + i, 35 - i, BaseLight,
                BaseLight, false);
        }

        GenerateBox(level, chunkBox, 25, 16, 25, 32, 16, 32, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 25, 17, 25, 25, 19, 25, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 32, 17, 25, 32, 19, 25, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 25, 17, 32, 25, 19, 32, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 32, 17, 32, 32, 19, 32, BaseLight, BaseLight, false);

        PlaceBlock(level, BaseLight, 26, 20, 26, chunkBox);
        PlaceBlock(level, BaseLight, 27, 21, 27, chunkBox);
        PlaceBlock(level, Lamp, 27, 20, 27, chunkBox);
        PlaceBlock(level, BaseLight, 26, 20, 31, chunkBox);
        PlaceBlock(level, BaseLight, 27, 21, 30, chunkBox);
        PlaceBlock(level, Lamp, 27, 20, 30, chunkBox);
        PlaceBlock(level, BaseLight, 31, 20, 31, chunkBox);
        PlaceBlock(level, BaseLight, 30, 21, 30, chunkBox);
        PlaceBlock(level, Lamp, 30, 20, 30, chunkBox);
        PlaceBlock(level, BaseLight, 31, 20, 26, chunkBox);
        PlaceBlock(level, BaseLight, 30, 21, 27, chunkBox);
        PlaceBlock(level, Lamp, 30, 20, 27, chunkBox);

        GenerateBox(level, chunkBox, 28, 21, 27, 29, 21, 27, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 27, 21, 28, 27, 21, 29, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 28, 21, 30, 29, 21, 30, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 30, 21, 28, 30, 21, 29, BaseGray, BaseGray, false);
    }

    /// <summary>The outermost terrace, along the two sides and the back.</summary>
    private void GenerateLowerWall(IFeatureLevel level, BoundingBox chunkBox) {
        if (ChunkIntersects(chunkBox, 0, 21, 6, 58)) {
            GenerateBox(level, chunkBox, 0, 0, 21, 6, 0, 57, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 0, 1, 21, 6, 7, 57);
            GenerateBox(level, chunkBox, 4, 4, 21, 6, 4, 53, BaseGray, BaseGray, false);

            // Vanilla runs this loop twice over, once here and once after the studs, writing the same
            // blocks both times.
            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, i, i + 1, 21, i, i + 1, 57 - i, BaseLight, BaseLight,
                    false);
            }

            for (int z = 23; z < 53; z += 3) {
                PlaceBlock(level, DotDeco, 5, 5, z, chunkBox);
            }

            PlaceBlock(level, DotDeco, 5, 5, 52, chunkBox);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, i, i + 1, 21, i, i + 1, 57 - i, BaseLight, BaseLight,
                    false);
            }

            GenerateBox(level, chunkBox, 4, 1, 52, 6, 3, 52, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 5, 1, 51, 5, 3, 53, BaseGray, BaseGray, false);
        }

        if (ChunkIntersects(chunkBox, 51, 21, 58, 58)) {
            GenerateBox(level, chunkBox, 51, 0, 21, 57, 0, 57, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 51, 1, 21, 57, 7, 57);
            GenerateBox(level, chunkBox, 51, 4, 21, 53, 4, 53, BaseGray, BaseGray, false);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, 57 - i, i + 1, 21, 57 - i, i + 1, 57 - i, BaseLight,
                    BaseLight, false);
            }

            for (int z = 23; z < 53; z += 3) {
                PlaceBlock(level, DotDeco, 52, 5, z, chunkBox);
            }

            PlaceBlock(level, DotDeco, 52, 5, 52, chunkBox);
            GenerateBox(level, chunkBox, 51, 1, 52, 53, 3, 52, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 52, 1, 51, 52, 3, 53, BaseGray, BaseGray, false);
        }

        if (!ChunkIntersects(chunkBox, 0, 51, 57, 57)) {
            return;
        }

        GenerateBox(level, chunkBox, 7, 0, 51, 50, 0, 57, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, 7, 1, 51, 50, 10, 57);

        for (int i = 0; i < 4; i++) {
            GenerateBox(level, chunkBox, i + 1, i + 1, 57 - i, 56 - i, i + 1, 57 - i, BaseLight,
                BaseLight, false);
        }
    }

    /// <summary>The second terrace up, whose back wall carries the tall studded panels.</summary>
    private void GenerateMiddleWall(IFeatureLevel level, BoundingBox chunkBox) {
        if (ChunkIntersects(chunkBox, 7, 21, 13, 50)) {
            GenerateBox(level, chunkBox, 7, 0, 21, 13, 0, 50, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 7, 1, 21, 13, 10, 50);
            GenerateBox(level, chunkBox, 11, 8, 21, 13, 8, 53, BaseGray, BaseGray, false);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, i + 7, i + 5, 21, i + 7, i + 5, 54, BaseLight, BaseLight,
                    false);
            }

            for (int z = 21; z <= 45; z += 3) {
                PlaceBlock(level, DotDeco, 12, 9, z, chunkBox);
            }
        }

        if (ChunkIntersects(chunkBox, 44, 21, 50, 54)) {
            GenerateBox(level, chunkBox, 44, 0, 21, 50, 0, 50, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 44, 1, 21, 50, 10, 50);
            GenerateBox(level, chunkBox, 44, 8, 21, 46, 8, 53, BaseGray, BaseGray, false);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, 50 - i, i + 5, 21, 50 - i, i + 5, 54, BaseLight,
                    BaseLight, false);
            }

            for (int z = 21; z <= 45; z += 3) {
                PlaceBlock(level, DotDeco, 45, 9, z, chunkBox);
            }
        }

        if (!ChunkIntersects(chunkBox, 8, 44, 49, 54)) {
            return;
        }

        GenerateBox(level, chunkBox, 14, 0, 44, 43, 0, 50, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, 14, 1, 44, 43, 10, 50);

        // Every third column gets a stud, and six of them get the full diamond pattern above it.
        for (int x = 12; x <= 45; x += 3) {
            PlaceBlock(level, DotDeco, x, 9, 45, chunkBox);
            PlaceBlock(level, DotDeco, x, 9, 52, chunkBox);

            if (x is not (12 or 18 or 24 or 33 or 39 or 45)) {
                continue;
            }

            PlaceBlock(level, DotDeco, x, 9, 47, chunkBox);
            PlaceBlock(level, DotDeco, x, 9, 50, chunkBox);
            PlaceBlock(level, DotDeco, x, 10, 45, chunkBox);
            PlaceBlock(level, DotDeco, x, 10, 46, chunkBox);
            PlaceBlock(level, DotDeco, x, 10, 51, chunkBox);
            PlaceBlock(level, DotDeco, x, 10, 52, chunkBox);
            PlaceBlock(level, DotDeco, x, 11, 47, chunkBox);
            PlaceBlock(level, DotDeco, x, 11, 50, chunkBox);
            PlaceBlock(level, DotDeco, x, 12, 48, chunkBox);
            PlaceBlock(level, DotDeco, x, 12, 49, chunkBox);
        }

        for (int i = 0; i < 3; i++) {
            GenerateBox(level, chunkBox, 8 + i, 5 + i, 54, 49 - i, 5 + i, 54, BaseGray, BaseGray,
                false);
        }

        GenerateBox(level, chunkBox, 11, 8, 54, 46, 8, 54, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 14, 8, 44, 43, 8, 53, BaseGray, BaseGray, false);
    }

    /// <summary>The innermost terrace, which the roof pyramid sits on.</summary>
    private void GenerateUpperWall(IFeatureLevel level, BoundingBox chunkBox) {
        if (ChunkIntersects(chunkBox, 14, 21, 20, 43)) {
            GenerateBox(level, chunkBox, 14, 0, 21, 20, 0, 43, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 14, 1, 22, 20, 14, 43);
            GenerateBox(level, chunkBox, 18, 12, 22, 20, 12, 39, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 18, 12, 21, 20, 12, 21, BaseLight, BaseLight, false);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, i + 14, i + 9, 21, i + 14, i + 9, 43 - i, BaseLight,
                    BaseLight, false);
            }

            for (int z = 23; z <= 39; z += 3) {
                PlaceBlock(level, DotDeco, 19, 13, z, chunkBox);
            }
        }

        if (ChunkIntersects(chunkBox, 37, 21, 43, 43)) {
            GenerateBox(level, chunkBox, 37, 0, 21, 43, 0, 43, BaseGray, BaseGray, false);
            GenerateWaterBox(level, chunkBox, 37, 1, 22, 43, 14, 43);
            GenerateBox(level, chunkBox, 37, 12, 22, 39, 12, 39, BaseGray, BaseGray, false);
            GenerateBox(level, chunkBox, 37, 12, 21, 39, 12, 21, BaseLight, BaseLight, false);

            for (int i = 0; i < 4; i++) {
                GenerateBox(level, chunkBox, 43 - i, i + 9, 21, 43 - i, i + 9, 43 - i, BaseLight,
                    BaseLight, false);
            }

            for (int z = 23; z <= 39; z += 3) {
                PlaceBlock(level, DotDeco, 38, 13, z, chunkBox);
            }
        }

        if (!ChunkIntersects(chunkBox, 15, 37, 42, 43)) {
            return;
        }

        GenerateBox(level, chunkBox, 21, 0, 37, 36, 0, 43, BaseGray, BaseGray, false);
        GenerateWaterBox(level, chunkBox, 21, 1, 37, 36, 14, 43);
        GenerateBox(level, chunkBox, 21, 12, 37, 36, 12, 39, BaseGray, BaseGray, false);

        for (int i = 0; i < 4; i++) {
            GenerateBox(level, chunkBox, 15 + i, i + 9, 43 - i, 42 - i, i + 9, 43 - i, BaseLight,
                BaseLight, false);
        }

        for (int x = 21; x <= 36; x += 3) {
            PlaceBlock(level, DotDeco, x, 13, 38, chunkBox);
        }
    }
}
