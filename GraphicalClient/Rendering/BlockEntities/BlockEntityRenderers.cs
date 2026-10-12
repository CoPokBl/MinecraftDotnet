using ClientLib.World.BlockEntities;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Schemas;
using BlockEntityType = Minecraft.Data.Generated.BlockEntityType;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary>
/// <c>BlockEntityRenderers</c>: the renderer each block entity type is drawn with. The end portal and
/// gateway are drawn by <see cref="EndPortalRenderer"/> from the meshed sections instead, and the structure
/// block and test instance block have none here.
/// </summary>
public static class BlockEntityRenderers {
    private static readonly Dictionary<Identifier, Func<BlockEntityRendererContext, BlockEntityRenderer>> Providers = new();

    static BlockEntityRenderers() {
        Register(BlockEntityType.Sign, context => new SignRenderer(context));
        Register(BlockEntityType.HangingSign, context => new SignRenderer(context));
        Register(BlockEntityType.MobSpawner, context => new SpawnerRenderer<SpawnerBlockEntity>(context));
        Register(BlockEntityType.Piston, context => new PistonHeadRenderer(context));
        Register(BlockEntityType.Chest, context => new ChestRenderer(context));
        Register(BlockEntityType.EnderChest, context => new ChestRenderer(context));
        Register(BlockEntityType.TrappedChest, context => new ChestRenderer(context));
        Register(BlockEntityType.EnchantingTable, context => new EnchantTableRenderer(context));
        Register(BlockEntityType.Lectern, context => new LecternRenderer(context));
        Register(BlockEntityType.Skull, context => new SkullBlockRenderer(context));
        Register(BlockEntityType.Banner, context => new BannerRenderer(context));
        Register(BlockEntityType.ShulkerBox, context => new ShulkerBoxRenderer(context));
        Register(BlockEntityType.Conduit, context => new ConduitRenderer(context));
        Register(BlockEntityType.Bell, context => new BellRenderer(context));
        Register(BlockEntityType.Campfire, context => new CampfireRenderer(context));
        Register(BlockEntityType.BrushableBlock, context => new BrushableBlockRenderer(context));
        Register(BlockEntityType.DecoratedPot, context => new DecoratedPotRenderer(context));
        Register(BlockEntityType.TrialSpawner, context => new SpawnerRenderer<TrialSpawnerBlockEntity>(context));
        Register(BlockEntityType.Vault, context => new VaultRenderer(context));
        Register(BlockEntityType.CopperGolemStatue, context => new CopperGolemStatueRenderer(context));
        Register(BlockEntityType.Shelf, context => new ShelfRenderer(context));
        Register(BlockEntityType.Beacon, context => new BeaconRenderer(context));
    }

    /// <summary>
    /// The types whose renderer draws the whole block, which vanilla gives an empty block model, so the
    /// built in art draws no stand in for them.
    /// </summary>
    private static readonly HashSet<Identifier> WholeBlock = new IBlockEntityType[] {
        BlockEntityType.Chest, BlockEntityType.TrappedChest, BlockEntityType.EnderChest, BlockEntityType.ShulkerBox, BlockEntityType.Banner,
        BlockEntityType.Skull, BlockEntityType.DecoratedPot, BlockEntityType.Conduit, BlockEntityType.CopperGolemStatue
    }.Select(type => type.Identifier).ToHashSet();

    public static bool DrawsWholeBlock(Minecraft.Data.Blocks.IBlock state) => state.BlockEntity is { } id && WholeBlock.Contains(id);

    private static void Register(IBlockEntityType type, Func<BlockEntityRendererContext, BlockEntityRenderer> provider) => Providers[type.Identifier] = provider;

    /// <summary><c>createEntityRenderers</c>.</summary>
    public static Dictionary<Identifier, BlockEntityRenderer> CreateAll(BlockEntityRendererContext context) =>
        Providers.ToDictionary(entry => entry.Key, entry => entry.Value(context));
}
