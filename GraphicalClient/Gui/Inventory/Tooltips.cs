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

    /// <summary>Draws the box next to the cursor, kept on screen.</summary>
    public static void Draw(GuiContext context, List<List<TextRun>> lines, float mouseX, float mouseY) {
        if (lines.Count == 0) {
            return;
        }
        int width = lines.Max(l => context.Text.Width(l));
        int height = lines.Count == 1 ? 8 : 10 + (lines.Count - 1) * 10;
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
        for (int i = 0; i < lines.Count; i++) {
            context.Text.Draw(lines[i], x, lineY);
            lineY += i == 0 ? 12 : 10;
        }
    }
}
