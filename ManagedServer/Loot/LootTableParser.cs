using System.Text.Json;
using Minecraft.Data.Loot;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Loot;

/// <summary>
/// A member of the loot table format that has no port here.
/// </summary>
/// <remarks>
/// Separate from a plain exception so the message always names the table it came from and says what to
/// do about it, which matters more now that the table is a consumer's file rather than a pinned copy.
/// </remarks>
public sealed class UnportedLootException(string table, string what)
    : InvalidOperationException(
        $"{table} uses {what}, which has no port. Add one to Minecraft/Data/Loot rather than letting "
        + "it drop: an absent condition reads as an unconditional drop and an absent set_count as a "
        + "count of one.");

/// <summary>
/// Reads vanilla's block loot table JSON into <see cref="LootTable"/>.
/// </summary>
/// <remarks>
/// <b>Anything not understood throws, including an unknown field on a type that is handled.</b> The
/// field level check is the stronger half and it is what makes the rest trustworthy: rejecting an
/// unknown type only catches a whole condition or function going missing, while a new field on a type
/// already handled would be read as its default and change what a block drops with nothing to show for
/// it. <c>set_count</c>'s <c>add</c> is exactly that shape, since absent it means "set" and present it
/// means "add to".
/// <p/>
/// There is deliberately no conformance harness for this and one would be weaker than the check above:
/// the datapack JSON is the source both sides read, so running vanilla's codec over it only proves
/// vanilla agrees with itself. The question worth asking is whether this parser read all of it.
/// </remarks>
public static class LootTableParser {
    /// <summary>Parses one block loot table.</summary>
    /// <remarks>
    /// A table that is not a <c>minecraft:block</c> one is rejected rather than parsed, since the other
    /// types reach context this has no notion of.
    /// </remarks>
    public static LootTable Parse(JsonElement root, string id) {
        string type = String(root, "type") ?? "minecraft:empty";

        if (type != "minecraft:block") {
            throw new InvalidOperationException($"{id} is a {type} table, not a block one.");
        }

        // random_sequence is read and dropped on purpose: it names the per level RandomSequence a roll
        // would come out of upstream, and only LegacyRandomSource is ported. Same distribution, not the
        // same sequence, which is written up on World.Random.
        Consumed(root, id, "type", "random_sequence", "pools", "functions");

        return new LootTable(List(root, "pools", element => Pool(element, id)),
            Functions(root, id));
    }

    private static LootPool Pool(JsonElement pool, string id) {
        Consumed(pool, id, "rolls", "bonus_rolls", "entries", "conditions", "functions");

        if (!pool.TryGetProperty("rolls", out JsonElement rolls)) {
            throw new InvalidOperationException($"{id}: pool with no rolls.");
        }

        INumberProvider? bonus = pool.TryGetProperty("bonus_rolls", out JsonElement bonusRolls)
            ? Number(bonusRolls, id)
            : null;

        LootEntryContainer[] entries = List(pool, "entries", element => Entry(element, id));
        ILootCondition[] conditions = Conditions(pool, id);
        LootFunction[] functions = Functions(pool, id);

        return bonus is null
            ? new LootPool(Number(rolls, id), entries, conditions, functions)
            : new LootPool(Number(rolls, id), entries, conditions, functions, bonus);
    }

    // ------------------------------------------------------------------ entries

    private static LootEntryContainer Entry(JsonElement entry, string id) {
        string type = String(entry, "type")
            ?? throw new InvalidOperationException($"{id}: entry with no type.");

        ILootCondition[] conditions = Conditions(entry, id);

        switch (type) {
            case "minecraft:item": {
                Consumed(entry, id, "type", "name", "conditions", "functions", "weight", "quality");

                return new ItemLootEntry(String(entry, "name")!, conditions, Weight(entry),
                    Quality(entry), Functions(entry, id));
            }

            case "minecraft:dynamic": {
                Consumed(entry, id, "type", "name", "conditions", "functions", "weight", "quality");

                return new DynamicLootEntry(String(entry, "name")!, conditions, Weight(entry),
                    Quality(entry), Functions(entry, id));
            }

            case "minecraft:alternatives": {
                Consumed(entry, id, "type", "children", "conditions");

                return new AlternativesLootEntry(List(entry, "children",
                    child => Entry(child, id)), conditions);
            }

            default:
                throw new UnportedLootException(id, $"loot entry type {type}");
        }
    }

    private static int Weight(JsonElement entry) {
        return entry.TryGetProperty("weight", out JsonElement value) ? value.GetInt32() : 1;
    }

    private static int Quality(JsonElement entry) {
        return entry.TryGetProperty("quality", out JsonElement value) ? value.GetInt32() : 0;
    }

    // ------------------------------------------------------------------ conditions

    private static ILootCondition[] Conditions(JsonElement node, string id) {
        return List(node, "conditions", element => Condition(element, id));
    }

    private static ILootCondition Condition(JsonElement condition, string id) {
        string type = String(condition, "condition")
            ?? throw new InvalidOperationException($"{id}: condition with no type.");

        switch (type) {
            case "minecraft:survives_explosion":
                Consumed(condition, id, "condition");
                return SurvivesExplosionCondition.Instance;

            case "minecraft:block_state_property":
                Consumed(condition, id, "condition", "block", "properties");

                return new BlockStatePropertyCondition(String(condition, "block")!,
                    Properties(condition, "properties"));

            case "minecraft:match_tool":
                Consumed(condition, id, "condition", "predicate");

                return new MatchToolCondition(
                    condition.TryGetProperty("predicate", out JsonElement predicate)
                        ? ItemPredicateOf(predicate, id)
                        : null);

            case "minecraft:any_of":
                Consumed(condition, id, "condition", "terms");
                return new AnyOfCondition(List(condition, "terms", term => Condition(term, id)));

            case "minecraft:all_of":
                Consumed(condition, id, "condition", "terms");
                return new AllOfCondition(List(condition, "terms", term => Condition(term, id)));

            case "minecraft:inverted":
                Consumed(condition, id, "condition", "term");
                return new InvertedCondition(Condition(condition.GetProperty("term"), id));

            case "minecraft:table_bonus": {
                Consumed(condition, id, "condition", "enchantment", "chances");

                List<float> chances = [];
                foreach (JsonElement chance in condition.GetProperty("chances").EnumerateArray()) {
                    chances.Add(chance.GetSingle());
                }

                return new TableBonusCondition(String(condition, "enchantment")!, chances.ToArray());
            }

            case "minecraft:random_chance":
                Consumed(condition, id, "condition", "chance");
                return new RandomChanceCondition(Number(condition.GetProperty("chance"), id));

            case "minecraft:location_check":
                return LocationCheck(condition, id);

            case "minecraft:entity_properties":
                return EntityProperties(condition, id);

            default:
                throw new UnportedLootException(id, $"loot condition {type}");
        }
    }

    /// <summary>
    /// The uses are a tall plant checking the other half of itself, so the port is an offset, a block
    /// and its state. Anything richer in the predicate is rejected rather than silently narrowed to
    /// what is understood.
    /// </summary>
    private static ILootCondition LocationCheck(JsonElement condition, string id) {
        Consumed(condition, id, "condition", "predicate", "offsetX", "offsetY", "offsetZ");

        JsonElement predicate = condition.GetProperty("predicate");

        foreach (JsonProperty property in predicate.EnumerateObject()) {
            if (property.Name != "block") {
                throw new UnportedLootException(id, $"location_check on {property.Name}");
            }
        }

        if (!predicate.TryGetProperty("block", out JsonElement block)) {
            throw new UnportedLootException(id, "location_check without a block predicate");
        }

        foreach (JsonProperty property in block.EnumerateObject()) {
            if (property.Name is not ("blocks" or "state")) {
                throw new UnportedLootException(id,
                    $"location_check block predicate on {property.Name}");
            }
        }

        string blocks = String(block, "blocks")!;

        if (blocks.StartsWith('#')) {
            throw new UnportedLootException(id, "location_check against a block tag");
        }

        return new LocationCheckCondition(
            new Vec3<int>(Int(condition, "offsetX"), Int(condition, "offsetY"),
                Int(condition, "offsetZ")),
            blocks, Properties(block, "state"));
    }

    /// <summary>
    /// The uses are <c>this</c> with an empty predicate, which asks only whether something did the
    /// breaking. A predicate with anything in it would be a real test and is rejected, because reading
    /// it as empty turns a conditional drop into an unconditional one.
    /// </summary>
    private static ILootCondition EntityProperties(JsonElement condition, string id) {
        Consumed(condition, id, "condition", "entity", "predicate");

        string entity = String(condition, "entity") ?? "this";

        if (entity != "this") {
            throw new UnportedLootException(id, $"entity_properties against {entity}");
        }

        if (condition.TryGetProperty("predicate", out JsonElement predicate)
            && predicate.EnumerateObject().Any()) {

            throw new UnportedLootException(id, "entity_properties with a non-empty predicate");
        }

        return EntityPresentCondition.Instance;
    }

    /// <summary>
    /// <c>ItemPredicate</c> cut to the item or tag and the enchantment level, which is every use in the
    /// block tables: a shears style match or a silk touch one.
    /// </summary>
    private static ItemPredicate ItemPredicateOf(JsonElement predicate, string id) {
        Identifier? item = null;
        Identifier? tag = null;
        List<(Identifier, int)> enchantments = [];

        foreach (JsonProperty property in predicate.EnumerateObject()) {
            switch (property.Name) {
                case "items": {
                    string value = property.Value.GetString()!;

                    if (value.StartsWith('#')) {
                        tag = Identifier.Parse(value[1..]);
                    } else {
                        item = Identifier.Parse(value);
                    }

                    break;
                }

                case "predicates": {
                    foreach (JsonProperty sub in property.Value.EnumerateObject()) {
                        if (sub.Name != "minecraft:enchantments") {
                            throw new UnportedLootException(id, $"item predicate {sub.Name}");
                        }

                        foreach (JsonElement term in sub.Value.EnumerateArray()) {
                            enchantments.Add(Enchantment(term, id));
                        }
                    }

                    break;
                }

                default:
                    throw new UnportedLootException(id, $"item predicate field {property.Name}");
            }
        }

        return new ItemPredicate(item, tag, enchantments.ToArray());
    }

    private static (Identifier, int) Enchantment(JsonElement term, string id) {
        string enchantment = String(term, "enchantments")
            ?? throw new UnportedLootException(id, "enchantment predicate with no enchantment");

        if (enchantment.StartsWith('#')) {
            throw new UnportedLootException(id, "enchantment predicate against a tag");
        }

        int min;

        if (!term.TryGetProperty("levels", out JsonElement levels)) {
            min = 1;
        } else if (levels.ValueKind == JsonValueKind.Number) {
            min = levels.GetInt32();
        } else if (levels.TryGetProperty("min", out JsonElement minimum)) {
            min = minimum.GetInt32();
        } else {
            throw new UnportedLootException(id, "enchantment predicate with no minimum level");
        }

        return (Identifier.Parse(enchantment), min);
    }

    // ------------------------------------------------------------------ functions

    private static LootFunction[] Functions(JsonElement node, string id) {
        return List(node, "functions", element => Function(element, id));
    }

    private static LootFunction Function(JsonElement function, string id) {
        string type = String(function, "function")
            ?? throw new InvalidOperationException($"{id}: function with no type.");

        ILootCondition[] conditions = Conditions(function, id);

        switch (type) {
            case "minecraft:set_count": {
                Consumed(function, id, "function", "conditions", "count", "add");

                bool add = function.TryGetProperty("add", out JsonElement addValue)
                    && addValue.GetBoolean();

                return new SetCountFunction(conditions, Number(function.GetProperty("count"), id), add);
            }

            case "minecraft:explosion_decay":
                Consumed(function, id, "function", "conditions");
                return new ExplosionDecayFunction(conditions);

            case "minecraft:apply_bonus":
                Consumed(function, id, "function", "conditions", "enchantment", "formula", "parameters");

                return new ApplyBonusFunction(conditions, String(function, "enchantment")!,
                    Formula(function, id));

            case "minecraft:limit_count": {
                Consumed(function, id, "function", "conditions", "limit");

                JsonElement limit = function.GetProperty("limit");
                INumberProvider? min = null;
                INumberProvider? max = null;

                if (limit.ValueKind == JsonValueKind.Number) {
                    // The codec unpacks a bare number into a range whose ends are both it.
                    min = max = new ConstantValue(limit.GetSingle());
                } else {
                    if (limit.TryGetProperty("min", out JsonElement minimum)) {
                        min = Number(minimum, id);
                    }

                    if (limit.TryGetProperty("max", out JsonElement maximum)) {
                        max = Number(maximum, id);
                    }
                }

                return new LimitCountFunction(conditions, new IntRange(min, max));
            }

            case "minecraft:copy_components": {
                Consumed(function, id, "function", "conditions", "source", "include");

                string source = String(function, "source") ?? "block_entity";

                if (source != "block_entity") {
                    throw new UnportedLootException(id, $"copy_components from {source}");
                }

                if (!function.TryGetProperty("include", out JsonElement include)) {
                    throw new UnportedLootException(id, "copy_components with no include list");
                }

                return new CopyComponentsFunction(conditions, Strings(include));
            }

            case "minecraft:copy_state":
                Consumed(function, id, "function", "conditions", "block", "properties");

                return new CopyStateFunction(conditions, String(function, "block")!,
                    PlainStrings(function.GetProperty("properties")));

            default:
                throw new UnportedLootException(id, $"loot function {type}");
        }
    }

    private static IBonusFormula Formula(JsonElement function, string id) {
        string formula = String(function, "formula")!;

        JsonElement parameters = function.TryGetProperty("parameters", out JsonElement given)
            ? given
            : default;

        switch (formula) {
            case "minecraft:ore_drops":
                return OreDropsFormula.Instance;

            case "minecraft:uniform_bonus_count":
                return new UniformBonusCountFormula(
                    parameters.ValueKind == JsonValueKind.Object
                        ? Int(parameters, "bonusMultiplier", 1)
                        : 1);

            case "minecraft:binomial_with_bonus_count":
                return new BinomialWithBonusCountFormula(parameters.GetProperty("extra").GetInt32(),
                    parameters.GetProperty("probability").GetSingle());

            default:
                throw new UnportedLootException(id, $"apply_bonus formula {formula}");
        }
    }

    // ------------------------------------------------------------------ number providers

    private static INumberProvider Number(JsonElement provider, string id) {
        if (provider.ValueKind == JsonValueKind.Number) {
            return new ConstantValue(provider.GetSingle());
        }

        string type = String(provider, "type") ?? "minecraft:constant";

        Consumed(provider, id, type switch {
            "minecraft:constant" => ["type", "value"],
            "minecraft:uniform" => ["type", "min", "max"],
            "minecraft:binomial" => ["type", "n", "p"],
            _ => ["type"]
        });

        return type switch {
            "minecraft:constant" => new ConstantValue(provider.GetProperty("value").GetSingle()),
            "minecraft:uniform" => new UniformGenerator(Number(provider.GetProperty("min"), id),
                Number(provider.GetProperty("max"), id)),
            "minecraft:binomial" => new BinomialDistributionGenerator(
                Number(provider.GetProperty("n"), id), Number(provider.GetProperty("p"), id)),
            _ => throw new UnportedLootException(id, $"number provider {type}")
        };
    }

    // ------------------------------------------------------------------ helpers

    /// <summary>A state predicate as the pairs of strings the datapack writes them as.</summary>
    private static (string, string)[] Properties(JsonElement node, string name) {
        if (!node.TryGetProperty(name, out JsonElement properties)
            || properties.ValueKind != JsonValueKind.Object) {

            return [];
        }

        return properties.EnumerateObject()
            .Select(property => (property.Name, property.Value.GetString()!))
            .ToArray();
    }

    private static T[] List<T>(JsonElement node, string name, Func<JsonElement, T> map) {
        if (!node.TryGetProperty(name, out JsonElement array)
            || array.ValueKind != JsonValueKind.Array) {

            return [];
        }

        return array.EnumerateArray().Select(map).ToArray();
    }

    private static Identifier[] Strings(JsonElement array) {
        return array.EnumerateArray().Select(element => (Identifier)element.GetString()!).ToArray();
    }

    /// <summary>
    /// The same as a list of ids but left as strings, which is what a state property name is.
    /// </summary>
    private static string[] PlainStrings(JsonElement array) {
        return array.EnumerateArray().Select(element => element.GetString()!).ToArray();
    }

    private static string? String(JsonElement node, string name) {
        return node.TryGetProperty(name, out JsonElement value) ? value.GetString() : null;
    }

    private static int Int(JsonElement node, string name, int fallback = 0) {
        return node.TryGetProperty(name, out JsonElement value) ? value.GetInt32() : fallback;
    }

    /// <summary>
    /// Asserts that a node has no key beyond the ones the caller just read.
    /// </summary>
    /// <remarks>
    /// This is the check that makes the rest trustworthy, and it is why the parser can be pointed at a
    /// datapack it has never seen. See the note on the class.
    /// </remarks>
    private static void Consumed(JsonElement node, string id, params string[] read) {
        foreach (JsonProperty property in node.EnumerateObject()) {
            if (!read.Contains(property.Name)) {
                throw new UnportedLootException(id, $"field {property.Name} on {Describe(node)}");
            }
        }
    }

    /// <summary>What a node calls itself, for the message above.</summary>
    private static string Describe(JsonElement node) {
        foreach (string key in new[] { "condition", "function", "type" }) {
            if (String(node, key) is { } value) {
                return value;
            }
        }

        return "a loot table node";
    }
}
