namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BoatRenderer</c>.</summary>
public sealed class BoatRenderer(string modelId, bool chest)
    : AbstractBoatRenderer(modelId, new BoatModel((chest ? BoatModel.CreateChestBoatModel() : BoatModel.CreateBoatModel()).BakeRoot())) {
    private readonly ModelPart _waterPatchModel = BoatModel.CreateWaterPatch().BakeRoot();

    /// <summary>The patch goes to <c>waterMask</c>, which writes depth and no colour, so the water drawn after it is hidden inside the hull.</summary>
    protected override void SubmitTypeAdditions(BoatRenderState state, PoseStack pose, EntityRenderContext context) {
        if (!state.IsUnderWater && context.WaterMaskBatch is { } waterMask) {
            _waterPatchModel.Render(pose, waterMask, new ModelDrawState(context.Textures.White, state));
        }
    }
}

/// <summary><c>RaftRenderer</c>.</summary>
public sealed class RaftRenderer(string modelId, bool chest)
    : AbstractBoatRenderer(modelId, new RaftModel((chest ? RaftModel.CreateChestRaftModel() : RaftModel.CreateRaftModel()).BakeRoot()));
