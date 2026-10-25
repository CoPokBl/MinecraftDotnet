using System.Numerics;
using ClientLib;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Gui;
using GraphicalClient.Rendering.Entities;

namespace GraphicalClient.Rendering;

/// <summary>
/// Everything drawn from one set of resource packs, built by <see cref="GameRenderer.Build"/> and put in use
/// whole by <see cref="GameRenderer.Swap"/>, so the frame never draws from a mix of two sets.
/// </summary>
public sealed class PackResources : IDisposable {
    public required PackFiles? Packs { get; init; }

    /// <summary>The connection this was built against, which may have been replaced by the time it is swapped in.</summary>
    public required MinecraftClient Client { get; init; }
    public required BlockModels Models { get; init; }
    public required TextureAnimator Animator { get; init; }
    public required WorldRenderer World { get; init; }
    public required TextRenderer Text { get; init; }
    public required GuiSprites Sprites { get; init; }
    public required HudIcons Icons { get; init; }
    public required EnchantmentGlint Glint { get; init; }
    public required ItemModelResolver ItemModels { get; init; }
    public required ItemAtlas Items { get; init; }
    public required WorldScene Scene { get; init; }
    public required GuiEntityRenderer GuiEntities { get; init; }
    public required Vector3[] EndPortalColours { get; init; }

    /// <summary>On the render thread; the packs themselves belong to whoever opened them.</summary>
    public void Dispose() {
        World.Dispose();
        Scene.Dispose();
        GuiEntities.Dispose();
        Text.Dispose();
        Icons.Dispose();
        Items.Dispose();
        Glint.Dispose();
        Sprites.Dispose();
        Models.Textures.Dispose();
    }
}
