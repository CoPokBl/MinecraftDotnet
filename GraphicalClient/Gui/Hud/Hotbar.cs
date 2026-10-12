using ClientLib;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Gui;

public static class Hotbar {
    public static void Draw(GuiContext context, MinecraftClient client, int w, int h) {
        float x = w / 2.0F - 91, y = h - 22;
        float sx = x - 1 + client.Inventory.SelectedSlot * 20, sy = y - 1;
        if (context.Sprites.Sprite(context.Gui, "hud/hotbar", x, y, 182, 22)) {
            context.Sprites.Sprite(context.Gui, "hud/hotbar_selection", sx, sy, 24, 23);
        }
        else {
            context.Gui.Rect(x, y, 182, 22, 0xC0000000);
            for (int i = 0; i < 9; i++) {
                context.Gui.Rect(x + 1 + i * 20, y + 1, 20, 20, 0x60808080);
                context.Gui.Rect(x + 2 + i * 20, y + 2, 18, 18, 0x80202020);
            }
            context.Gui.Rect(sx, sy, 24, 2, 0xFFFFFFFF);
            context.Gui.Rect(sx, sy + 22, 24, 2, 0xFFFFFFFF);
            context.Gui.Rect(sx, sy, 2, 24, 0xFFFFFFFF);
            context.Gui.Rect(sx + 22, sy, 2, 24, 0xFFFFFFFF);
        }

        // Hud.extractItemHotbar's seeds count from one along the bar and on to the off hand.
        for (int i = 0; i < 9; i++) {
            GuiItems.Draw(context, client.Inventory.Hotbar(i), x + 3 + i * 20, y + 3, i + 1, i == client.Inventory.SelectedSlot ? Hand.MainHand : null);
        }
        ItemStack offhand = client.Inventory.Offhand;
        if (offhand.Count > 0) {
            if (!context.Sprites.Sprite(context.Gui, "hud/hotbar_offhand_left", x - 29, y - 1, 29, 24)) {
                context.Gui.Rect(x - 29, y, 22, 22, 0xC0000000);
            }
            GuiItems.Draw(context, offhand, x - 26, y + 3, 10, Hand.OffHand);
        }
    }
}
