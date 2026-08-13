using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Bundles;
using ManagedServer.Features.Impl;
using BlockBreakingFeature = ManagedServer.Features.Basic.BlockBreakingFeature;

namespace ManagedServer;

public partial class ManagedMinecraftServer {
    // Has to be a computed property so that each call to BasicsBundle returns a new instance.
    // having the same feature instance in multiple servers can cause issues.
    public static FeatureBundle BasicsBundle => new(
        new ArmSwingFeature(),
        new PongFeature(),
        new BasicChatFeature(),
        new BlockPlacingFeature(),
        new PlayerCrouchFeature(),
        new BlockBreakingFeature(),
        new InventoryClickFeature(),
        new DropItemsEventFeature(),
        new ConsumablesFeature(),
        new LoginProcedureFeature(),
        new SimpleTabListFeature(),
        new PlayerSkinLayersFeature(),
        new UseItemEventFeature(),
        new RightClickToEquipArmourFeature(),
        new CommandsFeature(),
        new InventoryClosingFeature(),
        new DialogFeature(),
        new AttributeModifiersFeature(true),
        new PlayerSwapItemFeature(),
        new DeathFeature(),
        new RespawnFeature(),
        new EffectsFeature()
    );

    /// <summary>
    /// Vanilla's block behaviour: what state a block goes down in and how it reacts to its
    /// neighbours. Stairs face away from you, slabs double, doors get a top half, fences connect,
    /// a ladder lets go of a wall that goes.
    /// <p/>
    /// Not part of <see cref="BasicsBundle"/>, on the same reasoning as <see cref="MobsBundle"/>:
    /// <see cref="BlockPlacingFeature"/> gives a player the ability to place a block, and what state
    /// it lands in is a separate choice. Without this every block places its default state, which is
    /// what vanilla does for a block whose class overrides nothing.
    /// <p/>
    /// For a subset, register <c>VanillaPlacementRulesFeature</c> directly with
    /// <c>VanillaPlacementRules.Only</c> or <c>Except</c> instead of taking this bundle.
    /// </summary>
    public static FeatureBundle BlockRulesBundle => new(
        new VanillaPlacementRulesFeature()
    );

    /// <summary>
    /// Flowing water and lava, buckets that place and pick it up, and what standing in it does to an
    /// entity. Not part of <see cref="BasicsBundle"/>: a map full of water only starts moving once
    /// something simulates it, so which servers want that is theirs to say.
    /// </summary>
    public static FeatureBundle LiquidsBundle => new(
        new LiquidsFeature(),
        new BucketsFeature(),
        new LavaDamageFeature(),
        new WaterExtinguishesFireFeature()
    );

    /// <summary>
    /// Mobs that decide things for themselves. Not part of <see cref="BasicsBundle"/>: it changes what
    /// every mob in every world does, and it brings <see cref="PhysicsFeature"/> with it because a mob
    /// whose movement is never simulated cannot act on anything it decides.
    /// <p/>
    /// A game that wants the AI engine but its own behaviour registers <see cref="PhysicsFeature"/>
    /// alone and fills in each mob's goals itself; the engine is core and needs no feature.
    /// </summary>
    public static FeatureBundle MobsBundle => new(
        new PhysicsFeature(),
        new VanillaMobAiFeature()
    );

    public static FeatureBundle BasicsWithMojangAuthBundle => BasicsBundle
            .Replace(new LoginProcedureFeature(true, true))
            .With(new MojangAuthenticationFeature());

    /// <summary>
    /// The basics bundle but with connection encryption disabled because
    /// velocity does not support it.
    /// </summary>
    public static FeatureBundle BasicsWithProxySupport => BasicsBundle
            .Replace(new LoginProcedureFeature(false));
    
    public static ManagedMinecraftServer New(params FeatureBundle[] bundle) {
        ManagedMinecraftServer server = new();
        server.AddFeatures(bundle);
        return server;
    }
}
