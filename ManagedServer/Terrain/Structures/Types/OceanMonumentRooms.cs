using ManagedServer.Terrain.Features;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// The seven room fitters, in the order the building tries them.
/// </summary>
/// <remarks>
/// A fitter both tests a cell and <b>claims</b> the cells it will occupy, so the two halves cannot be
/// separated: asking whether a double room fits and then building something else there would leave the
/// second cell claimed by nothing.
/// </remarks>
file static class Faces {
    public const int Down = (int)BlockFace.NegY;
    public const int Up = (int)BlockFace.PosY;
    public const int North = (int)BlockFace.NegZ;
    public const int South = (int)BlockFace.PosZ;
    public const int West = (int)BlockFace.NegX;
    public const int East = (int)BlockFace.PosX;
}

/// <summary>A room two cells wide, joined east.</summary>
public sealed class FitDoubleXRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        return room.HasOpening[Faces.East] && !room.Connections[Faces.East]!.Claimed;
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        room.Connections[Faces.East]!.Claimed = true;
        return new MonumentDoubleXRoom(orientation, room);
    }
}

/// <summary>A room two cells wide and two tall, so four cells in all.</summary>
public sealed class FitDoubleXYRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        if (!room.HasOpening[Faces.East] || room.Connections[Faces.East]!.Claimed
            || !room.HasOpening[Faces.Up] || room.Connections[Faces.Up]!.Claimed) {

            return false;
        }

        MonumentRoom east = room.Connections[Faces.East]!;
        return east.HasOpening[Faces.Up] && !east.Connections[Faces.Up]!.Claimed;
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        room.Connections[Faces.East]!.Claimed = true;
        room.Connections[Faces.Up]!.Claimed = true;
        room.Connections[Faces.East]!.Connections[Faces.Up]!.Claimed = true;
        return new MonumentDoubleXYRoom(orientation, room);
    }
}

/// <summary>A room two cells tall.</summary>
public sealed class FitDoubleYRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        return room.HasOpening[Faces.Up] && !room.Connections[Faces.Up]!.Claimed;
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        room.Connections[Faces.Up]!.Claimed = true;
        return new MonumentDoubleYRoom(orientation, room);
    }
}

/// <summary>A room two cells deep and two tall.</summary>
public sealed class FitDoubleYZRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        if (!room.HasOpening[Faces.North] || room.Connections[Faces.North]!.Claimed
            || !room.HasOpening[Faces.Up] || room.Connections[Faces.Up]!.Claimed) {

            return false;
        }

        MonumentRoom north = room.Connections[Faces.North]!;
        return north.HasOpening[Faces.Up] && !north.Connections[Faces.Up]!.Claimed;
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        room.Connections[Faces.North]!.Claimed = true;
        room.Connections[Faces.Up]!.Claimed = true;
        room.Connections[Faces.North]!.Connections[Faces.Up]!.Claimed = true;
        return new MonumentDoubleYZRoom(orientation, room);
    }
}

/// <summary>
/// A room two cells deep.
/// </summary>
/// <remarks>
/// The one fitter whose <c>create</c> can build somewhere other than the cell it was asked about: if
/// the north opening has gone since the test, it falls back to the cell to the <b>south</b> and builds
/// from there instead. Nothing re-tests that, so the fallback is taken on trust.
/// </remarks>
public sealed class FitDoubleZRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        return room.HasOpening[Faces.North] && !room.Connections[Faces.North]!.Claimed;
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        MonumentRoom source = room;

        if (!room.HasOpening[Faces.North] || room.Connections[Faces.North]!.Claimed) {
            source = room.Connections[Faces.South]!;
        }

        source.Claimed = true;
        source.Connections[Faces.North]!.Claimed = true;
        return new MonumentDoubleZRoom(orientation, source);
    }
}

/// <summary>The catch all, which accepts any cell.</summary>
public sealed class FitSimpleRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) => true;

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        return new MonumentSimpleRoom(orientation, room, random);
    }
}

/// <summary>The sponge room, which only fits a cell with no openings at all but downwards.</summary>
public sealed class FitSimpleTopRoom : IMonumentRoomFitter {
    public bool Fits(MonumentRoom room) {
        return !room.HasOpening[Faces.West] && !room.HasOpening[Faces.East]
            && !room.HasOpening[Faces.North] && !room.HasOpening[Faces.South]
            && !room.HasOpening[Faces.Up];
    }

    public MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random) {
        room.Claimed = true;
        return new MonumentSimpleTopRoom(orientation, room);
    }
}

/// <summary><c>OceanMonumentEntryRoom</c>: the room the front doorway opens into.</summary>
public sealed class MonumentEntryRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 1, 1, 1) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBox(level, chunkBox, 0, 3, 0, 2, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 3, 0, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 1, 2, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 2, 0, 7, 2, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 0, 0, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 0, 7, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 1, 7, 7, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 0, 2, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 0, 6, 3, 0, BaseLight, BaseLight, false);

        if (Open(BlockFace.NegZ)) {
            GenerateWaterBox(level, chunkBox, 3, 1, 7, 4, 2, 7);
        }

        if (Open(BlockFace.NegX)) {
            GenerateWaterBox(level, chunkBox, 0, 1, 3, 1, 2, 4);
        }

        if (Open(BlockFace.PosX)) {
            GenerateWaterBox(level, chunkBox, 6, 1, 3, 7, 2, 4);
        }
    }
}

/// <summary>
/// <c>OceanMonumentCoreRoom</c>: the two by two by two treasure chamber, and the only gold in the
/// game that generates without a loot table.
/// </summary>
public sealed class MonumentCoreRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 2, 2, 2) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        GenerateBoxOnFillOnly(level, chunkBox, 1, 8, 0, 14, 8, 14, BaseGray);

        uint block = BaseLight;
        GenerateBox(level, chunkBox, 0, 7, 0, 0, 7, 15, block, block, false);
        GenerateBox(level, chunkBox, 15, 7, 0, 15, 7, 15, block, block, false);
        GenerateBox(level, chunkBox, 1, 7, 0, 15, 7, 0, block, block, false);
        GenerateBox(level, chunkBox, 1, 7, 15, 14, 7, 15, block, block, false);

        // Two of the six courses are the darker prismarine, which is what banded look comes from.
        for (int y = 1; y <= 6; y++) {
            block = y is 2 or 6 ? BaseGray : BaseLight;

            for (int x = 0; x <= 15; x += 15) {
                GenerateBox(level, chunkBox, x, y, 0, x, y, 1, block, block, false);
                GenerateBox(level, chunkBox, x, y, 6, x, y, 9, block, block, false);
                GenerateBox(level, chunkBox, x, y, 14, x, y, 15, block, block, false);
            }

            GenerateBox(level, chunkBox, 1, y, 0, 1, y, 0, block, block, false);
            GenerateBox(level, chunkBox, 6, y, 0, 9, y, 0, block, block, false);
            GenerateBox(level, chunkBox, 14, y, 0, 14, y, 0, block, block, false);
            GenerateBox(level, chunkBox, 1, y, 15, 14, y, 15, block, block, false);
        }

        GenerateBox(level, chunkBox, 6, 3, 6, 9, 6, 9, BaseBlack, BaseBlack, false);
        GenerateBox(level, chunkBox, 7, 4, 7, 8, 5, 8, Block.GoldBlock.StateId,
            Block.GoldBlock.StateId, false);

        for (int y = 3; y <= 6; y += 3) {
            for (int x = 6; x <= 9; x += 3) {
                PlaceBlock(level, Lamp, x, y, 6, chunkBox);
                PlaceBlock(level, Lamp, x, y, 9, chunkBox);
            }
        }

        GenerateBox(level, chunkBox, 5, 1, 6, 5, 2, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 9, 5, 2, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 1, 6, 10, 2, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 1, 9, 10, 2, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 5, 6, 2, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 1, 5, 9, 2, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 10, 6, 2, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 1, 10, 9, 2, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 2, 5, 5, 6, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 2, 10, 5, 6, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 2, 5, 10, 6, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 2, 10, 10, 6, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 7, 1, 5, 7, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 7, 1, 10, 7, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 7, 9, 5, 7, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 7, 9, 10, 7, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 7, 5, 6, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 7, 10, 6, 7, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 7, 5, 14, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 7, 10, 14, 7, 10, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 1, 2, 2, 1, 3, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 1, 2, 3, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 1, 2, 13, 1, 3, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 12, 1, 2, 12, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 1, 12, 2, 1, 13, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 1, 13, 3, 1, 13, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 1, 12, 13, 1, 13, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 12, 1, 13, 12, 1, 13, BaseLight, BaseLight, false);
    }
}

/// <summary><c>OceanMonumentDoubleXRoom</c>: two cells wide, with a lit arch across the middle.</summary>
public sealed class MonumentDoubleXRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 2, 1, 1) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        MonumentRoom west = Room!;
        MonumentRoom east = west.Connections[(int)BlockFace.PosX]!;

        if (west.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 8, 0, east.HasOpening[(int)BlockFace.NegY]);
            GenerateDefaultFloor(level, chunkBox, 0, 0, west.HasOpening[(int)BlockFace.NegY]);
        }

        if (west.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 4, 1, 7, 4, 6, BaseGray);
        }

        if (east.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 8, 4, 1, 14, 4, 6, BaseGray);
        }

        GenerateBox(level, chunkBox, 0, 3, 0, 0, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 15, 3, 0, 15, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 0, 15, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 7, 14, 3, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 2, 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 15, 2, 0, 15, 2, 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 15, 2, 0, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 7, 14, 2, 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 0, 1, 0, 0, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 15, 1, 0, 15, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 0, 15, 1, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 7, 14, 1, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 0, 10, 1, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 2, 0, 9, 2, 3, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 5, 3, 0, 10, 3, 4, BaseLight, BaseLight, false);
        PlaceBlock(level, Lamp, 6, 2, 3, chunkBox);
        PlaceBlock(level, Lamp, 9, 2, 3, chunkBox);

        MonumentRooms.OpenLower(this, level, chunkBox, west, east);
    }
}

/// <summary><c>OceanMonumentDoubleXYRoom</c>: two wide and two tall, with lit pilasters.</summary>
public sealed class MonumentDoubleXYRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 2, 2, 1) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        MonumentRoom west = Room!;
        MonumentRoom east = west.Connections[(int)BlockFace.PosX]!;
        MonumentRoom westUp = west.Connections[(int)BlockFace.PosY]!;
        MonumentRoom eastUp = east.Connections[(int)BlockFace.PosY]!;

        if (west.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 8, 0, east.HasOpening[(int)BlockFace.NegY]);
            GenerateDefaultFloor(level, chunkBox, 0, 0, west.HasOpening[(int)BlockFace.NegY]);
        }

        if (westUp.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 8, 1, 7, 8, 6, BaseGray);
        }

        if (eastUp.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 8, 8, 1, 14, 8, 6, BaseGray);
        }

        for (int y = 1; y <= 7; y++) {
            uint block = y is 2 or 6 ? BaseGray : BaseLight;

            GenerateBox(level, chunkBox, 0, y, 0, 0, y, 7, block, block, false);
            GenerateBox(level, chunkBox, 15, y, 0, 15, y, 7, block, block, false);
            GenerateBox(level, chunkBox, 1, y, 0, 15, y, 0, block, block, false);
            GenerateBox(level, chunkBox, 1, y, 7, 14, y, 7, block, block, false);
        }

        GenerateBox(level, chunkBox, 2, 1, 3, 2, 7, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 1, 2, 4, 7, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 1, 5, 4, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 13, 1, 3, 13, 7, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 11, 1, 2, 12, 7, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 11, 1, 5, 12, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 3, 5, 3, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 1, 3, 10, 3, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 7, 2, 10, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 5, 2, 5, 7, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 5, 2, 10, 7, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 5, 5, 5, 7, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 10, 5, 5, 10, 7, 5, BaseLight, BaseLight, false);
        PlaceBlock(level, BaseLight, 6, 6, 2, chunkBox);
        PlaceBlock(level, BaseLight, 9, 6, 2, chunkBox);
        PlaceBlock(level, BaseLight, 6, 6, 5, chunkBox);
        PlaceBlock(level, BaseLight, 9, 6, 5, chunkBox);
        GenerateBox(level, chunkBox, 5, 4, 3, 6, 4, 4, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 9, 4, 3, 10, 4, 4, BaseLight, BaseLight, false);
        PlaceBlock(level, Lamp, 5, 4, 2, chunkBox);
        PlaceBlock(level, Lamp, 5, 4, 5, chunkBox);
        PlaceBlock(level, Lamp, 10, 4, 2, chunkBox);
        PlaceBlock(level, Lamp, 10, 4, 5, chunkBox);

        MonumentRooms.OpenLower(this, level, chunkBox, west, east);
        MonumentRooms.OpenUpper(this, level, chunkBox, westUp, eastUp);
    }
}

/// <summary>
/// <c>OceanMonumentDoubleYRoom</c>: two cells tall, whose walls are drawn per storey.
/// </summary>
/// <remarks>
/// The two storeys walk the same body with the room swapped over halfway, which is why the upper
/// floor's openings are the <b>upper</b> room's rather than this one's.
/// </remarks>
public sealed class MonumentDoubleYRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 1, 2, 1) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (Room!.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 0, 0, Room.HasOpening[(int)BlockFace.NegY]);
        }

        MonumentRoom above = Room.Connections[(int)BlockFace.PosY]!;

        if (above.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 8, 1, 6, 8, 6, BaseGray);
        }

        // The mezzanine floor between the two storeys, which is a frame rather than a full slab.
        GenerateBox(level, chunkBox, 0, 4, 0, 0, 4, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 4, 0, 7, 4, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 4, 0, 6, 4, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 4, 7, 6, 4, 7, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 4, 1, 2, 4, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 4, 2, 1, 4, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 4, 1, 5, 4, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 4, 2, 6, 4, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 4, 5, 2, 4, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 4, 5, 1, 4, 5, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 4, 5, 5, 4, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 4, 5, 6, 4, 5, BaseLight, BaseLight, false);

        MonumentRoom storey = Room;

        for (int y = 1; y <= 5; y += 4) {
            Wall(level, chunkBox, storey, y);
            storey = above;
        }
    }

    /// <summary>
    /// One storey's four walls: a doorway where the room opens and a solid banded wall where it does
    /// not.
    /// </summary>
    private void Wall(IFeatureLevel level, BoundingBox chunkBox, MonumentRoom storey, int y) {
        if (storey.HasOpening[(int)BlockFace.PosZ]) {
            GenerateBox(level, chunkBox, 2, y, 0, 2, y + 2, 0, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 5, y, 0, 5, y + 2, 0, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 3, y + 2, 0, 4, y + 2, 0, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 0, y, 0, 7, y + 2, 0, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, y + 1, 0, 7, y + 1, 0, BaseGray, BaseGray, false);
        }

        if (storey.HasOpening[(int)BlockFace.NegZ]) {
            GenerateBox(level, chunkBox, 2, y, 7, 2, y + 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 5, y, 7, 5, y + 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 3, y + 2, 7, 4, y + 2, 7, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 0, y, 7, 7, y + 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, y + 1, 7, 7, y + 1, 7, BaseGray, BaseGray, false);
        }

        if (storey.HasOpening[(int)BlockFace.NegX]) {
            GenerateBox(level, chunkBox, 0, y, 2, 0, y + 2, 2, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, y, 5, 0, y + 2, 5, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, y + 2, 3, 0, y + 2, 4, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 0, y, 0, 0, y + 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 0, y + 1, 0, 0, y + 1, 7, BaseGray, BaseGray, false);
        }

        if (storey.HasOpening[(int)BlockFace.PosX]) {
            GenerateBox(level, chunkBox, 7, y, 2, 7, y + 2, 2, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 7, y, 5, 7, y + 2, 5, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 7, y + 2, 3, 7, y + 2, 4, BaseLight, BaseLight, false);
        } else {
            GenerateBox(level, chunkBox, 7, y, 0, 7, y + 2, 7, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 7, y + 1, 0, 7, y + 1, 7, BaseGray, BaseGray, false);
        }
    }
}

/// <summary>
/// <c>OceanMonumentDoubleYZRoom</c>: two deep and two tall, with the lit column in the middle.
/// </summary>
public sealed class MonumentDoubleYZRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 1, 2, 2) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        MonumentRoom south = Room!;
        MonumentRoom north = south.Connections[(int)BlockFace.NegZ]!;
        MonumentRoom northUp = north.Connections[(int)BlockFace.PosY]!;
        MonumentRoom southUp = south.Connections[(int)BlockFace.PosY]!;

        if (south.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 0, 8, north.HasOpening[(int)BlockFace.NegY]);
            GenerateDefaultFloor(level, chunkBox, 0, 0, south.HasOpening[(int)BlockFace.NegY]);
        }

        if (southUp.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 8, 1, 6, 8, 7, BaseGray);
        }

        if (northUp.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 8, 8, 6, 8, 14, BaseGray);
        }

        for (int y = 1; y <= 7; y++) {
            uint block = y is 2 or 6 ? BaseGray : BaseLight;

            GenerateBox(level, chunkBox, 0, y, 0, 0, y, 15, block, block, false);
            GenerateBox(level, chunkBox, 7, y, 0, 7, y, 15, block, block, false);
            GenerateBox(level, chunkBox, 1, y, 0, 6, y, 0, block, block, false);
            GenerateBox(level, chunkBox, 1, y, 15, 6, y, 15, block, block, false);
        }

        // The column between the two halves, lit at the two courses the walls band on.
        for (int y = 1; y <= 7; y++) {
            uint block = y is 2 or 6 ? Lamp : BaseBlack;
            GenerateBox(level, chunkBox, 3, y, 7, 4, y, 8, block, block, false);
        }

        if (south.HasOpening[(int)BlockFace.PosZ]) {
            GenerateWaterBox(level, chunkBox, 3, 1, 0, 4, 2, 0);
        }

        if (south.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 1, 3, 7, 2, 4);
        }

        if (south.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 1, 3, 0, 2, 4);
        }

        if (north.HasOpening[(int)BlockFace.NegZ]) {
            GenerateWaterBox(level, chunkBox, 3, 1, 15, 4, 2, 15);
        }

        if (north.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 1, 11, 0, 2, 12);
        }

        if (north.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 1, 11, 7, 2, 12);
        }

        if (southUp.HasOpening[(int)BlockFace.PosZ]) {
            GenerateWaterBox(level, chunkBox, 3, 5, 0, 4, 6, 0);
        }

        // Each upper doorway also gets a balcony to stand on, which the lower ones do not need.
        if (southUp.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 5, 3, 7, 6, 4);
            GenerateBox(level, chunkBox, 5, 4, 2, 6, 4, 5, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 6, 1, 2, 6, 3, 2, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 6, 1, 5, 6, 3, 5, BaseLight, BaseLight, false);
        }

        if (southUp.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 5, 3, 0, 6, 4);
            GenerateBox(level, chunkBox, 1, 4, 2, 2, 4, 5, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 1, 2, 1, 3, 2, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 1, 5, 1, 3, 5, BaseLight, BaseLight, false);
        }

        if (northUp.HasOpening[(int)BlockFace.NegZ]) {
            GenerateWaterBox(level, chunkBox, 3, 5, 15, 4, 6, 15);
        }

        if (northUp.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 5, 11, 0, 6, 12);
            GenerateBox(level, chunkBox, 1, 4, 10, 2, 4, 13, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 1, 10, 1, 3, 10, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 1, 1, 13, 1, 3, 13, BaseLight, BaseLight, false);
        }

        if (northUp.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 5, 11, 7, 6, 12);
            GenerateBox(level, chunkBox, 5, 4, 10, 6, 4, 13, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 6, 1, 10, 6, 3, 10, BaseLight, BaseLight, false);
            GenerateBox(level, chunkBox, 6, 1, 13, 6, 3, 13, BaseLight, BaseLight, false);
        }
    }
}

/// <summary><c>OceanMonumentDoubleZRoom</c>: two cells deep, with two lit arches.</summary>
public sealed class MonumentDoubleZRoom(Direction orientation, MonumentRoom room)
    : MonumentPiece(1, orientation, room, 1, 1, 2) {

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        MonumentRoom south = Room!;
        MonumentRoom north = south.Connections[(int)BlockFace.NegZ]!;

        if (south.Index / 25 > 0) {
            GenerateDefaultFloor(level, chunkBox, 0, 8, north.HasOpening[(int)BlockFace.NegY]);
            GenerateDefaultFloor(level, chunkBox, 0, 0, south.HasOpening[(int)BlockFace.NegY]);
        }

        if (south.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 4, 1, 6, 4, 7, BaseGray);
        }

        if (north.Connections[(int)BlockFace.PosY] is null) {
            GenerateBoxOnFillOnly(level, chunkBox, 1, 4, 8, 6, 4, 14, BaseGray);
        }

        GenerateBox(level, chunkBox, 0, 3, 0, 0, 3, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 3, 0, 7, 3, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 0, 7, 3, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 15, 6, 3, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 0, 2, 0, 0, 2, 15, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 7, 2, 0, 7, 2, 15, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 0, 7, 2, 0, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 1, 2, 15, 6, 2, 15, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, 0, 1, 0, 0, 1, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 7, 1, 0, 7, 1, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 0, 7, 1, 0, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 15, 6, 1, 15, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 1, 1, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 1, 6, 1, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 1, 1, 3, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 3, 1, 6, 3, 2, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 1, 13, 1, 1, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 1, 13, 6, 1, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 1, 3, 13, 1, 3, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 6, 3, 13, 6, 3, 14, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 1, 6, 2, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 6, 5, 3, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 1, 9, 2, 3, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 1, 9, 5, 3, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 2, 6, 4, 2, 6, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 3, 2, 9, 4, 2, 9, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 2, 2, 7, 2, 2, 8, BaseLight, BaseLight, false);
        GenerateBox(level, chunkBox, 5, 2, 7, 5, 2, 8, BaseLight, BaseLight, false);
        PlaceBlock(level, Lamp, 2, 2, 5, chunkBox);
        PlaceBlock(level, Lamp, 5, 2, 5, chunkBox);
        PlaceBlock(level, Lamp, 2, 2, 10, chunkBox);
        PlaceBlock(level, Lamp, 5, 2, 10, chunkBox);
        PlaceBlock(level, BaseLight, 2, 3, 5, chunkBox);
        PlaceBlock(level, BaseLight, 5, 3, 5, chunkBox);
        PlaceBlock(level, BaseLight, 2, 3, 10, chunkBox);
        PlaceBlock(level, BaseLight, 5, 3, 10, chunkBox);

        if (south.HasOpening[(int)BlockFace.PosZ]) {
            GenerateWaterBox(level, chunkBox, 3, 1, 0, 4, 2, 0);
        }

        if (south.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 1, 3, 7, 2, 4);
        }

        if (south.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 1, 3, 0, 2, 4);
        }

        if (north.HasOpening[(int)BlockFace.NegZ]) {
            GenerateWaterBox(level, chunkBox, 3, 1, 15, 4, 2, 15);
        }

        if (north.HasOpening[(int)BlockFace.NegX]) {
            GenerateWaterBox(level, chunkBox, 0, 1, 11, 0, 2, 12);
        }

        if (north.HasOpening[(int)BlockFace.PosX]) {
            GenerateWaterBox(level, chunkBox, 7, 1, 11, 7, 2, 12);
        }
    }
}

/// <summary>The doorway cutting the two double-wide rooms share.</summary>
internal static class MonumentRooms {
    public static void OpenLower(MonumentPiece piece, IFeatureLevel level, BoundingBox chunkBox,
        MonumentRoom west, MonumentRoom east) {

        Open(piece, level, chunkBox, west, east, 1, 2);
    }

    public static void OpenUpper(MonumentPiece piece, IFeatureLevel level, BoundingBox chunkBox,
        MonumentRoom west, MonumentRoom east) {

        Open(piece, level, chunkBox, west, east, 5, 6);
    }

    private static void Open(MonumentPiece piece, IFeatureLevel level, BoundingBox chunkBox,
        MonumentRoom west, MonumentRoom east, int y0, int y1) {

        if (west.HasOpening[(int)BlockFace.PosZ]) {
            piece.ClearWater(level, chunkBox, 3, y0, 0, 4, y1, 0);
        }

        if (west.HasOpening[(int)BlockFace.NegZ]) {
            piece.ClearWater(level, chunkBox, 3, y0, 7, 4, y1, 7);
        }

        if (west.HasOpening[(int)BlockFace.NegX]) {
            piece.ClearWater(level, chunkBox, 0, y0, 3, 0, y1, 4);
        }

        if (east.HasOpening[(int)BlockFace.PosZ]) {
            piece.ClearWater(level, chunkBox, 11, y0, 0, 12, y1, 0);
        }

        if (east.HasOpening[(int)BlockFace.NegZ]) {
            piece.ClearWater(level, chunkBox, 11, y0, 7, 12, y1, 7);
        }

        if (east.HasOpening[(int)BlockFace.PosX]) {
            piece.ClearWater(level, chunkBox, 15, y0, 3, 15, y1, 4);
        }
    }
}
