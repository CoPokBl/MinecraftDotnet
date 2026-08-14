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
/// between an item and an alternatives block: a singleton offers itself when its conditions hold, and
/// a composite delegates to its children.
/// </summary>
public abstract record LootEntryContainer(ILootCondition[] Conditions) {
    /// <summary>
    /// Adds the entries this container offers to <paramref name="output"/> and reports whether it
    /// offered any. <b>The return value is what makes <c>alternatives</c> work</b>: it stops at the
    /// first child that says yes, so a silk touch branch shadows the branch after it.
    /// </summary>
    public abstract bool Expand(LootContext context, List<ILootEntry> output);

    protected bool CanRun(LootContext context) {
        foreach (ILootCondition condition in Conditions) {
            if (!condition.Test(context)) {
                return false;
            }
        }

        return true;
    }
}

/// <summary>
/// <c>LootPoolSingletonContainer</c>: one entry, carrying a weight, a quality and its own functions.
/// The functions run on what this entry produces, before the pool's and the table's.
/// </summary>
public abstract record LootSingletonEntry(
    ILootCondition[] Conditions,
    int Weight,
    int Quality,
    LootFunction[] Functions) : LootEntryContainer(Conditions), ILootEntry {

    public override bool Expand(LootContext context, List<ILootEntry> output) {
        if (!CanRun(context)) {
            return false;
        }

        output.Add(this);
        return true;
    }

    /// <summary><c>LootPoolSingletonContainer.EntryBase.getWeight</c>.</summary>
    public int GetWeight(float luck) {
        return Math.Max(Mth.Floor(Weight + Quality * luck), 0);
    }

    public void CreateItemStack(Action<ItemStack> output, LootContext context) {
        CreateRawItemStack(stack => output(LootTable.ApplyAll(Functions, stack, context)), context);
    }

    protected abstract void CreateRawItemStack(Action<ItemStack> output, LootContext context);
}

/// <summary><c>LootItem</c>: one stack of one item, count one before the functions run.</summary>
public sealed record ItemLootEntry(
    Identifier Item,
    ILootCondition[] Conditions,
    int Weight,
    int Quality,
    LootFunction[] Functions) : LootSingletonEntry(Conditions, Weight, Quality, Functions) {

    protected override void CreateRawItemStack(Action<ItemStack> output, LootContext context) {
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
    ILootCondition[] Conditions,
    int Weight,
    int Quality,
    LootFunction[] Functions) : LootSingletonEntry(Conditions, Weight, Quality, Functions) {

    protected override void CreateRawItemStack(Action<ItemStack> output, LootContext context) { }
}

/// <summary>
/// <c>AlternativesEntry</c>: the first child that expands wins and the rest are never consulted. This
/// is the shape almost every block table is built on, and it is what silk touch rides: the enchanted
/// branch comes first and shadows the ordinary drop.
/// </summary>
public sealed record AlternativesLootEntry(
    LootEntryContainer[] Children,
    ILootCondition[] Conditions) : LootEntryContainer(Conditions) {

    public override bool Expand(LootContext context, List<ILootEntry> output) {
        if (!CanRun(context)) {
            return false;
        }

        foreach (LootEntryContainer child in Children) {
            if (child.Expand(context, output)) {
                return true;
            }
        }

        return false;
    }
}
