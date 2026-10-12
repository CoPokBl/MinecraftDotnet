using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using ClientLib.Entities.Vehicles;

namespace ClientLib.Entities;

public static class EntityKinds {
    /// <summary>
    /// <c>EntityType.create</c> for a spawn packet: the classes whose client side tick is simulated get
    /// their own, and everything else is a plain <see cref="ClientEntity"/>.
    /// </summary>
    public static ClientEntity Create(MinecraftClient client, IEntityType type, Guid uuid, int spawnData) {
        bool Is(EntityClass vanillaClass) => EntityClasses.Is(type.Identifier, vanillaClass);
        ClientEntity entity = type == EntityType.Item ? new ClientItemEntity(client)
            : type == EntityType.ExperienceOrb ? new ClientExperienceOrb(client)
            : type == EntityType.Tnt ? new ClientPrimedTnt(client)
            : type == EntityType.FallingBlock ? new ClientFallingBlock(client)
            : Is(EntityClass.AbstractBoat) ? new ClientBoat(client)
            : Is(EntityClass.Camel) ? new ClientCamel(client)
            : Is(EntityClass.AbstractHorse) ? new ClientHorse(client)
            : Is(EntityClass.Pig) ? new ClientPig(client)
            : Is(EntityClass.Strider) ? new ClientStrider(client)
            : Is(EntityClass.HappyGhast) ? new ClientHappyGhast(client)
            : Is(EntityClass.AbstractNautilus) ? new ClientNautilus(client)
            : Is(EntityClass.Shulker) ? new ClientShulker(client)
            : type == EntityType.CommandBlockMinecart ? new ClientMinecartCommandBlock()
            : new ClientEntity { MovesFreely = MovesFreely(type) };
        entity.Uuid = uuid;
        entity.Type = type;
        entity.SpawnData = spawnData;
        return entity;
    }

    /// <summary>Projectiles, whose client copy moves by its velocity between server updates rather than only interpolating.</summary>
    private static bool MovesFreely(IEntityType type) =>
        type == EntityType.Arrow || type == EntityType.SpectralArrow || type == EntityType.Trident || type == EntityType.Snowball
        || type == EntityType.Egg || type == EntityType.EnderPearl || type == EntityType.ExperienceBottle
        || type == EntityType.SplashPotion || type == EntityType.LingeringPotion || type == EntityType.FishingBobber;
}
