using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class FoxRenderer : AgeableMobRenderer<FoxRenderState, FoxModel> {
    private const int FlagSitting = 1;
    private const int FlagCrouching = 4;
    private const int FlagInterested = 8;
    private const int FlagPouncing = 16;
    private const int FlagSleeping = 32;
    private const int FlagFaceplanted = 64;

    private static readonly Dictionary<FoxVariant, (string Adult, string Baby, string SleepingAdult, string SleepingBaby)> Textures = new() {
        [FoxVariant.Red] = ("minecraft:textures/entity/fox/fox.png", "minecraft:textures/entity/fox/fox_baby.png",
            "minecraft:textures/entity/fox/fox_sleep.png", "minecraft:textures/entity/fox/fox_sleep_baby.png"),
        [FoxVariant.Snow] = ("minecraft:textures/entity/fox/fox_snow.png", "minecraft:textures/entity/fox/fox_snow_baby.png",
            "minecraft:textures/entity/fox/fox_snow_sleep.png", "minecraft:textures/entity/fox/fox_snow_sleep_baby.png")
    };

    private readonly ItemRenderer _items;

    public FoxRenderer(EntityRendererContext context) : base(
        new AdultFoxModel(AdultFoxModel.CreateBodyLayer().BakeRoot()),
        new BabyFoxModel(BabyFoxModel.CreateBodyLayer().BakeRoot()), 0.4F) {
        _items = context.Items;
        AddLayer(new FoxHeldItemLayer(this, context.Items));
    }

    /// <summary>The head tilt and crouch <c>Fox</c> keeps on the client's entity.</summary>
    private sealed class FoxAnimation {
        public float InterestedAngle, InterestedAngleO, CrouchAmount, CrouchAmountO;
    }

    private static bool GetFlag(ClientEntity entity, int flag) => (entity.Get(EntityDataFields.Fox.Flags) & flag) != 0;

    /// <summary><c>Fox.tick</c>'s client half.</summary>
    public override void Tick(ClientEntity entity) {
        FoxAnimation anim = (FoxAnimation)(entity.RendererData ??= new FoxAnimation());
        anim.InterestedAngleO = anim.InterestedAngle;
        if (GetFlag(entity, FlagInterested)) {
            anim.InterestedAngle = anim.InterestedAngle + (1.0F - anim.InterestedAngle) * 0.4F;
        }
        else {
            anim.InterestedAngle = anim.InterestedAngle + (0.0F - anim.InterestedAngle) * 0.4F;
        }
        anim.CrouchAmountO = anim.CrouchAmount;
        if (GetFlag(entity, FlagCrouching)) {
            anim.CrouchAmount += 0.2F;
            if (anim.CrouchAmount > 5.0F) {
                anim.CrouchAmount = 5.0F;
            }
        }
        else {
            anim.CrouchAmount = 0.0F;
        }
    }

    protected override void SetupRotations(FoxRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        if (state.IsPouncing || state.IsFaceplanted) {
            pose.RotateXDegrees(-state.XRot);
        }
    }

    public override string GetTextureLocation(FoxRenderState state) {
        if (!Textures.TryGetValue(state.Variant, out var textures)) {
            return "minecraft:textures/entity/fox/fox.png";
        }
        return state.IsSleeping ? state.IsBaby ? textures.SleepingBaby : textures.SleepingAdult : state.IsBaby ? textures.Baby : textures.Adult;
    }

    public override void ExtractRenderState(ClientEntity entity, FoxRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        FoxAnimation? anim = entity.RendererData as FoxAnimation;
        state.HeadRollAngle = anim == null ? 0 : Mth.Lerp(partialTick, anim.InterestedAngleO, anim.InterestedAngle) * 0.11F * MathF.PI;
        state.IsCrouching = GetFlag(entity, FlagCrouching);
        state.CrouchAmount = anim == null ? 0 : Mth.Lerp(partialTick, anim.CrouchAmountO, anim.CrouchAmount);
        state.IsSleeping = GetFlag(entity, FlagSleeping);
        state.IsSitting = GetFlag(entity, FlagSitting);
        state.IsFaceplanted = GetFlag(entity, FlagFaceplanted);
        state.IsPouncing = GetFlag(entity, FlagPouncing);
        // Fox.Variant.byId: out of range is the first.
        int variant = entity.Get(EntityDataFields.Fox.Type);
        state.Variant = variant is >= 0 and <= 1 ? (FoxVariant)variant : FoxVariant.Red;
    }
}
