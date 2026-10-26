using ClientLib.Entities;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>BoggedRenderState</c>.</summary>
public class BoggedRenderState : SkeletonRenderState {
    public bool IsSheared;
}

/// <summary><c>BoggedRenderer</c>.</summary>
public sealed class BoggedRenderer : AbstractSkeletonRenderer<BoggedRenderState> {
    private const string BoggedSkeletonLocation = "minecraft:textures/entity/skeleton/bogged.png";
    private const string BoggedOuterLayerLocation = "minecraft:textures/entity/skeleton/bogged_overlay.png";

    public BoggedRenderer(EntityRendererContext context) : base(context, HumanoidLayers.HumanoidArmor(), new BoggedModel(BoggedModel.CreateBodyLayer().BakeRoot())) {
        AddLayer(new SkeletonClothingLayer<BoggedRenderState, SkeletonModel<BoggedRenderState>>(this,
            LayerDefinition.Create(HumanoidModel<BoggedRenderState>.CreateMesh(new CubeDeformation(0.2F), 0.0F), 64, 32), BoggedOuterLayerLocation));
    }

    public override string GetTextureLocation(BoggedRenderState state) => BoggedSkeletonLocation;

    public override void ExtractRenderState(ClientEntity entity, BoggedRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        state.IsSheared = entity.Get(EntityDataFields.Bogged.Sheared);
    }
}

/// <summary><c>BoggedModel</c>.</summary>
public sealed class BoggedModel : SkeletonModel<BoggedRenderState> {
    private readonly ModelPart _mushrooms;

    public BoggedModel(ModelPart root) : base(root) {
        _mushrooms = root.GetChild("head").GetChild("mushrooms");
    }

    public new static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, 0.0F);
        PartDefinition root = mesh.Root;
        CreateDefaultSkeletonMesh(root);
        PartDefinition mushrooms = root.GetChild("head").AddOrReplaceChild("mushrooms", CubeListBuilder.Create(), PartPose.Zero);
        mushrooms.AddOrReplaceChild("red_mushroom_1", CubeListBuilder.Create().TexOffs(50, 16).AddBox(-3.0F, -3.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(3.0F, -8.0F, 3.0F, 0.0F, (float)(Math.PI / 4), 0.0F));
        mushrooms.AddOrReplaceChild("red_mushroom_2", CubeListBuilder.Create().TexOffs(50, 16).AddBox(-3.0F, -3.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(3.0F, -8.0F, 3.0F, 0.0F, (float)(Math.PI * 3.0 / 4.0), 0.0F));
        mushrooms.AddOrReplaceChild("brown_mushroom_1", CubeListBuilder.Create().TexOffs(50, 22).AddBox(-3.0F, -3.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(-3.0F, -8.0F, -3.0F, 0.0F, (float)(Math.PI / 4), 0.0F));
        mushrooms.AddOrReplaceChild("brown_mushroom_2", CubeListBuilder.Create().TexOffs(50, 22).AddBox(-3.0F, -3.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(-3.0F, -8.0F, -3.0F, 0.0F, (float)(Math.PI * 3.0 / 4.0), 0.0F));
        mushrooms.AddOrReplaceChild("brown_mushroom_3", CubeListBuilder.Create().TexOffs(50, 28).AddBox(-3.0F, -4.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(-2.0F, -1.0F, 4.0F, (float)(-Math.PI / 2), 0.0F, (float)(Math.PI / 4)));
        mushrooms.AddOrReplaceChild("brown_mushroom_4", CubeListBuilder.Create().TexOffs(50, 28).AddBox(-3.0F, -4.0F, 0.0F, 6.0F, 4.0F, 0.0F),
            PartPose.OffsetAndRotation(-2.0F, -1.0F, 4.0F, (float)(-Math.PI / 2), 0.0F, (float)(Math.PI * 3.0 / 4.0)));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(BoggedRenderState state) {
        base.SetupAnim(state);
        _mushrooms.Visible = !state.IsSheared;
    }
}
