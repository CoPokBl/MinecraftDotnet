using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Components;
using Minecraft.Data.Items;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Tags;

namespace ClientLib;

/// <summary>Container menus: what the server says is in them, and the clicks the player makes on them.</summary>
public sealed partial class MinecraftClient {
    private readonly Dictionary<Identifier, HashSet<Identifier>> _itemSets = new();
    private readonly HashSet<Identifier> _stonecutterInputs = [];
    private readonly List<(HashSet<Identifier> Inputs, Minecraft.Schemas.Recipes.SlotDisplay Result)> _stonecutterRecipes = [];
    private ClientMenuUser? _menuUser;

    /// <summary>
    /// <c>SelectableRecipe.SingleInputSet.selectByInput</c>: the stonecutter recipes the item can be cut
    /// with, in the server's order. A recipe button's id is its index in this list.
    /// </summary>
    public List<Minecraft.Schemas.Recipes.SlotDisplay> StonecutterResultsFor(Identifier input) {
        return _stonecutterRecipes.Where(r => r.Inputs.Contains(input)).Select(r => r.Result).ToList();
    }

    /// <summary>The server opened a menu; <see cref="OpenContainer"/> is it.</summary>
    public event Action<ContainerMenu>? ContainerOpened;

    /// <summary>The server closed the open menu.</summary>
    public event Action? ContainerClosed;

    /// <summary><c>handleOpenBook</c>: the server asked for the book held in this hand to be shown.</summary>
    public event Action<Hand>? BookOpened;

    /// <summary>Whichever menu clicks go to: the open container, or the player's own inventory.</summary>
    public ContainerMenu ActiveMenu => Inventory.ActiveMenu;

    public IMenuUser MenuUser => _menuUser ??= new ClientMenuUser(this);

    private void HandleContainerPacket(MinecraftPacket packet) {
        SyncMenuData();
        switch (packet) {
            case ClientBoundSetContainerContentPacket content:
                // ClientPacketListener.handleContainerContent: window 0 is always the inventory menu.
                if (content.WindowId == 0) {
                    Inventory.Menu.InitializeContents(content.StateId, content.SlotData, content.CursorItem);
                }
                else if (content.WindowId == ActiveMenu.WindowId) {
                    ActiveMenu.InitializeContents(content.StateId, content.SlotData, content.CursorItem);
                }
                break;

            case ClientBoundSetContainerSlotPacket slot:
                if (slot.WindowId == -1) {
                    ActiveMenu.Carried = Stack.Of(slot.Data);
                }
                else if (slot.WindowId == -2) {
                    Inventory.SetInventorySlot(slot.SlotId, slot.Data);
                }
                else if (slot.WindowId == 0) {
                    Inventory.Menu.SetItem(slot.SlotId, slot.StateId, slot.Data);
                }
                else if (slot.WindowId == ActiveMenu.WindowId) {
                    ActiveMenu.SetItem(slot.SlotId, slot.StateId, slot.Data);
                }
                break;

            case ClientBoundSetPlayerInventorySlotPacket inventorySlot:
                Inventory.SetInventorySlot(inventorySlot.Slot, inventorySlot.Contents);
                break;

            case ClientBoundSetCursorItemPacket cursor:
                if (!CreativeInventoryOpen) {
                    ActiveMenu.Carried = Stack.Of(cursor.Item);
                }
                break;

            case ClientBoundOpenScreenPacket open: {
                ContainerMenu? menu = MenuFactory.Create(open.WindowId, open.Type, open.Title, Inventory, Inventory.Data);
                if (menu == null) {
                    Info($"Server opened a {open.Type.Identifier} menu, which this client has no layout for");
                    break;
                }
                Inventory.ActiveMenu = menu;
                OpenContainer = menu;
                ContainerOpened?.Invoke(menu);
                break;
            }

            case ClientBoundCloseContainerPacket:
                // LocalPlayer.clientSideCloseContainer: back to the inventory menu, no packet.
                Inventory.ActiveMenu = Inventory.Menu;
                OpenContainer = null;
                ContainerClosed?.Invoke();
                break;

            case ClientBoundSetContainerPropertyPacket property:
                if (property.WindowId == ActiveMenu.WindowId) {
                    ActiveMenu.Properties[property.Property] = property.Value;
                }
                break;

            case ClientBoundUpdateRecipesPacket recipes:
                _itemSets.Clear();
                foreach ((Identifier name, IItem[] items) in recipes.ItemSets) {
                    _itemSets[name] = items.Select(i => i.Identifier).ToHashSet();
                }
                _stonecutterInputs.Clear();
                _stonecutterRecipes.Clear();
                foreach (ClientBoundUpdateRecipesPacket.StonecutterRecipe recipe in recipes.StonecutterRecipes) {
                    HashSet<Identifier> inputs = ResolveItems(recipe.Input).ToHashSet();
                    _stonecutterInputs.UnionWith(inputs);
                    _stonecutterRecipes.Add((inputs, recipe.Result));
                }
                SyncMenuData();
                break;

            case ClientBoundOpenBookPacket book:
                BookOpened?.Invoke(book.Hand);
                break;

            case ClientBoundMerchantOffersPacket offers:
                if (ActiveMenu is MerchantMenu merchant && merchant.WindowId == offers.WindowId) {
                    merchant.Offers = offers;
                }
                break;
        }
    }

    private IEnumerable<Identifier> ResolveItems(IdSet set) {
        int[] ids = set switch {
            IdSet.Ids list => list.Values,
            IdSet.Tag tag => TagMembers("minecraft:item", tag.TagName) ?? [],
            _ => []
        };
        return ids.Select(id => Registry.Items[id].Identifier);
    }

    /// <summary>The menus read tags and item sets the server can change, so they are refreshed before each use.</summary>
    private void SyncMenuData() {
        MenuData data = Inventory.Data;
        data.Registry = Registry;
        data.Tags = Tags;
        data.ItemSets.Clear();
        foreach ((Identifier key, HashSet<Identifier> value) in _itemSets) {
            data.ItemSets[key] = value;
        }
        data.StonecutterInputs.Clear();
        data.StonecutterInputs.UnionWith(_stonecutterInputs);
    }

    /// <summary>
    /// Set by a creative inventory screen while it is open: vanilla's creative screen keeps its own
    /// cursor, so the server's cursor updates are ignored.
    /// </summary>
    public bool CreativeInventoryOpen { get; set; }

    /// <summary>
    /// <c>MultiPlayerGameMode.handleContainerInput</c>: runs the click on the open menu, then tells the
    /// server which slots it changed and what is on the cursor, so the server can tell whether it agrees.
    /// </summary>
    public void ClickContainer(int slotIndex, int button, ContainerInput input) {
        ContainerMenu menu = ActiveMenu;
        SyncMenuData();
        IReadOnlyList<Inventory.Slot> slots = menu.Slots;
        Stack[] before = new Stack[slots.Count];
        for (int i = 0; i < slots.Count; i++) {
            before[i] = slots[i].Item.Copy();
        }

        menu.Clicked(slotIndex, button, input, MenuUser);

        Dictionary<short, HashedSlot?> changed = new();
        for (int i = 0; i < slots.Count; i++) {
            Stack after = slots[i].Item;
            if (!Stack.Matches(before[i], after)) {
                changed[(short)i] = Hash(after);
            }
        }

        Send(new ServerBoundClickContainerPacket {
            WindowId = menu.WindowId,
            StateId = menu.StateId,
            Slot = (short)slotIndex,
            Button = (sbyte)button,
            Mode = (int)input,
            ChangedSlots = changed,
            CursorItem = Hash(menu.Carried)
        });
    }

    /// <summary><c>HashedStack.create</c>: null for an empty stack.</summary>
    private HashedSlot? Hash(Stack stack) {
        if (stack.IsEmpty) {
            return null;
        }
        ItemStack item = stack.Template;
        List<(IDataComponent, int)> components = [];
        foreach ((IDataComponent component, object value) in item.Components) {
            components.Add((component, ComponentHasher.Hash(component, value, Registry) ?? 0));
        }
        return new HashedSlot(stack.Count, stack.Item, components.ToArray(), item.RemoveComponents.ToArray());
    }

    /// <summary><c>LocalPlayer.closeContainer</c>: tells the server, then drops back to the inventory menu.</summary>
    public void CloseContainer() {
        Send(new ServerBoundCloseContainerPacket { WindowId = ActiveMenu.WindowId });
        Inventory.ActiveMenu = Inventory.Menu;
        OpenContainer = null;
    }

    /// <summary>A menu button: an enchantment option, a stonecutter recipe, a loom pattern, a lectern page.</summary>
    public void ClickContainerButton(int buttonId) {
        Send(new ServerBoundClickContainerButtonPacket { WindowId = ActiveMenu.WindowId, ButtonId = buttonId });
    }

    /// <summary><c>handleCreativeModeItemAdd</c>: sets an inventory menu slot outright, -1 throws the stack.</summary>
    public void SetCreativeSlot(int menuSlot, ItemStack item) {
        if (Player is not { InstaBuild: true }) {
            return;
        }
        Send(new ServerBoundSetCreativeModeSlotPacket { Slot = (short)menuSlot, Item = item });
    }

    /// <summary>
    /// <c>ServerboundEditBookPacket</c>: the pages of the book in a hotbar slot or the off hand, slot 40,
    /// and signed into a written book when there is a title.
    /// </summary>
    public void EditBook(int slot, IEnumerable<string> pages, string? title) {
        Send(new ServerBoundEditBookPacket { Slot = slot, Entries = pages.ToArray(), Title = title });
    }

    public void RenameItem(string name) {
        Send(new ServerBoundRenameItemPacket { Name = name });
    }

    public void SelectTrade(int index) {
        if (ActiveMenu is MerchantMenu merchant) {
            merchant.SelectedOffer = index;
        }
        Send(new ServerBoundSelectTradePacket { SelectedSlot = index });
    }

    public void SetBeaconEffects(IPotionEffectType? primary, IPotionEffectType? secondary) {
        Send(new ServerBoundSetBeaconEffectPacket { PrimaryEffect = primary, SecondaryEffect = secondary });
    }

    /// <summary>The crafter's slot toggle, sent when an empty slot is clicked with nothing held.</summary>
    public void SetCrafterSlotEnabled(int slot, bool enabled) {
        Send(new ServerBoundChangeContainerSlotStatePacket { WindowId = ActiveMenu.WindowId, SlotId = slot, NewState = enabled });
    }

    private sealed class ClientMenuUser(MinecraftClient client) : IMenuUser {
        public bool InfiniteMaterials => client.Player?.InstaBuild ?? false;
        public bool IsCreative => client.Player?.GameMode == GameMode.Creative;
        public int ExperienceLevel => client.Player?.ExperienceLevel ?? 0;
        public PlayerInventory Inventory => client.Inventory;

        public void Drop(Stack stack) {
        }
    }
}
