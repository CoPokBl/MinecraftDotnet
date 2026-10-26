using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Schemas;
using Mth = GraphicalClient.Rendering.Entities.Mth;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class EndGatewayRenderState : BlockEntityRenderState {
    public int Height;
    public float Scale, AnimationTime;
    public uint Color;
}

/// <summary>
/// <c>TheEndGatewayRenderer</c>'s beam, up and down from a gateway that has just appeared or just sent
/// something through. Its faces are <see cref="EndPortalRenderer"/>'s.
/// </summary>
public sealed class EndGatewayBeamRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<EndGatewayBlockEntity, EndGatewayRenderState> {
    public static readonly SpriteId BeamLocation = Sheets.TextureSprite("minecraft:textures/entity/end_portal/end_gateway_beam.png");

    public override int ViewDistance => 256;

    public override void ExtractRenderState(EndGatewayBlockEntity blockEntity, EndGatewayRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        if (blockEntity.IsSpawning || blockEntity.IsCoolingDown) {
            state.Scale = blockEntity.IsSpawning ? blockEntity.SpawnPercent(partialTick) : blockEntity.CooldownPercent(partialTick);
            double beamDistance = blockEntity.IsSpawning ? render.Level.MaxY : 50.0;
            state.Scale = Mth.Sin(state.Scale * MathF.PI);
            state.Height = (int)Math.Floor(state.Scale * beamDistance);
            state.Color = BeaconBlockEntity.TextureDiffuseColor(blockEntity.IsSpawning ? DyeColor.Magenta : DyeColor.Purple);
            state.AnimationTime = (int)(((render.Level.GameTime % 40) + 40) % 40) + partialTick;
        }
        else {
            state.Height = 0;
        }
    }

    public override void Submit(EndGatewayRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.Height > 0 && BeaconRenderer.VisibleSpan(render, state, 0.175F) is (float visibleFrom, float visibleTo)) {
            BeaconRenderer.SubmitBeaconBeam(pose, render, context.Sprites, BeamLocation, state.Scale, state.AnimationTime, -state.Height, state.Height * 2,
                state.Color, 0.15F, 0.175F, visibleFrom, visibleTo);
        }
    }
}
