using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class ItemCodeGen {
    private const string Header = 
"""
using System.Collections.Frozen;
using Minecraft.Data.Items;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
public static class Item {

""";
    
    private const string Footer = "}\n";

    public static string CreateItemEntries(JObject registriesJson) {
        JObject itemsJson = registriesJson["minecraft:item"]!.ToObject<JObject>()!;
        JObject itemEntriesJson = itemsJson["entries"]!.ToObject<JObject>()!;

        // Build protocol ID lookup maps for blocks and entities (used in IdSet generation)
        _protocolIdLookup = new Dictionary<string, int>();
        foreach (string regName in new[] { "minecraft:block", "minecraft:entity_type" }) {
            JObject reg = registriesJson[regName]!.ToObject<JObject>()!;
            JObject entries = reg["entries"]!.ToObject<JObject>()!;
            foreach ((string key, JToken? val) in entries) {
                _protocolIdLookup[key] = val!["protocol_id"]!.Value<int>();
            }
        }

        Dictionary<string, string> blockByItem = BlockByItem();

        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header);

        // Entries are static readonly fields, so an item referencing another one (eg. the bowl left
        // behind by beetroot soup) reads null unless the item it needs is initialised first.
        // Collected here and emitted in dependency order below.
        List<(string Name, string Entry)> itemEntries = [];

        foreach ((string key, JToken? value) in itemEntriesJson) {
            int protocolId = value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            Func<string?, string> toCsStr = str => str == null ? "null" : $"\"{str}\"";

            blockByItem.TryGetValue(key, out string? block);

            // The vanilla data generator writes an item's default components one file per item.
            JObject defaultComponents = JObject.Parse(CodeGenUtils.ReadVanillaDataFile(
                "reports", "minecraft", "components", "item", key.Split(':')[1] + ".json"))["components"]!
                .ToObject<JObject>()!;

            // Vanilla's description id is not reported on its own, but item_name is always the
            // translatable text built from it.
            string translationKey = defaultComponents["minecraft:item_name"]!["translate"]!.Value<string>()!;
            List<string> defaultComponentConstructors = [];
            foreach ((string componentId, JToken? componentToken) in defaultComponents) {
                if (!DataComponentCodeGen.ComponentClasses.ContainsKey(componentId)) {
                    Console.WriteLine("WARNING: Component class not found for " + componentId + ", to create item default component.");
                    continue;
                }
                
                // This is the type of the generic (the actual type that has been serialized)
                // eg. IDataComponent<THIS_THING>
                string componentType = DataComponentCodeGen.ComponentTypes[componentId];

                if (!Deserialisers.TryGetValue(componentType, out Func<JToken, string?>? deserialiser)) {
                    Console.WriteLine("WARNING: No deserializer found for component type " + componentType + ", to create item default component.");
                    continue;
                }

                // Null means the component is at its own default, eg. an item with no attribute
                // modifiers, and is left off rather than written out empty for every item there is.
                string? inlineDefinition = deserialiser(componentToken!);
                if (inlineDefinition == null) {
                    continue;
                }

                // Remove the "Component" suffix from the class name
                int suffixLength = "Component".Length;
                string componentVarName = DataComponentCodeGen.ComponentClasses[componentId][..^suffixLength];
                defaultComponentConstructors.Add($"{{ DataComponent.{componentVarName}, {inlineDefinition} }}");
            }
            
            // Add to cs file
            itemEntries.Add((pascalName, $"{CodeGenUtils.GetIndentation(1)}public static readonly SimpleItem {pascalName} = new(\"{key}\", " +
                        $"{toCsStr(block)}, {toCsStr(translationKey)}, " +
                        $"new Dictionary<IDataComponent, object>() {{ {string.Join(", ", defaultComponentConstructors)} }}" +
                        ".ToFrozenDictionary());\n"));
            registryAdditions.AppendLine($"{CodeGenUtils.GetIndentation(2)}Data.Items.Add({protocolId}, Item.{pascalName});");
        }

        foreach ((string _, string entry) in SortByDependencies(itemEntries)) {
            file.Append(entry);
        }

        // Create the file content
        file.Append(Footer);
        File.WriteAllText("Item.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }

    /// <summary>
    /// The block each item places, which is the inverse of the block dump's <c>correspondingItem</c>.
    /// Several blocks can share one item (a torch and a wall torch, a sign and its wall variant), and
    /// vanilla's <c>Item.BY_BLOCK</c> keeps the first block registered, ie. the lowest id.
    /// </summary>
    private static Dictionary<string, string> BlockByItem() {
        JObject blocks = JObject.Parse(CodeGenUtils.ReadDumpFile("block.json"));

        Dictionary<string, (int Id, string Block)> byItem = [];
        foreach ((string blockId, JToken? block) in blocks) {
            string? item = block!["correspondingItem"]?.Value<string>();
            if (item == null) {
                continue;
            }

            int id = block["id"]!.Value<int>();
            if (!byItem.TryGetValue(item, out (int Id, string Block) existing) || id < existing.Id) {
                byItem[item] = (id, blockId);
            }
        }

        return byItem.ToDictionary(entry => entry.Key, entry => entry.Value.Block);
    }

    /// <summary>
    /// Orders entries so that an item referenced by another item's initialiser is declared first.
    /// Static field initialisers run in declaration order, so a reference to a field declared later
    /// evaluates to null instead of the item, with nothing to say so at runtime.
    /// </summary>
    private static List<(string Name, string Entry)> SortByDependencies(List<(string Name, string Entry)> entries) {
        Dictionary<string, int> indexByName = new();
        for (int i = 0; i < entries.Count; i++) {
            indexByName[entries[i].Name] = i;
        }

        List<(string Name, string Entry)> sorted = new(entries.Count);
        // 0 = unvisited, 1 = being visited (so a cycle is a second visit), 2 = emitted
        int[] state = new int[entries.Count];

        void Visit(int index) {
            if (state[index] != 0) {
                if (state[index] == 1) {
                    Console.WriteLine("WARNING: Item default components contain a reference cycle involving " +
                                      entries[index].Name + ", so it may be null at static init.");
                }
                return;
            }

            state[index] = 1;
            foreach (string dependency in GetReferencedNames(entries[index], indexByName)) {
                Visit(indexByName[dependency]);
            }
            state[index] = 2;
            sorted.Add(entries[index]);
        }

        for (int i = 0; i < entries.Count; i++) {
            Visit(i);
        }

        return sorted;
    }

    /// <summary>
    /// Every unqualified identifier in the entry that names another item, ie. an <c>Item</c> member
    /// read during static init. Identifiers after a dot are members of some other type, and item
    /// names are always PascalCase, so they never collide with the snake_case ids in the literals.
    /// </summary>
    private static IEnumerable<string> GetReferencedNames((string Name, string Entry) entry, Dictionary<string, int> indexByName) {
        HashSet<string> found = [];
        string text = entry.Entry;

        for (int i = 0; i < text.Length; i++) {
            if (!char.IsLetter(text[i]) && text[i] != '_') {
                continue;
            }

            int start = i;
            while (i < text.Length && (char.IsLetterOrDigit(text[i]) || text[i] == '_')) {
                i++;
            }

            if (start > 0 && text[start - 1] == '.') {
                continue;  // a member of something else, not one of ours
            }

            string identifier = text[start..i];
            if (identifier != entry.Name && indexByName.ContainsKey(identifier)) {
                found.Add(identifier);
            }
        }

        return found;
    }

    /// <summary>
    /// Both maps throw on a name they do not know rather than guessing one, so an operation or slot
    /// group added upstream stops the generator instead of silently dropping the modifier.
    /// </summary>
    private static readonly Dictionary<string, string> AttributeOperations = new() {
        { "add_value", "Add" },
        { "add_multiplied_base", "AddMultipliedBase" },
        { "add_multiplied_total", "AddMultipliedTotal" }
    };

    private static readonly Dictionary<string, string> SlotGroups = new() {
        { "any", "Any" }, { "mainhand", "MainHand" }, { "offhand", "OffHand" }, { "hand", "Hand" },
        { "feet", "Feet" }, { "legs", "Legs" }, { "chest", "Chest" }, { "head", "Head" },
        { "armor", "Armor" }, { "body", "Body" }, { "saddle", "Saddle" }
    };

    /// <summary>
    /// Only the hidden mode appears in vanilla's item defaults, on the wearable heads. Override
    /// carries a text component and throws here rather than being guessed at.
    /// </summary>
    private static string DisplayMode(JObject display) {
        string type = display["type"]!.Value<string>()!;
        return type switch {
            "default" => "ItemAttributeModifier.Display.DefaultMode()",
            "hidden" => "ItemAttributeModifier.Display.HiddenMode()",
            _ => throw new Exception("Unsupported attribute modifier display mode " + type)
        };
    }

    /// <summary>
    /// Turns a component's reported default into the C# that builds it. Returning null leaves the
    /// component off the item entirely, for a value that is already the default.
    /// </summary>
    private static readonly Dictionary<string, Func<JToken, string?>> Deserialisers = new() {
        { "int", token => token.ToObject<int>().ToString() },
        { "FoodComponent.Info", token => {
            JObject obj = token.ToObject<JObject>()!;
            int nutrition = obj["nutrition"]?.Value<int>() ?? throw new Exception("Nutrition missing");  // nutrition
            float saturation = obj["saturation"]?.Value<float>() ?? throw new Exception("Saturation missing");  // saturation modifier
            bool canAlwaysEat = obj["can_always_eat"]?.Value<bool>() ?? false;  // can always eat
            return "new FoodComponent.Info(" + 
                   $"{nutrition}, {saturation}f, {canAlwaysEat.ToString().ToLowerInvariant()})";
        } },
        { "TextComponent", token => {
            JObject obj = token.ToObject<JObject>()!;
            if (!obj.ContainsKey("translate")) {
                throw new Exception("TextComponent must have a 'translate' key, other types are not supported.");
            }
            
            string translationKey = obj["translate"]!.Value<string>()!;
            return $"TextComponent.Translatable(\"{translationKey}\")";
        } },
        // Armour points, attack damage and the rest of what an item is worth while it is worn or held.
        // The attributes are referenced through the generated Attribute class rather than the registry,
        // because these run during the registry's own initialisation.
        { "ItemAttributeModifier[]", token => {
            List<string> modifiers = [];
            foreach (JToken entry in token.ToObject<JArray>()!) {
                JObject obj = entry.ToObject<JObject>()!;
                string attribute = CodeGenUtils.NamespacedIdToPascalName(obj["type"]!.Value<string>()!);
                string id = obj["id"]!.Value<string>()!;
                double amount = obj["amount"]!.Value<double>();
                string operation = AttributeOperations[obj["operation"]!.Value<string>()!];

                // Vanilla defaults a missing slot to "any", though every item currently names one.
                string slot = SlotGroups[obj["slot"]?.Value<string>() ?? "any"];

                string display = obj["display"] is { } displayToken
                    ? DisplayMode(displayToken.ToObject<JObject>()!)
                    : "ItemAttributeModifier.Display.DefaultMode()";

                modifiers.Add($"new(Attribute.{attribute}, \"{id}\", " +
                              $"{amount.ToString("R", CultureInfo.InvariantCulture)}, " +
                              $"AttributeOperation.{operation}, EquipmentSlotGroup.{slot}, {display})");
            }

            // Every item's report carries the key, empty for the great majority of them.
            return modifiers.Count == 0
                ? null
                : $"new ItemAttributeModifier[] {{ {string.Join(", ", modifiers)} }}";
        } },
        { "Identifier", token => $"\"{token.ToObject<string>()!}\"" },
        { "ItemRarity", token => {
            string rarityStr = token.ToObject<string>()!;
            string rarityGuess = CodeGenUtils.NamespacedIdToPascalName(rarityStr);
            return $"ItemRarity.{rarityGuess}";
        } },
        { "ConsumableComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;
            float consumeSeconds = obj["consume_seconds"]?.Value<float>() ?? 1.6f;  // consume seconds
            string animationStr = obj["animation"]?.Value<string>() ?? "Eat";  // animation
            animationStr = CodeGenUtils.NamespacedIdToPascalName(animationStr);
            
            string sound = obj["sound"]?.ToObject<string>() ?? "minecraft:entity.generic.eat";
            sound = SoundCodeGen.GetVariableName(sound);
            
            bool hasParticles = obj["has_consume_particles"]?.Value<bool>() ?? true;
            JArray consumeEffects = obj["on_consume_effects"]?.ToObject<JArray>() ?? [];
            List<string> consumeEffectDefs = [];
            foreach (JToken consumeEffect in consumeEffects) {
                string type = consumeEffect["type"]?.Value<string>() ?? throw new Exception("Consume effect type not found");
                string consumeEffectDef;
                switch (type) {
                    case "minecraft:apply_effects": {
                        float probability = consumeEffect["probability"]?.Value<float>() ?? 1.0f;
                        JArray effects = consumeEffect["effects"]?.ToObject<JArray>() ?? throw new Exception("Consume effect effects not found");
                        List<string> inlineEffectDefs = [];
                        foreach (JToken effect in effects) {
                            string effectId = effect["id"]?.ToObject<string>()!;
                            string potionTypeEffectGuess = CodeGenUtils.NamespacedIdToPascalName(effectId);
                            sbyte amplifier = effect["amplifier"]?.Value<sbyte>() ?? 0;
                            int duration = effect["duration"]?.Value<int>() ?? 0;
                            bool ambient = effect["ambient"]?.Value<bool>() ?? false;
                            bool showParticles = effect["show_particles"]?.Value<bool>() ?? true;
                            bool showIcon = effect["show_icon"]?.Value<bool>() ?? true;
                            // TODO: Handle hidden effects
                            Func<bool, string> boolStr = b => b ? "true" : "false";
                            inlineEffectDefs.Add($"new PotionEffect(PotionEffectType.{potionTypeEffectGuess}, {amplifier}, {duration}, " +
                                                 $"{boolStr(ambient)}, {boolStr(showParticles)}, {boolStr(showIcon)}, false)");
                        }
                        //[{string.Join(", ", inlineEffectDefs)}], {probability}
                        consumeEffectDef = $"ConsumeEffect.ApplyEffects with {{ Effects = [{string.Join(", ", inlineEffectDefs)}], Probability = {probability}f }}";
                        break;
                    }

                    case "minecraft:play_sound": {
                        string soundId = consumeEffect["sound"]?.ToObject<string>() ?? throw new Exception("Consume effect sound not found");
                        string soundTypeGuess = SoundCodeGen.GetVariableName(soundId);
                        consumeEffectDef = $"ConsumeEffect.PlaySound with {{ Sound = new SoundEvent(SoundType.{soundTypeGuess}, null) }}";
                        break;
                    }

                    case "minecraft:clear_all_effects": {
                        consumeEffectDef = "ConsumeEffect.ClearAllEffects";
                        break;
                    }

                    case "minecraft:teleport_randomly": {
                        consumeEffectDef = "ConsumeEffect.TeleportRandomly";
                        break;
                    }

                    case "minecraft:remove_effects": {
                        string effect = consumeEffect["effects"]?.ToObject<string>() ?? throw new Exception("Consume effect effects not found");
                        consumeEffectDef = $"ConsumeEffect.RemoveEffects with {{ Effects = new IdSet.Tag(\"{effect}\") }}";
                        break;
                    }
                    
                    default:
                        throw new Exception("Unsupported consume effect type: " + type);
                }

                consumeEffectDefs.Add(consumeEffectDef);
            }
            
            return $"new ConsumableComponent.Data({consumeSeconds}f, ConsumableComponent.ConsumeAnimation.{animationStr}, " +
                   $"new SoundEvent(SoundType.{sound}, null), {hasParticles.ToString().ToLowerInvariant()}, " +
                   $"[{string.Join(", ", consumeEffectDefs)}])";
        } },
        { "TooltipDisplayComponent.Info", token => "new TooltipDisplayComponent.Info(false)" },  // This field is always empty
        { "bool", token => token.ToObject<bool>().ToString().ToLower() },
        { "(int, int)[]", _ => "Array.Empty<(int, int)>()" },
        { "EquippableComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;

            string slot = "EquippableComponent.Slot." + CodeGenUtils.NamespacedIdToPascalName(obj["slot"]?.ToObject<string>()!);
            if (slot == "EquippableComponent.Slot.Offhand") {
                slot = "EquippableComponent.Slot.OffHand";
            }
            
            string sound = obj.ContainsKey("equip_sound") ? "SoundType." + SoundCodeGen.GetVariableName(obj["equip_sound"]!.ToObject<string>()!) : "SoundType.ArmorEquipGeneric";
            string model = obj.ContainsKey("asset_id") ? '"' + obj["asset_id"]?.ToObject<string>() + '"' : "null";
            string cameraOverlay = obj.ContainsKey("camera_overlay") ? '"' + obj["camera_overlay"]?.ToObject<string>() + '"' : "null";
            string dispensable = obj["dispensable"]?.ToObject<bool>().ToString().ToLower() ?? "true";
            string swappable = obj["swappable"]?.ToObject<bool>().ToString().ToLower() ?? "true";
            string damageOnHurt = obj["damage_on_hurt"]?.ToObject<bool>().ToString().ToLower() ?? "true";
            string equipOnInteract = obj["equip_on_interact"]?.ToObject<bool>().ToString().ToLower() ?? "false";

            string allowedEntities = "null";
            if (obj.TryGetValue("allowed_entities", out JToken? allowedToken)) {
                allowedEntities = GetIdSet(allowedToken, id => "EntityType." + CodeGenUtils.NamespacedIdToPascalName(id));
            }

            return $"new EquippableComponent.Data({slot}, {sound}, {model}, {cameraOverlay}, {allowedEntities}, " +
                   $"{dispensable}, {swappable}, {damageOnHurt}, {equipOnInteract}, true, SoundType.ShearsSnip)";
        } },
        { "Tool", token => {
            JObject obj = token.ToObject<JObject>()!;

            float defaultMiningSpeed = obj["default_mining_speed"]?.ToObject<float>() ?? 1.0f;
            int damagePerBlock = obj["damage_per_block"]?.ToObject<int>() ?? 1;
            bool canMineInCreative = obj["can_destroy_blocks_in_creative"]?.ToObject<bool>() ?? true;

            List<string> rules = [];
            foreach (JToken jRule in obj["rules"]!.ToObject<JArray>()!) {
                JObject oRule = jRule.ToObject<JObject>()!;
                string speed = ParseOptionalFloat(oRule["speed"]);
                
                string correctForDrops = oRule["correct_for_drops"]?.ToObject<bool>().ToString().ToLower() ?? "null";
                string blocks = GetIdSet(oRule["blocks"]!, id => "Block." + CodeGenUtils.NamespacedIdToPascalName(id));
                
                rules.Add($"new ToolRule({blocks}, {speed}, {correctForDrops})");
            }
            
            return $"new Tool([{string.Join(", ", rules)}], {defaultMiningSpeed}, {damagePerBlock}, {canMineInCreative.ToString().ToLower()})";
        } },
        { "ItemStack", token => {
            // Assumption: is always just a type with a count
            JObject obj = token.ToObject<JObject>()!;
            string itemName = CodeGenUtils.NamespacedIdToPascalName(obj["id"]!.ToObject<string>()!);
            int itemCount = obj["count"]?.ToObject<int>() ?? 1;

            return $"new ItemStack({itemName}, {itemCount})";
        } },
        { "UseCooldownComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;
            string seconds = ParseOptionalFloat(obj["seconds"]);
            string cooldownGroup = obj["cooldown_group"]?.ToObject<string>() ?? "null";

            return $"new UseCooldownComponent.Data({seconds}, {cooldownGroup})";
        } },
        // What a shield is. Every field is optional in the codec, and the defaults are vanilla's own
        // rather than zeroes, so an item reported as {} still blocks everything in a ninety degree arc.
        { "BlocksAttacksComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;
            float blockDelay = obj["block_delay_seconds"]?.Value<float>() ?? 0f;
            float disableCooldownScale = obj["disable_cooldown_scale"]?.Value<float>() ?? 1f;

            List<string> reductions = [];
            foreach (JToken entry in obj["damage_reductions"]?.ToObject<JArray>() ?? []) {
                JObject reduction = entry.ToObject<JObject>()!;
                float angle = reduction["horizontal_blocking_angle"]?.Value<float>() ?? 90f;
                string type = reduction.TryGetValue("type", out JToken? typeToken)
                    ? DamageTypeSet(typeToken)
                    : "null";
                float baseAmount = reduction["base"]!.Value<float>();
                float factor = reduction["factor"]!.Value<float>();
                reductions.Add($"new BlocksAttacksComponent.DamageReduction({Float(angle)}, {type}, " +
                               $"{Float(baseAmount)}, {Float(factor)})");
            }

            string reductionList = reductions.Count == 0
                ? "[BlocksAttacksComponent.DamageReduction.Everything]"
                : $"[{string.Join(", ", reductions)}]";

            string itemDamage = "BlocksAttacksComponent.ItemDamage.Default";
            if (obj["item_damage"] is { } damageToken) {
                JObject damage = damageToken.ToObject<JObject>()!;
                itemDamage = $"new BlocksAttacksComponent.ItemDamage({Float(damage["threshold"]!.Value<float>())}, " +
                             $"{Float(damage["base"]!.Value<float>())}, {Float(damage["factor"]!.Value<float>())})";
            }

            string bypassedBy = obj.TryGetValue("bypassed_by", out JToken? bypassToken)
                ? DamageTypeSet(bypassToken)
                : "null";

            return $"new BlocksAttacksComponent.Data({Float(blockDelay)}, {Float(disableCooldownScale)}, " +
                   $"{reductionList}, {itemDamage}, {bypassedBy}, {Sound(obj["block_sound"])}, " +
                   $"{Sound(obj["disabled_sound"])})";
        } },
        // Emitted even when it is all defaults, since carrying the component at all is what makes an
        // item a weapon, and none of this reaches the wire: only a stack's own patch is sent.
        { "WeaponComponent.Data", token => {
            JObject obj = token.ToObject<JObject>()!;
            int itemDamage = obj["item_damage_per_attack"]?.Value<int>() ?? 1;
            float disableBlocking = obj["disable_blocking_for_seconds"]?.Value<float>() ?? 0f;
            return $"new WeaponComponent.Data({itemDamage}, {Float(disableBlocking)})";
        } },
        { "TextColor", token => {
            // integer with rgb bitshifted
            if (token.Type == JTokenType.Integer) {
                return $"TextColor.FromDecimal({token.ToObject<int>()})";
            }

            // array of 3 floats
            JArray arr = token.ToObject<JArray>()!;
            return $"TextColor.Rgb({arr[0].ToObject<float>()}f, {arr[1].ToObject<float>()}f, {arr[2].ToObject<float>()}f)";
        } }
    };

    private static Dictionary<string, int> _protocolIdLookup = new();

    private static string GetIdSet(JToken obj, Func<string, string> transformer) {
        if (obj.Type == JTokenType.String) {
            string id = obj.ToObject<string>()!;
            if (id.StartsWith('#')) {
                return $"new IdSet.Tag(\"{id[1..]}\")";
            }

            if (_protocolIdLookup.TryGetValue(id, out int protocolId)) {
                return $"new IdSet.Ids([{protocolId}])";
            }
            return $"new IdSet.Ids([/* unknown: {id} */])";
        }
        
        // is array of strings (identifiers of ids)
        IEnumerable<string> ids = obj.ToObject<JArray>()!
            .Select(jId => {
                string id = jId.ToObject<string>()!;
                return _protocolIdLookup.TryGetValue(id, out int pid) ? pid.ToString() : $"/* unknown: {id} */0";
            });

        return $"new IdSet.Ids([{string.Join(", ", ids)}])";
    }

    /// <summary>
    /// A float literal that round trips, since a value written as <c>0.25</c> has to come out of the
    /// generator as <c>0.25f</c> rather than as the current culture's decimal separator.
    /// </summary>
    private static string Float(float value) {
        return value.ToString("R", CultureInfo.InvariantCulture) + "f";
    }

    /// <summary>
    /// A <c>HolderSet&lt;DamageType&gt;</c>, which vanilla only ever writes as a tag reference.
    /// Damage types are a datapack registry, so their ids are not knowable here, and a list of them
    /// throws rather than being written out as ids that would mean something else.
    /// </summary>
    private static string DamageTypeSet(JToken token) {
        string? id = token.Type == JTokenType.String ? token.ToObject<string>() : null;
        if (id == null || !id.StartsWith('#')) {
            throw new Exception("Damage type set " + token + " is not a tag, which is not supported.");
        }

        return $"new IdSet.Tag(\"{id[1..]}\")";
    }

    /// <summary>A <c>Holder&lt;SoundEvent&gt;</c> field that may be absent, as a sound registry entry.</summary>
    private static string Sound(JToken? token) {
        return token == null ? "null" : "SoundType." + SoundCodeGen.GetVariableName(token.ToObject<string>()!);
    }

    private static string ParseOptionalFloat(JToken? obj) {
        if (obj == null) {
            return "null";
        }
        
        return obj.ToObject<float>().ToString(CultureInfo.InvariantCulture) + "f";
    }
}
