using ClientLib;
using ClientLib.Interaction;
using Minecraft.Text;

namespace GraphicalClient.Gui;

/// <summary><c>SpectatorGui</c>'s drawing: the menu in the hotbar's place, sliding down as it fades, and the selected item's name.</summary>
public static class SpectatorBar {
    public static void Draw(GuiContext context, MinecraftClient client, int w, int h) {
        SpectatorGui gui = client.SpectatorGui;
        gui.CloseIfFaded();
        if (gui.Menu is not { } menu) {
            return;
        }
        float alpha = gui.HotbarAlpha;
        int screenCenter = w / 2;
        int y = (int)Math.Floor(h - 22.0F * alpha);
        uint white = White(alpha);
        if (context.Sprites.Sprite(context.Gui, "hud/hotbar", screenCenter - 91, y, 182, 22, white)) {
            if (menu.SelectedSlot >= 0) {
                context.Sprites.Sprite(context.Gui, "hud/hotbar_selection", screenCenter - 91 - 1 + menu.SelectedSlot * 20, y - 1, 24, 23, white);
            }
        }
        else {
            context.Gui.Rect(screenCenter - 91, y, 182, 22, (uint)(alpha * 0xC0) << 24);
            if (menu.SelectedSlot >= 0) {
                context.Gui.Rect(screenCenter - 91 - 1 + menu.SelectedSlot * 20, y - 1, 24, 2, white);
            }
        }
        for (int slot = 0; slot < 9; slot++) {
            DrawSlot(context, slot, w / 2 - 90 + slot * 20 + 2, y + 3, alpha, menu.GetItem(slot));
        }
    }

    private static void DrawSlot(GuiContext context, int slot, int x, float y, float alpha, ISpectatorMenuItem item) {
        if (item == SpectatorMenu.EmptySlot) {
            return;
        }
        float brightness = item.IsEnabled ? 1.0F : 0.25F;
        DrawIcon(context, item, x, y, brightness, alpha);
        if (alpha > 0.0F && item.IsEnabled) {
            string key = (slot + 1).ToString();
            context.Text.Draw(key, x + 19 - 2 - context.Text.Width(key), (int)y + 6 + 3, White(alpha));
        }
    }

    /// <summary>
    /// <c>SpectatorMenuItem.extractIcon</c>. A player's face needs their skin in the GUI, which this client
    /// does not draw there, so a player shows as a tile with their initial.
    /// </summary>
    private static void DrawIcon(GuiContext context, ISpectatorMenuItem item, float x, float y, float brightness, float alpha) {
        uint tint = (uint)(alpha * 255) << 24 | (uint)(brightness * 255) * 0x010101;
        string? sprite = item.Icon switch {
            SpectatorIcon.Close => "spectator/close",
            SpectatorIcon.ScrollLeft => "spectator/scroll_left",
            SpectatorIcon.ScrollRight => "spectator/scroll_right",
            SpectatorIcon.TeleportToPlayer => "spectator/teleport_to_player",
            SpectatorIcon.TeleportToTeam => "spectator/teleport_to_team",
            _ => null
        };
        if (sprite != null) {
            if (!context.Sprites.Sprite(context.Gui, sprite, x, y, 16, 16, tint)) {
                context.Gui.Rect(x + 2, y + 2, 12, 12, tint & 0xFF808080);
            }
            return;
        }
        PlayerListEntry? player = item switch {
            PlayerMenuItem playerItem => playerItem.Player,
            TeleportToTeamMenuCategory.TeamSelectionItem team => team.IconPlayer,
            _ => null
        };
        if (item is TeleportToTeamMenuCategory.TeamSelectionItem { Team.Colour: { } colour } && (int)colour < 16
            && StringDecomposer.LegacyColour("0123456789abcdef"[(int)colour]) is { } rgb) {
            uint r = (uint)((rgb >> 16 & 0xFF) * brightness), g = (uint)((rgb >> 8 & 0xFF) * brightness), b = (uint)((rgb & 0xFF) * brightness);
            context.Gui.Rect(x + 1, y + 1, 14, 14, 0xFF000000 | r << 16 | g << 8 | b);
        }
        if (player != null) {
            context.Gui.Rect(x + 2, y + 2, 12, 12, tint & 0xFF606060);
            context.Text.DrawCentred(player.Name[..1].ToUpperInvariant(), x + 8, y + 4, tint);
        }
    }

    /// <summary><c>SpectatorGui.extractAction</c>: the selected item's name, or the category's prompt.</summary>
    public static void DrawAction(GuiContext context, MinecraftClient client, int w, int h) {
        SpectatorGui gui = client.SpectatorGui;
        float alpha = gui.HotbarAlpha;
        if (!(alpha > 0.0F) || gui.Menu is not { } menu) {
            return;
        }
        ISpectatorMenuItem item = menu.SelectedItem;
        TextComponent action = item == SpectatorMenu.EmptySlot ? menu.SelectedCategory.Prompt : item.Name;
        IReadOnlyList<TextRun> runs = TextFlattener.Flatten(action);
        int x = (w - context.Text.Width(runs)) / 2;
        context.Text.Draw(runs, x, h - 35, (byte)(alpha * 255));
    }

    private static uint White(float alpha) => (uint)(alpha * 255) << 24 | 0xFFFFFF;
}
