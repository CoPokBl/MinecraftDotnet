using System.Globalization;
using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Player;
using ClientLib.World;
using GraphicalClient.Rendering.Entities;
using GraphicalClient.Rendering.Entities.Special;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Minecraft.Data.Items;
using Minecraft.Schemas;
using Quaternion = System.Numerics.Quaternion;
using Minecraft.Schemas.Items;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary><c>ItemStackRenderState.FoilType</c>.</summary>
public enum FoilType : byte {
    None,
    Standard,
    /// <summary>A compass's or clock's glint, laid over the item in its own space rather than along its texture.</summary>
    Special
}

/// <summary>
/// What <c>ItemModel.update</c> is given: the stack, the display context, the level, the owner and the
/// seed. <see cref="HeldIn"/> and <see cref="Carried"/> stand in for vanilla comparing the stack with
/// the owner's held, used and carried stacks by identity, which stacks rebuilt on every read cannot do:
/// they say which of those this stack is.
/// </summary>
public sealed class ItemModelQuery {
    public ItemStack Stack = ItemStack.Air;
    public ItemDisplayContext DisplayContext;
    public MinecraftClient? Client;
    public ClientLevel? Level;
    public ClientEntity? Owner;
    public int Seed;
    public Hand? HeldIn;
    public bool Carried;

    /// <summary><c>owner.asLivingEntity()</c>, which is what the select and condition properties are given.</summary>
    public ClientEntity? Living => Owner is { IsLiving: true } owner ? owner : null;

    /// <summary>Whether a key mapping vanilla names, <c>key.use</c> say, is held; null for one it does not know.</summary>
    public static Func<string, bool?> KeyMappingDown { get; set; } = _ => null;

    /// <summary><c>Minecraft.hasShiftDown</c>.</summary>
    public static Func<bool> ShiftDown { get; set; } = () => false;

    /// <summary>The resolver's definition for another stack, which <c>appendItemLayers</c> walks into the same output; null resolves nothing.</summary>
    public Func<ItemStack, ItemModelNode?>? Definition;
}

/// <summary>One layer a stack's model draws: the leaf that drew it, the colours its tint indices take, and its glint.</summary>
public readonly record struct ItemModelLayer(ItemModelLeaf Leaf, uint[] Tints, FoilType Foil);

/// <summary><c>ItemStackRenderState</c> as the model tree fills it.</summary>
public sealed class ItemModelOutput {
    public readonly List<ItemModelLayer> Layers = [];

    /// <summary><c>isAnimated</c>: something in it changes from frame to frame without the stack changing.</summary>
    public bool Animated;

    /// <summary>A branch led to vanilla's missing model, or to a special model not ported.</summary>
    public bool Missing;

    public void Clear() {
        Layers.Clear();
        Animated = false;
        Missing = false;
    }
}

/// <summary><c>ClientItem.Properties</c>, those read here.</summary>
public sealed record ClientItemProperties(bool HandAnimationOnSwap, float SwapAnimationScale) {
    public static readonly ClientItemProperties Default = new(true, 1.0F);

    public static ClientItemProperties Read(JObject definition) =>
        new(definition.Value<bool?>("hand_animation_on_swap") ?? true, definition.Value<float?>("swap_animation_scale") ?? 1.0F);
}

/// <summary><c>ItemModel</c>: a node of an item definition's tree, baked.</summary>
public abstract class ItemModelNode {
    public abstract void Update(ItemModelOutput output, ItemModelQuery query);

    /// <summary>The tree for a stack with nothing to read: a default stack, in the GUI, with no owner.</summary>
    public void UpdateDefault(ItemModelOutput output, IItem item) {
        output.Clear();
        Update(output, new ItemModelQuery { Stack = new ItemStack(item), DisplayContext = ItemDisplayContext.Gui });
    }
}

/// <summary>
/// <c>CuboidItemModelWrapper</c> and <c>SpecialModelWrapper</c>: a model drawn as one layer. The model's
/// <see cref="ItemModel.Special"/> is set for a special one, whose quads the renderer draws.
/// </summary>
public sealed class ItemModelLeaf(int id, ItemModel model, Func<ItemModelQuery, uint>[] tints) : ItemModelNode {
    private static readonly Identifier CompassesTag = "minecraft:compasses";

    /// <summary>Unique among the leaves of one source, so a list of them names a drawing.</summary>
    public int Id { get; } = id;

    public ItemModel Model { get; } = model;

    public override void Update(ItemModelOutput output, ItemModelQuery query) {
        FoilType foil = FoilType.None;
        if (ItemModelProperties.HasFoil(query.Stack)) {
            foil = Model.Special == null && HasSpecialAnimatedTexture(query) ? FoilType.Special : FoilType.Standard;
            output.Animated = true;
        }
        uint[] colours = tints.Length == 0 ? [] : new uint[tints.Length];
        for (int i = 0; i < tints.Length; i++) {
            colours[i] = tints[i](query);
        }
        output.Layers.Add(new ItemModelLayer(this, colours, foil));
    }

    /// <summary><c>hasSpecialAnimatedTexture</c>: the compasses tag as the server sent it, or a clock.</summary>
    private static bool HasSpecialAnimatedTexture(ItemModelQuery query) =>
        query.Stack.Type.Identifier == Item.Clock.Identifier
        || query.Client?.Inventory.Data.InTag(ClientLib.Inventory.Stack.Of(query.Stack), CompassesTag) == true;
}

/// <summary><c>MissingItemModel</c>, which this client leaves to the caller to draw as it draws an item it has no model for.</summary>
public sealed class MissingItemModelNode : ItemModelNode {
    public static readonly MissingItemModelNode Instance = new();

    public override void Update(ItemModelOutput output, ItemModelQuery query) => output.Missing = true;
}

/// <summary><c>EmptyModel</c>.</summary>
public sealed class EmptyItemModelNode : ItemModelNode {
    public static readonly EmptyItemModelNode Instance = new();

    public override void Update(ItemModelOutput output, ItemModelQuery query) { }
}

/// <summary><c>BundleSelectedItemSpecialRenderer</c>: the selected item's own model, appended to the bundle's.</summary>
public sealed class BundleSelectedItemModelNode : ItemModelNode {
    public static readonly BundleSelectedItemModelNode Instance = new();

    public override void Update(ItemModelOutput output, ItemModelQuery query) {
        if (ClientLib.Inventory.BundleItem.GetSelectedItem(query.Stack) is not { } selected || query.Definition?.Invoke(selected) is not { } definition) {
            return;
        }
        (ItemStack stack, Hand? heldIn, bool carried) = (query.Stack, query.HeldIn, query.Carried);
        // A stack made from the template is none of the owner's, so it is neither held nor carried.
        (query.Stack, query.HeldIn, query.Carried) = (selected, null, false);
        definition.Update(output, query);
        (query.Stack, query.HeldIn, query.Carried) = (stack, heldIn, carried);
    }
}

/// <summary><c>CompositeModel</c>.</summary>
public sealed class CompositeItemModelNode(ItemModelNode[] models) : ItemModelNode {
    public override void Update(ItemModelOutput output, ItemModelQuery query) {
        foreach (ItemModelNode model in models) {
            model.Update(output, query);
        }
    }
}

/// <summary><c>ConditionalItemModel</c>.</summary>
public sealed class ConditionalItemModelNode(Func<ItemModelQuery, bool> property, ItemModelNode onTrue, ItemModelNode onFalse) : ItemModelNode {
    public override void Update(ItemModelOutput output, ItemModelQuery query) => (property(query) ? onTrue : onFalse).Update(output, query);
}

/// <summary><c>SelectItemModel</c>, its cases keyed by the property's value as <see cref="ItemModelTree"/> spells it.</summary>
public sealed class SelectItemModelNode(Func<ItemModelQuery, string?> property, Dictionary<string, ItemModelNode> cases, ItemModelNode fallback)
    : ItemModelNode {
    public override void Update(ItemModelOutput output, ItemModelQuery query) =>
        (property(query) is { } value && cases.TryGetValue(value, out ItemModelNode? model) ? model : fallback).Update(output, query);
}

/// <summary>
/// <c>SelectItemModel</c> over <c>ComponentContents</c>: each case's value read through the component's
/// codec the first time it is needed, and compared with the stack's value as the component compares them.
/// </summary>
public sealed class ComponentSelectItemModelNode(IDataComponent component, (JToken When, ItemModelNode Model)[] cases, ItemModelNode fallback)
    : ItemModelNode {
    private (object? Value, ItemModelNode Model)[]? _cases;

    public override void Update(ItemModelOutput output, ItemModelQuery query) {
        _cases ??= cases.Select(c => (Decode(c.When), c.Model)).ToArray();
        ItemModelNode chosen = fallback;
        if (ComponentValue(query.Stack) is { } value) {
            foreach ((object? candidate, ItemModelNode model) in _cases) {
                if (candidate != null && component.ValuesEqual(value, candidate)) {
                    chosen = model;
                    break;
                }
            }
        }
        chosen.Update(output, query);
    }

    private object? ComponentValue(ItemStack stack) {
        if (stack.Components.TryGetValue(component, out object? own)) {
            return own;
        }
        return stack.RemoveComponents.Contains(component) ? null : stack.Type.DefaultComponents.GetValueOrDefault(component);
    }

    private object? Decode(JToken when) {
        try {
            using System.Text.Json.JsonDocument document = System.Text.Json.JsonDocument.Parse(when.ToString(Newtonsoft.Json.Formatting.None));
            return component.FromNbt(Minecraft.Data.Components.Codecs.JsonNbt.FromJson(document.RootElement, component.Identifier), VanillaRegistry.Data);
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            return null;
        }
    }
}

/// <summary><c>RangeSelectItemModel</c>.</summary>
public sealed class RangeSelectItemModelNode(Func<ItemModelQuery, float> property, float scale, float[] thresholds, ItemModelNode[] models, ItemModelNode fallback)
    : ItemModelNode {
    public override void Update(ItemModelOutput output, ItemModelQuery query) {
        float value = property(query) * scale;
        ItemModelNode selected;
        if (float.IsNaN(value)) {
            selected = fallback;
        }
        else {
            int index = LastIndexLessOrEqual(thresholds, value);
            selected = index == -1 ? fallback : models[index];
        }
        selected.Update(output, query);
    }

    /// <summary><c>lastIndexLessOrEqual</c>, its binary search Java's <c>Arrays.binarySearch</c>, which ties go to.</summary>
    public static int LastIndexLessOrEqual(float[] haystack, float needle) {
        if (haystack.Length < 16) {
            for (int i = 0; i < haystack.Length; i++) {
                if (haystack[i] > needle) {
                    return i - 1;
                }
            }
            return haystack.Length - 1;
        }
        int low = 0, high = haystack.Length - 1;
        while (low <= high) {
            int mid = (int)((uint)(low + high) >> 1);
            float midValue = haystack[mid];
            if (midValue < needle) {
                low = mid + 1;
            }
            else if (midValue > needle) {
                high = mid - 1;
            }
            else {
                int midBits = BitConverter.SingleToInt32Bits(midValue), needleBits = BitConverter.SingleToInt32Bits(needle);
                if (midBits == needleBits) {
                    return mid;
                }
                if (midBits < needleBits) {
                    low = mid + 1;
                }
                else {
                    high = mid - 1;
                }
            }
        }
        return low - 1;
    }
}

/// <summary>
/// <c>ItemModels.CODEC</c> and the property and tint source codecs, reading an item definition's
/// <c>model</c> into a tree of baked nodes. A property or tint source this cannot read makes vanilla
/// reject the whole definition; here it is reported and answers false, no case, or no value.
/// </summary>
public sealed class ItemModelTree(BlockModelBaker baker, Rendering.BiomeColours.ColourMaps maps) {
    private int _nextLeaf;

    public ItemModelNode Read(JObject root) => Read(root, Matrix4x4.Identity);

    /// <summary>
    /// <c>ItemModel.Unbaked.bake</c>: each node's <c>transformation</c> is composed onto its parent's
    /// (<c>Transformation.compose</c>, the child's applied first) and handed to its children.
    /// </summary>
    private ItemModelNode Read(JObject node, Matrix4x4 parent) {
        string type = Path(node.Value<string>("type"));
        Matrix4x4 local = node["transformation"] is { } transformation ? TransformationOf(transformation) * parent : parent;
        switch (type) {
            case "model": {
                if (node.Value<string>("model") is not { } id || baker.BakeItem(id) is not { } model) {
                    return MissingItemModelNode.Instance;
                }
                Func<ItemModelQuery, uint>[] tints = node["tints"] is JArray list ? list.OfType<JObject>().Select(Tint).ToArray() : [];
                if (!local.IsIdentity) {
                    model = model with {
                        Local = local,
                        Quads = model.Quads.Select(q => q with { Positions = q.Positions.Select(p => Vector3.Transform(p, local)).ToArray() }).ToArray()
                    };
                }
                return new ItemModelLeaf(_nextLeaf++, model, tints);
            }
            case "special": {
                if (node["model"] is not JObject special || ParseSpecial(special) is not { } unbaked) {
                    return MissingItemModelNode.Instance;
                }
                // A base the pack lacks is vanilla's missing model, whose display transforms are all identity.
                ItemModel baseModel = (node.Value<string>("base") is { } baseId ? baker.BakeItem(baseId) : null)
                                      ?? new ItemModel([], [], new Dictionary<string, ItemTransform>(), true);
                return new ItemModelLeaf(_nextLeaf++, baseModel with { Quads = [], Layers = [], Local = local, Special = unbaked }, []);
            }
            case "composite": {
                ItemModelNode[] models = (node["models"] as JArray)?.OfType<JObject>().Select(m => Read(m, local)).ToArray() ?? [];
                return models.Length switch {
                    0 => EmptyItemModelNode.Instance,
                    1 => models[0],
                    _ => new CompositeItemModelNode(models)
                };
            }
            case "condition":
                return new ConditionalItemModelNode(Condition(node), Child(node["on_true"], local), Child(node["on_false"], local));
            case "select":
                return Select(node, local);
            case "range_dispatch": {
                (float Threshold, JObject Model)[] entries = (node["entries"] as JArray)?.OfType<JObject>()
                    .Select(e => (e.Value<float?>("threshold") ?? 0.0F, e["model"] as JObject))
                    .Where(e => e.Item2 != null).Select(e => (e.Item1, e.Item2!))
                    .OrderBy(e => e.Item1, Comparer<float>.Create(JavaCompare)).ToArray() ?? [];
                return new RangeSelectItemModelNode(Range(node), node.Value<float?>("scale") ?? 1.0F, entries.Select(e => e.Threshold).ToArray(),
                    entries.Select(e => Read(e.Model, local)).ToArray(), Child(node["fallback"], local));
            }
            case "empty":
                return EmptyItemModelNode.Instance;
            case "bundle/selected_item":
                return BundleSelectedItemModelNode.Instance;
            default:
                baker.Warnings.Add($"item model type {type} is not known");
                return MissingItemModelNode.Instance;
        }
    }

    /// <summary><c>SpecialModelRenderers.CODEC</c>; a field it fails on fails the definition in vanilla, and the model here.</summary>
    private ISpecialModelUnbaked? ParseSpecial(JObject special) {
        try {
            return SpecialModelRenderers.Parse(special);
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            baker.Warnings.Add($"special model {special.Value<string>("type")}: {e.Message}");
            return null;
        }
    }

    private ItemModelNode Child(JToken? token, Matrix4x4 local) => token is JObject child ? Read(child, local) : MissingItemModelNode.Instance;

    /// <summary><c>Comparator.comparingDouble</c>, which is <c>Double.compare</c>: negative zero before zero, NaN last.</summary>
    private static int JavaCompare(float a, float b) {
        if (a < b) {
            return -1;
        }
        if (a > b) {
            return 1;
        }
        long Bits(float value) => float.IsNaN(value) ? 0x7FF8000000000000L : BitConverter.DoubleToInt64Bits(value);
        return Bits(a).CompareTo(Bits(b));
    }

    private static string Path(string? identifier) => identifier == null ? "" : Identifier.Parse(identifier).Key;

    private static string Canonical(string identifier) => Identifier.Parse(identifier).ToString();

    private Func<ItemModelQuery, bool> Condition(JObject node) {
        string property = Path(node.Value<string>("property"));
        switch (property) {
            case "using_item":
                return UsingItem;
            case "broken":
                return q => ItemModelProperties.NextDamageWillBreak(q.Stack);
            case "damaged":
                return q => ItemModelProperties.IsDamaged(q.Stack);
            case "has_component": {
                if (Component(node.Value<string>("component")) is not { } component) {
                    return _ => false;
                }
                bool ignoreDefault = node.Value<bool?>("ignore_default") ?? false;
                // hasNonDefault: the stack's patch names it, a value of its own or a removal.
                return ignoreDefault
                    ? q => q.Stack.RemoveComponents.Contains(component) || q.Stack.Components.TryGetValue(component, out object? own)
                           && !(q.Stack.Type.DefaultComponents.TryGetValue(component, out object? fallback) && component.ValuesEqual(own, fallback))
                    : q => ItemComponents.Has(q.Stack, component);
            }
            case "custom_model_data": {
                int index = node.Value<int?>("index") ?? 0;
                return q => ItemModelProperties.CustomModelDataFlag(q.Stack, index) == true;
            }
            case "fishing_rod/cast":
                return FishingRodCast;
            case "bundle/has_selected_item":
                return q => ClientLib.Inventory.BundleItem.GetSelectedItemIndex(q.Stack) != ClientLib.Inventory.BundleContents.NoSelectedItemIndex;
            case "selected":
                return q => q.Living is LocalPlayer && q.HeldIn == Hand.MainHand;
            case "carried":
                return q => q.Living is LocalPlayer && q.Carried;
            case "extended_view":
                return q => q.DisplayContext == ItemDisplayContext.Gui && ItemModelQuery.ShiftDown();
            case "keybind_down": {
                string keybind = node.Value<string>("keybind") ?? "";
                return _ => ItemModelQuery.KeyMappingDown(keybind) == true;
            }
            case "view_entity":
                // Without a camera entity of its own, the client's view is always the player's.
                return q => q.Living != null && ReferenceEquals(q.Living, q.Client?.Player);
            case "component":
                return ComponentPredicate(node);
        }
        baker.Warnings.Add($"condition property {property} is not known");
        return _ => false;
    }

    private Func<ItemModelQuery, string?> SelectProperty(JObject node, string property) {
        switch (property) {
            case "custom_model_data": {
                int index = node.Value<int?>("index") ?? 0;
                return q => ItemModelProperties.CustomModelDataString(q.Stack, index);
            }
            case "main_hand":
                return q => q.Living is { } owner ? ArmedEntityRenderState.MainArmOf(owner) == HumanoidArm.Left ? "left" : "right" : null;
            case "charge_type":
                return q => ItemModelProperties.ChargeType(q.Stack) switch {
                    CrossbowChargeType.Arrow => "arrow",
                    CrossbowChargeType.Rocket => "rocket",
                    _ => "none"
                };
            case "trim_material":
                return q => ItemComponents.Get(q.Stack, DataComponent.Trim)?.Material.Identifier.ToString();
            case "block_state": {
                string name = node.Value<string>("block_state_property") ?? "";
                return q => ItemComponents.Get(q.Stack, DataComponent.BlockState)?.GetValueOrDefault(name);
            }
            case "display_context":
                return q => ItemRenderer.DisplayKey(q.DisplayContext);
            case "local_time":
                return LocalTime(node);
            case "context_entity_type":
                return q => q.Living?.Type.Identifier.ToString();
            case "context_dimension":
                return q => q.Level?.Name.ToString();
        }
        baker.Warnings.Add($"select property {property} is not known");
        return _ => null;
    }

    /// <summary>How a case's <c>when</c> is spelt in the case table: identifiers in full, anything else as written.</summary>
    private static string CaseKey(string property, JToken value) {
        string text = value.Type == JTokenType.String ? value.Value<string>()! : value.ToString(Newtonsoft.Json.Formatting.None);
        return property is "trim_material" or "context_entity_type" or "context_dimension" ? Canonical(text) : text;
    }

    private ItemModelNode Select(JObject node, Matrix4x4 local) {
        string property = Path(node.Value<string>("property"));
        ItemModelNode fallback = Child(node["fallback"], local);
        JObject[] cases = (node["cases"] as JArray)?.OfType<JObject>().ToArray() ?? [];
        if (property == "component") {
            if (Component(node.Value<string>("component")) is not { HasNbtForm: true } component) {
                return fallback;
            }
            List<(JToken, ItemModelNode)> decoded = [];
            foreach (JObject c in cases) {
                ItemModelNode model = Child(c["model"], local);
                foreach (JToken when in c["when"] is JArray list ? list : c["when"] is { } single ? [single] : []) {
                    decoded.Add((when, model));
                }
            }
            return new ComponentSelectItemModelNode(component, decoded.ToArray(), fallback);
        }
        Dictionary<string, ItemModelNode> table = new();
        foreach (JObject c in cases) {
            ItemModelNode model = Child(c["model"], local);
            foreach (JToken when in c["when"] is JArray list ? list : c["when"] is { } single ? [single] : []) {
                table.TryAdd(CaseKey(property, when), model);
            }
        }
        return new SelectItemModelNode(SelectProperty(node, property), table, fallback);
    }

    private Func<ItemModelQuery, float> Range(JObject node) {
        string property = Path(node.Value<string>("property"));
        switch (property) {
            case "custom_model_data": {
                int index = node.Value<int?>("index") ?? 0;
                return q => ItemModelProperties.CustomModelDataFloat(q.Stack, index) ?? 0.0F;
            }
            case "bundle/fullness":
                return q => ItemModelProperties.BundleFullness(q.Stack);
            case "damage": {
                bool normalize = node.Value<bool?>("normalize") ?? true;
                return q => ItemModelProperties.Damage(q.Stack, normalize);
            }
            case "count": {
                bool normalize = node.Value<bool?>("normalize") ?? true;
                return q => ItemModelProperties.Count(q.Stack, normalize);
            }
            case "cooldown":
                return q => q.Owner is LocalPlayer player ? player.Cooldowns.GetCooldownPercent(q.Stack, 0.0F) : 0.0F;
            case "crossbow/pull":
                return q => q.Living is not { } owner ? 0.0F
                    : ItemModelProperties.CrossbowPull(q.Stack, UsePrediction.UseDuration(q.Stack) - RemainingTicks(q, owner));
            case "use_cycle": {
                float period = node.Value<float?>("period") ?? 1.0F;
                return q => UseOf(q) is { ThisStack: true } use ? use.Remaining % period : 0.0F;
            }
            case "use_duration": {
                bool remaining = node.Value<bool?>("remaining") ?? false;
                return q => UseOf(q) is { ThisStack: true } use ? remaining ? use.Remaining : UsePrediction.UseDuration(q.Stack) - use.Remaining : 0.0F;
            }
            case "time":
                return new NeedleTime(node.Value<bool?>("wobble") ?? true, node.Value<string>("source") ?? "").Get;
            case "compass":
                return new CompassAngle(node.Value<bool?>("wobble") ?? true, node.Value<string>("target") ?? "").Get;
        }
        baker.Warnings.Add($"range property {property} is not known");
        return _ => float.NaN;
    }

    private static IDataComponent? Component(string? identifier) =>
        identifier != null && VanillaRegistry.Data.DataComponents.Contains(Identifier.Parse(identifier)) ? VanillaRegistry.Data.DataComponents[Identifier.Parse(identifier)] : null;

    /// <summary>
    /// <c>ComponentMatches</c>: <c>DataComponentPredicate</c>s by type. Only <c>damage</c>, <c>enchantments</c>,
    /// <c>stored_enchantments</c> and <c>potion_contents</c> are read, by their simple forms (a level or
    /// count range as a number or <c>min</c> and <c>max</c>, ids or lists of them); any other predicate answers false.
    /// </summary>
    private Func<ItemModelQuery, bool> ComponentPredicate(JObject node) {
        string predicate = Path(node.Value<string>("predicate"));
        JToken? value = node["value"];
        switch (predicate) {
            case "damage": {
                (int? Min, int? Max) durability = Bounds(value?["durability"]), damage = Bounds(value?["damage"]);
                return q => ItemModelProperties.IsDamageableItem(q.Stack)
                            && Matches(durability, ItemModelProperties.MaxDamage(q.Stack) - ItemModelProperties.DamageValue(q.Stack))
                            && Matches(damage, ItemModelProperties.DamageValue(q.Stack));
            }
            case "enchantments" or "stored_enchantments": {
                IDataComponent<(Minecraft.Data.Enchantments.IEnchantment, int)[]> component =
                    predicate == "enchantments" ? DataComponent.Enchantments : DataComponent.StoredEnchantments;
                (HashSet<string>? Ids, (int? Min, int? Max) Levels)[] wanted = (value as JArray ?? []).OfType<JObject>()
                    .Select(e => (Ids(e["enchantments"]), Bounds(e["levels"]))).ToArray();
                return q => {
                    (Minecraft.Data.Enchantments.IEnchantment Enchantment, int Level)[] own = ItemComponents.Get(q.Stack, component) ?? [];
                    return wanted.All(w => own.Any(e => (w.Ids == null || w.Ids.Contains(e.Enchantment.Identifier.ToString())) && Matches(w.Levels, e.Level)));
                };
            }
            case "potion_contents": {
                HashSet<string>? ids = Ids(value);
                return q => ItemComponents.Get(q.Stack, DataComponent.PotionContents)?.Potion is { } potion && (ids == null || ids.Contains(potion.Identifier.ToString()));
            }
        }
        baker.Warnings.Add($"component predicate {predicate} is not read");
        return _ => false;
    }

    private static (int? Min, int? Max) Bounds(JToken? token) => token switch {
        JValue exact when exact.Type == JTokenType.Integer => (exact.Value<int>(), exact.Value<int>()),
        JObject range => (range.Value<int?>("min"), range.Value<int?>("max")),
        _ => (null, null)
    };

    private static bool Matches((int? Min, int? Max) bounds, int value) => (bounds.Min == null || value >= bounds.Min) && (bounds.Max == null || value <= bounds.Max);

    /// <summary>A <c>HolderSet</c> of ids, null for any; a tag is not resolved and matches nothing.</summary>
    private static HashSet<string>? Ids(JToken? token) => token switch {
        null => null,
        JValue single when single.Value<string>() is { } id => id.StartsWith('#') ? [] : [Canonical(id)],
        JArray list => list.Select(i => i.Value<string>()).OfType<string>().Select(Canonical).ToHashSet(),
        _ => null
    };

    /// <summary><c>IsUsingItem</c>: the owner is using this very stack.</summary>
    public static bool UsingItem(ItemModelQuery query) => UseOf(query) is { ThisStack: true };

    /// <summary>
    /// What the owner is using, if this very stack is in the hand it uses. A remote entity counts its
    /// remaining ticks down from the item's use duration since the flag arrived, as vanilla's client does.
    /// </summary>
    private static (bool ThisStack, int Remaining)? UseOf(ItemModelQuery query) {
        if (query.Living is not { } owner) {
            return null;
        }
        if (owner is LocalPlayer local) {
            return local.IsUsingItem ? (query.HeldIn == local.UsedItemHand, local.UseItemRemainingTicks) : null;
        }
        if (!HumanoidEntityData.IsUsingItem(owner)) {
            return null;
        }
        return (query.HeldIn == HumanoidEntityData.UsedItemHand(owner),
            UsePrediction.UseDuration(HumanoidEntityData.UseItem(owner)) - HumanoidEntityData.Of(owner).TicksUsingItem);
    }

    /// <summary><c>getUseItemRemainingTicks</c>: zero when nothing is in use.</summary>
    private static int RemainingTicks(ItemModelQuery query, ClientEntity owner) => UseOf(query) is { } use ? use.Remaining : 0;

    /// <summary><c>FishingRodCast.get</c>: a hook out, and this stack in the hand <c>FishingHookRenderer.getHoldingArm</c> picks.</summary>
    private static bool FishingRodCast(ItemModelQuery query) {
        if (query.Living is not { } owner || !owner.Type.Equals(EntityType.Player) || query.Client is not { } client) {
            return false;
        }
        if (!client.Entities.Values.Any(e => e.Type.Equals(EntityType.FishingBobber) && e.SpawnData == owner.Id)) {
            return false;
        }
        Hand holding = owner.ItemInHand(Hand.MainHand).Type.Identifier == Item.FishingRod.Identifier ? Hand.MainHand : Hand.OffHand;
        return query.HeldIn == holding;
    }

    /// <summary>
    /// <c>LocalTime</c>: the pattern is Java's <c>SimpleDateFormat</c>, its common letters taken to .NET's,
    /// refreshed once a second.
    /// </summary>
    private Func<ItemModelQuery, string?> LocalTime(JObject node) {
        string format = JavaDateFormat(node.Value<string>("pattern") ?? "");
        string locale = node.Value<string>("locale") ?? "";
        CultureInfo culture;
        try {
            culture = locale.Length == 0 ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(locale.Replace('_', '-'));
        }
        catch (CultureNotFoundException) {
            culture = CultureInfo.InvariantCulture;
        }
        TimeZoneInfo zone = TimeZoneInfo.Local;
        if (node.Value<string>("time_zone") is { } zoneId) {
            try {
                zone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            }
            catch (Exception e) when (e is TimeZoneNotFoundException or InvalidTimeZoneException) {
                baker.Warnings.Add($"unknown time zone {zoneId}");
            }
        }
        long nextUpdate = 0;
        string last = "";
        return _ => {
            long now = Environment.TickCount64;
            if (now > nextUpdate) {
                last = TimeZoneInfo.ConvertTime(DateTime.UtcNow, zone).ToString(format, culture);
                nextUpdate = now + 1000;
            }
            return last;
        };
    }

    /// <summary>A <c>SimpleDateFormat</c> pattern as a .NET custom format: quoted text kept literal, <c>a</c> and <c>E</c> renamed, the rest shared.</summary>
    private static string JavaDateFormat(string pattern) {
        System.Text.StringBuilder result = new();
        for (int i = 0; i < pattern.Length; i++) {
            char c = pattern[i];
            if (c == '\'') {
                int end = pattern.IndexOf('\'', i + 1);
                string literal = end < 0 ? pattern[(i + 1)..] : pattern[(i + 1)..end];
                result.Append(literal.Length == 0 ? "\\'" : "\"" + literal + "\"");
                i = end < 0 ? pattern.Length : end;
                continue;
            }
            int run = 1;
            while (i + run < pattern.Length && pattern[i + run] == c) {
                run++;
            }
            result.Append(c switch {
                'a' => "tt",
                'E' => run >= 4 ? "dddd" : "ddd",
                'S' => new string('f', Math.Min(run, 7)),
                'u' => "%d",
                _ when char.IsLetter(c) && "yMdHhms".Contains(c) => new string(c, run),
                _ when char.IsLetter(c) => "",
                _ => "\\" + new string(c, 1) + (run > 1 ? new string(c, run - 1) : "")
            });
            i += run - 1;
        }
        return result.ToString();
    }

    /// <summary>
    /// <c>ItemTintSources</c>: each source as what it gives a query, as 0xRRGGBB. A grass tint is read from
    /// the colour map at the temperature and downfall it names.
    /// </summary>
    private Func<ItemModelQuery, uint> Tint(JObject source) {
        string type = Path(source.Value<string>("type"));
        int Default(int fallback) => source["default"] is { } value ? Colour(value) : fallback;
        switch (type) {
            case "constant": {
                uint value = (uint)Colour(source["value"]) & 0xFFFFFF;
                return _ => value;
            }
            case "grass": {
                uint value = maps.Grass is { } grass ? GrassAt(grass, source.Value<float?>("temperature") ?? 0.5F, source.Value<float?>("downfall") ?? 1.0F) : 0xFFFFFF;
                return _ => value;
            }
            case "dye": {
                int fallback = Default(-1);
                return q => (uint)ItemModelProperties.DyeColour(q.Stack, fallback) & 0xFFFFFF;
            }
            case "firework": {
                int fallback = Default(-7697782);
                return q => (uint)ItemModelProperties.FireworkColour(q.Stack, fallback) & 0xFFFFFF;
            }
            case "potion": {
                int fallback = Default(-13083194);
                return q => (uint)ItemModelProperties.PotionColour(q.Stack, fallback) & 0xFFFFFF;
            }
            case "map_color": {
                // MapItemColor.DEFAULT.
                int fallback = Default(4603950);
                return q => (uint)ItemModelProperties.MapColour(q.Stack, fallback) & 0xFFFFFF;
            }
            case "custom_model_data": {
                int index = source.Value<int?>("index") ?? 0;
                int fallback = Default(-1);
                return q => (uint)(ItemModelProperties.CustomModelDataColour(q.Stack, index) ?? fallback) & 0xFFFFFF;
            }
            case "team": {
                int fallback = Default(-1);
                return q => (uint)(TeamColour(q) ?? fallback) & 0xFFFFFF;
            }
        }
        baker.Warnings.Add($"tint source {type} is not known");
        return _ => 0xFFFFFF;
    }

    /// <summary><c>owner.getTeam().getColor()</c>.</summary>
    private static int? TeamColour(ItemModelQuery query) =>
        query.Living is { } owner && query.Client is { } client ? client.TeamOf(owner)?.Rgb : null;

    private static uint GrassAt(TextureImage map, float temperature, float downfall) {
        downfall *= temperature;
        int index = (int)((1.0 - downfall) * 255.0) << 8 | (int)((1.0 - temperature) * 255.0);
        if (index >= map.Width * map.Height) {
            return 0xFFFFFF;
        }
        return (uint)(map.Rgba[index * 4] << 16 | map.Rgba[index * 4 + 1] << 8 | map.Rgba[index * 4 + 2]);
    }

    /// <summary><c>ExtraCodecs.RGB_COLOR_CODEC</c>: a packed integer, or red, green and blue from 0 to 1.</summary>
    private static int Colour(JToken? token) => token switch {
        JArray rgb when rgb.Count >= 3 => (int)(rgb[0].Value<float>() * 255) << 16 | (int)(rgb[1].Value<float>() * 255) << 8 | (int)(rgb[2].Value<float>() * 255),
        JValue value when value.Type == JTokenType.Integer => (int)value.Value<long>(),
        _ => -1
    };

    /// <summary>
    /// <c>Transformation.EXTENDED_CODEC</c>: sixteen floats of a row major matrix, or translation, left
    /// rotation, scale and right rotation composed in that order. As row vectors here, so composed backwards.
    /// </summary>
    private static Matrix4x4 TransformationOf(JToken json) {
        if (json is JArray { Count: 16 } values) {
            Matrix4x4 m = default;
            for (int i = 0; i < 16; i++) {
                // setRowColumn(i >> 2, i & 3) on a column vector matrix is element [i & 3, i >> 2] here.
                m[i & 3, i >> 2] = values[i].Value<float>();
            }
            return m;
        }
        if (json is not JObject parts) {
            return Matrix4x4.Identity;
        }
        Vector3 translation = Vector3Of(parts["translation"], Vector3.Zero);
        Vector3 scale = Vector3Of(parts["scale"], Vector3.One);
        Quaternion left = QuaternionOf(parts["left_rotation"]);
        Quaternion right = QuaternionOf(parts["right_rotation"]);
        return Matrix4x4.CreateFromQuaternion(right) * Matrix4x4.CreateScale(scale) * Matrix4x4.CreateFromQuaternion(left) * Matrix4x4.CreateTranslation(translation);
    }

    private static Vector3 Vector3Of(JToken? token, Vector3 fallback) =>
        token is JArray { Count: 3 } v ? new Vector3(v[0].Value<float>(), v[1].Value<float>(), v[2].Value<float>()) : fallback;

    /// <summary><c>ExtraCodecs.QUATERNIONF</c>: x, y, z and w, or an angle in radians about an axis.</summary>
    private static Quaternion QuaternionOf(JToken? token) => token switch {
        JArray { Count: 4 } q => new Quaternion(q[0].Value<float>(), q[1].Value<float>(), q[2].Value<float>(), q[3].Value<float>()),
        JObject axisAngle => Quaternion.CreateFromAxisAngle(Vector3.Normalize(Vector3Of(axisAngle["axis"], Vector3.UnitY)), axisAngle.Value<float>("angle")),
        _ => Quaternion.Identity
    };

    /// <summary><c>NeedleDirectionHelper.get</c>: nothing without an owner, the owner's level without one given.</summary>
    private abstract class NeedleDirection {
        public float Get(ItemModelQuery query) {
            if (query.Owner is not { } owner) {
                return 0.0F;
            }
            ClientLevel? level = query.Level ?? query.Client?.Level;
            return level == null ? 0.0F : Calculate(query, level, owner);
        }

        protected abstract float Calculate(ItemModelQuery query, ClientLevel level, ClientEntity owner);
    }

    /// <summary><c>Time</c>.</summary>
    private sealed class NeedleTime(bool wobble, string source) : NeedleDirection {
        private readonly NeedleWobbler _wobbler = new(wobble, 0.9F);
        private readonly Random _random = new();

        protected override float Calculate(ItemModelQuery query, ClientLevel level, ClientEntity owner) {
            float targetRotation = source switch {
                // EnvironmentAttributes.SUN_ANGLE over 360, which the overworld's timeline eases through the
                // day; this client draws its sun by the classic curve, so the clock reads that.
                "daytime" => Rendering.Lighting.TimeOfDay(level.DefaultClockTime),
                // MOON_PHASE: a phase a day through the eight, as the overworld's moon timeline steps them.
                "moon_phase" => (float)(level.DefaultClockTime / 24000L % 8L) / 8,
                _ => _random.NextSingle()
            };
            long gameTime = level.GameTime;
            if (_wobbler.ShouldUpdate(gameTime)) {
                _wobbler.Update(gameTime, targetRotation);
            }
            return _wobbler.Rotation;
        }
    }

    /// <summary><c>CompassAngle</c> over <c>CompassAngleState</c>.</summary>
    private sealed class CompassAngle(bool wobble, string target) : NeedleDirection {
        private readonly NeedleWobbler _wobbler = new(wobble, 0.8F);
        private readonly NeedleWobbler _noTargetWobbler = new(wobble, 0.8F);
        private readonly Random _random = new();

        protected override float Calculate(ItemModelQuery query, ClientLevel level, ClientEntity owner) {
            (Identifier Dimension, int X, int Y, int Z)? targetPos = Target(query, level);
            long gameTime = level.GameTime;
            return !IsValidCompassTargetPos(owner, level, targetPos)
                ? RandomlySpinningRotation(query.Seed, gameTime)
                : RotationTowardsCompassTarget(owner, level, gameTime, targetPos!.Value);
        }

        /// <summary><c>CompassTarget.get</c>.</summary>
        private (Identifier, int, int, int)? Target(ItemModelQuery query, ClientLevel level) {
            switch (target) {
                case "lodestone":
                    return ItemComponents.Get(query.Stack, DataComponent.LodestoneTracker)?.Target is { } lodestone
                        ? (lodestone.Dimension, lodestone.Position.X, lodestone.Position.Y, lodestone.Position.Z)
                        : null;
                case "spawn":
                    return level.RespawnPosition;
                case "recovery":
                    return query.Living is LocalPlayer player ? player.LastDeathLocation : null;
                default:
                    return null;
            }
        }

        private float RandomlySpinningRotation(int seed, long gameTime) {
            if (_noTargetWobbler.ShouldUpdate(gameTime)) {
                _noTargetWobbler.Update(gameTime, _random.NextSingle());
            }
            float targetRotation = _noTargetWobbler.Rotation + unchecked(seed * 1327217883) / 2.1474836E9F;
            return NeedleWobbler.PositiveModulo(targetRotation, 1.0F);
        }

        private float RotationTowardsCompassTarget(ClientEntity owner, ClientLevel level, long gameTime, (Identifier, int X, int Y, int Z) target) {
            float angleToTarget = (float)(Math.Atan2(target.Z + 0.5 - owner.Position.Z, target.X + 0.5 - owner.Position.X) / (float)(Math.PI * 2));
            float ownerYRotation = NeedleWobbler.PositiveModulo(VisualRotationY(owner) / 360.0F, 1.0F);
            float targetRotation;
            if (owner is LocalPlayer && level.TickRateManager.RunsNormally) {
                if (_wobbler.ShouldUpdate(gameTime)) {
                    _wobbler.Update(gameTime, 0.5F - (ownerYRotation - 0.25F));
                }
                targetRotation = angleToTarget + _wobbler.Rotation;
            }
            else {
                targetRotation = 0.5F - (ownerYRotation - 0.25F - angleToTarget);
            }
            return NeedleWobbler.PositiveModulo(targetRotation, 1.0F);
        }

        /// <summary><c>isValidCompassTargetPos</c>.</summary>
        private static bool IsValidCompassTargetPos(ClientEntity owner, ClientLevel level, (Identifier Dimension, int X, int Y, int Z)? pos) {
            if (pos is not { } target || !target.Dimension.Equals(level.Name)) {
                return false;
            }
            double dx = target.X + 0.5 - owner.Position.X, dy = target.Y + 0.5 - owner.Position.Y, dz = target.Z + 0.5 - owner.Position.Z;
            return !(dx * dx + dy * dy + dz * dz < 1.0E-5F);
        }
    }

    /// <summary>
    /// <c>getVisualRotationYInDegrees</c>: a living entity's body, a dropped item's spin, a frame's facing
    /// and turn, anything else its own yaw.
    /// </summary>
    private static float VisualRotationY(ClientEntity owner) {
        if (owner is LocalPlayer) {
            return owner.YRot;
        }
        if (owner.Type.Equals(EntityType.Item)) {
            return 180.0F - ItemEntityRenderer.Spin(owner) / (float)(Math.PI * 2) * 360.0F;
        }
        if (owner.Type.Equals(EntityType.ItemFrame) || owner.Type.Equals(EntityType.GlowItemFrame)) {
            Minecraft.Schemas.Blocks.BlockEnums.Cardinal direction = owner.Get(EntityDataFields.HangingEntity.Direction, Minecraft.Schemas.Blocks.BlockEnums.Cardinal.South);
            int rotationCorrection = direction switch {
                Minecraft.Schemas.Blocks.BlockEnums.Cardinal.Up => 90,
                Minecraft.Schemas.Blocks.BlockEnums.Cardinal.Down => -90,
                _ => 0
            };
            return Rendering.Entities.Mth.WrapDegrees(180 + ItemFrameRenderer.Get2DDataValue(direction) * 90 + owner.Get(EntityDataFields.ItemFrame.Rotation) * 45 + rotationCorrection);
        }
        return owner.IsLiving ? owner.YBodyRot : owner.YRot;
    }
}
