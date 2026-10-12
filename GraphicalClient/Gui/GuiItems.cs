using System.Numerics;
using ClientLib.Interaction;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering.Entities;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Gui;

public static class GuiItems {
    /// <summary>
    /// An item icon, its glint, and <c>GuiGraphics.itemDecorations</c>: its bar, its cooldown and its count.
    /// <paramref name="heldIn"/> is the player's hand the stack is in and <paramref name="carried"/> whether it
    /// is the stack on the cursor, which some item models ask.
    /// </summary>
    public static void Draw(GuiContext context, ItemStack stack, float x, float y, int seed = 0, Hand? heldIn = null, bool carried = false) {
        if (stack.Count <= 0 || stack.Type.Identifier.Key == "air") {
            return;
        }
        if (context.Items.TryUv(stack, seed, heldIn, carried, out (float U0, float V0, float U1, float V1) uv, out FoilType foil)) {
            context.Gui.Textured(context.Items.Texture, x, y, 16, 16, uv.U0, uv.V0, uv.U1, uv.V1);
            if (foil != FoilType.None) {
                Span<Vector2> glintUvs = stackalloc Vector2[4];
                ItemAtlas.GlintUvs(foil, glintUvs);
                EnchantmentGlint glint = context.Items.Glint;
                Matrix3x2 texturing = glint.Matrix(GlintType.Item);
                for (int i = 0; i < 4; i++) {
                    glintUvs[i] = Vector2.Transform(glintUvs[i], texturing);
                }
                context.Gui.Glint(context.Items.Texture, x, y, 16, 16, uv, glint.ItemTexture, glintUvs, glint.Strength);
            }
        }
        if (ItemBars.IsBarVisible(stack)) {
            float left = x + 2, top = y + 13;
            context.Gui.Rect(left, top, 13, 2, 0xFF000000);
            context.Gui.Rect(left, top, ItemBars.GetBarWidth(stack), 1, 0xFF000000 | ItemBars.GetBarColor(stack));
        }
        float cooldown = context.Client.Player?.Cooldowns.GetCooldownPercent(stack, context.PartialTick) ?? 0.0F;
        if (cooldown > 0.0F) {
            float top = y + MathF.Floor(16.0F * (1.0F - cooldown));
            context.Gui.Rect(x, top, 16, MathF.Ceiling(16.0F * cooldown), 0x7FFFFFFF);
        }
        if (stack.Count > 1) {
            string count = stack.Count.ToString();
            context.Text.Draw(count, x + 17 - context.Text.Width(count), y + 9);
        }
    }
}
