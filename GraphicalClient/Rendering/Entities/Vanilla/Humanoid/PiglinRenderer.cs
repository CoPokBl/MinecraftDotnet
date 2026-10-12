using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>PiglinArmPose</c>.</summary>
public enum PiglinArmPose {
    AttackingWithMeleeWeapon,
    CrossbowHold,
    CrossbowCharge,
    AdmiringItem,
    Dancing,
    Default
}

/// <summary><c>PiglinRenderState</c>.</summary>
public class PiglinRenderState : HumanoidRenderState {
    public bool IsBrute;
    public bool IsConverting;
    public float MaxCrossbowChageDuration;
    public PiglinArmPose ArmPose = PiglinArmPose.Default;
}

/// <summary><c>PiglinRenderer</c>.</summary>
public sealed class PiglinRenderer : HumanoidMobRenderer<PiglinRenderState, PiglinModel> {
    private const string PiglinLocation = "minecraft:textures/entity/piglin/piglin.png";
    private const string PiglinBabyLocation = "minecraft:textures/entity/piglin/piglin_baby.png";
    private const string PiglinBruteLocation = "minecraft:textures/entity/piglin/piglin_brute.png";
    private static readonly Identifier PiglinLovedTag = "minecraft:piglin_loved";
    public static readonly CustomHeadLayer.Transforms PiglinCustomHeadTransforms = new(0.0F, 0.0F, 1.0019531F);

    public PiglinRenderer(EntityRendererContext context, LayerDefinition body, LayerDefinition babyBody, ArmorModelSet<LayerDefinition> armorSet,
        ArmorModelSet<LayerDefinition> babyArmorSet)
        : base(context, new AdultPiglinModel(body.BakeRoot()), new BabyPiglinModel(babyBody.BakeRoot()), 0.5F, PiglinCustomHeadTransforms) {
        AddLayer(new HumanoidArmorLayer<PiglinRenderState, PiglinModel, PiglinModel>(this,
            ArmorModelSet.Bake<PiglinModel>(armorSet, root => new AdultPiglinModel(root)),
            ArmorModelSet.Bake<PiglinModel>(babyArmorSet, root => new BabyPiglinModel(root)),
            EquipmentRenderer));
    }

    public static PiglinRenderer Piglin(EntityRendererContext context) =>
        new(context, AdultPiglinModel.CreateBodyLayer(), BabyPiglinModel.CreateBodyLayer(), HumanoidLayers.PiglinArmor(), HumanoidLayers.PiglinBabyArmor());

    /// <summary>The brute's baby model and armour are baked from its adult layers, as <c>EntityRenderers</c> registers it.</summary>
    public static PiglinRenderer PiglinBrute(EntityRendererContext context) =>
        new(context, AdultPiglinModel.CreateBodyLayer(), AdultPiglinModel.CreateBodyLayer(), HumanoidLayers.PiglinArmor(), HumanoidLayers.PiglinArmor());

    public override string GetTextureLocation(PiglinRenderState state) => state.IsBrute ? PiglinBruteLocation : state.IsBaby ? PiglinBabyLocation : PiglinLocation;

    public override void ExtractRenderState(ClientEntity entity, PiglinRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsBrute = entity.Type == EntityType.PiglinBrute;
        state.ArmPose = GetPiglinArmPose(entity, context);
        state.MaxCrossbowChageDuration = HumanoidEntityData.CrossbowChargeDuration(HumanoidEntityData.UseItem(entity));
        state.IsConverting = IsConverting(entity, context.Level);
    }

    protected override bool IsShaking(PiglinRenderState state) => base.IsShaking(state) || state.IsConverting;

    /// <summary><c>Piglin.getArmPose</c> and <c>PiglinBrute.getArmPose</c>.</summary>
    private static PiglinArmPose GetPiglinArmPose(ClientEntity entity, EntityRenderContext context) {
        bool attacking = HumanoidEntityData.IsAggressive(entity) && IsHoldingMeleeWeapon(entity);
        if (entity.Type == EntityType.PiglinBrute) {
            return attacking ? PiglinArmPose.AttackingWithMeleeWeapon : PiglinArmPose.Default;
        }
        if (entity.Get(EntityDataFields.Piglin.IsDancing)) {
            return PiglinArmPose.Dancing;
        }
        // PiglinAi.isLovedItem: the piglin_loved tag.
        if (context.Client.Inventory.Data.InTag(ClientLib.Inventory.Stack.Of(entity.ItemInHand(Hand.OffHand)), PiglinLovedTag)) {
            return PiglinArmPose.AdmiringItem;
        }
        if (attacking) {
            return PiglinArmPose.AttackingWithMeleeWeapon;
        }
        if (entity.Get(EntityDataFields.Piglin.IsChargingCrossbow)) {
            return PiglinArmPose.CrossbowCharge;
        }
        ItemStack mainHand = entity.ItemInHand(Hand.MainHand);
        bool holdingCrossbow = mainHand.Is(Item.Crossbow) || entity.ItemInHand(Hand.OffHand).Is(Item.Crossbow);
        // getWeaponItem: the main hand.
        return holdingCrossbow && mainHand.Has(DataComponent.ChargedProjectiles) && mainHand.Get(DataComponent.ChargedProjectiles).Length > 0
            ? PiglinArmPose.CrossbowHold
            : PiglinArmPose.Default;
    }

    /// <summary><c>AbstractPiglin.isHoldingMeleeWeapon</c>: a main hand item with a tool component.</summary>
    private static bool IsHoldingMeleeWeapon(ClientEntity entity) => entity.ItemInHand(Hand.MainHand).Has(DataComponent.Tool);

    /// <summary><c>AbstractPiglin.isConverting</c>.</summary>
    private static bool IsConverting(ClientEntity entity, ClientLevel level) {
        // Mob.isNoAi: bit 0 of DATA_MOB_FLAGS_ID.
        bool noAi = (entity.Get(EntityDataFields.Mob.MobFlags) & 1) != 0;
        return !entity.Get(EntityDataFields.AbstractPiglin.ImmuneToZombification) && !noAi && PiglinsZombify(entity, level);
    }

    /// <summary>
    /// <c>EnvironmentAttributes.PIGLINS_ZOMBIFY</c> where the entity stands: the biome's value over the
    /// dimension's over the default. A biome entry that modifies the dimension's value rather than
    /// replacing it is not applied; no vanilla biome has one for this attribute.
    /// </summary>
    private static bool PiglinsZombify(ClientEntity entity, ClientLevel level) {
        bool value = true;
        if (level.DimensionType.Attributes?[EnvironmentAttribute.GameplayPiglinsZombify.Identifier.ToString()] is { } dimension) {
            value = dimension.GetBoolean();
        }
        int x = (int)Math.Floor(entity.Position.X), y = (int)Math.Floor(entity.Position.Y), z = (int)Math.Floor(entity.Position.Z);
        int biomeId = level.GetBiome(x, y, z);
        if (biomeId < level.Registry.Biomes.Count
            && level.Registry.Biomes[biomeId].Attributes[EnvironmentAttribute.GameplayPiglinsZombify] is EnvironmentAttributeEntry.Constant { Value: EnvironmentAttributeValue.Boolean fromBiome }) {
            value = fromBiome.Value;
        }
        return value;
    }
}
