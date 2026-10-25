using ClientLib;
using ClientLib.Entities.Vehicles;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Attribute = Minecraft.Data.Generated.Attribute;
using Minecraft.Schemas;
using HeartType = GraphicalClient.Gui.HudIcons.HeartType;
using Icon = GraphicalClient.Gui.HudIcons.Icon;

namespace GraphicalClient.Gui;

/// <summary>The bars over the hotbar: experience or the jump bar, hearts, armour, food or the mount's hearts, and air.</summary>
public static class StatusBars {
    private const int MaxAir = 300;

    public static void Draw(GuiContext context, MinecraftClient client, LocalPlayer player, HealthDisplay health, int w, int h) {
        float left = w / 2.0F - 91, right = w / 2.0F + 91;
        float heartsY = h - 39;
        if (player.JumpableVehicle == null) {
            DrawExperienceBar(context, player, left, h - 29);
        }
        DrawLevel(context, player, w / 2.0F, h - 35);

        DrawPlayerHealth(context, client, player, health, left, heartsY);

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

    /// <summary>
    /// <c>Hud.extractPlayerHealth</c>'s armour and hearts. A drop in health blinks the hearts, and the
    /// health before it stays drawn under the new for a second.
    /// </summary>
    private static void DrawPlayerHealth(GuiContext context, MinecraftClient client, LocalPlayer player, HealthDisplay display, float xLeft, float yLineBase) {
        int tickCount = (int)client.ClientTicks;
        int currentHealth = (int)MathF.Ceiling(player.Health);
        bool blink = display.HealthBlinkTime > tickCount && (display.HealthBlinkTime - tickCount) / 3L % 2L == 1L;
        long timeMillis = Environment.TickCount64;
        if (currentHealth < display.LastHealth && player.InvulnerableTime > 0) {
            display.LastHealthTime = timeMillis;
            display.HealthBlinkTime = tickCount + 20;
        }
        else if (currentHealth > display.LastHealth && player.InvulnerableTime > 0) {
            display.LastHealthTime = timeMillis;
            display.HealthBlinkTime = tickCount + 10;
        }
        if (timeMillis - display.LastHealthTime > 1000L) {
            display.DisplayHealth = currentHealth;
            display.LastHealthTime = timeMillis;
        }
        display.LastHealth = currentHealth;
        int oldHealth = display.DisplayHealth;
        display.Random.SetSeed(unchecked(tickCount * 312871));
        float maxHealth = Math.Max((float)player.Attributes.Value(Attribute.MaxHealth), Math.Max(oldHealth, currentHealth));
        int totalAbsorption = (int)MathF.Ceiling(player.Get(EntityDataFields.Player.PlayerAbsorption, 0.0F));
        int numHealthRows = (int)MathF.Ceiling((maxHealth + totalAbsorption) / 2.0F / 10.0F);
        int healthRowHeight = Math.Max(10 - (numHealthRows - 2), 3);
        int heartOffsetIndex = -1;
        if (player.HasEffect(PotionEffectType.Regeneration)) {
            heartOffsetIndex = tickCount % (int)MathF.Ceiling(maxHealth + 5.0F);
        }

        int armour = (int)player.Attributes.Value(Attribute.Armor);
        if (armour > 0) {
            float yLineArmour = yLineBase - (numHealthRows - 1) * healthRowHeight - 10;
            for (int i = 0; i < 10; i++) {
                DrawIcon(context, Filled(i, armour, Icon.ArmourFull, Icon.ArmourHalf) ?? Icon.ArmourEmpty, xLeft + i * 8, yLineArmour);
            }
        }

        DrawHearts(context, client, player, display.Random, xLeft, yLineBase, healthRowHeight, heartOffsetIndex, maxHealth, currentHealth,
            oldHealth, totalAbsorption, blink);
    }

    /// <summary><c>Hud.extractHearts</c>: containers right to left and top down, absorption past the health.</summary>
    private static void DrawHearts(GuiContext context, MinecraftClient client, LocalPlayer player, RandomSource random, float xLeft,
        float yLineBase, int healthRowHeight, int heartOffsetIndex, float maxHealth, int currentHealth, int oldHealth, int absorption, bool blink) {
        HeartType type = HeartTypeFor(player);
        bool isHardcore = client.Hardcore;
        int healthContainerCount = (int)Math.Ceiling(maxHealth / 2.0);
        int absorptionContainerCount = (int)Math.Ceiling(absorption / 2.0);
        int maxHealthHalvesCount = healthContainerCount * 2;
        for (int containerIndex = healthContainerCount + absorptionContainerCount - 1; containerIndex >= 0; containerIndex--) {
            int row = containerIndex / 10;
            int column = containerIndex % 10;
            float xo = xLeft + column * 8;
            float yo = yLineBase - row * healthRowHeight;
            if (currentHealth + absorption <= 4) {
                yo += random.NextInt(2);
            }
            if (containerIndex < healthContainerCount && containerIndex == heartOffsetIndex) {
                yo -= 2;
            }
            DrawContainer(context, isHardcore, blink, xo, yo);
            int halves = containerIndex * 2;
            if (containerIndex >= healthContainerCount) {
                int absorptionHalves = halves - maxHealthHalvesCount;
                if (absorptionHalves < absorption) {
                    DrawHeart(context, type == HeartType.Withered ? type : HeartType.Absorbing, isHardcore, absorptionHalves + 1 == absorption, false, xo, yo);
                }
            }
            if (blink && halves < oldHealth) {
                DrawHeart(context, type, isHardcore, halves + 1 == oldHealth, true, xo, yo);
            }
            if (halves < currentHealth) {
                DrawHeart(context, type, isHardcore, halves + 1 == currentHealth, false, xo, yo);
            }
        }
    }

    /// <summary><c>HeartType.forPlayer</c>.</summary>
    private static HeartType HeartTypeFor(LocalPlayer player) {
        if (player.HasEffect(PotionEffectType.Poison)) {
            return HeartType.Poisoned;
        }
        if (player.HasEffect(PotionEffectType.Wither)) {
            return HeartType.Withered;
        }
        return player.IsFullyFrozen ? HeartType.Frozen : HeartType.Normal;
    }

    private static readonly string[] HeartSpritePrefixes = ["", "poisoned_", "withered_", "absorbing_", "frozen_"];

    private static void DrawContainer(GuiContext context, bool hardcore, bool blink, float x, float y) {
        string sprite = "hud/heart/container" + (hardcore ? "_hardcore" : "") + (blink ? "_blinking" : "");
        if (!context.Sprites.Sprite(context.Gui, sprite, x, y, 9, 9)) {
            DrawUv(context, context.Icons.ContainerUv(hardcore, blink), x, y);
        }
    }

    /// <summary><c>HeartType.getSprite</c>, or this client's art where the pack has no such sprite.</summary>
    private static void DrawHeart(GuiContext context, HeartType type, bool hardcore, bool half, bool blink, float x, float y) {
        string sprite = "hud/heart/" + HeartSpritePrefixes[(int)type] + (hardcore ? "hardcore_" : "") + (half ? "half" : "full") + (blink ? "_blinking" : "");
        if (!context.Sprites.Sprite(context.Gui, sprite, x, y, 9, 9)) {
            DrawUv(context, context.Icons.HeartUv(type, hardcore, half, blink), x, y);
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

    private static void DrawIcon(GuiContext context, Icon icon, float x, float y) => DrawUv(context, context.Icons.Uv(icon), x, y);

    private static void DrawUv(GuiContext context, (float U0, float V0, float U1, float V1) uv, float x, float y) =>
        context.Gui.Textured(context.Icons.Texture, x, y, HudIcons.Size, HudIcons.Size, uv.U0, uv.V0, uv.U1, uv.V1);
}

/// <summary><c>Hud</c>'s memory of the hearts between frames: when they blink, and the health they last showed.</summary>
public sealed class HealthDisplay {
    public int LastHealth { get; set; }
    public int DisplayHealth { get; set; }
    public long LastHealthTime { get; set; }
    public long HealthBlinkTime { get; set; }
    public RandomSource Random { get; } = new LegacyRandomSource(0);
}
