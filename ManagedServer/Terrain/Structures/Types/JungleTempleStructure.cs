using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>JungleTempleStructure</c>: the jungle pyramid, twelve by fifteen.
/// </summary>
public sealed class JungleTempleStructure(Structure.StructureSettings settings)
    : SinglePieceStructure((random, west, north) => new JungleTemplePiece(random, west, north),
        12, 15, settings);

/// <summary>
/// <c>JungleTemplePiece</c>: the temple and both of its traps.
/// </summary>
/// <remarks>
/// The redstone is placed exactly as vanilla writes it, connections included, and then never runs:
/// there is no redstone engine here, so pulling a lever does nothing and the piston puzzle cannot be
/// solved. The same gap the placement rules document. The tripwire traps are inert for the same
/// reason, and their dispensers are empty for <see cref="StructurePiece.CreateChest"/>'s.
/// </remarks>
public sealed class JungleTemplePiece(RandomSource random, int west, int north)
    : ScatteredFeaturePiece(west, 64, north, 12, 10, 15, RandomHorizontalDirection(random)) {

    /// <summary>
    /// Two in five cobblestone, three in five mossy, rolled per block.
    /// </summary>
    /// <remarks>
    /// One per placement, where vanilla's <c>STONE_SELECTOR</c> is a static shared by every temple in
    /// the world. It carries the last answer between <c>Next</c> and the read of <c>Current</c>, and
    /// several chunks decorate on the pool at once, so a shared instance would be two temples writing
    /// over each other's block. It changes no draw: the selector holds no state across a call.
    /// </remarks>
    private sealed class MossStoneSelector : IBlockSelector {
        public uint Current { get; private set; }

        public void Next(RandomSource random, int x, int y, int z, bool edge) {
            Current = random.NextFloat() < 0.4f
                ? Block.Cobblestone.StateId
                : Block.MossyCobblestone.StateId;
        }
    }

    private bool _placedMainChest;
    private bool _placedHiddenChest;
    private bool _placedTrap1;
    private bool _placedTrap2;

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        if (!UpdateAverageGroundHeight(level, chunkBox, 0)) {
            return;
        }

        MossStoneSelector stones = new();

        GenerateBox(level, chunkBox, 0, -4, 0, Width - 1, 0, Depth - 1, false, random, stones);
        GenerateBox(level, chunkBox, 2, 1, 2, 9, 2, 2, false, random, stones);
        GenerateBox(level, chunkBox, 2, 1, 12, 9, 2, 12, false, random, stones);
        GenerateBox(level, chunkBox, 2, 1, 3, 2, 2, 11, false, random, stones);
        GenerateBox(level, chunkBox, 9, 1, 3, 9, 2, 11, false, random, stones);
        GenerateBox(level, chunkBox, 1, 3, 1, 10, 6, 1, false, random, stones);
        GenerateBox(level, chunkBox, 1, 3, 13, 10, 6, 13, false, random, stones);
        GenerateBox(level, chunkBox, 1, 3, 2, 1, 6, 12, false, random, stones);
        GenerateBox(level, chunkBox, 10, 3, 2, 10, 6, 12, false, random, stones);
        GenerateBox(level, chunkBox, 2, 3, 2, 9, 3, 12, false, random, stones);
        GenerateBox(level, chunkBox, 2, 6, 2, 9, 6, 12, false, random, stones);
        GenerateBox(level, chunkBox, 3, 7, 3, 8, 7, 11, false, random, stones);
        GenerateBox(level, chunkBox, 4, 8, 4, 7, 8, 10, false, random, stones);

        GenerateAirBox(level, chunkBox, 3, 1, 3, 8, 2, 11);
        GenerateAirBox(level, chunkBox, 4, 3, 6, 7, 3, 9);
        GenerateAirBox(level, chunkBox, 2, 4, 2, 9, 5, 12);
        GenerateAirBox(level, chunkBox, 4, 6, 5, 7, 6, 9);
        GenerateAirBox(level, chunkBox, 5, 7, 6, 6, 7, 8);
        GenerateAirBox(level, chunkBox, 5, 1, 2, 6, 2, 2);
        GenerateAirBox(level, chunkBox, 5, 2, 12, 6, 2, 12);
        GenerateAirBox(level, chunkBox, 5, 5, 1, 6, 5, 1);
        GenerateAirBox(level, chunkBox, 5, 5, 13, 6, 5, 13);

        uint air = Block.Air.StateId;
        PlaceBlock(level, air, 1, 5, 5, chunkBox);
        PlaceBlock(level, air, 10, 5, 5, chunkBox);
        PlaceBlock(level, air, 1, 5, 9, chunkBox);
        PlaceBlock(level, air, 10, 5, 9, chunkBox);

        for (int z = 0; z <= 14; z += 14) {
            GenerateBox(level, chunkBox, 2, 4, z, 2, 5, z, false, random, stones);
            GenerateBox(level, chunkBox, 4, 4, z, 4, 5, z, false, random, stones);
            GenerateBox(level, chunkBox, 7, 4, z, 7, 5, z, false, random, stones);
            GenerateBox(level, chunkBox, 9, 4, z, 9, 5, z, false, random, stones);
        }

        GenerateBox(level, chunkBox, 5, 6, 0, 6, 6, 0, false, random, stones);

        for (int x = 0; x <= 11; x += 11) {
            for (int z = 2; z <= 12; z += 2) {
                GenerateBox(level, chunkBox, x, 4, z, x, 5, z, false, random, stones);
            }

            GenerateBox(level, chunkBox, x, 6, 5, x, 6, 5, false, random, stones);
            GenerateBox(level, chunkBox, x, 6, 9, x, 6, 9, false, random, stones);
        }

        GenerateBox(level, chunkBox, 2, 7, 2, 2, 9, 2, false, random, stones);
        GenerateBox(level, chunkBox, 9, 7, 2, 9, 9, 2, false, random, stones);
        GenerateBox(level, chunkBox, 2, 7, 12, 2, 9, 12, false, random, stones);
        GenerateBox(level, chunkBox, 9, 7, 12, 9, 9, 12, false, random, stones);
        GenerateBox(level, chunkBox, 4, 9, 4, 4, 9, 4, false, random, stones);
        GenerateBox(level, chunkBox, 7, 9, 4, 7, 9, 4, false, random, stones);
        GenerateBox(level, chunkBox, 4, 9, 10, 4, 9, 10, false, random, stones);
        GenerateBox(level, chunkBox, 7, 9, 10, 7, 9, 10, false, random, stones);
        GenerateBox(level, chunkBox, 5, 9, 7, 6, 9, 7, false, random, stones);

        uint eastStairs = Stairs(Direction.East);
        uint westStairs = Stairs(Direction.West);
        uint southStairs = Stairs(Direction.South);
        uint northStairs = Stairs(Direction.North);

        PlaceBlock(level, northStairs, 5, 9, 6, chunkBox);
        PlaceBlock(level, northStairs, 6, 9, 6, chunkBox);
        PlaceBlock(level, southStairs, 5, 9, 8, chunkBox);
        PlaceBlock(level, southStairs, 6, 9, 8, chunkBox);
        PlaceBlock(level, northStairs, 4, 0, 0, chunkBox);
        PlaceBlock(level, northStairs, 5, 0, 0, chunkBox);
        PlaceBlock(level, northStairs, 6, 0, 0, chunkBox);
        PlaceBlock(level, northStairs, 7, 0, 0, chunkBox);
        PlaceBlock(level, northStairs, 4, 1, 8, chunkBox);
        PlaceBlock(level, northStairs, 4, 2, 9, chunkBox);
        PlaceBlock(level, northStairs, 4, 3, 10, chunkBox);
        PlaceBlock(level, northStairs, 7, 1, 8, chunkBox);
        PlaceBlock(level, northStairs, 7, 2, 9, chunkBox);
        PlaceBlock(level, northStairs, 7, 3, 10, chunkBox);

        GenerateBox(level, chunkBox, 4, 1, 9, 4, 1, 9, false, random, stones);
        GenerateBox(level, chunkBox, 7, 1, 9, 7, 1, 9, false, random, stones);
        GenerateBox(level, chunkBox, 4, 1, 10, 7, 2, 10, false, random, stones);
        GenerateBox(level, chunkBox, 5, 4, 5, 6, 4, 5, false, random, stones);
        PlaceBlock(level, eastStairs, 4, 4, 5, chunkBox);
        PlaceBlock(level, westStairs, 7, 4, 5, chunkBox);

        // The staircase down to the traps, cut a step at a time.
        for (int step = 0; step < 4; step++) {
            PlaceBlock(level, southStairs, 5, 0 - step, 6 + step, chunkBox);
            PlaceBlock(level, southStairs, 6, 0 - step, 6 + step, chunkBox);
            GenerateAirBox(level, chunkBox, 5, 0 - step, 7 + step, 6, 0 - step, 9 + step);
        }

        GenerateAirBox(level, chunkBox, 1, -3, 12, 10, -1, 13);
        GenerateAirBox(level, chunkBox, 1, -3, 1, 3, -1, 13);
        GenerateAirBox(level, chunkBox, 1, -3, 1, 9, -1, 5);

        for (int z = 1; z <= 13; z += 2) {
            GenerateBox(level, chunkBox, 1, -3, z, 1, -2, z, false, random, stones);
        }

        for (int z = 2; z <= 12; z += 2) {
            GenerateBox(level, chunkBox, 1, -1, z, 3, -1, z, false, random, stones);
        }

        GenerateBox(level, chunkBox, 2, -2, 1, 5, -2, 1, false, random, stones);
        GenerateBox(level, chunkBox, 7, -2, 1, 9, -2, 1, false, random, stones);
        GenerateBox(level, chunkBox, 6, -3, 1, 6, -3, 1, false, random, stones);
        GenerateBox(level, chunkBox, 6, -1, 1, 6, -1, 1, false, random, stones);

        // The first trap: an east-west tripwire run into the arrow dispenser at its end.
        PlaceBlock(level, Hook(Direction.East), 1, -3, 8, chunkBox);
        PlaceBlock(level, Hook(Direction.West), 4, -3, 8, chunkBox);
        PlaceBlock(level, Wire(BlockFace.PosX, BlockFace.NegX), 2, -3, 8, chunkBox);
        PlaceBlock(level, Wire(BlockFace.PosX, BlockFace.NegX), 3, -3, 8, chunkBox);

        uint redstoneNorthSouth = Redstone(
            (BlockFace.NegZ, RedstoneWireConnection.Side),
            (BlockFace.PosZ, RedstoneWireConnection.Side));

        PlaceBlock(level, redstoneNorthSouth, 5, -3, 7, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 5, -3, 6, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 5, -3, 5, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 5, -3, 4, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 5, -3, 3, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 5, -3, 2, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.NegZ, RedstoneWireConnection.Side),
            (BlockFace.NegX, RedstoneWireConnection.Side)), 5, -3, 1, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.PosX, RedstoneWireConnection.Side),
            (BlockFace.NegX, RedstoneWireConnection.Side)), 4, -3, 1, chunkBox);

        PlaceBlock(level, Block.MossyCobblestone.StateId, 3, -3, 1, chunkBox);

        if (!_placedTrap1) {
            _placedTrap1 = CreateDispenser(level, chunkBox, random, 3, -2, 1, Direction.North);
        }

        PlaceBlock(level, Vine(BlockFace.PosZ), 3, -2, 2, chunkBox);

        // The second trap, north-south and one level up at its dispenser.
        PlaceBlock(level, Hook(Direction.North), 7, -3, 1, chunkBox);
        PlaceBlock(level, Hook(Direction.South), 7, -3, 5, chunkBox);
        PlaceBlock(level, Wire(BlockFace.NegZ, BlockFace.PosZ), 7, -3, 2, chunkBox);
        PlaceBlock(level, Wire(BlockFace.NegZ, BlockFace.PosZ), 7, -3, 3, chunkBox);
        PlaceBlock(level, Wire(BlockFace.NegZ, BlockFace.PosZ), 7, -3, 4, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.PosX, RedstoneWireConnection.Side),
            (BlockFace.NegX, RedstoneWireConnection.Side)), 8, -3, 6, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.NegX, RedstoneWireConnection.Side),
            (BlockFace.PosZ, RedstoneWireConnection.Side)), 9, -3, 6, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.NegZ, RedstoneWireConnection.Side),
            (BlockFace.PosZ, RedstoneWireConnection.Up)), 9, -3, 5, chunkBox);

        PlaceBlock(level, Block.MossyCobblestone.StateId, 9, -3, 4, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 9, -2, 4, chunkBox);

        if (!_placedTrap2) {
            _placedTrap2 = CreateDispenser(level, chunkBox, random, 9, -2, 3, Direction.West);
        }

        PlaceBlock(level, Vine(BlockFace.PosX), 8, -1, 3, chunkBox);
        PlaceBlock(level, Vine(BlockFace.PosX), 8, -2, 3, chunkBox);

        if (!_placedMainChest) {
            _placedMainChest = CreateChest(level, chunkBox, random, 8, -3, 3);
        }

        PlaceBlock(level, Block.MossyCobblestone.StateId, 9, -3, 2, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 8, -3, 1, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 4, -3, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 5, -2, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 5, -1, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 6, -3, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 7, -2, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 7, -1, 5, chunkBox);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 8, -3, 5, chunkBox);
        GenerateBox(level, chunkBox, 9, -1, 1, 9, -1, 5, false, random, stones);

        // The lever puzzle and the hidden chest behind it.
        GenerateAirBox(level, chunkBox, 8, -3, 8, 10, -1, 10);
        PlaceBlock(level, Block.ChiseledStoneBricks.StateId, 8, -2, 11, chunkBox);
        PlaceBlock(level, Block.ChiseledStoneBricks.StateId, 9, -2, 11, chunkBox);
        PlaceBlock(level, Block.ChiseledStoneBricks.StateId, 10, -2, 11, chunkBox);

        uint lever = ((IAttachFaced)((IHorizontalFacing)Block.Lever).WithFacing(Direction.North))
            .WithFace(AttachDirection.Wall).StateId;

        PlaceBlock(level, lever, 8, -2, 12, chunkBox);
        PlaceBlock(level, lever, 9, -2, 12, chunkBox);
        PlaceBlock(level, lever, 10, -2, 12, chunkBox);

        GenerateBox(level, chunkBox, 8, -3, 8, 8, -3, 10, false, random, stones);
        GenerateBox(level, chunkBox, 10, -3, 8, 10, -3, 10, false, random, stones);
        PlaceBlock(level, Block.MossyCobblestone.StateId, 10, -2, 9, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 8, -2, 9, chunkBox);
        PlaceBlock(level, redstoneNorthSouth, 8, -2, 10, chunkBox);

        PlaceBlock(level, Redstone(
            (BlockFace.NegZ, RedstoneWireConnection.Side),
            (BlockFace.PosZ, RedstoneWireConnection.Side),
            (BlockFace.PosX, RedstoneWireConnection.Side),
            (BlockFace.NegX, RedstoneWireConnection.Side)), 10, -1, 9, chunkBox);

        PlaceBlock(level, Piston(Cardinal.Up), 9, -2, 8, chunkBox);
        PlaceBlock(level, Piston(Cardinal.West), 10, -2, 8, chunkBox);
        PlaceBlock(level, Piston(Cardinal.West), 10, -1, 8, chunkBox);
        PlaceBlock(level, ((IHorizontalFacing)Block.Repeater).WithFacing(Direction.North).StateId,
            10, -2, 10, chunkBox);

        if (!_placedHiddenChest) {
            _placedHiddenChest = CreateChest(level, chunkBox, random, 9, -3, 10);
        }
    }

    private static uint Stairs(Direction facing) {
        return ((IHorizontalFacing)Block.CobblestoneStairs).WithFacing(facing).StateId;
    }

    private static uint Hook(Direction facing) {
        return ((IAttached)((IHorizontalFacing)Block.TripwireHook).WithFacing(facing))
            .WithAttached(true).StateId;
    }

    /// <summary>A run of tripwire, already attached at both of the given faces.</summary>
    private static uint Wire(BlockFace first, BlockFace second) {
        IBlock wire = ((IAttached)Block.Tripwire).WithAttached(true);
        wire = ((IFaceConnected)wire).WithConnection(first, true);
        return ((IFaceConnected)wire).WithConnection(second, true).StateId;
    }

    private static uint Vine(BlockFace face) {
        return ((IFaceConnected)Block.Vine).WithConnection(face, true).StateId;
    }

    /// <summary>Redstone dust with exactly the named connections, everything else left at none.</summary>
    private static uint Redstone(params (BlockFace Face, RedstoneWireConnection Side)[] sides) {
        IBlock wire = Block.RedstoneWire;

        foreach ((BlockFace face, RedstoneWireConnection side) in sides) {
            wire = ((IRedstoneConnected)wire).WithConnection(face, side);
        }

        return wire.StateId;
    }

    private static uint Piston(Cardinal facing) {
        return ((IDirectional)Block.StickyPiston).WithFacing(facing).StateId;
    }
}
