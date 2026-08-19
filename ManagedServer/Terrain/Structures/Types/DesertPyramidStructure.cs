using ManagedServer.Placement;
using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures.Types;

/// <summary>
/// <c>DesertPyramidStructure</c>: the desert temple, twenty one square, plus the buried cellar its
/// after-place pass scatters suspicious sand through.
/// </summary>
public sealed class DesertPyramidStructure(Structure.StructureSettings settings)
    : SinglePieceStructure((random, west, north) => new DesertPyramidPiece(random, west, north),
        21, 21, settings) {

    /// <summary>
    /// Turns some of the cellar's sand into suspicious sand and the rest into plain sand.
    /// </summary>
    /// <remarks>
    /// It is an after-place pass rather than part of the piece because the count is over the
    /// <b>whole</b> cellar: between five and seven positions out of the couple of hundred the piece
    /// offered, drawn from a random seeded at the centre of the structure's box. So every chunk the
    /// cellar spans shuffles the same list in the same order and keeps its own share of the answer.
    /// <p/>
    /// The sand goes down and the archaeology loot does not, on <c>CreateChest</c>'s reasoning: the
    /// loot table lives on a brushable block entity and there is no port of one.
    /// </remarks>
    public override void AfterPlace(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, PiecesContainer pieces) {

        // Sorted and deduplicated, as vanilla's SortedArraySet over Vec3i.compareTo is, because the
        // shuffle below is only reproducible over a list two chunks agree about.
        SortedSet<Vec3<int>> unique = new(PositionOrder.Instance);

        foreach (StructurePiece piece in pieces.Pieces) {
            if (piece is not DesertPyramidPiece pyramid) {
                continue;
            }

            foreach (Vec3<int> position in pyramid.PotentialSuspiciousSandPositions) {
                unique.Add(position);
            }

            PlaceSuspiciousSand(level, chunkBox, pyramid.RandomCollapsedRoofPos);
        }

        List<Vec3<int>> shuffled = [..unique];

        Vec3<int> centre = pieces.CalculateBoundingBox().Center;

        // Vanilla's SingleThreadedRandomSource, which is LegacyRandomSource without the atomic: the
        // same scramble, the same next, and a forkPositional that builds the same factory.
        RandomSource positional = new LegacyRandomSource(level.Seed).ForkPositional()
            .At(centre.X, centre.Y, centre.Z);

        Shuffle(shuffled, positional);

        int toPlace = Math.Min(unique.Count, positional.NextInt(5, 8));

        foreach (Vec3<int> position in shuffled) {
            if (toPlace > 0) {
                toPlace--;
                PlaceSuspiciousSand(level, chunkBox, position);
            } else if (chunkBox.IsInside(position.X, position.Y, position.Z)) {
                level.SetState(position.X, position.Y, position.Z, Block.Sand.StateId);
            }
        }
    }

    private static void PlaceSuspiciousSand(IFeatureLevel level, BoundingBox chunkBox,
        Vec3<int> position) {

        if (chunkBox.IsInside(position.X, position.Y, position.Z)) {
            level.SetState(position.X, position.Y, position.Z, Block.SuspiciousSand.StateId);
        }
    }

    /// <summary><c>Util.shuffle</c>: a Fisher-Yates walk downwards, which is not the upwards one.</summary>
    private static void Shuffle<T>(List<T> items, RandomSource random) {
        for (int i = items.Count; i > 1; i--) {
            int swap = random.NextInt(i);
            (items[i - 1], items[swap]) = (items[swap], items[i - 1]);
        }
    }

    /// <summary><c>Vec3i.compareTo</c>, which orders by y, then z, then x.</summary>
    private sealed class PositionOrder : IComparer<Vec3<int>> {
        public static readonly PositionOrder Instance = new();

        public int Compare(Vec3<int> a, Vec3<int> b) {
            if (a.Y != b.Y) {
                return a.Y - b.Y;
            }

            return a.Z != b.Z ? a.Z - b.Z : a.X - b.X;
        }
    }
}

/// <summary>
/// <c>DesertPyramidPiece</c>: the pyramid, its TNT trap and the cellar under one corner of it.
/// </summary>
/// <remarks>
/// The piece drops to the <b>lowest</b> ground height over its footprint rather than the mean, minus
/// up to two blocks, so a pyramid on uneven sand has its bottom step buried rather than a corner in
/// the air.
/// </remarks>
public sealed class DesertPyramidPiece(RandomSource random, int west, int north)
    : ScatteredFeaturePiece(west, 64, north, 21, 15, 21, RandomHorizontalDirection(random)) {

    private readonly bool[] _hasPlacedChest = new bool[4];

    private readonly List<Vec3<int>> _potentialSuspiciousSand = [];

    /// <summary>Every cellar position the after-place pass may turn into suspicious sand.</summary>
    public IReadOnlyList<Vec3<int>> PotentialSuspiciousSandPositions => _potentialSuspiciousSand;

    /// <summary>The one roof block that is always suspicious, wherever the piece put it.</summary>
    public Vec3<int> RandomCollapsedRoofPos { get; private set; }

    public override void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos) {

        // The draw happens whether or not the height is already known, since it is an argument, so
        // it must not be hoisted into the constructor or moved behind the test.
        if (!UpdateHeightPositionToLowestGroundHeight(level, -random.NextInt(3))) {
            return;
        }

        uint sandstone = Block.Sandstone.StateId;
        uint cut = Block.CutSandstone.StateId;
        uint chiselled = Block.ChiseledSandstone.StateId;
        uint orange = Block.OrangeTerracotta.StateId;
        uint air = Block.Air.StateId;

        GenerateBox(level, chunkBox, 0, -4, 0, Width - 1, 0, Depth - 1, sandstone, sandstone, false);

        // The stepped sides, one ring per level: a solid slab and then the middle taken back out.
        for (int step = 1; step <= 9; step++) {
            GenerateBox(level, chunkBox, step, step, step, Width - 1 - step, step, Depth - 1 - step,
                sandstone, sandstone, false);
            GenerateBox(level, chunkBox, step + 1, step, step + 1, Width - 2 - step, step,
                Depth - 2 - step, air, air, false);
        }

        for (int x = 0; x < Width; x++) {
            for (int z = 0; z < Depth; z++) {
                FillColumnDown(level, sandstone, x, -5, z, chunkBox);
            }
        }

        uint northStairs = Stairs(Direction.North);
        uint southStairs = Stairs(Direction.South);
        uint eastStairs = Stairs(Direction.East);
        uint westStairs = Stairs(Direction.West);

        // The two towers, west then east.
        GenerateBox(level, chunkBox, 0, 0, 0, 4, 9, 4, sandstone, air, false);
        GenerateBox(level, chunkBox, 1, 10, 1, 3, 10, 3, sandstone, sandstone, false);
        PlaceBlock(level, northStairs, 2, 10, 0, chunkBox);
        PlaceBlock(level, southStairs, 2, 10, 4, chunkBox);
        PlaceBlock(level, eastStairs, 0, 10, 2, chunkBox);
        PlaceBlock(level, westStairs, 4, 10, 2, chunkBox);

        GenerateBox(level, chunkBox, Width - 5, 0, 0, Width - 1, 9, 4, sandstone, air, false);
        GenerateBox(level, chunkBox, Width - 4, 10, 1, Width - 2, 10, 3, sandstone, sandstone, false);
        PlaceBlock(level, northStairs, Width - 3, 10, 0, chunkBox);
        PlaceBlock(level, southStairs, Width - 3, 10, 4, chunkBox);
        PlaceBlock(level, eastStairs, Width - 5, 10, 2, chunkBox);
        PlaceBlock(level, westStairs, Width - 1, 10, 2, chunkBox);

        // The entrance.
        GenerateBox(level, chunkBox, 8, 0, 0, 12, 4, 4, sandstone, air, false);
        GenerateBox(level, chunkBox, 9, 1, 0, 11, 3, 4, air, air, false);
        PlaceBlock(level, cut, 9, 1, 1, chunkBox);
        PlaceBlock(level, cut, 9, 2, 1, chunkBox);
        PlaceBlock(level, cut, 9, 3, 1, chunkBox);
        PlaceBlock(level, cut, 10, 3, 1, chunkBox);
        PlaceBlock(level, cut, 11, 3, 1, chunkBox);
        PlaceBlock(level, cut, 11, 2, 1, chunkBox);
        PlaceBlock(level, cut, 11, 1, 1, chunkBox);

        GenerateBox(level, chunkBox, 4, 1, 1, 8, 3, 3, sandstone, air, false);
        GenerateBox(level, chunkBox, 4, 1, 2, 8, 2, 2, air, air, false);
        GenerateBox(level, chunkBox, 12, 1, 1, 16, 3, 3, sandstone, air, false);
        GenerateBox(level, chunkBox, 12, 1, 2, 16, 2, 2, air, air, false);

        GenerateBox(level, chunkBox, 5, 4, 5, Width - 6, 4, Depth - 6, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, 9, 4, 9, 11, 4, 11, air, air, false);
        GenerateBox(level, chunkBox, 8, 1, 8, 8, 3, 8, cut, cut, false);
        GenerateBox(level, chunkBox, 12, 1, 8, 12, 3, 8, cut, cut, false);
        GenerateBox(level, chunkBox, 8, 1, 12, 8, 3, 12, cut, cut, false);
        GenerateBox(level, chunkBox, 12, 1, 12, 12, 3, 12, cut, cut, false);
        GenerateBox(level, chunkBox, 1, 1, 5, 4, 4, 11, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, Width - 5, 1, 5, Width - 2, 4, 11, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, 6, 7, 9, 6, 7, 11, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, Width - 7, 7, 9, Width - 7, 7, 11, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, 5, 5, 9, 5, 7, 11, cut, cut, false);
        GenerateBox(level, chunkBox, Width - 6, 5, 9, Width - 6, 7, 11, cut, cut, false);

        PlaceBlock(level, air, 5, 5, 10, chunkBox);
        PlaceBlock(level, air, 5, 6, 10, chunkBox);
        PlaceBlock(level, air, 6, 6, 10, chunkBox);
        PlaceBlock(level, air, Width - 6, 5, 10, chunkBox);
        PlaceBlock(level, air, Width - 6, 6, 10, chunkBox);
        PlaceBlock(level, air, Width - 7, 6, 10, chunkBox);

        GenerateBox(level, chunkBox, 2, 4, 4, 2, 6, 4, air, air, false);
        GenerateBox(level, chunkBox, Width - 3, 4, 4, Width - 3, 6, 4, air, air, false);
        PlaceBlock(level, northStairs, 2, 4, 5, chunkBox);
        PlaceBlock(level, northStairs, 2, 3, 4, chunkBox);
        PlaceBlock(level, northStairs, Width - 3, 4, 5, chunkBox);
        PlaceBlock(level, northStairs, Width - 3, 3, 4, chunkBox);

        GenerateBox(level, chunkBox, 1, 1, 3, 2, 2, 3, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, Width - 3, 1, 3, Width - 2, 2, 3, sandstone, sandstone, false);
        PlaceBlock(level, sandstone, 1, 1, 2, chunkBox);
        PlaceBlock(level, sandstone, Width - 2, 1, 2, chunkBox);
        PlaceBlock(level, Block.SandstoneSlab.StateId, 1, 2, 2, chunkBox);
        PlaceBlock(level, Block.SandstoneSlab.StateId, Width - 2, 2, 2, chunkBox);
        PlaceBlock(level, westStairs, 2, 1, 2, chunkBox);
        PlaceBlock(level, eastStairs, Width - 3, 1, 2, chunkBox);

        GenerateBox(level, chunkBox, 4, 3, 5, 4, 3, 17, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, Width - 5, 3, 5, Width - 5, 3, 17, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, 3, 1, 5, 4, 2, 16, air, air, false);
        GenerateBox(level, chunkBox, Width - 6, 1, 5, Width - 5, 2, 16, air, air, false);

        for (int z = 5; z <= 17; z += 2) {
            PlaceBlock(level, cut, 4, 1, z, chunkBox);
            PlaceBlock(level, chiselled, 4, 2, z, chunkBox);
            PlaceBlock(level, cut, Width - 5, 1, z, chunkBox);
            PlaceBlock(level, chiselled, Width - 5, 2, z, chunkBox);
        }

        // The floor mosaic over the trap.
        PlaceBlock(level, orange, 10, 0, 7, chunkBox);
        PlaceBlock(level, orange, 10, 0, 8, chunkBox);
        PlaceBlock(level, orange, 9, 0, 9, chunkBox);
        PlaceBlock(level, orange, 11, 0, 9, chunkBox);
        PlaceBlock(level, orange, 8, 0, 10, chunkBox);
        PlaceBlock(level, orange, 12, 0, 10, chunkBox);
        PlaceBlock(level, orange, 7, 0, 10, chunkBox);
        PlaceBlock(level, orange, 13, 0, 10, chunkBox);
        PlaceBlock(level, orange, 9, 0, 11, chunkBox);
        PlaceBlock(level, orange, 11, 0, 11, chunkBox);
        PlaceBlock(level, orange, 10, 0, 12, chunkBox);
        PlaceBlock(level, orange, 10, 0, 13, chunkBox);
        PlaceBlock(level, Block.BlueTerracotta.StateId, 10, 0, 10, chunkBox);

        // The two side walls' pattern, and then the front wall's, which is the same one turned.
        for (int x = 0; x <= Width - 1; x += Width - 1) {
            PlaceBlock(level, cut, x, 2, 1, chunkBox);
            PlaceBlock(level, orange, x, 2, 2, chunkBox);
            PlaceBlock(level, cut, x, 2, 3, chunkBox);
            PlaceBlock(level, cut, x, 3, 1, chunkBox);
            PlaceBlock(level, orange, x, 3, 2, chunkBox);
            PlaceBlock(level, cut, x, 3, 3, chunkBox);
            PlaceBlock(level, orange, x, 4, 1, chunkBox);
            PlaceBlock(level, chiselled, x, 4, 2, chunkBox);
            PlaceBlock(level, orange, x, 4, 3, chunkBox);
            PlaceBlock(level, cut, x, 5, 1, chunkBox);
            PlaceBlock(level, orange, x, 5, 2, chunkBox);
            PlaceBlock(level, cut, x, 5, 3, chunkBox);
            PlaceBlock(level, orange, x, 6, 1, chunkBox);
            PlaceBlock(level, chiselled, x, 6, 2, chunkBox);
            PlaceBlock(level, orange, x, 6, 3, chunkBox);
            PlaceBlock(level, orange, x, 7, 1, chunkBox);
            PlaceBlock(level, orange, x, 7, 2, chunkBox);
            PlaceBlock(level, orange, x, 7, 3, chunkBox);
            PlaceBlock(level, cut, x, 8, 1, chunkBox);
            PlaceBlock(level, cut, x, 8, 2, chunkBox);
            PlaceBlock(level, cut, x, 8, 3, chunkBox);
        }

        for (int x = 2; x <= Width - 3; x += Width - 3 - 2) {
            PlaceBlock(level, cut, x - 1, 2, 0, chunkBox);
            PlaceBlock(level, orange, x, 2, 0, chunkBox);
            PlaceBlock(level, cut, x + 1, 2, 0, chunkBox);
            PlaceBlock(level, cut, x - 1, 3, 0, chunkBox);
            PlaceBlock(level, orange, x, 3, 0, chunkBox);
            PlaceBlock(level, cut, x + 1, 3, 0, chunkBox);
            PlaceBlock(level, orange, x - 1, 4, 0, chunkBox);
            PlaceBlock(level, chiselled, x, 4, 0, chunkBox);
            PlaceBlock(level, orange, x + 1, 4, 0, chunkBox);
            PlaceBlock(level, cut, x - 1, 5, 0, chunkBox);
            PlaceBlock(level, orange, x, 5, 0, chunkBox);
            PlaceBlock(level, cut, x + 1, 5, 0, chunkBox);
            PlaceBlock(level, orange, x - 1, 6, 0, chunkBox);
            PlaceBlock(level, chiselled, x, 6, 0, chunkBox);
            PlaceBlock(level, orange, x + 1, 6, 0, chunkBox);
            PlaceBlock(level, orange, x - 1, 7, 0, chunkBox);
            PlaceBlock(level, orange, x, 7, 0, chunkBox);
            PlaceBlock(level, orange, x + 1, 7, 0, chunkBox);
            PlaceBlock(level, cut, x - 1, 8, 0, chunkBox);
            PlaceBlock(level, cut, x, 8, 0, chunkBox);
            PlaceBlock(level, cut, x + 1, 8, 0, chunkBox);
        }

        GenerateBox(level, chunkBox, 8, 4, 0, 12, 6, 0, cut, cut, false);
        PlaceBlock(level, air, 8, 6, 0, chunkBox);
        PlaceBlock(level, air, 12, 6, 0, chunkBox);
        PlaceBlock(level, orange, 9, 5, 0, chunkBox);
        PlaceBlock(level, chiselled, 10, 5, 0, chunkBox);
        PlaceBlock(level, orange, 11, 5, 0, chunkBox);

        // The treasure room, fourteen blocks under the floor, with the pressure plate over the TNT.
        GenerateBox(level, chunkBox, 8, -14, 8, 12, -11, 12, cut, cut, false);
        GenerateBox(level, chunkBox, 8, -10, 8, 12, -10, 12, chiselled, chiselled, false);
        GenerateBox(level, chunkBox, 8, -9, 8, 12, -9, 12, cut, cut, false);
        GenerateBox(level, chunkBox, 8, -8, 8, 12, -1, 12, sandstone, sandstone, false);
        GenerateBox(level, chunkBox, 9, -11, 9, 11, -1, 11, air, air, false);
        PlaceBlock(level, Block.StonePressurePlate.StateId, 10, -11, 10, chunkBox);
        GenerateBox(level, chunkBox, 9, -13, 9, 11, -13, 11, Block.Tnt.StateId, air, false);

        PlaceBlock(level, air, 8, -11, 10, chunkBox);
        PlaceBlock(level, air, 8, -10, 10, chunkBox);
        PlaceBlock(level, chiselled, 7, -10, 10, chunkBox);
        PlaceBlock(level, cut, 7, -11, 10, chunkBox);
        PlaceBlock(level, air, 12, -11, 10, chunkBox);
        PlaceBlock(level, air, 12, -10, 10, chunkBox);
        PlaceBlock(level, chiselled, 13, -10, 10, chunkBox);
        PlaceBlock(level, cut, 13, -11, 10, chunkBox);
        PlaceBlock(level, air, 10, -11, 8, chunkBox);
        PlaceBlock(level, air, 10, -10, 8, chunkBox);
        PlaceBlock(level, chiselled, 10, -10, 7, chunkBox);
        PlaceBlock(level, cut, 10, -11, 7, chunkBox);
        PlaceBlock(level, air, 10, -11, 12, chunkBox);
        PlaceBlock(level, air, 10, -10, 12, chunkBox);
        PlaceBlock(level, chiselled, 10, -10, 13, chunkBox);
        PlaceBlock(level, cut, 10, -11, 13, chunkBox);

        // The four chests, indexed by the direction's own 2D data value so that a chest already
        // placed in another chunk is not placed again here.
        foreach (BlockFace face in Directions.Horizontal) {
            Direction direction = face.ToDirection();
            int slot = TwoDimensionalValue(direction);

            if (_hasPlacedChest[slot]) {
                continue;
            }

            _hasPlacedChest[slot] = CreateChest(level, chunkBox, random,
                10 + StepX(direction) * 2, -11, 10 + StepZ(direction) * 2);
        }

        AddCellar(level, chunkBox);
    }

    private void AddCellar(IFeatureLevel level, BoundingBox chunkBox) {
        Vec3<int> roomCenter = new(16, -4, 13);
        AddCellarStairs(roomCenter, level, chunkBox);
        AddCellarRoom(roomCenter, level, chunkBox);
    }

    private void AddCellarStairs(Vec3<int> roomCenter, IFeatureLevel level, BoundingBox chunkBox) {
        int x = roomCenter.X;
        int y = roomCenter.Y;
        int z = roomCenter.Z;

        // Turned a quarter counter-clockwise on the way in, on top of whatever turn the piece itself
        // applies, which is why these three go through the transform rather than being written facing.
        uint turned = BlockStateTransform
            .Rotate(level.Registry.Blocks.GetByStateId(Block.SandstoneStairs.StateId),
                BlockRotation.CounterClockwise90)
            .StateId;

        PlaceBlock(level, turned, 13, -1, 17, chunkBox);
        PlaceBlock(level, turned, 14, -2, 17, chunkBox);
        PlaceBlock(level, turned, 15, -3, 17, chunkBox);

        uint sand = Block.Sand.StateId;
        uint sandstone = Block.Sandstone.StateId;

        // The one place a piece draws from the level's own random rather than the pass's, so which
        // of the two blocks is sand depends on the chunk being generated.
        bool variant = level.LevelRandom.NextBoolean();

        PlaceBlock(level, sand, x - 4, y + 4, z + 4, chunkBox);
        PlaceBlock(level, sand, x - 3, y + 4, z + 4, chunkBox);
        PlaceBlock(level, sand, x - 2, y + 4, z + 4, chunkBox);
        PlaceBlock(level, sand, x - 1, y + 4, z + 4, chunkBox);
        PlaceBlock(level, sand, x, y + 4, z + 4, chunkBox);
        PlaceBlock(level, sand, x - 2, y + 3, z + 4, chunkBox);
        PlaceBlock(level, variant ? sand : sandstone, x - 1, y + 3, z + 4, chunkBox);
        PlaceBlock(level, !variant ? sand : sandstone, x, y + 3, z + 4, chunkBox);
        PlaceBlock(level, sand, x - 1, y + 2, z + 4, chunkBox);
        PlaceBlock(level, sandstone, x, y + 2, z + 4, chunkBox);
        PlaceBlock(level, sand, x, y + 1, z + 4, chunkBox);
    }

    private void AddCellarRoom(Vec3<int> roomCenter, IFeatureLevel level, BoundingBox chunkBox) {
        int x = roomCenter.X;
        int y = roomCenter.Y;
        int z = roomCenter.Z;

        uint cut = Block.CutSandstone.StateId;
        uint hieroglyphs = Block.ChiseledSandstone.StateId;

        GenerateBox(level, chunkBox, x - 3, y + 1, z - 3, x - 3, y + 1, z + 2, cut, cut, true);
        GenerateBox(level, chunkBox, x + 3, y + 1, z - 3, x + 3, y + 1, z + 2, cut, cut, true);
        GenerateBox(level, chunkBox, x - 3, y + 1, z - 3, x + 3, y + 1, z - 2, cut, cut, true);
        GenerateBox(level, chunkBox, x - 3, y + 1, z + 3, x + 3, y + 1, z + 3, cut, cut, true);
        GenerateBox(level, chunkBox, x - 3, y + 2, z - 3, x - 3, y + 2, z + 2, hieroglyphs, hieroglyphs, true);
        GenerateBox(level, chunkBox, x + 3, y + 2, z - 3, x + 3, y + 2, z + 2, hieroglyphs, hieroglyphs, true);
        GenerateBox(level, chunkBox, x - 3, y + 2, z - 3, x + 3, y + 2, z - 2, hieroglyphs, hieroglyphs, true);
        GenerateBox(level, chunkBox, x - 3, y + 2, z + 3, x + 3, y + 2, z + 3, hieroglyphs, hieroglyphs, true);
        GenerateBox(level, chunkBox, x - 3, -1, z - 3, x - 3, -1, z + 2, cut, cut, true);
        GenerateBox(level, chunkBox, x + 3, -1, z - 3, x + 3, -1, z + 2, cut, cut, true);
        GenerateBox(level, chunkBox, x - 3, -1, z - 3, x + 3, -1, z - 2, cut, cut, true);
        GenerateBox(level, chunkBox, x - 3, -1, z + 3, x + 3, -1, z + 3, cut, cut, true);

        RecordSandBox(x - 2, y + 1, z - 2, x + 2, y + 3, z + 2);
        PlaceCollapsedRoof(level, chunkBox, x - 2, y + 4, z - 2, x + 2, z + 2);

        uint orange = Block.OrangeTerracotta.StateId;

        PlaceBlock(level, Block.BlueTerracotta.StateId, x, y, z, chunkBox);
        PlaceBlock(level, orange, x + 1, y, z - 1, chunkBox);
        PlaceBlock(level, orange, x + 1, y, z + 1, chunkBox);
        PlaceBlock(level, orange, x - 1, y, z - 1, chunkBox);
        PlaceBlock(level, orange, x - 1, y, z + 1, chunkBox);
        PlaceBlock(level, orange, x + 2, y, z, chunkBox);
        PlaceBlock(level, orange, x - 2, y, z, chunkBox);
        PlaceBlock(level, orange, x, y, z + 2, chunkBox);
        PlaceBlock(level, orange, x, y, z - 2, chunkBox);

        PlaceBlock(level, orange, x + 3, y, z, chunkBox);
        RecordSand(x + 3, y + 1, z);
        RecordSand(x + 3, y + 2, z);
        PlaceBlock(level, cut, x + 4, y + 1, z, chunkBox);
        PlaceBlock(level, hieroglyphs, x + 4, y + 2, z, chunkBox);

        PlaceBlock(level, orange, x - 3, y, z, chunkBox);
        RecordSand(x - 3, y + 1, z);
        RecordSand(x - 3, y + 2, z);
        PlaceBlock(level, cut, x - 4, y + 1, z, chunkBox);
        PlaceBlock(level, hieroglyphs, x - 4, y + 2, z, chunkBox);

        PlaceBlock(level, orange, x, y, z + 3, chunkBox);
        RecordSand(x, y + 1, z + 3);
        RecordSand(x, y + 2, z + 3);

        PlaceBlock(level, orange, x, y, z - 3, chunkBox);
        RecordSand(x, y + 1, z - 3);
        RecordSand(x, y + 2, z - 3);
        PlaceBlock(level, cut, x, y + 1, z - 4, chunkBox);
        PlaceBlock(level, hieroglyphs, x, -2, z - 4, chunkBox);
    }

    /// <summary>
    /// Notes a position for the after-place pass and writes nothing.
    /// </summary>
    /// <remarks>
    /// Vanilla's method is called <c>placeSand</c> and places no sand either: what actually fills the
    /// cellar is <c>afterPlace</c> walking this list, so a position recorded here is left as whatever
    /// the terrain had until then.
    /// </remarks>
    private void RecordSand(int x, int y, int z) {
        _potentialSuspiciousSand.Add(GetWorldPos(x, y, z));
    }

    private void RecordSandBox(int x0, int y0, int z0, int x1, int y1, int z1) {
        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    RecordSand(x, y, z);
                }
            }
        }
    }

    /// <summary>
    /// The cellar's caved-in ceiling: a third sandstone and the rest sand, plus one position that the
    /// after-place pass always makes suspicious.
    /// </summary>
    private void PlaceCollapsedRoof(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0,
        int x1, int z1) {

        for (int x = x0; x <= x1; x++) {
            for (int z = z0; z <= z1; z++) {
                PlaceBlock(level, level.LevelRandom.NextFloat() < 0.33f
                    ? Block.Sandstone.StateId
                    : Block.Sand.StateId, x, y0, z, chunkBox);
            }
        }

        Vec3<int> corner = GetWorldPos(x0, y0, z0);
        RandomSource positional = new LegacyRandomSource(level.Seed).ForkPositional()
            .At(corner.X, corner.Y, corner.Z);

        int roofX = positional.NextIntBetweenInclusive(x0, x1);
        int roofZ = positional.NextIntBetweenInclusive(z0, z1);

        RandomCollapsedRoofPos = GetWorldPos(roofX, y0, roofZ);
    }

    private static uint Stairs(Direction facing) {
        return ((IHorizontalFacing)Block.SandstoneStairs).WithFacing(facing).StateId;
    }

    /// <summary><c>Direction.get2DDataValue</c>: south, west, north, east.</summary>
    private static int TwoDimensionalValue(Direction direction) {
        return direction switch {
            Direction.South => 0,
            Direction.West => 1,
            Direction.North => 2,
            _ => 3
        };
    }

    private static int StepX(Direction direction) {
        return direction switch {
            Direction.East => 1,
            Direction.West => -1,
            _ => 0
        };
    }

    private static int StepZ(Direction direction) {
        return direction switch {
            Direction.South => 1,
            Direction.North => -1,
            _ => 0
        };
    }
}
