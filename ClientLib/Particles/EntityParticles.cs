using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Data.Particles;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Items;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.Particles;

/// <summary>
/// The particles entities make on the client: what every entity's <c>baseTick</c> and <c>LivingEntity.tick</c>
/// spawn (the splash into water, sprinting, effect swirls, eating), what each class's client tick adds, the
/// <c>handleEntityEvent</c> overrides, and the firework starters. Vanilla's classes say what spawns, where and
/// how often; the draws come from <see cref="ParticleEngine.Random"/>, which nothing a server sees reads.
/// <p/>
/// Runs at the start of the particle engine's tick, after the entities have ticked, which is where vanilla's
/// entity ticks leave their particles. An entity further than the engine's cut off from the camera skips the
/// work every entity does, as none of what it would make could be seen.
/// </summary>
public sealed partial class EntityParticles {
    /// <summary>The engine's 32 block cut off, plus room for the widest entity that runs the shared work.</summary>
    private const double NearSqr = 36.0 * 36.0;

    private readonly MinecraftClient _client;
    private readonly ParticleEngine _engine;
    /// <summary>The level of the engine's last tick, which its block lookups read.</summary>
    private ClientLevel? _level;

    internal EntityParticles(MinecraftClient client, ParticleEngine engine) {
        _client = client;
        _engine = engine;
        client.PacketReceived += Handle;
    }

    private ParticleRandom R => _engine.Random;

    private void Add(IParticle options, double x, double y, double z, double xd, double yd, double zd) =>
        _engine.AddParticle(options, x, y, z, xd, yd, zd);

    /// <summary>Called by the engine's tick once it is ready, before any particle moves.</summary>
    internal void Tick(ClientLevel level) {
        if (!ReferenceEquals(level, _level)) {
            _fireworks.Clear();
        }
        _level = level;
        TickFireworks();
        Vec3d camera = _engine.CameraPosition ?? (_client.Player is { } player ? player.Position.Add(0, player.EyeHeight, 0) : Vec3d.Zero);
        foreach (ClientEntity entity in _client.Entities.Values) {
            if (entity.IsRemoved || level.TickRateManager.IsEntityFrozen(entity)) {
                continue;
            }
            EntityEmitter emitter = entity.Emitter ??= new EntityEmitter(Classify(entity), entity.IsLiving);
            if (emitter.Kind == EmitterKind.NoBaseTick) {
                continue;
            }
            if (entity.Position.DistanceToSqr(camera) <= NearSqr) {
                TickShared(entity, emitter);
            }
            else {
                emitter.InWater = -1;
            }
            if (emitter.Kind != EmitterKind.Plain) {
                TickKind(entity, emitter);
            }
        }
    }

    private void Handle(MinecraftPacket packet) {
        if (!_engine.Enabled || _client.Level is not { } level || !ReferenceEquals(level, _level)) {
            return;
        }
        switch (packet) {
            case ClientBoundEntityEventPacket entityEvent when _client.Entities.TryGetValue(entityEvent.EntityId, out ClientEntity? entity):
                HandleEntityEvent(entity, (byte)entityEvent.Status);
                break;
            case ClientBoundSpawnEntityPacket spawn when spawn.EntityType.Identifier == EntityType.LlamaSpit.Identifier:
                // LlamaSpit.recreateFromPacket.
                for (int i = 0; i < 7; i++) {
                    double k = 0.4 + 0.1 * i;
                    Add(Particle.Spit, spawn.Position.X, spawn.Position.Y, spawn.Position.Z, spawn.Velocity.X * k, spawn.Velocity.Y, spawn.Velocity.Z * k);
                }
                break;
            case ClientBoundRemoveEntitiesPacket remove:
                foreach (int id in remove.Entities) {
                    if (_client.Entities.TryGetValue(id, out ClientEntity? removed) && removed.Is(EntityClass.ThrownEnderpearl)) {
                        EnderPearlHit(removed);
                    }
                }
                break;
        }
    }

    /// <summary>
    /// <c>ThrownEnderpearl.onHit</c>'s portal burst. Vanilla's client finds the hit with its own copy of the
    /// pearl's flight; this one does not fly the pearl, so it bursts where the server removes it, which is the
    /// same place unless the pearl left tracking range instead, where nothing would be seen anyway.
    /// </summary>
    private void EnderPearlHit(ClientEntity pearl) {
        for (int i = 0; i < 32; i++) {
            Add(Particle.Portal, pearl.Position.X, pearl.Position.Y + R.NextDouble() * 2.0, pearl.Position.Z, R.NextGaussian(), 0.0, R.NextGaussian());
        }
    }

    /// <summary><c>AbstractBoat.onAboveBubbleColumn</c>'s odd splash over the column, once in a hundred ticks.</summary>
    internal void BoatAboveBubbleColumn(ClientEntity boat) {
        if (_engine.Enabled && R.NextInt(100) == 0) {
            Add(Particle.Splash, boat.Position.X + R.NextFloat(), boat.Position.Y + 0.7, boat.Position.Z + R.NextFloat(), 0.0, 0.0, 0.0);
        }
    }

    #region What every entity does

    private void TickShared(ClientEntity entity, EntityEmitter emitter) {
        bool inWater, inLava;
        switch (entity) {
            case LocalPlayer player:
                inWater = player.IsInWater;
                inLava = player.IsInLava;
                break;
            // A vehicle nobody here steers only interpolates, and keeps no fluid state of its own.
            case SimulatedEntity or PhysicsEntity { IsLocalInstanceAuthoritative: true }:
                inWater = ((PhysicsEntity)entity).IsInWater;
                inLava = ((PhysicsEntity)entity).IsInLava;
                break;
            default:
                (inWater, inLava) = FluidsAt(entity, emitter);
                break;
        }
        // AbstractBoat.modifyPassengerFluidInteractionBox: a rider sits above the water the hull keeps out.
        if (inWater && entity.Vehicle is Entities.Vehicles.ClientBoat { IsUnderWater: false }) {
            inWater = false;
        }
        if (inWater && emitter.InWater == 0 && entity is not LocalPlayer { IsSpectator: true }) {
            DoWaterSplashEffect(entity);
        }
        emitter.InWater = (sbyte)(inWater ? 1 : 0);
        if (CanSpawnSprintParticle(entity, emitter, inWater, inLava)) {
            SpawnSprintParticle(entity);
        }
        if (emitter.Living) {
            TickEffects(entity);
            if (entity is not LocalPlayer) {
                TickItemUse(entity, emitter);
            }
        }
    }

    /// <summary>
    /// <c>Entity.isInWater</c> and <c>isInLava</c> for an entity whose client copy runs no fluid check of its own.
    /// Only the column under its middle is looked at, over the bottom block or two of its box: an entity
    /// half over the edge of a pool reads as dry until its middle crosses, a tick or two after vanilla's whole
    /// box check would. One that has not moved keeps last tick's answer, so water flowing in around a still
    /// entity is not noticed until it moves.
    /// </summary>
    private (bool Water, bool Lava) FluidsAt(ClientEntity entity, EntityEmitter emitter) {
        if (emitter.InWater >= 0 && entity.Position == emitter.CheckedAt) {
            return (emitter.InWater == 1, emitter.InLava);
        }
        emitter.CheckedAt = entity.Position;
        double minY = entity.Position.Y + 0.001;
        double maxY = entity.Position.Y + Math.Max(entity.Height - 0.001, 0.001);
        int x = (int)Math.Floor(entity.Position.X), z = (int)Math.Floor(entity.Position.Z);
        int y0 = (int)Math.Floor(minY), y1 = Math.Min((int)Math.Floor(maxY), y0 + 1);
        bool water = false, lava = false;
        for (int y = y0; y <= y1; y++) {
            // Plain air, the usual answer, without looking the block up.
            if (_engine.StateAt(x, y, z) == 0) {
                continue;
            }
            (byte fluid, float height) = _engine.FluidAt(x, y, z);
            if (fluid != 0 && y + height >= minY) {
                water |= fluid == ParticleEngine.FluidWater;
                lava |= fluid == ParticleEngine.FluidLava;
            }
        }
        emitter.InLava = lava;
        return (water, lava);
    }

    /// <summary><c>Entity.doWaterSplashEffect</c>: a ring of bubbles and splashes at the surface, thrown with the mover.</summary>
    private void DoWaterSplashEffect(ClientEntity entity) {
        Vec3d movement = (entity.ControllingPassenger ?? entity).DeltaMovement;
        float width = entity.Dimensions.Width;
        float yt = Mth.Floor(entity.Position.Y);
        int count = (int)Math.Ceiling(1.0F + width * 20.0F);
        for (int i = 0; i < count; i++) {
            double xo = (R.NextDouble() * 2.0 - 1.0) * width;
            double zo = (R.NextDouble() * 2.0 - 1.0) * width;
            Add(Particle.Bubble, entity.Position.X + xo, yt + 1.0F, entity.Position.Z + zo, movement.X, movement.Y - R.NextDouble() * 0.2F, movement.Z);
        }
        for (int i = 0; i < count; i++) {
            double xo = (R.NextDouble() * 2.0 - 1.0) * width;
            double zo = (R.NextDouble() * 2.0 - 1.0) * width;
            Add(Particle.Splash, entity.Position.X + xo, yt + 1.0F, entity.Position.Z + zo, movement.X, movement.Y, movement.Z);
        }
    }

    /// <summary><c>Entity.canSpawnSprintParticle</c> and the iron golem's and rabbit's overrides.</summary>
    private bool CanSpawnSprintParticle(ClientEntity entity, EntityEmitter emitter, bool inWater, bool inLava) {
        switch (emitter.Kind) {
            case EmitterKind.IronGolem:
                return entity.DeltaMovement.HorizontalDistanceSqr() > 2.5000003E-7F && R.NextInt(5) == 0;
            case EmitterKind.Rabbit:
                return false;
        }
        return (entity.SharedFlags & 0x08) != 0 && !inWater && !inLava && !entity.IsCrouching && IsAlive(entity)
            && !EntityCollisions.IsSpectator(_client, entity);
    }

    /// <summary>
    /// <c>Entity.spawnSprintParticle</c>: a chip of the block underfoot kicked back. The block is the one 0.2
    /// under the feet, without <c>getOnPosLegacy</c>'s preference for the block the entity is supported by, which
    /// only differs at an edge.
    /// </summary>
    private void SpawnSprintParticle(ClientEntity entity) {
        int x = (int)Math.Floor(entity.Position.X), y = (int)Math.Floor(entity.Position.Y - 0.2F), z = (int)Math.Floor(entity.Position.Z);
        IBlock block = _level!.Registry.Blocks.GetByStateId(_engine.StateAt(x, y, z));
        // RenderShape.INVISIBLE: air and fluids; the provider refuses the rest that make no terrain particles.
        if (block.Air || block.Liquid) {
            return;
        }
        Vec3d movement = entity.DeltaMovement;
        float width = entity.Dimensions.Width;
        double px = entity.Position.X + (R.NextDouble() - 0.5) * width;
        double pz = entity.Position.Z + (R.NextDouble() - 0.5) * width;
        Add(Particle.Block with { BlockState = block }, px, entity.Position.Y + 0.1, pz, movement.X * -4.0, 1.5, movement.Z * -4.0);
    }

    /// <summary><c>LivingEntity.tickEffects</c> on the client: now and then one of the synced effect particles, rarer when ambient or invisible.</summary>
    private void TickEffects(ClientEntity entity) {
        IParticle[]? particles = entity.Get(EntityDataFields.LivingEntity.EffectParticles);
        if (particles is not { Length: > 0 }) {
            return;
        }
        int bound = entity.IsInvisible ? 15 : 4;
        int ambientFactor = entity.Get(EntityDataFields.LivingEntity.EffectAmbience) ? 5 : 1;
        if (R.NextInt(bound * ambientFactor) != 0) {
            return;
        }
        (float width, float height) = entity.Dimensions;
        Add(particles[R.NextInt(particles.Length)], RandomX(entity, width, 0.5), RandomY(entity, height), RandomZ(entity, width, 0.5), 1.0, 1.0, 1.0);
    }

    /// <summary>
    /// <c>LivingEntity.updatingUsingItem</c>'s <c>onUseTick</c> for an entity another client steers: the use
    /// starts when its living flags say so, as <c>onSyncedDataUpdated</c> starts it, and counts down from the
    /// consumable's duration. The local player's is <see cref="SpawnItemParticles"/>, from whoever plays its sounds.
    /// </summary>
    private void TickItemUse(ClientEntity entity, EntityEmitter emitter) {
        sbyte flags = entity.Get(EntityDataFields.LivingEntity.LivingEntityFlags);
        if ((flags & 1) == 0) {
            emitter.UseItem = null;
            return;
        }
        ItemStack inHand = entity.ItemInHand((flags & 2) != 0 ? Hand.OffHand : Hand.MainHand);
        if (emitter.UseItem == null) {
            if (ItemComponents.IsEmpty(inHand)) {
                return;
            }
            emitter.UseItem = inHand;
            emitter.UseRemaining = ItemComponents.Get(inHand, DataComponent.Consumable) is { } started ? (int)(started.ConsumeSeconds * 20.0F) : 0;
        }
        else if (!inHand.Type.Identifier.Equals(emitter.UseItem.Type.Identifier)) {
            emitter.UseItem = null;
            return;
        }
        if (ItemComponents.Get(inHand, DataComponent.Consumable) is { HasParticles: true } consumable && ShouldEmitParticlesAndSounds(consumable, emitter.UseRemaining)) {
            SpawnItemParticles(entity, inHand, 5);
        }
        emitter.UseRemaining--;
    }

    /// <summary><c>Consumable.shouldEmitParticlesAndSounds</c>.</summary>
    public static bool ShouldEmitParticlesAndSounds(ConsumableComponent.Data consumable, int useItemRemainingTicks) {
        int consumeTicks = (int)(consumable.ConsumeSeconds * 20.0F);
        int itemUsedForTicks = consumeTicks - useItemRemainingTicks;
        int waitTicksBeforeUseEffects = (int)(consumeTicks * 0.21875F);
        return itemUsedForTicks > waitTicksBeforeUseEffects && useItemRemainingTicks % 4 == 0;
    }

    /// <summary><c>LivingEntity.spawnItemParticles</c>: crumbs of the item falling from in front of the mouth.</summary>
    public void SpawnItemParticles(ClientEntity entity, ItemStack itemStack, int count) {
        if (!_engine.Enabled || ItemComponents.IsEmpty(itemStack)) {
            return;
        }
        IParticle particle = Particle.Item with { Item = itemStack };
        float xRot = -entity.XRot * (MathF.PI / 180.0F), yRot = -entity.YRot * (MathF.PI / 180.0F);
        double eyeY = entity.Position.Y + entity.CurrentEyeHeight;
        for (int i = 0; i < count; i++) {
            Vec3d d = new((R.NextFloat() - 0.5) * 0.1, R.NextFloat() * 0.1 + 0.1, 0.0);
            d = ClientEntity.YRotate(ClientEntity.XRotate(d, xRot), yRot);
            double y1 = -R.NextFloat() * 0.6 - 0.3;
            Vec3d p = new((R.NextFloat() - 0.5) * 0.3, y1, 0.6);
            p = ClientEntity.YRotate(ClientEntity.XRotate(p, xRot), yRot);
            Add(particle, p.X + entity.Position.X, p.Y + eyeY, p.Z + entity.Position.Z, d.X, d.Y + 0.05, d.Z);
        }
    }

    #endregion

    #region Helpers

    private static bool IsAlive(ClientEntity entity) => !entity.IsRemoved && (!entity.IsLiving || entity.CurrentHealth > 0.0F);

    /// <summary><c>Entity.getRandomX</c>.</summary>
    private double RandomX(ClientEntity entity, float width, double scale) => entity.Position.X + (2.0 * R.NextDouble() - 1.0) * width * scale;

    /// <summary><c>Entity.getRandomY</c>.</summary>
    private double RandomY(ClientEntity entity, float height) => entity.Position.Y + height * R.NextDouble();

    /// <summary><c>Entity.getRandomZ</c>.</summary>
    private double RandomZ(ClientEntity entity, float width, double scale) => entity.Position.Z + (2.0 * R.NextDouble() - 1.0) * width * scale;

    /// <summary><c>Entity.calculateViewVector</c>.</summary>
    private static Vec3d ViewVector(float xRot, float yRot) {
        float realXRot = xRot * (MathF.PI / 180.0F);
        float realYRot = -yRot * (MathF.PI / 180.0F);
        float yCos = Mth.Cos(realYRot), ySin = Mth.Sin(realYRot);
        float xCos = Mth.Cos(realXRot), xSin = Mth.Sin(realXRot);
        return new Vec3d(ySin * xCos, -xSin, yCos * xCos);
    }

    /// <summary><c>LivingEntity.getScale</c>: the scale attribute, halved for a baby.</summary>
    private static float Scale(ClientEntity entity) =>
        (float)entity.Attributes.Value(Minecraft.Data.Generated.Attribute.Scale) * (entity.IsBaby ? 0.5F : 1.0F);

    /// <summary>The block state at a position, through the engine's chunk cache.</summary>
    private IBlock BlockAt(int x, int y, int z) => _level!.Registry.Blocks.GetByStateId(_engine.StateAt(x, y, z));

    /// <summary><c>getBlockStateOn</c>: the block just under the feet.</summary>
    private IBlock BlockStateOn(ClientEntity entity) =>
        BlockAt((int)Math.Floor(entity.Position.X), (int)Math.Floor(entity.Position.Y - 1.0E-5F), (int)Math.Floor(entity.Position.Z));

    /// <summary><c>getRenderShape() != INVISIBLE</c>, as near as the block data says: not air and not a fluid's own block.</summary>
    private static bool Visible(IBlock block) => !block.Air && !block.Liquid;

    #endregion
}

/// <summary>Which client tick of its own an entity runs, worked out once from its class.</summary>
internal enum EmitterKind : byte {
    /// <summary>Only what every entity does.</summary>
    Plain,

    /// <summary>A class whose tick never reaches <c>baseTick</c>: displays, markers, interactions, hanging and falling blocks.</summary>
    NoBaseTick,
    Blaze, EnderMan, Endermite, Guardian, Phantom, Ravager, Breeze, CubeMob, Illusioner, Spellcaster, Warden, EnderDragon, Wither,
    Bee, Dolphin, GlowSquid, Nautilus, Panda, Sniffer, Wolf, IronGolem, Rabbit,
    Arrow, SpectralArrow, AbstractArrow, SmokingProjectile, DragonFireball, WindCharge, Throwable, ShulkerBullet, EyeOfEnder,
    FireworkRocket, PrimedTnt, MinecartTnt, MinecartFurnace, AreaEffectCloud, OminousItemSpawner, EvokerFangs
}

/// <summary>What <see cref="EntityParticles"/> keeps for one entity: the fields its vanilla class keeps on the client.</summary>
internal sealed class EntityEmitter(EmitterKind kind, bool living) {
    public readonly EmitterKind Kind = kind;
    public readonly bool Living = living;

    /// <summary><c>wasTouchingWater</c>: -1 until known, so an entity first seen in water does not splash.</summary>
    public sbyte InWater = -1;
    public bool InLava;
    public Vec3d CheckedAt;

    /// <summary>Counters and timers of the class's own: a fuse, a stun, an animation's start tick.</summary>
    public int A, B, C;
    public float F, G;
    public bool Flag;

    public ItemStack? UseItem;
    public int UseRemaining;
}
