using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>CopperGolemRenderState</c>. The animation states are the entity's own, not copies.</summary>
public class CopperGolemRenderState : ArmedEntityRenderState {
    public WeatheringCopperState Weathering = WeatheringCopperState.Unaffected;
    public CopperGolemState CopperGolemState = CopperGolemState.Idle;
    public AnimationState IdleAnimationState = new();
    public AnimationState InteractionGetItem = new();
    public AnimationState InteractionGetNoItem = new();
    public AnimationState InteractionDropItem = new();
    public AnimationState InteractionDropNoItem = new();
    public IBlock? BlockOnAntenna;
}

/// <summary><c>CopperGolemRenderer</c>.</summary>
public sealed class CopperGolemRenderer : MobRenderer<CopperGolemRenderState, CopperGolemModel> {
    private readonly ItemRenderer _items;

    public CopperGolemRenderer(EntityRendererContext context) : base(new CopperGolemModel(CopperGolemModel.CreateBodyLayer().BakeRoot()), 0.5F) {
        _items = context.Items;
        AddLayer(new LivingEntityEmissiveLayer<CopperGolemRenderState, CopperGolemModel>(this, state => OxidationLevel(state.Weathering).EyeTexture,
            (_, _) => 1.0F, new CopperGolemModel(CopperGolemModel.CreateBodyLayer().BakeRoot()), false, false));
        AddLayer(new ItemInHandLayer<CopperGolemRenderState, CopperGolemModel>(this, context.Items));
        AddLayer(new BlockDecorationLayer<CopperGolemRenderState, CopperGolemModel>(this, state => state.BlockOnAntenna, Model.ApplyBlockOnAntennaTransform,
            context.Blocks));
        AddLayer(new CustomHeadLayer<CopperGolemRenderState, CopperGolemModel>(this, context.Items));
    }

    /// <summary>The textures of <c>CopperGolemOxidationLevels</c>.</summary>
    private static (string Texture, string EyeTexture) OxidationLevel(WeatheringCopperState state) => state switch {
        WeatheringCopperState.Exposed => ("minecraft:textures/entity/copper_golem/copper_golem_exposed.png",
            "minecraft:textures/entity/copper_golem/copper_golem_eyes_exposed.png"),
        WeatheringCopperState.Weathered => ("minecraft:textures/entity/copper_golem/copper_golem_weathered.png",
            "minecraft:textures/entity/copper_golem/copper_golem_eyes_weathered.png"),
        WeatheringCopperState.Oxidized => ("minecraft:textures/entity/copper_golem/copper_golem_oxidized.png",
            "minecraft:textures/entity/copper_golem/copper_golem_eyes_oxidized.png"),
        _ => ("minecraft:textures/entity/copper_golem/copper_golem.png", "minecraft:textures/entity/copper_golem/copper_golem_eyes.png")
    };

    /// <summary><c>CopperGolem</c>'s animation states and the tick its next idle head spin starts on.</summary>
    private sealed class Animations {
        // The entity's own RandomSource; nothing compares these draws with vanilla's.
        public readonly Random Random = new();
        public int IdleAnimationStartTick;
        public readonly AnimationState Idle = new(), GetItem = new(), GetNoItem = new(), DropItem = new(), DropNoItem = new();

        /// <summary>Stops every chest interaction but <paramref name="keep"/>.</summary>
        public void StopInteractionsBut(AnimationState? keep) {
            foreach (AnimationState state in (ReadOnlySpan<AnimationState>)[GetItem, GetNoItem, DropItem, DropNoItem]) {
                if (state != keep) {
                    state.Stop();
                }
            }
        }
    }

    /// <summary>The client half of <c>CopperGolem.tick</c>: <c>setupAnimationStates</c>, unless it has no AI.</summary>
    public override void Tick(ClientEntity entity) {
        Animations a = (Animations)(entity.RendererData ??= new Animations());
        // Mob.isNoAi: bit 0 of DATA_MOB_FLAGS_ID.
        if ((entity.Get(EntityDataFields.Mob.MobFlags) & 1) != 0) {
            return;
        }
        int tickCount = entity.TickCount;
        CopperGolemState golemState = entity.Get(EntityDataFields.CopperGolem.CopperGolemState);
        if (golemState == CopperGolemState.Idle) {
            a.StopInteractionsBut(null);
            if (a.IdleAnimationStartTick == tickCount) {
                a.Idle.Start(tickCount);
            }
            else if (a.IdleAnimationStartTick == 0) {
                a.IdleAnimationStartTick = tickCount + a.Random.Next(200, 240);
            }
            if (tickCount == a.IdleAnimationStartTick + 10.0F) {
                a.IdleAnimationStartTick = 0;
            }
            return;
        }
        AnimationState? interaction = golemState switch {
            CopperGolemState.GettingItem => a.GetItem,
            CopperGolemState.GettingNoItem => a.GetNoItem,
            CopperGolemState.DroppingItem => a.DropItem,
            CopperGolemState.DroppingNoItem => a.DropNoItem,
            _ => null
        };
        if (interaction != null) {
            a.Idle.Stop();
            a.IdleAnimationStartTick = 0;
            a.StopInteractionsBut(interaction);
            interaction.StartIfStopped(tickCount);
        }
    }

    public override string GetTextureLocation(CopperGolemRenderState state) => OxidationLevel(state.Weathering).Texture;

    public override void ExtractRenderState(ClientEntity entity, CopperGolemRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ArmedEntityRenderState.ExtractArmedEntityRenderState(entity, state, _items, partialTick);
        state.Weathering = entity.Get(EntityDataFields.CopperGolem.WeatherState);
        state.CopperGolemState = entity.Get(EntityDataFields.CopperGolem.CopperGolemState);
        if (entity.RendererData is Animations a) {
            state.IdleAnimationState = a.Idle;
            state.InteractionGetItem = a.GetItem;
            state.InteractionGetNoItem = a.GetNoItem;
            state.InteractionDropItem = a.DropItem;
            state.InteractionDropNoItem = a.DropNoItem;
        }
        // CopperGolem.EQUIPMENT_SLOT_ANTENNA is the saddle slot.
        ItemStack antennaItem = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.BlockOnAntenna = antennaItem.IsAir() ? null : BlockOf(antennaItem, context);
    }

    /// <summary>
    /// <c>BlockItem.getBlock</c>'s default state. A block item is found as the block of the same name
    /// that names it as its item, which misses the few block items named apart from their block; the
    /// stack's <c>block_state</c> properties are not applied.
    /// </summary>
    private static IBlock? BlockOf(ItemStack stack, EntityRenderContext context) {
        Identifier id = stack.Type.Identifier;
        if (!context.Client.Registry.Blocks.Contains(id)) {
            return null;
        }
        IBlock block = context.Client.Registry.Blocks[id];
        return block.Item == id ? block : null;
    }
}
