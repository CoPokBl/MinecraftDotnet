using ManagedServer.Placement;
using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using static ManagedServer.Terrain.Structures.Types.WoodlandMansionStructure;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>WoodlandMansionPieces.FloorRoomCollection</c>: which template a floor uses for each room shape.
/// </summary>
/// <remarks>
/// The three floors differ only in these names, which is why the placer takes a collection rather than
/// a floor number. The third floor's collection is the second's, unchanged.
/// </remarks>
internal abstract class FloorRoomCollection {
    public abstract string Get1x1(RandomSource random);

    public abstract string Get1x1Secret(RandomSource random);

    public abstract string Get1x2SideEntrance(RandomSource random, bool isStairsRoom);

    public abstract string Get1x2FrontEntrance(RandomSource random, bool isStairsRoom);

    public abstract string Get1x2Secret(RandomSource random);

    public abstract string Get2x2(RandomSource random);

    public abstract string Get2x2Secret(RandomSource random);
}

internal sealed class FirstFloorRoomCollection : FloorRoomCollection {
    public override string Get1x1(RandomSource random) => "1x1_a" + (random.NextInt(5) + 1);

    public override string Get1x1Secret(RandomSource random) => "1x1_as" + (random.NextInt(4) + 1);

    public override string Get1x2SideEntrance(RandomSource random, bool isStairsRoom) {
        return "1x2_a" + (random.NextInt(9) + 1);
    }

    public override string Get1x2FrontEntrance(RandomSource random, bool isStairsRoom) {
        return "1x2_b" + (random.NextInt(5) + 1);
    }

    public override string Get1x2Secret(RandomSource random) => "1x2_s" + (random.NextInt(2) + 1);

    public override string Get2x2(RandomSource random) => "2x2_a" + (random.NextInt(4) + 1);

    public override string Get2x2Secret(RandomSource random) => "2x2_s1";
}

/// <summary>
/// The second floor's rooms, and the third floor's unchanged.
/// </summary>
/// <remarks>
/// <c>get1x2Secret</c> is <c>random.nextInt(1)</c>, which always answers zero and so always names
/// <c>1x2_se1</c>. The draw is still taken, so removing it would move everything after it.
/// </remarks>
internal class SecondFloorRoomCollection : FloorRoomCollection {
    public override string Get1x1(RandomSource random) => "1x1_b" + (random.NextInt(5) + 1);

    public override string Get1x1Secret(RandomSource random) => "1x1_as" + (random.NextInt(4) + 1);

    public override string Get1x2SideEntrance(RandomSource random, bool isStairsRoom) {
        return isStairsRoom ? "1x2_c_stairs" : "1x2_c" + (random.NextInt(4) + 1);
    }

    public override string Get1x2FrontEntrance(RandomSource random, bool isStairsRoom) {
        return isStairsRoom ? "1x2_d_stairs" : "1x2_d" + (random.NextInt(5) + 1);
    }

    public override string Get1x2Secret(RandomSource random) => "1x2_se" + (random.NextInt(1) + 1);

    public override string Get2x2(RandomSource random) => "2x2_b" + (random.NextInt(5) + 1);

    public override string Get2x2Secret(RandomSource random) => "2x2_s1";
}

internal sealed class ThirdFloorRoomCollection : SecondFloorRoomCollection;

/// <summary>Where the outer wall traversal has got to, which it carries round the mansion.</summary>
internal sealed class PlacementData {
    public BlockRotation Rotation;
    public Vec3<int> Position;
    public string WallType = string.Empty;
}

/// <summary>
/// <c>WoodlandMansionPieces.MansionPiecePlacer</c>: turns a finished grid into templates.
/// </summary>
/// <remarks>
/// Everything here is in <b>grid cells of eight blocks</b>, offset from the entrance cell, and every
/// position is built by stepping south and east in the mansion's own rotated frame. That is why
/// nothing uses absolute directions: the same arithmetic places a mansion facing any of four ways.
/// </remarks>
internal sealed class MansionPiecePlacer(StructureTemplateManager templates, RandomSource random) {
    private int _startX;
    private int _startY;

    public void CreateMansion(Vec3<int> origin, BlockRotation rotation,
        List<WoodlandMansionPiece> pieces, MansionGrid mansion) {

        PlacementData data = new() {
            Position = origin,
            Rotation = rotation,
            WallType = "wall_flat"
        };

        Entrance(pieces, data);

        PlacementData second = new() {
            Position = Above(data.Position, 8),
            Rotation = data.Rotation,
            WallType = "wall_window"
        };

        SimpleGrid baseGrid = mansion.BaseGrid;
        SimpleGrid thirdGrid = mansion.ThirdFloorGrid;

        _startX = mansion.EntranceX + 1;
        _startY = mansion.EntranceY + 1;

        int endX = mansion.EntranceX + 1;
        int endY = mansion.EntranceY;

        TraverseOuterWalls(pieces, data, baseGrid, Direction.South, _startX, _startY, endX, endY);
        TraverseOuterWalls(pieces, second, baseGrid, Direction.South, _startX, _startY, endX, endY);

        PlacementData third = new() {
            Position = Above(data.Position, 19),
            Rotation = data.Rotation,
            WallType = "wall_window"
        };

        // The third floor's walls start from the first house cell found scanning rows from the north
        // and columns from the east, which is what makes the tower sit over one end of the mansion.
        bool done = false;

        for (int y = 0; y < thirdGrid.Height && !done; y++) {
            for (int x = thirdGrid.Width - 1; x >= 0 && !done; x--) {
                if (!MansionGrid.IsHouse(thirdGrid, x, y)) {
                    continue;
                }

                third.Position = Relative(third.Position, Rotate(rotation, Direction.South),
                    8 + (y - _startY) * 8);

                third.Position = Relative(third.Position, Rotate(rotation, Direction.East),
                    (x - _startX) * 8);

                TraverseWallPiece(pieces, third);
                TraverseOuterWalls(pieces, third, thirdGrid, Direction.South, x, y, x, y);

                done = true;
            }
        }

        CreateRoof(pieces, Above(origin, 16), rotation, baseGrid, thirdGrid);
        CreateRoof(pieces, Above(origin, 27), rotation, thirdGrid, null);

        FloorRoomCollection[] collections = [
            new FirstFloorRoomCollection(),
            new SecondFloorRoomCollection(),
            new ThirdFloorRoomCollection()
        ];

        for (int floorNumber = 0; floorNumber < 3; floorNumber++) {
            Vec3<int> floorOrigin = Above(origin, 8 * floorNumber + (floorNumber == 2 ? 3 : 0));
            SimpleGrid rooms = mansion.FloorRooms[floorNumber];
            SimpleGrid grid = floorNumber == 2 ? thirdGrid : baseGrid;

            string southPiece = floorNumber == 0 ? "carpet_south_1" : "carpet_south_2";
            string westPiece = floorNumber == 0 ? "carpet_west_1" : "carpet_west_2";

            PlaceCorridors(pieces, rotation, grid, rooms, floorOrigin, southPiece, westPiece);

            PlaceRooms(pieces, mansion, rotation, grid, rooms, floorOrigin, floorNumber,
                collections[floorNumber]);
        }
    }

    /// <summary>The corridor floors and the carpets that edge them.</summary>
    private void PlaceCorridors(List<WoodlandMansionPiece> pieces, BlockRotation rotation,
        SimpleGrid grid, SimpleGrid rooms, Vec3<int> floorOrigin, string southPiece,
        string westPiece) {

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                if (grid.Get(x, y) != 1) {
                    continue;
                }

                Vec3<int> pos = Cell(floorOrigin, rotation, x, y);

                Add(pieces, "corridor_floor", pos, rotation);

                if (IsCorridorish(grid, rooms, x, y - 1)) {
                    Add(pieces, "carpet_north",
                        Above(Relative(pos, Rotate(rotation, Direction.East), 1), 1), rotation);
                }

                if (IsCorridorish(grid, rooms, x + 1, y)) {
                    Vec3<int> carpet = Relative(pos, Rotate(rotation, Direction.South), 1);
                    carpet = Relative(carpet, Rotate(rotation, Direction.East), 5);

                    Add(pieces, "carpet_east", Above(carpet, 1), rotation);
                }

                if (IsCorridorish(grid, rooms, x, y + 1)) {
                    Vec3<int> carpet = Relative(pos, Rotate(rotation, Direction.South), 5);
                    carpet = Relative(carpet, Rotate(rotation, Direction.West), 1);

                    Add(pieces, southPiece, carpet, rotation);
                }

                if (IsCorridorish(grid, rooms, x - 1, y)) {
                    Vec3<int> carpet = Relative(pos, Rotate(rotation, Direction.West), 1);
                    carpet = Relative(carpet, Rotate(rotation, Direction.North), 1);

                    Add(pieces, westPiece, carpet, rotation);
                }
            }
        }
    }

    /// <summary>
    /// A cell a carpet may run into: a corridor, or the entrance hall's own two cells.
    /// </summary>
    private static bool IsCorridorish(SimpleGrid grid, SimpleGrid rooms, int x, int y) {
        return grid.Get(x, y) == 1
            || (rooms.Get(x, y) & MansionGrid.CorridorFlag) == MansionGrid.CorridorFlag;
    }

    /// <summary>The inner walls, the doors through them, and the room contents behind them.</summary>
    private void PlaceRooms(List<WoodlandMansionPiece> pieces, MansionGrid mansion,
        BlockRotation rotation, SimpleGrid grid, SimpleGrid rooms, Vec3<int> floorOrigin,
        int floorNumber, FloorRoomCollection collection) {

        string wallPiece = floorNumber == 0 ? "indoors_wall_1" : "indoors_wall_2";
        string doorPiece = floorNumber == 0 ? "indoors_door_1" : "indoors_door_2";

        List<MansionDoor> doorDirections = [];

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                bool thirdFloorStartRoom = floorNumber == 2 && grid.Get(x, y) == 3;

                if (grid.Get(x, y) != 2 && !thirdFloorStartRoom) {
                    continue;
                }

                int data = rooms.Get(x, y);
                int type = data & MansionGrid.TypeMask;
                int roomId = data & MansionGrid.IdMask;

                thirdFloorStartRoom = thirdFloorStartRoom
                    && (data & MansionGrid.CorridorFlag) == MansionGrid.CorridorFlag;

                doorDirections.Clear();

                if ((data & MansionGrid.DoorFlag) == MansionGrid.DoorFlag) {
                    foreach (BlockFace face in Directions.Horizontal) {
                        Direction direction = face.ToDirection();

                        if (grid.Get(x + MansionGrid.StepX(direction),
                            y + MansionGrid.StepZ(direction)) == 1) {

                            doorDirections.Add(MansionDoors.Of(direction));
                        }
                    }
                }

                // Up stands for "no door at all", which is what marks a secret room. It is only
                // reachable through the origin flag, so a room with neither is left blank.
                MansionDoor? doorDirection = doorDirections.Count > 0
                    ? doorDirections[random.NextInt(doorDirections.Count)]
                    : (data & MansionGrid.OriginFlag) == MansionGrid.OriginFlag
                        ? MansionDoor.Up
                        : null;

                Vec3<int> roomPos = Relative(floorOrigin, Rotate(rotation, Direction.South),
                    8 + (y - _startY) * 8);

                roomPos = Relative(roomPos, Rotate(rotation, Direction.East),
                    -1 + (x - _startX) * 8);

                if (MansionGrid.IsHouse(grid, x - 1, y)
                    && !mansion.IsRoomId(grid, x - 1, y, floorNumber, roomId)) {

                    Add(pieces, doorDirection == MansionDoor.West ? doorPiece : wallPiece, roomPos,
                        rotation);
                }

                if (grid.Get(x + 1, y) == 1 && !thirdFloorStartRoom) {
                    Vec3<int> wall = Relative(roomPos, Rotate(rotation, Direction.East), 8);

                    Add(pieces, doorDirection == MansionDoor.East ? doorPiece : wallPiece, wall,
                        rotation);
                }

                if (MansionGrid.IsHouse(grid, x, y + 1)
                    && !mansion.IsRoomId(grid, x, y + 1, floorNumber, roomId)) {

                    Vec3<int> wall = Relative(roomPos, Rotate(rotation, Direction.South), 7);
                    wall = Relative(wall, Rotate(rotation, Direction.East), 7);

                    Add(pieces, doorDirection == MansionDoor.South ? doorPiece : wallPiece, wall,
                        Rotated(rotation, BlockRotation.Clockwise90));
                }

                if (grid.Get(x, y - 1) == 1 && !thirdFloorStartRoom) {
                    Vec3<int> wall = Relative(roomPos, Rotate(rotation, Direction.North), 1);
                    wall = Relative(wall, Rotate(rotation, Direction.East), 7);

                    Add(pieces, doorDirection == MansionDoor.North ? doorPiece : wallPiece, wall,
                        Rotated(rotation, BlockRotation.Clockwise90));
                }

                if (type == MansionGrid.Room1x1) {
                    AddRoom1x1(pieces, roomPos, rotation, doorDirection, collection);
                } else if (type == MansionGrid.Room1x2 && doorDirection is { } door1x2) {
                    Direction? roomDirection = mansion.Get1x2RoomDirection(grid, x, y, floorNumber,
                        roomId);

                    bool isStairsRoom = (data & MansionGrid.StairsFlag) == MansionGrid.StairsFlag;

                    AddRoom1x2(pieces, roomPos, rotation, roomDirection, door1x2, collection,
                        isStairsRoom);
                } else if (type == MansionGrid.Room2x2 && doorDirection is { } door2x2
                    && door2x2 != MansionDoor.Up) {

                    Direction roomDirection = door2x2.ToDirection().ClockWise();

                    if (!mansion.IsRoomId(grid, x + MansionGrid.StepX(roomDirection),
                        y + MansionGrid.StepZ(roomDirection), floorNumber, roomId)) {

                        roomDirection = roomDirection.Opposite();
                    }

                    AddRoom2x2(pieces, roomPos, rotation, roomDirection, door2x2, collection);
                } else if (type == MansionGrid.Room2x2 && doorDirection == MansionDoor.Up) {
                    AddRoom2x2Secret(pieces, roomPos, rotation, collection);
                }
            }
        }
    }

    /// <summary>
    /// Walks the outside of the mansion, placing a wall, a corner or an inner corner at each step.
    /// </summary>
    /// <remarks>
    /// A right hand wall follow: the walk turns clockwise where the cell ahead is outside, steps into
    /// an inner corner where the cell ahead and its left neighbour are both house, and otherwise walks
    /// on. It stops on returning to the starting cell <b>facing the way it started</b>, which is why
    /// the direction is part of the loop test.
    /// </remarks>
    private void TraverseOuterWalls(List<WoodlandMansionPiece> pieces, PlacementData data,
        SimpleGrid grid, Direction gridDirection, int startX, int startY, int endX, int endY) {

        int gridX = startX;
        int gridY = startY;
        Direction startDirection = gridDirection;

        do {
            int aheadX = gridX + MansionGrid.StepX(gridDirection);
            int aheadY = gridY + MansionGrid.StepZ(gridDirection);

            if (!MansionGrid.IsHouse(grid, aheadX, aheadY)) {
                TraverseTurn(pieces, data);
                gridDirection = gridDirection.ClockWise();

                if (gridX != endX || gridY != endY || startDirection != gridDirection) {
                    TraverseWallPiece(pieces, data);
                }

                continue;
            }

            Direction counter = gridDirection.CounterClockWise();

            if (MansionGrid.IsHouse(grid, aheadX + MansionGrid.StepX(counter),
                aheadY + MansionGrid.StepZ(counter))) {

                TraverseInnerTurn(pieces, data);
                gridX = aheadX;
                gridY = aheadY;
                gridDirection = counter;

                continue;
            }

            gridX = aheadX;
            gridY = aheadY;

            if (gridX != endX || gridY != endY || startDirection != gridDirection) {
                TraverseWallPiece(pieces, data);
            }
        } while (gridX != endX || gridY != endY || startDirection != gridDirection);
    }

    /// <summary>
    /// The roof over one floor, and the small walls where a floor above stands on it.
    /// </summary>
    /// <remarks>
    /// Three passes in a fixed order: the roof slabs and their fronts, then the small walls around a
    /// floor above, then the corner pieces. Splitting them is what lets a corner piece test the same
    /// cell the first pass already roofed.
    /// </remarks>
    private void CreateRoof(List<WoodlandMansionPiece> pieces, Vec3<int> roofOrigin,
        BlockRotation rotation, SimpleGrid grid, SimpleGrid? aboveGrid) {

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                Vec3<int> pos = Cell(roofOrigin, rotation, x, y);
                bool above = aboveGrid is not null && MansionGrid.IsHouse(aboveGrid, x, y);

                if (!MansionGrid.IsHouse(grid, x, y) || above) {
                    continue;
                }

                Add(pieces, "roof", Above(pos, 3), rotation);

                if (!MansionGrid.IsHouse(grid, x + 1, y)) {
                    Add(pieces, "roof_front",
                        Relative(pos, Rotate(rotation, Direction.East), 6), rotation);
                }

                if (!MansionGrid.IsHouse(grid, x - 1, y)) {
                    Vec3<int> front = Relative(pos, Rotate(rotation, Direction.South), 7);

                    Add(pieces, "roof_front", front,
                        Rotated(rotation, BlockRotation.Clockwise180));
                }

                if (!MansionGrid.IsHouse(grid, x, y - 1)) {
                    Add(pieces, "roof_front", Relative(pos, Rotate(rotation, Direction.West), 1),
                        Rotated(rotation, BlockRotation.CounterClockwise90));
                }

                if (!MansionGrid.IsHouse(grid, x, y + 1)) {
                    Vec3<int> front = Relative(pos, Rotate(rotation, Direction.East), 6);
                    front = Relative(front, Rotate(rotation, Direction.South), 6);

                    Add(pieces, "roof_front", front, Rotated(rotation, BlockRotation.Clockwise90));
                }
            }
        }

        if (aboveGrid is not null) {
            CreateSmallWalls(pieces, roofOrigin, rotation, grid, aboveGrid);
        }

        CreateRoofCorners(pieces, roofOrigin, rotation, grid, aboveGrid);
    }

    private void CreateSmallWalls(List<WoodlandMansionPiece> pieces, Vec3<int> roofOrigin,
        BlockRotation rotation, SimpleGrid grid, SimpleGrid aboveGrid) {

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                Vec3<int> pos = Cell(roofOrigin, rotation, x, y);

                if (!MansionGrid.IsHouse(grid, x, y) || !MansionGrid.IsHouse(aboveGrid, x, y)) {
                    continue;
                }

                bool east = !MansionGrid.IsHouse(grid, x + 1, y);
                bool west = !MansionGrid.IsHouse(grid, x - 1, y);
                bool north = !MansionGrid.IsHouse(grid, x, y - 1);
                bool south = !MansionGrid.IsHouse(grid, x, y + 1);

                if (east) {
                    Add(pieces, "small_wall", Relative(pos, Rotate(rotation, Direction.East), 7),
                        rotation);
                }

                if (west) {
                    Vec3<int> wall = Relative(pos, Rotate(rotation, Direction.West), 1);
                    wall = Relative(wall, Rotate(rotation, Direction.South), 6);

                    Add(pieces, "small_wall", wall, Rotated(rotation, BlockRotation.Clockwise180));
                }

                if (north) {
                    Vec3<int> wall = Relative(pos, Rotate(rotation, Direction.North), 1);

                    Add(pieces, "small_wall", wall,
                        Rotated(rotation, BlockRotation.CounterClockwise90));
                }

                if (south) {
                    Vec3<int> wall = Relative(pos, Rotate(rotation, Direction.East), 6);
                    wall = Relative(wall, Rotate(rotation, Direction.South), 7);

                    Add(pieces, "small_wall", wall, Rotated(rotation, BlockRotation.Clockwise90));
                }

                if (east && north) {
                    Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.East), 7);
                    corner = Relative(corner, Rotate(rotation, Direction.North), 2);

                    Add(pieces, "small_wall_corner", corner, rotation);
                }

                if (east && south) {
                    Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.East), 8);
                    corner = Relative(corner, Rotate(rotation, Direction.South), 7);

                    Add(pieces, "small_wall_corner", corner,
                        Rotated(rotation, BlockRotation.Clockwise90));
                }

                if (west && north) {
                    Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.West), 2);
                    corner = Relative(corner, Rotate(rotation, Direction.North), 1);

                    Add(pieces, "small_wall_corner", corner,
                        Rotated(rotation, BlockRotation.CounterClockwise90));
                }

                if (west && south) {
                    Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.West), 1);
                    corner = Relative(corner, Rotate(rotation, Direction.South), 8);

                    Add(pieces, "small_wall_corner", corner,
                        Rotated(rotation, BlockRotation.Clockwise180));
                }
            }
        }
    }

    private void CreateRoofCorners(List<WoodlandMansionPiece> pieces, Vec3<int> roofOrigin,
        BlockRotation rotation, SimpleGrid grid, SimpleGrid? aboveGrid) {

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                Vec3<int> pos = Cell(roofOrigin, rotation, x, y);
                bool above = aboveGrid is not null && MansionGrid.IsHouse(aboveGrid, x, y);

                if (!MansionGrid.IsHouse(grid, x, y) || above) {
                    continue;
                }

                if (!MansionGrid.IsHouse(grid, x + 1, y)) {
                    Vec3<int> east = Relative(pos, Rotate(rotation, Direction.East), 6);

                    if (!MansionGrid.IsHouse(grid, x, y + 1)) {
                        Add(pieces, "roof_corner",
                            Relative(east, Rotate(rotation, Direction.South), 6), rotation);
                    } else if (MansionGrid.IsHouse(grid, x + 1, y + 1)) {
                        Add(pieces, "roof_inner_corner",
                            Relative(east, Rotate(rotation, Direction.South), 5), rotation);
                    }

                    if (!MansionGrid.IsHouse(grid, x, y - 1)) {
                        Add(pieces, "roof_corner", east,
                            Rotated(rotation, BlockRotation.CounterClockwise90));
                    } else if (MansionGrid.IsHouse(grid, x + 1, y - 1)) {
                        Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.East), 9);
                        corner = Relative(corner, Rotate(rotation, Direction.North), 2);

                        Add(pieces, "roof_inner_corner", corner,
                            Rotated(rotation, BlockRotation.Clockwise90));
                    }
                }

                if (MansionGrid.IsHouse(grid, x - 1, y)) {
                    continue;
                }

                if (!MansionGrid.IsHouse(grid, x, y + 1)) {
                    Add(pieces, "roof_corner",
                        Relative(pos, Rotate(rotation, Direction.South), 6),
                        Rotated(rotation, BlockRotation.Clockwise90));
                } else if (MansionGrid.IsHouse(grid, x - 1, y + 1)) {
                    Vec3<int> corner = Relative(pos, Rotate(rotation, Direction.South), 8);
                    corner = Relative(corner, Rotate(rotation, Direction.West), 3);

                    Add(pieces, "roof_inner_corner", corner,
                        Rotated(rotation, BlockRotation.CounterClockwise90));
                }

                if (!MansionGrid.IsHouse(grid, x, y - 1)) {
                    Add(pieces, "roof_corner", pos, Rotated(rotation, BlockRotation.Clockwise180));
                } else if (MansionGrid.IsHouse(grid, x - 1, y - 1)) {
                    Add(pieces, "roof_inner_corner",
                        Relative(pos, Rotate(rotation, Direction.South), 1),
                        Rotated(rotation, BlockRotation.Clockwise180));
                }
            }
        }
    }

    private void Entrance(List<WoodlandMansionPiece> pieces, PlacementData data) {
        Direction west = Rotate(data.Rotation, Direction.West);

        Add(pieces, "entrance", Relative(data.Position, west, 9), data.Rotation);

        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.South), 16);
    }

    private void TraverseWallPiece(List<WoodlandMansionPiece> pieces, PlacementData data) {
        Add(pieces, data.WallType,
            Relative(data.Position, Rotate(data.Rotation, Direction.East), 7), data.Rotation);

        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.South), 8);
    }

    private void TraverseTurn(List<WoodlandMansionPiece> pieces, PlacementData data) {
        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.South), -1);

        Add(pieces, "wall_corner", data.Position, data.Rotation);

        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.South), -7);
        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.West), -6);
        data.Rotation = Rotated(data.Rotation, BlockRotation.Clockwise90);
    }

    private static void TraverseInnerTurn(List<WoodlandMansionPiece> pieces, PlacementData data) {
        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.South), 6);
        data.Position = Relative(data.Position, Rotate(data.Rotation, Direction.East), 8);
        data.Rotation = Rotated(data.Rotation, BlockRotation.CounterClockwise90);
    }

    /// <summary>
    /// A one cell room, turned so its door faces the corridor.
    /// </summary>
    /// <remarks>
    /// East is the template's own facing, so it needs no turn. Anything that is not one of the four
    /// horizontals is the secret room, which is the <c>else</c> at the end rather than a separate
    /// test.
    /// </remarks>
    private void AddRoom1x1(List<WoodlandMansionPiece> pieces, Vec3<int> roomPos,
        BlockRotation rotation, MansionDoor? doorDirection, FloorRoomCollection rooms) {

        BlockRotation pieceRotation = BlockRotation.None;
        string roomType = rooms.Get1x1(random);

        if (doorDirection != MansionDoor.East) {
            if (doorDirection == MansionDoor.North) {
                pieceRotation = Rotated(pieceRotation, BlockRotation.CounterClockwise90);
            } else if (doorDirection == MansionDoor.West) {
                pieceRotation = Rotated(pieceRotation, BlockRotation.Clockwise180);
            } else if (doorDirection == MansionDoor.South) {
                pieceRotation = Rotated(pieceRotation, BlockRotation.Clockwise90);
            } else {
                roomType = rooms.Get1x1Secret(random);
            }
        }

        Vec3<int> orientation = StructureTemplate.ZeroPositionWithTransform(new Vec3<int>(1, 0, 0),
            BlockMirror.None, pieceRotation, 7, 7);

        pieceRotation = Rotated(pieceRotation, rotation);
        orientation = RotateOffset(orientation, rotation);

        Vec3<int> pos = new(roomPos.X + orientation.X, roomPos.Y, roomPos.Z + orientation.Z);

        Add(pieces, roomType, pos, pieceRotation);
    }

    /// <summary>
    /// A two cell room, in one of twelve arrangements of door direction against room direction.
    /// </summary>
    /// <remarks>
    /// Eight are side entrances, four are front entrances, and the last two are the secret room. There
    /// is no arrangement for a door up with the room running north or west, which is why a 1x2 secret
    /// room only ever appears in two of the four orientations.
    /// </remarks>
    private void AddRoom1x2(List<WoodlandMansionPiece> pieces, Vec3<int> roomPos,
        BlockRotation rotation, Direction? roomDirection, MansionDoor doorDirection,
        FloorRoomCollection rooms, bool isStairsRoom) {

        Direction east = Rotate(rotation, Direction.East);
        Direction south = Rotate(rotation, Direction.South);
        Direction north = Rotate(rotation, Direction.North);
        Direction west = Rotate(rotation, Direction.West);

        switch (doorDirection, roomDirection) {
            case (MansionDoor.East, Direction.South):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(roomPos, east, 1), rotation);
                return;

            case (MansionDoor.East, Direction.North):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 1), south, 6), rotation, BlockMirror.LeftRight);
                return;

            case (MansionDoor.West, Direction.North):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 7), south, 6),
                    Rotated(rotation, BlockRotation.Clockwise180));
                return;

            case (MansionDoor.West, Direction.South):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(roomPos, east, 7), rotation, BlockMirror.FrontBack);
                return;

            case (MansionDoor.South, Direction.East):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(roomPos, east, 1), Rotated(rotation, BlockRotation.Clockwise90),
                    BlockMirror.LeftRight);
                return;

            case (MansionDoor.South, Direction.West):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(roomPos, east, 7), Rotated(rotation, BlockRotation.Clockwise90));
                return;

            case (MansionDoor.North, Direction.West):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 7), south, 6),
                    Rotated(rotation, BlockRotation.Clockwise90), BlockMirror.FrontBack);
                return;

            case (MansionDoor.North, Direction.East):
                Add(pieces, rooms.Get1x2SideEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 1), south, 6),
                    Rotated(rotation, BlockRotation.CounterClockwise90));
                return;

            case (MansionDoor.South, Direction.North):
                Add(pieces, rooms.Get1x2FrontEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 1), north, 8), rotation);
                return;

            case (MansionDoor.North, Direction.South):
                Add(pieces, rooms.Get1x2FrontEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, east, 7), south, 14),
                    Rotated(rotation, BlockRotation.Clockwise180));
                return;

            case (MansionDoor.West, Direction.East):
                Add(pieces, rooms.Get1x2FrontEntrance(random, isStairsRoom),
                    Relative(roomPos, east, 15), Rotated(rotation, BlockRotation.Clockwise90));
                return;

            case (MansionDoor.East, Direction.West):
                Add(pieces, rooms.Get1x2FrontEntrance(random, isStairsRoom),
                    Relative(Relative(roomPos, west, 7), south, 6),
                    Rotated(rotation, BlockRotation.CounterClockwise90));
                return;

            case (MansionDoor.Up, Direction.East):
                Add(pieces, rooms.Get1x2Secret(random), Relative(roomPos, east, 15),
                    Rotated(rotation, BlockRotation.Clockwise90));
                return;

            case (MansionDoor.Up, Direction.South):
                Add(pieces, rooms.Get1x2Secret(random), Relative(roomPos, east, 1), rotation);
                return;
        }
    }

    /// <summary>
    /// A four cell room, whose eight arrangements are an offset, a rotation and sometimes a mirror.
    /// </summary>
    private void AddRoom2x2(List<WoodlandMansionPiece> pieces, Vec3<int> roomPos,
        BlockRotation rotation, Direction roomDirection, MansionDoor doorDirection,
        FloorRoomCollection rooms) {

        int east = 0;
        int south = 0;
        BlockRotation pieceRotation = rotation;
        BlockMirror mirror = BlockMirror.None;

        switch (doorDirection, roomDirection) {
            case (MansionDoor.East, Direction.South):
                east = -7;
                break;

            case (MansionDoor.East, Direction.North):
                east = -7;
                south = 6;
                mirror = BlockMirror.LeftRight;
                break;

            case (MansionDoor.North, Direction.East):
                east = 1;
                south = 14;
                pieceRotation = Rotated(rotation, BlockRotation.CounterClockwise90);
                break;

            case (MansionDoor.North, Direction.West):
                east = 7;
                south = 14;
                pieceRotation = Rotated(rotation, BlockRotation.CounterClockwise90);
                mirror = BlockMirror.LeftRight;
                break;

            case (MansionDoor.South, Direction.West):
                east = 7;
                south = -8;
                pieceRotation = Rotated(rotation, BlockRotation.Clockwise90);
                break;

            case (MansionDoor.South, Direction.East):
                east = 1;
                south = -8;
                pieceRotation = Rotated(rotation, BlockRotation.Clockwise90);
                mirror = BlockMirror.LeftRight;
                break;

            case (MansionDoor.West, Direction.North):
                east = 15;
                south = 6;
                pieceRotation = Rotated(rotation, BlockRotation.Clockwise180);
                break;

            case (MansionDoor.West, Direction.South):
                east = 15;
                mirror = BlockMirror.FrontBack;
                break;
        }

        Vec3<int> pos = Relative(roomPos, Rotate(rotation, Direction.East), east);
        pos = Relative(pos, Rotate(rotation, Direction.South), south);

        Add(pieces, rooms.Get2x2(random), pos, pieceRotation, mirror);
    }

    private void AddRoom2x2Secret(List<WoodlandMansionPiece> pieces, Vec3<int> roomPos,
        BlockRotation rotation, FloorRoomCollection rooms) {

        Add(pieces, rooms.Get2x2Secret(random),
            Relative(roomPos, Rotate(rotation, Direction.East), 1), rotation, BlockMirror.None);
    }

    // ------------------------------------------------------------------ helpers

    private void Add(List<WoodlandMansionPiece> pieces, string template, Vec3<int> position,
        BlockRotation rotation, BlockMirror mirror = BlockMirror.None) {

        pieces.Add(new WoodlandMansionPiece(templates, template, position, rotation, mirror));
    }

    /// <summary>Where a grid cell's origin sits, in the mansion's own rotated frame.</summary>
    private Vec3<int> Cell(Vec3<int> origin, BlockRotation rotation, int x, int y) {
        Vec3<int> pos = Relative(origin, Rotate(rotation, Direction.South),
            8 + (y - _startY) * 8);

        return Relative(pos, Rotate(rotation, Direction.East), (x - _startX) * 8);
    }

    private static Vec3<int> Relative(Vec3<int> pos, Direction direction, int distance) {
        return new Vec3<int>(pos.X + MansionGrid.StepX(direction) * distance, pos.Y,
            pos.Z + MansionGrid.StepZ(direction) * distance);
    }

    private static Vec3<int> Above(Vec3<int> pos, int distance) {
        return new Vec3<int>(pos.X, pos.Y + distance, pos.Z);
    }

    /// <summary><c>BlockPos.rotate</c>: a position turned about the origin.</summary>
    private static Vec3<int> RotateOffset(Vec3<int> pos, BlockRotation rotation) {
        return rotation switch {
            BlockRotation.Clockwise90 => new Vec3<int>(-pos.Z, pos.Y, pos.X),
            BlockRotation.Clockwise180 => new Vec3<int>(-pos.X, pos.Y, -pos.Z),
            BlockRotation.CounterClockwise90 => new Vec3<int>(pos.Z, pos.Y, -pos.X),
            _ => pos
        };
    }

    internal static Direction Rotate(BlockRotation rotation, Direction direction) {
        return BlockStateTransform.RotateFace(direction.ToFace(), rotation).ToDirection();
    }

    /// <summary><c>Rotation.getRotated</c>: the two turns composed, which is addition modulo four.</summary>
    internal static BlockRotation Rotated(BlockRotation rotation, BlockRotation by) {
        return (BlockRotation)(((int)rotation + (int)by) % 4);
    }
}
