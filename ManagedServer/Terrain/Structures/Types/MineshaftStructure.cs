using System.Runtime.CompilerServices;
using Minecraft.Placement.Helpers;
using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>MineshaftStructure.Type</c>: which of the two mineshafts this is.
/// </summary>
/// <remarks>
/// A type rather than three block constants because it also decides how the structure picks its
/// height, and because it is what the datapack's <c>mineshaft_type</c> field names.
/// </remarks>
public enum MineshaftType {
    Normal,
    Mesa
}

/// <summary>
/// <c>MineshaftStructure</c>: the abandoned mineshaft, a network of corridors, crossings and stairs
/// grown out of one room.
/// </summary>
/// <remarks>
/// The one structure that lays itself out <b>before</b> it knows where it is. Every piece is built
/// around <see cref="MagicStartY"/> and the whole network is then dropped, so the height it ends up at
/// is an answer from the layout rather than an input to it. That is why it is the only user of
/// <see cref="GenerationStub"/>'s eager form.
/// <p/>
/// Two registered structures share this class and the vanilla type <c>minecraft:mineshaft</c>:
/// <c>minecraft:mineshaft</c> and <c>minecraft:mineshaft_mesa</c>. Beyond the three framing blocks the
/// type picks an entirely different way of choosing the height: a normal mineshaft is buried under the
/// sea level, and a mesa one is pulled up towards the surface, which is what makes its tunnels break
/// out of the sides of the plateaus.
/// </remarks>
public sealed class MineshaftStructure(Structure.StructureSettings settings, MineshaftType type)
    : Structure(settings) {

    /// <summary>The height every piece is laid out around, before the whole network is dropped.</summary>
    public const int MagicStartY = 50;

    protected override GenerationStub FindGenerationPoint(StructureGenerationContext context) {
        // Drawn and discarded. It is the first thing findGenerationPoint does, so leaving it out
        // moves every piece of the network.
        context.Random.NextDouble();

        StructurePiecesBuilder builder = new();
        int dy = GeneratePiecesAndAdjust(builder, context);

        Vec3<int> start = new((context.ChunkX << 4) + 8, MagicStartY + dy, context.ChunkZ << 4);
        return new GenerationStub(start, builder);
    }

    /// <summary>Builds the network and drops it, answering how far it moved.</summary>
    private int GeneratePiecesAndAdjust(StructurePiecesBuilder builder,
        StructureGenerationContext context) {

        MineShaftRoom room = new(0, context.Random, (context.ChunkX << 4) + 2,
            (context.ChunkZ << 4) + 2, type);

        builder.AddPiece(room);
        room.AddChildren(room, builder, context.Random);

        if (type != MineshaftType.Mesa) {
            return builder.MoveBelowSeaLevel(context.SeaLevel, context.MinY, context.Random, 10);
        }

        Vec3<int> center = builder.BoundingBox.Center;
        int surface = context.Heights(center.X, center.Z, HeightmapType.WorldSurfaceWorldgen);

        int target = surface <= context.SeaLevel
            ? context.SeaLevel
            : Mth.RandomBetweenInclusive(context.Random, context.SeaLevel, surface);

        int dy = target - center.Y;
        builder.OffsetPiecesVertically(dy);
        return dy;
    }
}

/// <summary>
/// <c>MineshaftPieces.MineShaftPiece</c>: what the four kinds of mineshaft piece have in common.
/// </summary>
/// <remarks>
/// <see cref="CanBeReplaced"/> is the load bearing one. A mineshaft is built out of pieces that
/// overlap at their ends, so a corridor digging its air out would take the frame of the crossing it
/// joins with it. Refusing to overwrite the four framing blocks is what leaves the junctions standing.
/// </remarks>
public abstract class MineShaftPiece(int genDepth, MineshaftType type, BoundingBox boundingBox)
    : StructurePiece(genDepth, boundingBox) {

    /// <summary>Which of the two mineshafts this piece belongs to.</summary>
    public MineshaftType Type => type;

    protected uint Wood =>
        type == MineshaftType.Mesa ? Block.DarkOakLog.StateId : Block.OakLog.StateId;

    protected uint Planks =>
        type == MineshaftType.Mesa ? Block.DarkOakPlanks.StateId : Block.OakPlanks.StateId;

    protected IBlock Fence => type == MineshaftType.Mesa ? Block.DarkOakFence : Block.OakFence;

    /// <summary>Air that no light comes through, which every mineshaft cavity is dug in.</summary>
    protected static uint CaveAir => Block.CaveAir.StateId;

    protected override bool CanBeReplaced(IFeatureLevel level, int x, int y, int z,
        BoundingBox chunkBox) {

        Identifier block = level.Registry.Blocks
            .GetByStateId(GetBlock(level, x, y, z, chunkBox)).Identifier;

        return !block.Equals(level.Registry.Blocks.GetByStateId(Planks).Identifier)
            && !block.Equals(level.Registry.Blocks.GetByStateId(Wood).Identifier)
            && !block.Equals(Fence.Identifier)
            && !block.Equals(Block.IronChain.Identifier);
    }

    /// <summary>Whether the whole width of a support's span has something above it to hold up.</summary>
    protected bool IsSupportingBox(IFeatureLevel level, BoundingBox chunkBox, int x0, int x1, int y1,
        int z0) {

        for (int x = x0; x <= x1; x++) {
            if (level.Blocks.IsAir(GetBlock(level, x, y1 + 1, z0, chunkBox))) {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// <c>isInInvalidLocation</c>: whether the piece would be dug into water, or into a biome that
    /// refuses mineshafts entirely.
    /// </summary>
    /// <remarks>
    /// The box it scans is the piece's own <b>clipped to the chunk</b>, so the two halves of a corridor
    /// across a border are judged separately and one can place while the other does not. That is
    /// vanilla's own arrangement rather than a consequence of generating one chunk at a time: the
    /// method takes the writable area and vanilla passes it the same chunk box.
    /// </remarks>
    protected bool IsInInvalidLocation(IFeatureLevel level, BoundingBox chunkBox) {
        int x0 = Math.Max(BoundingBox.MinX - 1, chunkBox.MinX);
        int y0 = Math.Max(BoundingBox.MinY - 1, chunkBox.MinY);
        int z0 = Math.Max(BoundingBox.MinZ - 1, chunkBox.MinZ);
        int x1 = Math.Min(BoundingBox.MaxX + 1, chunkBox.MaxX);
        int y1 = Math.Min(BoundingBox.MaxY + 1, chunkBox.MaxY);
        int z1 = Math.Min(BoundingBox.MaxZ + 1, chunkBox.MaxZ);

        Identifier biome = level.GetBiome((x0 + x1) / 2, (y0 + y1) / 2, (z0 + z1) / 2).Identifier;

        if (BlockingBiomes(level.Registry).Contains(biome)) {
            return true;
        }

        // The six faces of the box, which is where water would be leaking in from. The interior is
        // deliberately not scanned: a tunnel through a pocket of water is fine as long as its walls
        // hold it out.
        for (int x = x0; x <= x1; x++) {
            for (int z = z0; z <= z1; z++) {
                if (IsLiquid(level, x, y0, z) || IsLiquid(level, x, y1, z)) {
                    return true;
                }
            }
        }

        for (int x = x0; x <= x1; x++) {
            for (int y = y0; y <= y1; y++) {
                if (IsLiquid(level, x, y, z0) || IsLiquid(level, x, y, z1)) {
                    return true;
                }
            }
        }

        for (int z = z0; z <= z1; z++) {
            for (int y = y0; y <= y1; y++) {
                if (IsLiquid(level, x0, y, z) || IsLiquid(level, x1, y, z)) {
                    return true;
                }
            }
        }

        return false;
    }

    private static readonly Identifier MineshaftBlocking = "minecraft:mineshaft_blocking";

    private static readonly ConditionalWeakTable<MinecraftRegistry, HashSet<Identifier>> Blocking =
        new();

    /// <summary>
    /// <c>BiomeTags.MINESHAFT_BLOCKING</c>, resolved once per registry.
    /// </summary>
    /// <remarks>
    /// A flat set rather than a tag walk because the question is asked once per piece per chunk, and a
    /// mineshaft is hundreds of pieces spread over a hundred chunks.
    /// </remarks>
    private static HashSet<Identifier> BlockingBiomes(MinecraftRegistry registry) {
        return Blocking.GetValue(registry, key => key.Biomes.Tags.Contains(MineshaftBlocking)
            ? [..key.Biomes.Tags[MineshaftBlocking].GetValueIds(key)]
            : []);
    }

    private static bool IsLiquid(IFeatureLevel level, int x, int y, int z) {
        return level.Blocks.IsLiquid(level.GetState(x, y, z));
    }

    /// <summary>
    /// Floors over a hole under the tunnel, which is what keeps a corridor crossing a cave walkable.
    /// </summary>
    /// <remarks>
    /// Only where the position is <b>interior</b>, so the part of a mineshaft that broke out into the
    /// open is left with its floor missing rather than gaining a plank bridge in mid air.
    /// </remarks>
    protected void SetPlanksBlock(IFeatureLevel level, BoundingBox chunkBox, uint planks, int x, int y,
        int z) {

        if (!IsInterior(level, x, y, z, chunkBox)) {
            return;
        }

        Vec3<int> world = GetWorldPos(x, y, z);

        if (!FaceSturdy(level, world.X, world.Y, world.Z, BlockFace.PosY)) {
            level.SetState(world.X, world.Y, world.Z, planks);
        }
    }

    /// <summary><c>BlockState.isFaceSturdy</c> at a world position.</summary>
    protected static bool FaceSturdy(IFeatureLevel level, int x, int y, int z, BlockFace face,
        SupportType type = SupportType.Full) {

        return ShapeSupport.IsFaceSturdy(level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)),
            face, type);
    }
}

/// <summary>
/// <c>MineShaftRoom</c>: the wide domed chamber a mineshaft grows out of, and the piece every other
/// one measures its distance from.
/// </summary>
public sealed class MineShaftRoom : MineShaftPiece {
    private readonly List<BoundingBox> _childEntranceBoxes = [];

    public MineShaftRoom(int genDepth, RandomSource random, int west, int north, MineshaftType type)
        : base(genDepth, type, RoomBox(random, west, north)) { }

    /// <summary>
    /// The room's own size, three draws wide.
    /// </summary>
    /// <remarks>
    /// The three draws are arguments to the box, so they run left to right: width, then height, then
    /// depth. Reordering them is a different room and a different mineshaft after it.
    /// </remarks>
    private static BoundingBox RoomBox(RandomSource random, int west, int north) {
        return new BoundingBox(west, MineshaftStructure.MagicStartY, north,
            west + 7 + random.NextInt(6),
            54 + random.NextInt(6),
            north + 7 + random.NextInt(6));
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int depth = GenDepth;

        // How far above the floor a tunnel may leave, which is the room's height less the three
        // blocks a tunnel needs and one more for the ceiling.
        int heightSpace = Math.Max(BoundingBox.YSpan - 3 - 1, 1);

        AddWall(start, builder, random, Direction.North, BoundingBox.XSpan, heightSpace, depth);
        AddWall(start, builder, random, Direction.South, BoundingBox.XSpan, heightSpace, depth);
        AddWall(start, builder, random, Direction.West, BoundingBox.ZSpan, heightSpace, depth);
        AddWall(start, builder, random, Direction.East, BoundingBox.ZSpan, heightSpace, depth);
    }

    /// <summary>
    /// One wall's doorways: step along by a draw at a time, stop once one would not fit, and leave
    /// four blocks after each.
    /// </summary>
    /// <remarks>
    /// The step is drawn <b>before</b> the test that ends the loop, so a wall that fits nothing has
    /// still consumed a number.
    /// </remarks>
    private void AddWall(StructurePiece start, StructurePiecesBuilder builder, RandomSource random,
        Direction direction, int span, int heightSpace, int depth) {

        int offset = 0;

        while (offset < span) {
            offset += random.NextInt(span);

            if (offset + 3 > span) {
                return;
            }

            int footY = BoundingBox.MinY + random.NextInt(heightSpace) + 1;

            (int footX, int footZ) = direction switch {
                Direction.South => (BoundingBox.MinX + offset, BoundingBox.MaxZ + 1),
                Direction.West => (BoundingBox.MinX - 1, BoundingBox.MinZ + offset),
                Direction.East => (BoundingBox.MaxX + 1, BoundingBox.MinZ + offset),
                _ => (BoundingBox.MinX + offset, BoundingBox.MinZ - 1)
            };

            MineShaftPiece? child = MineshaftPieces.GenerateAndAddPiece(start, builder, random, footX,
                footY, footZ, direction, depth);

            if (child is not null) {
                _childEntranceBoxes.Add(EntranceBox(direction, child.BoundingBox));
            }

            offset += 4;
        }
    }

    /// <summary>
    /// The two block deep slot in the room's wall that a doorway is cut through, sized to the tunnel
    /// rather than to the room.
    /// </summary>
    private BoundingBox EntranceBox(Direction direction, BoundingBox child) {
        return direction switch {
            Direction.South => new BoundingBox(child.MinX, child.MinY, BoundingBox.MaxZ - 1,
                child.MaxX, child.MaxY, BoundingBox.MaxZ),

            Direction.West => new BoundingBox(BoundingBox.MinX, child.MinY, child.MinZ,
                BoundingBox.MinX + 1, child.MaxY, child.MaxZ),

            Direction.East => new BoundingBox(BoundingBox.MaxX - 1, child.MinY, child.MinZ,
                BoundingBox.MaxX, child.MaxY, child.MaxZ),

            _ => new BoundingBox(child.MinX, child.MinY, BoundingBox.MinZ,
                child.MaxX, child.MaxY, BoundingBox.MinZ + 1)
        };
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (IsInInvalidLocation(level, chunkBox)) {
            return;
        }

        GenerateBox(level, chunkBox, BoundingBox.MinX, BoundingBox.MinY + 1, BoundingBox.MinZ,
            BoundingBox.MaxX, Math.Min(BoundingBox.MinY + 3, BoundingBox.MaxY), BoundingBox.MaxZ,
            CaveAir, CaveAir, false);

        // The doorways, each cut to the top of the tunnel that joins there rather than to the room's
        // own ceiling, which is what lets a corridor come in above the floor.
        foreach (BoundingBox entrance in _childEntranceBoxes) {
            GenerateBox(level, chunkBox, entrance.MinX, entrance.MaxY - 2, entrance.MinZ,
                entrance.MaxX, entrance.MaxY, entrance.MaxZ, CaveAir, CaveAir, false);
        }

        GenerateUpperHalfSphere(level, chunkBox, BoundingBox.MinX, BoundingBox.MinY + 4,
            BoundingBox.MinZ, BoundingBox.MaxX, BoundingBox.MaxY, BoundingBox.MaxZ, CaveAir, false);
    }

    public override void Move(int dx, int dy, int dz) {
        base.Move(dx, dy, dz);

        foreach (BoundingBox box in _childEntranceBoxes) {
            box.Move(dx, dy, dz);
        }
    }
}

/// <summary>
/// <c>MineShaftCorridor</c>: a run of tunnel, five blocks at a time, with its supports, its cobwebs
/// and sometimes its rails.
/// </summary>
/// <remarks>
/// Laid out along positive z in its own coordinates and turned by its orientation, which is what lets
/// one body serve all four directions.
/// <p/>
/// Vanilla's corridor also overrides <c>fillColumnDown</c>. Nothing in the mineshaft calls it, on
/// either the base or the override, so it is deliberately absent here rather than transcribed dead.
/// </remarks>
public sealed class MineShaftCorridor : MineShaftPiece {
    private readonly bool _hasRails;
    private readonly bool _spiderCorridor;
    private readonly int _numSections;

    public MineShaftCorridor(int genDepth, RandomSource random, BoundingBox boundingBox,
        Direction direction, MineshaftType type) : base(genDepth, type, boundingBox) {

        Orientation = direction;

        // The second draw only happens for a corridor without rails, so a corridor that got them has
        // consumed one number where a corridor that did not has consumed two.
        _hasRails = random.NextInt(3) == 0;
        _spiderCorridor = !_hasRails && random.NextInt(23) == 0;

        _numSections = direction is Direction.North or Direction.South
            ? boundingBox.ZSpan / 5
            : boundingBox.XSpan / 5;
    }

    /// <summary>
    /// The longest corridor that fits without hitting a piece already placed, or null for none.
    /// </summary>
    /// <remarks>
    /// The length is drawn <b>once</b> and then counted down, so a corridor that had to shorten itself
    /// consumes exactly as many numbers as one that did not.
    /// </remarks>
    public static BoundingBox? FindCorridorSize(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction) {

        for (int sections = random.NextInt(3) + 2; sections > 0; sections--) {
            int length = sections * 5;

            BoundingBox box = direction switch {
                Direction.South => new BoundingBox(0, 0, 0, 2, 2, length - 1),
                Direction.West => new BoundingBox(-(length - 1), 0, 0, 0, 2, 2),
                Direction.East => new BoundingBox(0, 0, 0, length - 1, 2, 2),
                _ => new BoundingBox(0, 0, -(length - 1), 2, 2, 0)
            };

            box.Move(footX, footY, footZ);

            if (builder.FindCollisionPiece(box) is null) {
                return box;
            }
        }

        return null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int depth = GenDepth;
        int end = random.NextInt(4);

        // Carrying straight on is twice as likely as either turn, which is what makes a mineshaft's
        // tunnels mostly straight.
        switch (Orientation) {
            case Direction.South:
                if (end <= 1) {
                    Continue(start, builder, random, BoundingBox.MinX, BoundingBox.MaxZ + 1,
                        Direction.South, depth);
                } else if (end == 2) {
                    Continue(start, builder, random, BoundingBox.MinX - 1, BoundingBox.MaxZ - 3,
                        Direction.West, depth);
                } else {
                    Continue(start, builder, random, BoundingBox.MaxX + 1, BoundingBox.MaxZ - 3,
                        Direction.East, depth);
                }

                break;

            case Direction.West:
                if (end <= 1) {
                    Continue(start, builder, random, BoundingBox.MinX - 1, BoundingBox.MinZ,
                        Direction.West, depth);
                } else if (end == 2) {
                    Continue(start, builder, random, BoundingBox.MinX, BoundingBox.MinZ - 1,
                        Direction.North, depth);
                } else {
                    Continue(start, builder, random, BoundingBox.MinX, BoundingBox.MaxZ + 1,
                        Direction.South, depth);
                }

                break;

            case Direction.East:
                if (end <= 1) {
                    Continue(start, builder, random, BoundingBox.MaxX + 1, BoundingBox.MinZ,
                        Direction.East, depth);
                } else if (end == 2) {
                    Continue(start, builder, random, BoundingBox.MaxX - 3, BoundingBox.MinZ - 1,
                        Direction.North, depth);
                } else {
                    Continue(start, builder, random, BoundingBox.MaxX - 3, BoundingBox.MaxZ + 1,
                        Direction.South, depth);
                }

                break;

            default:
                if (end <= 1) {
                    Continue(start, builder, random, BoundingBox.MinX, BoundingBox.MinZ - 1,
                        Direction.North, depth);
                } else if (end == 2) {
                    Continue(start, builder, random, BoundingBox.MinX - 1, BoundingBox.MinZ,
                        Direction.West, depth);
                } else {
                    Continue(start, builder, random, BoundingBox.MaxX + 1, BoundingBox.MinZ,
                        Direction.East, depth);
                }

                break;
        }

        if (depth >= 8) {
            return;
        }

        // Side branches, one roll per section along whichever axis the corridor runs, and at the
        // corridor's own floor rather than at a stepped height.
        if (Orientation is Direction.North or Direction.South) {
            for (int z = BoundingBox.MinZ + 3; z + 3 <= BoundingBox.MaxZ; z += 5) {
                int selection = random.NextInt(5);

                if (selection == 0) {
                    MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                        BoundingBox.MinY, z, Direction.West, depth + 1);
                } else if (selection == 1) {
                    MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                        BoundingBox.MinY, z, Direction.East, depth + 1);
                }
            }
        } else {
            for (int x = BoundingBox.MinX + 3; x + 3 <= BoundingBox.MaxX; x += 5) {
                int selection = random.NextInt(5);

                if (selection == 0) {
                    MineshaftPieces.GenerateAndAddPiece(start, builder, random, x, BoundingBox.MinY,
                        BoundingBox.MinZ - 1, Direction.North, depth + 1);
                } else if (selection == 1) {
                    MineshaftPieces.GenerateAndAddPiece(start, builder, random, x, BoundingBox.MinY,
                        BoundingBox.MaxZ + 1, Direction.South, depth + 1);
                }
            }
        }
    }

    /// <summary>
    /// The piece at the far end of this one, whose floor steps up or down by up to one block.
    /// </summary>
    /// <remarks>
    /// The height draw is an argument, so it happens whichever branch was taken and whether or not a
    /// piece is built there.
    /// </remarks>
    private void Continue(StructurePiece start, StructurePiecesBuilder builder, RandomSource random,
        int footX, int footZ, Direction direction, int depth) {

        MineshaftPieces.GenerateAndAddPiece(start, builder, random, footX,
            BoundingBox.MinY - 1 + random.NextInt(3), footZ, direction, depth);
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (IsInInvalidLocation(level, chunkBox)) {
            return;
        }

        int length = _numSections * 5 - 1;

        // The top row of the tunnel is only mostly dug out, which is what gives a mineshaft its
        // uneven ceiling.
        GenerateBox(level, chunkBox, 0, 0, 0, 2, 1, length, CaveAir, CaveAir, false);
        GenerateMaybeBox(level, chunkBox, random, 0.8f, 0, 2, 0, 2, 2, length, CaveAir, CaveAir,
            false, false);

        if (_spiderCorridor) {
            GenerateMaybeBox(level, chunkBox, random, 0.6f, 0, 0, 0, 2, 1, length,
                Block.Cobweb.StateId, CaveAir, false, true);
        }

        // Local rather than carried on the piece, which is a deliberate divergence. Vanilla persists
        // it, so a corridor across a chunk border gets one spawner between its two halves and which
        // half depends on the order the chunks were generated in. Keeping it local trades that for at
        // most one spawner per half and keeps the pass's promise that a chunk comes out the same
        // whatever order chunks were asked for.
        bool placedSpider = false;

        for (int section = 0; section < _numSections; section++) {
            int z = 2 + section * 5;

            PlaceSupport(level, chunkBox, 0, 0, z, 2, 2, random);
            MaybePlaceCobweb(level, chunkBox, random, 0.1f, 0, 2, z - 1);
            MaybePlaceCobweb(level, chunkBox, random, 0.1f, 2, 2, z - 1);
            MaybePlaceCobweb(level, chunkBox, random, 0.1f, 0, 2, z + 1);
            MaybePlaceCobweb(level, chunkBox, random, 0.1f, 2, 2, z + 1);
            MaybePlaceCobweb(level, chunkBox, random, 0.05f, 0, 2, z - 2);
            MaybePlaceCobweb(level, chunkBox, random, 0.05f, 2, 2, z - 2);
            MaybePlaceCobweb(level, chunkBox, random, 0.05f, 0, 2, z + 2);
            MaybePlaceCobweb(level, chunkBox, random, 0.05f, 2, 2, z + 2);

            if (random.NextInt(100) == 0) {
                CreateChestMinecart(level, chunkBox, random, 2, 0, z - 1);
            }

            if (random.NextInt(100) == 0) {
                CreateChestMinecart(level, chunkBox, random, 0, 0, z + 1);
            }

            if (!_spiderCorridor || placedSpider) {
                continue;
            }

            int spiderZ = z - 1 + random.NextInt(3);
            Vec3<int> spider = GetWorldPos(1, 0, spiderZ);

            if (!chunkBox.IsInside(spider.X, spider.Y, spider.Z)
                || !IsInterior(level, 1, 0, spiderZ, chunkBox)) {

                continue;
            }

            placedSpider = true;

            // The block and not what it spawns. A spawner's entity type lives on a block entity and
            // there is no port of one, so this one sits there inert. Same gap that leaves every
            // structure chest empty.
            level.SetState(spider.X, spider.Y, spider.Z, Block.Spawner.StateId);
        }

        for (int x = 0; x <= 2; x++) {
            for (int z = 0; z <= length; z++) {
                SetPlanksBlock(level, chunkBox, Planks, x, -1, z);
            }
        }

        PlaceDoubleLowerOrUpperSupport(level, chunkBox, 0, -1, 2);

        if (_numSections > 1) {
            PlaceDoubleLowerOrUpperSupport(level, chunkBox, 0, -1, length - 2);
        }

        if (!_hasRails) {
            return;
        }

        uint rail = ((IRailShaped)Block.Rail).WithShape(RailShape.NorthSouth).StateId;

        for (int z = 0; z <= length; z++) {
            uint floor = GetBlock(level, 1, -1, z, chunkBox);

            if (level.Blocks.IsAir(floor) || !level.Blocks.IsSolidRender(floor)) {
                continue;
            }

            // Rails are laid more sparsely where the tunnel is buried than where it broke into a
            // cave, which is the opposite way round to what it looks like.
            float probability = IsInterior(level, 1, 0, z, chunkBox) ? 0.7f : 0.9f;
            MaybeGenerateBlock(level, chunkBox, random, probability, 1, 0, z, rail);
        }
    }

    /// <summary>
    /// <c>createChest</c>: the rail a chest minecart would have stood on.
    /// </summary>
    /// <remarks>
    /// A minecart is an entity and the generator has no world to add one to, so the rail goes down and
    /// the cart does not. The <c>NextLong</c> is still drawn, because vanilla takes the cart's loot
    /// seed from the same random the rest of the corridor is laid out from.
    /// <p/>
    /// Its own method rather than an override of <see cref="StructurePiece.CreateChest"/>, which is
    /// what vanilla makes it. Nothing outside this class calls either, so the dispatch never happens,
    /// and the two do different things.
    /// </remarks>
    private void CreateChestMinecart(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        int x, int y, int z) {

        Vec3<int> world = GetWorldPos(x, y, z);

        if (!chunkBox.IsInside(world.X, world.Y, world.Z)
            || !level.IsAir(world.X, world.Y, world.Z)
            || level.IsAir(world.X, world.Y - 1, world.Z)) {

            return;
        }

        uint rail = ((IRailShaped)Block.Rail)
            .WithShape(random.NextBoolean() ? RailShape.NorthSouth : RailShape.EastWest).StateId;

        PlaceBlock(level, rail, x, y, z, chunkBox);
        random.NextLong();
    }

    /// <summary>
    /// Turns either end of a floor beam into a pillar down or a chain up, where the beam really was
    /// laid.
    /// </summary>
    private void PlaceDoubleLowerOrUpperSupport(IFeatureLevel level, BoundingBox chunkBox, int x,
        int y, int z) {

        Identifier planks = level.Registry.Blocks.GetByStateId(Planks).Identifier;

        if (IsPlanks(level, planks, x, y, z, chunkBox)) {
            FillPillarDownOrChainUp(level, Wood, x, y, z, chunkBox);
        }

        if (IsPlanks(level, planks, x + 2, y, z, chunkBox)) {
            FillPillarDownOrChainUp(level, Wood, x + 2, y, z, chunkBox);
        }
    }

    private bool IsPlanks(IFeatureLevel level, Identifier planks, int x, int y, int z,
        BoundingBox chunkBox) {

        return level.Registry.Blocks.GetByStateId(GetBlock(level, x, y, z, chunkBox)).Identifier
            .Equals(planks);
    }

    /// <summary>
    /// Searches down for something to stand a log pillar on and up for something to hang a chain from,
    /// both at once, and takes whichever it reaches first.
    /// </summary>
    /// <remarks>
    /// The two searches step together rather than one after the other, so a beam with ground twelve
    /// blocks below and a ceiling three above gets the chain. Each side stops on its own limit, twenty
    /// blocks down and fifty up.
    /// </remarks>
    private void FillPillarDownOrChainUp(IFeatureLevel level, uint pillar, int x, int y, int z,
        BoundingBox chunkBox) {

        Vec3<int> world = GetWorldPos(x, y, z);

        if (!chunkBox.IsInside(world.X, world.Y, world.Z)) {
            return;
        }

        int worldY = world.Y;
        bool checkBelow = true;
        bool checkAbove = true;

        for (int distance = 1; checkBelow || checkAbove; distance++) {
            if (checkBelow) {
                int below = worldY - distance;
                uint state = level.GetState(world.X, below, world.Z);

                // Lava is excluded here and nowhere else: a pillar would stand on it happily, and
                // then burn.
                bool empty = IsReplaceableByStructures(level, state)
                    && !level.Registry.Blocks.GetByStateId(state).Identifier
                        .Equals(Block.Lava.Identifier);

                if (!empty && FaceSturdy(level, world.X, below, world.Z, BlockFace.PosY)) {
                    FillColumnBetween(level, pillar, world.X, world.Z, below + 1, worldY);
                    return;
                }

                checkBelow = distance <= 20 && empty && below > level.MinY + 1;
            }

            if (checkAbove) {
                int above = worldY + distance;
                uint state = level.GetState(world.X, above, world.Z);
                bool empty = IsReplaceableByStructures(level, state);

                if (!empty && CanHangChainBelow(level, world.X, above, world.Z, state)) {
                    level.SetState(world.X, worldY + 1, world.Z, Fence.StateId);
                    FillColumnBetween(level, Block.IronChain.StateId, world.X, world.Z, worldY + 2,
                        above);
                    return;
                }

                checkAbove = distance <= 50 && empty && above < level.MaxY;
            }
        }
    }

    private static void FillColumnBetween(IFeatureLevel level, uint state, int x, int z,
        int bottomInclusive, int topExclusive) {

        for (int y = bottomInclusive; y < topExclusive; y++) {
            level.SetState(x, y, z, state);
        }
    }

    /// <summary>
    /// <c>canHangChainBelow</c>: the centre column of the block above, and never a falling block.
    /// </summary>
    /// <remarks>
    /// The falling block test is the point of it. Gravel and sand pass the shape test and would drop
    /// the moment anything below them moved, leaving the chain hanging from nothing.
    /// </remarks>
    private static bool CanHangChainBelow(IFeatureLevel level, int x, int y, int z, uint state) {
        IBlock block = level.Registry.Blocks.GetByStateId(state);

        if (BlockClasses.Of(block.Identifier).Contains(BlockClass.FallingBlock)) {
            return false;
        }

        // Block.canSupportCenter with the face pointing down, which is the one direction the
        // unstable_bottom_center carve out applies to.
        if (level.Blocks.IsIn(UnstableBottomCenter, state)) {
            return false;
        }

        return FaceSturdy(level, x, y, z, BlockFace.NegY, SupportType.Center);
    }

    private static readonly Identifier UnstableBottomCenter = "minecraft:unstable_bottom_center";

    /// <summary>The two fence posts and the beam across them, where there is a ceiling to hold up.</summary>
    private void PlaceSupport(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z,
        int y1, int x1, RandomSource random) {

        if (!IsSupportingBox(level, chunkBox, x0, x1, y1, z)) {
            return;
        }

        // Each post is written already connected to the wall behind it, since there is no shape
        // cascade in the generator to work it out afterwards.
        uint west = ((IFaceConnected)Fence).WithConnection(BlockFace.NegX, true).StateId;
        uint east = ((IFaceConnected)Fence).WithConnection(BlockFace.PosX, true).StateId;

        GenerateBox(level, chunkBox, x0, y0, z, x0, y1 - 1, z, west, CaveAir, false);
        GenerateBox(level, chunkBox, x1, y0, z, x1, y1 - 1, z, east, CaveAir, false);

        // A quarter of supports lose the beam between their two posts, and those are the ones that
        // never get a torch either.
        if (random.NextInt(4) == 0) {
            GenerateBox(level, chunkBox, x0, y1, z, x0, y1, z, Planks, CaveAir, false);
            GenerateBox(level, chunkBox, x1, y1, z, x1, y1, z, Planks, CaveAir, false);
            return;
        }

        GenerateBox(level, chunkBox, x0, y1, z, x1, y1, z, Planks, CaveAir, false);

        uint south = ((IHorizontalFacing)Block.WallTorch).WithFacing(Direction.South).StateId;
        uint north = ((IHorizontalFacing)Block.WallTorch).WithFacing(Direction.North).StateId;

        MaybeGenerateBlock(level, chunkBox, random, 0.05f, x0 + 1, y1, z - 1, south);
        MaybeGenerateBlock(level, chunkBox, random, 0.05f, x0 + 1, y1, z + 1, north);
    }

    private void MaybePlaceCobweb(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        float probability, int x, int y, int z) {

        if (IsInterior(level, x, y, z, chunkBox) && random.NextFloat() < probability
            && HasSturdyNeighbours(level, chunkBox, x, y, z, 2)) {

            PlaceBlock(level, Block.Cobweb.StateId, x, y, z, chunkBox);
        }
    }

    /// <summary>Whether enough of the six neighbours present a face for a web to be strung between.</summary>
    private bool HasSturdyNeighbours(IFeatureLevel level, BoundingBox chunkBox, int x, int y, int z,
        int count) {

        Vec3<int> world = GetWorldPos(x, y, z);
        int found = 0;

        foreach (BlockFace face in Directions.All) {
            (int nx, int ny, int nz) = Neighbour(world, face);

            if (!chunkBox.IsInside(nx, ny, nz)) {
                continue;
            }

            if (!FaceSturdy(level, nx, ny, nz, face.Opposite())) {
                continue;
            }

            if (++found >= count) {
                return true;
            }
        }

        return false;
    }

    private static (int X, int Y, int Z) Neighbour(Vec3<int> pos, BlockFace face) {
        return face switch {
            BlockFace.NegY => (pos.X, pos.Y - 1, pos.Z),
            BlockFace.PosY => (pos.X, pos.Y + 1, pos.Z),
            BlockFace.NegZ => (pos.X, pos.Y, pos.Z - 1),
            BlockFace.PosZ => (pos.X, pos.Y, pos.Z + 1),
            BlockFace.NegX => (pos.X - 1, pos.Y, pos.Z),
            _ => (pos.X + 1, pos.Y, pos.Z)
        };
    }
}

/// <summary>
/// <c>MineShaftCrossing</c>: where two tunnels meet, sometimes on two levels.
/// </summary>
/// <remarks>
/// Laid out in <b>world</b> coordinates rather than in its own. It keeps the direction it was reached
/// from as a plain field and never sets an orientation, so its blocks land where its box says and are
/// not turned. That is vanilla, and it is why every offset here is written off
/// <see cref="StructurePiece.BoundingBox"/>.
/// </remarks>
public sealed class MineShaftCrossing : MineShaftPiece {
    private readonly Direction _direction;
    private readonly bool _isTwoFloored;

    public MineShaftCrossing(int genDepth, BoundingBox boundingBox, Direction direction,
        MineshaftType type) : base(genDepth, type, boundingBox) {

        _direction = direction;
        _isTwoFloored = boundingBox.YSpan > 3;
    }

    /// <summary>
    /// The crossing's box, or null where a piece is already there.
    /// </summary>
    /// <remarks>
    /// One in four is drawn tall enough for two floors, and the draw happens before the collision
    /// test, so a crossing that could not be placed has still consumed it.
    /// </remarks>
    public static BoundingBox? FindCrossing(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction) {

        int top = random.NextInt(4) == 0 ? 6 : 2;

        BoundingBox box = direction switch {
            Direction.South => new BoundingBox(-1, 0, 0, 3, top, 4),
            Direction.West => new BoundingBox(-4, 0, -1, 0, top, 3),
            Direction.East => new BoundingBox(0, 0, -1, 4, top, 3),
            _ => new BoundingBox(-1, 0, -4, 3, top, 0)
        };

        box.Move(footX, footY, footZ);
        return builder.FindCollisionPiece(box) is null ? box : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int depth = GenDepth;

        // Three arms, the fourth side being the tunnel that reached the crossing.
        switch (_direction) {
            case Direction.South:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MaxZ + 1, Direction.South, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.West, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.East, depth);
                break;

            case Direction.West:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ - 1, Direction.North, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MaxZ + 1, Direction.South, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.West, depth);
                break;

            case Direction.East:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ - 1, Direction.North, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MaxZ + 1, Direction.South, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.East, depth);
                break;

            default:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ - 1, Direction.North, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.West, depth);
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ + 1, Direction.East, depth);
                break;
        }

        if (!_isTwoFloored) {
            return;
        }

        // The upper floor's four arms, each rolled for separately, so a two floored crossing can come
        // out with anything from none of them to all four.
        if (random.NextBoolean()) {
            MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                BoundingBox.MinY + 4, BoundingBox.MinZ - 1, Direction.North, depth);
        }

        if (random.NextBoolean()) {
            MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                BoundingBox.MinY + 4, BoundingBox.MinZ + 1, Direction.West, depth);
        }

        if (random.NextBoolean()) {
            MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                BoundingBox.MinY + 4, BoundingBox.MinZ + 1, Direction.East, depth);
        }

        if (random.NextBoolean()) {
            MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX + 1,
                BoundingBox.MinY + 4, BoundingBox.MaxZ + 1, Direction.South, depth);
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (IsInInvalidLocation(level, chunkBox)) {
            return;
        }

        if (_isTwoFloored) {
            // Two crossed tunnels at the bottom, two more at the top, and the floor between them
            // opened out in the middle so the two levels join.
            GenerateBox(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MinY, BoundingBox.MinZ,
                BoundingBox.MaxX - 1, BoundingBox.MinY + 2, BoundingBox.MaxZ, CaveAir, CaveAir, false);
            GenerateBox(level, chunkBox, BoundingBox.MinX, BoundingBox.MinY, BoundingBox.MinZ + 1,
                BoundingBox.MaxX, BoundingBox.MinY + 2, BoundingBox.MaxZ - 1, CaveAir, CaveAir, false);
            GenerateBox(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MaxY - 2, BoundingBox.MinZ,
                BoundingBox.MaxX - 1, BoundingBox.MaxY, BoundingBox.MaxZ, CaveAir, CaveAir, false);
            GenerateBox(level, chunkBox, BoundingBox.MinX, BoundingBox.MaxY - 2, BoundingBox.MinZ + 1,
                BoundingBox.MaxX, BoundingBox.MaxY, BoundingBox.MaxZ - 1, CaveAir, CaveAir, false);
            GenerateBox(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MinY + 3,
                BoundingBox.MinZ + 1, BoundingBox.MaxX - 1, BoundingBox.MinY + 3, BoundingBox.MaxZ - 1,
                CaveAir, CaveAir, false);
        } else {
            GenerateBox(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MinY, BoundingBox.MinZ,
                BoundingBox.MaxX - 1, BoundingBox.MaxY, BoundingBox.MaxZ, CaveAir, CaveAir, false);
            GenerateBox(level, chunkBox, BoundingBox.MinX, BoundingBox.MinY, BoundingBox.MinZ + 1,
                BoundingBox.MaxX, BoundingBox.MaxY, BoundingBox.MaxZ - 1, CaveAir, CaveAir, false);
        }

        PlaceSupportPillar(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MinZ + 1);
        PlaceSupportPillar(level, chunkBox, BoundingBox.MinX + 1, BoundingBox.MaxZ - 1);
        PlaceSupportPillar(level, chunkBox, BoundingBox.MaxX - 1, BoundingBox.MinZ + 1);
        PlaceSupportPillar(level, chunkBox, BoundingBox.MaxX - 1, BoundingBox.MaxZ - 1);

        for (int x = BoundingBox.MinX; x <= BoundingBox.MaxX; x++) {
            for (int z = BoundingBox.MinZ; z <= BoundingBox.MaxZ; z++) {
                SetPlanksBlock(level, chunkBox, Planks, x, BoundingBox.MinY - 1, z);
            }
        }
    }

    /// <summary>One corner post, put in only where there is something above it to hold up.</summary>
    private void PlaceSupportPillar(IFeatureLevel level, BoundingBox chunkBox, int x, int z) {
        if (level.Blocks.IsAir(GetBlock(level, x, BoundingBox.MaxY + 1, z, chunkBox))) {
            return;
        }

        GenerateBox(level, chunkBox, x, BoundingBox.MinY, z, x, BoundingBox.MaxY, z, Planks, CaveAir,
            false);
    }
}

/// <summary>
/// <c>MineShaftStairs</c>: the flight that drops a tunnel five blocks, cut as five overlapping boxes.
/// </summary>
public sealed class MineShaftStairs : MineShaftPiece {
    public MineShaftStairs(int genDepth, BoundingBox boundingBox, Direction direction,
        MineshaftType type) : base(genDepth, type, boundingBox) {

        Orientation = direction;
    }

    public static BoundingBox? FindStairs(StructurePiecesBuilder builder, RandomSource random,
        int footX, int footY, int footZ, Direction direction) {

        BoundingBox box = direction switch {
            Direction.South => new BoundingBox(0, -5, 0, 2, 2, 8),
            Direction.West => new BoundingBox(-8, -5, 0, 0, 2, 2),
            Direction.East => new BoundingBox(0, -5, 0, 8, 2, 2),
            _ => new BoundingBox(0, -5, -8, 2, 2, 0)
        };

        box.Move(footX, footY, footZ);
        return builder.FindCollisionPiece(box) is null ? box : null;
    }

    public override void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) {

        int depth = GenDepth;

        // Only ever straight on, from the bottom of the flight.
        switch (Orientation) {
            case Direction.South:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX,
                    BoundingBox.MinY, BoundingBox.MaxZ + 1, Direction.South, depth);
                break;

            case Direction.West:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX - 1,
                    BoundingBox.MinY, BoundingBox.MinZ, Direction.West, depth);
                break;

            case Direction.East:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MaxX + 1,
                    BoundingBox.MinY, BoundingBox.MinZ, Direction.East, depth);
                break;

            default:
                MineshaftPieces.GenerateAndAddPiece(start, builder, random, BoundingBox.MinX,
                    BoundingBox.MinY, BoundingBox.MinZ - 1, Direction.North, depth);
                break;
        }
    }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (IsInInvalidLocation(level, chunkBox)) {
            return;
        }

        // The landings at the top and the bottom, then the flight itself as five boxes that each drop
        // one and shorten one. The last of the five keeps its own floor, which is what leaves a step
        // at the bottom rather than a hole.
        GenerateBox(level, chunkBox, 0, 5, 0, 2, 7, 1, CaveAir, CaveAir, false);
        GenerateBox(level, chunkBox, 0, 0, 7, 2, 2, 8, CaveAir, CaveAir, false);

        for (int step = 0; step < 5; step++) {
            GenerateBox(level, chunkBox, 0, 5 - step - (step < 4 ? 1 : 0), 2 + step, 2, 7 - step,
                2 + step, CaveAir, CaveAir, false);
        }
    }
}

/// <summary>
/// <c>MineshaftPieces</c>: how one piece decides what joins onto it.
/// </summary>
public static class MineshaftPieces {
    /// <summary>How deep the piece tree may go.</summary>
    private const int MaxDepth = 8;

    /// <summary>How far from the room a piece may be, on either horizontal axis.</summary>
    private const int MaxDistanceFromStart = 80;

    /// <summary>
    /// Picks a piece for the far end of a tunnel: mostly corridor, one in five a crossing, one in ten
    /// a flight of stairs.
    /// </summary>
    /// <remarks>
    /// Only the branch that was chosen draws anything further, and each of the three draws a different
    /// amount, so this one roll is what the rest of the network hangs off.
    /// </remarks>
    private static MineShaftPiece? CreateRandomShaftPiece(StructurePiecesBuilder builder,
        RandomSource random, int footX, int footY, int footZ, Direction direction, int genDepth,
        MineshaftType type) {

        int selection = random.NextInt(100);

        if (selection >= 80) {
            BoundingBox? crossing = MineShaftCrossing.FindCrossing(builder, random, footX, footY,
                footZ, direction);

            return crossing is null
                ? null
                : new MineShaftCrossing(genDepth, crossing, direction, type);
        }

        if (selection >= 70) {
            BoundingBox? stairs = MineShaftStairs.FindStairs(builder, random, footX, footY, footZ,
                direction);

            return stairs is null ? null : new MineShaftStairs(genDepth, stairs, direction, type);
        }

        BoundingBox? corridor = MineShaftCorridor.FindCorridorSize(builder, random, footX, footY,
            footZ, direction);

        return corridor is null
            ? null
            : new MineShaftCorridor(genDepth, random, corridor, direction, type);
    }

    /// <summary>
    /// Builds the piece at a tunnel's end, adds it, and lets it grow its own children.
    /// </summary>
    /// <remarks>
    /// The recursion is what lays the whole network out, and it is bounded twice over: by depth, and
    /// by how far the piece is from the room the mineshaft started at. The distance is measured from
    /// the <b>start piece's</b> minimum corner rather than from the parent, so a mineshaft cannot walk
    /// away indefinitely by taking short steps.
    /// </remarks>
    public static MineShaftPiece? GenerateAndAddPiece(StructurePiece startPiece,
        StructurePiecesBuilder builder, RandomSource random, int footX, int footY, int footZ,
        Direction direction, int depth) {

        if (depth > MaxDepth) {
            return null;
        }

        if (Math.Abs(footX - startPiece.BoundingBox.MinX) > MaxDistanceFromStart
            || Math.Abs(footZ - startPiece.BoundingBox.MinZ) > MaxDistanceFromStart) {

            return null;
        }

        MineShaftPiece? piece = CreateRandomShaftPiece(builder, random, footX, footY, footZ,
            direction, depth + 1, ((MineShaftPiece)startPiece).Type);

        if (piece is null) {
            return null;
        }

        builder.AddPiece(piece);
        piece.AddChildren(startPiece, builder, random);
        return piece;
    }
}
