using System.Numerics;
using ClientLib;
using ClientLib.World.BlockEntities;
using GraphicalClient.Rendering.Entities;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace GraphicalClient.Rendering.BlockEntities;

public sealed class SignRenderState : BlockEntityRenderState {
    public SignText? FrontText, BackText;
    public int TextLineHeight, MaxTextLineWidth;
    public bool DrawOutline;
    public Matrix4x4 FrontTransformation = Matrix4x4.Identity, BackTransformation = Matrix4x4.Identity;
}

/// <summary>
/// <c>AbstractSignRenderer</c> with <c>StandingSignRenderer</c> and <c>HangingSignRenderer</c>: the text on
/// both faces. The board itself is a block model. Text filtering is never on.
/// </summary>
public sealed class SignRenderer(BlockEntityRendererContext context) : BlockEntityRenderer<SignBlockEntity, SignRenderState> {
    private const uint BlackTextOutlineColor = 0xFFF0EBCC;
    private const int OutlineRenderDistance = 16 * 16;

    private static readonly Vector3 StandingTextOffset = new(0.0F, 0.33333334F, 0.046666667F);
    private static readonly Vector3 HangingTextOffset = new(0.0F, -0.32F, 0.073F);

    public override void ExtractRenderState(SignBlockEntity blockEntity, SignRenderState state, float partialTick, EntityRenderContext render) {
        base.ExtractRenderState(blockEntity, state, partialTick, render);
        state.MaxTextLineWidth = blockEntity.MaxTextLineWidth;
        state.TextLineHeight = blockEntity.TextLineHeight;
        state.FrontText = blockEntity.FrontText;
        state.BackText = blockEntity.BackText;
        state.DrawOutline = IsOutlineVisible(blockEntity, render);
        bool wall = blockEntity.State is IHorizontalFacing;
        float angle = blockEntity.State switch {
            IHorizontalFacing facing => DirectionUtil.ToYRot(facing.Facing),
            IRotated rotated => BlockEntityTransforms.SegmentToDegrees(rotated.Rotation),
            _ => 0.0F
        };
        if (blockEntity.IsHanging) {
            state.FrontTransformation = HangingTextTransformation(angle, true);
            state.BackTransformation = HangingTextTransformation(angle, false);
        }
        else {
            state.FrontTransformation = StandingTextTransformation(wall, angle, true);
            state.BackTransformation = StandingTextTransformation(wall, angle, false);
        }
    }

    /// <summary>
    /// <c>isOutlineVisible</c>: the camera within sixteen blocks of the sign. Looking through a spyglass
    /// in first person would also show it; this client has no spyglass zoom to test for.
    /// </summary>
    private static bool IsOutlineVisible(SignBlockEntity blockEntity, EntityRenderContext render) =>
        new ClientLib.Maths.Vec3d(blockEntity.X + 0.5, blockEntity.Y + 0.5, blockEntity.Z + 0.5).DistanceToSqr(render.Camera.Position) < OutlineRenderDistance;

    public override void Submit(SignRenderState state, PoseStack pose, EntityRenderContext render) {
        if (state.FrontText != null) {
            pose.Push();
            pose.MulPose(state.FrontTransformation);
            SubmitSignText(state, pose, render, state.FrontText);
            pose.Pop();
        }
        if (state.BackText != null) {
            pose.Push();
            pose.MulPose(state.BackTransformation);
            SubmitSignText(state, pose, render, state.BackText);
            pose.Pop();
        }
    }

    private void SubmitSignText(SignRenderState state, PoseStack pose, EntityRenderContext render, SignText signText) {
        uint darkColor = GetDarkColor(signText);
        int signMidpoint = 4 * state.TextLineHeight / 2;
        uint textColor;
        bool drawOutline;
        float sky = state.SkyLight, block = state.BlockLight;
        if (signText.HasGlowingText) {
            textColor = TextColor(signText.Color);
            drawOutline = textColor == TextColor(DyeColor.Black) || state.DrawOutline;
            sky = block = 15;
        }
        else {
            textColor = darkColor;
            drawOutline = false;
        }
        Minecraft.Text.TextComponent[] messages = signText.GetMessages(false);
        for (int i = 0; i < 4; i++) {
            List<TextRun> line = context.Font.FirstLine(TextFlattener.Flatten(messages[i], (int)(textColor & 0xFFFFFF)), state.MaxTextLineWidth);
            float x1 = -context.Font.Width(line) / 2;
            context.Font.Draw(line, x1, i * state.TextLineHeight - signMidpoint, 255, drawOutline ? darkColor : 0, pose, render.Batch, sky, block);
        }
    }

    /// <summary><c>getDarkColor</c>: black glowing text gets a pale outline, anything else its colour at 40 percent.</summary>
    public static uint GetDarkColor(SignText signText) {
        uint color = TextColor(signText.Color);
        if (color == TextColor(DyeColor.Black) && signText.HasGlowingText) {
            return BlackTextOutlineColor;
        }
        uint Scale(int shift) => (uint)(int)((color >> shift & 0xFF) * 0.4F) << shift;
        return 0xFF000000 | Scale(16) | Scale(8) | Scale(0);
    }

    /// <summary><c>DyeColor.getTextColor</c>, made opaque as <c>Font.adjustColor</c> makes a colour with no alpha.</summary>
    public static uint TextColor(DyeColor color) => 0xFF000000 | color switch {
        DyeColor.White => 16777215u,
        DyeColor.Orange => 16738335u,
        DyeColor.Magenta => 16711935u,
        DyeColor.LightBlue => 10141901u,
        DyeColor.Yellow => 16776960u,
        DyeColor.Lime => 12582656u,
        DyeColor.Pink => 16738740u,
        DyeColor.Gray => 8421504u,
        DyeColor.LightGray => 13882323u,
        DyeColor.Cyan => 65535u,
        DyeColor.Purple => 10494192u,
        DyeColor.Blue => 255u,
        DyeColor.Brown => 9127187u,
        DyeColor.Green => 65280u,
        DyeColor.Red => 16711680u,
        _ => 0u
    };

    /// <summary><c>StandingSignRenderer.textTransformation</c>.</summary>
    private static Matrix4x4 StandingTextTransformation(bool wall, float angle, bool isFrontText) {
        PoseStack result = new();
        result.Translate(0.5F, 0.5F, 0.5F);
        result.RotateYDegrees(-angle);
        if (wall) {
            result.Translate(0.0F, -0.3125F, -0.4375F);
        }
        if (!isFrontText) {
            result.RotateYDegrees(180.0F);
        }
        const float s = 0.010416667F;
        result.Translate(StandingTextOffset);
        result.Scale(s, -s, s);
        return result.Matrix;
    }

    /// <summary><c>HangingSignRenderer.textTransformation</c>.</summary>
    private static Matrix4x4 HangingTextTransformation(float angle, bool isFrontText) {
        PoseStack result = new();
        result.Translate(0.5F, 0.9375F, 0.5F);
        result.RotateYDegrees(-angle);
        result.Translate(0.0F, -0.3125F, 0.0F);
        if (!isFrontText) {
            result.RotateYDegrees(180.0F);
        }
        const float s = 0.0140625F;
        result.Translate(HangingTextOffset);
        result.Scale(s, -s, s);
        return result.Matrix;
    }
}
