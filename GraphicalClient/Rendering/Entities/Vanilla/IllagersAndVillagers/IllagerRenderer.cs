using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public enum IllagerArmPose {
    Crossed,
    Attacking,
    Spellcasting,
    BowAndArrow,
    CrossbowHold,
    CrossbowCharge,
    Celebrating,
    Neutral
}

/// <summary>
/// <c>IllagerRenderState</c>. Vanilla redeclares <c>maxCrossbowChargeDuration</c> and <c>ticksUsingItem</c>
/// here, hiding <c>HumanoidRenderState</c>'s; nothing reads the hidden pair for an illager, so these use
/// the inherited fields.
/// </summary>
public class IllagerRenderState : UndeadRenderState {
    public bool IsRiding, IsAggressive;
    public IllagerArmPose ArmPose = IllagerArmPose.Neutral;
    public float AttackAnim;
}

/// <summary><c>IllagerRenderer</c>.</summary>
public abstract class IllagerRenderer<S> : MobRenderer<S, IllagerModel<S>> where S : IllagerRenderState, new() {
    protected readonly ItemRenderer Items;

    /// <summary>Every illager's layer is <c>IllagerModel.createBodyLayer</c> scaled by 0.9375, with a half block shadow.</summary>
    protected IllagerRenderer(EntityRendererContext context)
        : base(new IllagerModel<S>(IllagerModel<S>.CreateBodyLayer().Apply(MeshTransformers.Scaling(0.9375F)).BakeRoot()), 0.5F) {
        Items = context.Items;
        AddLayer(new CustomHeadLayer<S, IllagerModel<S>>(this, context.Items));
    }

    /// <summary><c>getArmPose</c> of the vanilla class; <c>AbstractIllager</c>'s is crossed arms.</summary>
    protected virtual IllagerArmPose GetArmPose(ClientEntity entity) => IllagerArmPose.Crossed;

    /// <summary><c>LivingEntity</c>'s item use timer, which the crossbow charge reads.</summary>
    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<HumanoidEntityData>(entity);

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ArmedEntityRenderState.ExtractArmedEntityRenderState(entity, state, Items, partialTick);
        state.IsRiding = entity.VehicleId != null;
        state.MainArm = ArmedEntityRenderState.MainArmOf(entity);
        state.ArmPose = GetArmPose(entity);
        state.MaxCrossbowChargeDuration = state.ArmPose == IllagerArmPose.CrossbowCharge ? GetChargeDuration(HumanoidEntityData.UseItem(entity)) : 0;
        state.TicksUsingItemValue = HumanoidEntityData.Of(entity).GetTicksUsingItem(entity, partialTick);
        state.AttackAnim = entity.GetAttackAnim(partialTick);
        state.IsAggressive = HumanoidEntityData.IsAggressive(entity);
    }

    /// <summary>
    /// <c>CrossbowItem.getChargeDuration</c>. <c>modifyCrossbowChargingTime</c> runs the stack's
    /// enchantment effects from the datapack; this applies vanilla <c>quick_charge</c>'s, a quarter
    /// second off per level, and no other enchantment's.
    /// </summary>
    private static int GetChargeDuration(ItemStack crossbow) {
        float duration = 1.25F + -0.25F * crossbow.GetEnchantmentLevel(Enchantment.QuickCharge);
        return Mth.Floor(duration * 20.0F);
    }

    /// <summary><c>Raider.isCelebrating</c>.</summary>
    protected static bool IsCelebrating(ClientEntity entity) => entity.Get(EntityDataFields.Raider.IsCelebrating);

    /// <summary><c>SpellcasterIllager.isCastingSpell</c>: the client reads the synced spell id.</summary>
    protected static bool IsCastingSpell(ClientEntity entity) => entity.Get(EntityDataFields.SpellcasterIllager.SpellCasting) > 0;

    /// <summary>An <c>ItemInHandLayer</c> drawn only while the predicate holds, as the illager renderers' anonymous subclasses are.</summary>
    protected sealed class ConditionalItemInHandLayer : ItemInHandLayer<S, IllagerModel<S>> {
        private readonly Func<S, bool> _condition;

        public ConditionalItemInHandLayer(LivingEntityRenderer<S, IllagerModel<S>> parent, ItemRenderer items, Func<S, bool> condition) : base(parent, items) {
            _condition = condition;
        }

        public override void Submit(PoseStack pose, EntityRenderContext context, S state) {
            if (_condition(state)) {
                base.Submit(pose, context, state);
            }
        }
    }
}
