using ClientLib.Entities;
using ClientLib.Player;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;

namespace GraphicalClient.Gui;

/// <summary>The active effects in the top right corner: beneficial ones in the first row, the rest in the second.</summary>
public static class EffectIcons {
    /// <summary><c>Hud.getMobEffectSprite</c>.</summary>
    public static string Sprite(IPotionEffectType effect) => $"mob_effect/{effect.Identifier.Key}";

    /// <summary><c>Hud.extractEffects</c>, which the demo's extra offset is left out of.</summary>
    public static void Draw(GuiContext context, LocalPlayer player, int w, bool screenShowsEffects) {
        if (player.ActiveEffects.Count == 0 || screenShowsEffects) {
            return;
        }
        int beneficialCount = 0;
        int harmfulCount = 0;
        foreach (MobEffectInstance instance in player.ActiveEffects.OrderByDescending(effect => effect)) {
            if (!instance.ShowIcon) {
                continue;
            }
            int x = w;
            int y = 1;
            if (MobEffects.Get(instance.Effect).IsBeneficial) {
                beneficialCount++;
                x -= 25 * beneficialCount;
            }
            else {
                harmfulCount++;
                x -= 25 * harmfulCount;
                y += 26;
            }

            float alpha = 1.0F;
            if (instance.IsAmbient) {
                context.Sprites.Sprite(context.Gui, "hud/effect_background_ambient", x, y, 24, 24);
            }
            else {
                context.Sprites.Sprite(context.Gui, "hud/effect_background", x, y, 24, 24);
                if (instance.EndsWithin(200)) {
                    int remainingDuration = instance.Duration;
                    int usedSeconds = 10 - remainingDuration / 20;
                    alpha = Math.Clamp(remainingDuration / 10.0F / 5.0F * 0.5F, 0.0F, 0.5F)
                            + Mth.Cos(remainingDuration * (float)Math.PI / 5.0F) * Math.Clamp(usedSeconds / 10.0F * 0.25F, 0.0F, 0.25F);
                    alpha = Math.Clamp(alpha, 0.0F, 1.0F);
                }
            }
            context.Sprites.Sprite(context.Gui, Sprite(instance.Effect), x + 3, y + 3, 18, 18, White(alpha));
        }
    }

    /// <summary><c>ARGB.white</c>.</summary>
    private static uint White(float alpha) => (uint)(int)(alpha * 255.0F) << 24 | 0xFFFFFF;
}
