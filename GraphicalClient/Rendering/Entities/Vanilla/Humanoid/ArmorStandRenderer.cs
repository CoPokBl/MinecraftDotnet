using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Vec;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>ArmorStandRenderState</c>. Vanilla's <c>yRot</c>, <c>leftArmPose</c> and <c>rightArmPose</c> hide
/// the inherited fields of those names; they are renamed here so the humanoid model's reads of the
/// inherited ones stay as they are.
/// </summary>
public class ArmorStandRenderState : HumanoidRenderState {
    public float ArmorStandYRot;
    public float Wiggle;
    public bool IsMarker;
    public bool IsSmall;
    public bool ShowArms;
    public bool ShowBasePlate = true;
    public Vector3 HeadPose = new(0.0F, 0.0F, 0.0F);
    public Vector3 BodyPose = new(0.0F, 0.0F, 0.0F);
    public Vector3 LeftArmRotations = new(-10.0F, 0.0F, -10.0F);
    public Vector3 RightArmRotations = new(-15.0F, 0.0F, 10.0F);
    public Vector3 LeftLegPose = new(-1.0F, 0.0F, -1.0F);
    public Vector3 RightLegPose = new(1.0F, 0.0F, 1.0F);
}

/// <summary><c>ArmorStand.lastHit</c>, counted in the entity's own ticks rather than the level's game time; only the difference is read.</summary>
public sealed class ArmorStandEntityData : HumanoidEntityData {
    public long LastHit = long.MinValue / 2;
}

/// <summary><c>ArmorStandRenderer</c>.</summary>
public sealed class ArmorStandRenderer : LivingEntityRenderer<ArmorStandRenderState, ArmorStandArmorModel> {
    public const string DefaultSkinLocation = "minecraft:textures/entity/armorstand/armorstand.png";
    private readonly ArmorStandArmorModel _bigModel;
    private readonly ArmorStandArmorModel _smallModel;
    private readonly ItemRenderer _items;

    public ArmorStandRenderer(EntityRendererContext context) : base(new ArmorStandModel(ArmorStandModel.CreateBodyLayer().BakeRoot()), 0.0F) {
        _bigModel = Model;
        _items = context.Items;
        _smallModel = new ArmorStandModel(ArmorStandModel.CreateBodyLayer().Apply(HumanoidModel<ArmorStandRenderState>.BabyTransformer).BakeRoot());
        ArmorModelSet<LayerDefinition> armor = ArmorStandArmorModel.CreateArmorLayerSet(HumanoidLayers.InnerArmorDeformation, HumanoidLayers.OuterArmorDeformation);
        EquipmentLayerRenderer equipmentRenderer = EquipmentLayerRenderer.For(context);
        AddLayer(new HumanoidArmorLayer<ArmorStandRenderState, ArmorStandArmorModel, ArmorStandArmorModel>(this,
            ArmorModelSet.Bake(armor, root => new ArmorStandArmorModel(root)),
            ArmorModelSet.Bake(HumanoidLayers.Scaled(armor, HumanoidModel<ArmorStandRenderState>.BabyTransformer), root => new ArmorStandArmorModel(root)),
            equipmentRenderer));
        AddLayer(new ItemInHandLayer<ArmorStandRenderState, ArmorStandArmorModel>(this, context.Items));
        AddLayer(new WingsLayer<ArmorStandRenderState, ArmorStandArmorModel>(this, equipmentRenderer));
        AddLayer(new CustomHeadLayer<ArmorStandRenderState, ArmorStandArmorModel>(this, context.Items));
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<ArmorStandEntityData>(entity);

    /// <summary><c>ArmorStand.handleEntityEvent</c>: event 32 is a hit, which starts the wiggle.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        if (eventId == 32) {
            ArmorStandEntityData data = entity.RendererData as ArmorStandEntityData ?? new ArmorStandEntityData();
            entity.RendererData = data;
            data.LastHit = entity.TickCount;
        }
    }

    public override string GetTextureLocation(ArmorStandRenderState state) => DefaultSkinLocation;

    /// <summary>
    /// <c>ArmorStand.shouldRenderAtSqrDistance</c>: four times the usual distance, whatever the view scale, and a
    /// marker's empty box as a four block one. A small stand's box is half the size.
    /// </summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) {
        sbyte flags = entity.Get(EntityDataFields.ArmorStand.ClientFlags);
        double size = (flags & 16) != 0 ? 4.0 : BoxSize(entity) * ((flags & 1) != 0 ? 0.5 : 1.0) * 4.0;
        size *= 64.0;
        return distanceSqr < size * size;
    }

    protected override NameTagRule NameTagRule => NameTagRule.ArmorStand;

    public override void ExtractRenderState(ClientEntity entity, ArmorStandRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HumanoidMobRenderer.ExtractHumanoidRenderState(entity, state, partialTick, _items, context);
        // ArmorStand.tickHeadTurn: the body always faces the entity's yaw, rather than easing toward
        // where it walks as the client's generic body turn does.
        state.BodyRot = Mth.RotLerp(partialTick, entity.YRotO, entity.YRot);
        state.YRot = Mth.WrapDegrees(Mth.RotLerp(partialTick, entity.YHeadRotO, entity.YHeadRot) - state.BodyRot);
        int flags = entity.Get(EntityDataFields.ArmorStand.ClientFlags);
        state.ArmorStandYRot = Mth.RotLerp(partialTick, entity.YRotO, entity.YRot);
        state.IsMarker = (flags & 16) != 0;
        if (state.IsMarker) {
            // ArmorStand.getLightProbePosition: a marker's box has no size, so the probe is the block it stands in.
            LightAt(entity, state, (int)Math.Floor(entity.Position.X), (int)Math.Floor(entity.Position.Y), (int)Math.Floor(entity.Position.Z), context.Level);
        }
        state.IsSmall = (flags & 1) != 0;
        // ArmorStand.isBaby is isSmall.
        state.IsBaby = state.IsSmall;
        state.AgeScale = state.IsBaby ? 0.5F : 1.0F;
        state.ShowArms = (flags & 4) != 0;
        state.ShowBasePlate = (flags & 8) == 0;
        state.BodyPose = Pose(entity, EntityDataFields.ArmorStand.BodyPose, state.BodyPose);
        state.HeadPose = Pose(entity, EntityDataFields.ArmorStand.HeadPose, state.HeadPose);
        state.LeftArmRotations = Pose(entity, EntityDataFields.ArmorStand.LeftArmPose, state.LeftArmRotations);
        state.RightArmRotations = Pose(entity, EntityDataFields.ArmorStand.RightArmPose, state.RightArmRotations);
        state.LeftLegPose = Pose(entity, EntityDataFields.ArmorStand.LeftLegPose, state.LeftLegPose);
        state.RightLegPose = Pose(entity, EntityDataFields.ArmorStand.RightLegPose, state.RightLegPose);
        long lastHit = entity.RendererData is ArmorStandEntityData data ? data.LastHit : long.MinValue / 2;
        state.Wiggle = (float)(entity.TickCount - lastHit) + partialTick;
    }

    /// <summary>A synced <c>Rotations</c>, which its constructor wraps into (-360, 360) and zeroes when not finite.</summary>
    private static Vector3 Pose(ClientEntity entity, EntityDataField<Vec3<float>> field, Vector3 fallback) {
        if (!entity.Has(field)) {
            return fallback;
        }
        Vec3<float> value = entity.Get(field);
        static float Wrap(float v) => float.IsFinite(v) ? v % 360.0F : 0.0F;
        return new Vector3(Wrap(value.X), Wrap(value.Y), Wrap(value.Z));
    }

    public override void Submit(ArmorStandRenderState state, PoseStack pose, EntityRenderContext context) {
        Model = state.IsSmall ? _smallModel : _bigModel;
        base.Submit(state, pose, context);
    }

    /// <summary><c>getRenderType</c>: a marker's body is drawn with <c>entityCutout(texture, false)</c>.</summary>
    protected override bool BodyAffectsOutline(ArmorStandRenderState state) => !state.IsMarker;

    protected override void SetupRotations(ArmorStandRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        pose.RotateYDegrees(180.0F - bodyRot);
        if (state.Wiggle < 5.0F) {
            pose.RotateYDegrees(Mth.Sin(state.Wiggle / 1.5F * (float)Math.PI) * 3.0F);
        }
    }
}
