using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns <c>data/minecraft/loot_table/blocks/</c> into <c>BlockLootTables.cs</c>, one typed
/// expression per table.
/// <para>
/// Emitted as constructor calls rather than as embedded JSON parsed at start up, which is the trick
/// <see cref="DynamicRegistryCodeGen"/> uses. The tables are read on every block break and a renamed
/// condition upstream has to be a compile error rather than a table that quietly stops applying, so
/// the shape has to survive into the C#.
/// </para>
/// <para>
/// <b>Every unknown member throws.</b> A condition that goes missing reads as an unconditional drop
/// and a function that goes missing reads as a count of one, so neither can be skipped with a
/// warning the way an unimplemented packet is. The vocabulary the block tables actually use is nine
/// conditions, six functions, three entry types and three number providers, and anything outside
/// that list is a version bump to deal with rather than data to ignore.
/// </para>
/// </summary>
public static class LootTableCodeGen {
    /// <summary>Where the datapack writes block tables, below <c>data/minecraft/</c>.</summary>
    private static readonly string[] BlocksFolder = ["loot_table", "blocks"];

    public static void GenerateLootTableCode(JObject _) {
        string folder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft",
            Path.Combine(BlocksFolder));

        if (!Directory.Exists(folder)) {
            throw new DirectoryNotFoundException($"No block loot tables at {folder}.");
        }

        StringBuilder entries = new();
        int count = 0;

        foreach (string file in Directory.EnumerateFiles(folder, "*.json", SearchOption.AllDirectories)
                     .OrderBy(f => f, StringComparer.Ordinal)) {
            // The id is the path below loot_table/, so .../loot_table/blocks/stone.json becomes
            // minecraft:blocks/stone, which is the key Block.getLootTable hands back.
            string relative = Path.GetRelativePath(Path.Combine(CodeGenUtils.VanillaDataDir, "data",
                "minecraft", "loot_table"), file).Replace(Path.DirectorySeparatorChar, '/');
            string id = "minecraft:" + relative[..^".json".Length];

            JObject table = JObject.Parse(File.ReadAllText(file));
            entries.Append(CodeGenUtils.GetIndentation(2))
                .Append('[')
                .Append(Str(id))
                .Append("] = ")
                .Append(Table(table, id))
                .Append(",\n");
            count++;
        }

        Console.WriteLine($"Generated {count} block loot tables.");

        StringBuilder file2 = new(Header);
        file2.Append(entries);
        file2.Append(Footer);
        File.WriteAllText("BlockLootTables.cs",
            file2.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
    }

    // ------------------------------------------------------------------ table

    private static string Table(JObject table, string id) {
        string type = table["type"]?.ToObject<string>() ?? "minecraft:empty";
        if (type != "minecraft:block") {
            throw new InvalidOperationException($"{id} is a {type} table, not a block one.");
        }

        Consumed(table, id, "type", "random_sequence", "pools", "functions");

        // random_sequence is read and dropped on purpose: it names the per level RandomSequence a roll
        // would come out of upstream, and only LegacyRandomSource is ported. Same distribution, not the
        // same sequence, which is written up on World.Random.
        string pools = List(table["pools"], p => Pool((JObject)p, id));
        string functions = Functions(table["functions"], id);
        return $"new({pools}, {functions})";
    }

    private static string Pool(JObject pool, string id) {
        Consumed(pool, id, "rolls", "bonus_rolls", "entries", "conditions", "functions");

        string rolls = Number(pool["rolls"] ?? throw new InvalidOperationException($"{id}: pool with no rolls."), id);
        string entries = List(pool["entries"], e => Entry((JObject)e, id));
        string conditions = Conditions(pool["conditions"], id);
        string functions = Functions(pool["functions"], id);

        JToken? bonus = pool["bonus_rolls"];
        string bonusRolls = bonus == null ? "" : ", " + Number(bonus, id);

        return $"new LootPool({rolls}, {entries}, {conditions}, {functions}{bonusRolls})";
    }

    // ------------------------------------------------------------------ entries

    private static string Entry(JObject entry, string id) {
        string type = entry["type"]?.ToObject<string>()
                      ?? throw new InvalidOperationException($"{id}: entry with no type.");

        string conditions = Conditions(entry["conditions"], id);

        switch (type) {
            case "minecraft:item": {
                Consumed(entry, id, "type", "name", "conditions", "functions", "weight", "quality");
                string name = entry["name"]!.ToObject<string>()!;
                return $"new ItemLootEntry({Str(name)}, {conditions}, {Weight(entry)}, {Quality(entry)}, " +
                       $"{Functions(entry["functions"], id)})";
            }

            case "minecraft:dynamic": {
                Consumed(entry, id, "type", "name", "conditions", "functions", "weight", "quality");
                string name = entry["name"]!.ToObject<string>()!;
                return $"new DynamicLootEntry({Str(name)}, {conditions}, {Weight(entry)}, {Quality(entry)}, " +
                       $"{Functions(entry["functions"], id)})";
            }

            case "minecraft:alternatives": {
                Consumed(entry, id, "type", "children", "conditions");
                string children = List(entry["children"], c => Entry((JObject)c, id));
                return $"new AlternativesLootEntry({children}, {conditions})";
            }

            default:
                throw new InvalidOperationException(
                    $"{id}: loot entry type {type} has no port. Add one to Minecraft/Data/Loot rather " +
                    "than letting the entry drop, since a missing entry is a missing drop.");
        }
    }

    private static string Weight(JObject entry) => (entry["weight"]?.ToObject<int>() ?? 1).ToString();

    private static string Quality(JObject entry) => (entry["quality"]?.ToObject<int>() ?? 0).ToString();

    // ------------------------------------------------------------------ conditions

    private static string Conditions(JToken? conditions, string id) {
        return List(conditions, c => Condition((JObject)c, id));
    }

    private static string Condition(JObject condition, string id) {
        string type = condition["condition"]?.ToObject<string>()
                      ?? throw new InvalidOperationException($"{id}: condition with no type.");

        switch (type) {
            case "minecraft:survives_explosion":
                Consumed(condition, id, "condition");
                return "SurvivesExplosionCondition.Instance";

            case "minecraft:block_state_property": {
                Consumed(condition, id, "condition", "block", "properties");
                string block = condition["block"]!.ToObject<string>()!;
                return $"new BlockStatePropertyCondition({Str(block)}, {Properties(condition["properties"])})";
            }

            case "minecraft:match_tool": {
                Consumed(condition, id, "condition", "predicate");
                JToken? predicate = condition["predicate"];
                return $"new MatchToolCondition({(predicate == null ? "null" : ItemPredicate((JObject)predicate, id))})";
            }

            case "minecraft:any_of":
                Consumed(condition, id, "condition", "terms");
                return $"new AnyOfCondition({List(condition["terms"], t => Condition((JObject)t, id))})";

            case "minecraft:all_of":
                Consumed(condition, id, "condition", "terms");
                return $"new AllOfCondition({List(condition["terms"], t => Condition((JObject)t, id))})";

            case "minecraft:inverted":
                Consumed(condition, id, "condition", "term");
                return $"new InvertedCondition({Condition((JObject)condition["term"]!, id)})";

            case "minecraft:table_bonus": {
                Consumed(condition, id, "condition", "enchantment", "chances");
                string enchantment = condition["enchantment"]!.ToObject<string>()!;
                float[] chances = condition["chances"]!.ToObject<float[]>()!;
                return $"new TableBonusCondition({Str(enchantment)}, [{string.Join(", ", chances.Select(Float))}])";
            }

            case "minecraft:random_chance":
                Consumed(condition, id, "condition", "chance");
                return $"new RandomChanceCondition({Number(condition["chance"]!, id)})";

            case "minecraft:location_check":
                return LocationCheck(condition, id);

            case "minecraft:entity_properties":
                return EntityProperties(condition, id);

            default:
                throw new InvalidOperationException(
                    $"{id}: loot condition {type} has no port. Add one to Minecraft/Data/Loot rather than " +
                    "letting it drop, since an absent condition reads as an unconditional drop.");
        }
    }

    /// <summary>
    /// The four uses are a tall plant checking the other half of itself, so the port is an offset, a
    /// block and its state. Anything richer than that in the predicate is rejected rather than
    /// silently narrowed to what is understood.
    /// </summary>
    private static string LocationCheck(JObject condition, string id) {
        Consumed(condition, id, "condition", "predicate", "offsetX", "offsetY", "offsetZ");

        JObject predicate = (JObject)condition["predicate"]!;
        JObject block = (JObject)(predicate["block"]
                                  ?? throw new Unported(id, "location_check without a block predicate"));

        foreach (JProperty property in predicate.Properties()) {
            if (property.Name != "block") {
                throw new Unported(id, $"location_check on {property.Name}");
            }
        }

        foreach (JProperty property in block.Properties()) {
            if (property.Name is not ("blocks" or "state")) {
                throw new Unported(id, $"location_check block predicate on {property.Name}");
            }
        }

        string blocks = block["blocks"]!.ToObject<string>()!;
        if (blocks.StartsWith('#')) {
            throw new Unported(id, "location_check against a block tag");
        }

        int x = condition["offsetX"]?.ToObject<int>() ?? 0;
        int y = condition["offsetY"]?.ToObject<int>() ?? 0;
        int z = condition["offsetZ"]?.ToObject<int>() ?? 0;

        return $"new LocationCheckCondition(new Vec3<int>({x}, {y}, {z}), {Str(blocks)}, " +
               $"{Properties(block["state"])})";
    }

    /// <summary>
    /// Both uses are <c>this</c> with an empty predicate, which asks only whether something did the
    /// breaking. A predicate with anything in it would be a real test and is rejected, because reading
    /// it as empty turns a conditional drop into an unconditional one.
    /// </summary>
    private static string EntityProperties(JObject condition, string id) {
        Consumed(condition, id, "condition", "entity", "predicate");

        string entity = condition["entity"]?.ToObject<string>() ?? "this";
        if (entity != "this") {
            throw new Unported(id, $"entity_properties against {entity}");
        }

        JObject predicate = (JObject)(condition["predicate"] ?? new JObject());
        if (predicate.HasValues) {
            throw new Unported(id, "entity_properties with a non-empty predicate");
        }

        return "EntityPresentCondition.Instance";
    }

    /// <summary>
    /// <c>ItemPredicate</c> cut to the item or tag and the enchantment level, which is every use in
    /// the block tables. The two forms are 47 shears style matches and 156 silk touch ones.
    /// </summary>
    private static string ItemPredicate(JObject predicate, string id) {
        string item = "null";
        string tag = "null";
        List<string> enchantments = [];

        foreach (JProperty property in predicate.Properties()) {
            switch (property.Name) {
                case "items": {
                    string value = property.Value.ToObject<string>()!;
                    if (value.StartsWith('#')) {
                        tag = Str(value[1..]);
                    }
                    else {
                        item = Str(value);
                    }

                    break;
                }

                case "predicates": {
                    foreach (JProperty sub in ((JObject)property.Value).Properties()) {
                        if (sub.Name != "minecraft:enchantments") {
                            throw new Unported(id, $"item predicate {sub.Name}");
                        }

                        foreach (JToken term in (JArray)sub.Value) {
                            enchantments.Add(Enchantment((JObject)term, id));
                        }
                    }

                    break;
                }

                default:
                    throw new Unported(id, $"item predicate field {property.Name}");
            }
        }

        return $"new ItemPredicate({item}, {tag}, [{string.Join(", ", enchantments)}])";
    }

    private static string Enchantment(JObject term, string id) {
        string enchantment = term["enchantments"]?.ToObject<string>()
                             ?? throw new Unported(id, "enchantment predicate with no enchantment");

        if (enchantment.StartsWith('#')) {
            throw new Unported(id, "enchantment predicate against a tag");
        }

        JToken? levels = term["levels"];
        int min = levels switch {
            null => 1,
            JValue value => value.ToObject<int>(),
            JObject range when range["min"] != null => range["min"]!.ToObject<int>(),
            _ => throw new Unported(id, "enchantment predicate with no minimum level")
        };

        return $"({Str(enchantment)}, {min})";
    }

    // ------------------------------------------------------------------ functions

    private static string Functions(JToken? functions, string id) {
        return List(functions, f => Function((JObject)f, id));
    }

    private static string Function(JObject function, string id) {
        string type = function["function"]?.ToObject<string>()
                      ?? throw new InvalidOperationException($"{id}: function with no type.");

        string conditions = Conditions(function["conditions"], id);

        switch (type) {
            case "minecraft:set_count": {
                Consumed(function, id, "function", "conditions", "count", "add");
                string count = Number(function["count"]!, id);
                string add = (function["add"]?.ToObject<bool>() ?? false) ? "true" : "false";
                return $"new SetCountFunction({conditions}, {count}, {add})";
            }

            case "minecraft:explosion_decay":
                Consumed(function, id, "function", "conditions");
                return $"new ExplosionDecayFunction({conditions})";

            case "minecraft:apply_bonus": {
                Consumed(function, id, "function", "conditions", "enchantment", "formula", "parameters");
                string enchantment = function["enchantment"]!.ToObject<string>()!;
                return $"new ApplyBonusFunction({conditions}, {Str(enchantment)}, {Formula(function, id)})";
            }

            case "minecraft:limit_count": {
                Consumed(function, id, "function", "conditions", "limit");
                JToken limit = function["limit"]!;
                string min = "null";
                string max = "null";

                if (limit is JValue exact) {
                    // The codec unpacks a bare number into a range whose ends are both it.
                    min = max = $"new ConstantValue({Float(exact.ToObject<float>())})";
                }
                else {
                    JObject range = (JObject)limit;
                    if (range["min"] != null) {
                        min = Number(range["min"]!, id);
                    }

                    if (range["max"] != null) {
                        max = Number(range["max"]!, id);
                    }
                }

                return $"new LimitCountFunction({conditions}, new IntRange({min}, {max}))";
            }

            case "minecraft:copy_components": {
                Consumed(function, id, "function", "conditions", "source", "include");
                string source = function["source"]?.ToObject<string>() ?? "block_entity";
                if (source != "block_entity") {
                    throw new Unported(id, $"copy_components from {source}");
                }

                string[] include = function["include"]?.ToObject<string[]>()
                                   ?? throw new Unported(id, "copy_components with no include list");
                return $"new CopyComponentsFunction({conditions}, [{string.Join(", ", include.Select(Str))}])";
            }

            case "minecraft:copy_state": {
                Consumed(function, id, "function", "conditions", "block", "properties");
                string block = function["block"]!.ToObject<string>()!;
                string[] properties = function["properties"]!.ToObject<string[]>()!;
                return $"new CopyStateFunction({conditions}, {Str(block)}, " +
                       $"[{string.Join(", ", properties.Select(Str))}])";
            }

            default:
                throw new InvalidOperationException(
                    $"{id}: loot function {type} has no port. Add one to Minecraft/Data/Loot rather than " +
                    "letting it drop, since an absent count function reads as a count of one.");
        }
    }

    private static string Formula(JObject function, string id) {
        string formula = function["formula"]!.ToObject<string>()!;
        JObject parameters = (JObject)(function["parameters"] ?? new JObject());

        return formula switch {
            "minecraft:ore_drops" => "OreDropsFormula.Instance",
            "minecraft:uniform_bonus_count" =>
                $"new UniformBonusCountFormula({parameters["bonusMultiplier"]?.ToObject<int>() ?? 1})",
            "minecraft:binomial_with_bonus_count" =>
                $"new BinomialWithBonusCountFormula({parameters["extra"]!.ToObject<int>()}, " +
                $"{Float(parameters["probability"]!.ToObject<float>())})",
            _ => throw new Unported(id, $"apply_bonus formula {formula}")
        };
    }

    // ------------------------------------------------------------------ number providers

    private static string Number(JToken provider, string id) {
        if (provider is JValue constant) {
            return $"new ConstantValue({Float(constant.ToObject<float>())})";
        }

        JObject obj = (JObject)provider;
        string type = obj["type"]?.ToObject<string>() ?? "minecraft:constant";

        Consumed(obj, id, type switch {
            "minecraft:constant" => ["type", "value"],
            "minecraft:uniform" => ["type", "min", "max"],
            "minecraft:binomial" => ["type", "n", "p"],
            _ => ["type"]
        });

        return type switch {
            "minecraft:constant" => $"new ConstantValue({Float(obj["value"]!.ToObject<float>())})",
            "minecraft:uniform" =>
                $"new UniformGenerator({Number(obj["min"]!, id)}, {Number(obj["max"]!, id)})",
            "minecraft:binomial" =>
                $"new BinomialDistributionGenerator({Number(obj["n"]!, id)}, {Number(obj["p"]!, id)})",
            _ => throw new Unported(id, $"number provider {type}")
        };
    }

    // ------------------------------------------------------------------ helpers

    /// <summary>A state predicate as the pairs of strings the datapack writes them as.</summary>
    private static string Properties(JToken? properties) {
        if (properties is not JObject obj) {
            return "[]";
        }

        IEnumerable<string> pairs = obj.Properties()
            .Select(p => $"({Str(p.Name)}, {Str(p.Value.ToObject<string>()!)})");
        return $"[{string.Join(", ", pairs)}]";
    }

    private static string List(JToken? array, Func<JToken, string> map) {
        if (array is not JArray items || items.Count == 0) {
            return "[]";
        }

        return $"[{string.Join(", ", items.Select(map))}]";
    }

    /// <summary>
    /// Asserts that <paramref name="node"/> has no key beyond the ones the caller just read.
    /// <para>
    /// This is the check that makes the whole file trustworthy, and it is stronger than a conformance
    /// harness would be. Rejecting an unknown <i>type</i> only catches a whole condition or function
    /// going missing; a new <b>field</b> on a type that is already handled would be read as its
    /// default and change what a block drops with nothing to show for it. <c>set_count</c>'s
    /// <c>add</c> is exactly that shape: absent it means "set", present it means "add to".
    /// </para>
    /// <para>
    /// Running vanilla's codec over the same files could not see this either, since it would agree
    /// with itself. The datapack JSON is the source both sides read, so the question worth asking is
    /// whether this generator read all of it.
    /// </para>
    /// </summary>
    private static void Consumed(JObject node, string id, params string[] read) {
        foreach (JProperty property in node.Properties()) {
            if (!read.Contains(property.Name)) {
                throw new Unported(id, $"field {property.Name} on {Describe(node)}");
            }
        }
    }

    /// <summary>What a node calls itself, for the message above.</summary>
    private static string Describe(JObject node) {
        foreach (string key in new[] { "condition", "function", "type" }) {
            if (node[key]?.ToObject<string>() is { } value) {
                return value;
            }
        }

        return "a loot table node";
    }

    private static string Str(string value) => $"\"{value}\"";

    private static string Float(float value) {
        return value.ToString("R", CultureInfo.InvariantCulture) + "f";
    }

    /// <summary>
    /// A member of the datapack format that has no port. Separate from a plain exception so the
    /// message always names the table it came from and says what to do about it.
    /// </summary>
    private sealed class Unported(string table, string what)
        : InvalidOperationException(
            $"{table}: {what} has no port. Extend Minecraft/Data/Loot to cover it; skipping it would " +
            "change what the block drops without failing anything.");

    private const string Header =
        """
        using Minecraft.Data.Blocks;
        using Minecraft.Data.Loot;
        using Minecraft.Schemas;
        using Minecraft.Schemas.Vec;

        namespace Minecraft.Data.Generated;

        // Generated using the CodeGen project. Do not edit manually.
        //
        // Last updated: {date}
        /// <summary>
        /// Every vanilla block loot table, keyed by the id <see cref="BlockInfo.LootTable"/> holds.
        /// <para>
        /// Keyed by table rather than by block because the two are not one to one: every wall sign
        /// shares its standing form's table, and the blocks with no table at all are absent rather
        /// than present and empty.
        /// </para>
        /// <para>
        /// <b>Shared by every server in the process.</b> That is only safe because a
        /// <see cref="LootTable"/> and everything under it is immutable, so nothing here may grow a
        /// mutable field. A consumer replacing what a block drops wraps the source rather than
        /// editing this table, see <c>VanillaBlockLoot</c>.
        /// </para>
        /// </summary>
        public static class BlockLootTables {
            /// <summary>Every table, by loot table id.</summary>
            public static readonly IReadOnlyDictionary<Identifier, LootTable> ById = new Dictionary<Identifier, LootTable> {

        """;

    private const string Footer =
        """
            };

            /// <summary>
            /// The table a block loots from, or null when it has none. A block with no table drops
            /// nothing, which is not the same as a table that rolls nothing.
            /// </summary>
            public static LootTable? Of(IBlock block) {
                return block.LootTable is { } id && ById.TryGetValue(id, out LootTable? table) ? table : null;
            }
        }

        """;
}
