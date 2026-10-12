using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Data.WolfVariant;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class WolfRenderer : AgeableMobRenderer<WolfRenderState, WolfModel> {
    public WolfRenderer(EntityRendererContext context) : base(
        new AdultWolfModel(AdultWolfModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()),
        new BabyWolfModel(BabyWolfModel.CreateBodyLayer().BakeRoot()), 0.5F) {
        AddLayer(new WolfArmorLayer(this, EquipmentLayerRenderer.For(context)));
        AddLayer(new WolfCollarLayer(this));
    }

    /// <summary>The fields <c>Wolf</c> keeps on the client's entity for its head tilt and shake.</summary>
    private sealed class WolfAnimation {
        public float InterestedAngle, InterestedAngleO;
        public bool IsWet, IsShaking;
        public float ShakeAnim, ShakeAnimO;
    }

    /// <summary>
    /// <c>Wolf.tick</c>'s client half. <c>isInWaterOrRain</c> is taken as in water only: whether rain
    /// reaches the wolf is not worked out, so a wolf wet only by rain stays dry and undarkened.
    /// </summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        WolfAnimation anim = (WolfAnimation)(entity.RendererData ??= new WolfAnimation());
        if (entity.CurrentHealth <= 0) {
            // Wolf.die.
            anim.IsWet = false;
            anim.IsShaking = false;
            anim.ShakeAnimO = 0.0F;
            anim.ShakeAnim = 0.0F;
            return;
        }
        anim.InterestedAngleO = anim.InterestedAngle;
        if (entity.Get(EntityDataFields.Wolf.Interested)) {
            anim.InterestedAngle = anim.InterestedAngle + (1.0F - anim.InterestedAngle) * 0.4F;
        }
        else {
            anim.InterestedAngle = anim.InterestedAngle + (0.0F - anim.InterestedAngle) * 0.4F;
        }
        if (EntityWater.IsInWater(level, entity)) {
            anim.IsWet = true;
        }
        else if ((anim.IsWet || anim.IsShaking) && anim.IsShaking) {
            anim.ShakeAnimO = anim.ShakeAnim;
            anim.ShakeAnim += 0.05F;
            if (anim.ShakeAnimO >= 2.0F) {
                anim.IsWet = false;
                anim.IsShaking = false;
                anim.ShakeAnimO = 0.0F;
                anim.ShakeAnim = 0.0F;
            }
        }
    }

    /// <summary><c>Wolf.handleEntityEvent</c>: 8 starts the shake, 56 cancels it.</summary>
    public override void HandleEntityEvent(ClientEntity entity, byte eventId) {
        WolfAnimation anim = (WolfAnimation)(entity.RendererData ??= new WolfAnimation());
        if (eventId == 8) {
            anim.IsShaking = true;
            anim.ShakeAnim = 0.0F;
            anim.ShakeAnimO = 0.0F;
        }
        else if (eventId == 56) {
            anim.IsShaking = false;
            anim.ShakeAnim = 0.0F;
            anim.ShakeAnimO = 0.0F;
        }
    }

    protected override uint GetModelTint(WolfRenderState state) {
        float wetShade = state.WetShade;
        if (wetShade == 1.0F) {
            return 0xFFFFFFFF;
        }
        uint channel = (uint)Mth.Floor(wetShade * 255.0F) & 0xFF;
        return 0xFF000000 | channel << 16 | channel << 8 | channel;
    }

    public override string GetTextureLocation(WolfRenderState state) => state.Texture;

    public override void ExtractRenderState(ClientEntity entity, WolfRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        bool isTame = (entity.Get(EntityDataFields.TamableAnimal.Flags) & 4) != 0;
        // NeutralMob.isAngry.
        long angerEndTime = entity.Get(EntityDataFields.Wolf.AngerEndTime);
        state.IsAngry = angerEndTime > 0L && angerEndTime - context.Level.GameTime > 0L;
        state.IsSitting = (entity.Get(EntityDataFields.TamableAnimal.Flags) & 1) != 0;
        state.TailAngle = GetTailAngle(entity, state.IsAngry, isTame);
        WolfAnimation? anim = entity.RendererData as WolfAnimation;
        state.HeadRollAngle = anim == null ? 0 : Mth.Lerp(partialTick, anim.InterestedAngleO, anim.InterestedAngle) * 0.15F * MathF.PI;
        state.ShakeAnim = anim == null ? 0 : Mth.Lerp(partialTick, anim.ShakeAnimO, anim.ShakeAnim);
        state.Texture = GetTexture(entity, context, state.IsBaby, isTame, state.IsAngry);
        state.WetShade = anim is not { IsWet: true }
            ? 1.0F
            : Math.Min(0.75F + Mth.Lerp(partialTick, anim.ShakeAnimO, anim.ShakeAnim) / 2.0F * 0.25F, 1.0F);
        state.CollarColor = isTame ? DyeById(entity.Get(EntityDataFields.Wolf.CollarColor, (int)DyeColor.Red)) : null;
        state.BodyArmorItem = entity.GetItemBySlot(EquipmentSlot.Body);
    }

    /// <summary><c>Wolf.getTailAngle</c>.</summary>
    private static float GetTailAngle(ClientEntity entity, bool isAngry, bool isTame) {
        if (isAngry) {
            return 1.5393804F;
        }
        if (isTame) {
            float maxHealth = (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.MaxHealth);
            float damageRatio = (maxHealth - entity.CurrentHealth) / maxHealth;
            return (0.55F - damageRatio * 0.4F) * MathF.PI;
        }
        return (float)(Math.PI / 5);
    }

    /// <summary><c>Wolf.getTexture</c>, through the variant registry the server sent.</summary>
    private static string GetTexture(ClientEntity entity, EntityRenderContext context, bool isBaby, bool isTame, bool isAngry) {
        IWolfVariant? variant = SyncedVariants.Resolve(context.Client.Registry.WolfVariants, entity, EntityDataFields.Wolf.Variant, "minecraft:pale");
        if (variant == null) {
            return WolfRenderState.DefaultTexture;
        }
        WolfAssetInfo assetInfo = isBaby ? variant.BabyAssets : variant.Assets;
        Identifier texture = isTame ? assetInfo.Tame : isAngry ? assetInfo.Angry : assetInfo.Wild;
        return SyncedVariants.TexturePath(texture);
    }

    /// <summary><c>DyeColor.byId</c>: out of range is white.</summary>
    private static DyeColor DyeById(int id) => id is >= 0 and < 16 ? (DyeColor)id : DyeColor.White;
}
