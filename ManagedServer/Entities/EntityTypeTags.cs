using Minecraft.Schemas;

namespace ManagedServer.Entities;

/// <summary>
/// The <c>minecraft:entity_type</c> tags that core entity behaviour asks about, vanilla's
/// <c>EntityTypeTags</c>. They are looked up through
/// <see cref="Minecraft.Registry.Tags.RegistryTagContainer.Contains(Minecraft.Registry.MinecraftRegistry,Identifier,Identifier)"/>,
/// so a tag the registry does not have reads as empty rather than throwing.
/// </summary>
public static class EntityTypeTags {
    /// <summary>
    /// Mobs a wind charge does not anger. Being flung around by a breeze is meant to be a nuisance
    /// rather than a fight, so these do not remember it as an attacker.
    /// </summary>
    public static readonly Identifier NoAngerFromWindCharge = "minecraft:no_anger_from_wind_charge";
}
