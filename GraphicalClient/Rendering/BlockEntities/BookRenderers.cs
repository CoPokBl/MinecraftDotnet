using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using Minecraft.Data.Generated.BlockTypes;

namespace GraphicalClient.Rendering.BlockEntities;

/// <summary><c>BookModel</c>.</summary>
public sealed class BookModel : EntityModel<EntityRenderState> {
    /// <summary><c>BookModel.State</c>.</summary>
    public readonly record struct State(float Openness, float PageFlip1, float PageFlip2) {
        public static State ForAnimation(float progress, float pageFlip1, float pageFlip2, float openness) =>
            new((Mth.Sin(progress * 0.02F) * 0.1F + 1.25F) * openness, pageFlip1, pageFlip2);
    }

    private readonly ModelPart _leftLid, _rightLid, _leftPages, _rightPages, _flipPage1, _flipPage2;

    public BookModel(ModelPart root) : base(root) {
        _leftLid = root.GetChild("left_lid");
        _rightLid = root.GetChild("right_lid");
        _leftPages = root.GetChild("left_pages");
        _rightPages = root.GetChild("right_pages");
        _flipPage1 = root.GetChild("flip_page1");
        _flipPage2 = root.GetChild("flip_page2");
    }

    public static LayerDefinition CreateBodyLayer() {
        MeshDefinition mesh = new();
        PartDefinition root = mesh.Root;
        root.AddOrReplaceChild("left_lid", CubeListBuilder.Create().TexOffs(0, 0).AddBox(-6.0F, -5.0F, -0.005F, 6.0F, 10.0F, 0.005F), PartPose.Offset(0.0F, 0.0F, -1.0F));
        root.AddOrReplaceChild("right_lid", CubeListBuilder.Create().TexOffs(16, 0).AddBox(0.0F, -5.0F, -0.005F, 6.0F, 10.0F, 0.005F), PartPose.Offset(0.0F, 0.0F, 1.0F));
        root.AddOrReplaceChild("seam", CubeListBuilder.Create().TexOffs(12, 0).AddBox(-1.0F, -5.0F, 0.0F, 2.0F, 10.0F, 0.005F), PartPose.Rotation(0.0F, MathF.PI / 2, 0.0F));
        root.AddOrReplaceChild("left_pages", CubeListBuilder.Create().TexOffs(0, 10).AddBox(0.0F, -4.0F, -0.99F, 5.0F, 8.0F, 1.0F), PartPose.Zero);
        root.AddOrReplaceChild("right_pages", CubeListBuilder.Create().TexOffs(12, 10).AddBox(0.0F, -4.0F, -0.01F, 5.0F, 8.0F, 1.0F), PartPose.Zero);
        CubeListBuilder page = CubeListBuilder.Create().TexOffs(24, 10).AddBox(0.0F, -4.0F, 0.0F, 5.0F, 8.0F, 0.005F);
        root.AddOrReplaceChild("flip_page1", page, PartPose.Zero);
        root.AddOrReplaceChild("flip_page2", page, PartPose.Zero);
        return LayerDefinition.Create(mesh, 64, 32);
    }

    public void SetupAnim(State state) {
        ResetPose();
        float openness = state.Openness;
        _leftLid.YRot = MathF.PI + openness;
        _rightLid.YRot = -openness;
        _leftPages.YRot = openness;
        _rightPages.YRot = -openness;
        _flipPage1.YRot = openness - openness * 2.0F * state.PageFlip1;
        _flipPage2.YRot = openness - openness * 2.0F * state.PageFlip2;
        _leftPages.X = Mth.Sin(openness);
        _rightPages.X = Mth.Sin(openness);
        _flipPage1.X = Mth.Sin(openness);
        _flipPage2.X = Mth.Sin(openness);
    }
}

public sealed class EnchantTableRenderState : BlockEntityRenderState {
    public float Flip, Open, Time, YRot;
}

/// <summary><c>EnchantTableRenderer</c>: the book over the table.</summary>
public sealed class EnchantTableRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<EnchantingTableBlockEntity, EnchantTableRenderState> {
    public static readonly SpriteId BookTexture = Sheets.BlockEntitySprite("enchantment/enchanting_table_book");

    private readonly BookModel _bookModel = new(BookModel.CreateBodyLayer().BakeRoot());

    public override void ExtractRenderState(EnchantingTableBlockEntity blockEntity, EnchantTableRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.Flip = Mth.Lerp(partialTick, blockEntity.OFlip, blockEntity.Flip);
        state.Open = Mth.Lerp(partialTick, blockEntity.OOpen, blockEntity.Open);
        state.Time = blockEntity.Time + partialTick;
        float or = blockEntity.Rot - blockEntity.ORot;
        while (or >= MathF.PI) {
            or -= MathF.PI * 2;
        }
        while (or < -MathF.PI) {
            or += MathF.PI * 2;
        }
        state.YRot = blockEntity.ORot + or * partialTick;
    }

    public override void Submit(EnchantTableRenderState state, PoseStack pose, EntityRenderContext render) {
        pose.Push();
        pose.Translate(0.5F, 0.75F, 0.5F);
        pose.Translate(0.0F, 0.1F + Mth.Sin(state.Time * 0.1F) * 0.01F, 0.0F);
        pose.RotateY(-state.YRot);
        pose.RotateZDegrees(80.0F);
        float ff1 = Mth.Frac(state.Flip + 0.25F) * 1.6F - 0.3F;
        float ff2 = Mth.Frac(state.Flip + 0.75F) * 1.6F - 0.3F;
        _bookModel.SetupAnim(BookModel.State.ForAnimation(state.Time, Mth.Clamp(ff1, 0.0F, 1.0F), Mth.Clamp(ff2, 0.0F, 1.0F), state.Open));
        _bookModel.RenderToBuffer(pose, render.Batch, Draw(context.Sprites.Get(BookTexture), state));
        pose.Pop();
    }
}

public sealed class LecternRenderState : BlockEntityRenderState {
    public bool HasBook;
    public float YRot;
}

/// <summary><c>LecternRenderer</c>: the open book on its stand.</summary>
public sealed class LecternRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<ClientBlockEntity, LecternRenderState> {
    private static readonly BookModel.State BookState = BookModel.State.ForAnimation(0.0F, 0.1F, 0.9F, 1.2F);

    private readonly BookModel _bookModel = new(BookModel.CreateBodyLayer().BakeRoot());

    public override void ExtractRenderState(ClientBlockEntity blockEntity, LecternRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        if (blockEntity.State is LecternBlock lectern) {
            state.HasBook = lectern.HasBook;
            state.YRot = DirectionUtil.ToYRot(DirectionUtil.ClockWise(lectern.Facing));
        }
    }

    public override void Submit(LecternRenderState state, PoseStack pose, EntityRenderContext render) {
        if (!state.HasBook) {
            return;
        }
        pose.Push();
        pose.Translate(0.5F, 1.0625F, 0.5F);
        pose.RotateYDegrees(-state.YRot);
        pose.RotateZDegrees(67.5F);
        pose.Translate(0.0F, -0.125F, 0.0F);
        _bookModel.SetupAnim(BookState);
        _bookModel.RenderToBuffer(pose, render.Batch, Draw(context.Sprites.Get(EnchantTableRenderer.BookTexture), state));
        pose.Pop();
    }
}
