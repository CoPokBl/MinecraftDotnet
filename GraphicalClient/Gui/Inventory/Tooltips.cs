using ClientLib;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace GraphicalClient.Gui.Inventory;

/// <summary>What hovering an item shows: its name, then enchantments, lore and durability.</summary>
public static class Tooltips {
    /// <summary>The first line, <c>ItemStack.getStyledHoverName</c>.</summary>
    public static List<TextRun> Name(ItemStack stack) => TextFlattener.Flatten(ItemNames.StyledHoverName(stack));

    public static List<List<TextRun>> Lines(ItemStack stack) {
        List<List<TextRun>> lines = [Name(stack)];
        if (stack.Has(DataComponent.Enchantments)) {
            foreach ((IEnchantment enchantment, int level) in stack.Get(DataComponent.Enchantments)) {
                lines.Add([new TextRun(EnchantmentName(enchantment, level), 0xAAAAAA)]);
            }
        }
        if (stack.Has(DataComponent.StoredEnchantments)) {
            foreach ((IEnchantment enchantment, int level) in stack.Get(DataComponent.StoredEnchantments)) {
                lines.Add([new TextRun(EnchantmentName(enchantment, level), 0xAAAAAA)]);
            }
        }
        if (stack.Has(DataComponent.Lore)) {
            foreach (TextComponent line in stack.Get(DataComponent.Lore)) {
                // ItemLore.LORE_STYLE is merged under the line, so the line's own style wins.
                lines.Add(TextFlattener.Flatten(TextComponent.Empty().With(line).WithColor(TextColor.DarkPurple).WithItalic()));
            }
        }
        if (stack.Has(DataComponent.Damage) && stack.Has(DataComponent.MaxDamage) && stack.Get(DataComponent.Damage) > 0) {
            int max = stack.Get(DataComponent.MaxDamage);
            lines.Add([new TextRun($"Durability: {max - stack.Get(DataComponent.Damage)} / {max}", 0xFFFFFF)]);
        }
        return lines;
    }

    private static string EnchantmentName(IEnchantment enchantment, int level) {
        string name = Translations.Get("enchantment." + enchantment.Identifier.Namespace + "." + enchantment.Identifier.Key) ?? enchantment.Identifier.Key;
        return level == 1 && enchantment.Identifier.Key.EndsWith("curse") ? name : $"{name} {Roman(level)}";
    }

    private static string Roman(int value) => value switch {
        1 => "I", 2 => "II", 3 => "III", 4 => "IV", 5 => "V", 6 => "VI", 7 => "VII", 8 => "VIII", 9 => "IX", 10 => "X",
        _ => value.ToString()
    };

    /// <summary>
    /// <c>GuiGraphicsExtractor.tooltip</c>: draws the box next to the cursor, kept on screen. An item's
    /// tooltip image goes after its name, as <c>setTooltipForNextFrame</c> puts it.
    /// </summary>
    public static void Draw(GuiContext context, List<List<TextRun>> lines, float mouseX, float mouseY, ITooltipImage? image = null) {
        int components = lines.Count + (image == null ? 0 : 1);
        if (components == 0) {
            return;
        }
        int width = 0, height = components == 1 ? -2 : 0;
        for (int i = 0; i < components; i++) {
            (int w, int h) = Size(context, lines, image, i);
            width = Math.Max(width, w);
            height += h;
        }
        float x = mouseX + 12, y = mouseY - 12;
        if (x + width + 4 > context.Width) {
            x = mouseX - 16 - width;
        }
        y = Math.Clamp(y, 4, Math.Max(4, context.Height - height - 4));

        context.Gui.Rect(x - 3, y - 4, width + 6, height + 8, 0xF0100010);
        context.Gui.Rect(x - 4, y - 3, width + 8, height + 6, 0xF0100010);
        context.Gui.Rect(x - 3, y - 3, width + 6, 1, 0x805000FF);
        context.Gui.Rect(x - 3, y + height + 2, width + 6, 1, 0x80280070);
        context.Gui.Rect(x - 3, y - 2, 1, height + 4, 0x805000FF);
        context.Gui.Rect(x + width + 2, y - 2, 1, height + 4, 0x80280070);

        float lineY = y;
        for (int i = 0; i < components; i++) {
            if (Component(lines, image, i) is { } line) {
                context.Text.Draw(line, x, lineY);
            }
            lineY += Size(context, lines, image, i).Height + (i == 0 ? 2 : 0);
        }
        lineY = y;
        for (int i = 0; i < components; i++) {
            if (image != null && i == 1) {
                image.Draw(context, x, lineY, width);
            }
            lineY += Size(context, lines, image, i).Height + (i == 0 ? 2 : 0);
        }
    }

    /// <summary>The text line at a component's place, null where the image is.</summary>
    private static List<TextRun>? Component(List<List<TextRun>> lines, ITooltipImage? image, int index) =>
        image == null || index == 0 ? lines[index] : index == 1 ? null : lines[index - 1];

    private static (int Width, int Height) Size(GuiContext context, List<List<TextRun>> lines, ITooltipImage? image, int index) =>
        Component(lines, image, index) is { } line ? (context.Text.Width(line), 10) : (image!.Width, image.Height(context));
}

/// <summary><c>ClientTooltipComponent</c> for an item's <c>getTooltipImage</c>: something drawn into a tooltip besides text.</summary>
public interface ITooltipImage {
    int Width { get; }

    int Height(GuiContext context);

    /// <summary><c>extractImage</c>: <paramref name="tooltipWidth"/> is the whole tooltip's.</summary>
    void Draw(GuiContext context, float x, float y, int tooltipWidth);

    /// <summary><c>showTooltipWithItemInHand</c>: shown over the slot while the cursor holds something.</summary>
    bool ShowTooltipWithItemInHand { get; }
}
