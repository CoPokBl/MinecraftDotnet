using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>WardenRenderState</c>. The animation states are the entity's own, shared rather than copied.</summary>
public sealed class WardenRenderState : LivingEntityRenderState {
    public float TendrilAnimation, HeartAnimation;
    public AnimationState RoarAnimationState = new();
    public AnimationState SniffAnimationState = new();
    public AnimationState EmergeAnimationState = new();
    public AnimationState DiggingAnimationState = new();
    public AnimationState AttackAnimationState = new();
    public AnimationState SonicBoomAnimationState = new();
}

public sealed class WardenRenderer : MobRenderer<WardenRenderState, WardenModel> {
    private const string Texture = "minecraft:textures/entity/warden/warden.png";

    // Warden's AngerLevel.ANGRY minimum anger.
    private const int AngryMinimumAnger = 80;

    public WardenRenderer(EntityRendererContext context) : base(new WardenModel(WardenModel.CreateBodyLayer().BakeRoot()), 0.9F) {
        WardenModel pulsatingSpotsModel = new(WardenModel.CreatePulsatingSpotsLayer().BakeRoot());
        Emissive("minecraft:textures/entity/warden/warden_bioluminescent_layer.png", (_, _) => 1.0F, new(WardenModel.CreateBioluminescentLayer().BakeRoot()));
        Emissive("minecraft:textures/entity/warden/warden_pulsating_spots_1.png", (_, ageInTicks) => Math.Max(0.0F, Mth.Cos(ageInTicks * 0.045F) * 0.25F),
            pulsatingSpotsModel);
        Emissive("minecraft:textures/entity/warden/warden_pulsating_spots_2.png",
            (_, ageInTicks) => Math.Max(0.0F, Mth.Cos(ageInTicks * 0.045F + (float)Math.PI) * 0.25F), pulsatingSpotsModel);
        Emissive(Texture, (warden, _) => warden.TendrilAnimation, new(WardenModel.CreateTendrilsLayer().BakeRoot()));
        Emissive("minecraft:textures/entity/warden/warden_heart.png", (warden, _) => warden.HeartAnimation, new(WardenModel.CreateHeartLayer().BakeRoot()));
    }

    /// <summary>Every layer is <c>entityTranslucentEmissive</c>, which the translucent batch stands in for.</summary>
    private void Emissive(string texture, LivingEntityEmissiveLayer<WardenRenderState, WardenModel>.AlphaFunction alpha, WardenModel model) =>
        AddLayer(new LivingEntityEmissiveLayer<WardenRenderState, WardenModel>(this, _ => texture, alpha, model, true, false));

    /// <summary>What <c>Warden</c> keeps on the client: its animation states and the tendril and heart counters.</summary>
    private sealed class WardenData {
        public readonly AnimationState RoarAnimationState = new();
        public readonly AnimationState SniffAnimationState = new();
        public readonly AnimationState EmergeAnimationState = new();
        public readonly AnimationState DiggingAnimationState = new();
        public readonly AnimationState AttackAnimationState = new();
        public readonly AnimationState SonicBoomAnimationState = new();
        public int TendrilAnimation, TendrilAnimationO, HeartAnimation, HeartAnimationO;
        public EntityPose? SeenPose;
    }

    private static WardenData DataOf(ClientEntity entity) => (WardenData)(entity.RendererData ??= new WardenData());

    /// <summary>
    /// <c>Warden.onSyncedDataUpdated</c> for <c>DATA_POSE</c>, noticed rather than told: a frame sees
    /// it at the tick count it arrived in, and a tick that sees it first knows it came a tick earlier.
    /// </summary>
    private static void NoticePose(ClientEntity entity, WardenData data, int arrivedTick) {
        EntityPose pose = entity.Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
        if (data.SeenPose == pose) {
            return;
        }
        // An entity's first look is its spawn metadata, which vanilla also passes through onSyncedDataUpdated.
        data.SeenPose = pose;
        switch (pose) {
            case EntityPose.Emerging:
                data.EmergeAnimationState.Start(arrivedTick);
                break;
            case EntityPose.Digging:
                data.DiggingAnimationState.Start(arrivedTick);
                break;
            case EntityPose.Roaring:
                data.RoarAnimationState.Start(arrivedTick);
                break;
            case EntityPose.Sniffing:
                data.SniffAnimationState.Start(arrivedTick);
                break;
        }
    }

    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        WardenData data = DataOf(entity);
        if (eventId == 4) {
            data.RoarAnimationState.Stop();
            data.AttackAnimationState.Start(entity.TickCount);
        }
        else if (eventId == 61) {
            data.TendrilAnimation = 10;
        }
        else if (eventId == 62) {
            data.SonicBoomAnimationState.Start(entity.TickCount);
        }
    }

    /// <summary><c>Warden.tick</c>'s client half. The heartbeat sound and digging particles are not this renderer's.</summary>
    public override void Tick(ClientEntity entity) {
        WardenData data = DataOf(entity);
        NoticePose(entity, data, entity.TickCount - 1);
        if (entity.TickCount % GetHeartBeatDelay(entity) == 0) {
            data.HeartAnimation = 10;
        }
        data.TendrilAnimationO = data.TendrilAnimation;
        if (data.TendrilAnimation > 0) {
            data.TendrilAnimation--;
        }
        data.HeartAnimationO = data.HeartAnimation;
        if (data.HeartAnimation > 0) {
            data.HeartAnimation--;
        }
    }

    /// <summary><c>Warden.getHeartBeatDelay</c>.</summary>
    private static int GetHeartBeatDelay(ClientEntity entity) {
        float anger = (float)entity.Get(EntityDataFields.Warden.ClientAngerLevel) / AngryMinimumAnger;
        return 40 - Mth.Floor(Mth.Clamp(anger, 0.0F, 1.0F) * 30.0F);
    }

    public override string GetTextureLocation(WardenRenderState state) => Texture;

    public override void ExtractRenderState(ClientEntity entity, WardenRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        WardenData data = DataOf(entity);
        NoticePose(entity, data, entity.TickCount);
        state.TendrilAnimation = Mth.Lerp(partialTick, data.TendrilAnimationO, data.TendrilAnimation) / 10.0F;
        state.HeartAnimation = Mth.Lerp(partialTick, data.HeartAnimationO, data.HeartAnimation) / 10.0F;
        state.RoarAnimationState = data.RoarAnimationState;
        state.SniffAnimationState = data.SniffAnimationState;
        state.EmergeAnimationState = data.EmergeAnimationState;
        state.DiggingAnimationState = data.DiggingAnimationState;
        state.AttackAnimationState = data.AttackAnimationState;
        state.SonicBoomAnimationState = data.SonicBoomAnimationState;
    }
}
