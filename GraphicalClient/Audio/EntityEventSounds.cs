using ClientLib;
using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.DamageType;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Sound;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace GraphicalClient.Audio;

/// <summary>
/// The sounds of <c>ClientPacketListener.handleEntityEvent</c> and <c>handleDamageEvent</c>, through each
/// entity class's own handler.
/// <p/>
/// <c>Entity.playSound</c> on a client plays only for the local player, whose <c>LocalPlayer.playSound</c>
/// plays it here; for everything else the server sends the sound instead. That silences the attack and
/// hurt sounds of <c>IronGolem</c>, <c>Ravager</c>, <c>Hoglin</c>, <c>Zoglin</c> and <c>Creaking</c> events,
/// and leaves death and hurt sounds to the local player alone.
/// </summary>
public sealed class EntityEventSounds(ClientSounds sounds, MinecraftClient client, Func<(double X, double Y, double Z)> camera) {
    // Entity.random is unseeded, so one random stands in for every entity's own.
    private readonly LegacyRandom _random = new();
    private readonly List<FireworkStarter> _fireworks = [];

    /// <summary><c>ClientPacketListener.handleEntityEvent</c>.</summary>
    public void HandleEntityEvent(ClientEntity entity, byte id) {
        switch (id) {
            case 21:
                if (entity.Is(EntityClass.Guardian)) {
                    sounds.Engine.Play(new GuardianAttackSoundInstance(entity, sounds.IsRemoved));
                }
                break;
            case 35:
                sounds.Play(SoundType.TotemUse, SoundSourceOf(entity), 1.0F, 1.0F, entity.Position);
                break;
            case 63:
                if (entity.Is(EntityClass.Sniffer)) {
                    sounds.Engine.Play(new SnifferSoundInstance(entity, sounds.IsRemoved));
                }
                break;
            default:
                EntityHandleEntityEvent(entity, id);
                break;
        }
    }

    /// <summary>
    /// <c>handleEntityEvent</c> down the entity's class chain, for the overrides that play a sound. None of
    /// the overrides left out takes an id the ones here handle.
    /// </summary>
    private void EntityHandleEntityEvent(ClientEntity entity, byte id) {
        if (entity.Is(EntityClass.Armadillo) && id == 64) {
            sounds.Play(SoundType.ArmadilloPeek, SoundSourceOf(entity), 1.0F, 1.0F, entity.Position);
        }
        else if (entity.Is(EntityClass.ArmorStand) && id == 32) {
            sounds.Play(SoundType.ArmorStandHit, SoundSourceOf(entity), 0.3F, 1.0F, entity.Position);
        }
        else if (entity.Is(EntityClass.ZombieVillager) && id == 16) {
            if (!IsSilent(entity)) {
                sounds.Play(SoundType.ZombieVillagerCure, SoundSourceOf(entity), 1.0F + _random.NextFloat(), _random.NextFloat() * 0.7F + 0.3F,
                    entity.Position.X, ZombieVillagerEyeY(entity), entity.Position.Z);
            }
        }
        else if (entity.Is(EntityClass.EvokerFangs)) {
            if (id == 4 && !IsSilent(entity)) {
                sounds.Play(SoundType.EvokerFangsAttack, SoundSourceOf(entity), 1.0F, _random.NextFloat() * 0.2F + 0.85F, entity.Position);
            }
        }
        else if (entity.Is(EntityClass.FireworkRocketEntity)) {
            if (id == 17) {
                CreateFireworks(entity);
            }
        }
        else if (entity.IsLiving) {
            LivingEntityHandleEntityEvent(entity, id);
        }
    }

    /// <summary><c>LivingEntity.handleEntityEvent</c>.</summary>
    private void LivingEntityHandleEntityEvent(ClientEntity entity, byte id) {
        switch (id) {
            case 2:
                OnKineticHit(entity);
                break;
            case 3:
                // Player.getDeathSound, through LocalPlayer.playSound; getSoundVolume is 1.
                if (entity is LocalPlayer) {
                    sounds.PlayFromPlayer(entity, SoundType.PlayerDeath, 1.0F, (_random.NextFloat() - _random.NextFloat()) * 0.2F + 1.0F);
                }
                break;
            case 47 or 48 or 49 or 50 or 51 or 52 or 65 or 68:
                BreakItem(entity, ItemBySlot(entity, id switch {
                    47 => EquipmentSlot.MainHand,
                    48 => EquipmentSlot.OffHand,
                    49 => EquipmentSlot.Helmet,
                    50 => EquipmentSlot.Chestplate,
                    51 => EquipmentSlot.Leggings,
                    52 => EquipmentSlot.Boots,
                    65 => EquipmentSlot.Body,
                    _ => EquipmentSlot.Saddle
                }));
                break;
        }
    }

    /// <summary><c>LivingEntity.handleDamageEvent</c>: <c>Player.getHurtSound</c> is the damage type's effects.</summary>
    public void HandleDamageEvent(ClientEntity entity, IDamageType type) {
        if (entity is not LocalPlayer) {
            return;
        }
        ISoundType hurtSound = type.Effects switch {
            DamageEffectType.Drowning => SoundType.PlayerHurtDrown,
            DamageEffectType.Burning => SoundType.PlayerHurtOnFire,
            DamageEffectType.Poking => SoundType.PlayerHurtSweetBerryBush,
            DamageEffectType.Freezing => SoundType.PlayerHurtFreeze,
            _ => SoundType.PlayerHurt
        };
        sounds.PlayFromPlayer(entity, hurtSound, 1.0F, (_random.NextFloat() - _random.NextFloat()) * 0.2F + 1.0F);
    }

    /// <summary>
    /// <c>LivingEntity.onKineticHit</c>. <c>useItem</c> is the item in the hand the entity data says is in
    /// use, which is what <c>onSyncedDataUpdated</c> takes it to be; the local player's is its own.
    /// </summary>
    private void OnKineticHit(ClientEntity entity) {
        if (entity.OnKineticHit(client.Level?.GameTime ?? 0L)) {
            KineticWeaponComponent.Data? kineticWeapon = ItemComponents.Get(UseItem(entity), DataComponent.KineticWeapon);
            if (kineticWeapon?.HitSound is { } hitSound) {
                sounds.PlayAt(entity, ClientSounds.TypeOf(hitSound), SoundSourceOf(entity), 1.0F, 1.0F);
            }
        }
    }

    private ItemStack UseItem(ClientEntity entity) {
        if (entity is LocalPlayer) {
            return client.Interactions.UsingItem is { } hand ? entity.ItemInHand(hand) : ItemStack.Air;
        }
        sbyte flags = entity.Get(EntityDataFields.LivingEntity.LivingEntityFlags);
        if ((flags & 1) == 0) {
            return ItemStack.Air;
        }
        return entity.ItemInHand((flags & 2) != 0 ? Hand.OffHand : Hand.MainHand);
    }

    /// <summary><c>LivingEntity.breakItem</c>.</summary>
    private void BreakItem(ClientEntity entity, ItemStack itemStack) {
        if (ItemComponents.IsEmpty(itemStack)) {
            return;
        }
        if (ItemComponents.Get(itemStack, DataComponent.BreakSound) is { } breakSound && !IsSilent(entity)) {
            sounds.Play(ClientSounds.TypeOf(breakSound), SoundSourceOf(entity), 0.8F, 0.8F + _random.NextFloat() * 0.4F, entity.Position);
        }
    }

    /// <summary>
    /// <c>getItemBySlot</c>. The server never sends the local player its own equipment: its hands and
    /// armour are its inventory, at <c>Inventory.EQUIPMENT_SLOT_MAPPING</c>.
    /// </summary>
    private ItemStack ItemBySlot(ClientEntity entity, EquipmentSlot slot) {
        if (slot == EquipmentSlot.MainHand) {
            return entity.ItemInHand(Hand.MainHand);
        }
        if (slot == EquipmentSlot.OffHand) {
            return entity.ItemInHand(Hand.OffHand);
        }
        if (entity is LocalPlayer) {
            int index = slot switch {
                EquipmentSlot.Boots => 36,
                EquipmentSlot.Leggings => 37,
                EquipmentSlot.Chestplate => 38,
                EquipmentSlot.Helmet => 39,
                _ => -1
            };
            if (index >= 0) {
                return client.Inventory.Get(index).ToItemStack();
            }
        }
        return entity.GetItemBySlot(slot);
    }

    /// <summary>
    /// <c>getEyeY</c> for a zombie villager: <c>ZombieVillager.BABY_DIMENSIONS</c> for a baby, scaled by the
    /// scale attribute as <c>getDimensions</c> does.
    /// </summary>
    private static double ZombieVillagerEyeY(ClientEntity entity) {
        double eyeHeight = entity.IsBaby ? 0.67F : entity.EyeHeight;
        return entity.Position.Y + eyeHeight * (float)entity.Attributes.Value(Attribute.Scale);
    }

    /// <summary>
    /// <c>FireworkRocketEntity.handleEntityEvent</c> into <c>ClientLevel.createFireworks</c>. With no
    /// explosions it is only poof particles.
    /// </summary>
    private void CreateFireworks(ClientEntity rocket) {
        ItemStack item = rocket.Get(EntityDataFields.FireworkRocketEntity.IdFireworksItem) ?? ItemStack.Air;
        FireworkExplosionComponent.Data[] explosions = ItemComponents.Get(item, DataComponent.Fireworks)?.Explosions ?? [];
        if (explosions.Length > 0) {
            _fireworks.Add(new FireworkStarter(sounds, camera, rocket.Position.X, rocket.Position.Y, rocket.Position.Z, explosions));
        }
    }

    /// <summary>The particle engine's tick, for the firework starters.</summary>
    public void Tick() {
        foreach (FireworkStarter firework in _fireworks) {
            firework.Tick();
        }
        _fireworks.RemoveAll(firework => firework.Removed);
    }

    private static bool IsSilent(ClientEntity entity) => entity.Get(EntityDataFields.Entity.Silent);

    /// <summary><c>Entity.getSoundSource</c> and its overrides, most derived first.</summary>
    private static SoundCategory SoundSourceOf(ClientEntity entity) {
        if (entity.Is(EntityClass.LightningBolt)) {
            return SoundCategory.Weather;
        }
        if (entity.Is(EntityClass.ExperienceOrb) || entity.Is(EntityClass.ItemEntity)) {
            return SoundCategory.Ambient;
        }
        if (entity.Is(EntityClass.SulfurCube) || entity.Is(EntityClass.Parrot) || entity.Is(EntityClass.HappyGhast)) {
            return SoundCategory.Neutral;
        }
        if (entity.Is(EntityClass.Rabbit)) {
            return entity.Get(EntityDataFields.Rabbit.Type) == (int)RabbitVariant.Evil ? SoundCategory.Hostile : SoundCategory.Neutral;
        }
        if (entity.Is(EntityClass.Monster) || entity.Is(EntityClass.AbstractCubeMob) || entity.Is(EntityClass.EnderDragon) || entity.Is(EntityClass.Ghast)
            || entity.Is(EntityClass.Phantom) || entity.Is(EntityClass.Shulker) || entity.Is(EntityClass.ShulkerBullet) || entity.Is(EntityClass.Hoglin)) {
            return SoundCategory.Hostile;
        }
        return entity.Is(EntityClass.Player) ? SoundCategory.Players : SoundCategory.Neutral;
    }

    /// <summary>
    /// The sound half of <c>FireworkParticles.Starter</c>, the invisible particle a rocket's explosion
    /// leaves behind: the blast on its first tick and, after any twinkling stars have burst, the crackle.
    /// It never moves, as <c>Starter.tick</c> does not call the particle's own movement.
    /// </summary>
    private sealed class FireworkStarter {
        private readonly ClientSounds _sounds;
        private readonly Func<(double X, double Y, double Z)> _camera;
        private readonly double _x, _y, _z;
        private readonly FireworkExplosionComponent.Data[] _explosions;
        private readonly LegacyRandom _random = new();
        private readonly int _lifetime;
        private readonly bool _twinkleDelay;
        private int _life;

        public bool Removed { get; private set; }

        public FireworkStarter(ClientSounds sounds, Func<(double X, double Y, double Z)> camera, double x, double y, double z, FireworkExplosionComponent.Data[] explosions) {
            _sounds = sounds;
            _camera = camera;
            (_x, _y, _z) = (x, y, z);
            _explosions = explosions;
            _lifetime = explosions.Length * 2 - 1;
            if (explosions.Any(explosion => explosion.HasTwinkle)) {
                _twinkleDelay = true;
                _lifetime += 15;
            }
        }

        public void Tick() {
            if (_life == 0) {
                bool farEffect = IsFarAwayFromCamera();
                bool largeExplosion = _explosions.Length >= 3 || _explosions.Any(explosion => explosion.Shape == FireworkShape.LargeBall);
                ISoundType sound = largeExplosion
                    ? farEffect ? SoundType.FireworkRocketLargeBlastFar : SoundType.FireworkRocketLargeBlast
                    : farEffect ? SoundType.FireworkRocketBlastFar : SoundType.FireworkRocketBlast;
                _sounds.Play(sound, SoundCategory.Ambient, 20.0F, 0.95F + _random.NextFloat() * 0.1F, _x, _y, _z, true);
            }
            _life++;
            if (_life > _lifetime) {
                if (_twinkleDelay) {
                    ISoundType sound = IsFarAwayFromCamera() ? SoundType.FireworkRocketTwinkleFar : SoundType.FireworkRocketTwinkle;
                    _sounds.Play(sound, SoundCategory.Ambient, 20.0F, 0.9F + _random.NextFloat() * 0.15F, _x, _y, _z, true);
                }
                Removed = true;
            }
        }

        private bool IsFarAwayFromCamera() => ClientSounds.DistanceSqr(_camera(), _x, _y, _z) >= 256.0;
    }
}
