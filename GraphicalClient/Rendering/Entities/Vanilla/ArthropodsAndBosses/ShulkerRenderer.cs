using System.Numerics;
using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.Entities.Vanilla;

public sealed class ShulkerRenderState : LivingEntityRenderState {
    public Vector3 RenderOffset = Vector3.Zero;
    public DyeColor? Color;
    public float PeekAmount, YHeadRot, YBodyRot;
    public Cardinal AttachFace = Cardinal.Down;
}

public sealed class ShulkerRenderer : MobRenderer<ShulkerRenderState, ShulkerModel> {
    // DyeColor's names, by id.
    private static readonly string[] ColourNames = [
        "white", "orange", "magenta", "light_blue", "yellow", "lime", "pink", "gray",
        "light_gray", "cyan", "purple", "blue", "brown", "green", "red", "black"
    ];

    private static readonly string[] TextureLocation = ColourNames.Select(name => $"minecraft:textures/entity/shulker/shulker_{name}.png").ToArray();

    public ShulkerRenderer(EntityRendererContext context) : base(new ShulkerModel(ShulkerModel.CreateBodyLayer().BakeRoot()), 0.0F) { }

    public override string GetTextureLocation(ShulkerRenderState state) => GetTextureLocation(state.Color);

    public static string GetTextureLocation(DyeColor? color) => color == null ? "minecraft:textures/entity/shulker/shulker.png" : TextureLocation[(int)color.Value];

    public override void ExtractRenderState(ClientEntity entity, ShulkerRenderState state, float partialTick, EntityRenderContext context) {
        base.ExtractRenderState(entity, state, partialTick, context);
        ClientShulker? shulker = entity as ClientShulker;
        if (shulker != null) {
            // The snapped position, which vanilla's xOld matches outside a teleport, so it does not lerp.
            (state.X, state.Y, state.Z) = (shulker.SnappedPosition.X, shulker.SnappedPosition.Y, shulker.SnappedPosition.Z);
        }
        // getRenderOffset, which the dispatcher adds to the position before submitting.
        state.RenderOffset = shulker?.RenderPosition(partialTick) is { } offset ? new Vector3((float)offset.X, (float)offset.Y, (float)offset.Z) : Vector3.Zero;
        state.X += state.RenderOffset.X;
        state.Y += state.RenderOffset.Y;
        state.Z += state.RenderOffset.Z;
        // Shulker.getColor.
        sbyte color = entity.Get(EntityDataFields.Shulker.Color, (sbyte)16);
        state.Color = color != 16 && color <= 15 ? (DyeColor)color : null;
        state.PeekAmount = shulker?.ClientPeekAmount(partialTick) ?? 0;
        state.YHeadRot = entity.YHeadRot;
        state.YBodyRot = entity.YBodyRot;
        state.AttachFace = entity.Get(EntityDataFields.Shulker.AttachFace, Cardinal.Down);
    }

    protected override void SetupRotations(ShulkerRenderState state, PoseStack pose, float bodyRot, float entityScale) {
        base.SetupRotations(state, pose, bodyRot + 180.0F, entityScale);
        pose.Translate(0.0F, 0.5F, 0.0F);
        RotateToFace(pose, ClientShulker.Opposite(state.AttachFace));
        pose.Translate(0.0F, -0.5F, 0.0F);
    }

    /// <summary><c>Direction.getRotation</c>.</summary>
    private static void RotateToFace(PoseStack pose, Cardinal face) {
        switch (face) {
            case Cardinal.Down:
                pose.RotateX((float)Math.PI);
                break;
            case Cardinal.Up:
                break;
            case Cardinal.North:
                pose.RotateXYZ((float)(Math.PI / 2), 0.0F, (float)Math.PI);
                break;
            case Cardinal.South:
                pose.RotateX((float)(Math.PI / 2));
                break;
            case Cardinal.West:
                pose.RotateXYZ((float)(Math.PI / 2), 0.0F, (float)(Math.PI / 2));
                break;
            case Cardinal.East:
                pose.RotateXYZ((float)(Math.PI / 2), 0.0F, (float)(-Math.PI / 2));
                break;
        }
    }
}
