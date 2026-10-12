using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.CatVariant;
using Minecraft.Data.Generated;
using Minecraft.Schemas;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class CatRenderer : AgeableMobRenderer<CatRenderState, AbstractFelineModel<CatRenderState>> {
    public CatRenderer() : base(
        new AdultCatModel(AdultFelineModel<CatRenderState>.CreateBodyLayer(CubeDeformation.None).Apply(AdultCatModel.CatTransformer).BakeRoot()),
        new BabyCatModel(BabyFelineModel<CatRenderState>.CreateBabyLayer().BakeRoot()), 0.4F) {
        AddLayer(new CatCollarLayer(this));
    }

    /// <summary>The lie down and relax amounts <c>Cat</c> keeps on the client's entity.</summary>
    private sealed class CatAnimation {
        public float LieDownAmount, LieDownAmountO, LieDownAmountTail, LieDownAmountOTail;
        public float RelaxStateOneAmount, RelaxStateOneAmountO;
    }

    /// <summary><c>Cat.handleLieDown</c>'s <c>updateLieDownAmount</c> and <c>updateRelaxStateOneAmount</c>.</summary>
    public override void Tick(ClientEntity entity) {
        CatAnimation anim = (CatAnimation)(entity.RendererData ??= new CatAnimation());
        anim.LieDownAmountO = anim.LieDownAmount;
        anim.LieDownAmountOTail = anim.LieDownAmountTail;
        if (entity.Get(EntityDataFields.Cat.IsLying)) {
            anim.LieDownAmount = Math.Min(1.0F, anim.LieDownAmount + 0.15F);
            anim.LieDownAmountTail = Math.Min(1.0F, anim.LieDownAmountTail + 0.08F);
        }
        else {
            anim.LieDownAmount = Math.Max(0.0F, anim.LieDownAmount - 0.22F);
            anim.LieDownAmountTail = Math.Max(0.0F, anim.LieDownAmountTail - 0.13F);
        }
        anim.RelaxStateOneAmountO = anim.RelaxStateOneAmount;
        if (entity.Get(EntityDataFields.Cat.RelaxStateOne)) {
            anim.RelaxStateOneAmount = Math.Min(1.0F, anim.RelaxStateOneAmount + 0.1F);
        }
        else {
            anim.RelaxStateOneAmount = Math.Max(0.0F, anim.RelaxStateOneAmount - 0.13F);
        }
    }

    public override string GetTextureLocation(CatRenderState state) => state.Texture;

    public override void ExtractRenderState(ClientEntity entity, CatRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ICatVariant? variant = SyncedVariants.Resolve(context.Client.Registry.CatVariants, entity, EntityDataFields.Cat.Variant, "minecraft:black");
        state.Texture = variant == null ? CatRenderState.DefaultTexture : SyncedVariants.TexturePath(state.IsBaby ? variant.BabyAssetId : variant.AssetId);
        state.IsCrouching = OcelotRenderer.IsCrouching(entity);
        state.IsSprinting = OcelotRenderer.IsSprinting(entity);
        bool isTame = (entity.Get(EntityDataFields.TamableAnimal.Flags) & 4) != 0;
        state.IsSitting = (entity.Get(EntityDataFields.TamableAnimal.Flags) & 1) != 0;
        if (entity.RendererData is CatAnimation anim) {
            state.LieDownAmount = Mth.Lerp(partialTick, anim.LieDownAmountO, anim.LieDownAmount);
            state.LieDownAmountTail = Mth.Lerp(partialTick, anim.LieDownAmountOTail, anim.LieDownAmountTail);
            state.RelaxStateOneAmount = Mth.Lerp(partialTick, anim.RelaxStateOneAmountO, anim.RelaxStateOneAmount);
        }
        state.IsLyingOnTopOfSleepingPlayer = entity.Get(EntityDataFields.Cat.IsLying) && IsNearSleepingPlayer(entity, context);
        int collar = entity.Get(EntityDataFields.Cat.CollarColor, (int)DyeColor.Red);
        // DyeColor.byId: out of range is white.
        state.CollarColor = isTame ? collar is >= 0 and < 16 ? (DyeColor)collar : DyeColor.White : null;
    }

    /// <summary>
    /// <c>Cat.handleLieDown</c>'s search: a sleeping player whose box meets the cat's block grown by two.
    /// Vanilla works it out each tick; this works it out each frame, from the same synced data.
    /// </summary>
    private static bool IsNearSleepingPlayer(ClientEntity cat, EntityRenderContext context) {
        int bx = (int)Math.Floor(cat.Position.X), by = (int)Math.Floor(cat.Position.Y), bz = (int)Math.Floor(cat.Position.Z);
        foreach (ClientEntity player in context.Client.Entities.Values) {
            if (!player.Is(EntityClass.Player) || player.Get(EntityDataFields.LivingEntity.SleepingPos) is not { Present: true }) {
                continue;
            }
            // LivingEntity.SLEEPING_DIMENSIONS: a sleeping player's box is 0.2 square, whatever its scale.
            double x = player.Position.X, y = player.Position.Y, z = player.Position.Z;
            if (x + 0.1 > bx - 2 && x - 0.1 < bx + 3 && y + 0.2 > by - 2 && y < by + 3 && z + 0.1 > bz - 2 && z - 0.1 < bz + 3) {
                return true;
            }
        }
        return false;
    }

    protected override void SetupRotations(CatRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        float lieDownAmount = state.LieDownAmount;
        if (lieDownAmount > 0.0F) {
            pose.Translate(0.4F * lieDownAmount, 0.15F * lieDownAmount, 0.1F * lieDownAmount);
            pose.RotateZDegrees(Mth.RotLerp(lieDownAmount, 0.0F, 90.0F));
            if (state.IsLyingOnTopOfSleepingPlayer) {
                pose.Translate(0.15F * lieDownAmount, 0.0F, 0.0F);
            }
        }
    }
}
