using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>CreeperRenderState</c>.</summary>
public class CreeperRenderState : LivingEntityRenderState {
    public float Swelling;
    public bool IsPowered;
}

/// <summary>
/// <c>CreeperRenderer</c>. The charged creeper's <c>CreeperPowerLayer</c> is not drawn: its energy swirl
/// is an additive, scrolling, repeating texture, which a deferred entity pass sampling an atlas has no
/// way to express.
/// </summary>
public sealed class CreeperRenderer : MobRenderer<CreeperRenderState, CreeperModel> {
    private const string CreeperLocation = "minecraft:textures/entity/creeper/creeper.png";

    public CreeperRenderer(EntityRendererContext context)
        : base(new CreeperModel(CreeperModel.CreateBodyLayer(CubeDeformation.None).BakeRoot()), 0.5F) { }

    /// <summary><c>Creeper.swell</c> and <c>oldSwell</c>, which the client counts itself from the synced direction.</summary>
    private sealed class Swell {
        // Creeper.maxSwell: the Fuse tag, which is never sent, so the client always counts to the default.
        public const int MaxSwell = 30;
        public int Current, Old;
    }

    /// <summary><c>Creeper.tick</c>'s swell count.</summary>
    public override void Tick(ClientEntity entity) {
        if (entity.CurrentHealth <= 0) {
            return;
        }
        Swell swell = (Swell)(entity.RendererData ??= new Swell());
        swell.Old = swell.Current;
        int swellDir = entity.Get(EntityDataFields.Creeper.IsIgnited) ? 1 : entity.Get(EntityDataFields.Creeper.SwellDir, -1);
        swell.Current += swellDir;
        if (swell.Current < 0) {
            swell.Current = 0;
        }
        if (swell.Current >= Swell.MaxSwell) {
            swell.Current = Swell.MaxSwell;
        }
    }

    protected override void Scale(CreeperRenderState state, PoseStack pose) {
        float g = state.Swelling;
        float wobble = 1.0F + Mth.Sin(g * 100.0F) * g * 0.01F;
        g = Mth.Clamp(g, 0.0F, 1.0F);
        g *= g;
        g *= g;
        float s = (1.0F + g * 0.4F) * wobble;
        float hs = (1.0F + g * 0.1F) / wobble;
        pose.Scale(s, hs, s);
    }

    protected override float GetWhiteOverlayProgress(CreeperRenderState state) {
        float step = state.Swelling;
        return (int)(step * 10.0F) % 2 == 0 ? 0.0F : Mth.Clamp(step, 0.5F, 1.0F);
    }

    public override string GetTextureLocation(CreeperRenderState state) => CreeperLocation;

    public override void ExtractRenderState(ClientEntity entity, CreeperRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        // Creeper.getSwelling.
        state.Swelling = entity.RendererData is Swell swell ? Mth.Lerp(partialTick, swell.Old, swell.Current) / (Swell.MaxSwell - 2) : 0;
        state.IsPowered = entity.Get(EntityDataFields.Creeper.IsPowered);
    }
}
