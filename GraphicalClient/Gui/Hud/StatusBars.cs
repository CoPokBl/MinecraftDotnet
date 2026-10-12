using ClientLib;
using ClientLib.Entities.Vehicles;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Attribute = Minecraft.Data.Generated.Attribute;
using Icon = GraphicalClient.Gui.HudIcons.Icon;

namespace GraphicalClient.Gui;

/// <summary>The bars over the hotbar: experience or the jump bar, hearts, armour, food or the mount's hearts, and air.</summary>
public static class StatusBars {
    private const int MaxAir = 300;

    public static void Draw(GuiContext context, MinecraftClient client, LocalPlayer player, int w, int h) {
        float left = w / 2.0F - 91, right = w / 2.0F + 91;
        float heartsY = h - 39;
        if (player.JumpableVehicle == null) {
            DrawExperienceBar(context, player, left, h - 29);
        }
        DrawLevel(context, player, w / 2.0F, h - 35);

        // Gui.renderHearts: rows of ten, half a heart per point.
        int hearts = (int)Math.Ceiling(player.Attributes.Value(Attribute.MaxHealth) / 2.0);
        int health = (int)Math.Ceiling(player.Health);
        int rows = Math.Max(1, (hearts + 9) / 10);
        int rowStep = Math.Max(10 - (rows - 2), 3);
        for (int i = hearts - 1; i >= 0; i--) {
            float hx = left + i % 10 * 8, hy = heartsY - i / 10 * rowStep;
            if (health <= 4 && client.ClientTicks % 4 < 2 && i * 2 < health + 2) {
                hy += (client.ClientTicks + i) % 2;
            }
            DrawIcon(context, Icon.HeartEmpty, hx, hy);
            if (Filled(i, health, client.Hardcore ? Icon.HeartHardcoreFull : Icon.HeartFull, client.Hardcore ? Icon.HeartHardcoreHalf : Icon.HeartHalf) is { } heart) {
                DrawIcon(context, heart, hx, hy);
            }
        }

        // Armour sits a row above the hearts, only when there is some.
        int armour = (int)player.Attributes.Value(Attribute.Armor);
        if (armour > 0) {
            float ay = heartsY - (rows - 1) * rowStep - 10;
            for (int i = 0; i < 10; i++) {
                DrawIcon(context, Filled(i, armour, Icon.ArmourFull, Icon.ArmourHalf) ?? Icon.ArmourEmpty, left + i * 8, ay);
            }
        }

        // Food, right to left, unless a mount's hearts stand in its place.
        int vehicleHearts = VehicleMaxHearts(player);
        for (int i = 0; i < 10 && vehicleHearts == 0; i++) {
            float fx = right - i * 8 - 9;
            DrawIcon(context, Icon.FoodEmpty, fx, heartsY);
            if (Filled(i, player.Food, Icon.FoodFull, Icon.FoodHalf) is { } food) {
                DrawIcon(context, food, fx, heartsY);
            }
        }

        // Air: shown while under water or while it is still refilling.
        int air = player.Get(EntityDataFields.Entity.AirSupply, MaxAir);
        if (player.IsUnderWater || air < MaxAir) {
            int full = (int)Math.Ceiling((air - 2) * 10.0 / MaxAir);
            int popping = (int)Math.Ceiling(air * 10.0 / MaxAir) - full;
            // Hud.getAirBubbleYLine: above the top row of the mount's hearts.
            float airY = heartsY - 10 - Math.Max(0, (vehicleHearts + 9) / 10 - 1) * 10;
            for (int i = 0; i < full + popping && i < 10; i++) {
                DrawIcon(context, i < full ? Icon.Bubble : Icon.BubblePopped, right - i * 8 - 9, airY);
            }
        }
    }

    /// <summary>The icon for the <paramref name="i"/>th of a row of two point icons, or null where it is empty.</summary>
    private static Icon? Filled(int i, int value, Icon full, Icon half) =>
        i * 2 + 1 < value ? full : i * 2 + 1 == value ? half : null;

    private static void DrawExperienceBar(GuiContext context, LocalPlayer player, float left, float top) {
        float progress = Math.Clamp(player.ExperienceProgress, 0, 1);
        if (context.Sprites.Sprite(context.Gui, "hud/experience_bar_background", left, top, 182, 5)) {
            context.Sprites.Sprite(context.Gui, "hud/experience_bar_progress", left, top, 182, 5, fraction: progress);
            return;
        }
        context.Gui.Rect(left, top, 182, 5, 0xFF000000);
        context.Gui.Rect(left + 1, top + 1, 180, 3, 0xFF202020);
        context.Gui.Rect(left + 1, top + 1, 180 * progress, 3, 0xFF80FF20);
    }

    private static void DrawLevel(GuiContext context, LocalPlayer player, float centreX, float top) {
        if (player.ExperienceLevel <= 0) {
            return;
        }
        string level = player.ExperienceLevel.ToString();
        float x = centreX - context.Text.Width(level) / 2.0F;
        context.Text.Draw(level, x + 1, top, 0xFF000000, false);
        context.Text.Draw(level, x - 1, top, 0xFF000000, false);
        context.Text.Draw(level, x, top + 1, 0xFF000000, false);
        context.Text.Draw(level, x, top - 1, 0xFF000000, false);
        context.Text.Draw(level, x, top, 0xFF80FF20, false);
    }

    /// <summary><c>Hud.getVehicleMaxHearts</c>: a living mount shows up to 30 hearts.</summary>
    private static int VehicleMaxHearts(LocalPlayer player) {
        if (player.Vehicle is not { IsLiving: true } vehicle) {
            return 0;
        }
        float maxVehicleHealth = (float)vehicle.Attributes.Value(Attribute.MaxHealth);
        return Math.Min((int)(maxVehicleHealth + 0.5F) / 2, 30);
    }

    /// <summary><c>Hud.extractVehicleHealth</c>: the mount's hearts, right to left in rows of ten, where the food goes.</summary>
    public static void DrawVehicleHealth(GuiContext context, LocalPlayer player, int w, int h) {
        int hearts = VehicleMaxHearts(player);
        if (hearts == 0) {
            return;
        }
        int currentHealth = (int)Math.Ceiling(player.Vehicle!.CurrentHealth);
        float xRight = w / 2.0F + 91;
        float yo = h - 39;
        for (int baseHealth = 0; hearts > 0; baseHealth += 20) {
            int rowHearts = Math.Min(hearts, 10);
            hearts -= rowHearts;
            for (int i = 0; i < rowHearts; i++) {
                float xo = xRight - i * 8 - 9;
                DrawSpriteOrIcon(context, "hud/heart/vehicle_container", Icon.HeartEmpty, xo, yo);
                if (i * 2 + 1 + baseHealth < currentHealth) {
                    DrawSpriteOrIcon(context, "hud/heart/vehicle_full", Icon.HeartFull, xo, yo);
                }
                if (i * 2 + 1 + baseHealth == currentHealth) {
                    DrawSpriteOrIcon(context, "hud/heart/vehicle_half", Icon.HeartHalf, xo, yo);
                }
            }
            yo -= 10;
        }
    }

    /// <summary><c>JumpableVehicleBar</c>: the charge of the riding jump, or the whole bar dimmed while the dash recovers.</summary>
    public static void DrawJumpBar(GuiContext context, LocalPlayer player, IPlayerRideableJumping vehicle, int w, int h) {
        float left = w / 2.0F - 91, top = h - 29;
        // Mth.lerpDiscrete(scale, 0, 182).
        float scale = player.JumpRidingScale;
        int progress = (int)Math.Floor(scale * 181) + (scale > 0.0F ? 1 : 0);
        if (context.Sprites.Sprite(context.Gui, "hud/jump_bar_background", left, top, 182, 5)) {
            if (vehicle.JumpCooldown > 0) {
                context.Sprites.Sprite(context.Gui, "hud/jump_bar_cooldown", left, top, 182, 5);
            }
            else if (progress > 0) {
                context.Sprites.Sprite(context.Gui, "hud/jump_bar_progress", left, top, 182, 5, fraction: progress / 182.0F);
            }
            return;
        }
        context.Gui.Rect(left, top, 182, 5, 0xFF000000);
        context.Gui.Rect(left + 1, top + 1, 180, 3, vehicle.JumpCooldown > 0 ? 0xFF505050 : 0xFF202020);
        if (vehicle.JumpCooldown <= 0) {
            context.Gui.Rect(left + 1, top + 1, 180 * progress / 182.0F, 3, 0xFF40A0FF);
        }
    }

    private static void DrawSpriteOrIcon(GuiContext context, string sprite, Icon fallback, float x, float y) {
        if (!context.Sprites.Sprite(context.Gui, sprite, x, y, 9, 9)) {
            DrawIcon(context, fallback, x, y);
        }
    }

    private static void DrawIcon(GuiContext context, Icon icon, float x, float y) {
        (float u0, float v0, float u1, float v1) = context.Icons.Uv(icon);
        context.Gui.Textured(context.Icons.Texture, x, y, HudIcons.Size, HudIcons.Size, u0, v0, u1, v1);
    }
}
