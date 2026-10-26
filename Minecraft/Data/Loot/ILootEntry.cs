using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Loot;

/// <summary>
/// What a pool picks between, vanilla's <c>LootPoolEntry</c>: a weight and something that produces
/// stacks. One <see cref="LootEntryContainer"/> can produce several of these, or none.
/// </summary>
public interface ILootEntry {
    public int GetWeight(float luck);
    public void CreateItemStack(Action<ItemStack> output, LootContext context);
}

/// <summary>
/// Vanilla's <c>LootPoolEntryContainer</c>. <see cref="Expand"/> is the whole of the difference
/// between an item and an alternatives block: a single entry offers itself when its condition holds,
/// and a composite delegates to its children.
/// <p/>
/// The modifier belongs to the container rather than to what it produces, so a composite's modifier
/// runs on every child's stack, after the child's own (<c>LootPoolEntryContainer.adjustOutput</c>).
/// </summary>
public abstract record LootEntryContainer(ILootCondition? Condition, LootFunction? Modifier) {
    /// <summary>
    /// Adds the entries this container offers to <paramref name="output"/> and reports whether it
    /// offered any. <b>The return value is what makes <c>alternatives</c> work</b>: it stops at the
    /// first child that says yes, so a silk touch branch shadows the branch after it.
    /// </summary>
    public bool Expand(LootContext context, List<ILootEntry> output) {
        if (Condition != null && !Condition.Test(context)) {
            return false;
        }

        if (Modifier == null) {
            return ExpandRaw(context, output);
        }

        int first = output.Count;
        bool expanded = ExpandRaw(context, output);
        for (int i = first; i < output.Count; i++) {
            output[i] = new ModifiedEntry(output[i], Modifier);
        }

        return expanded;
    }

    protected abstract bool ExpandRaw(LootContext context, List<ILootEntry> output);

    private sealed record ModifiedEntry(ILootEntry Inner, LootFunction Modifier) : ILootEntry {
        public int GetWeight(float luck) => Inner.GetWeight(luck);

        public void CreateItemStack(Action<ItemStack> output, LootContext context) {
            Inner.CreateItemStack(stack => output(Modifier.Apply(stack, context)), context);
        }
    }
}

/// <summary>
/// <c>SingleEntryContainerBase</c>: one entry, carrying a weight and a quality.
/// </summary>
public abstract record LootSingletonEntry(
    ILootCondition? Condition,
    int Weight,
    int Quality,
    LootFunction? Modifier) : LootEntryContainer(Condition, Modifier), ILootEntry {

    protected override bool ExpandRaw(LootContext context, List<ILootEntry> output) {
        output.Add(this);
        return true;
    }

    /// <summary><c>UniformContainerBase.EntryBase.getWeight</c>.</summary>
    public int GetWeight(float luck) {
        return Math.Max(Mth.Floor(Weight + Quality * luck), 0);
    }

    public abstract void CreateItemStack(Action<ItemStack> output, LootContext context);
}

/// <summary><c>LootItem</c>: one stack of one item, count one before any modifier runs.</summary>
public sealed record ItemLootEntry(
    Identifier Item,
    ILootCondition? Condition,
    int Weight,
    int Quality,
    LootFunction? Modifier) : LootSingletonEntry(Condition, Weight, Quality, Modifier) {

    public override void CreateItemStack(Action<ItemStack> output, LootContext context) {
        output(new ItemStack(context.Registry.Items[Item]));
    }
}

/// <summary>
/// <c>DynamicLoot</c>: whatever the block itself decides to drop, keyed by a name the block knows.
/// <p/>
/// <b>Inert today.</b> The one block table using it is <c>decorated_pot</c> asking for
/// <c>minecraft:sherds</c>, which come off the block entity, and there is no port of the block entity
/// to item conversion. The pot itself still drops. See <see cref="CopyComponentsFunction"/>, which is
/// the same gap.
/// </summary>
public sealed record DynamicLootEntry(
    Identifier Name,
    ILootCondition? Condition,
    int Weight,
    int Quality,
    LootFunction? Modifier) : LootSingletonEntry(Condition, Weight, Quality, Modifier) {

    public override void CreateItemStack(Action<ItemStack> output, LootContext context) { }
}

/// <summary>
/// <c>AlternativesEntry</c>: the first child that expands wins and the rest are never consulted. This
/// is the shape almost every block table is built on, and it is what silk touch rides: the enchanted
/// branch comes first and shadows the ordinary drop.
/// </summary>
public sealed record AlternativesLootEntry(
    LootEntryContainer[] Children,
    ILootCondition? Condition,
    LootFunction? Modifier) : LootEntryContainer(Condition, Modifier) {

    protected override bool ExpandRaw(LootContext context, List<ILootEntry> output) {
        foreach (LootEntryContainer child in Children) {
            if (child.Expand(context, output)) {
                return true;
            }
        }

        return false;
    }
}
