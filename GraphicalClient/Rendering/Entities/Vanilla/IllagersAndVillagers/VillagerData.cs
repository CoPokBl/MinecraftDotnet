using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Registry;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>
/// <c>VillagerData</c> as the wire carries it: a <c>villager_type</c> and a <c>villager_profession</c>
/// registry id, and the level.
/// </summary>
public readonly record struct VillagerData(int Type, int Profession, int Level) {
    /// <summary>The synced value, or <c>Villager.createDefaultVillagerData</c>'s plains, none, 1 until the server sends one.</summary>
    public static VillagerData Read(ClientEntity entity, Minecraft.Schemas.Entities.Meta.EntityDataField<(int, int, int)> field, MinecraftRegistry registry) {
        if (entity.Has(field)) {
            (int type, int profession, int level) = entity.Get(field);
            return new VillagerData(type, profession, level);
        }
        return new VillagerData(registry.VillagerTypes.GetProtocolId(VillagerType.Plains), VillagerProfessions.None, 1);
    }
}
