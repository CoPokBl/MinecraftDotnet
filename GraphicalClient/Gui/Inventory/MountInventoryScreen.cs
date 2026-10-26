using ClientLib;
using ClientLib.Inventory;
using Slot = ClientLib.Inventory.Slot;

namespace GraphicalClient.Gui.Inventory;

/// <summary>
/// <c>AbstractMountInventoryScreen</c> as <c>HorseInventoryScreen</c> and <c>NautilusInventoryScreen</c>
/// draw it: the saddle and armour slots only where the mount can use them, and the chest columns a
/// donkey, mule or llama carries.
/// </summary>
public sealed class MountInventoryScreen(MinecraftClient client, MountInventoryMenu menu) : ContainerScreen(client, menu) {
    protected override string PackBackground => menu.Nautilus ? "gui/container/nautilus" : "gui/container/horse";

    protected override bool DrawsSlot(Slot slot) => slot is not MountEquipmentSlot { Active: false } && base.DrawsSlot(slot);

    protected override void DrawPackOverlay(GuiContext context) {
        if (!menu.Nautilus && menu.InventoryColumns > 0) {
            context.Sprites.Sprite(context.Gui, "container/horse/chest_slots", Left + 79, Top + 17, 90, 54,
                fraction: menu.InventoryColumns * 18 / 90.0F);
        }
        if (menu.SaddleSlot.Active) {
            context.Sprites.Sprite(context.Gui, "container/slot", Left + 7, Top + 35 - 18, 18, 18);
        }
        if (menu.ArmorSlot.Active) {
            context.Sprites.Sprite(context.Gui, "container/slot", Left + 7, Top + 35, 18, 18);
        }
        DrawMount(context);
    }

    protected override void DrawBackground(GuiContext context) {
        // The black frame the vanilla texture has round the mount.
        context.Gui.Rect(Left + 26, Top + 18, 52, 52, 0xFF000000);
        context.Gui.Rect(Left + 27, Top + 19, 50, 50, 0xFF3A3A3A);
        DrawMount(context);
    }

    private float _xMouse, _yMouse;

    /// <summary>Vanilla records the cursor before drawing, unlike <c>InventoryScreen</c>.</summary>
    public override void Render(GuiContext context, float partialTick) {
        _xMouse = context.MouseX;
        _yMouse = context.MouseY;
        base.Render(context, partialTick);
    }

    private void DrawMount(GuiContext context) {
        if (menu.Mount is { } mount) {
            InventoryScreen.ExtractEntityInInventoryFollowsMouse(context, Left + 26, Top + 18, Left + 78, Top + 70, 17, 0.25F, _xMouse, _yMouse, mount);
        }
    }
}
