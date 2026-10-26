using ClientLib;
using ClientLib.Entities;

namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// <c>EffectsInInventory</c>: the player's effects in a column right of an inventory screen, named where
/// there is room and as bare icons with a tooltip where there is not.
/// </summary>
public sealed class EffectsInInventory {
    private const int SpriteSquareSize = 32;
    private const int Spacing = 7;

    private List<List<TextRun>>? _tooltip;

    public static bool CanSeeEffects(int width, float leftPos, int imageWidth) {
        int xo = (int)leftPos + imageWidth + 2;
        return width - xo >= 32;
    }

    /// <summary><c>extractRenderState</c>. The compact tooltip waits for <see cref="DrawTooltip"/>, as vanilla defers it to the end of the frame.</summary>
    public void Render(GuiContext context, float leftPos, float topPos, int imageWidth, float mouseX, float mouseY) {
        _tooltip = null;
        int xo = (int)leftPos + imageWidth + 2;
        int availableWidth = context.Width - xo;
        if (context.Client.Player is not { } player || player.ActiveEffects.Count == 0 || availableWidth < 32) {
            return;
        }
        int maxWidth = availableWidth >= 120 ? availableWidth - 7 : 32;
        int yStep = 33;
        if (player.ActiveEffects.Count > 5) {
            yStep = 132 / (player.ActiveEffects.Count - 1);
        }

        float tickRate = context.Client.Level?.TickRateManager.TickRate ?? 20.0F;
        int y0 = (int)topPos;
        foreach (MobEffectInstance effect in player.ActiveEffects.Order()) {
            string effectText = EffectName(effect);
            string duration = MobEffectUtil.FormatDuration(effect, 1.0F, tickRate);
            int textureWidth = DrawBackground(context, effectText, duration, xo, y0, effect.IsAmbient, maxWidth);
            DrawText(context, effectText, duration, xo, y0, textureWidth, yStep, mouseX, mouseY);
            context.Sprites.Sprite(context.Gui, EffectIcons.Sprite(effect.Effect), xo + 7, y0 + 7, 18, 18);
            y0 += yStep;
        }
    }

    public void DrawTooltip(GuiContext context, float mouseX, float mouseY) {
        if (_tooltip != null) {
            Tooltips.Draw(context, _tooltip, mouseX, mouseY);
        }
    }

    private static int DrawBackground(GuiContext context, string effectName, string duration, int x0, int y0, bool isAmbient, int maxTextureWidth) {
        int nameWidth = SpriteSquareSize + context.Text.Width(effectName) + Spacing;
        int durationWidth = SpriteSquareSize + context.Text.Width(duration) + Spacing;
        int textureWidth = Math.Min(maxTextureWidth, Math.Max(nameWidth, durationWidth));
        string sprite = isAmbient ? "container/inventory/effect_background_ambient" : "container/inventory/effect_background";
        context.Sprites.Sliced(context.Gui, sprite, x0, y0, textureWidth, SpriteSquareSize, 4);
        return textureWidth;
    }

    private void DrawText(GuiContext context, string effectText, string duration, int x0, int y0, int textureWidth, int yStep, float mouseX, float mouseY) {
        int textX = x0 + SpriteSquareSize;
        int textY = y0 + 7;
        int maxTextWidth = textureWidth - SpriteSquareSize - Spacing;
        bool isCompact;
        if (maxTextWidth > 0) {
            bool shouldClip = context.Text.Width(effectText) > maxTextWidth;
            context.Text.Draw(shouldClip ? ClipText(context, effectText, maxTextWidth) : effectText, textX, textY, 0xFFFFFFFF);
            context.Text.Draw(duration, textX, textY + 9, 0xFF808080);
            isCompact = shouldClip;
        }
        else {
            isCompact = true;
        }

        if (isCompact && mouseX >= x0 && mouseX <= x0 + textureWidth && mouseY >= y0 && mouseY <= y0 + yStep) {
            _tooltip = [[new TextRun(effectText, 0xFFFFFF)], [new TextRun(duration, 0xFFFFFF)]];
        }
    }

    /// <summary><c>ComponentRenderUtils.clipText</c>.</summary>
    private static string ClipText(GuiContext context, string text, int width) =>
        context.Text.Splitter.PlainHeadByWidth(text, width - context.Text.Width("..."), StringSplitter.Empty) + "...";

    /// <summary><c>getEffectName</c>: the effect's name, and its level as a numeral from II to X.</summary>
    private static string EffectName(MobEffectInstance effect) {
        string name = Translations.Get(MobEffect.DescriptionId(effect.Effect)) ?? effect.Effect.Identifier.Key;
        if (effect.Amplifier >= 1 && effect.Amplifier <= 9) {
            name += " " + Translations.Get("enchantment.level." + (effect.Amplifier + 1));
        }
        return name;
    }
}
