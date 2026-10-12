using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features.Basic;
using ManagedServer.Fluids;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.DamageType;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Fluids;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Standing in lava sets an entity alight and hurts it, and burning keeps hurting it after it climbs
/// out. Vanilla's <c>Entity.lavaHurt</c> plus the fire half of <c>Entity.baseTick</c>.
/// <p/>
/// Needs a <see cref="LiquidsFeature"/> registered, which is what knows where the lava is.
/// <p/>
/// Lava is asked for four damage every tick an entity is inside it, exactly as vanilla does, and the
/// invulnerable window in <see cref="LivingEntity.Damage(DamageSource, float)"/> throws all but one
/// every ten ticks away. Nothing is counted here.
/// </summary>
public class LavaDamageFeature(float lavaDamage = 4f, float fireDamage = 1f) : ScopedFeature {
    /// <summary>Damage per hit while standing in lava, twice a second, <c>Entity.lavaHurt</c>.</summary>
    public float LavaDamage { get; set; } = lavaDamage;

    /// <summary>Damage a second while burning out of lava, <c>Entity.baseTick</c>.</summary>
    public float FireDamage { get; set; } = fireDamage;

    /// <summary>
    /// Entities that lava neither ignites nor hurts. <c>Entity.fireImmune</c> is the entity type's own
    /// flag, which covers blazes and the rest; creative and spectator players are added because vanilla
    /// stops them in <c>isInvulnerableTo</c>, which is a check we do not have.
    /// <p/>
    /// The fire resistance effect is deliberately not here. <see cref="FireResistanceFeature"/> stops
    /// anything in <c>minecraft:is_fire</c>, which covers this and every other way of burning at once.
    /// </summary>
    public Func<Entity, bool> FireImmune { get; set; } = entity =>
        entity.Type.FireImmune || entity is Player { GameMode: GameMode.Creative or GameMode.Spectator };

    public override void Register() {
        AddEventHandler<ServerTickEvent>(e => {
            LiquidsFeature? liquids = e.Server.FeatureHandler.Features.OfType<LiquidsFeature>().FirstOrDefault();
            if (liquids == null) {
                return;
            }

            foreach (World world in e.Server.Worlds) {
                FluidSimulation fluids = liquids.GetSimulation(world);
                foreach (Entity entity in world.Entities.GetEntities()) {
                    TickEntity(fluids, entity);
                }
            }
        });
    }

    private void TickEntity(FluidSimulation fluids, Entity entity) {
        if (FireImmune(entity)) {
            EntityFluids.ClearFire(entity);
            return;
        }

        bool inLava = EntityFluids.IsIn(fluids, entity, FluidKind.Lava);
        if (inLava) {
            EntityFluids.IgniteForTicks(entity, EntityFluids.LavaFireTicks);
        }

        int fireTicks = EntityFluids.FireTicks(entity);

        // Being in lava is checked first so the burn damage below never lands while an entity is still
        // in the lava that lit it, which is what makes lava four damage rather than five.
        if (inLava) {
            if (Damage(entity, DamageType.Lava, LavaDamage)) {
                // Entity.lavaHurt plays this on top of the hurt sound, and only when the damage landed.
                PlaySound(entity, SoundType.GenericBurn, 0.4f, 2f + Random.Shared.NextSingle() * 0.4f);
            }
        }
        else if (fireTicks > 0 && fireTicks % 20 == 0) {
            Damage(entity, DamageType.OnFire, FireDamage);
        }

        if (fireTicks > 0) {
            EntityFluids.SetFireTicks(entity, fireTicks - 1);
        }
    }

    /// <summary>Returns whether the damage landed, which is what gates the burn sound in vanilla.</summary>
    private static bool Damage(Entity entity, IDamageType type, float amount) {
        return entity is LivingEntity living && living.Damage(new DamageSource(type), amount);
    }

    /// <summary>
    /// Unlike the block sounds, this one goes to the burning entity too, since it is its own fire.
    /// The hurt sound beside it is the client's, played off the damage event packet.
    /// </summary>
    private static void PlaySound(Entity entity, ISoundType sound, float volume, float pitch) {
        entity.SendToSelfAndViewers(new ClientBoundSoundEffectPacket(sound,
            entity is Player ? SoundCategory.Players : SoundCategory.Neutral,
            entity.Position, volume, pitch, Random.Shared.NextInt64()));
    }
}
