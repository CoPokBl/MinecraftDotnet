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
        ClientEntity entity = type.Identifier == EntityType.Item.Identifier ? new ClientItemEntity(client)
            : type.Identifier == EntityType.ExperienceOrb.Identifier ? new ClientExperienceOrb(client)
            : type.Identifier == EntityType.Tnt.Identifier ? new ClientPrimedTnt(client)
            : type.Identifier == EntityType.FallingBlock.Identifier ? new ClientFallingBlock(client)
            : Is(EntityClass.AbstractBoat) ? new ClientBoat(client)
            : Is(EntityClass.Camel) ? new ClientCamel(client)
            : Is(EntityClass.AbstractHorse) ? new ClientHorse(client)
            : Is(EntityClass.Pig) ? new ClientPig(client)
            : Is(EntityClass.Strider) ? new ClientStrider(client)
            : Is(EntityClass.HappyGhast) ? new ClientHappyGhast(client)
            : Is(EntityClass.AbstractNautilus) ? new ClientNautilus(client)
            : Is(EntityClass.Shulker) ? new ClientShulker(client)
            : type.Identifier == EntityType.CommandBlockMinecart.Identifier ? new ClientMinecartCommandBlock()
            : new ClientEntity { MovesFreely = MovesFreely(type) };
        entity.Uuid = uuid;
        entity.Type = type;
        entity.SpawnData = spawnData;
        // Display's InterpolationHandler takes no steps until its teleport duration says otherwise.
        if (Is(EntityClass.Display)) {
            entity.InterpolationSteps = 0;
        }
        return entity;
    }

    /// <summary>Projectiles, whose client copy moves by its velocity between server updates rather than only interpolating.</summary>
    private static bool MovesFreely(IEntityType type) =>
        type.Identifier == EntityType.Arrow.Identifier || type.Identifier == EntityType.SpectralArrow.Identifier || type.Identifier == EntityType.Trident.Identifier || type.Identifier == EntityType.Snowball.Identifier
        || type.Identifier == EntityType.Egg.Identifier || type.Identifier == EntityType.EnderPearl.Identifier || type.Identifier == EntityType.ExperienceBottle.Identifier
        || type.Identifier == EntityType.SplashPotion.Identifier || type.Identifier == EntityType.LingeringPotion.Identifier || type.Identifier == EntityType.FishingBobber.Identifier;
}
