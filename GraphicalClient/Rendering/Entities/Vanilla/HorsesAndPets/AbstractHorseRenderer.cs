using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public abstract class AbstractHorseRenderer<S, M> : AgeableMobRenderer<S, M> where S : EquineRenderState, new() where M : EntityModel<S> {
    private const int FlagEating = 16;
    private const int FlagStanding = 32;
    private const int FlagOpenMouth = 64;

    protected AbstractHorseRenderer(M model, M babyModel) : base(model, babyModel, 0.75F) { }

    /// <summary>The donkey and mule draw no body armour, so only the horse and undead horse renderers add these.</summary>
    protected void AddBodyArmorAndSaddleLayers(EntityRendererContext context, EquipmentClientInfo.LayerType saddleLayer, MeshTransformer transformer) {
        EquipmentLayerRenderer equipment = EquipmentLayerRenderer.For(context);
        AddLayer(new SimpleEquipmentLayer<S, M, EquineRenderState>(this, equipment, EquipmentClientInfo.LayerType.HorseBody, state => state.BodyArmorItem,
            new HorseModel<EquineRenderState>(AbstractEquineModel<EquineRenderState>.CreateBodyLayer(new CubeDeformation(0.1F)).Apply(transformer).BakeRoot()), null));
        AddLayer(new SimpleEquipmentLayer<S, M, EquineRenderState>(this, equipment, saddleLayer, state => state.Saddle,
            new EquineSaddleModel(EquineSaddleModel.CreateSaddleLayer().Apply(transformer).BakeRoot()), null));
    }

    /// <summary>The animation fields <c>AbstractHorse</c> keeps on the client's entity.</summary>
    private sealed class HorseAnimation {
        public int TailCounter;
        public float EatAnim, EatAnimO, StandAnim, StandAnimO, MouthAnim, MouthAnimO;
    }

    private static bool GetFlag(ClientEntity entity, int flag) => (entity.Get(EntityDataFields.AbstractHorse.IdFlags) & flag) != 0;

    /// <summary>
    /// <c>AbstractHorse.aiStep</c>'s tail flick and <c>AbstractHorse.tick</c>'s animation easing. The mouth
    /// and stand counters are left out: only the server sets them, and the flags they clear arrive synced.
    /// </summary>
    public override void Tick(ClientEntity entity) {
        HorseAnimation anim = (HorseAnimation)(entity.RendererData ??= new HorseAnimation());
        // The 1 in 200 draw is not from the entity's own random, so a flick lands at a different tick than vanilla's would.
        if (Random.Shared.Next(200) == 0) {
            anim.TailCounter = 1;
        }
        if (anim.TailCounter > 0 && ++anim.TailCounter > 8) {
            anim.TailCounter = 0;
        }
        anim.EatAnimO = anim.EatAnim;
        if (GetFlag(entity, FlagEating)) {
            anim.EatAnim = anim.EatAnim + ((1.0F - anim.EatAnim) * 0.4F + 0.05F);
            if (anim.EatAnim > 1.0F) {
                anim.EatAnim = 1.0F;
            }
        }
        else {
            anim.EatAnim = anim.EatAnim + ((0.0F - anim.EatAnim) * 0.4F - 0.05F);
            if (anim.EatAnim < 0.0F) {
                anim.EatAnim = 0.0F;
            }
        }
        anim.StandAnimO = anim.StandAnim;
        if (GetFlag(entity, FlagStanding)) {
            anim.EatAnim = 0.0F;
            anim.EatAnimO = anim.EatAnim;
            anim.StandAnim = anim.StandAnim + ((1.0F - anim.StandAnim) * 0.4F + 0.05F);
            if (anim.StandAnim > 1.0F) {
                anim.StandAnim = 1.0F;
            }
        }
        else {
            anim.StandAnim = anim.StandAnim + ((0.8F * anim.StandAnim * anim.StandAnim * anim.StandAnim - anim.StandAnim) * 0.6F - 0.05F);
            if (anim.StandAnim < 0.0F) {
                anim.StandAnim = 0.0F;
            }
        }
        anim.MouthAnimO = anim.MouthAnim;
        if (GetFlag(entity, FlagOpenMouth)) {
            anim.MouthAnim = anim.MouthAnim + ((1.0F - anim.MouthAnim) * 0.7F + 0.05F);
            if (anim.MouthAnim > 1.0F) {
                anim.MouthAnim = 1.0F;
            }
        }
        else {
            anim.MouthAnim = anim.MouthAnim + ((0.0F - anim.MouthAnim) * 0.7F - 0.05F);
            if (anim.MouthAnim < 0.0F) {
                anim.MouthAnim = 0.0F;
            }
        }
    }

    public override void ExtractRenderState(ClientEntity entity, S state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // LivingEntityRenderer.extractRenderState's isInWater, which the shared extraction leaves unset and the equine legs read.
        state.IsInWater = EntityWater.IsInWater(context.Level, entity);
        state.Saddle = entity.GetItemBySlot(EquipmentSlot.Saddle);
        state.BodyArmorItem = entity.GetItemBySlot(EquipmentSlot.Body);
        state.IsRidden = entity.Passengers.Length > 0;
        if (entity.RendererData is HorseAnimation anim) {
            state.EatAnimation = Mth.Lerp(partialTick, anim.EatAnimO, anim.EatAnim);
            state.StandAnimation = Mth.Lerp(partialTick, anim.StandAnimO, anim.StandAnim);
            state.FeedingAnimation = Mth.Lerp(partialTick, anim.MouthAnimO, anim.MouthAnim);
            state.AnimateTail = anim.TailCounter > 0;
        }
    }
}
