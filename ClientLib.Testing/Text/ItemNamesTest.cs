using ClientLib.Inventory;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Items;
using Minecraft.Text;

namespace ClientLib.Testing.Text;

/// <summary><c>ItemStack.getStyledHoverName</c> and the book contents the book screens read.</summary>
public class ItemNamesTest {
    private static List<TextRun> Styled(ItemStack stack) => TextFlattener.Flatten(ItemNames.StyledHoverName(stack));

    [Test]
    public void TestCustomNameIsItalicInTheRarityColour() {
        ItemStack stack = new ItemStack(Item.Diamond).With(DataComponent.CustomName, TextComponent.Text("Shiny"));
        Assert.That(Styled(stack), Is.EqualTo(new List<TextRun> { new("Shiny", 0xFFFFFF, Italic: true) }));
    }

    [Test]
    public void TestItemNameIsNotItalic() {
        ItemStack stack = new ItemStack(Item.Diamond).With(DataComponent.ItemName, TextComponent.Text("Gem"));
        Assert.That(Styled(stack), Is.EqualTo(new List<TextRun> { new("Gem", 0xFFFFFF) }));
    }

    [Test]
    public void TestOwnColourBeatsRarity() {
        ItemStack stack = new ItemStack(Item.Diamond)
            .With(DataComponent.CustomName, TextComponent.Text("Red").WithColor(TextColor.Red))
            .With(DataComponent.Rarity, ItemRarity.Epic);
        Assert.That(Styled(stack), Is.EqualTo(new List<TextRun> { new("Red", 0xFF5555, Italic: true) }));
    }

    [Test]
    public void TestEnchantingRaisesRarity() {
        (IEnchantment, int)[] sharpness = [(Enchantment.Sharpness, 1)];
        Assert.That(ItemNames.Rarity(new ItemStack(Item.DiamondSword).With(DataComponent.Enchantments, sharpness)), Is.EqualTo(ItemRarity.Rare));
        Assert.That(ItemNames.Rarity(new ItemStack(Item.DiamondSword).With(DataComponent.Rarity, ItemRarity.Rare).With(DataComponent.Enchantments, sharpness)),
            Is.EqualTo(ItemRarity.Epic));
        Assert.That(Styled(new ItemStack(Item.Diamond).With(DataComponent.Rarity, ItemRarity.Uncommon))[0].Rgb, Is.EqualTo(0xFFFF55));
    }

    [Test]
    public void TestWrittenBookTitleIsTheNameButNotItalic() {
        WrittenBookContentComponent.Data content = new(new WrittenBookContentComponent.Title("T"), "A", 0, [], true);
        ItemStack stack = new ItemStack(Item.WrittenBook).With(DataComponent.WrittenBookContent, content);
        Assert.That(Styled(stack), Is.EqualTo(new List<TextRun> { new("T", 0xFFFFFF) }));
    }

    [Test]
    public void TestBlankWritableBookHasNoPages() {
        ItemStack stack = new(Item.WritableBook);
        Assert.That(BookAccess.WritableContent(stack)?.Contents, Is.Empty);
        Assert.That(BookAccess.FromItem(stack), Is.Empty);
        Assert.That(BookAccess.FromItem(new ItemStack(Item.Book)), Is.Null);
    }

    [Test]
    public void TestWrittenBookPagesWinOverWritable() {
        WrittenBookContentComponent.Data content = new(new WrittenBookContentComponent.Title("T"), "A", 0,
            [new WrittenBookContentComponent.Page(TextComponent.Text("one")), new WrittenBookContentComponent.Page(TextComponent.Text("two"))], true);
        List<TextComponent>? pages = BookAccess.FromItem(new ItemStack(Item.WrittenBook).With(DataComponent.WrittenBookContent, content));
        Assert.That(pages!.Select(TextFlattener.Plain), Is.EqualTo(new[] { "one", "two" }));
    }
}
