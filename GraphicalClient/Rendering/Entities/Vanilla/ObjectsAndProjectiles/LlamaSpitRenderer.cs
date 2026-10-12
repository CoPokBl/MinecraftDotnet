using ClientLib.Entities;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>LlamaSpitRenderState</c>.</summary>
public class LlamaSpitRenderState : EntityRenderState {
    public float XRot;
    public float YRot;
}

/// <summary><c>LlamaSpitRenderer</c>.</summary>
public sealed class LlamaSpitRenderer : EntityRenderer<LlamaSpitRenderState> {
    private const string LlamaSpitLocation = "minecraft:textures/entity/llama/llama_spit.png";

    private readonly LlamaSpitModel _model = new(LlamaSpitModel.CreateBodyLayer().BakeRoot());

    public override void Submit(LlamaSpitRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.Translate(0.0F, 0.15F, 0.0F);
        pose.RotateYDegrees(state.YRot - 90.0F);
        pose.RotateZDegrees(state.XRot);
        _model.SetupAnim(state);
        _model.RenderToBuffer(pose, context.Batch, new ModelDrawState(context.Texture(LlamaSpitLocation), state));
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, LlamaSpitRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.XRot = GetXRot(entity, partialTick);
        state.YRot = GetYRot(entity, partialTick);
    }
}

/// <summary><c>LlamaSpitModel</c>.</summary>
public sealed class LlamaSpitModel : EntityModel<EntityRenderState> {
    public LlamaSpitModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild(
            "main",
            CubeListBuilder.Create()
                .TexOffs(0, 0)
                .AddBox(-4.0F, 0.0F, 0.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(0.0F, -4.0F, 0.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(0.0F, 0.0F, -4.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(0.0F, 0.0F, 0.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(2.0F, 0.0F, 0.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(0.0F, 2.0F, 0.0F, 2.0F, 2.0F, 2.0F)
                .AddBox(0.0F, 0.0F, 2.0F, 2.0F, 2.0F, 2.0F),
            PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }
}
