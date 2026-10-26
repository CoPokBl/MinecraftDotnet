using ClientLib.Inventory;
using Minecraft;
using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib.Testing.Inventory;

/// <summary>
/// Expected values are what vanilla's client hashes the same component values to, printed by
/// Conformance/componenthash.sh. A wrong hash only makes the server resend a slot, so nothing else
/// would notice.
/// </summary>
public class ComponentHasherTest {
    [OneTimeSetUp]
    public void InitialiseRegistry() {
        _ = VanillaRegistry.Data;
    }

    private static int? Hash(IDataComponent component, object value) {
        return ComponentHasher.Hash(component, value, VanillaRegistry.Data);
    }

    [Test]
    public void Integers() {
        Assert.Multiple(() => {
            Assert.That(Hash(DataComponent.Damage, 5), Is.EqualTo(645064431));
            Assert.That(Hash(DataComponent.Damage, 0), Is.EqualTo(-2146075228));
            Assert.That(Hash(DataComponent.MaxStackSize, 16), Is.EqualTo(1769065625));
            Assert.That(Hash(DataComponent.RepairCost, 3), Is.EqualTo(-499649379));
        });
    }

    [Test]
    public void BooleanAndUnit() {
        Assert.Multiple(() => {
            Assert.That(Hash(DataComponent.EnchantmentGlintOverride, true), Is.EqualTo(-1019818302));
            Assert.That(Hash(DataComponent.Unbreakable, default(None)), Is.EqualTo(-982207288));
        });
    }

    [Test]
    public void Text() {
        Assert.Multiple(() => {
            Assert.That(Hash(DataComponent.CustomName, TextComponent.Text("Bob")), Is.EqualTo(-378510004));
            Assert.That(Hash(DataComponent.CustomName, TextComponent.Text("Bob").WithColor(TextColor.Red).WithBold()), Is.EqualTo(396895550));
        });
    }

    /// <summary>An identifier component as read off the wire, which a container click hashes as its id string.</summary>
    [Test]
    public void IdentifiersReadFromTheWire() {
        Assert.Multiple(() => {
            foreach (IDataComponent component in new IDataComponent[] { DataComponent.ItemModel, DataComponent.TooltipStyle, DataComponent.NoteBlockSound }) {
                object value = component.ReadData(new DataReader(new DataWriter().WriteString("mapmaker:thing").ToArray()), VanillaRegistry.Data);
                Assert.That(value, Is.EqualTo(Identifier.Parse("mapmaker:thing")), component.ToString());
                Assert.That(Hash(component, value), Is.EqualTo((int)ComponentHasher.Hash(new NBT.Tags.StringTag("mapmaker:thing"))), component.ToString());
            }
        });
    }

    [Test]
    public void ColourAndEnchantments() {
        Assert.Multiple(() => {
            Assert.That(Hash(DataComponent.DyedColor, TextColor.FromDecimal(0x123456)), Is.EqualTo(287990503));
            Assert.That(Hash(DataComponent.Enchantments, new[] { (Enchantment.Sharpness, 3), (Enchantment.Unbreaking, 2) }), Is.EqualTo(635402762));
        });
    }
}
