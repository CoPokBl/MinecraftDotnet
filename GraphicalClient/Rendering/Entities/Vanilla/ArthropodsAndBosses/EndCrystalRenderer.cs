using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EndCrystalRenderState</c>.</summary>
public sealed class EndCrystalRenderState : EntityRenderState {
    public bool ShowsBottom = true;
    public ClientLib.Maths.Vec3d? BeamOffset;
}

/// <summary><c>EndCrystalRenderer</c>.</summary>
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

    /// <summary><c>shouldRender</c>: wherever it is while it has a beam.</summary>
    public override bool ShouldRenderOutOfView(ClientEntity entity, Frustum frustum, EntityRenderContext context) =>
        entity.Get(EntityDataFields.EndCrystal.BeamTarget) is { Present: true };

    /// <summary><c>EndCrystal.time</c> plus the partial tick, which the bob and the beam's scroll both read.</summary>
    public static float Time(ClientEntity entity, float partialTick) => ((CrystalTime)(entity.RendererData ??= new CrystalTime())).Time + partialTick;

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
        state.AgeInTicks = Time(entity, partialTick);
        state.ShowsBottom = entity.Get(EntityDataFields.EndCrystal.ShowBottom, true);
        if (entity.Get(EntityDataFields.EndCrystal.BeamTarget) is { Present: true } target) {
            ClientLib.Maths.Vec3d position = ClientLib.Entities.Leashes.Position(entity, partialTick);
            Minecraft.Schemas.Vec.Vec3<int> block = target.Value;
            state.BeamOffset = new ClientLib.Maths.Vec3d(block.X + 0.5 - position.X, block.Y + 0.5 - position.Y, block.Z + 0.5 - position.Z);
        }
        else {
            state.BeamOffset = null;
        }
    }

    public override void Submit(EndCrystalRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Scale(2.0F, 2.0F, 2.0F);
        pose.Translate(0.0F, -0.5F, 0.0F);
        _model.SetupAnim(state);
        EntityTexture texture = context.Textures.Get(EndCrystalLocation) ?? context.Textures.Missing;
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(texture, 0xFFFFFFFF, state.SkyLight, state.BlockLight, 0));
        pose.Pop();
        if (state.BeamOffset is { } beamOffset) {
            float crystalY = GetY(state.AgeInTicks);
            float deltaX = (float)beamOffset.X, deltaY = (float)beamOffset.Y, deltaZ = (float)beamOffset.Z;
            pose.Translate((float)beamOffset.X, (float)beamOffset.Y, (float)beamOffset.Z);
            EnderDragonRenderer.SubmitCrystalBeams(-deltaX, -deltaY + crystalY, -deltaZ, state.AgeInTicks, pose, context, state.SkyLight, state.BlockLight);
        }
    }
}
