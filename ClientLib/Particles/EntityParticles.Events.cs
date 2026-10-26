using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary>The particles of <c>ClientPacketListener.handleEntityEvent</c> and the <c>handleEntityEvent</c> overrides it reaches.</summary>
public sealed partial class EntityParticles {
    private static readonly IParticle HoneyBlock = Particle.Block with { BlockState = Block.HoneyBlock };

    /// <summary><c>ClientPacketListener.handleEntityEvent</c>: the totem's emitter, else the entity's own handler.</summary>
    public void HandleEntityEvent(ClientEntity entity, byte id) {
        // Until the engine has ticked in a new level, its block lookups still read the old one.
        if (!_engine.Enabled || !ReferenceEquals(_client.Level, _level)) {
            return;
        }
        switch (id) {
            case 21:
            case 63:
                break;
            case 35:
                _engine.CreateTrackingEmitter(entity, Particle.TotemOfUndying, 30);
                break;
            default:
                EntityHandleEntityEvent(entity, id);
                break;
        }
    }

    /// <summary>
    /// <c>handleEntityEvent</c> down the class chain, most derived first. An override that does not pass an id
    /// on returns; the rest fall through to their superclass's.
    /// </summary>
    private void EntityHandleEntityEvent(ClientEntity e, byte id) {
        if (e.Is(EntityClass.Arrow)) {
            if (id == 0) {
                ArrowPotionBurst(e);
                return;
            }
        }
        else if (e.Is(EntityClass.Snowball) || e.Is(EntityClass.ThrownEgg)) {
            // Neither passes any id on.
            if (id == 3) {
                ThrowableBreak(e);
            }
            return;
        }
        else if (e.Is(EntityClass.FireworkRocketEntity)) {
            if (id == 17) {
                CreateFireworks(e);
            }
        }
        else if (e.Is(EntityClass.EvokerFangs)) {
            if (id == 4) {
                EntityEmitter fangs = EmitterOf(e);
                if (!fangs.Flag) {
                    fangs.Flag = true;
                    fangs.A = 22;
                }
            }
        }
        else if (e.Is(EntityClass.MinecartTNT)) {
            if (id == 70) {
                EmitterOf(e).A = 80;
                return;
            }
        }
        else if (e.IsLiving) {
            LivingHandleEntityEvent(e, id);
            return;
        }
        if (id == 53) {
            HoneyParticles(e, 5);
        }
    }

    private EntityEmitter EmitterOf(ClientEntity entity) => entity.Emitter ??= new EntityEmitter(Classify(entity), entity.IsLiving);

    private void LivingHandleEntityEvent(ClientEntity e, byte id) {
        if (e.Is(EntityClass.Villager)) {
            // Villager.handleEntityEvent through AbstractVillager.addParticlesAroundSelf.
            IParticle? particle = id switch {
                12 => Particle.Heart,
                13 => Particle.AngryVillager,
                14 => Particle.HappyVillager,
                42 => Particle.Splash,
                _ => null
            };
            if (particle != null) {
                ParticlesAroundSelf(e, particle, 5, 1.0, 0.02);
                return;
            }
        }
        else if (e.Is(EntityClass.Witch)) {
            if (id == 15) {
                double top = e.BoundingBox.MaxY;
                for (int i = 0; i < R.NextInt(35) + 10; i++) {
                    Add(Particle.Witch, e.Position.X + R.NextGaussian() * 0.13F, top + 0.5 + R.NextGaussian() * 0.13F, e.Position.Z + R.NextGaussian() * 0.13F, 0.0, 0.0, 0.0);
                }
                return;
            }
        }
        else if (e.Is(EntityClass.Ravager)) {
            // Ravager.handleEntityEvent passes every id on, these two included.
            if (id == 39) {
                EmitterOf(e).A = 40;
            }
            else if (id == 69) {
                Minecraft.Physics.Box box = e.BoundingBox;
                double cx = (box.MinX + box.MaxX) / 2.0, cy = (box.MinY + box.MaxY) / 2.0, cz = (box.MinZ + box.MaxZ) / 2.0;
                for (int i = 0; i < 40; i++) {
                    Add(Particle.Poof, cx, cy, cz, R.NextGaussian() * 0.2, R.NextGaussian() * 0.2, R.NextGaussian() * 0.2);
                }
            }
        }
        else if (e.Is(EntityClass.Allay)) {
            if (id == 18) {
                ParticlesAroundSelf(e, Particle.Heart, 3, 0.5, 0.02);
                return;
            }
        }
        else if (e.Is(EntityClass.Ocelot)) {
            if (id is 40 or 41) {
                ParticlesAroundSelf(e, id == 41 ? Particle.Heart : Particle.Smoke, 7, 0.5, 0.02);
                return;
            }
        }
        else if (e.Is(EntityClass.Dolphin)) {
            if (id == 38) {
                ParticlesAroundSelf(e, Particle.HappyVillager, 7, 0.2, 0.01);
                return;
            }
        }
        else if (e.Is(EntityClass.Fox)) {
            if (id == 45) {
                FoxEat(e);
                return;
            }
        }
        else if (e.Is(EntityClass.Wolf)) {
            if (id == 8) {
                EntityEmitter wolf = EmitterOf(e);
                wolf.Flag = true;
                wolf.F = wolf.G = 0.0F;
                return;
            }
            if (id == 56) {
                EntityEmitter wolf = EmitterOf(e);
                wolf.Flag = false;
                wolf.F = wolf.G = 0.0F;
                return;
            }
        }
        else if (e.Is(EntityClass.Rabbit)) {
            if (id == 1) {
                SpawnSprintParticle(e);
                return;
            }
        }
        // TamableAnimal and AbstractHorse spawnTamingParticles; a wolf and a cat are tamable animals.
        if ((id is 6 or 7) && (e.Is(EntityClass.TamableAnimal) || e.Is(EntityClass.AbstractHorse))) {
            ParticlesAroundSelf(e, id == 7 ? Particle.Heart : Particle.Smoke, 7, 0.5, 0.02);
            return;
        }
        // Animal.handleEntityEvent: the hearts of falling in love.
        if (id == 18 && e.Is(EntityClass.Animal)) {
            ParticlesAroundSelf(e, Particle.Heart, 7, 0.5, 0.02);
            return;
        }
        // Mob.handleEntityEvent: spawnAnim.
        if (id == 20 && e.Is(EntityClass.Mob)) {
            MakePoofParticles(e);
            return;
        }
        switch (id) {
            case 46:
                ChorusTeleport(e);
                break;
            case 47 or 48 or 49 or 50 or 51 or 52 or 65 or 68:
                SpawnItemParticles(e, ItemBySlot(e, id switch {
                    47 => EquipmentSlot.MainHand,
                    48 => EquipmentSlot.OffHand,
                    49 => EquipmentSlot.Helmet,
                    50 => EquipmentSlot.Chestplate,
                    51 => EquipmentSlot.Leggings,
                    52 => EquipmentSlot.Boots,
                    65 => EquipmentSlot.Body,
                    _ => EquipmentSlot.Saddle
                }), 5);
                break;
            case 53:
                HoneyParticles(e, 5);
                break;
            case 54:
                HoneyParticles(e, 10);
                break;
            case 60:
                MakePoofParticles(e);
                break;
            case 67: {
                // makeDrownParticles: triangle(0, 1) on each axis.
                Vec3d movement = e.DeltaMovement;
                for (int i = 0; i < 8; i++) {
                    Add(Particle.Bubble, e.Position.X + (R.NextDouble() - R.NextDouble()), e.Position.Y + (R.NextDouble() - R.NextDouble()),
                        e.Position.Z + (R.NextDouble() - R.NextDouble()), movement.X, movement.Y, movement.Z);
                }
                break;
            }
        }
    }

    /// <summary>
    /// The shape <c>Animal</c>, <c>TamableAnimal</c>, <c>AbstractHorse</c>, <c>Ocelot</c>, <c>Allay</c>,
    /// <c>Dolphin</c> and <c>AbstractVillager</c> share: a few particles anywhere over the box, lifted a little,
    /// with a gaussian drift.
    /// </summary>
    private void ParticlesAroundSelf(ClientEntity e, IParticle particle, int count, double lift, double drift) {
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < count; i++) {
            double xa = R.NextGaussian() * drift, ya = R.NextGaussian() * drift, za = R.NextGaussian() * drift;
            Add(particle, RandomX(e, width, 1.0), RandomY(e, height) + lift, RandomZ(e, width, 1.0), xa, ya, za);
        }
    }

    /// <summary><c>LivingEntity.makePoofParticles</c>: the cloud a mob leaves when it dies or a spawner makes it.</summary>
    private void MakePoofParticles(ClientEntity e) {
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < 20; i++) {
            double xa = R.NextGaussian() * 0.02, ya = R.NextGaussian() * 0.02, za = R.NextGaussian() * 0.02;
            Add(Particle.Poof, RandomX(e, width, 1.0) - xa * 10.0, RandomY(e, height) - ya * 10.0, RandomZ(e, width, 1.0) - za * 10.0, xa, ya, za);
        }
    }

    /// <summary>Event 46, a chorus fruit or enderman teleport: portal motes along the way from where it was.</summary>
    private void ChorusTeleport(ClientEntity e) {
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < 128; i++) {
            double d = i / 127.0;
            float xa = (R.NextFloat() - 0.5F) * 0.2F, ya = (R.NextFloat() - 0.5F) * 0.2F, za = (R.NextFloat() - 0.5F) * 0.2F;
            double x = Lerp(d, e.OldPosition.X, e.Position.X) + (R.NextDouble() - 0.5) * width * 2.0;
            double y = Lerp(d, e.OldPosition.Y, e.Position.Y) + R.NextDouble() * height;
            double z = Lerp(d, e.OldPosition.Z, e.Position.Z) + (R.NextDouble() - 0.5) * width * 2.0;
            Add(Particle.Portal, x, y, z, xa, ya, za);
        }
    }

    /// <summary><c>HoneyBlock.showParticles</c>.</summary>
    private void HoneyParticles(ClientEntity e, int count) {
        for (int i = 0; i < count; i++) {
            Add(HoneyBlock, e.Position.X, e.Position.Y, e.Position.Z, 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>Arrow.handleEntityEvent(0)</c>: the potion bursting off an arrow that has sat in the ground long enough.</summary>
    private void ArrowPotionBurst(ClientEntity e) {
        int colour = e.Get(EntityDataFields.Arrow.IdEffectColor, -1);
        if (colour == -1) {
            return;
        }
        IParticle particle = Particle.EntityEffect with { Argb = colour | unchecked((int)0xFF000000) };
        (float width, float height) = e.Dimensions;
        for (int i = 0; i < 20; i++) {
            Add(particle, RandomX(e, width, 0.5), RandomY(e, height), RandomZ(e, width, 0.5), 0.0, 0.0, 0.0);
        }
    }

    /// <summary><c>Snowball</c> and <c>ThrownEgg.handleEntityEvent(3)</c>: crumbs of the thrown item where it broke.</summary>
    private void ThrowableBreak(ClientEntity e) {
        ItemStack item = e.Get(EntityDataFields.ThrowableItemProjectile.ItemStack) ?? ItemStack.Air;
        bool egg = e.Is(EntityClass.ThrownEgg);
        if (ItemComponents.IsEmpty(item)) {
            if (egg) {
                return;
            }
            for (int i = 0; i < 8; i++) {
                Add(Particle.ItemSnowball, e.Position.X, e.Position.Y, e.Position.Z, 0.0, 0.0, 0.0);
            }
            return;
        }
        IParticle particle = Particle.Item with { Item = item };
        for (int i = 0; i < 8; i++) {
            if (egg) {
                Add(particle, e.Position.X, e.Position.Y, e.Position.Z, (R.NextFloat() - 0.5) * 0.08, (R.NextFloat() - 0.5) * 0.08, (R.NextFloat() - 0.5) * 0.08);
            }
            else {
                Add(particle, e.Position.X, e.Position.Y, e.Position.Z, 0.0, 0.0, 0.0);
            }
        }
    }

    /// <summary><c>Fox.handleEntityEvent(45)</c>: crumbs of what it holds in its mouth.</summary>
    private void FoxEat(ClientEntity e) {
        ItemStack mouthItem = e.GetItemBySlot(EquipmentSlot.MainHand);
        if (ItemComponents.IsEmpty(mouthItem)) {
            return;
        }
        IParticle particle = Particle.Item with { Item = mouthItem };
        float xRot = -e.XRot * (MathF.PI / 180.0F), yRot = -e.YRot * (MathF.PI / 180.0F);
        Vec3d look = ViewVector(e.XRot, e.YRot);
        for (int i = 0; i < 8; i++) {
            Vec3d direction = new((R.NextFloat() - 0.5) * 0.1, R.NextFloat() * 0.1 + 0.1, 0.0);
            direction = ClientEntity.YRotate(ClientEntity.XRotate(direction, xRot), yRot);
            Add(particle, e.Position.X + look.X / 2.0, e.Position.Y, e.Position.Z + look.Z / 2.0, direction.X, direction.Y + 0.05, direction.Z);
        }
    }

    /// <summary>
    /// <c>getItemBySlot</c>. The server never sends the local player its own equipment: its hands and armour
    /// are its inventory, at <c>Inventory.EQUIPMENT_SLOT_MAPPING</c>.
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
                return _client.Inventory.Get(index).ToItemStack();
            }
        }
        return entity.GetItemBySlot(slot);
    }
}
