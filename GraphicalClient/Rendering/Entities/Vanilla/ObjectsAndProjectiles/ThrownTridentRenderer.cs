using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>ThrownTridentRenderState</c>.</summary>
public class ThrownTridentRenderState : EntityRenderState {
    public float XRot;
    public float YRot;
    public bool IsFoil;
}

/// <summary><c>ThrownTridentRenderer</c>.</summary>
public sealed class ThrownTridentRenderer : EntityRenderer<ThrownTridentRenderState> {
    private readonly TridentModel _model = new(TridentModel.CreateLayer().BakeRoot());

    /// <summary><c>AbstractArrow.shouldRenderAtSqrDistance</c>.</summary>
    public override bool? ShouldRenderAtSqrDistance(ClientEntity entity, double distanceSqr) => WithinViewDistance(entity, distanceSqr, 10.0);

    public override (Vector3 Min, Vector3 Max)? BoundingBoxForCulling(ClientEntity entity) {
        float half = (float)entity.Width / 2;
        // inflate(1.5).
        return (new Vector3(-half - 1.5F, -1.5F, -half - 1.5F), new Vector3(half + 1.5F, (float)entity.Height + 1.5F, half + 1.5F));
    }

    public override void Submit(ThrownTridentRenderState state, PoseStack pose, EntityRenderContext context) {
        pose.Push();
        pose.RotateYDegrees(state.YRot - 90.0F);
        pose.RotateZDegrees(state.XRot + 90.0F);
        _model.SetupAnim(state);
        ModelDrawState draw = new(context.Texture(TridentModel.Texture), state);
        _model.RenderToBuffer(pose, context.Batch, draw);
        if (state.IsFoil) {
            _model.RenderToBuffer(pose, new GlintSink(context.Batch, GlintType.Entity), draw);
        }
        pose.Pop();
    }

    public override void ExtractRenderState(ClientEntity entity, ThrownTridentRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.YRot = GetYRot(entity, partialTick);
        state.XRot = GetXRot(entity, partialTick);
        state.IsFoil = entity.Get(EntityDataFields.ThrownTrident.IdFoil);
    }
}

/// <summary><c>TridentModel</c>, a plain <c>Model</c> in vanilla, posed by nothing.</summary>
public sealed class TridentModel : EntityModel<EntityRenderState> {
    public const string Texture = "minecraft:textures/entity/trident/trident.png";

    public TridentModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        PartDefinition pole = root.AddOrReplaceChild("pole", CubeListBuilder.Create().TexOffs(0, 6).AddBox(-0.5F, 2.0F, -0.5F, 1.0F, 25.0F, 1.0F), PartPose.Zero);
        pole.AddOrReplaceChild("base", CubeListBuilder.Create().TexOffs(4, 0).AddBox(-1.5F, 0.0F, -0.5F, 3.0F, 2.0F, 1.0F), PartPose.Zero);
        pole.AddOrReplaceChild("left_spike", CubeListBuilder.Create().TexOffs(4, 3).AddBox(-2.5F, -3.0F, -0.5F, 1.0F, 4.0F, 1.0F), PartPose.Zero);
        pole.AddOrReplaceChild("middle_spike", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-0.5F, -4.0F, -0.5F, 1.0F, 4.0F, 1.0F), PartPose.Zero);
        pole.AddOrReplaceChild("right_spike", CubeListBuilder.Create().TexOffs(4, 3).Mirror().AddBox(1.5F, -3.0F, -0.5F, 1.0F, 4.0F, 1.0F), PartPose.Zero);
        return LayerDefinition.Create(mesh, 32, 32);
    }
}
