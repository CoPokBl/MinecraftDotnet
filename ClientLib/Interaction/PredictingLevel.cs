using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Fluids;
using Minecraft.Placement;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ClientLib.Interaction;

/// <summary>
/// The level as the placement rules see it inside <c>useItemOn</c>'s prediction: <c>ClientLevel</c>,
/// whose <c>setBlock</c> records the server's state for every position it changes so the
/// acknowledgement can settle it, and which runs the same shape cascade a server does.
/// </summary>
internal sealed class PredictingLevel : IPlacementLevel {
    private readonly ClientLevel _level;
    private readonly MultiPlayerGameMode _gameMode;
    private readonly BlockTags _tags;
    private readonly NeighbourUpdater _neighbours;

    public PredictingLevel(ClientLevel level, MultiPlayerGameMode gameMode, BlockTags tags) {
        _level = level;
        _gameMode = gameMode;
        _tags = tags;
        _neighbours = new NeighbourUpdater(this);
    }

    public IBlock GetBlock(Vec3<int> pos) => _level.GetBlock(pos.X, pos.Y, pos.Z);

    public IBlock GetBlockOr(Vec3<int> pos, IBlock def) =>
        IsInBounds(pos) && _level.HasChunk(pos.X >> 4, pos.Z >> 4) ? GetBlock(pos) : def;

    public MinecraftRegistry Registry => _level.Registry;
    public int MinY => _level.MinY;
    public int Height => _level.Height;
    public bool IsInBounds(Vec3<int> pos) => pos.Y >= _level.MinY && pos.Y <= _level.MaxY;
    public bool IsClientSide => true;

    public bool IsInBlockTag(Identifier tag, Identifier block) => _tags.Contains(tag, Registry.Blocks[block]);

    /// <summary>A vanilla client knows every vanilla rule and no other.</summary>
    public IBlockPlacementRule? PlacementRuleFor(IBlock block) => VanillaPlacementRules.For(block);

    void IPlacementLevel.SetBlock(Vec3<int> pos, IBlock block, int flags, int updateLimit) => SetBlock(pos, block, flags, updateLimit);

    /// <summary><c>Level.setBlock</c>: false when the position is outside the world or its chunk, or already holds the state.</summary>
    public bool SetBlock(Vec3<int> pos, IBlock block, int flags = BlockUpdateFlags.Default, int updateLimit = BlockUpdateFlags.UpdateLimit) {
        if (!IsInBounds(pos) || !_level.HasChunk(pos.X >> 4, pos.Z >> 4) || _level.GetState(pos.X, pos.Y, pos.Z) == block.StateId) {
            return false;
        }
        _gameMode.SetPredicted(pos.X, pos.Y, pos.Z, (ushort)block.StateId);
        if ((flags & BlockUpdateFlags.KnownShape) == 0 && updateLimit > 0) {
            int cascade = flags & ~(BlockUpdateFlags.SuppressDrops | BlockUpdateFlags.NeighborUpdates);
            _neighbours.UpdateNeighbourShapes(pos, block, cascade, updateLimit - 1);
        }
        return true;
    }

    public bool DestroyBlock(Vec3<int> pos, bool dropResources, int updateLimit = BlockUpdateFlags.UpdateLimit) {
        IBlock existing = GetBlock(pos);
        if (existing.Air) {
            return false;
        }
        if (!BlockClasses.Is(existing.Identifier, BlockClass.BaseFireBlock)) {
            _level.RaiseLevelEvent(2001, pos.X, pos.Y, pos.Z, (int)existing.StateId);
        }
        return SetBlock(pos, FluidState.Of(existing).ToBlock(), BlockUpdateFlags.Default, updateLimit);
    }
}
