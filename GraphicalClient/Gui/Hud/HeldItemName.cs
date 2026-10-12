using ClientLib;
using ClientLib.Interaction;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;

namespace GraphicalClient.Gui;

/// <summary>
/// The held item's styled name over the hotbar, shown for two seconds whenever the held item or its name
/// changes and fading over the last half second: <c>Hud.toolHighlightTimer</c>.
/// </summary>
public sealed class HeldItemName {
    private ItemStack _lastToolHighlight = ItemStack.Air;
    private int _toolHighlightTimer;
    private long _lastTick = -1;

    /// <summary><c>Hud.tick</c>'s part, run once per client tick however often it is called.</summary>
    public void Tick(MinecraftClient client) {
        if (client.ClientTicks == _lastTick || client.Player == null) {
            return;
        }
        _lastTick = client.ClientTicks;
        ItemStack selected = client.Inventory.MainHand;
        if (ItemComponents.IsEmpty(selected)) {
            _toolHighlightTimer = 0;
        }
        else if (ItemComponents.IsEmpty(_lastToolHighlight) || selected.Type.Identifier != _lastToolHighlight.Type.Identifier
                 || ItemNames.HoverName(selected).ToJsonString() != ItemNames.HoverName(_lastToolHighlight).ToJsonString()) {
            // 40 ticks times notificationDisplayTime, which this client leaves at its default of 1.
            _toolHighlightTimer = 40;
        }
        else if (_toolHighlightTimer > 0) {
            _toolHighlightTimer--;
        }
        _lastToolHighlight = selected;
    }

    /// <summary><c>Hud.extractSelectedItemName</c>, without the backdrop the default text background setting leaves off.</summary>
    public void Draw(GuiContext context, MinecraftClient client, int w, int h) {
        if (_toolHighlightTimer <= 0 || ItemComponents.IsEmpty(_lastToolHighlight)) {
            return;
        }
        List<TextRun> str = TextFlattener.Flatten(ItemNames.StyledHoverName(_lastToolHighlight));
        int strWidth = context.Text.Width(str);
        int x = (w - strWidth) / 2;
        int y = h - 59;
        if (client.Player?.GameMode is not (GameMode.Survival or GameMode.Adventure)) {
            y += 14;
        }
        int alpha = Math.Min((int)(_toolHighlightTimer * 256.0F / 10.0F), 255);
        if (alpha > 0) {
            context.Text.Draw(str, x, y, (byte)alpha);
        }
    }
}
