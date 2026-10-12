using ClientLib.Entities;
using Minecraft.Data;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities.Meta;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>A variant entity data id, read through the registry the server sent during configuration.</summary>
internal static class SyncedVariants {
    /// <summary>
    /// The variant the id names. A value at its default is never sent, so an id the client has not
    /// received is the default <c>defineSynchedData</c> gives it, <c>VariantUtils.getDefaultOrAny</c>.
    /// </summary>
    public static T? Resolve<T>(SequentialRegistry<T> registry, ClientEntity entity, EntityDataField<int> field, Identifier defaultId)
        where T : class, IProtocolType {
        if (entity.Has(field)) {
            int id = entity.Get(field);
            return id >= 0 && id < registry.Count ? registry[id] : null;
        }
        return registry.All.FirstOrDefault(v => v.Identifier == defaultId) ?? registry.All.FirstOrDefault();
    }

    /// <summary><c>ClientAsset.ResourceTexture</c>'s texture path.</summary>
    public static string TexturePath(Identifier assetId) => $"{assetId.Namespace}:textures/{assetId.Key}.png";
}
