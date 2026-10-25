using ClientLib.Player;
using Minecraft.Schemas;

namespace ClientLib.Inventory;

/// <summary><c>ScrollWheelHandler</c>: whole notches out of a wheel's fractional deltas, dropping what was left when the direction turns.</summary>
public sealed class ScrollWheelHandler {
    private double _accumulatedScrollX;
    private double _accumulatedScrollY;

    public (int X, int Y) OnMouseScroll(double scaledXScrollOffset, double scaledYScrollOffset) {
        if (_accumulatedScrollX != 0.0 && Math.Sign(scaledXScrollOffset) != Math.Sign(_accumulatedScrollX)) {
            _accumulatedScrollX = 0.0;
        }
        if (_accumulatedScrollY != 0.0 && Math.Sign(scaledYScrollOffset) != Math.Sign(_accumulatedScrollY)) {
            _accumulatedScrollY = 0.0;
        }
        _accumulatedScrollX += scaledXScrollOffset;
        _accumulatedScrollY += scaledYScrollOffset;
        int wheelX = (int)_accumulatedScrollX;
        int wheelY = (int)_accumulatedScrollY;
        if (wheelX == 0 && wheelY == 0) {
            return (0, 0);
        }
        _accumulatedScrollX -= wheelX;
        _accumulatedScrollY -= wheelY;
        return (wheelX, wheelY);
    }

    /// <summary><c>getNextScrollWheelSelection</c>: scrolling up steps back, wrapping within <paramref name="limit"/>.</summary>
    public static int GetNextScrollWheelSelection(double wheel, int currentSelected, int limit) {
        int step = Math.Sign(wheel);
        currentSelected -= step;
        currentSelected = Math.Max(-1, currentSelected);
        while (currentSelected < 0) {
            currentSelected += limit;
        }
        while (currentSelected >= limit) {
            currentSelected -= limit;
        }
        return currentSelected;
    }
}

/// <summary>
/// <c>BundleMouseActions</c>: scrolling over a bundle in a menu slot selects one of its items, and the
/// server is told of every change, a hover leaving the slot included, as vanilla tells it.
/// </summary>
/// <param name="isBundle"><c>ItemTags.BUNDLES</c> as the server sent it.</param>
/// <param name="selectBundleItem">Sends <c>ServerboundSelectBundleItemPacket</c>: the slot, then the item, -1 for none.</param>
public sealed class BundleMouseActions(Func<Stack, bool> isBundle, Action<int, int> selectBundleItem) {
    private static readonly Identifier BundlesTag = "minecraft:bundles";

    private readonly ScrollWheelHandler _scrollWheelHandler = new();

    public BundleMouseActions(MinecraftClient client)
        : this(stack => client.Inventory.Data.InTag(stack, BundlesTag), client.SelectBundleItem) {
    }

    public bool Matches(Slot slot) => isBundle(slot.Item);

    public bool OnMouseScrolled(double scrollX, double scrollY, int slotIndex, Stack itemStack) {
        int amountOfShownItems = BundleItem.GetNumberOfItemsToShow(itemStack.ToItemStack());
        if (amountOfShownItems == 0) {
            return false;
        }
        (int wheelX, int wheelY) = _scrollWheelHandler.OnMouseScroll(scrollX, scrollY);
        int wheel = wheelY == 0 ? -wheelX : wheelY;
        if (wheel != 0) {
            int selectedItem = BundleItem.GetSelectedItemIndex(itemStack.ToItemStack());
            int updatedSelectedItem = ScrollWheelHandler.GetNextScrollWheelSelection(wheel, selectedItem, amountOfShownItems);
            if (selectedItem != updatedSelectedItem) {
                ToggleSelectedBundleItem(itemStack, slotIndex, updatedSelectedItem);
            }
        }
        return true;
    }

    public void OnStopHovering(Slot hoveredSlot) => UnselectedBundleItem(hoveredSlot.Item, hoveredSlot.Index);

    public void OnSlotClicked(Slot slot, ContainerInput containerInput) {
        if (containerInput is ContainerInput.QuickMove or ContainerInput.Swap) {
            UnselectedBundleItem(slot.Item, slot.Index);
        }
    }

    /// <summary>A selection of -1 always passes the check, so leaving a bundle sends a packet even with nothing selected.</summary>
    private void ToggleSelectedBundleItem(Stack bundleItem, int slotIndex, int selectedItem) {
        if (selectedItem < BundleItem.GetNumberOfItemsToShow(bundleItem.ToItemStack())) {
            BundleItem.ToggleSelectedItem(bundleItem, selectedItem);
            selectBundleItem(slotIndex, selectedItem);
        }
    }

    public void UnselectedBundleItem(Stack bundleItem, int slotIndex) => ToggleSelectedBundleItem(bundleItem, slotIndex, BundleContents.NoSelectedItemIndex);
}
