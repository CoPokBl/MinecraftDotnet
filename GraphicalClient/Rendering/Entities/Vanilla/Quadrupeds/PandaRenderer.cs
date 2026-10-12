using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>Panda.Gene</c>.</summary>
public enum PandaGene { Normal = 0, Lazy = 1, Worried = 2, Playful = 3, Brown = 4, Weak = 5, Aggressive = 6 }

public class PandaRenderState : HoldingEntityRenderState {
    public PandaGene Variant = PandaGene.Normal;
    public bool IsUnhappy;
    public bool IsSneezing;
    public int SneezeTime;
    public bool IsEating;
    public bool IsScared;
    public bool IsSitting;
    public float SitAmount;
    public float LieOnBackAmount;
    public float RollAmount;
    public float RollTime;
}

public sealed class PandaRenderer : AgeableMobRenderer<PandaRenderState, PandaModel> {
    private static readonly Dictionary<PandaGene, (string Adult, string Baby)> Textures = new() {
        [PandaGene.Normal] = ("minecraft:textures/entity/panda/panda.png", "minecraft:textures/entity/panda/panda_baby.png"),
        [PandaGene.Lazy] = ("minecraft:textures/entity/panda/panda_lazy.png", "minecraft:textures/entity/panda/lazy_panda_baby.png"),
        [PandaGene.Worried] = ("minecraft:textures/entity/panda/panda_worried.png", "minecraft:textures/entity/panda/worried_panda_baby.png"),
        [PandaGene.Playful] = ("minecraft:textures/entity/panda/panda_playful.png", "minecraft:textures/entity/panda/playful_panda_baby.png"),
        [PandaGene.Brown] = ("minecraft:textures/entity/panda/panda_brown.png", "minecraft:textures/entity/panda/brown_panda_baby.png"),
        [PandaGene.Weak] = ("minecraft:textures/entity/panda/panda_weak.png", "minecraft:textures/entity/panda/weak_panda_baby.png"),
        [PandaGene.Aggressive] = ("minecraft:textures/entity/panda/panda_aggressive.png", "minecraft:textures/entity/panda/aggressive_panda_baby.png")
    };

    private readonly ItemRenderer _items;

    public PandaRenderer(EntityRendererContext context)
        : base(new PandaModel(PandaModel.CreateBodyLayer().BakeRoot()), new BabyPandaModel(BabyPandaModel.CreateBodyLayer().BakeRoot()), 0.9F) {
        _items = context.Items;
        AddLayer(new PandaHoldsItemLayer(this, context.Items));
    }

    /// <summary>What <c>Panda.tick</c> keeps on the client: the roll count and the eased sit, lie and roll amounts.</summary>
    private sealed class PandaAnimation {
        public int RollCounter;
        public float SitAmount, SitAmountO, OnBackAmount, OnBackAmountO, RollAmount, RollAmountO;
    }

    private static bool GetFlag(ClientEntity entity, int flag) => (entity.Get(EntityDataFields.Panda.IdFlags) & flag) != 0;

    /// <summary><c>Panda.Gene.byId</c>: an id out of range is the first, normal.</summary>
    private static PandaGene GeneById(int id) => id is >= 0 and <= 6 ? (PandaGene)id : PandaGene.Normal;

    /// <summary><c>Panda.getVariant</c>: brown and weak are recessive, and show only when both genes carry them.</summary>
    private static PandaGene GetVariant(ClientEntity entity) {
        PandaGene mainGene = GeneById(entity.Get(EntityDataFields.Panda.MainGene));
        PandaGene hiddenGene = GeneById(entity.Get(EntityDataFields.Panda.HiddenGene));
        if (mainGene is PandaGene.Brown or PandaGene.Weak) {
            return mainGene == hiddenGene ? mainGene : PandaGene.Normal;
        }
        return mainGene;
    }

    /// <summary><c>Panda.isScared</c>: a worried panda during a thunderstorm.</summary>
    private static bool IsScared(ClientEntity entity, ClientLevel level) => GetVariant(entity) == PandaGene.Worried && IsThundering(level);

    /// <summary><c>Level.isThundering</c>.</summary>
    private static bool IsThundering(ClientLevel level) {
        // getThunderLevel: the thunder level times the rain level.
        return level.CanHaveWeather && level.ThunderLevel * level.RainLevel > 0.9;
    }

    /// <summary>
    /// <c>Panda.tick</c>'s client side bookkeeping. The sneeze, unhappy and eat counters vanilla's client
    /// also advances are read as the server last sent them instead.
    /// </summary>
    public override void Tick(ClientEntity entity, ClientLevel level) {
        PandaAnimation panda = (PandaAnimation)(entity.RendererData ??= new PandaAnimation());
        // handleRoll: past 32 the client clears its own rolling flag, which stops the count the same way.
        if (GetFlag(entity, 4) && panda.RollCounter <= 32) {
            panda.RollCounter++;
        }
        else {
            panda.RollCounter = 0;
        }
        panda.SitAmountO = panda.SitAmount;
        panda.SitAmount = GetFlag(entity, 8) ? Math.Min(1.0F, panda.SitAmount + 0.15F) : Math.Max(0.0F, panda.SitAmount - 0.19F);
        panda.OnBackAmountO = panda.OnBackAmount;
        panda.OnBackAmount = GetFlag(entity, 16) ? Math.Min(1.0F, panda.OnBackAmount + 0.15F) : Math.Max(0.0F, panda.OnBackAmount - 0.19F);
        panda.RollAmountO = panda.RollAmount;
        panda.RollAmount = GetFlag(entity, 4) && panda.RollCounter <= 32 ? Math.Min(1.0F, panda.RollAmount + 0.15F) : Math.Max(0.0F, panda.RollAmount - 0.19F);
    }

    public override string GetTextureLocation(PandaRenderState state) => state.IsBaby ? Textures[state.Variant].Baby : Textures[state.Variant].Adult;

    public override void ExtractRenderState(ClientEntity entity, PandaRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HoldingEntityRenderState.ExtractHoldingEntityRenderState(entity, state, _items);
        PandaAnimation panda = entity.RendererData as PandaAnimation ?? new PandaAnimation();
        state.Variant = GetVariant(entity);
        state.IsUnhappy = entity.Get(EntityDataFields.Panda.UnhappyCounter) > 0;
        state.IsSneezing = GetFlag(entity, 2);
        state.SneezeTime = entity.Get(EntityDataFields.Panda.SneezeCounter);
        state.IsEating = entity.Get(EntityDataFields.Panda.EatCounter) > 0;
        state.IsScared = IsScared(entity, context.Level);
        state.IsSitting = GetFlag(entity, 8);
        state.SitAmount = Mth.Lerp(partialTick, panda.SitAmountO, panda.SitAmount);
        state.LieOnBackAmount = Mth.Lerp(partialTick, panda.OnBackAmountO, panda.OnBackAmount);
        state.RollAmount = entity.IsBaby ? 0.0F : Mth.Lerp(partialTick, panda.RollAmountO, panda.RollAmount);
        state.RollTime = panda.RollCounter > 0 ? panda.RollCounter + partialTick : 0.0F;
    }

    protected override void SetupRotations(PandaRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot, entityScale);
        if (state.RollTime > 0.0F) {
            float rollTransitionTime = Mth.Frac(state.RollTime);
            int rollPos = Mth.Floor(state.RollTime);
            int nextRollPos = rollPos + 1;
            float y = state.IsBaby ? 0.3F : 0.8F;
            if (rollPos < 8.0F) {
                float thisAngle = 90.0F * rollPos / 7.0F;
                float nextAngle = 90.0F * nextRollPos / 7.0F;
                float angle = GetAngle(thisAngle, nextAngle, nextRollPos, rollTransitionTime, 8.0F);
                pose.Translate(0.0F, (y + 0.2F) * (angle / 90.0F), 0.0F);
                pose.RotateXDegrees(-angle);
            }
            else if (rollPos < 16.0F) {
                float internalRollCounter = (rollPos - 8.0F) / 7.0F;
                float thisAngle = 90.0F + 90.0F * internalRollCounter;
                float nextAngle = 90.0F + 90.0F * (nextRollPos - 8.0F) / 7.0F;
                float angle = GetAngle(thisAngle, nextAngle, nextRollPos, rollTransitionTime, 16.0F);
                pose.Translate(0.0F, y + 0.2F + (y - 0.2F) * (angle - 90.0F) / 90.0F, 0.0F);
                pose.RotateXDegrees(-angle);
            }
            else if (rollPos < 24.0F) {
                float internalRollCounter = (rollPos - 16.0F) / 7.0F;
                float thisAngle = 180.0F + 90.0F * internalRollCounter;
                float nextAngle = 180.0F + 90.0F * (nextRollPos - 16.0F) / 7.0F;
                float angle = GetAngle(thisAngle, nextAngle, nextRollPos, rollTransitionTime, 24.0F);
                pose.Translate(0.0F, y + y * (270.0F - angle) / 90.0F, 0.0F);
                pose.RotateXDegrees(-angle);
            }
            else if (rollPos < 32) {
                float internalRollCounter = (rollPos - 24.0F) / 7.0F;
                float thisAngle = 270.0F + 90.0F * internalRollCounter;
                float nextAngle = 270.0F + 90.0F * (nextRollPos - 24.0F) / 7.0F;
                float angle = GetAngle(thisAngle, nextAngle, nextRollPos, rollTransitionTime, 32.0F);
                pose.Translate(0.0F, y * ((360.0F - angle) / 90.0F), 0.0F);
                pose.RotateXDegrees(-angle);
            }
        }
        float sitAmount = state.SitAmount;
        if (sitAmount > 0.0F) {
            pose.Translate(0.0F, 0.8F * sitAmount, 0.0F);
            pose.RotateXDegrees(Mth.Lerp(sitAmount, state.XRot, state.XRot + 90.0F));
            pose.Translate(0.0F, -1.0F * sitAmount, 0.0F);
            if (state.IsScared) {
                float shakeRot = (float)(Math.Cos(state.AgeInTicks * 1.25F) * Math.PI * 0.05F);
                pose.RotateYDegrees(shakeRot);
                if (state.IsBaby) {
                    pose.Translate(0.0F, 0.8F, 0.55F);
                }
            }
        }
        float lieOnBackAmount = state.LieOnBackAmount;
        if (lieOnBackAmount > 0.0F) {
            float y = state.IsBaby ? 0.5F : 1.3F;
            pose.Translate(0.0F, y * lieOnBackAmount, 0.0F);
            pose.RotateXDegrees(Mth.Lerp(lieOnBackAmount, state.XRot, state.XRot + 180.0F));
        }
    }

    private static float GetAngle(float thisAngle, float nextAngle, int nextRollPos, float rollTransitionTime, float threshold) =>
        nextRollPos < threshold ? Mth.Lerp(rollTransitionTime, thisAngle, nextAngle) : thisAngle;
}
