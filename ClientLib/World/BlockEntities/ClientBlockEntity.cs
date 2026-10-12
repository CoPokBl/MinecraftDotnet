using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace ClientLib.World.BlockEntities;

/// <summary>
/// <c>BlockEntity</c> as the client keeps it: the block it belongs to, what the server's update tag
/// said, and the state its client ticker animates. A type with nothing to draw or tick is this class.
/// </summary>
public class ClientBlockEntity {
    public IBlockEntityType Type { get; }
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    /// <summary><c>getBlockState</c>: the state at the position, kept current as the block changes.</summary>
    public IBlock State { get; internal set; }

    /// <summary><c>getLevel</c>: set once the block entity is in a level's chunk.</summary>
    public ClientLevel? Level { get; internal set; }

    /// <summary>Set when the block or its chunk goes away; a renderer holding it should let it go.</summary>
    public bool Removed { get; internal set; }

    /// <summary>The last update tag, for anything read straight off it.</summary>
    public CompoundTag Data { get; private set; } = new();

    protected ClientBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) {
        Type = type;
        X = x;
        Y = y;
        Z = z;
        State = state;
    }

    /// <summary><c>loadWithComponents</c> from an update tag.</summary>
    public void Load(CompoundTag tag, MinecraftRegistry registry) {
        Data = tag;
        LoadAdditional(tag, registry);
    }

    protected virtual void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) { }

    /// <summary><c>triggerEvent</c>, for a block event naming this block.</summary>
    public virtual bool TriggerEvent(int b0, int b1) => false;

    /// <summary>Whether the block's <c>getTicker</c> gives a client ticker for this state.</summary>
    public virtual bool HasClientTicker => false;

    /// <summary>The client ticker <c>getTicker</c> returns, run once a tick by <c>Level.tickBlockEntities</c>.</summary>
    public virtual void Tick(BlockEntityTickContext context) { }

    /// <summary><c>BlockEntityType.isValid</c>: the block names this type.</summary>
    public static bool IsValid(IBlockEntityType type, IBlock state) => state.BlockEntity is { } id && id.Equals(type.Identifier);

    /// <summary>
    /// <c>EntityBlock.newBlockEntity</c>: the type the state names, as the client class that animates
    /// it. Null for a state with no block entity or one the registry does not know.
    /// </summary>
    public static ClientBlockEntity? Create(MinecraftRegistry registry, int x, int y, int z, IBlock state) {
        // MovingPistonBlock.newBlockEntity makes none: a moving piston's comes from its piston's block event.
        if (state.BlockEntity is not { } id || !registry.BlockEntityTypes.Contains(id) || id.Equals(BlockEntityType.Piston.Identifier)) {
            return null;
        }
        IBlockEntityType type = registry.BlockEntityTypes[id];
        return Of(type, x, y, z, state);
    }

    private delegate ClientBlockEntity Factory(IBlockEntityType type, int x, int y, int z, IBlock state);

    private static readonly Dictionary<Identifier, Factory> Factories = new() {
        [BlockEntityType.Chest.Identifier] = (t, x, y, z, s) => new ChestBlockEntity(t, x, y, z, s),
        [BlockEntityType.TrappedChest.Identifier] = (t, x, y, z, s) => new ChestBlockEntity(t, x, y, z, s),
        [BlockEntityType.EnderChest.Identifier] = (t, x, y, z, s) => new ChestBlockEntity(t, x, y, z, s),
        [BlockEntityType.EnchantingTable.Identifier] = (t, x, y, z, s) => new EnchantingTableBlockEntity(t, x, y, z, s),
        [BlockEntityType.ShulkerBox.Identifier] = (t, x, y, z, s) => new ShulkerBoxBlockEntity(t, x, y, z, s),
        [BlockEntityType.Bell.Identifier] = (t, x, y, z, s) => new BellBlockEntity(t, x, y, z, s),
        [BlockEntityType.Conduit.Identifier] = (t, x, y, z, s) => new ConduitBlockEntity(t, x, y, z, s),
        [BlockEntityType.Sign.Identifier] = (t, x, y, z, s) => new SignBlockEntity(t, x, y, z, s),
        [BlockEntityType.HangingSign.Identifier] = (t, x, y, z, s) => new SignBlockEntity(t, x, y, z, s),
        [BlockEntityType.Banner.Identifier] = (t, x, y, z, s) => new BannerBlockEntity(t, x, y, z, s),
        [BlockEntityType.Skull.Identifier] = (t, x, y, z, s) => new SkullBlockEntity(t, x, y, z, s),
        [BlockEntityType.DecoratedPot.Identifier] = (t, x, y, z, s) => new DecoratedPotBlockEntity(t, x, y, z, s),
        [BlockEntityType.MobSpawner.Identifier] = (t, x, y, z, s) => new SpawnerBlockEntity(t, x, y, z, s),
        [BlockEntityType.TrialSpawner.Identifier] = (t, x, y, z, s) => new TrialSpawnerBlockEntity(t, x, y, z, s),
        [BlockEntityType.Vault.Identifier] = (t, x, y, z, s) => new VaultBlockEntity(t, x, y, z, s),
        [BlockEntityType.Campfire.Identifier] = (t, x, y, z, s) => new ItemDisplayBlockEntity(t, x, y, z, s),
        [BlockEntityType.Shelf.Identifier] = (t, x, y, z, s) => new ItemDisplayBlockEntity(t, x, y, z, s),
        [BlockEntityType.BrushableBlock.Identifier] = (t, x, y, z, s) => new BrushableBlockEntity(t, x, y, z, s),
        [BlockEntityType.Beacon.Identifier] = (t, x, y, z, s) => new BeaconBlockEntity(t, x, y, z, s),
        [BlockEntityType.CommandBlock.Identifier] = (t, x, y, z, s) => new CommandBlockEntity(t, x, y, z, s),
        [BlockEntityType.TestBlock.Identifier] = (t, x, y, z, s) => new TestBlockEntity(t, x, y, z, s),
        [BlockEntityType.Jigsaw.Identifier] = (t, x, y, z, s) => new JigsawBlockEntity(t, x, y, z, s)
    };

    private static ClientBlockEntity Of(IBlockEntityType type, int x, int y, int z, IBlock state) =>
        Factories.TryGetValue(type.Identifier, out Factory? factory) ? factory(type, x, y, z, state) : new ClientBlockEntity(type, x, y, z, state);

    /// <summary>Whether this is the given type, by identifier, as the registry's copy need not be the generated instance.</summary>
    public bool Is(IBlockEntityType type) => Type.Identifier.Equals(type.Identifier);
}
