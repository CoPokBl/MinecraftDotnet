using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;

namespace ClientLib.Inventory;

/// <summary>What a menu needs to know about the player using it.</summary>
public interface IMenuUser {
    /// <summary><c>Player.hasInfiniteMaterials</c>: creative mode.</summary>
    bool InfiniteMaterials { get; }

    bool IsCreative { get; }
    int ExperienceLevel { get; }
    Player.PlayerInventory Inventory { get; }

    /// <summary>Where a stack thrown out of a menu goes; the client only forgets it, the server spawns the item.</summary>
    void Drop(Stack stack);

    /// <summary><c>LocalPlayer.playSound</c>: a sound only this player hears, where it stands.</summary>
    void PlaySound(Minecraft.Data.Sounds.ISoundType sound, float volume, float pitch);

    /// <summary><c>level().getRandom()</c>, which a bundle's sounds draw their pitch from.</summary>
    Minecraft.Schemas.RandomSource Random { get; }
}

/// <summary>Vanilla's <c>Slot</c>: one position of a container as a menu shows it.</summary>
public class Slot(Container container, int containerSlot, int x, int y) {
    public Container Container { get; } = container;
    public int ContainerSlot { get; } = containerSlot;

    /// <summary>The slot's position in its menu, assigned as slots are added.</summary>
    public int Index { get; internal set; }

    /// <summary>Where the slot sits on the menu's panel, in GUI pixels, vanilla's layout.</summary>
    public int X { get; } = x;
    public int Y { get; } = y;

    public Stack Item => Container.Get(ContainerSlot);
    public bool HasItem => !Item.IsEmpty;

    public virtual bool MayPlace(Stack stack) => true;
    public virtual bool MayPickup(IMenuUser user) => true;
    public virtual int MaxStackSize => Container.MaxStackSize;
    public virtual int MaxStackSizeFor(Stack stack) => Math.Min(MaxStackSize, stack.MaxStackSize);

    /// <summary>Slots the player cannot pick up or put into, such as the crafter's preview.</summary>
    public virtual bool IsFake => false;

    public virtual void Set(Stack stack) => Container.Set(ContainerSlot, stack);
    public virtual void SetByPlayer(Stack stack) => Set(stack);
    public virtual Stack Remove(int amount) => Container.Remove(ContainerSlot, amount);
    public virtual void OnTake(IMenuUser user, Stack carried) {
    }

    public virtual bool AllowModification(IMenuUser user) => MayPickup(user) && MayPlace(Item);

    /// <summary><c>Slot.tryRemove</c>.</summary>
    public virtual Stack? TryRemove(int amount, int maxAmount, IMenuUser user) {
        if (!MayPickup(user)) {
            return null;
        }
        if (!AllowModification(user) && maxAmount < Item.Count) {
            return null;
        }
        amount = Math.Min(amount, maxAmount);
        Stack result = Remove(amount);
        if (result.IsEmpty) {
            return null;
        }
        if (Item.IsEmpty) {
            SetByPlayer(Stack.Empty);
        }
        return result;
    }

    public virtual Stack SafeTake(int amount, int maxAmount, IMenuUser user) {
        Stack? result = TryRemove(amount, maxAmount, user);
        if (result != null) {
            OnTake(user, result);
        }
        return result ?? Stack.Empty;
    }

    public virtual Stack SafeClone(IMenuUser user) {
        Stack item = Item;
        return item.CopyWithCount(item.MaxStackSize);
    }

    public Stack SafeInsert(Stack stack) => SafeInsert(stack, stack.Count);

    /// <summary><c>Slot.safeInsert</c>: returns what is left of the input, which is the input itself.</summary>
    public virtual Stack SafeInsert(Stack input, int amount) {
        if (input.IsEmpty || !MayPlace(input)) {
            return input;
        }
        Stack slotStack = Item;
        int transferable = Math.Min(Math.Min(amount, input.Count), MaxStackSizeFor(input) - slotStack.Count);
        if (transferable <= 0) {
            return input;
        }
        if (slotStack.IsEmpty) {
            SetByPlayer(input.Split(transferable));
        }
        else if (Stack.IsSameItemSameComponents(slotStack, input)) {
            input.Shrink(transferable);
            slotStack.Grow(transferable);
            SetByPlayer(slotStack);
        }
        return input;
    }
}

/// <summary>A slot with a placement rule and nothing else special.</summary>
public class FilteredSlot(Container container, int containerSlot, int x, int y, Func<Stack, bool> mayPlace, int maxStackSize = -1)
    : Slot(container, containerSlot, x, y) {
    public override bool MayPlace(Stack stack) => mayPlace(stack);
    public override int MaxStackSize => maxStackSize > 0 ? maxStackSize : base.MaxStackSize;
}

/// <summary>
/// A slot the player only takes from, whose taking changes the inputs: the result of a furnace,
/// a stonecutter, a loom, a merchant and the like. What the take does is passed in.
/// </summary>
public class OutputSlot(Container container, int containerSlot, int x, int y, Action<IMenuUser, Stack>? onTake = null, Func<IMenuUser, bool>? mayPickup = null)
    : Slot(container, containerSlot, x, y) {
    public override bool MayPlace(Stack stack) => false;
    public override bool MayPickup(IMenuUser user) => mayPickup?.Invoke(user) ?? true;
    public override void OnTake(IMenuUser user, Stack carried) => onTake?.Invoke(user, carried);
}

/// <summary><c>ArmorSlot</c>: one piece of equipment, only what equips there, and stuck while cursed.</summary>
public sealed class ArmorSlot(Container container, EquippableComponent.Slot slot, int containerSlot, int x, int y)
    : Slot(container, containerSlot, x, y) {
    public EquippableComponent.Slot EquipmentSlot { get; } = slot;

    public override int MaxStackSize => 1;

    public override bool MayPlace(Stack stack) => ItemRules.EquipmentSlotFor(stack) == EquipmentSlot;

    /// <summary>
    /// Binding is the only enchantment with <c>prevent_armor_change</c> in vanilla's data, and the
    /// client has no enchantment effects to ask, so it is matched by key.
    /// </summary>
    public override bool MayPickup(IMenuUser user) {
        Stack item = Item;
        if (!item.IsEmpty && !user.IsCreative && ItemRules.HasEnchantment(item, Enchantment.BindingCurse)) {
            return false;
        }
        return base.MayPickup(user);
    }
}

/// <summary>
/// <c>ResultSlot</c>: a crafting output. Taking from it uses one of each ingredient; the client
/// predicts that with <c>CraftingRecipe.defaultCraftingReminder</c>, since it does not know the
/// recipe, and the server's own result arrives as a slot update.
/// </summary>
public sealed class CraftingResultSlot(Container grid, Container result, int x, int y)
    : Slot(result, 0, x, y) {
    public override bool MayPlace(Stack stack) => false;

    public override void OnTake(IMenuUser user, Stack carried) {
        for (int i = 0; i < grid.Size; i++) {
            Stack item = grid.Get(i);
            Stack replacement = ItemRules.CraftingRemainder(item);
            if (!item.IsEmpty) {
                grid.Remove(i, 1);
                item = grid.Get(i);
            }
            if (replacement.IsEmpty) {
                continue;
            }
            if (item.IsEmpty) {
                grid.Set(i, replacement);
            }
            else if (Stack.IsSameItemSameComponents(item, replacement)) {
                replacement.Grow(item.Count);
                grid.Set(i, replacement);
            }
            else if (!user.Inventory.Add(replacement)) {
                user.Drop(replacement);
            }
        }
    }
}

/// <summary>
/// <c>NonInteractiveResultSlot</c>: the crafter's preview, which nothing can take or fill by clicking.
/// It does not refuse placement, so a number key swap still writes into it, as it does in vanilla.
/// </summary>
public sealed class PreviewSlot(Container container, int containerSlot, int x, int y) : Slot(container, containerSlot, x, y) {
    public override bool MayPickup(IMenuUser user) => false;
    public override Stack? TryRemove(int amount, int maxAmount, IMenuUser user) => null;
    public override Stack SafeTake(int amount, int maxAmount, IMenuUser user) => Stack.Empty;
    public override Stack SafeInsert(Stack input, int amount) => input;
    public override bool AllowModification(IMenuUser user) => false;
    public override bool IsFake => true;
}
