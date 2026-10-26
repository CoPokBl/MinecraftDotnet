using System.Text.Json;
using ManagedServer.Loot;
using ManagedServer.Terrain.Data;
using Minecraft.Data.Generated;
using Minecraft.Data.Loot;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Blocks;

/// <summary>
/// The parts of the table format the vanilla tables do not reach: holders named by id, a modifier on
/// a composite entry, and the forms the codec refuses.
/// </summary>
[TestFixture]
public class LootTableParserTest {
    private static readonly MinecraftRegistry Registry = VanillaRegistry.Data;

    private string _pack = null!;

    [SetUp]
    public void SetUp() {
        _pack = Path.Combine(Path.GetTempPath(), "loot-parser-" + Guid.NewGuid().ToString("N"));
        Write("predicate/always.json", """{ "type": "minecraft:survives_explosion" }""");
        Write("predicate/self.json", """{ "type": "minecraft:any_of", "terms": "minecraft:self" }""");
        Write("item_modifier/three.json", """{ "type": "minecraft:set_count", "count": 3 }""");
        Write("item_modifier/both.json", """[ "minecraft:three", { "type": "minecraft:set_count", "count": 1, "add": true } ]""");
        Write("context_int_provider/two.json", "2");
    }

    [TearDown]
    public void TearDown() {
        Directory.Delete(_pack, true);
    }

    private void Write(string path, string json) {
        string full = Path.Combine(_pack, "data", "minecraft", path);
        Directory.CreateDirectory(Path.GetDirectoryName(full)!);
        File.WriteAllText(full, json);
    }

    private ItemStack[] Roll(string table) {
        LootReferences references = LootReferences.Load(new DirectoryDatapack(_pack));
        using JsonDocument document = JsonDocument.Parse(table);
        LootTable parsed = LootTableParser.Parse(document.RootElement, "test:table", references);
        return parsed.GetRandomItems(new LootContext(Block.Stone, Vec3<int>.Zero, new LegacyRandomSource(1), Registry));
    }

    private static string Pool(string entry, string extra = "") =>
        $$"""{ "type": "minecraft:block", "pools": [ { "rolls": 1, {{extra}} "entries": [ {{entry}} ] } ] }""";

    [Test]
    public void ResolvesAPredicateById() {
        ItemStack[] items = Roll(Pool("""{ "type": "minecraft:item", "name": "minecraft:stone", "condition": "minecraft:always" }"""));
        Assert.That(items, Has.Length.EqualTo(1));
    }

    [Test]
    public void ResolvesAModifierListThroughAnotherModifier() {
        ItemStack[] items = Roll(Pool("""{ "type": "minecraft:item", "name": "minecraft:stone", "modifier": "minecraft:both" }"""));
        Assert.That(items[0].Count, Is.EqualTo(4));
    }

    [Test]
    public void ResolvesAnIntProviderById() {
        ItemStack[] items = Roll(Pool("""{ "type": "minecraft:item", "name": "minecraft:stone" }""").Replace("\"rolls\": 1", "\"rolls\": \"minecraft:two\""));
        Assert.That(items, Has.Length.EqualTo(2));
    }

    [Test]
    public void AppliesAnAlternativesModifierAfterTheChildsOwn() {
        ItemStack[] items = Roll(Pool("""
            { "type": "minecraft:alternatives",
              "modifier": { "type": "minecraft:set_count", "count": 1, "add": true },
              "children": [ { "type": "minecraft:item", "name": "minecraft:stone", "modifier": "minecraft:three" } ] }
            """));
        Assert.That(items[0].Count, Is.EqualTo(4));
    }

    [Test]
    public void ReadsASingleTermAsASet() {
        ItemStack[] items = Roll(Pool("""
            { "type": "minecraft:item", "name": "minecraft:stone",
              "condition": { "type": "minecraft:any_of", "terms": "minecraft:always" } }
            """));
        Assert.That(items, Has.Length.EqualTo(1));
    }

    [Test]
    public void MatchBlockReadsAList() {
        ItemStack[] items = Roll(Pool("""
            { "type": "minecraft:item", "name": "minecraft:stone",
              "condition": { "type": "minecraft:match_block", "blocks": [ "minecraft:dirt", "minecraft:stone" ] } }
            """));
        Assert.That(items, Has.Length.EqualTo(1));
    }

    [Test]
    public void RefusesAConditionList() {
        Assert.Throws<InvalidOperationException>(() => Roll(Pool("""
            { "type": "minecraft:item", "name": "minecraft:stone", "condition": [ "minecraft:always" ] }
            """)));
    }

    [Test]
    public void RefusesABareLimit() {
        Assert.Throws<UnportedLootException>(() => Roll(Pool("""
            { "type": "minecraft:item", "name": "minecraft:stone", "modifier": { "type": "minecraft:limit_count", "limit": 2 } }
            """)));
    }

    [Test]
    public void RefusesAPredicateThatNamesItself() {
        Assert.Throws<InvalidOperationException>(() => Roll(Pool("""
            { "type": "minecraft:item", "name": "minecraft:stone", "condition": "minecraft:self" }
            """)));
    }
}
