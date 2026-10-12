using Minecraft.Data.Components;
using Minecraft.Schemas.Items;

namespace ClientLib.Interaction;

public static class ItemComponents {
    /// <summary>
    /// <c>ItemStack.get</c>: the stack's own value, else the item's default unless the stack removed it.
    /// A stack on the wire carries only its differences from the item.
    /// </summary>
    public static T? Get<T>(ItemStack stack, IDataComponent<T> component) where T : notnull {
        if (stack.Components.TryGetValue(component, out object? value)) {
            return (T)value;
        }
        if (stack.RemoveComponents.Contains(component)) {
            return default;
        }
        return stack.Type.DefaultComponents.TryGetValue(component, out object? fallback) ? (T)fallback : default;
    }

    public static bool Has(ItemStack stack, IDataComponent component) {
        if (stack.Components.ContainsKey(component)) {
            return true;
        }
        return !stack.RemoveComponents.Contains(component) && stack.Type.DefaultComponents.ContainsKey(component);
    }

    public static bool IsEmpty(ItemStack stack) => stack.Count <= 0 || stack.IsAir();
}
