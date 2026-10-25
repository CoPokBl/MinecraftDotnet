using System.Numerics;
using ClientLib;
using ClientLib.Entities;
using ClientLib.Inventory;
using ClientLib.Player;
using Minecraft.Data.Generated;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;
using Minecraft.Schemas.Tags;
using Minecraft.Text;
using GraphicalClient.Rendering.Entities;
using Silk.NET.Input;
using Slot = ClientLib.Inventory.Slot;

namespace GraphicalClient.Gui.Inventory;

/// <summary>Which screen shows which menu.</summary>
public static class ContainerScreens {
    /// <summary>The screen for the menu the server has just opened, <see cref="MinecraftClient.OpenContainer"/>.</summary>
    public static Screen? ForOpenMenu(MinecraftClient client) => client.OpenContainer switch {
        ChestMenu menu => new ChestScreen(client, menu),
        DispenserMenu menu => new BasicScreen(client, menu, new("gui/container/dispenser")),
        ShulkerBoxMenu menu => new BasicScreen(client, menu, new("gui/container/shulker_box")),
        HopperMenu menu => new BasicScreen(client, menu, new("gui/container/hopper", Height: 133)),
        CraftingMenu menu => new CraftingScreen(client, menu),
        SmithingMenu menu => new BasicScreen(client, menu, new(Arrow: (68, 49))),
        GrindstoneMenu menu => new BasicScreen(client, menu, new(Arrow: (98, 34))),
        CartographyTableMenu menu => new BasicScreen(client, menu, new(Arrow: (113, 39))),
        CrafterMenu menu => new CrafterScreen(client, menu),
        FurnaceMenu menu => new FurnaceScreen(client, menu),
        BrewingStandMenu menu => new BrewingStandScreen(client, menu),
        AnvilMenu menu => new AnvilScreen(client, menu),
        EnchantmentMenu menu => new EnchantmentScreen(client, menu),
        StonecutterMenu menu => new StonecutterScreen(client, menu),
        LoomMenu menu => new LoomScreen(client, menu),
        BeaconMenu menu => new BeaconScreen(client, menu),
        MerchantMenu menu => new MerchantScreen(client, menu),
        LecternMenu menu => new LecternScreen(client, menu),
        MountInventoryMenu menu => new MountInventoryScreen(client, menu),
        _ => null
    };

    /// <summary>The E key: the creative inventory in creative mode, the player's inventory otherwise.</summary>
    public static Screen PlayerInventory(MinecraftClient client) =>
        client.Player is { InstaBuild: true } ? new CreativeInventoryScreen(client) : new InventoryScreen(client);
}

/// <summary>
/// The layout of a menu that needs nothing beyond its slots: the pack texture it matches, its height, an
/// arrow lit while there is a result, and where its title goes.
/// </summary>
public sealed record ContainerLayout(string? Background = null, int Height = 166, (int X, int Y)? Arrow = null, (int X, int Y)? Title = null);

public sealed class BasicScreen(MinecraftClient client, ContainerMenu menu, ContainerLayout layout) : ContainerScreen(client, menu) {
    public override int ImageHeight => layout.Height;
    protected override string? PackBackground => layout.Background;
    protected override (int X, int Y) TitleLabel => layout.Title ?? base.TitleLabel;

    protected override void DrawBackground(GuiContext context) {
        if (layout.Arrow is { } arrow) {
            Panel.Arrow(context, Left + arrow.X, Top + arrow.Y, ResultShown ? 1 : 0);
        }
    }
}

/// <summary><c>InventoryScreen</c>: the player's own menu.</summary>
public sealed class InventoryScreen(MinecraftClient client) : RecipeBookScreen(client, client.Inventory.Menu) {
    protected override (int X, int Y)? InventoryLabel => null;
    protected override (int X, int Y) TitleLabel => (97, 8);
    protected override string PackBackground => "gui/container/inventory";

    private float _xMouse, _yMouse;
    private readonly EffectsInInventory _effects = new();
    private bool _buttonClicked;

    protected override (float X, float Y) RecipeBookButtonPosition(int height) => (Left + 104, height / 2 - 22);

    protected override bool IsBiggerResultSlot => false;

    protected override void OnRecipeBookButtonClick() => _buttonClicked = true;

    /// <summary>The release of the press that toggled the book is swallowed, so it cannot drop a carried stack.</summary>
    public override void MouseUp(GuiContext context, float x, float y, MouseButton button) {
        if (_buttonClicked) {
            _buttonClicked = false;
            return;
        }
        base.MouseUp(context, x, y, button);
    }

    /// <summary>
    /// Vanilla records the cursor after drawing, so the player turns to where it was a frame ago,
    /// and to the top left corner on the first frame.
    /// </summary>
    public override void Render(GuiContext context, float partialTick) {
        base.Render(context, partialTick);
        _effects.DrawTooltip(context, context.MouseX, context.MouseY);
        _xMouse = context.MouseX;
        _yMouse = context.MouseY;
    }

    public override bool ShowsActiveEffects(GuiContext context) => EffectsInInventory.CanSeeEffects(context.Width, Left, ImageWidth);

    protected override void DrawBesidePanel(GuiContext context) => _effects.Render(context, Left, Top, ImageWidth, context.MouseX, context.MouseY);

    protected override void DrawBackground(GuiContext context) {
        // The black frame the vanilla texture has round the player.
        context.Gui.Rect(Left + 26, Top + 8, 49, 70, 0xFF000000);
        context.Gui.Rect(Left + 27, Top + 9, 47, 68, 0xFF3A3A3A);
        DrawPackOverlay(context);
        Panel.Arrow(context, Left + 135, Top + 28, ResultShown ? 1 : 0);
    }

    protected override void DrawPackOverlay(GuiContext context) {
        if (Client.Player is { } player) {
            ExtractEntityInInventoryFollowsMouse(context, Left + 26, Top + 8, Left + 75, Top + 78, 30, 0.0625F, _xMouse, _yMouse, player);
        }
    }

    protected override void DrawForeground(GuiContext context) => context.Text.Draw("Crafting", Left + 97, Top + 8, Panel.Label, false);

    /// <summary><c>InventoryScreen.extractEntityInInventoryFollowsMouse</c>.</summary>
    public static void ExtractEntityInInventoryFollowsMouse(GuiContext context, float x0, float y0, float x1, float y1, int size, float offsetY,
        float mouseX, float mouseY, ClientEntity entity) {
        if (context.EntityRenderer is not { } renderer) {
            return;
        }
        float centerX = (x0 + x1) / 2.0F;
        float centerY = (y0 + y1) / 2.0F;
        float xAngle = (float)Math.Atan((centerX - mouseX) / 40.0F);
        float yAngle = (float)Math.Atan((centerY - mouseY) / 40.0F);
        // new Quaternionf().rotateZ(PI).mul(xRotation): the X turn applies first.
        Matrix4x4 xRotation = Matrix4x4.CreateRotationX(yAngle * 20.0F * (float)(Math.PI / 180.0));
        Matrix4x4 rotation = xRotation * Matrix4x4.CreateRotationZ((float)Math.PI);
        if (renderer.ExtractRenderState(entity) is not { } renderState) {
            return;
        }
        if (renderState is LivingEntityRenderState livingRenderState) {
            livingRenderState.BodyRot = 180.0F + xAngle * 20.0F;
            livingRenderState.YRot = xAngle * 20.0F;
            if (livingRenderState.Pose != Minecraft.Schemas.Entities.EntityPose.FallFlying) {
                livingRenderState.XRot = -yAngle * 20.0F;
            }
            else {
                livingRenderState.XRot = 0.0F;
            }
            // Vanilla divides the box by the scale here; the box in the state is never scaled, so only the scale is reset.
            livingRenderState.Scale = 1.0F;
        }
        Vector3 translation = new(0.0F, renderState.BoundingBoxHeight / 2.0F + offsetY, 0.0F);
        renderer.Entity(context.Gui, renderState, size, translation, rotation, yAngle * 20.0F, x0, y0, x1, y1);
    }
}

/// <summary><c>ContainerScreen</c>, vanilla's name for the chest's: one to six rows.</summary>
public sealed class ChestScreen(MinecraftClient client, ChestMenu menu) : ContainerScreen(client, menu) {
    public override int ImageHeight => 114 + menu.Rows * 18;

    /// <summary>
    /// <c>ContainerScreen.renderBg</c>: <c>generic_54</c> holds six rows; fewer are drawn as the top
    /// of it down to the last row, then the inventory part from where it starts in the texture.
    /// </summary>
    protected override bool DrawPackBackground(GuiContext context) {
        int top = menu.Rows * 18 + 17;
        return context.Sprites.Region(context.Gui, "gui/container/generic_54", Left, Top, 0, 0, ImageWidth, top)
               && context.Sprites.Region(context.Gui, "gui/container/generic_54", Left, Top + top, 0, 126, ImageWidth, 96);
    }
}

/// <summary>
/// <c>CrafterScreen</c>: clicking an empty input slot with nothing held switches it on or off, which is
/// its own packet rather than a container click.
/// </summary>
public sealed class CrafterScreen(MinecraftClient client, CrafterMenu menu) : ContainerScreen(client, menu) {
    protected override void DrawBackground(GuiContext context) => Panel.Arrow(context, Left + 97, Top + 35, menu.IsPowered ? 1 : 0);

    protected override void DrawSlotOverlay(GuiContext context, Slot slot) {
        if (slot.Index < 9 && menu.IsSlotDisabled(slot.Index)) {
            context.Gui.Rect(Left + slot.X, Top + slot.Y, 16, 16, 0xC0602020);
        }
    }

    protected override bool OverridesClick(GuiContext context, Slot? slot, int button, ContainerInput input) {
        if (slot == null || slot.Index >= 9 || slot.HasItem || Client.Player?.GameMode == GameMode.Spectator
            || input is not (ContainerInput.Pickup or ContainerInput.QuickMove)) {
            return false;
        }
        bool disabled = menu.IsSlotDisabled(slot.Index);
        Client.SetCrafterSlotEnabled(slot.Index, disabled);
        menu.Properties[slot.Index] = disabled ? 0 : 1;
        // CrafterScreen.updateSlotState: LocalPlayer.playSound, where the player stands.
        if (Client.Player is { } player) {
            context.Sounds?.Play(SoundType.ButtonClick, Minecraft.Schemas.Sound.SoundCategory.Players, 0.4F, disabled ? 1.0F : 0.75F,
                player.Position.X, player.Position.Y, player.Position.Z);
        }
        return true;
    }
}

/// <summary><c>CraftingScreen</c>: the crafting table's 3x3, with the recipe book.</summary>
public sealed class CraftingScreen(MinecraftClient client, CraftingMenu menu) : RecipeBookScreen(client, menu) {
    protected override string PackBackground => "gui/container/crafting_table";
    protected override (int X, int Y) TitleLabel => (29, 6);

    protected override (float X, float Y) RecipeBookButtonPosition(int height) => (Left + 5, height / 2 - 49);

    protected override void DrawBackground(GuiContext context) => Panel.Arrow(context, Left + 90, Top + 35, ResultShown ? 1 : 0);
}

/// <summary><c>AbstractFurnaceScreen</c> for the furnace, the smoker and the blast furnace, which differ in their art.</summary>
public sealed class FurnaceScreen(MinecraftClient client, FurnaceMenu menu) : RecipeBookScreen(client, menu) {
    private readonly string _kind = menu.Type?.Identifier == InventoryType.Smoker.Identifier ? "smoker"
        : menu.Type?.Identifier == InventoryType.BlastFurnace.Identifier ? "blast_furnace"
        : "furnace";

    protected override string PackBackground => "gui/container/" + _kind;

    protected override (float X, float Y) RecipeBookButtonPosition(int height) => (Left + 20, height / 2 - 49);

    protected override void DrawBackground(GuiContext context) {
        Panel.Flame(context, Left + 56, Top + 36, menu.IsLit ? menu.LitProgress : 0);
        Panel.Arrow(context, Left + 79, Top + 34, menu.BurnProgress);
    }

    /// <summary>
    /// <c>AbstractFurnaceScreen.renderBg</c>: the flame shows <c>ceil(lit * 13) + 1</c> rows from its
    /// bottom, and the arrow <c>ceil(progress * 24)</c> columns from its left.
    /// </summary>
    protected override void DrawPackOverlay(GuiContext context) {
        if (menu.IsLit) {
            int rows = (int)MathF.Ceiling(menu.LitProgress * 13.0F) + 1;
            context.Sprites.SpriteFromBottom(context.Gui, $"container/{_kind}/lit_progress", Left + 56, Top + 36, 14, 14, rows / 14.0F);
        }
        int columns = (int)MathF.Ceiling(menu.BurnProgress * 24.0F);
        context.Sprites.Sprite(context.Gui, $"container/{_kind}/burn_progress", Left + 79, Top + 34, 24, 16, fraction: columns / 24.0F);
    }
}

public sealed class BrewingStandScreen(MinecraftClient client, BrewingStandMenu menu) : ContainerScreen(client, menu) {
    protected override void DrawBackground(GuiContext context) {
        float brew = menu.BrewTime > 0 ? 1.0F - menu.BrewTime / 400.0F : 0;
        context.Gui.Rect(Left + 97, Top + 16, 9, 28, 0xFF8B8B8B);
        context.Gui.Rect(Left + 97, Top + 16, 9, 28 * brew, 0xFFFFFFFF);
        context.Gui.Rect(Left + 60, Top + 44, 18, 4, 0xFF8B8B8B);
        context.Gui.Rect(Left + 60, Top + 44, 18 * Math.Clamp(menu.Fuel / 20.0F, 0, 1), 4, 0xFFFF8020);
    }
}

/// <summary><c>AnvilScreen</c>: the name field sends a rename on every change, as vanilla's does.</summary>
public sealed class AnvilScreen(MinecraftClient client, AnvilMenu menu) : ContainerScreen(client, menu) {
    private string _name = "";
    private Stack _lastInput = Stack.Empty;

    protected override (int X, int Y) TitleLabel => (60, 6);

    protected override void DrawBackground(GuiContext context) {
        Stack input = menu.Slots[0].Item;
        if (!Stack.IsSameItem(input, _lastInput)) {
            _lastInput = input.Copy();
            _name = input.IsEmpty ? "" : TextFlattener.Plain(ItemNames.HoverName(input.ToItemStack()));
        }
        context.Gui.Rect(Left + 59, Top + 20, 110, 16, input.IsEmpty ? 0xFF6F6F6F : 0xFF000000);
        context.Gui.Rect(Left + 60, Top + 21, 108, 14, input.IsEmpty ? 0xFF8B8B8B : 0xFF1A1A1A);
        if (!input.IsEmpty) {
            context.Text.Draw(_name + (Environment.TickCount64 / 300 % 2 == 0 ? "_" : ""), Left + 62, Top + 24, 0xFFE0E0E0);
        }
        Panel.Arrow(context, Left + 102, Top + 48, ResultShown ? 1 : 0);
    }

    protected override void DrawForeground(GuiContext context) {
        if (menu.Cost <= 0) {
            return;
        }
        bool affordable = Client.MenuUser.InfiniteMaterials || Client.MenuUser.ExperienceLevel >= menu.Cost;
        string text = menu.Cost >= 40 && !Client.MenuUser.InfiniteMaterials ? "Too expensive!" : $"Enchantment cost: {menu.Cost}";
        float width = context.Text.Width(text);
        context.Gui.Rect(Left + ImageWidth - 8 - width - 2, Top + 67, width + 4, 12, 0x4F000000);
        context.Text.Draw(text, Left + ImageWidth - 8 - width, Top + 69, affordable && menu.Cost < 40 ? 0xFF80FF20 : 0xFFFF6060);
    }

    /// <summary>The name field is editable, and so has the keyboard, while there is an item to rename.</summary>
    public override bool HasFocusedEditBox => !menu.Slots[0].Item.IsEmpty;

    public override void Char(GuiContext context, char c) {
        if (!HasFocusedEditBox || !EditBox.IsAllowedChatCharacter(c) || _name.Length >= 50) {
            return;
        }
        _name += c;
        Client.RenameItem(_name);
    }

    /// <summary><c>keyPressed</c>: an editable name field takes every key but Escape, so typing never reaches the key mappings.</summary>
    public override void KeyDown(GuiContext context, Key key, bool control) {
        if (key == Key.Escape || !HasFocusedEditBox) {
            base.KeyDown(context, key, control);
            return;
        }
        if (key == Key.Backspace && _name.Length > 0) {
            _name = _name[..^1];
            Client.RenameItem(_name);
        }
    }
}

/// <summary><c>EnchantmentScreen</c>: three options, each a button whose cost the server sends as data.</summary>
public sealed class EnchantmentScreen(MinecraftClient client, EnchantmentMenu menu) : ContainerScreen(client, menu) {
    private const float OptionsX = 60, OptionsY = 14, OptionWidth = 108, OptionHeight = 19;

    protected override void DrawForeground(GuiContext context) {
        for (int i = 0; i < 3; i++) {
            float y = Top + OptionsY + i * OptionHeight;
            int cost = menu.Cost(i);
            bool usable = cost > 0 && (Client.MenuUser.InfiniteMaterials || (Client.MenuUser.ExperienceLevel >= cost && menu.Slots[1].Item.Count > i));
            bool hovered = usable && Inside(MouseX, MouseY, Left + OptionsX, y, OptionWidth, OptionHeight);
            context.Gui.Rect(Left + OptionsX, y, OptionWidth, OptionHeight, 0xFF000000);
            context.Gui.Rect(Left + OptionsX + 1, y + 1, OptionWidth - 2, OptionHeight - 2, !usable ? 0xFF5A4A5A : hovered ? 0xFF9A7AB0 : 0xFF7A5A90);
            if (cost > 0) {
                context.Text.Draw($"{i + 1}", Left + OptionsX + 4, y + 6, 0xFF80FF20);
                string label = $"{cost} levels";
                context.Text.Draw(label, Left + OptionsX + OptionWidth - context.Text.Width(label) - 4, y + 6, usable ? 0xFF80FF20 : 0xFF407020);
            }
        }
    }

    protected override bool WidgetClicked(GuiContext context, float x, float y, MouseButton button) {
        for (int i = 0; i < 3; i++) {
            if (menu.Cost(i) > 0 && Inside(x, y, Left + OptionsX, Top + OptionsY + i * OptionHeight, OptionWidth, OptionHeight)) {
                Client.ClickContainerButton(i);
                return true;
            }
        }
        return false;
    }
}

/// <summary>
/// A screen whose buttons are a scrolling grid over a list, picked with a container button: the
/// stonecutter's recipes, the loom's patterns and the merchant's trades.
/// </summary>
public abstract class ListScreen(MinecraftClient client, ContainerMenu menu, ScrollGrid grid) : ContainerScreen(client, menu) {
    protected ScrollGrid Grid { get; } = grid;

    protected abstract int Count { get; }

    /// <summary>The index into the list of the visible cell under a point, or -1.</summary>
    protected int IndexAt(float x, float y) {
        int cell = Grid.CellAt(x - Left, y - Top);
        return cell < 0 || Grid.IndexOf(cell) >= Count ? -1 : Grid.IndexOf(cell);
    }

    /// <summary>A click on an entry: its sound, then the button it presses.</summary>
    protected abstract void Pick(GuiContext context, int index);

    protected override bool WidgetClicked(GuiContext context, float x, float y, MouseButton button) {
        int index = IndexAt(x, y);
        if (index < 0) {
            return false;
        }
        Pick(context, index);
        return true;
    }

    public override void Scroll(GuiContext context, float delta) {
        if (!ScrollSlot(delta)) {
            Grid.ScrollBy(delta, Count);
        }
    }
}

/// <summary><c>StonecutterScreen</c>: the recipes the input can be cut into, four to a row; picking one is a button.</summary>
public sealed class StonecutterScreen(MinecraftClient client, StonecutterMenu menu) : ListScreen(client, menu, new ScrollGrid(52, 15, 4, 3, 16, 18)) {
    private List<SlotDisplay> Recipes() {
        Stack input = menu.Slots[0].Item;
        return input.IsEmpty ? [] : Client.StonecutterResultsFor(input.Item.Identifier);
    }

    protected override int Count => Recipes().Count;

    protected override void DrawForeground(GuiContext context) {
        List<SlotDisplay> recipes = Recipes();
        context.Gui.Rect(Left + 51, Top + 14, 66, 56, 0xFF8B8B8B);
        int hovered = IndexAt(MouseX, MouseY);
        for (int cell = 0; cell < Grid.Cells && Grid.IndexOf(cell) < recipes.Count; cell++) {
            int index = Grid.IndexOf(cell);
            (float x, float y) = Grid.Cell(cell);
            context.Gui.Rect(Left + x, Top + y, 16, 18, index == menu.SelectedRecipe ? 0xFF6080C0 : index == hovered ? 0xFFD0D0D0 : 0xFFA8A8A8);
            if (ResultOf(recipes[index]) is { } result) {
                GuiItems.Draw(context, result, Left + x, Top + y + 1);
            }
        }
    }

    private static ItemStack? ResultOf(SlotDisplay display) => display switch {
        SlotDisplay.Item item => new ItemStack(item.Value),
        SlotDisplay.Stack stack => stack.Value,
        _ => null
    };

    protected override void Pick(GuiContext context, int index) {
        // StonecutterMenu.clickMenuButton refuses the recipe already chosen, and only an accepted click sounds.
        if (index != menu.SelectedRecipe) {
            PlayUi(context, SoundType.StonecutterSelectRecipe);
        }
        Client.ClickContainerButton(index);
    }
}

/// <summary>
/// <c>LoomScreen</c>: the patterns the loom offers for what is in the pattern slot, as numbered
/// buttons. The pattern list is <c>LoomMenu.getSelectablePatterns</c> over the synchronised tags.
/// </summary>
public sealed class LoomScreen(MinecraftClient client, LoomMenu menu) : ListScreen(client, menu, new ScrollGrid(60, 13, 4, 4, 14, 14)) {
    private List<Identifier> Patterns() {
        Stack banner = menu.Slots[0].Item, dye = menu.Slots[1].Item;
        if (banner.IsEmpty || dye.IsEmpty) {
            return [];
        }
        Stack pattern = menu.Slots[2].Item;
        Identifier tag = "minecraft:no_item_required";
        if (!pattern.IsEmpty) {
            if (!pattern.Has(DataComponent.ProvidesBannerPatterns) || pattern.Template.Get(DataComponent.ProvidesBannerPatterns) is not IdSet.Tag provided) {
                return [];
            }
            tag = provided.TagName;
        }
        if (!Client.Tags.TryGetValue("minecraft:banner_pattern", out Dictionary<Identifier, int[]>? tags) || !tags.TryGetValue(tag, out int[]? ids)) {
            return [];
        }
        return ids.Select(id => Client.Registry.BannerPatterns[id].Identifier).ToList();
    }

    protected override int Count => Patterns().Count;

    protected override void DrawForeground(GuiContext context) {
        List<Identifier> patterns = Patterns();
        int hovered = IndexAt(MouseX, MouseY);
        for (int cell = 0; cell < Grid.Cells && Grid.IndexOf(cell) < patterns.Count; cell++) {
            int index = Grid.IndexOf(cell);
            (float x, float y) = Grid.Cell(cell);
            context.Gui.Rect(Left + x, Top + y, 14, 14, index == menu.SelectedPattern ? 0xFF6080C0 : index == hovered ? 0xFFD0D0D0 : 0xFFA8A8A8);
            context.Gui.Rect(Left + x + 3, Top + y + 2, 8, 10, 0xFF404040 | (uint)Assets.DevArt.Hash(patterns[index].Key) & 0x7F7F7F);
        }
    }

    protected override void DrawHoverTooltip(GuiContext context) {
        if (IndexAt(MouseX, MouseY) is var index and >= 0) {
            string name = string.Join(' ', Patterns()[index].Key.Split('_').Select(w => char.ToUpperInvariant(w[0]) + w[1..]));
            Tooltips.Draw(context, [[new TextRun(name, 0xFFFFFF)]], MouseX, MouseY);
        }
    }

    protected override void Pick(GuiContext context, int index) {
        PlayUi(context, SoundType.LoomSelectPattern);
        Client.ClickContainerButton(index);
    }
}

/// <summary><c>MerchantScreen</c>: the trades down the left; picking one asks the server to fill the payment.</summary>
public sealed class MerchantScreen(MinecraftClient client, MerchantMenu menu) : ListScreen(client, menu, new ScrollGrid(5, 18, 1, 7, 88, 20)) {
    public override int ImageWidth => 276;
    protected override (int X, int Y)? InventoryLabel => (107, ImageHeight - 94);
    protected override (int X, int Y) TitleLabel => (107, 6);

    private Trade[] Trades => menu.Offers?.Trades ?? [];

    protected override int Count => Trades.Length;

    protected override void DrawForeground(GuiContext context) {
        Trade[] trades = Trades;
        context.Text.Draw("Trades", Left + 5, Top + 6, Panel.Label, false);
        int hovered = IndexAt(MouseX, MouseY);
        for (int cell = 0; cell < Grid.Cells && Grid.IndexOf(cell) < trades.Length; cell++) {
            int index = Grid.IndexOf(cell);
            Trade trade = trades[index];
            (float x, float y) = Grid.Cell(cell);
            x += Left;
            y += Top;
            uint fill = index == menu.SelectedOffer ? 0xFF6080C0 : trade.TradeDisabled ? 0xFF806060 : index == hovered ? 0xFFD0D0D0 : 0xFFA8A8A8;
            context.Gui.Rect(x, y, 88, 20, 0xFF000000);
            context.Gui.Rect(x + 1, y + 1, 86, 18, fill);
            GuiItems.Draw(context, trade.InputItem1.Item.WithCount(MerchantMenu.ModifiedCostCount(trade)), x + 3, y + 2);
            if (trade.InputItem2 != null) {
                GuiItems.Draw(context, trade.InputItem2.Item, x + 25, y + 2);
            }
            context.Text.Draw(">", x + 47, y + 6, 0xFF404040, false);
            GuiItems.Draw(context, trade.OutputItem, x + 63, y + 2);
        }
        Panel.Arrow(context, Left + 186, Top + 35, ResultShown ? 1 : 0);
    }

    protected override void Pick(GuiContext context, int index) {
        PlayDownSound(context);
        Client.SelectTrade(index);
    }
}

/// <summary><c>BeaconScreen</c>: a primary power from the levels reached, a secondary at four, then confirm.</summary>
public sealed class BeaconScreen(MinecraftClient client, BeaconMenu menu) : ContainerScreen(client, menu) {
    private static readonly IPotionEffectType[][] Primary = [
        [PotionEffectType.Speed, PotionEffectType.Haste],
        [PotionEffectType.Resistance, PotionEffectType.JumpBoost],
        [PotionEffectType.Strength]
    ];

    private IPotionEffectType? _primary;
    private IPotionEffectType? _secondary;

    public override int ImageWidth => 230;
    public override int ImageHeight => 219;
    protected override (int X, int Y)? InventoryLabel => null;
    protected override bool ShowsTitle => false;

    private IEnumerable<(IPotionEffectType Effect, float X, float Y, int Tier)> Buttons() {
        for (int tier = 0; tier < 3; tier++) {
            for (int i = 0; i < Primary[tier].Length; i++) {
                yield return (Primary[tier][i], 53 + i * 24 - Primary[tier].Length * 12 + 24, 22 + tier * 25, tier);
            }
        }
        if (_primary != null) {
            yield return (PotionEffectType.Regeneration, 157, 47, 3);
            yield return (_primary, 181, 47, 3);
        }
    }

    protected override void DrawForeground(GuiContext context) {
        context.Text.DrawCentred(Translations.Get("block.minecraft.beacon.primary")!, Left + 62, Top + 10, 0xFFE0E0E0);
        context.Text.DrawCentred(Translations.Get("block.minecraft.beacon.secondary")!, Left + 169, Top + 10, 0xFFE0E0E0);
        foreach ((IPotionEffectType effect, float x, float y, int tier) in Buttons()) {
            bool chosen = tier == 3 ? _secondary == effect : _primary == effect;
            uint fill = menu.Levels <= tier ? 0xFF404040 : chosen ? 0xFF40A040 : Inside(MouseX, MouseY, Left + x, Top + y, 22, 22) ? 0xFFA0A0C0 : 0xFF707070;
            context.Gui.Rect(Left + x, Top + y, 22, 22, 0xFF000000);
            context.Gui.Rect(Left + x + 1, Top + y + 1, 20, 20, fill);
            context.Text.DrawCentred(effect.Identifier.Key[..2].ToUpperInvariant(), Left + x + 11, Top + y + 7, 0xFFFFFFFF);
        }
        bool canConfirm = _primary != null && menu.Slots[0].HasItem;
        context.Gui.Rect(Left + 164, Top + 107, 22, 22, canConfirm ? 0xFF40A040 : 0xFF404040);
        context.Text.DrawCentred("OK", Left + 175, Top + 114, 0xFFFFFFFF);
        context.Gui.Rect(Left + 190, Top + 107, 22, 22, 0xFFA04040);
        context.Text.DrawCentred("X", Left + 201, Top + 114, 0xFFFFFFFF);
    }

    protected override bool WidgetClicked(GuiContext context, float x, float y, MouseButton button) {
        foreach ((IPotionEffectType effect, float bx, float by, int tier) in Buttons().ToList()) {
            if (!Inside(x, y, Left + bx, Top + by, 22, 22)) {
                continue;
            }
            if (Pressed(context, x, y, Left + bx, Top + by, 22, 22, menu.Levels > tier)) {
                if (tier == 3) {
                    _secondary = effect;
                }
                else {
                    _primary = effect;
                    _secondary = null;
                }
            }
            return true;
        }
        if (_primary is { } primary && Pressed(context, x, y, Left + 164, Top + 107, 22, 22, menu.Slots[0].HasItem)) {
            Client.SetBeaconEffects(primary, _secondary);
            Close(context);
            return true;
        }
        if (Pressed(context, x, y, Left + 190, Top + 107, 22, 22)) {
            Close(context);
            return true;
        }
        return false;
    }
}

