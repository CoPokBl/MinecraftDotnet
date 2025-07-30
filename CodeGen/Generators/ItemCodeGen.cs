using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class ItemCodeGen {
    private const string Header = 
"""
using Minecraft.Data.Items;
using Minecraft.Data.Components;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
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

        JObject itemData = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("item_data.json"));
        
        StringBuilder registryAdditions = new();
        StringBuilder file = new(Header);

        foreach ((string key, JToken? value) in itemEntriesJson) {
            int protocolId = value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(key);
            
            JObject itemDataEntry = itemData[key]!.ToObject<JObject>()!;
            Func<string?, string> toCsStr = str => str == null ? "null" : $"\"{str}\"";
            
            string? block = itemDataEntry["correspondingBlock"]?.Value<string>();
            string translationKey = itemDataEntry["translationKey"]!.Value<string>()!;
            
            // Get default components
            JObject defaultComponents = itemDataEntry["components"]!.ToObject<JObject>()!;
            List<string> defaultComponentConstructors = [];
            foreach ((string componentId, JToken? componentToken) in defaultComponents) {
                if (!DataComponentCodeGen.ComponentClasses.ContainsKey(componentId)) {
                    Console.WriteLine("WARNING: Component class not found for " + componentId + ", to create item default component.");
                    continue;
                }
                
                // This is the type of the generic (the actual type that has been serialized)
                // eg. IDataComponent<THIS_THING>
                string componentType = DataComponentCodeGen.ComponentTypes[componentId];

                if (!Deserialisers.TryGetValue(componentType, out Func<JToken, string>? deserialiser)) {
                    Console.WriteLine("WARNING: No deserializer found for component type " + componentType + ", to create item default component.");
                    continue;
                }
                string inlineDefinition = deserialiser(componentToken!);
                
                // Remove the "Component" suffix from the class name
                int suffixLength = "Component".Length;
                string componentVarName = DataComponentCodeGen.ComponentClasses[componentId][..^suffixLength];
                defaultComponentConstructors.Add($"{{ DataComponent.{componentVarName}, {inlineDefinition} }}");
            }
            
            // Add to cs file
            file.Append($"{CodeGenUtils.GetIndentation(1)}public static SimpleItem {pascalName} => new(\"{key}\", {protocolId}, " +
                        $"{toCsStr(block)}, {toCsStr(translationKey)}, " +
                        $"new Dictionary<IDataComponent, object>() {{ {string.Join(", ", defaultComponentConstructors)} }});\n");
            registryAdditions.AppendLine($"{CodeGenUtils.GetIndentation(2)}Data.Items.Add(Item.{pascalName});");
        }
        
        // Create the file content
        file.Append(Footer);
        File.WriteAllText("Item.cs", file.ToString().Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));

        return registryAdditions.ToString();
    }

    private static readonly Dictionary<string, Func<JToken, string>> Deserialisers = new() {
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

            string allowedEntities = "null";
            if (obj.TryGetValue("allowed_entities", out JToken? allowedToken)) {
                allowedEntities = GetIdSet(allowedToken, id => "EntityType." + CodeGenUtils.NamespacedIdToPascalName(id));
            }

            return $"new EquippableComponent.Data({slot}, {sound}, {model}, {cameraOverlay}, {allowedEntities}, {dispensable}, {swappable}, {damageOnHurt})";
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

    private static string GetIdSet(JToken obj, Func<string, string> transformer) {
        if (obj.Type == JTokenType.String) {
            string id = obj.ToObject<string>()!;
            if (id.StartsWith('#')) {
                return $"new IdSet.Tag(\"{id[1..]}\")";
            }

            return $"IdSet.FromProtocolTypes({transformer(id)})";
        }
        
        // is array of strings (identifiers of ids)
        IEnumerable<string> names = obj.ToObject<JArray>()!
            .Select(jId => transformer(jId.ToObject<string>()!));

        return $"IdSet.FromProtocolTypes({string.Join(", ", names)})";
    }

    private static string ParseOptionalFloat(JToken? obj) {
        if (obj == null) {
            return "null";
        }
        
        return obj.ToObject<float>().ToString(CultureInfo.InvariantCulture) + "f";
    }
}
