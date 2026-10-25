using System.Numerics;
using ClientLib.Recipes;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Recipes;

namespace GraphicalClient.Gui;

/// <summary>
/// <c>RecipeToast</c>: one toast for every recipe unlocked while it is up, cycling through them, each shown as the
/// station it is made at, small, behind what it makes. It stays five seconds after the last one arrived.
/// </summary>
public sealed class RecipeToast : Toast {
    private const long DisplayTime = 5000;

    private readonly List<(ItemStack CategoryItem, ItemStack UnlockedItem)> _recipeItems = [];
    private long _lastChanged;
    private bool _changed;
    private ToastVisibility _wantedVisibility = ToastVisibility.Hide;
    private int _displayedRecipeIndex;

    private RecipeToast() {
    }

    public override ToastVisibility WantedVisibility => _wantedVisibility;

    public override void Update(ToastManager manager, long fullyVisibleForMs) {
        if (_changed) {
            _lastChanged = fullyVisibleForMs;
            _changed = false;
        }
        double displayTime = DisplayTime * manager.NotificationDisplayTimeMultiplier;
        _wantedVisibility = _recipeItems.Count == 0 || fullyVisibleForMs - _lastChanged >= displayTime ? ToastVisibility.Hide : ToastVisibility.Show;
        if (_recipeItems.Count > 0) {
            _displayedRecipeIndex = (int)(fullyVisibleForMs / Math.Max(1.0, displayTime / _recipeItems.Count) % _recipeItems.Count);
        }
    }

    public override void Render(GuiContext context, float x, float y, long fullyVisibleForMs) {
        bool fallback = !context.Sprites.Sprite(context.Gui, "toast/recipe", x, y, Width, Height);
        if (fallback) {
            AdvancementToast.DrawFallbackBackground(context, x, y, Width, Height);
        }
        context.Text.Draw(Menus.T("recipe.toast.title"), x + 30, y + 7, fallback ? 0xFFE0A0E0 : 0xFF500050, false);
        context.Text.Draw(Menus.T("recipe.toast.description"), x + 30, y + 18, fallback ? 0xFFFFFFFF : 0xFF000000, false);
        if (_recipeItems.Count == 0) {
            return;
        }
        (ItemStack category, ItemStack unlocked) = _recipeItems[_displayedRecipeIndex];
        Matrix3x2 previous = context.Gui.Pose;
        context.Gui.Pose = Matrix3x2.CreateScale(0.6F) * Matrix3x2.CreateTranslation(x, y) * previous;
        GuiItems.Icon(context, category, 3, 3);
        context.Gui.Pose = previous;
        GuiItems.Icon(context, unlocked, x + 8, y + 8);
    }

    /// <summary><c>addOrUpdate</c>: added to the toast already up or waiting, or a new one when there is none.</summary>
    public static void AddOrUpdate(ToastManager toasts, RecipeDisplay recipe, SlotDisplayContext context) {
        RecipeToast? toast = toasts.Get<RecipeToast>(NoToken);
        if (toast == null) {
            toast = new RecipeToast();
            toasts.Add(toast);
        }
        toast._recipeItems.Add((recipe.CraftingStation.ResolveForFirstStack(context), recipe.Result.ResolveForFirstStack(context)));
        toast._changed = true;
    }
}
