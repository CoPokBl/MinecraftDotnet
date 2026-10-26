using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Loot;

/// <summary>
/// A pool, vanilla's <c>LootPool</c>: rolled a number of times, each roll picking one entry by weight
/// from whatever the entries expand to.
/// <p/>
/// <c>bonus_rolls</c> is modelled because the codec has it, but every block table leaves it at zero
/// and luck is zero for a block break, so it never adds a roll here.
/// </summary>
public sealed record LootPool(
    IContextIntProvider Rolls,
    LootEntryContainer[] Entries,
    ILootCondition? Condition,
    LootFunction? Modifier,
    IContextFloatProvider? BonusRolls = null) {

    public void AddRandomItems(Action<ItemStack> output, LootContext context) {
        if (Condition != null && !Condition.Test(context)) {
            return;
        }

        Action<ItemStack> decorated = LootTable.Decorate(Modifier, output, context);

        int count = Rolls.GetInt(context)
            + Mth.Floor((BonusRolls?.GetFloat(context) ?? 0f) * context.Luck);

        for (int i = 0; i < count; i++) {
            AddRandomItem(decorated, context);
        }
    }

    /// <summary>
    /// <c>LootPool.addRandomItem</c>: expand every entry, then pick one of the results weighted.
    /// A single valid entry skips the draw entirely, which is why an ordinary one item table does not
    /// consume a random number and a two branch one does.
    /// </summary>
    private void AddRandomItem(Action<ItemStack> output, LootContext context) {
        List<ILootEntry> validEntries = [];
        int totalWeight = 0;

        foreach (LootEntryContainer entry in Entries) {
            List<ILootEntry> expanded = [];
            entry.Expand(context, expanded);

            foreach (ILootEntry candidate in expanded) {
                int weight = candidate.GetWeight(context.Luck);
                if (weight > 0) {
                    validEntries.Add(candidate);
                    totalWeight += weight;
                }
            }
        }

        if (totalWeight == 0 || validEntries.Count == 0) {
            return;
        }

        if (validEntries.Count == 1) {
            validEntries[0].CreateItemStack(output, context);
            return;
        }

        int index = context.Random.NextInt(totalWeight);
        foreach (ILootEntry entry in validEntries) {
            index -= entry.GetWeight(context.Luck);
            if (index < 0) {
                entry.CreateItemStack(output, context);
                return;
            }
        }
    }
}

/// <summary>
/// A loot table, vanilla's <c>LootTable</c>. Immutable, and the generated vanilla ones are shared
/// between every server in the process, so nothing on this type or anything it holds may gain
/// mutable state.
/// </summary>
public sealed record LootTable(LootPool[] Pools, LootFunction? Modifier) {
    public static readonly LootTable Empty = new([], null);

    public LootTable(LootPool[] pools) : this(pools, null) { }

    /// <summary>
    /// <c>LootTable.getRandomItems</c>, splitter included. The split is not a detail: a table asking
    /// for sixty four of something whose stack limit is sixteen produces four stacks upstream, and one
    /// oversized stack here would be a stack the client cannot hold.
    /// </summary>
    public ItemStack[] GetRandomItems(LootContext context) {
        List<ItemStack> result = [];
        GetRandomItemsRaw(stack => Split(stack, result), context);
        return result.ToArray();
    }

    /// <summary><c>LootTable.getRandomItemsRaw</c>: the table's own modifier wraps every pool.</summary>
    public void GetRandomItemsRaw(Action<ItemStack> output, LootContext context) {
        Action<ItemStack> decorated = Decorate(Modifier, output, context);

        foreach (LootPool pool in Pools) {
            pool.AddRandomItems(decorated, context);
        }
    }

    /// <summary><c>LootTable.createStackSplitter</c>.</summary>
    private static void Split(ItemStack stack, List<ItemStack> output) {
        if (stack.IsAir() || stack.Count <= 0) {
            return;
        }

        int maxStackSize = stack.GetMaxStackSize();
        if (stack.Count < maxStackSize) {
            output.Add(stack);
            return;
        }

        int remaining = stack.Count;
        while (remaining > 0) {
            int taken = Math.Min(maxStackSize, remaining);
            remaining -= taken;
            output.Add(stack.WithCount(taken));
        }
    }

    /// <summary><c>LootItemFunction.decorate</c>.</summary>
    internal static Action<ItemStack> Decorate(LootFunction? modifier, Action<ItemStack> output,
        LootContext context) {
        return modifier == null ? output : stack => output(modifier.Apply(stack, context));
    }
}
