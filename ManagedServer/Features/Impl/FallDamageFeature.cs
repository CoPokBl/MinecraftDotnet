using Minecraft.Schemas.Blocks.BlockEnums;
using ManagedServer.Damage;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Blocks;
using Minecraft.Data.DamageType;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Registry.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Landing after a fall hurts. Vanilla's <c>LivingEntity.causeFallDamage</c> plus the <c>fallOn</c>
/// overrides that soften a landing, driven by the <see cref="EntityLandEvent"/> that
/// <see cref="EntityPhysics.CheckFallDamage"/> fires.
/// <p/>
/// The distance itself is kept whether this is registered or not, so nothing else has to be: a player
/// is tracked from the movement their client reports and everything else from what
/// <see cref="Features.Basic.PhysicsFeature"/> simulates.
/// <p/>
/// Damage is <c>floor((distance + 1e-6 - safe_fall_distance) * blockModifier * fall_damage_multiplier)</c>,
/// so both attributes do what they do in vanilla: raising <c>safe_fall_distance</c> on a player is
/// what feather falling is, and a mob type that carries its own value (a horse, a camel) uses that.
/// </summary>
public class FallDamageFeature : ScopedFeature {
    /// <summary>
    /// Entities a fall never hurts. <c>minecraft:fall_damage_immune</c> is the entity type tag vanilla
    /// checks in <c>causeFallDamage</c>; creative and spectator players are added because vanilla stops
    /// them on <c>abilities.mayfly</c> instead, which is not something we carry.
    /// </summary>
    public Func<Entity, bool> Immune { get; set; } = entity =>
        entity is Player { GameMode: GameMode.Creative or GameMode.Spectator } ||
        InTag(entity.Server.Registry, entity.Server.Registry.EntityTypes.Tags,
            FallDamageImmuneTag, entity.Type.Identifier);

    private static readonly Identifier FallDamageImmuneTag = "minecraft:fall_damage_immune";

    public override void Register() {
        AddEventHandler<EntityLandEvent>(e => Land(e.World, e.Entity, e.FallDistance, e.LandedOn));
    }

    private void Land(World world, Entity entity, double fallDistance, Vec3<int> landedOn) {
        if (entity is not LivingEntity living || Immune(entity)) {
            return;
        }

        (double distance, float modifier, IDamageType source) =
            FallOn(world.GetBlockOr(landedOn, Block.Air), fallDistance);

        int damage = CalculateFallDamage(living, distance, modifier);
        if (damage <= 0) {
            return;
        }

        // LivingEntity.getFallDamageSound, which is the entity's own fall sound and the big one past
        // four damage. The per mob overrides are methods rather than data, so as with the hurt sounds
        // everything that is not a player gets the base LivingEntity pair.
        bool big = damage > 4;
        PlaySound(living, living is Player
            ? big ? SoundType.PlayerBigFall : SoundType.PlayerSmallFall
            : big ? SoundType.GenericBigFall : SoundType.GenericSmallFall);

        living.Damage(new DamageSource(source), damage);
    }

    /// <summary><c>LivingEntity.calculateFallDamage</c>, with <c>calculateFallPower</c> folded in.</summary>
    private static int CalculateFallDamage(LivingEntity entity, double fallDistance, float modifier) {
        double power = fallDistance + 1.0E-6 - entity.GetAttributeValue(Attribute.SafeFallDistance);
        return (int)Math.Floor(power * modifier * entity.GetAttributeValue(Attribute.FallDamageMultiplier));
    }

    /// <summary>
    /// <c>Block.fallOn</c> and the overrides of it, as the distance and the damage modifier they end up
    /// calling <c>causeFallDamage</c> with. Everything not listed lands at its full distance and full
    /// damage.
    /// <p/>
    /// Farmland turning to dirt and turtle eggs breaking are the other two things vanilla does from
    /// here. Both are what the landing does to the block rather than to the entity, so they belong to
    /// whatever feature owns those blocks and are not done here.
    /// </summary>
    private static (double Distance, float Modifier, IDamageType Source) FallOn(IBlock block,
        double fallDistance) {
        Identifier id = block.Identifier;

        // Hay and honey take a fifth; slime takes none, and the crouching case vanilla handles by not
        // calling causeFallDamage at all comes out the same way.
        if (id.Equals(Block.HayBlock.Identifier) || id.Equals(Block.HoneyBlock.Identifier)) {
            return (fallDistance, 0.2f, DamageType.Fall);
        }

        if (id.Equals(Block.SlimeBlock.Identifier) || id.Equals(Block.PowderSnow.Identifier)) {
            return (fallDistance, 0.0f, DamageType.Fall);
        }

        // A stalagmite is the one that makes a fall worse rather than better, and the one that lands as
        // its own damage type rather than as a fall.
        if (block is PointedDripstoneBlock {
                VerticalDirection: VerticalDirection.Up,
                Thickness: SpeleothemThickness.Tip
            }) {
            return (fallDistance + 2.5, 2.0f, DamageType.Stalagmite);
        }

        // Block.fallOn itself. The overrides above do not call it, so the reduction is theirs to skip.
        return (fallDistance * (1.0f - block.FallDistanceReduction), 1.0f, DamageType.Fall);
    }

    private static bool InTag(MinecraftRegistry registry, RegistryTagContainer tags, Identifier tag, Identifier value) {
        if (!tags.Contains(tag)) {
            return false;
        }

        foreach (Identifier id in tags[tag].GetValueIds(registry)) {
            if (id.Equals(value)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// The landing sound, which vanilla plays on top of the hurt sound the damage event carries.
    /// Unlike the block sounds this one goes to the entity itself too, since it is its own fall.
    /// </summary>
    private static void PlaySound(Entity entity, ISoundType sound) {
        entity.SendToSelfAndViewers(new ClientBoundSoundEffectPacket(sound,
            entity is Player ? SoundCategory.Players : SoundCategory.Neutral,
            entity.Position, 1f, 1f, Random.Shared.NextInt64()));
    }
}
