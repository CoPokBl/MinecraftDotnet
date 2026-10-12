using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EndCrystalRenderState</c>. Its <c>beamOffset</c> is left out with the beam.</summary>
public sealed class EndCrystalRenderState : EntityRenderState {
    public bool ShowsBottom = true;
}

/// <summary>
/// <c>EndCrystalRenderer</c>. The beam to its target is left out: it is a scrolling texture on a
/// custom tube, which the entity batch has no way to express.
/// </summary>
public sealed class EndCrystalRenderer : EntityRenderer<EndCrystalRenderState> {
    private const string EndCrystalLocation = "minecraft:textures/entity/end_crystal/end_crystal.png";

    private readonly EndCrystalModel _model;

    public EndCrystalRenderer(EntityRendererContext context) {
        ShadowRadius = 0.5F;
        _model = new EndCrystalModel(EndCrystalModel.CreateBodyLayer().BakeRoot());
    }

    /// <summary><c>EndCrystal.time</c>, which starts at random on each client.</summary>
    private sealed class CrystalTime {
        public int Time = Random.Shared.Next(100000);
    }

    /// <summary><c>EndCrystal.shouldRenderAtSqrDistance</c>: at any distance while it has a beam.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) =>
        WithinViewDistance(entity, distanceSqr) || entity.Get(EntityDataFields.EndCrystal.BeamTarget) is { Present: true };

    public override void Tick(ClientEntity entity) {
        CrystalTime time = (CrystalTime)(entity.RendererData ??= new CrystalTime());
        time.Time++;
    }

    public static float GetY(float timeInTicks) {
        float hh = Mth.Sin(timeInTicks * 0.2F) / 2.0F + 0.5F;
        hh = (hh * hh + hh) * 0.4F;
        return hh - 1.4F;
    }

    public override void ExtractRenderState(ClientEntity entity, EndCrystalRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        CrystalTime time = (CrystalTime)(entity.RendererData ??= new CrystalTime());
        state.AgeInTicks = time.Time + partialTick;
        state.ShowsBottom = entity.Get(EntityDataFields.EndCrystal.ShowBottom, true);
    }

    public override void Submit(EndCrystalRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Scale(2.0F, 2.0F, 2.0F);
        pose.Translate(0.0F, -0.5F, 0.0F);
        _model.SetupAnim(state);
        EntityTexture texture = context.Textures.Get(EndCrystalLocation) ?? context.Textures.Missing;
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        pose.Pop();
    }
}
