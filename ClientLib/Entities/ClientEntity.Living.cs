using ClientLib.Maths;
using ClientLib.World;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Direction = Minecraft.Schemas.Blocks.BlockEnums.Direction;

namespace ClientLib.Entities;

/// <summary>What <c>LivingEntity</c> adds: equipment, effects, the swing, the hurt flash, the body turn and the stride.</summary>
public partial class ClientEntity {
    /// <summary><c>LivingEntity.yBodyRot</c>: no packet carries it; the client works it out each tick.</summary>
    public float YBodyRot { get; set; }
    public float YBodyRotO { get; set; }
    private bool _bodyRotationSet;

    public Dictionary<EquipmentSlot, ItemStack> Equipment { get; } = new();

    private AttributeMap? _attributes;
    public AttributeMap Attributes => _attributes ??= new AttributeMap(Type);

    private readonly Dictionary<IPotionEffectType, MobEffectInstance> _activeEffects = new();

    public IReadOnlyCollection<MobEffectInstance> ActiveEffects => _activeEffects.Values;

    public bool HasEffect(IPotionEffectType type) => _activeEffects.ContainsKey(type);

    public MobEffectInstance? GetEffect(IPotionEffectType type) => _activeEffects.GetValueOrDefault(type);

    public float GetEffectBlendFactor(IPotionEffectType type, float partialTick) => GetEffect(type)?.BlendFactor(IsRemoved, partialTick) ?? 0.0F;

    /// <summary><c>LivingEntity.addEffect</c>, less <c>canBeAffected</c> and what only the server does on a change.</summary>
    public bool AddEffect(MobEffectInstance newEffect) {
        if (!_activeEffects.TryGetValue(newEffect.Effect, out MobEffectInstance? effect)) {
            _activeEffects[newEffect.Effect] = newEffect;
            return true;
        }
        return effect.Update(newEffect);
    }

    /// <summary><c>LivingEntity.forceAddEffect</c>. Its <c>canBeAffected</c> check is the packet handler's, which has the tags.</summary>
    public void ForceAddEffect(MobEffectInstance newEffect) {
        if (_activeEffects.TryGetValue(newEffect.Effect, out MobEffectInstance? previousEffect)) {
            newEffect.CopyBlendState(previousEffect);
        }
        _activeEffects[newEffect.Effect] = newEffect;
    }

    public MobEffectInstance? RemoveEffectNoUpdate(IPotionEffectType type) => _activeEffects.Remove(type, out MobEffectInstance? removed) ? removed : null;

    /// <summary><c>LivingEntity.tickEffects</c> on the client, less the effect particles.</summary>
    private void TickEffects() {
        foreach (MobEffectInstance effect in _activeEffects.Values) {
            effect.TickClient();
        }
    }

    /// <summary>Ticks left on the hurt flash, set by <c>hurt_animation</c> and damage events.</summary>
    public int HurtTime { get; set; }

    /// <summary><c>Entity.invulnerableTime</c> as the client keeps it: 20 after a hit, 10 after the local player heals.</summary>
    public int InvulnerableTime { get; set; }

    /// <summary><c>LivingEntity.swingState</c>.</summary>
    public SwingState SwingState { get; } = new();

    public bool IsSwinging => SwingState.IsSwinging;

    /// <summary><c>LivingEntity.getCurrentSwing</c>.</summary>
    public SwingState.Swing? CurrentSwing => SwingState.Current;

    /// <summary><c>LivingEntity.deathTime</c>: ticks since its health reached zero, which tips the body over.</summary>
    public int DeathTime { get; private set; }

    /// <summary><c>LivingEntity.lastKineticHitFeedbackTime</c>, in game time.</summary>
    public long LastKineticHitFeedbackTime { get; private set; } = int.MinValue;

    /// <summary>The gate of <c>LivingEntity.onKineticHit</c>: a hit more than ten ticks after the last starts its feedback.</summary>
    public bool OnKineticHit(long gameTime) {
        if (gameTime - LastKineticHitFeedbackTime <= 10L) {
            return false;
        }
        LastKineticHitFeedbackTime = gameTime;
        return true;
    }

    /// <summary><c>LivingEntity.getTicksSinceLastKineticHitFeedback</c>.</summary>
    public float TicksSinceLastKineticHitFeedback(long gameTime, float partial) =>
        LastKineticHitFeedbackTime < 0L ? 0.0F : gameTime - LastKineticHitFeedbackTime + partial;

    /// <summary>Whether the type has health at all, vanilla's <c>LivingEntity</c>.</summary>
    public bool IsLiving => _isLiving ??= Is(EntityClass.LivingEntity);
    private bool? _isLiving;

    /// <summary><c>WalkAnimationState</c>: how far through a stride the legs are, and how hard they swing.</summary>
    public float WalkPosition { get; private set; }
    public float WalkSpeed { get; private set; }
    public float WalkSpeedOld { get; private set; }

    /// <summary><c>WalkAnimationState.positionScale</c>: a baby strides three times as often.</summary>
    public float WalkPositionScale { get; private set; } = 1.0F;

    /// <summary><c>WalkAnimationState.position(partialTicks)</c>, the stride a model swings its legs by.</summary>
    public float WalkAnimationPosition(float partialTick) => (WalkPosition - WalkSpeed * (1.0F - partialTick)) * WalkPositionScale;

    /// <summary><c>LivingEntity.getItemBySlot</c>, from what the server last sent.</summary>
    public ItemStack GetItemBySlot(EquipmentSlot slot) => Equipment.GetValueOrDefault(slot) ?? ItemStack.Air;

    public virtual ItemStack ItemInHand(Hand hand) => GetItemBySlot(hand == Hand.MainHand ? EquipmentSlot.MainHand : EquipmentSlot.OffHand);

    /// <summary><c>LivingEntity.isBaby</c>: false unless the class keeps a baby flag of its own.</summary>
    public bool IsBaby =>
        Is(EntityClass.AgeableMob) ? Get(EntityDataFields.AgeableMob.Baby)
        : Is(EntityClass.Zombie) ? Get(EntityDataFields.Zombie.Baby)
        : Is(EntityClass.Piglin) ? Get(EntityDataFields.Piglin.Baby)
        : Is(EntityClass.Zoglin) && Get(EntityDataFields.Zoglin.Baby);

    /// <summary>
    /// <c>Entity.getEyeHeight</c>, where the camera sits: a player's by its pose, anything else's by its
    /// type scaled as its attachments are, which takes a mob with poses of its own as standing.
    /// </summary>
    public virtual float CurrentEyeHeight =>
        Is(EntityClass.Player) ? Player.LocalPlayer.EyeHeightOf((Player.EntityPose)Get(EntityDataFields.Entity.Pose, EntityPose.Standing)) : (float)EyeHeight * AttachmentScale;

    /// <summary><c>LivingEntity.DATA_HEALTH_ID</c>, or full health until the server says otherwise.</summary>
    public virtual float CurrentHealth => Get(EntityDataFields.LivingEntity.Health, 1.0F);

    /// <summary>
    /// <c>LivingEntity.swing</c>: a swing restarts only once the last is past its first half. Nothing is
    /// sent: an attack sends its own punch, and the server swings for every other use itself.
    /// </summary>
    public bool Swing(Hand hand, SwingAnimation animation) {
        return SwingState.StartIfAble(hand, animation, SwingState.ModifiedDuration(animation,
            GetEffect(PotionEffectType.Haste)?.Amplifier, GetEffect(PotionEffectType.ConduitPower)?.Amplifier,
            GetEffect(PotionEffectType.MiningFatigue)?.Amplifier));
    }

    /// <summary><c>LivingEntity.getSwingAnimation</c>: how far through the current swing, 0 to 1.</summary>
    public float GetSwingAnimation(float partialTick) => SwingState.GetAnimation(partialTick);

    /// <summary>
    /// <c>LivingEntity.baseTick</c>'s swing and hurt countdown, <c>tickDeath</c>'s death count and
    /// <c>tickEffects</c>; the server removes a dead entity once the count reaches 20.
    /// </summary>
    protected void TickHurtAndDeath() {
        if (IsLiving) {
            SwingState.Tick();
        }
        if (HurtTime > 0) {
            HurtTime--;
        }
        if (InvulnerableTime > 0) {
            InvulnerableTime--;
        }
        if (IsLiving && CurrentHealth <= 0) {
            if (DeathTime < 20) {
                DeathTime++;
            }
        }
        else {
            DeathTime = 0;
        }
        TickEffects();
    }

    /// <summary>
    /// <c>LivingEntity.tick</c>'s body turn: toward the way it walks, or where it faces while swinging,
    /// eased by <c>tickHeadTurn</c> and never more than 50 degrees from the facing.
    /// </summary>
    protected void TickBodyRotation() {
        if (!_bodyRotationSet) {
            YBodyRot = YBodyRotO = YHeadRot;
            _bodyRotationSet = true;
        }
        YBodyRotO = YBodyRot;
        double xd = Position.X - OldPosition.X, zd = Position.Z - OldPosition.Z;
        float sideDist = (float)(xd * xd + zd * zd);
        float target = YBodyRot;
        if (sideDist > 0.0025000002F) {
            float walkDirection = (float)Math.Atan2(zd, xd) * (180.0F / MathF.PI) - 90.0F;
            float difference = Math.Abs(Wrap(YRot) - walkDirection);
            target = 95.0F < difference && difference < 265.0F ? walkDirection - 180.0F : walkDirection;
        }
        if (SwingState.Animation > 0.0F) {
            target = YRot;
        }
        YBodyRot += Wrap(target - YBodyRot) * 0.3F;
        float headDiff = Wrap(YRot - YBodyRot);
        if (Math.Abs(headDiff) > 50.0F) {
            YBodyRot += headDiff - Math.Sign(headDiff) * 50.0F;
        }
        while (YBodyRot - YBodyRotO < -180.0F) {
            YBodyRotO -= 360.0F;
        }
        while (YBodyRot - YBodyRotO >= 180.0F) {
            YBodyRotO += 360.0F;
        }
    }

    /// <summary><c>LivingEntity.calculateEntityAnimation</c>: the stride follows how far the entity actually moved.</summary>
    protected void UpdateWalkAnimation() {
        if (VehicleId != null || IsLiving && CurrentHealth <= 0) {
            WalkSpeedOld = WalkSpeed = WalkPosition = 0.0F;
            return;
        }
        double dx = Position.X - OldPosition.X, dz = Position.Z - OldPosition.Z;
        float distance = (float)Math.Sqrt(dx * dx + dz * dz);
        float target = Math.Min(distance * 4.0F, 1.0F);
        WalkSpeedOld = WalkSpeed;
        WalkSpeed += (target - WalkSpeed) * 0.4F;
        WalkPosition += WalkSpeed;
        WalkPositionScale = IsBaby ? 3.0F : 1.0F;
    }

    /// <summary><c>LivingEntity.getSleepingPos</c>.</summary>
    public (int X, int Y, int Z)? SleepingPos =>
        IsLiving && Get(EntityDataFields.LivingEntity.SleepingPos) is { Present: true } pos ? (pos.Value.X, pos.Value.Y, pos.Value.Z) : null;

    public bool IsSleeping => SleepingPos != null;

    /// <summary><c>LivingEntity.getBedOrientation</c>: null when what it sleeps in is not a bed.</summary>
    public Direction? BedOrientation(ClientLevel level) =>
        SleepingPos is { } bed && level.GetBlock(bed.X, bed.Y, bed.Z) is IHorizontalFacing bedBlock && BlockClasses.Is(bedBlock.Identifier, BlockClass.BedBlock)
            ? bedBlock.Facing
            : null;

    /// <summary><c>Entity.onSyncedDataUpdated</c>, after the field at the index was set.</summary>
    public virtual void OnSyncedDataUpdated(int index) {
        // Display.onSyncedDataUpdated: the teleport duration is the number of steps a move is interpolated over.
        if (index == EntityDataFields.Display.PosRotInterpolationDuration.Index && Is(EntityClass.Display) && Interpolation is LinearInterpolationHandler linear) {
            linear.SetInterpolationLength(Get(EntityDataFields.Display.PosRotInterpolationDuration));
        }
        // LivingEntity.setPosToBed.
        if (IsLiving && index == EntityDataFields.LivingEntity.SleepingPos.Index && SleepingPos is { } bed) {
            Position = new Vec3d(bed.X + 0.5, bed.Y + 0.6875, bed.Z + 0.5);
        }
    }

    /// <summary>
    /// <c>LivingEntity.stopSleeping</c> on the client, which writes its own copy of the synced data.
    /// <c>BedBlock.findStandUpPosition</c> and the turn back towards the bed are left out: the server
    /// teleports the sleeper right after the wake animation that brings the client here, which sets both.
    /// </summary>
    public virtual void StopSleeping(ClientLevel? level) {
        if (level != null && SleepingPos is { } bed && level.GetBlock(bed.X, bed.Y, bed.Z) is IOccupied bedBlock
            && BlockClasses.Is(bedBlock.Identifier, BlockClass.BedBlock)) {
            level.SetState(bed.X, bed.Y, bed.Z, (ushort)bedBlock.WithOccupied(false).StateId);
        }
        Set(EntityDataFields.Entity.Pose, MetaFieldType.Pose, EntityPose.Standing);
        Set(EntityDataFields.LivingEntity.SleepingPos, MetaFieldType.OptionalPosition, Optional<Vec3<int>>.Empty);
    }
}
