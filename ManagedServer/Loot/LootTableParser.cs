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
/// do about it, which matters because the table is a consumer's file rather than a pinned copy.
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
/// A <c>condition</c>, a <c>modifier</c> and a number are each a registry holder: inline, or a string
/// naming an element of <c>predicate</c>, <c>item_modifier</c>, <c>context_int_provider</c> or
/// <c>context_float_provider</c>, which <see cref="LootReferences"/> supplies. A holder set (the
/// <c>terms</c> of a composite, the list form of a modifier) may also be a single element; its
/// <c>#tag</c> form is refused, since no block table uses one.
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
    public static LootTable Parse(JsonElement root, string id, LootReferences? references = null) {
        return new Reader(id, references ?? LootReferences.None).Table(root);
    }

    private sealed class Reader(string id, LootReferences references) {
        public LootTable Table(JsonElement root) {
            string type = String(root, "type") ?? "minecraft:empty";

            if (type != "minecraft:block") {
                throw new InvalidOperationException($"{id} is a {type} table, not a block one.");
            }

            // random_sequence is read and dropped on purpose: it names the per level RandomSequence a
            // roll would come out of upstream, and only LegacyRandomSource is ported. Same
            // distribution, not the same sequence, which is written up on World.Random.
            Consumed(root, "type", "random_sequence", "pools", "modifier");

            return new LootTable(List(root, "pools", Pool), OptionalModifier(root));
        }

        private LootPool Pool(JsonElement pool) {
            Consumed(pool, "rolls", "bonus_rolls", "entries", "condition", "modifier");

            if (!pool.TryGetProperty("rolls", out JsonElement rolls)) {
                throw new InvalidOperationException($"{id}: pool with no rolls.");
            }

            IContextFloatProvider? bonus = pool.TryGetProperty("bonus_rolls", out JsonElement bonusRolls)
                ? Float(bonusRolls)
                : null;

            return new LootPool(Int(rolls), List(pool, "entries", Entry), OptionalCondition(pool),
                OptionalModifier(pool), bonus);
        }

        // -------------------------------------------------------------- entries

        private LootEntryContainer Entry(JsonElement entry) {
            string type = String(entry, "type")
                ?? throw new InvalidOperationException($"{id}: entry with no type.");

            switch (type) {
                case "minecraft:item":
                    Consumed(entry, "type", "name", "condition", "modifier", "weight", "quality");
                    return new ItemLootEntry(String(entry, "name")!, OptionalCondition(entry), Weight(entry),
                        Quality(entry), OptionalModifier(entry));

                case "minecraft:dynamic":
                    Consumed(entry, "type", "name", "condition", "modifier", "weight", "quality");
                    return new DynamicLootEntry(String(entry, "name")!, OptionalCondition(entry),
                        Weight(entry), Quality(entry), OptionalModifier(entry));

                case "minecraft:alternatives":
                    Consumed(entry, "type", "children", "condition", "modifier");
                    return new AlternativesLootEntry(List(entry, "children", Entry), OptionalCondition(entry),
                        OptionalModifier(entry));

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

        // -------------------------------------------------------------- conditions

        private ILootCondition? OptionalCondition(JsonElement node) {
            return node.TryGetProperty("condition", out JsonElement condition) ? Condition(condition) : null;
        }

        /// <summary><c>LootItemCondition.CODEC</c>: an inline condition or a <c>predicate</c> id.</summary>
        private ILootCondition Condition(JsonElement holder) {
            return holder.ValueKind == JsonValueKind.String
                ? Reference("predicate", holder.GetString()!, references.Predicates, ConditionDirect)
                : ConditionDirect(holder);
        }

        /// <summary><c>LootItemCondition.LIST_CODEC</c>: a list, or one element on its own.</summary>
        private ILootCondition[] Conditions(JsonElement set) {
            return HolderSet(set, "predicate", Condition);
        }

        private ILootCondition ConditionDirect(JsonElement condition) {
            if (condition.ValueKind != JsonValueKind.Object) {
                throw new InvalidOperationException($"{id}: a condition is a {condition.ValueKind}, not an object.");
            }

            string type = String(condition, "type")
                ?? throw new InvalidOperationException($"{id}: condition with no type.");

            switch (type) {
                case "minecraft:survives_explosion":
                    Consumed(condition, "type");
                    return SurvivesExplosionCondition.Instance;

                case "minecraft:match_block":
                    return new MatchBlockCondition(BlockPredicateOf(condition, "type"));

                case "minecraft:match_tool":
                    Consumed(condition, "type", "predicate");

                    return new MatchToolCondition(
                        condition.TryGetProperty("predicate", out JsonElement predicate)
                            ? ItemPredicateOf(predicate)
                            : null);

                case "minecraft:any_of":
                    Consumed(condition, "type", "terms");
                    return new AnyOfCondition(Conditions(condition.GetProperty("terms")));

                case "minecraft:all_of":
                    Consumed(condition, "type", "terms");
                    return new AllOfCondition(Conditions(condition.GetProperty("terms")));

                case "minecraft:inverted":
                    Consumed(condition, "type", "term");
                    return new InvertedCondition(Condition(condition.GetProperty("term")));

                case "minecraft:table_bonus": {
                    Consumed(condition, "type", "enchantment", "chances");

                    List<float> chances = [];
                    foreach (JsonElement chance in condition.GetProperty("chances").EnumerateArray()) {
                        chances.Add(chance.GetSingle());
                    }

                    return new TableBonusCondition(String(condition, "enchantment")!, chances.ToArray());
                }

                case "minecraft:random_chance":
                    Consumed(condition, "type", "chance");
                    return new RandomChanceCondition(Float(condition.GetProperty("chance")));

                case "minecraft:location_check":
                    return LocationCheck(condition);

                case "minecraft:entity_properties":
                    return EntityProperties(condition);

                default:
                    throw new UnportedLootException(id, $"loot condition {type}");
            }
        }

        /// <summary>
        /// The uses are a tall plant checking the other half of itself, so the port is an offset and a
        /// block predicate. Anything richer in the location predicate is rejected rather than silently
        /// narrowed to what is understood.
        /// </summary>
        private ILootCondition LocationCheck(JsonElement condition) {
            Consumed(condition, "type", "predicate", "offsetX", "offsetY", "offsetZ");

            JsonElement predicate = condition.GetProperty("predicate");

            foreach (JsonProperty property in predicate.EnumerateObject()) {
                if (property.Name != "block") {
                    throw new UnportedLootException(id, $"location_check on {property.Name}");
                }
            }

            if (!predicate.TryGetProperty("block", out JsonElement block)) {
                throw new UnportedLootException(id, "location_check without a block predicate");
            }

            return new LocationCheckCondition(
                new Vec3<int>(IntField(condition, "offsetX"), IntField(condition, "offsetY"),
                    IntField(condition, "offsetZ")),
                BlockPredicateOf(block));
        }

        /// <summary>
        /// <c>BlockPredicate</c>'s map fields, read off <paramref name="node"/> alongside any of
        /// <paramref name="siblings"/> it shares the object with. <c>nbt</c> and component matches
        /// need the block entity read back as components, which is not ported, so they are refused.
        /// </summary>
        private BlockPredicate BlockPredicateOf(JsonElement node, params string[] siblings) {
            Consumed(node, [..siblings, "blocks", "state"]);

            Identifier[]? blocks = null;
            Identifier? tag = null;

            if (node.TryGetProperty("blocks", out JsonElement set)) {
                if (set.ValueKind == JsonValueKind.String && set.GetString()!.StartsWith('#')) {
                    tag = Identifier.Parse(set.GetString()![1..]);
                } else if (set.ValueKind == JsonValueKind.String) {
                    blocks = [Identifier.Parse(set.GetString()!)];
                } else {
                    blocks = set.EnumerateArray().Select(element => Identifier.Parse(element.GetString()!)).ToArray();
                }
            }

            (string, string)[] state = [];
            if (node.TryGetProperty("state", out JsonElement properties)) {
                state = properties.EnumerateObject()
                    .Select(property => property.Value.ValueKind == JsonValueKind.String
                        ? (property.Name, property.Value.GetString()!)
                        : throw new UnportedLootException(id, $"a ranged state match on {property.Name}"))
                    .ToArray();
            }

            return new BlockPredicate(blocks, tag, state);
        }

        /// <summary>
        /// The uses are <c>this</c> with an empty predicate, which asks only whether something did the
        /// breaking. A predicate with anything in it would be a real test and is rejected, because
        /// reading it as empty turns a conditional drop into an unconditional one.
        /// </summary>
        private ILootCondition EntityProperties(JsonElement condition) {
            Consumed(condition, "type", "entity", "predicate");

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
        /// <c>ItemPredicate</c> cut to the item or tag and the enchantment level, which is every use in
        /// the block tables and their predicates: a shears style match or a silk touch one.
        /// </summary>
        private ItemPredicate ItemPredicateOf(JsonElement predicate) {
            Identifier? item = null;
            Identifier? tag = null;
            List<(Identifier, int)> enchantments = [];

            foreach (JsonProperty property in predicate.EnumerateObject()) {
                switch (property.Name) {
                    case "items": {
                        if (property.Value.ValueKind != JsonValueKind.String) {
                            throw new UnportedLootException(id, "an item predicate over a list of items");
                        }

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
                                enchantments.Add(Enchantment(term));
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

        private (Identifier, int) Enchantment(JsonElement term) {
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

        // -------------------------------------------------------------- modifiers

        private LootFunction? OptionalModifier(JsonElement node) {
            return node.TryGetProperty("modifier", out JsonElement modifier) ? Modifier(modifier) : null;
        }

        /// <summary><c>LootItemFunctions.CODEC</c>: an inline modifier or an <c>item_modifier</c> id.</summary>
        private LootFunction Modifier(JsonElement holder) {
            return holder.ValueKind == JsonValueKind.String
                ? Reference("item_modifier", holder.GetString()!, references.ItemModifiers, ModifierDirect)
                : ModifierDirect(holder);
        }

        /// <summary>
        /// <c>LootItemFunctions.DIRECT_CODEC</c>: a typed function, or a list read as a
        /// <c>sequence</c> with no condition (<c>SequenceFunction.INLINE_CODEC</c>).
        /// </summary>
        private LootFunction ModifierDirect(JsonElement modifier) {
            return modifier.ValueKind == JsonValueKind.Array
                ? new SequenceFunction(null, Functions(modifier))
                : Function(modifier);
        }

        /// <summary><c>LootItemFunctions.LIST_CODEC</c>: each element typed, or an id.</summary>
        private LootFunction[] Functions(JsonElement set) {
            return HolderSet(set, "item_modifier", element => element.ValueKind == JsonValueKind.String
                ? Reference("item_modifier", element.GetString()!, references.ItemModifiers, ModifierDirect)
                : Function(element));
        }

        private LootFunction Function(JsonElement function) {
            if (function.ValueKind != JsonValueKind.Object) {
                throw new InvalidOperationException($"{id}: a function is a {function.ValueKind}, not an object.");
            }

            string type = String(function, "type")
                ?? throw new InvalidOperationException($"{id}: function with no type.");

            ILootCondition? condition = OptionalCondition(function);

            switch (type) {
                case "minecraft:set_count": {
                    Consumed(function, "type", "condition", "count", "add");

                    bool add = function.TryGetProperty("add", out JsonElement addValue)
                        && addValue.GetBoolean();

                    return new SetCountFunction(condition, Int(function.GetProperty("count")), add);
                }

                case "minecraft:explosion_decay":
                    Consumed(function, "type", "condition");
                    return new ExplosionDecayFunction(condition);

                case "minecraft:apply_bonus":
                    Consumed(function, "type", "condition", "enchantment", "formula", "parameters");

                    return new ApplyBonusFunction(condition, String(function, "enchantment")!,
                        Formula(function));

                case "minecraft:limit_count": {
                    Consumed(function, "type", "condition", "limit");

                    JsonElement limit = function.GetProperty("limit");
                    if (limit.ValueKind != JsonValueKind.Object) {
                        throw new UnportedLootException(id, "a limit_count limit that is not an object, which IntLimit's codec refuses");
                    }

                    Consumed(limit, "min", "max");

                    return new LimitCountFunction(condition, new IntLimit(
                        limit.TryGetProperty("min", out JsonElement minimum) ? Int(minimum) : null,
                        limit.TryGetProperty("max", out JsonElement maximum) ? Int(maximum) : null));
                }

                case "minecraft:copy_components": {
                    Consumed(function, "type", "condition", "source", "include");

                    string source = String(function, "source") ?? "block_entity";

                    if (source != "block_entity") {
                        throw new UnportedLootException(id, $"copy_components from {source}");
                    }

                    if (!function.TryGetProperty("include", out JsonElement include)) {
                        throw new UnportedLootException(id, "copy_components with no include list");
                    }

                    return new CopyComponentsFunction(condition, Strings(include));
                }

                case "minecraft:copy_state":
                    Consumed(function, "type", "condition", "block", "properties");

                    return new CopyStateFunction(condition, String(function, "block")!,
                        PlainStrings(function.GetProperty("properties")));

                case "minecraft:sequence":
                    Consumed(function, "type", "condition", "functions");
                    return new SequenceFunction(condition, Functions(function.GetProperty("functions")));

                default:
                    throw new UnportedLootException(id, $"loot function {type}");
            }
        }

        private IBonusFormula Formula(JsonElement function) {
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
                            ? IntField(parameters, "bonusMultiplier", 1)
                            : 1);

                case "minecraft:binomial_with_bonus_count":
                    return new BinomialWithBonusCountFormula(parameters.GetProperty("extra").GetInt32(),
                        parameters.GetProperty("probability").GetSingle());

                default:
                    throw new UnportedLootException(id, $"apply_bonus formula {formula}");
            }
        }

        // -------------------------------------------------------------- numbers

        /// <summary>
        /// <c>ContextIntProviders.CODEC</c>: a bare integer, a typed provider, or a
        /// <c>context_int_provider</c> id.
        /// </summary>
        /// <remarks>
        /// A bare number that is not a whole one is refused rather than truncated or rounded: the
        /// constant is read with <c>Codec.INT</c>, and what that makes of a fraction is a property of
        /// the JSON library rather than of the format.
        /// </remarks>
        private IContextIntProvider Int(JsonElement holder) {
            return holder.ValueKind == JsonValueKind.String
                ? Reference("context_int_provider", holder.GetString()!, references.IntProviders, IntDirect)
                : IntDirect(holder);
        }

        /// <summary><c>ContextIntProviders.DIRECT_CODEC</c>, which is also what a registry file holds.</summary>
        private IContextIntProvider IntDirect(JsonElement holder) {
            if (holder.ValueKind == JsonValueKind.Number) {
                return holder.TryGetInt32(out int value)
                    ? new ConstantInt(value)
                    : throw new UnportedLootException(id, $"a non-integer count {holder.GetRawText()}");
            }

            if (holder.ValueKind != JsonValueKind.Object) {
                throw new InvalidOperationException($"{id}: an int provider is a {holder.ValueKind}.");
            }

            string type = String(holder, "type")
                ?? throw new InvalidOperationException($"{id}: int provider with no type.");

            switch (type) {
                case "minecraft:constant":
                    Consumed(holder, "type", "value");
                    return new ConstantInt(holder.GetProperty("value").GetInt32());

                case "minecraft:uniform":
                    Consumed(holder, "type", "min", "max");
                    return new UniformInt(Int(holder.GetProperty("min")), Int(holder.GetProperty("max")));

                case "minecraft:binomial":
                    Consumed(holder, "type", "n", "p");
                    return new BinomialInt(Int(holder.GetProperty("n")), Float(holder.GetProperty("p")));

                default:
                    throw new UnportedLootException(id, $"int provider {type}");
            }
        }

        /// <summary>
        /// <c>ContextFloatProviders.CODEC</c>: a bare number, a typed provider, or a
        /// <c>context_float_provider</c> id.
        /// </summary>
        private IContextFloatProvider Float(JsonElement holder) {
            return holder.ValueKind == JsonValueKind.String
                ? Reference("context_float_provider", holder.GetString()!, references.FloatProviders, FloatDirect)
                : FloatDirect(holder);
        }

        /// <summary><c>ContextFloatProviders.DIRECT_CODEC</c>.</summary>
        private IContextFloatProvider FloatDirect(JsonElement holder) {
            if (holder.ValueKind == JsonValueKind.Number) {
                return new ConstantFloat(holder.GetSingle());
            }

            if (holder.ValueKind != JsonValueKind.Object) {
                throw new InvalidOperationException($"{id}: a float provider is a {holder.ValueKind}.");
            }

            string type = String(holder, "type")
                ?? throw new InvalidOperationException($"{id}: float provider with no type.");

            switch (type) {
                case "minecraft:constant":
                    Consumed(holder, "type", "value");
                    return new ConstantFloat(holder.GetProperty("value").GetSingle());

                case "minecraft:uniform":
                    Consumed(holder, "type", "min", "max");
                    return new UniformFloat(Float(holder.GetProperty("min")), Float(holder.GetProperty("max")));

                default:
                    throw new UnportedLootException(id, $"float provider {type}");
            }
        }

        // -------------------------------------------------------------- holders

        /// <summary>
        /// A registry element named by id, parsed once and shared, as vanilla's holder is. The file is
        /// read with the direct codec, so it cannot itself be a bare id, but it can name itself through
        /// a nested holder, and that has no value and is refused.
        /// </summary>
        private T Reference<T>(string registry, string name, Dictionary<Identifier, JsonElement> elements,
            Func<JsonElement, T> parse) where T : class {

            if (name.StartsWith('#')) {
                throw new UnportedLootException(id, $"a {registry} tag ({name}) where one element is expected");
            }

            Identifier key = Identifier.Parse(name);

            if (references.Parsed.TryGetValue((registry, key), out object? parsed)) {
                return (T)parsed;
            }

            if (!elements.TryGetValue(key, out JsonElement element)) {
                throw new InvalidOperationException($"{id}: no {registry} called {key} in the pack.");
            }

            if (!references.Resolving.Add((registry, key))) {
                throw new InvalidOperationException($"{id}: {registry} {key} refers back to itself.");
            }

            try {
                T value = parse(element);
                references.Parsed[(registry, key)] = value;
                return value;
            }
            finally {
                references.Resolving.Remove((registry, key));
            }
        }

        /// <summary><c>HolderSetCodec</c> without its tag form: a list, or one element on its own.</summary>
        private T[] HolderSet<T>(JsonElement set, string registry, Func<JsonElement, T> element) {
            if (set.ValueKind == JsonValueKind.String && set.GetString()!.StartsWith('#')) {
                throw new UnportedLootException(id, $"a {registry} tag ({set.GetString()})");
            }

            return set.ValueKind == JsonValueKind.Array
                ? set.EnumerateArray().Select(element).ToArray()
                : [element(set)];
        }

        // -------------------------------------------------------------- helpers

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

        private static int IntField(JsonElement node, string name, int fallback = 0) {
            return node.TryGetProperty(name, out JsonElement value) ? value.GetInt32() : fallback;
        }

        /// <summary>
        /// Asserts that a node has no key beyond the ones the caller just read.
        /// </summary>
        /// <remarks>
        /// This is the check that makes the rest trustworthy, and it is why the parser can be pointed at
        /// a datapack it has never seen. See the note on the class.
        /// </remarks>
        private void Consumed(JsonElement node, params string[] read) {
            foreach (JsonProperty property in node.EnumerateObject()) {
                if (!read.Contains(property.Name)) {
                    throw new UnportedLootException(id, $"field {property.Name} on {Describe(node)}");
                }
            }
        }

        /// <summary>What a node calls itself, for the message above.</summary>
        private static string Describe(JsonElement node) {
            return String(node, "type") ?? "a loot table node";
        }
    }
}
