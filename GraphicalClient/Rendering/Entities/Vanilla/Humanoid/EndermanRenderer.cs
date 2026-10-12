using ClientLib.Entities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary><c>EndermanRenderState</c>.</summary>
public class EndermanRenderState : HumanoidRenderState {
    public bool IsCreepy;
    public IBlock? CarriedBlock;
}

/// <summary><c>EndermanRenderer</c>.</summary>
public sealed class EndermanRenderer : MobRenderer<EndermanRenderState, EndermanModel<EndermanRenderState>> {
    private const string EndermanLocation = "minecraft:textures/entity/enderman/enderman.png";
    private readonly Random _random = new();
    private readonly ItemRenderer _items;

    public EndermanRenderer(EntityRendererContext context)
        : base(new EndermanModel<EndermanRenderState>(EndermanModel<EndermanRenderState>.CreateBodyLayer().BakeRoot()), 0.5F) {
        _items = context.Items;
        AddLayer(new EnderEyesLayer(this));
        AddLayer(new CarriedBlockLayer(this, context.Blocks));
    }

    public override void Tick(ClientEntity entity) => HumanoidEntityData.TickFor<HumanoidEntityData>(entity);

    /// <summary><c>getRenderOffset</c>: a creepy enderman jitters sideways each frame.</summary>
    public override System.Numerics.Vector3 GetRenderOffset(EndermanRenderState state) {
        if (state.IsCreepy) {
            double d = 0.02 * state.Scale;
            return new System.Numerics.Vector3((float)(NextGaussian() * d), 0.0F, (float)(NextGaussian() * d));
        }
        return System.Numerics.Vector3.Zero;
    }

    /// <summary>
    /// <c>nextGaussian</c> from an unseeded source, as vanilla's renderer keeps one; the sequence is
    /// not vanilla's, which nothing can observe since vanilla's is unseeded too.
    /// </summary>
    private double NextGaussian() {
        double u1 = 1.0 - _random.NextDouble(), u2 = _random.NextDouble();
        return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
    }

    public override string GetTextureLocation(EndermanRenderState state) => EndermanLocation;

    public override void ExtractRenderState(ClientEntity entity, EndermanRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        HumanoidMobRenderer.ExtractHumanoidRenderState(entity, state, partialTick, _items, context);
        state.IsCreepy = entity.Get(EntityDataFields.EnderMan.Creepy);
        state.CarriedBlock = entity.Get(EntityDataFields.EnderMan.CarryState) is { Present: true, Value.Air: false } carried ? carried.Value : null;
    }
}

/// <summary><c>EndermanModel</c>.</summary>
public sealed class EndermanModel<T> : HumanoidModel<T> where T : EndermanRenderState {
    public EndermanModel(ModelPart root) : base(root) { }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = CreateMesh(CubeDeformation.None, -14.0F);
        PartDefinition root = mesh.Root;
        PartDefinition head = root.AddOrReplaceChild("head", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F),
            PartPose.Offset(0.0F, -13.0F, 0.0F));
        head.AddOrReplaceChild("hat", CubeListBuilder.Create().TexOffs(0, 16).AddBox(-4.0F, -8.0F, -4.0F, 8.0F, 8.0F, 8.0F, new CubeDeformation(-0.5F)), PartPose.Zero);
        root.AddOrReplaceChild("body", CubeListBuilder.Create().TexOffs(32, 16).AddBox(-4.0F, 0.0F, -2.0F, 8.0F, 12.0F, 4.0F), PartPose.Offset(0.0F, -14.0F, 0.0F));
        root.AddOrReplaceChild("right_arm", CubeListBuilder.Create().TexOffs(56, 0).AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 30.0F, 2.0F), PartPose.Offset(-5.0F, -12.0F, 0.0F));
        root.AddOrReplaceChild("left_arm", CubeListBuilder.Create().TexOffs(56, 0).Mirror().AddBox(-1.0F, -2.0F, -1.0F, 2.0F, 30.0F, 2.0F),
            PartPose.Offset(5.0F, -12.0F, 0.0F));
        root.AddOrReplaceChild("right_leg", CubeListBuilder.Create().TexOffs(56, 0).AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 30.0F, 2.0F), PartPose.Offset(-2.0F, -5.0F, 0.0F));
        root.AddOrReplaceChild("left_leg", CubeListBuilder.Create().TexOffs(56, 0).Mirror().AddBox(-1.0F, 0.0F, -1.0F, 2.0F, 30.0F, 2.0F),
            PartPose.Offset(2.0F, -5.0F, 0.0F));
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public override void SetupAnim(T state) {
        base.SetupAnim(state);
        HeadPart.Visible = true;
        RightArm.XRot *= 0.5F;
        LeftArm.XRot *= 0.5F;
        RightLeg.XRot *= 0.5F;
        LeftLeg.XRot *= 0.5F;
        RightArm.XRot = Mth.Clamp(RightArm.XRot, -0.4F, 0.4F);
        LeftArm.XRot = Mth.Clamp(LeftArm.XRot, -0.4F, 0.4F);
        RightLeg.XRot = Mth.Clamp(RightLeg.XRot, -0.4F, 0.4F);
        LeftLeg.XRot = Mth.Clamp(LeftLeg.XRot, -0.4F, 0.4F);
        if (state.CarriedBlock != null) {
            RightArm.XRot = -0.5F;
            LeftArm.XRot = -0.5F;
            RightArm.ZRot = 0.05F;
            LeftArm.ZRot = -0.05F;
        }
        if (state.IsCreepy) {
            HeadPart.Y -= 5.0F;
            Hat.Y += 5.0F;
        }
    }
}

/// <summary><c>EnderEyesLayer</c>.</summary>
public sealed class EnderEyesLayer : EyesLayer<EndermanRenderState, EndermanModel<EndermanRenderState>> {
    public EnderEyesLayer(LivingEntityRenderer<EndermanRenderState, EndermanModel<EndermanRenderState>> renderer) : base(renderer) { }

    public override string Texture => "minecraft:textures/entity/enderman/enderman_eyes.png";
}

/// <summary><c>CarriedBlockLayer</c>.</summary>
public sealed class CarriedBlockLayer : RenderLayer<EndermanRenderState, EndermanModel<EndermanRenderState>> {
    private readonly BlockModelRenderer _blocks;

    public CarriedBlockLayer(LivingEntityRenderer<EndermanRenderState, EndermanModel<EndermanRenderState>> renderer, BlockModelRenderer blocks) : base(renderer) {
        _blocks = blocks;
    }

    public override void Submit(PoseStack pose, EntityRenderContext context, EndermanRenderState state) {
        if (state.CarriedBlock is not { } carriedBlock) {
            return;
        }
        pose.Push();
        pose.Translate(0.0F, 0.6875F, -0.75F);
        pose.RotateXDegrees(20.0F);
        pose.RotateYDegrees(45.0F);
        pose.Translate(0.25F, 0.1875F, 0.25F);
        pose.Scale(-0.5F, -0.5F, 0.5F);
        pose.RotateYDegrees(90.0F);
        _blocks.Render(carriedBlock, pose, context.Batch, state.SkyLight, state.BlockLight);
        pose.Pop();
    }
}
