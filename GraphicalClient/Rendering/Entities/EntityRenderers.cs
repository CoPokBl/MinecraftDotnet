using Minecraft.Data.Entities;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>EntityRendererProvider.Context</c>: what a renderer is built with.</summary>
public sealed class EntityRendererContext {
    public required ItemRenderer Items { get; init; }
    public required BlockModelRenderer Blocks { get; init; }

    /// <summary>The resource packs, for anything a renderer reads beyond textures, such as equipment assets.</summary>
    public required GraphicalClient.Assets.ResourcePacks.ResourcePackSource Pack { get; init; }
}

/// <summary>
/// <c>EntityRenderers</c>: the renderer each entity type is drawn with. Each group of vanilla renderers
/// registers from its own file through one of the partial methods, so a type nobody has ported falls
/// back to the built in art rather than failing.
/// </summary>
public static partial class EntityRenderers {
    private static readonly Dictionary<IEntityType, Func<EntityRendererContext, EntityRenderer>> Providers = new();

    static EntityRenderers() {
        RegisterCore();
        RegisterHumanoids();
        RegisterIllagersAndVillagers();
        RegisterQuadrupeds();
        RegisterHorsesAndPets();
        RegisterSmallAndFlying();
        RegisterAquatic();
        RegisterArthropodsAndBosses();
        RegisterObjectsAndProjectiles();
    }

    private static void Register(IEntityType type, Func<EntityRendererContext, EntityRenderer> provider) => Providers[type] = provider;

    static partial void RegisterHumanoids();
    static partial void RegisterIllagersAndVillagers();
    static partial void RegisterQuadrupeds();
    static partial void RegisterHorsesAndPets();
    static partial void RegisterSmallAndFlying();
    static partial void RegisterAquatic();
    static partial void RegisterArthropodsAndBosses();
    static partial void RegisterObjectsAndProjectiles();

    private static void RegisterCore() {
        Register(Minecraft.Data.Generated.EntityType.Item, context => new ItemEntityRenderer(context));
        Register(Minecraft.Data.Generated.EntityType.Creeper, context => new Vanilla.CreeperRenderer(context));
    }

    /// <summary>
    /// <c>createEntityRenderers</c>: one renderer per registered type. One that throws while building is
    /// reported and left out, so its type draws as the built in art.
    /// </summary>
    public static Dictionary<IEntityType, EntityRenderer> CreateAll(EntityRendererContext context, Action<string> report) {
        Dictionary<IEntityType, EntityRenderer> renderers = new();
        foreach ((IEntityType type, Func<EntityRendererContext, EntityRenderer> provider) in Providers) {
            try {
                renderers[type] = provider(context);
            }
            catch (Exception e) {
                report($"No renderer for {type.Identifier}: {e.Message}");
            }
        }
        return renderers;
    }
}
