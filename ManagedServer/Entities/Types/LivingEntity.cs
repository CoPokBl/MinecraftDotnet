using ManagedServer.Damage;
using ManagedServer.Events;
using ManagedServer.Features.Basic;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace ManagedServer.Entities.Types;

public class LivingEntity(IEntityType type, LivingEntityMeta? meta = null) 
    : Entity(type, meta ?? new LivingEntityMeta()) {
    public float Health {
        get;
        set {
            field = value;

            // Anything that puts health back on the entity puts it back in the running to die again.
            if (value > 0) {
                IsDead = false;
            }

            Meta = Meta with {
                Health = value
            };
            SendHealthUpdate();
        }
    } = 20f;

    /// <summary>
    /// Whether the entity is out of health and its death has already been announced as an
    /// <see cref="EntityDeathEvent"/>. Healing it above zero clears this, which is what lets it die
    /// again; a death that was cancelled leaves it set, so the same zero is not announced every tick.
    /// <p/>
    /// <see cref="DeathFeature"/> is what sets it. With that feature not registered nothing does, and
    /// running out of health does nothing on its own.
    /// </summary>
    public bool IsDead { get; set; }

    public int Food {
        get;
        set {
            field = value;
            SendHealthUpdate();
        }
    } = 20;

    public float Saturation {
        get;
        set {
            field = value;
            SendHealthUpdate();
        }
    } = 20f;

    private Dictionary<EquipmentSlot, ItemStack> _equipment = [];
    
    public new LivingEntityMeta Meta {
        get => (LivingEntityMeta)base.Meta;
        set => base.Meta = value;
    }

    /// <summary>
    /// The status effects on this entity. Holding them is all that happens here; what any of them
    /// does is a feature, and <see cref="EffectsFeature"/> is what counts their durations down.
    /// </summary>
    public EntityEffects Effects => field ??= new EntityEffects(this);

    /// <summary>The arm swing in progress, <c>LivingEntity.swingState</c>.</summary>
    public SwingState SwingState { get; } = new();

    /// <summary>
    /// <c>LivingEntity.swing</c>: start a swing and show it to the viewers, and to this entity's own
    /// client when <paramref name="sendToSelf"/>. Refused, sending nothing, while the current swing is
    /// in its first half.
    /// </summary>
    public bool Swing(Hand hand, SwingAnimation animation, bool sendToSelf) {
        int duration = SwingState.ModifiedDuration(animation, Effects.AmplifierOf(PotionEffectType.Haste),
            Effects.AmplifierOf(PotionEffectType.ConduitPower), Effects.AmplifierOf(PotionEffectType.MiningFatigue));
        if (!SwingState.StartIfAble(hand, animation, duration)) {
            return false;
        }

        ClientBoundSwingAnimationPacket packet = new() {
            EntityId = NetId,
            Hand = hand,
            Animation = animation
        };
        if (sendToSelf) {
            SendToSelfAndViewers(packet);
        }
        else {
            SendToViewers(packet);
        }

        return true;
    }

    /// <summary><c>LivingEntity.baseTick</c> ticks the swing first.</summary>
    protected override void Tick() {
        base.Tick();
        SwingState.Tick();
    }

    /// <summary>
    /// The absorption hearts a hit eats before it reaches <see cref="Health"/>, vanilla's
    /// <c>getAbsorptionAmount</c>. Nothing grants any on its own; it is here because the
    /// <see cref="DamageStage.Absorption"/> stage of the pipeline is what spends it.
    /// </summary>
    public float Absorption {
        get;
        set => field = Math.Max(0, value);
    }

    /// <summary>
    /// How long a hit stops the next one from landing, vanilla's <c>damageCooldownTime</c>. Set to zero
    /// to turn the window off, which is what a minigame wanting every hit to count does.
    /// <p/>
    /// Ten rather than twenty because that is what vanilla's is worth: <c>LivingEntity.hurtServer</c>
    /// sets <c>damageCooldownTime</c> to twenty but only throws a hit away while it is <b>above ten</b>,
    /// and it drops by one a tick.
    /// </summary>
    public int InvulnerableTicks { get; set; } = 10;

    #region movement_input

    /// <summary>
    /// Vanilla's <c>xxa</c>, <c>yya</c> and <c>zza</c>: the entity's own movement input for the tick,
    /// as strafe, upward and forward, normally in [-1, 1]. <c>LivingEntity.travel</c> turns them into
    /// velocity through <see cref="Speed"/>, so an entity that leaves them at zero moves only on
    /// whatever velocity something else gave it, which is what every entity here did before mob AI
    /// existed.
    /// <p/>
    /// Public fields rather than properties because vanilla's are, and because the controls write
    /// them every tick.
    /// </summary>
    public float Xxa, Yya, Zza;

    /// <summary>
    /// Vanilla's <c>speed</c> field, <c>getSpeed</c>/<c>setSpeed</c>: what the movement input is
    /// scaled by. It is not <c>minecraft:movement_speed</c>; a mob's move control writes this each
    /// tick as the attribute times the goal's speed modifier.
    /// <p/>
    /// Virtual because <see cref="Mob"/> overrides <c>setSpeed</c> to write <see cref="Zza"/> as well,
    /// which is the only thing that makes a mob walk: the move control never touches the forward input
    /// itself.
    /// </summary>
    public virtual float Speed { get; set; }

    /// <summary>
    /// Vanilla's <c>jumping</c>. Set it and the next tick on the ground spends it on a jump; it is
    /// what a jump control drives, and it is not itself the jump.
    /// </summary>
    public bool Jumping { get; set; }

    /// <summary>Vanilla's <c>noJumpDelay</c>: ten ticks of cooldown after a jump from the ground.</summary>
    public int NoJumpDelay { get; set; }

    /// <summary>
    /// <c>LivingEntity.getFlyingSpeed</c>: what scales the input when the entity is off the ground.
    /// A mob being ridden by a player uses the rider's speed, everything else takes the constant.
    /// </summary>
    public virtual float FlyingSpeed => 0.02f;

    /// <summary>
    /// <c>LivingEntity.isImmobile</c>, which in 26.2 is exactly <c>isDeadOrDying</c>. An immobile
    /// entity has its input and its jump thrown away before they are spent.
    /// </summary>
    public virtual bool IsImmobile => IsDead || Health <= 0f;

    /// <summary>
    /// Whether the entity is in the world and still has health, vanilla's <c>isAlive</c>. Despawning
    /// only nulls <see cref="Entity.World"/>, so anything holding on to an entity across ticks (a
    /// mob's target, a goal's cached entity) has to ask this rather than assume.
    /// </summary>
    public bool IsAlive => World != null && !IsDead && Health > 0f;

    #endregion

    #region last_attacker

    /// <summary>
    /// Who last hurt this entity, vanilla's <c>getLastHurtByMob</c>. It is what revenge targeting is
    /// built on: <c>HurtByTargetGoal</c> reads nothing else.
    /// <p/>
    /// Vanilla holds an <c>EntityReference</c> and resolves it against the level on every read, so an
    /// attacker that left the world reads as null without anything having to clear it. Reading through
    /// the same check here means a goal cannot end up chasing a despawned entity, and it also means
    /// the reference does not keep one alive.
    /// <p/>
    /// Setting it stamps <see cref="LastHurtByMobTimestamp"/>, as <c>setLastHurtByMob</c> does.
    /// </summary>
    public LivingEntity? LastHurtByMob {
        get => field?.World == World ? field : null;

        set {
            field = value;
            LastHurtByMobTimestamp = TickCount;
        }
    }

    /// <summary>
    /// The value <see cref="Entity.TickCount"/> had when <see cref="LastHurtByMob"/> was last written,
    /// vanilla's <c>lastHurtByMobTimestamp</c>.
    /// <p/>
    /// There is no decay on it, which is worth knowing before writing anything against it: a mob
    /// remembers its last attacker for as long as that attacker is loaded. What stops
    /// <c>HurtByTargetGoal</c> re-triggering forever is that the goal keeps its own copy of this and
    /// only fires when the two differ, so the number is a "has it happened again" marker rather than
    /// an age.
    /// </summary>
    public int LastHurtByMobTimestamp { get; private set; }

    /// <summary>
    /// How many ticks the entity has gone without doing anything, vanilla's <c>noActionTime</c>. A hit
    /// resets it and a mob's AI step counts it up; vanilla despawns on it and uses it to decide a mob
    /// is idle enough to stop being simulated in detail.
    /// </summary>
    public int NoActionTime { get; set; }

    /// <summary>
    /// <c>LivingEntity.resolveMobResponsibleForDamage</c>: remember the attacker, unless the damage
    /// type says not to be angered by it. The wind charge carve out is vanilla's, and it is per victim
    /// rather than per damage type: the mobs a breeze is meant to fling around without starting a
    /// fight are the ones in <c>minecraft:no_anger_from_wind_charge</c>.
    /// </summary>
    private void ResolveMobResponsibleForDamage(World world, DamageSource source) {
        if (source.Attacker is not LivingEntity attacker
            || source.IsIn(world.Server.Registry, DamageTypeTags.NoAnger)) {
            return;
        }

        if (source.Type.Identifier.Equals(DamageType.WindCharge.Identifier)
            && world.Server.Registry.EntityTypes.Tags.Contains(world.Server.Registry,
                EntityTypeTags.NoAngerFromWindCharge, Type.Identifier)) {
            return;
        }

        LastHurtByMob = attacker;
    }

    #endregion

    #region attacking

    /// <summary>
    /// Whether this entity is allowed to fight <paramref name="target"/> at all,
    /// <c>LivingEntity.canAttack</c>. Vanilla also refuses to attack a player on peaceful difficulty;
    /// there is no difficulty setting here, so only the <c>canBeSeenAsEnemy</c> half is ported.
    /// </summary>
    public virtual bool CanAttack(LivingEntity target) {
        return target.CanBeSeenAsEnemy;
    }

    /// <summary>
    /// <c>LivingEntity.canBeSeenAsEnemy</c>: alive and not invulnerable. A creative or spectating
    /// player is what <see cref="Player"/> overrides this for.
    /// </summary>
    public virtual bool CanBeSeenAsEnemy => IsAlive;

    /// <summary>
    /// Shoves the entity away from a hit, <c>LivingEntity.knockback</c>. The direction is given as an
    /// unnormalised x/z pair, which is why the loop below can be entered: two attackers standing in
    /// exactly the same place would otherwise produce a zero vector, so vanilla jitters it rather than
    /// dividing by zero.
    /// <p/>
    /// The existing velocity is <b>halved</b> rather than replaced, and the upward part is capped at
    /// 0.4 only when the entity is on the ground, so a hit taken mid air does not lift anything.
    /// </summary>
    public void Knockback(double power, double xd, double zd) {
        power *= 1.0 - GetAttributeValue(Attribute.KnockbackResistance);

        if (power <= 0.0) {
            return;
        }

        // Vanilla compares against a float literal widened to double, which is what 1.0E-5F is here.
        while (xd * xd + zd * zd < 1.0E-5f) {
            xd = (Random.NextDouble() - Random.NextDouble()) * 0.01;
            zd = (Random.NextDouble() - Random.NextDouble()) * 0.01;
        }

        Vec3<double> current = Velocity;
        double length = Math.Sqrt(xd * xd + zd * zd);
        double pushX = xd / length * power;
        double pushZ = zd / length * power;

        Velocity = new Vec3<double>(
            current.X / 2.0 - pushX,
            OnGround ? Math.Min(0.4, current.Y / 2.0 + power) : current.Y,
            current.Z / 2.0 - pushZ);
    }

    #endregion

    /// <summary>The tick the last hit landed on, or null if nothing has hit this entity yet.</summary>
    private ulong? _lastHurtTick;

    /// <summary>
    /// Vanilla's <c>lastHurt</c>: what the last hit was worth before reductions. A hit inside the
    /// invulnerable window is measured against it rather than thrown away outright.
    /// </summary>
    private float _lastHurtAmount;

    /// <summary>
    /// Hurts the entity for <c>minecraft:generic</c> damage. The overload taking a
    /// <see cref="DamageSource"/> is the one to prefer; a damage type is what decides which
    /// reductions apply and what the client plays, and generic bypasses none of them.
    /// </summary>
    public bool Damage(float damage) {
        return Damage(new DamageSource(DamageType.Generic), damage);
    }

    /// <summary>
    /// Hurts the entity, a port of <c>LivingEntity.hurtServer</c> and <c>actuallyHurt</c>. Returns
    /// whether the hit landed, which is false for one thrown away by the invulnerable window,
    /// cancelled through <see cref="EntityDamageEvent"/>, or stopped whole by a shield. A hit that
    /// landed for zero because armour soaked all of it still returns true, as vanilla's does.
    /// <p/>
    /// Everything a hit is reduced by lives in <see cref="ManagedMinecraftServer.DamagePipeline"/>
    /// and is put there by features, so a server that registers none of them deals whole hits.
    /// </summary>
    public bool Damage(DamageSource source, float amount) {
        World world = World.ThrowIfNull();

        // A dead entity takes no more hits, which is what stops the blow that killed it being counted
        // again while DeathFeature still has the death to announce.
        if (IsDead || Health <= 0) {
            return false;
        }

        // Being hit counts as doing something, and vanilla clears this before anything can throw the
        // hit away, so even a hit the invulnerable window eats keeps a mob from looking idle.
        NoActionTime = 0;

        if (amount < 0) {
            amount = 0;
        }

        // Vanilla clamps rather than rejects, so an infinite hit is a very large one. NaN survives the
        // check above, since every comparison against it is false.
        if (float.IsNaN(amount) || float.IsInfinity(amount)) {
            amount = float.MaxValue;
        }

        // What a raised shield stops, vanilla's applyItemBlocking. Ahead of both the window and the
        // event on purpose: the window is judged on what is left after a block, and a hit either of
        // them throws away has still been blocked, which is what makes an axe swing into a shield cost
        // the shield rather than nothing.
        DamagePipeline.BlockOutcome blocking = world.Server.DamagePipeline.ApplyBlocking(this, source, amount);
        amount -= blocking.Blocked;

        // The invulnerable window. Counting from the tick the last hit landed on says the same thing
        // as vanilla's per tick countdown without needing anything to tick it.
        bool fresh = true;
        float dealt = amount;
        if (_lastHurtTick is { } last
            && world.Server.CurrentTick - last < (ulong)InvulnerableTicks
            && !source.IsIn(world.Server.Registry, DamageTypeTags.BypassesCooldown)) {
            // A harder hit inside the window still lands, but only for the difference. A softer one is
            // thrown away, which is what stops a mob being chipped to death through its own iframes.
            if (amount <= _lastHurtAmount) {
                return false;
            }

            dealt = amount - _lastHurtAmount;
            fresh = false;
        }

        EntityDamageEvent damageEvent = new() {
            LivingEntity = this,
            Source = source,
            Amount = dealt,
            World = world
        };
        world.Events.CallEvent(damageEvent);

        // Cancelled before anything was written, so a cancelled hit leaves no window behind and the
        // next one is judged as if this had never happened.
        if (damageEvent.Cancelled) {
            return false;
        }

        _lastHurtAmount = amount;
        if (fresh) {
            _lastHurtTick = world.Server.CurrentTick;
        }

        float final = world.Server.DamagePipeline.Apply(this, source, damageEvent.Amount);
        Health = Math.Max(0, Health - final);

        // Vanilla resolves the attacker after actuallyHurt, on both the fresh and the difference path
        // but on neither early return, so a hit the window threw away leaves nothing to retaliate
        // against. Keeping the position matters: a goal reading this on the same tick sees the hit
        // that landed, not the one that did not.
        ResolveMobResponsibleForDamage(world, source);

        // What makes a hit look like one: the client's handleDamageEvent is the red flash, the camera
        // tilt and the damage type's hurt sound. Vanilla broadcasts it whatever the damage came out
        // as, so a hit armour soaked entirely still flashes, but not on the difference path above,
        // where the client is already flashing from the hit being topped up.
        // A blocked hit is the other exception: vanilla plays the blocking item's own sound instead of
        // this, so both live behind the same tookFullDamage check it does.
        if (fresh) {
            if (blocking.Blocked > 0) {
                blocking.ReportBlocked(this, source);
            }
            else {
                SendToSelfAndViewers(new ClientBoundDamageEventPacket {
                    EntityId = NetId,
                    SourceType = source.Type,
                    SourceCauseId = source.Attacker?.NetId,
                    SourceDirectId = source.Direct?.NetId,
                    SourcePosition = source.Position
                });
            }
        }

        // Vanilla's `success`, which is what hurtServer returns: a hit a shield ate whole did not
        // happen, so nothing gets to react to it.
        bool landed = blocking.Blocked <= 0 || amount > 0;
        if (landed) {
            world.Events.CallEvent(new EntityDamagedEvent {
                LivingEntity = this,
                Source = source,
                Amount = final,
                World = world
            });
        }

        return landed;
    }

    /// <summary>
    /// <c>LivingEntity.getJumpBoostPower</c>: what jump boost adds on top of the attribute. Zero
    /// without the effect, and note vanilla's amplifiers are zero based, so Jump Boost I is 0.1.
    /// </summary>
    public float JumpBoostPower =>
        Effects.AmplifierOf(PotionEffectType.JumpBoost) is { } level ? 0.1f * (level + 1) : 0.0f;

    /// <summary>
    /// <c>LivingEntity.getJumpPower(float)</c>. Every term is a float upstream and they are
    /// multiplied before anything widens, so the attribute is narrowed first.
    /// </summary>
    public virtual float JumpPower(float scale, float blockJumpFactor) {
        return (float)GetAttributeValue(Attribute.JumpStrength) * scale * blockJumpFactor + JumpBoostPower;
    }

    /// <summary>
    /// <c>LivingEntity.jumpFromGround</c>: replace the upward velocity with the jump power if that is
    /// the faster of the two, and give a sprinting entity a nudge in the direction it faces.
    /// <p/>
    /// The nudge goes through <see cref="Mth"/>'s sine table rather than <see cref="Math"/>, because
    /// that is the table the client used to predict the same jump.
    /// </summary>
    public virtual void JumpFromGround(float blockJumpFactor) {
        float power = JumpPower(1.0f, blockJumpFactor);
        if (power <= 1.0E-5f) {
            return;
        }

        Vec3<double> velocity = Velocity;
        Velocity = velocity.WithY(Math.Max(power, velocity.Y));

        if (!Sprinting) {
            return;
        }

        float yaw = Yaw.DegreesF * 0.017453292f;
        Velocity += new Vec3<double>(-Mth.Sin(yaw) * 0.2, 0.0, Mth.Cos(yaw) * 0.2);
    }

    public void Heal(float amount = -1) {
        float maxHealth = (float)GetAttributeValue(Attribute.MaxHealth);
        if (Math.Abs(amount - -1) < 0.01) {
            amount = maxHealth;
        }
        Health = Math.Min(maxHealth, Health + amount);
    }
    
    protected void SendHealthUpdate() {
        SendToSelf(new ClientBoundSetHealthPacket {
            Health = Health,
            Food = Food,
            Saturation = Saturation
        });
    }
    
    public void SetEquipmentItem(EquipmentSlot slot, ItemStack item) {
        _equipment[slot] = item;

        SendToViewers(new ClientBoundSetEquipmentPacket {
            EntityId = NetId,
            Equipment = new Dictionary<EquipmentSlot, ItemStack> {
                { slot, item }
            }
        });
    }
    
    public ItemStack GetEquipmentItem(EquipmentSlot slot) {
        return _equipment.TryGetValue(slot, out ItemStack? item) ? item : ItemStack.Air;
    }

    /// <summary>
    /// What is in one of the entity's hands, vanilla's <c>getItemInHand</c>, which is the equipment in
    /// the matching slot. <see cref="Player"/> overrides both of these, since a player's hands are their
    /// inventory rather than equipment set on them.
    /// </summary>
    public virtual ItemStack GetItemInHand(Hand hand) {
        return GetEquipmentItem(hand == Hand.OffHand ? EquipmentSlot.OffHand : EquipmentSlot.MainHand);
    }

    public virtual void SetItemInHand(Hand hand, ItemStack item) {
        SetEquipmentItem(hand == Hand.OffHand ? EquipmentSlot.OffHand : EquipmentSlot.MainHand, item);
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        if (_equipment.Count == 0) {  // If no equipment, just return the base packets
            return base.GenerateSpawnEntityPackets();
        }
        
        MinecraftPacket[] arr = [
            new ClientBoundSetEquipmentPacket {
                EntityId = NetId,
                Equipment = _equipment
            }
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }
}
