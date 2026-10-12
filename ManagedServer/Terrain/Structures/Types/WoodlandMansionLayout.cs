using ManagedServer.Terrain.Structures.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using static ManagedServer.Terrain.Structures.Types.WoodlandMansionStructure;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// Which side of a room its door is on.
/// </summary>
/// <remarks>
/// Vanilla uses <c>Direction.UP</c> for the fifth case, meaning a room with no door at all, which is
/// what a secret room is. That value cannot live in a horizontal-only direction type, so the five are
/// their own enum here and the four real ones convert back.
/// </remarks>
internal enum MansionDoor {
    North,
    South,
    East,
    West,

    /// <summary>No door: the room is reached through the ceiling, or not at all.</summary>
    Up
}

internal static class MansionDoors {
    public static MansionDoor Of(Direction direction) {
        return direction switch {
            Direction.North => MansionDoor.North,
            Direction.South => MansionDoor.South,
            Direction.East => MansionDoor.East,
            _ => MansionDoor.West
        };
    }

    public static Direction ToDirection(this MansionDoor door) {
        return door switch {
            MansionDoor.North => Direction.North,
            MansionDoor.South => Direction.South,
            MansionDoor.East => Direction.East,
            MansionDoor.West => Direction.West,
            _ => throw new InvalidOperationException("A doorless room has no direction.")
        };
    }
}

/// <summary>
/// <c>WoodlandMansionPieces.SimpleGrid</c>: a small int grid that answers a fixed value outside itself.
/// </summary>
/// <remarks>
/// The value outside is what makes the layout algorithm terminate without bounds checks: it is five,
/// meaning blocked, so a corridor grown at the edge sees a wall rather than an index error.
/// </remarks>
internal sealed class SimpleGrid(int width, int height, int valueIfOutside) {
    private readonly int[,] _grid = new int[width, height];

    public int Width => width;

    public int Height => height;

    public void Set(int x, int y, int value) {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            _grid[x, y] = value;
        }
    }

    public void Set(int x0, int y0, int x1, int y1, int value) {
        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                Set(x, y, value);
            }
        }
    }

    public int Get(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height ? _grid[x, y] : valueIfOutside;
    }

    public void SetIf(int x, int y, int ifValue, int value) {
        if (Get(x, y) == ifValue) {
            Set(x, y, value);
        }
    }

    public bool EdgesTo(int x, int y, int ifValue) {
        return Get(x - 1, y) == ifValue || Get(x + 1, y) == ifValue
            || Get(x, y + 1) == ifValue || Get(x, y - 1) == ifValue;
    }
}

/// <summary>
/// <c>WoodlandMansionPieces.MansionGrid</c>: which cell of the mansion is corridor, room or outside,
/// on each of its three floors.
/// </summary>
/// <remarks>
/// A cell's value is a <b>bitfield</b> once rooms have been identified: the low sixteen bits are a
/// room id, one nibble above that says whether the room is 1x1, 1x2 or 2x2, and four flags above
/// those mark the room's origin cell, its door cell, the stairs room and the corridor cells the
/// entrance hall occupies. Almost every test in the placer is a mask against one of them.
/// </remarks>
internal sealed class MansionGrid {
    private const int Clear = 0;
    private const int Corridor = 1;
    private const int Room = 2;
    private const int StartRoom = 3;
    private const int Blocked = 5;

    public const int Room1x1 = 65536;
    public const int Room1x2 = 131072;
    public const int Room2x2 = 262144;

    public const int OriginFlag = 1048576;
    public const int DoorFlag = 2097152;
    public const int StairsFlag = 4194304;
    public const int CorridorFlag = 8388608;

    public const int TypeMask = 983040;
    public const int IdMask = 65535;

    private readonly RandomSource _random;

    public SimpleGrid BaseGrid { get; }

    public SimpleGrid ThirdFloorGrid { get; }

    public SimpleGrid[] FloorRooms { get; }

    public int EntranceX { get; }

    public int EntranceY { get; }

    /// <summary>
    /// Builds the whole layout: the entrance hall, four corridors grown west from it, the rooms
    /// filling what is left, and a third floor over one of the second floor's rooms.
    /// </summary>
    /// <remarks>
    /// The first two floors share <see cref="BaseGrid"/> and differ only in how their rooms were
    /// grouped, which is why <c>identifyRooms</c> is run twice over the same grid: the shuffle inside
    /// it is what makes the two floors different.
    /// </remarks>
    public MansionGrid(RandomSource random) {
        _random = random;

        EntranceX = 7;
        EntranceY = 4;

        BaseGrid = new SimpleGrid(11, 11, Blocked);

        BaseGrid.Set(EntranceX, EntranceY, EntranceX + 1, EntranceY + 1, StartRoom);
        BaseGrid.Set(EntranceX - 1, EntranceY, EntranceX - 1, EntranceY + 1, Room);
        BaseGrid.Set(EntranceX + 2, EntranceY - 2, EntranceX + 3, EntranceY + 3, Blocked);
        BaseGrid.Set(EntranceX + 1, EntranceY - 2, EntranceX + 1, EntranceY - 1, Corridor);
        BaseGrid.Set(EntranceX + 1, EntranceY + 2, EntranceX + 1, EntranceY + 3, Corridor);
        BaseGrid.Set(EntranceX - 1, EntranceY - 1, Corridor);
        BaseGrid.Set(EntranceX - 1, EntranceY + 2, Corridor);
        BaseGrid.Set(0, 0, 11, 1, Blocked);
        BaseGrid.Set(0, 9, 11, 11, Blocked);

        RecursiveCorridor(BaseGrid, EntranceX, EntranceY - 2, Direction.West, 6);
        RecursiveCorridor(BaseGrid, EntranceX, EntranceY + 3, Direction.West, 6);
        RecursiveCorridor(BaseGrid, EntranceX - 2, EntranceY - 1, Direction.West, 3);
        RecursiveCorridor(BaseGrid, EntranceX - 2, EntranceY + 2, Direction.West, 3);

        while (CleanEdges(BaseGrid)) { }

        FloorRooms = [
            new SimpleGrid(11, 11, Blocked),
            new SimpleGrid(11, 11, Blocked),
            new SimpleGrid(11, 11, Blocked)
        ];

        IdentifyRooms(BaseGrid, FloorRooms[0]);
        IdentifyRooms(BaseGrid, FloorRooms[1]);

        FloorRooms[0].Set(EntranceX + 1, EntranceY, EntranceX + 1, EntranceY + 1, CorridorFlag);
        FloorRooms[1].Set(EntranceX + 1, EntranceY, EntranceX + 1, EntranceY + 1, CorridorFlag);

        ThirdFloorGrid = new SimpleGrid(BaseGrid.Width, BaseGrid.Height, Blocked);
        SetupThirdFloor();
        IdentifyRooms(ThirdFloorGrid, FloorRooms[2]);
    }

    public static bool IsHouse(SimpleGrid grid, int x, int y) {
        int value = grid.Get(x, y);
        return value is Corridor or Room or StartRoom or 4;
    }

    public bool IsRoomId(SimpleGrid grid, int x, int y, int floor, int roomId) {
        return (FloorRooms[floor].Get(x, y) & IdMask) == roomId;
    }

    /// <summary>Which way the other half of a 1x2 room lies, or null where there is none.</summary>
    public Direction? Get1x2RoomDirection(SimpleGrid grid, int x, int y, int floor, int roomId) {
        foreach (BlockFace face in Directions.Horizontal) {
            Direction direction = face.ToDirection();

            if (IsRoomId(grid, x + StepX(direction), y + StepZ(direction), floor, roomId)) {
                return direction;
            }
        }

        return null;
    }

    /// <summary>
    /// Grows one corridor, turning at random and marking rooms alongside it.
    /// </summary>
    /// <remarks>
    /// The turn is drawn up to <b>eight times</b> and the first draw that is neither a reversal nor a
    /// rejected east step wins, so a corridor that cannot turn anywhere simply stops. The east
    /// rejection is a coin flip rather than a ban, which is what biases the mansion west away from
    /// its entrance.
    /// </remarks>
    private void RecursiveCorridor(SimpleGrid grid, int x, int y, Direction heading, int depth) {
        if (depth <= 0) {
            return;
        }

        grid.Set(x, y, Corridor);
        grid.SetIf(x + StepX(heading), y + StepZ(heading), Clear, Corridor);

        for (int attempt = 0; attempt < 8; attempt++) {
            Direction next = Directions.From2DDataValue(_random.NextInt(4));

            if (next == heading.Opposite() || (next == Direction.East && _random.NextBoolean())) {
                continue;
            }

            int nx = x + StepX(heading);
            int ny = y + StepZ(heading);

            if (grid.Get(nx + StepX(next), ny + StepZ(next)) == Clear
                && grid.Get(nx + StepX(next) * 2, ny + StepZ(next) * 2) == Clear) {

                RecursiveCorridor(grid, x + StepX(heading) + StepX(next),
                    y + StepZ(heading) + StepZ(next), next, depth - 1);

                break;
            }
        }

        Direction clockwise = heading.ClockWise();
        Direction counter = heading.CounterClockWise();

        grid.SetIf(x + StepX(clockwise), y + StepZ(clockwise), Clear, Room);
        grid.SetIf(x + StepX(counter), y + StepZ(counter), Clear, Room);
        grid.SetIf(x + StepX(heading) + StepX(clockwise), y + StepZ(heading) + StepZ(clockwise),
            Clear, Room);
        grid.SetIf(x + StepX(heading) + StepX(counter), y + StepZ(heading) + StepZ(counter),
            Clear, Room);
        grid.SetIf(x + StepX(heading) * 2, y + StepZ(heading) * 2, Clear, Room);
        grid.SetIf(x + StepX(clockwise) * 2, y + StepZ(clockwise) * 2, Clear, Room);
        grid.SetIf(x + StepX(counter) * 2, y + StepZ(counter) * 2, Clear, Room);
    }

    /// <summary>
    /// Fills in the cells a corridor left almost surrounded, run until nothing changes.
    /// </summary>
    /// <remarks>
    /// Three neighbours always becomes a room; exactly two becomes one only when at most one diagonal
    /// is also house, which is what fills a notch without squaring off a corner.
    /// </remarks>
    private static bool CleanEdges(SimpleGrid grid) {
        bool touched = false;

        for (int y = 0; y < grid.Height; y++) {
            for (int x = 0; x < grid.Width; x++) {
                if (grid.Get(x, y) != Clear) {
                    continue;
                }

                int direct = (IsHouse(grid, x + 1, y) ? 1 : 0)
                    + (IsHouse(grid, x - 1, y) ? 1 : 0)
                    + (IsHouse(grid, x, y + 1) ? 1 : 0)
                    + (IsHouse(grid, x, y - 1) ? 1 : 0);

                if (direct >= 3) {
                    grid.Set(x, y, Room);
                    touched = true;
                    continue;
                }

                if (direct != 2) {
                    continue;
                }

                int diagonal = (IsHouse(grid, x + 1, y + 1) ? 1 : 0)
                    + (IsHouse(grid, x - 1, y + 1) ? 1 : 0)
                    + (IsHouse(grid, x + 1, y - 1) ? 1 : 0)
                    + (IsHouse(grid, x - 1, y - 1) ? 1 : 0);

                if (diagonal <= 1) {
                    grid.Set(x, y, Room);
                    touched = true;
                }
            }
        }

        return touched;
    }

    /// <summary>
    /// Picks one second floor room to become the stairs up, and grows the third floor off it.
    /// </summary>
    /// <remarks>
    /// A mansion with no 1x2 room carrying a door, or whose chosen room has nowhere for a corridor to
    /// leave, gets <b>no third floor at all</b>: the grid is filled with blocked and the stairs flag
    /// is taken back off. That is why the flag is written before the corridor test rather than after.
    /// </remarks>
    private void SetupThirdFloor() {
        List<(int X, int Y)> potentialRooms = [];
        SimpleGrid floor = FloorRooms[1];

        for (int y = 0; y < ThirdFloorGrid.Height; y++) {
            for (int x = 0; x < ThirdFloorGrid.Width; x++) {
                int data = floor.Get(x, y);

                if ((data & TypeMask) == Room1x2 && (data & DoorFlag) == DoorFlag) {
                    potentialRooms.Add((x, y));
                }
            }
        }

        if (potentialRooms.Count == 0) {
            ThirdFloorGrid.Set(0, 0, ThirdFloorGrid.Width, ThirdFloorGrid.Height, Blocked);
            return;
        }

        (int roomX, int roomY) = potentialRooms[_random.NextInt(potentialRooms.Count)];
        int roomData = floor.Get(roomX, roomY);
        floor.Set(roomX, roomY, roomData | StairsFlag);

        Direction roomDirection = Get1x2RoomDirection(BaseGrid, roomX, roomY, 1, roomData & IdMask)
            ?? throw new InvalidOperationException(
                "A mansion's stairs room has no second half, which its 1x2 type says it must.");

        int endX = roomX + StepX(roomDirection);
        int endY = roomY + StepZ(roomDirection);

        for (int y = 0; y < ThirdFloorGrid.Height; y++) {
            for (int x = 0; x < ThirdFloorGrid.Width; x++) {
                if (!IsHouse(BaseGrid, x, y)) {
                    ThirdFloorGrid.Set(x, y, Blocked);
                } else if (x == roomX && y == roomY) {
                    ThirdFloorGrid.Set(x, y, StartRoom);
                } else if (x == endX && y == endY) {
                    ThirdFloorGrid.Set(x, y, StartRoom);
                    FloorRooms[2].Set(x, y, CorridorFlag);
                }
            }
        }

        List<Direction> potentialCorridors = [];

        foreach (BlockFace face in Directions.Horizontal) {
            Direction direction = face.ToDirection();

            if (ThirdFloorGrid.Get(endX + StepX(direction), endY + StepZ(direction)) == Clear) {
                potentialCorridors.Add(direction);
            }
        }

        if (potentialCorridors.Count == 0) {
            ThirdFloorGrid.Set(0, 0, ThirdFloorGrid.Width, ThirdFloorGrid.Height, Blocked);
            floor.Set(roomX, roomY, roomData);
            return;
        }

        Direction corridor = potentialCorridors[_random.NextInt(potentialCorridors.Count)];

        RecursiveCorridor(ThirdFloorGrid, endX + StepX(corridor), endY + StepZ(corridor), corridor, 4);

        while (CleanEdges(ThirdFloorGrid)) { }
    }

    /// <summary>
    /// Groups the room cells of a grid into rooms, and picks each one's door cell.
    /// </summary>
    /// <remarks>
    /// The cells are <b>shuffled first</b>, which is the whole of why two floors sharing one grid have
    /// different rooms: a 2x2 is only formed when the cell drawn first has three free neighbours, so
    /// the draw order decides which groupings win.
    /// <p/>
    /// The door cell is drawn as a pair of coin flips over the room's own corners and then walked
    /// around until one of them touches a corridor. All four failing leaves the room <b>doorless</b>,
    /// which is what a secret room is.
    /// </remarks>
    private void IdentifyRooms(SimpleGrid fromGrid, SimpleGrid roomGrid) {
        List<(int X, int Y)> cells = [];

        for (int y = 0; y < fromGrid.Height; y++) {
            for (int x = 0; x < fromGrid.Width; x++) {
                if (fromGrid.Get(x, y) == Room) {
                    cells.Add((x, y));
                }
            }
        }

        StructurePiece.Shuffle(cells, _random);

        int roomId = 10;

        foreach ((int x, int y) in cells) {
            if (roomGrid.Get(x, y) != Clear) {
                continue;
            }

            int x0 = x;
            int x1 = x;
            int y0 = y;
            int y1 = y;
            int type = Room1x1;

            if (Free(roomGrid, fromGrid, x + 1, y) && Free(roomGrid, fromGrid, x, y + 1)
                && Free(roomGrid, fromGrid, x + 1, y + 1)) {

                x1 = x + 1;
                y1 = y + 1;
                type = Room2x2;
            } else if (Free(roomGrid, fromGrid, x - 1, y) && Free(roomGrid, fromGrid, x, y + 1)
                && Free(roomGrid, fromGrid, x - 1, y + 1)) {

                x0 = x - 1;
                y1 = y + 1;
                type = Room2x2;
            } else if (Free(roomGrid, fromGrid, x - 1, y) && Free(roomGrid, fromGrid, x, y - 1)
                && Free(roomGrid, fromGrid, x - 1, y - 1)) {

                x0 = x - 1;
                y0 = y - 1;
                type = Room2x2;
            } else if (Free(roomGrid, fromGrid, x + 1, y)) {
                x1 = x + 1;
                type = Room1x2;
            } else if (Free(roomGrid, fromGrid, x, y + 1)) {
                y1 = y + 1;
                type = Room1x2;
            } else if (Free(roomGrid, fromGrid, x - 1, y)) {
                x0 = x - 1;
                type = Room1x2;
            } else if (Free(roomGrid, fromGrid, x, y - 1)) {
                y0 = y - 1;
                type = Room1x2;
            }

            int doorX = _random.NextBoolean() ? x0 : x1;
            int doorY = _random.NextBoolean() ? y0 : y1;
            int doorFlag = DoorFlag;

            if (!fromGrid.EdgesTo(doorX, doorY, Corridor)) {
                doorX = doorX == x0 ? x1 : x0;
                doorY = doorY == y0 ? y1 : y0;

                if (!fromGrid.EdgesTo(doorX, doorY, Corridor)) {
                    doorY = doorY == y0 ? y1 : y0;

                    if (!fromGrid.EdgesTo(doorX, doorY, Corridor)) {
                        doorX = doorX == x0 ? x1 : x0;
                        doorY = doorY == y0 ? y1 : y0;

                        if (!fromGrid.EdgesTo(doorX, doorY, Corridor)) {
                            doorFlag = 0;
                            doorX = x0;
                            doorY = y0;
                        }
                    }
                }
            }

            for (int ry = y0; ry <= y1; ry++) {
                for (int rx = x0; rx <= x1; rx++) {
                    roomGrid.Set(rx, ry, rx == doorX && ry == doorY
                        ? OriginFlag | doorFlag | type | roomId
                        : type | roomId);
                }
            }

            roomId++;
        }
    }

    /// <summary>A cell that is a room in the source grid and not yet claimed in the room grid.</summary>
    private static bool Free(SimpleGrid roomGrid, SimpleGrid fromGrid, int x, int y) {
        return roomGrid.Get(x, y) == Clear && fromGrid.Get(x, y) == Room;
    }

    internal static int StepX(Direction direction) {
        return direction switch {
            Direction.East => 1,
            Direction.West => -1,
            _ => 0
        };
    }

    internal static int StepZ(Direction direction) {
        return direction switch {
            Direction.South => 1,
            Direction.North => -1,
            _ => 0
        };
    }
}
