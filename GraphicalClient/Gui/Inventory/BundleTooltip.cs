using ClientLib;
using ClientLib.Interaction;
using ClientLib.Inventory;
using ClientLib.Maths;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Gui.Inventory;

/// <summary><c>ClientBundleTooltip</c>: a bundle's first items in a grid filled from the bottom right, its selected item's name, and its fill bar.</summary>
public sealed class BundleTooltip(ItemStack[] contents) : ITooltipImage {
    private const int SlotSize = 24, GridWidth = 96, ProgressbarHeight = 13, ProgressbarFillMax = 94, ProgressbarMarginY = 4;

    /// <summary><c>BundleItem.getTooltipImage</c>: null for anything but a bundle, or one whose tooltip hides its contents.</summary>
    public static BundleTooltip? For(ItemStack stack) {
        if (!BundleItem.Is(stack.Type)) {
            return null;
        }
        TooltipDisplayComponent.Info? display = ItemComponents.Get(stack, DataComponent.TooltipDisplay);
        if (display != null && (display.HideTooltip || display.Hidden.Any(c => c.Identifier == DataComponent.BundleContents.Identifier))) {
            return null;
        }
        return BundleContents.Of(stack) is { } contents ? new BundleTooltip(contents) : null;
    }

    public int Width => GridWidth;

    public bool ShowTooltipWithItemInHand => true;

    public int Height(GuiContext context) => contents.Length == 0 ? EmptyDescription(context).Count * 9 + ProgressbarHeight + 8 : ItemGridHeight + ProgressbarHeight + 8;

    private int ItemGridHeight => GridSizeY * SlotSize;

    private int GridSizeY => (SlotCount + 3) / 4;

    private int SlotCount => Math.Min(12, contents.Length);

    private static int ContentXOffset(int tooltipWidth) => (tooltipWidth - GridWidth) / 2;

    private static List<List<TextRun>> EmptyDescription(GuiContext context) =>
        context.Text.Wrap([new TextRun(Text("item.minecraft.bundle.empty.description"), 0xAAAAAA)], GridWidth);

    private static string Text(string key) => Translations.Get(key) ?? key;

    public void Draw(GuiContext context, float x, float y, int tooltipWidth) {
        if (BundleContents.Weight(contents) is not { } weight) {
            return;
        }
        float left = x + ContentXOffset(tooltipWidth);
        if (contents.Length == 0) {
            List<List<TextRun>> description = EmptyDescription(context);
            for (int i = 0; i < description.Count; i++) {
                context.Text.Draw(description[i], left, y + i * 9);
            }
            DrawProgressbar(context, left, y + description.Count * 9 + ProgressbarMarginY, weight);
            return;
        }

        bool isOverflowing = contents.Length > 12;
        int shown = Math.Min(contents.Length, BundleContents.NumberOfItemsToShow(contents));
        float xStartPos = left + GridWidth;
        float yStartPos = y + GridSizeY * SlotSize;
        int slotNumber = 1;
        for (int rowNumber = 1; rowNumber <= GridSizeY; rowNumber++) {
            for (int columnNumber = 1; columnNumber <= 4; columnNumber++) {
                float drawX = xStartPos - columnNumber * SlotSize;
                float drawY = yStartPos - rowNumber * SlotSize;
                if (isOverflowing && columnNumber * rowNumber == 1) {
                    int hidden = contents.Skip(shown).Sum(s => s.Count);
                    context.Text.DrawCentred("+" + hidden, drawX + 12, drawY + 10);
                }
                else if (shown >= slotNumber) {
                    DrawSlot(context, slotNumber, drawX, drawY, shown);
                    slotNumber++;
                }
            }
        }
        DrawSelectedItemTooltip(context, x, y, tooltipWidth);
        DrawProgressbar(context, left, y + ItemGridHeight + ProgressbarMarginY, weight);
    }

    private void DrawSlot(GuiContext context, int slotNumber, float drawX, float drawY, int shown) {
        int itemVisualOrderIndex = shown - slotNumber;
        bool hasHighlight = itemVisualOrderIndex == BundleContents.SelectedItemIndex(contents);
        context.Sprites.Sprite(context.Gui, hasHighlight ? "container/bundle/slot_highlight_back" : "container/bundle/slot_background", drawX, drawY, SlotSize, SlotSize);
        GuiItems.Draw(context, contents[itemVisualOrderIndex], drawX + 4, drawY + 4, slotNumber);
        if (hasHighlight) {
            context.Sprites.Sprite(context.Gui, "container/bundle/slot_highlight_front", drawX, drawY, SlotSize, SlotSize);
        }
    }

    private void DrawSelectedItemTooltip(GuiContext context, float x, float y, int tooltipWidth) {
        if (BundleContents.SelectedItem(contents) is not { } selectedItem) {
            return;
        }
        List<TextRun> name = Tooltips.Name(selectedItem);
        int textWidth = context.Text.Width(name);
        float centerTooltip = x + tooltipWidth / 2 - 12;
        Tooltips.Draw(context, [name], centerTooltip - textWidth / 2, y - 15);
    }

    private static void DrawProgressbar(GuiContext context, float x, float y, Fraction weight) {
        bool full = weight.CompareTo(Fraction.One) >= 0;
        int fill = Math.Clamp(unchecked(weight.Numerator * ProgressbarFillMax) / weight.Denominator, 0, ProgressbarFillMax);
        if (!context.Sprites.NineSliced(context.Gui, full ? "container/bundle/bundle_progressbar_full" : "container/bundle/bundle_progressbar_fill", x + 1, y, fill, ProgressbarHeight, 2)) {
            context.Gui.Rect(x + 1, y, fill, ProgressbarHeight, full ? 0xFFFF5555 : 0xFF7087FF);
        }
        if (!context.Sprites.NineSliced(context.Gui, "container/bundle/bundle_progressbar_border", x, y, GridWidth, ProgressbarHeight, 2)) {
            context.Gui.Rect(x, y, GridWidth, 1, 0xFFFFFFFF);
            context.Gui.Rect(x, y + ProgressbarHeight - 1, GridWidth, 1, 0xFFFFFFFF);
        }
        string? text = weight.CompareTo(Fraction.Zero) == 0 ? Text("item.minecraft.bundle.empty") : full ? Text("item.minecraft.bundle.full") : null;
        if (text != null) {
            context.Text.DrawCentred(text, x + 48, y + 3);
        }
    }
}
