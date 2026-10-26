using ManagedServer.Terrain.Features;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>OceanMonumentStructure</c>: the guardian monument.
/// </summary>
/// <remarks>
/// <b>It refuses unless every biome around it is deep ocean.</b> The test is over a 29 block radius of
/// the monument's own centre, at sea level, and one quart cell of anything else is enough to decline.
/// That is why a monument is never half on a shore, and it is a much stronger condition than the
/// structure's own biome list.
/// <p/>
/// The whole monument is <b>one piece</b> in the builder. The rooms inside are children the building
/// holds and dispatches to itself, rather than pieces the pass sees, which is why nothing here
/// collides with anything.
/// </remarks>
public sealed class OceanMonumentStructure(Structure.StructureSettings settings)
    : Structure(settings) {

    /// <summary>How far around the centre every biome has to be an allowed one.</summary>
    public const int BiomeRangeCheck = 29;

    private static readonly Identifier RequiredSurrounding =
        "minecraft:required_ocean_monument_surrounding";

    protected override GenerationStub? FindGenerationPoint(StructureGenerationContext context) {
        int centreX = (context.ChunkX << 4) + 9;
        int centreZ = (context.ChunkZ << 4) + 9;

        if (!SurroundedByOcean(context, centreX, centreZ)) {
            return null;
        }

        // The building is laid out from 29 blocks north west of the source chunk, so the chunk that
        // decided it exists is the middle of it rather than a corner.
        return OnTopOfChunkCenter(context, HeightmapType.OceanFloorWorldgen,
            builder => builder.AddPiece(MonumentBuilding.Create(context.Random,
                (context.ChunkX << 4) - 29, (context.ChunkZ << 4) - 29)));
    }

    /// <summary>
    /// <c>BiomeSource.getBiomesWithin</c> over the check radius, with every result tested.
    /// </summary>
    /// <remarks>
    /// The cube is walked in quart cells and includes the <b>y</b> range, so a column whose climate
    /// changes with depth fails it too.
    /// </remarks>
    private bool SurroundedByOcean(StructureGenerationContext context, int centreX, int centreZ) {
        IReadOnlySet<Identifier> allowed = AllowedSurroundings(context.Registry);

        int x0 = (centreX - BiomeRangeCheck) >> 2;
        int y0 = (context.SeaLevel - BiomeRangeCheck) >> 2;
        int z0 = (centreZ - BiomeRangeCheck) >> 2;
        int x1 = (centreX + BiomeRangeCheck) >> 2;
        int y1 = (context.SeaLevel + BiomeRangeCheck) >> 2;
        int z1 = (centreZ + BiomeRangeCheck) >> 2;

        for (int quartZ = z0; quartZ <= z1; quartZ++) {
            for (int quartX = x0; quartX <= x1; quartX++) {
                for (int quartY = y0; quartY <= y1; quartY++) {
                    if (!allowed.Contains(context.Biomes(quartX, quartY, quartZ))) {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<MinecraftRegistry,
        HashSet<Identifier>> Surroundings = new();

    private static HashSet<Identifier> AllowedSurroundings(MinecraftRegistry registry) {
        return Surroundings.GetValue(registry, key => key.Biomes.Tags.Contains(RequiredSurrounding)
            ? [..key.Biomes.Tags[RequiredSurrounding].GetValueIds(key)]
            : []);
    }
}

/// <summary>
/// <c>OceanMonumentPieces.RoomDefinition</c>: one cell of the monument's five by five by three room
/// grid, and which of its six neighbours it opens onto.
/// </summary>
/// <remarks>
/// The grid is a graph rather than an array of rooms: the layout closes doorways at random and keeps
/// only the ones that leave every room still reachable from the entrance. <see cref="FindSource"/> is
/// that reachability walk.
/// </remarks>
public sealed class MonumentRoom(int index) {
    /// <summary>Where in the grid, as <c>y * 25 + z * 5 + x</c>. Past 75 means a wing or the roof.</summary>
    public int Index => index;

    /// <summary>Neighbour per face, indexed by <see cref="BlockFace"/>, which is vanilla's own order.</summary>
    public readonly MonumentRoom?[] Connections = new MonumentRoom?[6];

    public readonly bool[] HasOpening = new bool[6];

    public bool Claimed { get; set; }

    public bool IsSource { get; set; }

    private int _scanIndex;

    public void SetConnection(BlockFace face, MonumentRoom other) {
        Connections[(int)face] = other;
        other.Connections[(int)face.Opposite()] = this;
    }

    public void UpdateOpenings() {
        for (int i = 0; i < 6; i++) {
            HasOpening[i] = Connections[i] is not null;
        }
    }

    /// <summary>
    /// Whether the entrance is still reachable from this room through open doorways.
    /// </summary>
    /// <remarks>
    /// A depth first walk marked with a scan number rather than a visited set, so the same rooms can
    /// be walked again on the next attempt without clearing anything. The caller hands out a fresh
    /// number per walk.
    /// </remarks>
    public bool FindSource(int scan) {
        if (IsSource) {
            return true;
        }

        _scanIndex = scan;

        for (int i = 0; i < 6; i++) {
            if (Connections[i] is { } neighbour && HasOpening[i] && neighbour._scanIndex != scan
                && neighbour.FindSource(scan)) {

                return true;
            }
        }

        return false;
    }

    /// <summary>Whether this is one of the three rooms outside the grid: the two wings and the roof.</summary>
    public bool IsSpecial => index >= 75;

    public int CountOpenings() {
        int count = 0;

        foreach (bool open in HasOpening) {
            if (open) {
                count++;
            }
        }

        return count;
    }
}

/// <summary>Picks which shape of room to build in a grid cell, if it fits there.</summary>
public interface IMonumentRoomFitter {
    bool Fits(MonumentRoom room);

    MonumentPiece Create(Direction orientation, MonumentRoom room, RandomSource random);
}

/// <summary>
/// <c>OceanMonumentPieces.OceanMonumentPiece</c>: the blocks and the drawing primitives every monument
/// piece shares.
/// </summary>
/// <remarks>
/// <see cref="GenerateWaterBox"/> is the one that carries the monument's idea: the building is written
/// into water, so clearing a space means <b>filling it with water</b> rather than with air, and only
/// above sea level does it become air. Ice of any kind is left alone.
/// </remarks>
public abstract class MonumentPiece : StructurePiece {
    protected static uint BaseGray => Block.Prismarine.StateId;
    protected static uint BaseLight => Block.PrismarineBricks.StateId;
    protected static uint BaseBlack => Block.DarkPrismarine.StateId;

    /// <summary>The dotted trim, which is the same block as <see cref="BaseLight"/> upstream too.</summary>
    protected static uint DotDeco => Block.PrismarineBricks.StateId;

    protected static uint Lamp => Block.SeaLantern.StateId;

    protected static uint Fill => Block.Water.StateId;

    /// <summary>The room this piece was built for, or null for the wings and the penthouse.</summary>
    protected MonumentRoom? Room { get; }

    protected MonumentPiece(Direction orientation, int genDepth, BoundingBox boundingBox)
        : base(genDepth, boundingBox) {

        Orientation = orientation;
    }

    protected MonumentPiece(int genDepth, Direction orientation, MonumentRoom room, int roomWidth,
        int roomHeight, int roomDepth)
        : base(genDepth, RoomBox(orientation, room, roomWidth, roomHeight, roomDepth)) {

        Orientation = orientation;
        Room = room;
    }

    /// <summary>
    /// Where a room's cell sits inside the building, in the building's own frame.
    /// </summary>
    /// <remarks>
    /// A cell is eight by four by eight. The four facings do not simply rotate the offset: north and
    /// west measure z from the far end and add one, because the box is built running the other way.
    /// </remarks>
    private static BoundingBox RoomBox(Direction orientation, MonumentRoom room, int roomWidth,
        int roomHeight, int roomDepth) {

        int roomX = room.Index % 5;
        int roomZ = room.Index / 5 % 5;
        int roomY = room.Index / 25;

        BoundingBox box = MakeBoundingBox(0, 0, 0, orientation, roomWidth * 8, roomHeight * 4,
            roomDepth * 8);

        return orientation switch {
            Direction.North => box.Move(roomX * 8, roomY * 4, -(roomZ + roomDepth) * 8 + 1),
            Direction.South => box.Move(roomX * 8, roomY * 4, roomZ * 8),
            Direction.West => box.Move(-(roomZ + roomDepth) * 8 + 1, roomY * 4, roomX * 8),
            _ => box.Move(roomZ * 8, roomY * 4, roomX * 8)
        };
    }

    /// <summary>Whether a face of the piece's room is open, by <see cref="BlockFace"/>.</summary>
    protected bool Open(BlockFace face) => Room!.HasOpening[(int)face];

    /// <summary>
    /// Clears a box to water, or to air where it is above the sea.
    /// </summary>
    /// <remarks>
    /// Ice of all three kinds is kept, which is what stops a monument under a frozen ocean punching a
    /// hole through the surface.
    /// </remarks>
    protected void GenerateWaterBox(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0,
        int x1, int y1, int z1) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    uint existing = GetBlock(level, x, y, z, chunkBox);

                    if (IsFillKeep(level, existing)) {
                        continue;
                    }

                    PlaceBlock(level,
                        GetWorldY(y) >= level.SeaLevel && existing != Fill ? Block.Air.StateId : Fill,
                        x, y, z, chunkBox);
                }
            }
        }
    }

    /// <summary><see cref="GenerateWaterBox"/>, for the helper the double rooms share.</summary>
    public void ClearWater(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0, int x1,
        int y1, int z1) {

        GenerateWaterBox(level, chunkBox, x0, y0, z0, x1, y1, z1);
    }

    private static bool IsFillKeep(IFeatureLevel level, uint stateId) {
        Identifier block = level.Registry.Blocks.GetByStateId(stateId).Identifier;

        return block.Equals(Block.Ice.Identifier)
            || block.Equals(Block.PackedIce.Identifier)
            || block.Equals(Block.BlueIce.Identifier)
            || block.Equals(Block.Water.Identifier);
    }

    /// <summary>
    /// A room's floor: solid, or with a lit ring around the hole where a room below opens up into it.
    /// </summary>
    protected void GenerateDefaultFloor(IFeatureLevel level, BoundingBox chunkBox, int xOff, int zOff,
        bool downOpening) {

        if (!downOpening) {
            GenerateBox(level, chunkBox, xOff, 0, zOff, xOff + 7, 0, zOff + 7, BaseGray, BaseGray,
                false);

            return;
        }

        GenerateBox(level, chunkBox, xOff, 0, zOff, xOff + 2, 0, zOff + 7, BaseGray, BaseGray, false);
        GenerateBox(level, chunkBox, xOff + 5, 0, zOff, xOff + 7, 0, zOff + 7, BaseGray, BaseGray,
            false);
        GenerateBox(level, chunkBox, xOff + 3, 0, zOff, xOff + 4, 0, zOff + 2, BaseGray, BaseGray,
            false);
        GenerateBox(level, chunkBox, xOff + 3, 0, zOff + 5, xOff + 4, 0, zOff + 7, BaseGray, BaseGray,
            false);
        GenerateBox(level, chunkBox, xOff + 3, 0, zOff + 2, xOff + 4, 0, zOff + 2, BaseLight,
            BaseLight, false);
        GenerateBox(level, chunkBox, xOff + 3, 0, zOff + 5, xOff + 4, 0, zOff + 5, BaseLight,
            BaseLight, false);
        GenerateBox(level, chunkBox, xOff + 2, 0, zOff + 3, xOff + 2, 0, zOff + 4, BaseLight,
            BaseLight, false);
        GenerateBox(level, chunkBox, xOff + 5, 0, zOff + 3, xOff + 5, 0, zOff + 4, BaseLight,
            BaseLight, false);
    }

    /// <summary>
    /// Writes only where the water the monument was cleared into is still standing.
    /// </summary>
    /// <remarks>
    /// This is how a room gets a ceiling only where nothing above it already put a floor down: the
    /// rooms are written in an arbitrary order, so a test against water is what keeps them from
    /// overwriting each other.
    /// </remarks>
    protected void GenerateBoxOnFillOnly(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0,
        int z0, int x1, int y1, int z1, uint state) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    if (GetBlock(level, x, y, z, chunkBox) == Fill) {
                        PlaceBlock(level, state, x, y, z, chunkBox);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Whether a rectangle of the piece's own coordinates reaches the chunk being written.
    /// </summary>
    /// <remarks>
    /// The building is 58 blocks across, so almost every chunk it overlaps wants only a few of its
    /// walls. Testing each wall before drawing it is what keeps that affordable.
    /// </remarks>
    protected bool ChunkIntersects(BoundingBox chunkBox, int x0, int z0, int x1, int z1) {
        int wx0 = GetWorldX(x0, z0);
        int wz0 = GetWorldZ(x0, z0);
        int wx1 = GetWorldX(x1, z1);
        int wz1 = GetWorldZ(x1, z1);

        return chunkBox.Intersects(Math.Min(wx0, wx1), Math.Min(wz0, wz1), Math.Max(wx0, wx1),
            Math.Max(wz0, wz1));
    }

    /// <summary>
    /// <c>spawnElder</c>, which places nothing.
    /// </summary>
    /// <remarks>
    /// The three elder guardians are live entities added at generation time, and the generator has no
    /// world to add one to. Same gap that leaves the swamp hut without its witch.
    /// </remarks>
    protected static void SpawnElder(IFeatureLevel level, BoundingBox chunkBox, int x, int y, int z) { }
}
