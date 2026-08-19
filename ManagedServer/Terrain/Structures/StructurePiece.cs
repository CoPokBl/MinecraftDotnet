using ManagedServer.Placement;
using ManagedServer.Terrain.Features;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Terrain.Structures;

/// <summary>
/// <c>StructurePiece</c>: one room, corridor or hut of a structure, and the drawing primitives every
/// one of them is built out of.
/// </summary>
/// <remarks>
/// A piece is laid out in its <b>own local coordinates</b> and turned into world ones by
/// <see cref="Orientation"/>. That is what lets a mineshaft corridor be written once, running along
/// positive z, and then placed running any of four ways: <see cref="GetWorldX"/> and
/// <see cref="GetWorldZ"/> do the turn, and <see cref="PlaceBlock"/> puts the block itself through
/// <see cref="BlockStateTransform"/> so a stair still faces along the corridor.
/// <p/>
/// <b>Every write is clipped to one chunk.</b> <see cref="PlaceBlock"/> drops anything outside the
/// box it is handed, which the generation pass sets to the chunk being built, and <see cref="GetBlock"/>
/// answers air outside it. So a piece is run once per chunk it overlaps and writes only that chunk's
/// share of itself, which is vanilla's own arrangement and the reason the structure pass needs no
/// forks.
/// </remarks>
public abstract class StructurePiece {
    /// <summary>How deep in the piece tree this one is, which several structures branch on.</summary>
    public int GenDepth { get; set; }

    public BoundingBox BoundingBox { get; protected set; }

    /// <summary>
    /// Which way the piece faces, or null for one laid out directly in world coordinates.
    /// </summary>
    /// <remarks>
    /// Setting it also fixes the mirror and rotation a block goes through on the way in, which is
    /// vanilla's <c>setOrientation</c>. The pairing is not a rotation by quarter turns: south is a
    /// left-right mirror with no turn, and west is that mirror plus a quarter turn.
    /// </remarks>
    public Direction? Orientation {
        get => _orientation;
        set {
            _orientation = value;

            (Mirror, Rotation) = value switch {
                Direction.South => (BlockMirror.LeftRight, BlockRotation.None),
                Direction.West => (BlockMirror.LeftRight, BlockRotation.Clockwise90),
                Direction.East => (BlockMirror.None, BlockRotation.Clockwise90),
                _ => (BlockMirror.None, BlockRotation.None)
            };
        }
    }

    private Direction? _orientation;

    public BlockMirror Mirror { get; private set; }
    public BlockRotation Rotation { get; private set; }

    protected StructurePiece(int genDepth, BoundingBox boundingBox) {
        GenDepth = genDepth;
        BoundingBox = boundingBox;
    }

    /// <summary>
    /// Writes this piece's share of itself into the chunk the box covers.
    /// </summary>
    /// <param name="chunkBox">
    /// The writable area, which the pass sets to the chunk being generated. Everything outside it is
    /// dropped rather than forked.
    /// </param>
    public abstract void PostProcess(IFeatureLevel level, RandomSource random, BoundingBox chunkBox,
        int chunkX, int chunkZ, Vec3<int> referencePos);

    /// <summary>
    /// Adds whatever this piece decides should join it, which is how a structure grows from its start
    /// piece into a tree. Does nothing for a piece that is a leaf.
    /// </summary>
    public virtual void AddChildren(StructurePiece start, StructurePiecesBuilder builder,
        RandomSource random) { }

    /// <summary>Shifts the piece, which is how a builder drops a whole structure to a new height.</summary>
    public virtual void Move(int dx, int dy, int dz) {
        BoundingBox.Move(dx, dy, dz);
    }

    /// <summary>Whether the piece is within the given distance of a chunk.</summary>
    public bool IsCloseToChunk(int chunkX, int chunkZ, int distance) {
        int minX = chunkX << 4;
        int minZ = chunkZ << 4;

        return BoundingBox.Intersects(minX - distance, minZ - distance,
            minX + 15 + distance, minZ + 15 + distance);
    }

    /// <summary>
    /// A box from a corner, a facing and a size, vanilla's <c>makeBoundingBox</c>. The width and the
    /// depth swap over on the x facing directions.
    /// </summary>
    protected static BoundingBox MakeBoundingBox(int x, int y, int z, Direction direction, int width,
        int height, int depth) {

        return direction is Direction.North or Direction.South
            ? new BoundingBox(x, y, z, x + width - 1, y + height - 1, z + depth - 1)
            : new BoundingBox(x, y, z, x + depth - 1, y + height - 1, z + width - 1);
    }

    /// <summary><c>Direction.Plane.HORIZONTAL.getRandomDirection</c>.</summary>
    protected static Direction RandomHorizontalDirection(RandomSource random) {
        return Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)].ToDirection();
    }

    // ------------------------------------------------- local to world coordinates

    protected int GetWorldX(int x, int z) {
        return Orientation switch {
            null => x,
            Direction.North or Direction.South => BoundingBox.MinX + x,
            Direction.West => BoundingBox.MaxX - z,
            Direction.East => BoundingBox.MinX + z,
            _ => x
        };
    }

    /// <summary>All three at once, for a piece recording a position to come back to.</summary>
    protected Vec3<int> GetWorldPos(int x, int y, int z) {
        return new Vec3<int>(GetWorldX(x, z), GetWorldY(y), GetWorldZ(x, z));
    }

    protected int GetWorldY(int y) {
        return Orientation is null ? y : y + BoundingBox.MinY;
    }

    protected int GetWorldZ(int x, int z) {
        return Orientation switch {
            null => z,
            Direction.North => BoundingBox.MaxZ - z,
            Direction.South => BoundingBox.MinZ + z,
            Direction.West or Direction.East => BoundingBox.MinZ + x,
            _ => z
        };
    }

    // --------------------------------------------------------------- primitives

    /// <summary>
    /// Writes one block, turned the way the piece faces, if it lands inside the writable area.
    /// </summary>
    /// <remarks>
    /// Vanilla also schedules a fluid tick where the write lands in liquid, and marks a handful of
    /// blocks for post processing so their shape settles. There is no block tick scheduler in the
    /// generator, so neither happens: a fence or a torch placed against a wall keeps the state it was
    /// written with. Same gap the placement rules and the carvers document.
    /// </remarks>
    protected void PlaceBlock(IFeatureLevel level, uint stateId, int x, int y, int z,
        BoundingBox chunkBox) {

        int worldX = GetWorldX(x, z);
        int worldY = GetWorldY(y);
        int worldZ = GetWorldZ(x, z);

        if (!chunkBox.IsInside(worldX, worldY, worldZ)) {
            return;
        }

        if (!CanBeReplaced(level, x, y, z, chunkBox)) {
            return;
        }

        level.SetState(worldX, worldY, worldZ, Turned(level, stateId));
    }

    /// <summary>
    /// The state as the piece's own facing leaves it. Identity for a piece laid out in world
    /// coordinates, which is the common case and skips the registry lookup entirely.
    /// </summary>
    protected uint Turned(IFeatureLevel level, uint stateId) {
        if (Mirror == BlockMirror.None && Rotation == BlockRotation.None) {
            return stateId;
        }

        IBlock block = level.Registry.Blocks.GetByStateId(stateId);
        block = BlockStateTransform.Mirror(block, Mirror);
        block = BlockStateTransform.Rotate(block, Rotation);
        return block.StateId;
    }

    /// <summary>
    /// Whether a position may be written at all. Always yes here; the pieces that carve into terrain
    /// rather than sitting on it override it.
    /// </summary>
    protected virtual bool CanBeReplaced(IFeatureLevel level, int x, int y, int z,
        BoundingBox chunkBox) {

        return true;
    }

    /// <summary>Reads a block in piece coordinates. Air outside the writable area.</summary>
    protected uint GetBlock(IFeatureLevel level, int x, int y, int z, BoundingBox chunkBox) {
        int worldX = GetWorldX(x, z);
        int worldY = GetWorldY(y);
        int worldZ = GetWorldZ(x, z);

        return chunkBox.IsInside(worldX, worldY, worldZ)
            ? level.GetState(worldX, worldY, worldZ)
            : Block.Air.StateId;
    }

    /// <summary>
    /// Whether the position one above is under the terrain surface, which is how a piece tells the
    /// buried part of itself from the part sticking out.
    /// </summary>
    protected bool IsInterior(IFeatureLevel level, int x, int y, int z, BoundingBox chunkBox) {
        int worldX = GetWorldX(x, z);
        int worldY = GetWorldY(y + 1);
        int worldZ = GetWorldZ(x, z);

        if (!chunkBox.IsInside(worldX, worldY, worldZ)) {
            return false;
        }

        return worldY < level.GetHeight(HeightmapType.OceanFloorWorldgen, worldX, worldZ);
    }

    protected void GenerateAirBox(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0,
        int x1, int y1, int z1) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    PlaceBlock(level, Block.Air.StateId, x, y, z, chunkBox);
                }
            }
        }
    }

    /// <summary>
    /// A box with one block on its faces and another inside it, which is most of what a room is.
    /// </summary>
    /// <remarks>
    /// The edge test is "on any of the six faces", so a box one thick in some axis is all edge.
    /// </remarks>
    protected void GenerateBox(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0,
        int x1, int y1, int z1, uint edgeState, uint fillState, bool skipAir) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    if (skipAir && level.Blocks.IsAir(GetBlock(level, x, y, z, chunkBox))) {
                        continue;
                    }

                    bool inside = y != y0 && y != y1 && x != x0 && x != x1 && z != z0 && z != z1;
                    PlaceBlock(level, inside ? fillState : edgeState, x, y, z, chunkBox);
                }
            }
        }
    }

    protected void GenerateBox(IFeatureLevel level, BoundingBox chunkBox, BoundingBox box,
        uint edgeState, uint fillState, bool skipAir) {

        GenerateBox(level, chunkBox, box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ,
            edgeState, fillState, skipAir);
    }

    /// <summary>The same box, with a selector picking each block as it goes.</summary>
    protected void GenerateBox(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0, int z0,
        int x1, int y1, int z1, bool skipAir, RandomSource random, IBlockSelector selector) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    if (skipAir && level.Blocks.IsAir(GetBlock(level, x, y, z, chunkBox))) {
                        continue;
                    }

                    bool edge = y == y0 || y == y1 || x == x0 || x == x1 || z == z0 || z == z1;
                    selector.Next(random, x, y, z, edge);
                    PlaceBlock(level, selector.Current, x, y, z, chunkBox);
                }
            }
        }
    }

    protected void GenerateBox(IFeatureLevel level, BoundingBox chunkBox, BoundingBox box,
        bool skipAir, RandomSource random, IBlockSelector selector) {

        GenerateBox(level, chunkBox, box.MinX, box.MinY, box.MinZ, box.MaxX, box.MaxY, box.MaxZ,
            skipAir, random, selector);
    }

    /// <summary>
    /// A box whose blocks are each rolled for, which is how a ruined wall gets its holes.
    /// </summary>
    /// <remarks>
    /// The roll happens for every position <b>before</b> the two skip tests, so which blocks survive
    /// depends on the size of the box and not on what is already there.
    /// </remarks>
    protected void GenerateMaybeBox(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        float probability, int x0, int y0, int z0, int x1, int y1, int z1, uint edgeState,
        uint fillState, bool skipAir, bool hasToBeInside) {

        for (int y = y0; y <= y1; y++) {
            for (int x = x0; x <= x1; x++) {
                for (int z = z0; z <= z1; z++) {
                    if (random.NextFloat() > probability) {
                        continue;
                    }

                    if (skipAir && level.Blocks.IsAir(GetBlock(level, x, y, z, chunkBox))) {
                        continue;
                    }

                    if (hasToBeInside && !IsInterior(level, x, y, z, chunkBox)) {
                        continue;
                    }

                    bool inside = y != y0 && y != y1 && x != x0 && x != x1 && z != z0 && z != z1;
                    PlaceBlock(level, inside ? fillState : edgeState, x, y, z, chunkBox);
                }
            }
        }
    }

    protected void MaybeGenerateBlock(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        float probability, int x, int y, int z, uint stateId) {

        if (random.NextFloat() < probability) {
            PlaceBlock(level, stateId, x, y, z, chunkBox);
        }
    }

    /// <summary>
    /// The top half of an ellipsoid, which is the shape a mineshaft room is dug out of.
    /// </summary>
    /// <remarks>
    /// The cutoff is 1.05 rather than 1, which is what gives the shape its slightly squared corners.
    /// </remarks>
    protected void GenerateUpperHalfSphere(IFeatureLevel level, BoundingBox chunkBox, int x0, int y0,
        int z0, int x1, int y1, int z1, uint fillState, bool skipAir) {

        float diagX = x1 - x0 + 1;
        float diagY = y1 - y0 + 1;
        float diagZ = z1 - z0 + 1;
        float centerX = x0 + diagX / 2.0f;
        float centerZ = z0 + diagZ / 2.0f;

        for (int y = y0; y <= y1; y++) {
            float distanceY = (y - y0) / diagY;

            for (int x = x0; x <= x1; x++) {
                float distanceX = (x - centerX) / (diagX * 0.5f);

                for (int z = z0; z <= z1; z++) {
                    float distanceZ = (z - centerZ) / (diagZ * 0.5f);

                    if (skipAir && level.Blocks.IsAir(GetBlock(level, x, y, z, chunkBox))) {
                        continue;
                    }

                    float distance = distanceX * distanceX + distanceY * distanceY
                        + distanceZ * distanceZ;

                    if (distance <= 1.05f) {
                        PlaceBlock(level, fillState, x, y, z, chunkBox);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Fills downwards from a position until it meets something solid, which is what puts a leg under
    /// a piece hanging over a drop.
    /// </summary>
    /// <remarks>
    /// Writes straight to the level rather than through <see cref="PlaceBlock"/>, so the blocks it
    /// lays are not turned. That is vanilla, and it is only ever asked to place a plain cube.
    /// </remarks>
    protected void FillColumnDown(IFeatureLevel level, uint stateId, int x, int startY, int z,
        BoundingBox chunkBox) {

        int worldX = GetWorldX(x, z);
        int worldY = GetWorldY(startY);
        int worldZ = GetWorldZ(x, z);

        if (!chunkBox.IsInside(worldX, worldY, worldZ)) {
            return;
        }

        while (IsReplaceableByStructures(level, level.GetState(worldX, worldY, worldZ))
            && worldY > level.MinY + 1) {

            level.SetState(worldX, worldY, worldZ, stateId);
            worldY--;
        }
    }

    /// <summary>
    /// What a leg may be driven through: air, any liquid, and the three plants that grow in the way.
    /// </summary>
    protected static bool IsReplaceableByStructures(IFeatureLevel level, uint stateId) {
        if (level.Blocks.IsAir(stateId) || level.Blocks.HasFluidAt(stateId)) {
            return true;
        }

        Identifier block = level.Registry.Blocks.GetByStateId(stateId).Identifier;

        return block.Equals(Block.GlowLichen.Identifier)
            || block.Equals(Block.Seagrass.Identifier)
            || block.Equals(Block.TallSeagrass.Identifier);
    }

    /// <summary>
    /// Places a chest, turned to face whichever way <see cref="Reorient"/> decides.
    /// </summary>
    /// <remarks>
    /// The chest goes down and its loot table does not, because a loot table lives on a block entity
    /// and there is no port of one: <c>BlockEntity</c> here is the wire record and carries no
    /// contents. So every chest a structure places is real and empty. The same gap stops a mineshaft
    /// spawner spawning anything and a monument's block entities existing at all.
    /// </remarks>
    protected bool CreateChest(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        int x, int y, int z, uint? state = null) {

        int worldX = GetWorldX(x, z);
        int worldY = GetWorldY(y);
        int worldZ = GetWorldZ(x, z);

        if (!chunkBox.IsInside(worldX, worldY, worldZ)) {
            return false;
        }

        uint existing = level.GetState(worldX, worldY, worldZ);

        if (level.Registry.Blocks.GetByStateId(existing).Identifier.Equals(Block.Chest.Identifier)) {
            return false;
        }

        level.SetState(worldX, worldY, worldZ,
            state ?? Reorient(level, worldX, worldY, worldZ, Block.Chest.StateId));

        ConsumeLootSeed(random);
        return true;
    }

    /// <summary>
    /// Places a trap dispenser facing the given way, empty for <see cref="CreateChest"/>'s reason.
    /// </summary>
    /// <remarks>
    /// The facing goes through <see cref="PlaceBlock"/>, so it turns with the piece: the jungle
    /// temple's two dispensers fire along their own corridors whichever way the temple ended up.
    /// </remarks>
    protected bool CreateDispenser(IFeatureLevel level, BoundingBox chunkBox, RandomSource random,
        int x, int y, int z, Direction facing) {

        Vec3<int> world = GetWorldPos(x, y, z);

        if (!chunkBox.IsInside(world.X, world.Y, world.Z)) {
            return false;
        }

        uint existing = level.GetState(world.X, world.Y, world.Z);

        if (level.Registry.Blocks.GetByStateId(existing).Identifier
            .Equals(Block.Dispenser.Identifier)) {

            return false;
        }

        PlaceBlock(level,
            ((IDirectional)Block.Dispenser).WithFacing(facing.ToFace().ToCardinal()).StateId,
            x, y, z, chunkBox);

        ConsumeLootSeed(random);
        return true;
    }

    /// <summary>
    /// The same at an absolute position, which is what a template piece's data marker has.
    /// </summary>
    /// <remarks>
    /// Not turned, because the caller already knows which way the chest faces: a mansion's marker
    /// names the direction and turns it by the piece's own rotation before calling.
    /// </remarks>
    protected static bool CreateChestAt(IFeatureLevel level, BoundingBox chunkBox,
        RandomSource random, Vec3<int> pos, uint? state = null) {

        if (!chunkBox.IsInside(pos.X, pos.Y, pos.Z)) {
            return false;
        }

        uint existing = level.GetState(pos.X, pos.Y, pos.Z);

        if (level.Registry.Blocks.GetByStateId(existing).Identifier.Equals(Block.Chest.Identifier)) {
            return false;
        }

        level.SetState(pos.X, pos.Y, pos.Z,
            state ?? Reorient(level, pos.X, pos.Y, pos.Z, Block.Chest.StateId));

        ConsumeLootSeed(random);
        return true;
    }

    /// <summary>
    /// <c>Util.shuffle</c>: a Fisher-Yates pass walking <b>down</b> from the end of the list.
    /// </summary>
    /// <remarks>
    /// The direction and the exclusive bound are both vanilla's, and together they decide which
    /// permutation a given seed produces. A shuffle written the other way round generates a different
    /// mansion from the same seed.
    /// </remarks>
    public static void Shuffle<T>(IList<T> list, RandomSource random) {
        for (int i = list.Count; i > 1; i--) {
            int swap = random.NextInt(i);
            (list[i - 1], list[swap]) = (list[swap], list[i - 1]);
        }
    }

    /// <summary>
    /// The draw that would have seeded the container's loot table.
    /// </summary>
    /// <remarks>
    /// There is no block entity to give a loot table to, but the draw still has to happen: vanilla
    /// takes it from the <b>same</b> random the rest of the piece is laid out from, so skipping it
    /// moves every block placed after a chest. The jungle temple lays three more walls after its
    /// first dispenser.
    /// </remarks>
    private static void ConsumeLootSeed(RandomSource random) {
        random.NextLong();
    }

    /// <summary>
    /// <c>StructurePiece.reorient</c>: which way a chest dropped into a room should face.
    /// </summary>
    /// <remarks>
    /// Exactly one solid neighbour means the chest backs onto it. None, or more than one, falls
    /// through to walking the state's own facing round until it is not looking into a wall, which is
    /// why a chest in a corridor faces along it.
    /// </remarks>
    internal static uint Reorient(IFeatureLevel level, int x, int y, int z, uint stateId) {
        IBlock block = level.Registry.Blocks.GetByStateId(stateId);

        if (block is not IHorizontalFacing facing) {
            return stateId;
        }

        Direction? solidNeighbour = null;

        foreach (BlockFace face in Directions.Horizontal) {
            (int nx, int ny, int nz) = Offset(x, y, z, face);
            uint neighbour = level.GetState(nx, ny, nz);

            if (level.Registry.Blocks.GetByStateId(neighbour).Identifier
                .Equals(Block.Chest.Identifier)) {

                return stateId;
            }

            if (!level.Blocks.IsSolid(neighbour)) {
                continue;
            }

            if (solidNeighbour is not null) {
                solidNeighbour = null;
                break;
            }

            solidNeighbour = face.ToDirection();
        }

        if (solidNeighbour is { } backing) {
            return facing.WithFacing(backing.Opposite()).StateId;
        }

        Direction looking = facing.Facing;

        for (int attempt = 0; attempt < 3; attempt++) {
            (int nx, int ny, int nz) = Offset(x, y, z, looking.ToFace());

            if (!level.Blocks.IsSolid(level.GetState(nx, ny, nz))) {
                break;
            }

            looking = attempt == 1 ? looking.ClockWise() : looking.Opposite();
        }

        return facing.WithFacing(looking).StateId;
    }

    private static (int, int, int) Offset(int x, int y, int z, BlockFace face) {
        return face switch {
            BlockFace.NegY => (x, y - 1, z),
            BlockFace.PosY => (x, y + 1, z),
            BlockFace.NegZ => (x, y, z - 1),
            BlockFace.PosZ => (x, y, z + 1),
            BlockFace.NegX => (x - 1, y, z),
            _ => (x + 1, y, z)
        };
    }

    /// <summary>The first piece in the list whose box overlaps the given one, or null.</summary>
    public static StructurePiece? FindCollisionPiece(IReadOnlyList<StructurePiece> pieces,
        BoundingBox box) {

        foreach (StructurePiece piece in pieces) {
            if (piece.BoundingBox.Intersects(box)) {
                return piece;
            }
        }

        return null;
    }

    /// <summary>
    /// Picks the block at each position of a <see cref="GenerateBox"/>, which is how a stronghold
    /// wall gets its mix of cracked and mossy bricks.
    /// </summary>
    public interface IBlockSelector {
        /// <summary>Chooses the next block. <paramref name="edge"/> is true on the box's faces.</summary>
        void Next(RandomSource random, int x, int y, int z, bool edge);

        /// <summary>What the last <see cref="Next"/> chose.</summary>
        uint Current { get; }
    }
}
