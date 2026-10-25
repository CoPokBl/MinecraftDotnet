using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace GraphicalClient.Rendering.Entities;

/// <summary>
/// <c>ItemModelResolver</c>: the definition a stack's <c>item_model</c> names, walked for a display context
/// and an owner. Game thread only, as the output it fills is shared.
/// </summary>
public sealed class ItemModelResolver(IResourceSource source, MinecraftClient? client) {
    private readonly ItemModelQuery _query = new();
    private readonly ItemModelOutput _output = new();
    private readonly Dictionary<Identifier, ItemModelNode?> _definitions = new();

    /// <summary>The connection whose level and player items are resolved against, replaced on every join.</summary>
    public MinecraftClient? Client { get; set; } = client;

    /// <summary>The local player, whom the GUI's items are resolved for.</summary>
    public ClientEntity? Player => Client?.Player;

    /// <summary>The definition a stack's model id names; null when the source has none, which vanilla draws as the missing model.</summary>
    public ItemModelNode? Definition(ItemStack stack) {
        Identifier modelId = ModelIdOf(stack);
        if (!_definitions.TryGetValue(modelId, out ItemModelNode? definition)) {
            definition = source.ItemDefinition(modelId);
            _definitions[modelId] = definition;
        }
        return definition;
    }

    /// <summary><c>DataComponents.ITEM_MODEL</c>, which the component's network read leaves as text.</summary>
    private static Identifier ModelIdOf(ItemStack stack) {
        if (!stack.Components.TryGetValue(DataComponent.ItemModel, out object? value)
            && (stack.RemoveComponents.Contains(DataComponent.ItemModel) || !stack.Type.DefaultComponents.TryGetValue(DataComponent.ItemModel, out value))) {
            return stack.Type.Identifier;
        }
        return value switch {
            Identifier id => id,
            string text => Identifier.Parse(text),
            _ => stack.Type.Identifier
        };
    }

    /// <summary>
    /// <c>updateForTopItem</c>. <paramref name="heldIn"/> is the owner's hand this very stack is in and
    /// <paramref name="carried"/> whether it is the stack on the cursor. The output is reused by the next call.
    /// </summary>
    public ItemModelOutput Update(ItemStack stack, ItemDisplayContext context, ClientEntity? owner, int seed, Hand? heldIn = null, bool carried = false) {
        _output.Clear();
        if (stack.IsAir()) {
            return _output;
        }
        if (Definition(stack) is not { } definition) {
            _output.Missing = true;
            return _output;
        }
        _query.Stack = stack;
        _query.DisplayContext = context;
        _query.Client = Client;
        _query.Level = Client?.Level;
        _query.Owner = owner;
        _query.Seed = seed;
        _query.HeldIn = heldIn;
        _query.Carried = carried;
        _query.Definition ??= Definition;
        definition.Update(_output, _query);
        return _output;
    }

    /// <summary><c>shouldPlaySwapAnimation</c>.</summary>
    public bool ShouldPlaySwapAnimation(ItemStack stack) => source.ItemProperties(ModelIdOf(stack)).HandAnimationOnSwap;

    /// <summary><c>swapAnimationScale</c>.</summary>
    public float SwapAnimationScale(ItemStack stack) => source.ItemProperties(ModelIdOf(stack)).SwapAnimationScale;

    /// <summary>The seed <c>updateForLiving</c> and <c>updateForNonLiving</c> give an owner.</summary>
    public static int SeedFor(ClientEntity? owner, ItemDisplayContext context) => owner == null ? 0 : owner.IsLiving ? owner.Id + (int)context : owner.Id;
}
