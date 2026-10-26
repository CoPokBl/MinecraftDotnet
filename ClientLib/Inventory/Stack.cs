using Minecraft.Data.Components;
using Minecraft.Data.Generated;
using Items = Minecraft.Data.Generated.Item;
using Minecraft.Data.Items;
using Minecraft.Schemas.Items;

namespace ClientLib.Inventory;

/// <summary>
/// A mutable item stack, vanilla's <c>ItemStack</c>. The container click code shrinks, grows and
/// splits stacks in place and relies on two slots sharing one stack object, so it is ported against
/// this rather than the immutable <see cref="ItemStack"/>, which is what goes in and out of it.
/// </summary>
public sealed class Stack {
    /// <summary>A fresh empty stack. Vanilla's <c>EMPTY</c> is a singleton nothing mutates; a new one each time keeps that true here.</summary>
    public static Stack Empty => new(Items.Air, 0, ItemStack.Air);

    /// <summary>The components this stack patches, carried from the stack it was made from.</summary>
    private ItemStack _template;

    public IItem Item { get; private set; }
    public int Count { get; set; }

    private Stack(IItem item, int count, ItemStack template) {
        Item = item;
        Count = count;
        _template = template;
    }

    public static Stack Of(ItemStack stack) {
        return stack.IsAir() ? Empty : new Stack(stack.Type, stack.Count, stack);
    }

    public ItemStack ToItemStack() {
        return IsEmpty ? ItemStack.Air : _template.WithCount(Count);
    }

    public bool IsEmpty => Count <= 0 || Item.Identifier == Items.Air.Identifier;

    public int MaxStackSize => _template.IsAir() ? ItemStack.Air.GetMaxStackSize() : _template.GetMaxStackSize();

    public bool IsStackable => MaxStackSize > 1;

    public bool IsDamageable => !_template.IsAir() && _template.Has(DataComponent.MaxDamage) && !_template.Has(DataComponent.Unbreakable) && _template.Has(DataComponent.Damage);

    public bool IsDamaged => IsDamageable && _template.Get(DataComponent.Damage) > 0;

    public ItemStack Template => _template;

    public Stack Copy() => IsEmpty ? Empty : new Stack(Item, Count, _template);

    public Stack CopyWithCount(int count) => IsEmpty ? Empty : new Stack(Item, count, _template);

    /// <summary>Takes up to <paramref name="amount"/> off this stack into a new one.</summary>
    public Stack Split(int amount) {
        int taken = Math.Min(amount, Count);
        Stack result = CopyWithCount(taken);
        Shrink(taken);
        return result;
    }

    public void Grow(int amount) => Count += amount;

    public void Shrink(int amount) => Count -= amount;

    public bool Is(IItem item) => Item.Identifier == item.Identifier;

    public static bool IsSameItem(Stack a, Stack b) => a.Item.Identifier == b.Item.Identifier;

    /// <summary><c>ItemStack.isSameItemSameComponents</c>: two empties match, as vanilla's do.</summary>
    public static bool IsSameItemSameComponents(Stack a, Stack b) {
        if (!IsSameItem(a, b)) {
            return false;
        }
        if (a.IsEmpty && b.IsEmpty) {
            return true;
        }
        return a._template.CanStackWith(b._template);
    }

    /// <summary><c>ItemStack.matches</c>: same item, components and count.</summary>
    public static bool Matches(Stack a, Stack b) {
        if (a == b) {
            return true;
        }
        return a.Count == b.Count && IsSameItemSameComponents(a, b);
    }

    public T? Get<T>(IDataComponent<T> component) where T : class {
        return _template.IsAir() ? null : _template.GetOrNull(component);
    }

    public bool Has<T>(IDataComponent<T> component) => !_template.IsAir() && _template.Has(component);

    /// <summary>
    /// <c>ItemStack.set</c>, in place. As in <c>PatchedDataComponentMap.set</c>, a value equal to the item's
    /// default leaves the patch rather than joining it, which the hash a click sends depends on.
    /// </summary>
    /// <param name="missingDefault">The item's default where the generated defaults leave it out, as they do every empty list.</param>
    public void Set<T>(IDataComponent<T> component, T value, T? missingDefault = default) where T : notnull {
        if (_template.IsAir()) {
            return;
        }
        Dictionary<IDataComponent, object> components = _template.Components.Where(c => !c.Key.Equals(component)).ToDictionary();
        IDataComponent[] removed = _template.RemoveComponents.Where(c => !c.Equals(component)).ToArray();
        object? fallback = Item.DefaultComponents.TryGetValue(component, out object? generated) ? generated : missingDefault;
        if (fallback == null || !component.ValuesEqual(fallback, value)) {
            components[component] = value;
        }
        _template = new ItemStack(_template.Type, _template.Count, components, removed);
    }

    public override string ToString() => IsEmpty ? "empty" : $"{Count} {Item.Identifier}";
}
