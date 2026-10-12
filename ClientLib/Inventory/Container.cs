namespace ClientLib.Inventory;

/// <summary>Vanilla's <c>Container</c>: numbered stacks a menu's slots point into.</summary>
public abstract class Container {
    public abstract int Size { get; }
    public abstract Stack Get(int index);
    public abstract void Set(int index, Stack stack);

    /// <summary><c>Container.getMaxStackSize</c>, the cap before an item's own.</summary>
    public virtual int MaxStackSize => 99;

    /// <summary><c>ContainerHelper.removeItem</c>: splits off up to <paramref name="amount"/>.</summary>
    public virtual Stack Remove(int index, int amount) {
        Stack stack = Get(index);
        return index >= 0 && index < Size && !stack.IsEmpty && amount > 0 ? stack.Split(amount) : Stack.Empty;
    }

    public void Clear() {
        for (int i = 0; i < Size; i++) {
            Set(i, Stack.Empty);
        }
    }
}

public sealed class SimpleContainer(int size) : Container {
    private readonly Stack[] _items = Enumerable.Range(0, size).Select(_ => Stack.Empty).ToArray();

    public override int Size => _items.Length;
    public override Stack Get(int index) => _items[index];
    public override void Set(int index, Stack stack) => _items[index] = stack;
}

/// <summary>A result slot's container, which vanilla caps at the item's own size like any other.</summary>
public sealed class ResultContainer() : Container {
    private Stack _item = Stack.Empty;

    public override int Size => 1;
    public override Stack Get(int index) => _item;
    public override void Set(int index, Stack stack) => _item = stack;

    /// <summary><c>ResultContainer.removeItem</c> takes the whole stack whatever amount is asked for.</summary>
    public override Stack Remove(int index, int amount) {
        Stack taken = _item;
        _item = Stack.Empty;
        return taken;
    }
}
