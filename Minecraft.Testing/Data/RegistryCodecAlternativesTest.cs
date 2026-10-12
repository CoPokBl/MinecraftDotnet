using Minecraft.Data.Biomes;
using Minecraft.Data.Dialogs;
using Minecraft.Data.DimensionType;
using Minecraft.Data.Enchantments;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated;
using Minecraft.Data.Instrument;
using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Testing.Data;

/// <summary>
/// The forms vanilla's codecs accept beyond the one we write, which is what a server running an
/// older version behind a translating proxy sends. A round trip through our own writer only ever
/// produces the one form, so each alternative is built by hand here.
/// </summary>
public class RegistryCodecAlternativesTest {
    [OneTimeSetUp]
    public void InitialiseRegistry() {
        _ = VanillaRegistry.Data;
    }

    private static MinecraftRegistry Reg => VanillaRegistry.Data;

    /// <summary>The compound with <paramref name="key"/> set to <paramref name="value"/>, added or replaced.</summary>
    private static CompoundTag With(INbtTag tag, string key, INbtTag value) {
        List<(string, INbtTag)> children = ((CompoundTag)tag).Children.Where(c => c.key != key).ToList();
        children.Add((key, value));
        return new CompoundTag(children.ToArray());
    }

    // ------------------------------------------------------------------ NbtOps numbers

    [Test]
    public void AnyNumericTagReadsAsAnyNumber() {
        INbtTag[] ones = [new ByteTag(1), new ShortTag(1), new IntegerTag(1), new LongTag(1), new FloatTag(1), new DoubleTag(1)];
        Assert.Multiple(() => {
            foreach (INbtTag one in ones) {
                Assert.That(one.AsInt(), Is.EqualTo(1), one.GetType().Name);
                Assert.That(one.AsLong(), Is.EqualTo(1L), one.GetType().Name);
                Assert.That(one.AsFloat(), Is.EqualTo(1.0F), one.GetType().Name);
                Assert.That(one.AsDouble(), Is.EqualTo(1.0), one.GetType().Name);
                Assert.That(one.AsBool(), Is.True, one.GetType().Name);
            }
        });
    }

    [Test]
    public void NarrowingFollowsJava() {
        Assert.Multiple(() => {
            Assert.That(new DoubleTag(2.9).AsInt(), Is.EqualTo(2));
            Assert.That(new DoubleTag(-2.9).AsInt(), Is.EqualTo(-2));
            Assert.That(new DoubleTag(1e20).AsInt(), Is.EqualTo(int.MaxValue));
            Assert.That(new FloatTag(float.NaN).AsInt(), Is.EqualTo(0));
            Assert.That(new LongTag(0x1_0000_0005L).AsInt(), Is.EqualTo(5));
            Assert.That(new IntegerTag(0x1FF).AsByte(), Is.EqualTo((sbyte)-1));
            Assert.That(new DoubleTag(0.25).AsBool(), Is.True);
            Assert.That(new ByteTag(0).AsBool(), Is.False);
        });
    }

    [Test]
    public void AStringIsNotANumber() {
        Assert.Throws<InvalidCastException>(() => new StringTag("1").AsInt());
    }

    [Test]
    public void ArrayTagsReadAsLists() {
        Assert.Multiple(() => {
            Assert.That(new ArrayTag<int>(3, 4).AsList().Select(t => t.AsInt()), Is.EqualTo(new[] { 3, 4 }));
            Assert.That(new ArrayTag<sbyte>(1, 0).AsList().Select(t => t.AsBool()), Is.EqualTo(new[] { true, false }));
            Assert.That(new ArrayTag<long>(7L).AsList().Select(t => t.AsLong()), Is.EqualTo(new[] { 7L }));
        });
    }

    [Test]
    public void AMixedListIsUnwrapped() {
        ListTag mixed = new(new CompoundTag(("", new StringTag("a"))), new CompoundTag(("text", new StringTag("b"))));
        INbtTag[] elements = mixed.AsList();
        Assert.Multiple(() => {
            Assert.That(elements[0], Is.InstanceOf<StringTag>());
            Assert.That(elements[1], Is.InstanceOf<CompoundTag>());
        });
    }

    // ------------------------------------------------------------------ colours

    [Test]
    public void BiomeColourReadsFromEveryForm() {
        INbtTag plains = Biome.Plains.ToNbt();
        INbtTag effects = ((CompoundTag)plains)["effects"]!;
        int expected = Biome.Plains.Effects.WaterColor;

        INbtTag[] forms = [
            new StringTag(PackedColor.ToRgbString(expected)),
            new IntegerTag(expected),
            new ListTag(new FloatTag((expected >> 16 & 0xFF) / 255.0F), new FloatTag((expected >> 8 & 0xFF) / 255.0F),
                new FloatTag((expected & 0xFF) / 255.0F))
        ];

        Assert.Multiple(() => {
            foreach (INbtTag form in forms) {
                CompoundTag biome = With(plains, "effects", With(effects, "water_color", form));
                IBiome read = IBiome.FromNbt("minecraft:plains", biome, Reg);
                Assert.That(read.Effects.WaterColor, Is.EqualTo(expected), form.GetType().Name);
            }
        });
    }

    [Test]
    public void OptionalBiomeColoursReadFromAnInt() {
        CompoundTag effects = (CompoundTag)new BiomeSpecialEffects(0x3F76E4).ToNbt();
        effects = With(With(effects, "grass_color", new IntegerTag(0x91BD59)), "foliage_color", new IntegerTag(0x77AB2F));
        BiomeSpecialEffects read = BiomeSpecialEffects.FromNbt(effects);
        Assert.Multiple(() => {
            Assert.That(read.GrassColor, Is.EqualTo(0x91BD59));
            Assert.That(read.FoliageColor, Is.EqualTo(0x77AB2F));
        });
    }

    [Test]
    public void ColourVectorsUseAs8BitChannel() {
        Assert.Multiple(() => {
            // Mth.floor(0.5F * 255.0F) is 127, not the 128 rounding would give.
            Assert.That(PackedColor.RgbFromNbt(new ListTag(new FloatTag(1), new FloatTag(0.5F), new FloatTag(0))),
                Is.EqualTo(unchecked((int)0xFFFF7F00)));
            Assert.That(PackedColor.ArgbFromNbt(new ListTag(new FloatTag(1), new FloatTag(0), new FloatTag(0), new FloatTag(0.5F))),
                Is.EqualTo(0x7FFF0000));
            Assert.That(PackedColor.StringArgbFromNbt(new IntegerTag(0x12345678)), Is.EqualTo(0x12345678));
        });
    }

    [Test]
    public void AnRgbAttributeReadsFromAnInt() {
        EnvironmentAttributeValue value = EnvironmentAttributeValue.FromNbt(
            EnvironmentAttributeValueKind.RgbColor, new IntegerTag(0x78A7FF), Reg);
        Assert.That(value, Is.EqualTo(new EnvironmentAttributeValue.RgbColor(0x78A7FF)));
    }

    [Test]
    public void ATriStateReadsFromABoolean() {
        Assert.Multiple(() => {
            Assert.That(EnvironmentAttributeValue.FromNbt(EnvironmentAttributeValueKind.TriState, new ByteTag(1), Reg),
                Is.EqualTo(new EnvironmentAttributeValue.TriStateValue(TriState.True)));
            Assert.That(EnvironmentAttributeValue.FromNbt(EnvironmentAttributeValueKind.TriState, new StringTag("default"), Reg),
                Is.EqualTo(new EnvironmentAttributeValue.TriStateValue(TriState.Default)));
        });
    }

    // ------------------------------------------------------------------ holder sets

    [Test]
    public void SupportedItemsReadsAsATagAListOrOneId() {
        INbtTag sharpness = Enchantment.Sharpness.ToNbt();

        (INbtTag Form, HolderSet Expected)[] forms = [
            (new StringTag("#minecraft:enchantable/sharp_weapon"), new HolderSet.Tag("minecraft:enchantable/sharp_weapon")),
            (new ListTag(new StringTag("minecraft:diamond_sword"), new StringTag("minecraft:iron_sword")),
                new HolderSet.Direct(["minecraft:diamond_sword", "minecraft:iron_sword"])),
            (new StringTag("minecraft:diamond_sword"), new HolderSet.Direct(["minecraft:diamond_sword"]))
        ];

        Assert.Multiple(() => {
            foreach ((INbtTag form, HolderSet expected) in forms) {
                CompoundTag tag = With(With(sharpness, "supported_items", form), "primary_items", form);
                IEnchantment read = IEnchantment.FromNbt("minecraft:sharpness", tag, Reg);
                Assert.That(read.SupportedItems, Is.EqualTo(expected));
                Assert.That(read.PrimaryItems, Is.EqualTo(expected));
                Assert.That(read.ToNbt()["supported_items"], Is.EqualTo(form), "written back as vanilla writes it");
            }
        });
    }

    [Test]
    public void ExclusiveSetReadsAsAList() {
        CompoundTag tag = With(Enchantment.Sharpness.ToNbt(), "exclusive_set",
            new ListTag(new StringTag("minecraft:smite"), new StringTag("minecraft:bane_of_arthropods")));
        IEnchantment read = IEnchantment.FromNbt("minecraft:sharpness", tag, Reg);
        Assert.That(read.ExclusiveSet, Is.EqualTo(new HolderSet.Direct(["minecraft:smite", "minecraft:bane_of_arthropods"])));
    }

    [Test]
    public void InfiniburnReadsAsAList() {
        CompoundTag tag = With(DimensionType.Overworld.ToNbt(), "infiniburn",
            new ListTag(new StringTag("minecraft:netherrack")));
        IDimensionType read = IDimensionType.FromNbt("minecraft:overworld", tag, Reg);
        Assert.That(read.InfiniBurn, Is.EqualTo(new HolderSet.Direct(["minecraft:netherrack"])));
    }

    // ------------------------------------------------------------------ numbers in records

    [Test]
    public void InstrumentFloatsReadFromInts() {
        INbtTag horn = Instrument.PonderGoatHorn.ToNbt();
        CompoundTag tag = With(With(horn, "use_duration", new IntegerTag(7)), "range", new IntegerTag(256));
        IInstrument read = IInstrument.FromNbt("minecraft:ponder_goat_horn", tag, Reg);
        Assert.Multiple(() => {
            Assert.That(read.UseDuration, Is.EqualTo(7.0F));
            Assert.That(read.Range, Is.EqualTo(256.0F));
        });
    }

    [Test]
    public void BooleansReadFromAnyNumber() {
        CompoundTag tag = With(With(DimensionType.Overworld.ToNbt(), "has_skylight", new ByteTag(1)),
            "has_ceiling", new IntegerTag(0));
        tag = With(tag, "monster_spawn_light_level", new ByteTag(7));
        IDimensionType read = IDimensionType.FromNbt("minecraft:overworld", tag, Reg);
        Assert.Multiple(() => {
            Assert.That(read.HasSkyLight, Is.True);
            Assert.That(read.HasCeiling, Is.False);
            Assert.That(read.MonsterSpawnLightLevel!.Value1, Is.EqualTo(7));
        });
    }

    [Test]
    public void ABiomeReadsWithByteAndIntPrimitives() {
        CompoundTag tag = With(With(Biome.Plains.ToNbt(), "has_precipitation", new ByteTag(1)),
            "temperature", new IntegerTag(1));
        IBiome read = IBiome.FromNbt("minecraft:plains", tag, Reg);
        Assert.Multiple(() => {
            Assert.That(read.HasPrecipitation, Is.True);
            Assert.That(read.Temperature, Is.EqualTo(1.0F));
        });
    }

    // ------------------------------------------------------------------ text

    [Test]
    public void AListIsATextComponent() {
        TextComponent read = TextComponent.FromTag(new ListTag(new StringTag("a"), new StringTag("b")));
        Assert.Multiple(() => {
            Assert.That(read.Content.Fields[0].Tag.GetString(), Is.EqualTo("a"));
            Assert.That(read.Children, Has.Count.EqualTo(1));
            Assert.That(read.Children[0].TryCollapseToString(), Is.EqualTo("b"));
        });
    }

    [Test]
    public void ShadowColourReadsAnArgbIntOrVector() {
        CompoundTag withInt = new(("text", new StringTag("x")), ("shadow_color", new IntegerTag(unchecked((int)0xFF102030))));
        CompoundTag withVector = new(("text", new StringTag("x")), ("shadow_color",
            new ListTag(new FloatTag(1), new FloatTag(0), new FloatTag(0), new FloatTag(1))));
        Assert.Multiple(() => {
            Assert.That(TextComponent.FromTag(withInt).ShadowColor, Is.EqualTo(TextColor.Rgb(0x10, 0x20, 0x30)));
            Assert.That(TextComponent.FromTag(withVector).ShadowColor, Is.EqualTo(TextColor.Rgb(0xFF, 0, 0)));
        });
    }

    [Test]
    public void TextColourHexTakesAnyNumberOfDigits() {
        Assert.That(TextColor.Parse("#FF"), Is.EqualTo(TextColor.Rgb(0, 0, 0xFF)));
    }

    // ------------------------------------------------------------------ dialogs

    [Test]
    public void ADialogListTakesInlineDialogs() {
        CompoundTag notice = new(("type", new StringTag("minecraft:notice")), ("title", new StringTag("Hi")));
        CompoundTag list = new(("type", new StringTag("minecraft:dialog_list")), ("title", new StringTag("List")),
            ("dialogs", notice));
        DialogListDialog read = (DialogListDialog)IDialog.FromNbt("minecraft:test", list, Reg);
        Assert.Multiple(() => {
            Assert.That(read.Dialogs.IsValue2, Is.True);
            Assert.That(read.Dialogs.Value2!, Has.Length.EqualTo(1));
            Assert.That(read.Dialogs.Value2![0], Is.InstanceOf<NoticeDialog>());
            Assert.That(((CompoundTag)((IDialog)read).ToNbt())["dialogs"], Is.EqualTo(read.Dialogs.Value2![0].ToNbt()));
        });
    }

    [Test]
    public void ADialogListStillTakesATag() {
        CompoundTag list = new(("type", new StringTag("minecraft:dialog_list")), ("title", new StringTag("List")),
            ("dialogs", new StringTag("#minecraft:pause_screen_additions")));
        DialogListDialog read = (DialogListDialog)IDialog.FromNbt("minecraft:test", list, Reg);
        Assert.That(read.Dialogs.Value1, Is.EqualTo(new HolderSet.Tag("minecraft:pause_screen_additions")));
    }

    [Test]
    public void DialogShorthandsRead() {
        CompoundTag body = new(("type", new StringTag("minecraft:item")), ("item", new StringTag("minecraft:stone")),
            ("description", new StringTag("A stone")));
        DialogBody.ItemBody item = (DialogBody.ItemBody)DialogBody.FromNbt(body);

        CompoundTag input = new(("type", new StringTag("minecraft:single_option")), ("key", new StringTag("k")),
            ("label", new StringTag("L")), ("options", new ListTag(new StringTag("a"), new StringTag("b"))));
        DialogInput option = DialogInput.FromNbt(input);

        Assert.Multiple(() => {
            Assert.That(item.Item, Is.EqualTo(new DialogItem("minecraft:stone")));
            Assert.That(item.Description!.Contents.TryCollapseToString(), Is.EqualTo("A stone"));
            Assert.That(item.Description.Width, Is.EqualTo(200));
            Assert.That(((InputControl.SingleOption)option.Control).Options.Select(o => o.Id), Is.EqualTo(new[] { "a", "b" }));
        });
    }

    // ------------------------------------------------------------------ what we write is unchanged

    [Test]
    public void EverySynchronisedRegistryRoundTripsByteForByte() {
        MinecraftRegistry copy = VanillaRegistry.Data.Clone();
        Assert.Multiple(() => {
            foreach (INbtSerialisableRegistry registry in VanillaRegistry.Data.SubRegistries.OfType<INbtSerialisableRegistry>()) {
                Dictionary<string, INbtTag> written = registry.ToNbt();
                INbtSerialisableRegistry target = copy.SubRegistries.OfType<INbtSerialisableRegistry>()
                    .First(r => r.RegistryId == registry.RegistryId);
                target.LoadNbt(written, copy);
                Dictionary<string, INbtTag> rewritten = target.ToNbt();

                Assert.That(rewritten.Keys, Is.EqualTo(written.Keys), registry.RegistryId.ToString());
                foreach ((string key, INbtTag tag) in written) {
                    Assert.That(rewritten[key].Serialise(), Is.EqualTo(tag.Serialise()), $"{registry.RegistryId} {key}");
                }
            }
        });
    }
}
