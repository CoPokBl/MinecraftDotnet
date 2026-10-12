using ClientLib.Entities;
using ClientLib.Interaction;
using ClientLib.Maths;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ClientLib.Player;

/// <summary>The player this client controls.</summary>
public sealed partial class LocalPlayer : ClientEntity {
    private readonly MinecraftClient _client;

    public float Health { get; set; } = 20.0F;

    /// <summary>The player is never sent its own entity data; its health comes from <c>set_health</c>.</summary>
    public override float CurrentHealth => Health;

    /// <summary><c>ClientAvatarState.walkDist</c> and <c>bob</c>, which view bobbing swings with.</summary>
    public float WalkDist { get; private set; }
    public float WalkDistO { get; private set; }
    public float Bob { get; private set; }
    public float BobO { get; private set; }

    /// <summary><c>Player.attackStrengthTicker</c> and <c>itemSwapTicker</c>: ticks since the last swing or item change.</summary>
    public int AttackStrengthTicker { get; private set; }
    public int ItemSwapTicker { get; private set; }
    private ItemStack _lastItemInMainHand = ItemStack.Air;

    public void ResetAttackStrengthTicker() {
        AttackStrengthTicker = 0;
        ItemSwapTicker = 0;
    }

    /// <summary><c>Player.onAttack</c>: <c>resetOnlyAttackStrengthTicker</c>.</summary>
    public void OnAttack() => AttackStrengthTicker = 0;

    /// <summary><c>Player.getCurrentItemAttackStrengthDelay</c>: ticks to a full strength attack.</summary>
    public float CurrentItemAttackStrengthDelay => (float)(1.0 / Attributes.Value(Minecraft.Data.Generated.Attribute.AttackSpeed) * 20.0);

    /// <summary><c>Player.getAttackStrengthScale</c>, which the attack indicator shows.</summary>
    public float AttackStrengthScale(float partialTick) => Math.Clamp((AttackStrengthTicker + partialTick) / CurrentItemAttackStrengthDelay, 0.0F, 1.0F);

    /// <summary><c>Player.getItemSwapScale</c>, which lowers the held item after a swing or a swap.</summary>
    public float ItemSwapScale(float partialTick) => Math.Clamp((ItemSwapTicker + partialTick) / CurrentItemAttackStrengthDelay, 0.0F, 1.0F);

    /// <summary>
    /// <c>Player.attack</c> as the client runs it. The damage is the server's; what runs here is
    /// <c>hurtClient</c> deciding whether the hit lands and, when it does, <c>causeExtraKnockback</c>
    /// pushing the target and slowing and unsprinting the attacker in the same tick.
    /// </summary>
    public void Attack(ClientEntity target) {
        if (CannotAttack(target)) {
            return;
        }
        float baseDamage = IsAutoSpinAttack ? _autoSpinAttackDamage : (float)Attributes.Value(Minecraft.Data.Generated.Attribute.AttackDamage);
        float attackStrengthScale = AttackStrengthScale(0.5F);
        // getEnchantedDamage is the identity off the server, so magicBoost is always zero here.
        baseDamage *= 0.2F + attackStrengthScale * attackStrengthScale * 0.8F;
        OnAttack();
        if (DeflectProjectile(target) || baseDamage <= 0.0F) {
            return;
        }
        bool fullStrengthAttack = attackStrengthScale > 0.9F;
        bool knockbackAttack = Sprinting && fullStrengthAttack;
        // getAttackDamageBonus and the critical multiplier only change the damage, which nothing here reads.
        bool criticalAttack = fullStrengthAttack && CanCriticalAttack(target);
        if (!HurtClient(target)) {
            return;
        }
        // getKnockback skips EnchantmentHelper.modifyKnockback off the server.
        CauseExtraKnockback(target, (float)Attributes.Value(Minecraft.Data.Generated.Attribute.AttackKnockback) / 2.0F + (knockbackAttack ? 0.5F : 0.0F));
        // isSweepAttack and doSweepAttack only play a sound for nobody and hurt on the server.
        if (criticalAttack) {
            CriticalHit?.Invoke(target);
        }
    }

    /// <summary><c>LocalPlayer.crit</c>, which starts a tracking emitter of crit particles on the target.</summary>
    public event Action<ClientEntity>? CriticalHit;

    /// <summary>
    /// <c>Player.cannotAttack</c>: <c>isAttackable</c> and <c>skipAttackInteraction</c>. On a client
    /// <c>mayInteract</c> is always true and an item frame's <c>fixed</c> is never known, so a
    /// <c>BlockAttachedEntity</c>'s <c>hurtClient</c> always lands and its skip always refuses.
    /// </summary>
    private bool CannotAttack(ClientEntity target) {
        if (target.Is(EntityClass.ExperienceOrb) || target.Is(EntityClass.FallingBlockEntity) || target.Is(EntityClass.ItemEntity)
            || target.Is(EntityClass.FireworkRocketEntity) || target.Is(EntityClass.EyeOfEnder)
            || target.Is(EntityClass.AbstractArrow) && !_client.InEntityTypeTag(target.Type, Picking.RedirectableProjectile)) {
            return true;
        }
        if (target.Is(EntityClass.Interaction)) {
            return !target.Get(EntityDataFields.Interaction.Response);
        }
        return target.Is(EntityClass.BlockAttachedEntity) && !target.IsRemoved;
    }

    /// <summary><c>Player.deflectProjectile</c>: <c>AIM_DEFLECT</c> sends the projectile along the look.</summary>
    private bool DeflectProjectile(ClientEntity target) {
        if (!_client.InEntityTypeTag(target.Type, Picking.RedirectableProjectile) || !target.Is(EntityClass.Projectile)) {
            return false;
        }
        target.DeltaMovement = Picking.ViewVector(this, 1.0F);
        return true;
    }

    /// <summary><c>Player.canCriticalAttack</c>.</summary>
    private bool CanCriticalAttack(ClientEntity target) =>
        FallDistance > 0.0 && !OnGround && !OnClimbable() && !IsInWater && !HasEffect(PotionEffectType.Blindness) && !IsPassenger
        && target.IsLiving && !Sprinting;

    /// <summary>
    /// <c>hurtClient</c> for a player attack: true for a <c>RemotePlayer</c>, a <c>VehicleEntity</c>, an end
    /// crystal and a shulker bullet, false for every other entity, mobs included.
    /// </summary>
    private bool HurtClient(ClientEntity target) =>
        target.Type == EntityType.Player && target != this || target.Is(EntityClass.VehicleEntity) || target.Is(EntityClass.ShulkerBullet)
        || target.Is(EntityClass.EndCrystal) && !target.IsRemoved;

    /// <summary><c>Player.causeExtraKnockback</c>.</summary>
    private void CauseExtraKnockback(ClientEntity target, float knockbackAmount) {
        if (knockbackAmount <= 0.0F) {
            return;
        }
        float yRot = YRot * ((float)Math.PI / 180.0F);
        if (target.IsLiving) {
            Knockback(target, knockbackAmount, Mth.Sin(yRot), -Mth.Cos(yRot));
        }
        else {
            target.DeltaMovement = target.DeltaMovement.Add(-Mth.Sin(yRot) * knockbackAmount, 0.1, Mth.Cos(yRot) * knockbackAmount);
        }
        DeltaMovement = new Vec3d(DeltaMovement.X * 0.6, DeltaMovement.Y, DeltaMovement.Z * 0.6);
        SetSprinting(false);
    }

    /// <summary>
    /// <c>LivingEntity.knockback</c> on the target's client copy. Its loop redrawing a zero direction from
    /// the target's random never runs here: the direction is a sine and cosine pair.
    /// </summary>
    private static void Knockback(ClientEntity target, double power, double xd, double zd) {
        power *= 1.0 - target.Attributes.Value(Minecraft.Data.Generated.Attribute.KnockbackResistance);
        if (power <= 0.0) {
            return;
        }
        Vec3d deltaMovement = target.DeltaMovement;
        Vec3d deltaVector = new Vec3d(xd, 0.0, zd).Normalize() * power;
        target.DeltaMovement = new Vec3d(
            deltaMovement.X / 2.0 - deltaVector.X,
            target.OnGround ? Math.Min(0.4, deltaMovement.Y / 2.0 + power) : deltaMovement.Y,
            deltaMovement.Z / 2.0 - deltaVector.Z);
    }

    /// <summary><c>Player.hurtDir</c>: the yaw the last hit came from, which way the camera tilts.</summary>
    public float HurtDir { get; set; }

    public override ItemStack ItemInHand(Hand hand) => hand == Hand.MainHand ? _client.Inventory.MainHand : _client.Inventory.Offhand;
    public int Food { get; set; } = 20;

    public ItemCooldowns Cooldowns { get; } = new();
    public float Saturation { get; set; } = 5.0F;
    public float ExperienceProgress { get; set; }
    public int ExperienceLevel { get; set; }
    public int TotalExperience { get; set; }

    public GameMode GameMode { get; set; } = GameMode.Survival;
    public GameMode PreviousGameMode { get; set; } = GameMode.Undefined;

    public bool Invulnerable { get; set; }
    public bool Flying { get; set; }
    public bool MayFly { get; set; }
    public bool InstaBuild { get; set; }
    public float FlyingSpeed { get; set; } = 0.05F;
    public float WalkingSpeed { get; set; } = 0.1F;

    public bool ReducedDebugInfo { get; set; }
    public bool ShowDeathScreen { get; set; } = true;

    /// <summary><c>Player.getLastDeathLocation</c>, from the login or respawn that made this player.</summary>
    public (Identifier Dimension, int X, int Y, int Z)? LastDeathLocation { get; init; }
    public bool IsDead => Health <= 0.0F;

    public bool HorizontalCollision { get; private set; }

    /// <summary>The keys held this tick. Written by the host before every <see cref="MinecraftClient.Tick"/>.</summary>
    public PlayerInput Input { get; set; } = PlayerInput.None;

    /// <summary>
    /// Mouse look, vanilla's <c>Entity.turn</c>: the host calls this every frame with the cursor
    /// movement already scaled by sensitivity, and the old rotation moves with it so a frame's
    /// interpolation does not snap back.
    /// </summary>
    public void Turn(double yRotDelta, double xRotDelta) {
        float yd = (float)xRotDelta * 0.15F;
        float xd = (float)yRotDelta * 0.15F;
        XRot = Math.Clamp(XRot + yd, -90.0F, 90.0F);
        YRot += xd;
        XRotO = Math.Clamp(XRotO + yd, -90.0F, 90.0F);
        YRotO += xd;
        Vehicle?.OnPassengerTurned(this);
    }

    // LocalPlayer.sendPosition's memory of what it last told the server.
    private double _xLast, _yLast, _zLast;
    private float _yRotLast, _xRotLast;
    private bool _lastOnGround, _lastHorizontalCollision;
    private int _positionReminder;
    private bool _wasSprinting;
    private ServerBoundPlayerInputPacket.Input _lastSentInput;

    public LocalPlayer(MinecraftClient client) {
        _client = client;
        InterpolationSteps = 0;
    }

    /// <summary>
    /// <c>MultiPlayerGameMode.createPlayer</c> for a respawn. One that keeps the entity data carries
    /// over what the server was last told, so nothing is sent again.
    /// </summary>
    internal LocalPlayer(MinecraftClient client, LocalPlayer? kept) : this(client) {
        if (kept != null) {
            _lastSentInput = kept._lastSentInput;
            _wasSprinting = kept.Sprinting;
        }
    }

    public bool IsSpectator => GameMode == GameMode.Spectator;
    public bool IsCreative => GameMode == GameMode.Creative;

    /// <summary><c>GameType.updatePlayerAbilities</c>.</summary>
    public void UpdateAbilities(GameMode mode) {
        switch (mode) {
            case GameMode.Creative:
                MayFly = true;
                InstaBuild = true;
                Invulnerable = true;
                break;
            case GameMode.Spectator:
                MayFly = true;
                InstaBuild = false;
                Invulnerable = true;
                Flying = true;
                break;
            default:
                MayFly = false;
                InstaBuild = false;
                Invulnerable = false;
                Flying = false;
                break;
        }
    }

    public void ApplyAbilities(ClientBoundPlayerAbilitiesPacket packet) {
        ClientBoundPlayerAbilitiesPacket.Abilities flags = packet.Flags;
        Invulnerable = (flags & ClientBoundPlayerAbilitiesPacket.Abilities.Invulnerable) != 0;
        Flying = (flags & ClientBoundPlayerAbilitiesPacket.Abilities.Flying) != 0;
        MayFly = (flags & ClientBoundPlayerAbilitiesPacket.Abilities.AllowFlying) != 0;
        InstaBuild = (flags & ClientBoundPlayerAbilitiesPacket.Abilities.CreativeMode) != 0;
        FlyingSpeed = packet.FlyingSpeed;
        WalkingSpeed = packet.FovModifier;
    }

    /// <summary><c>LocalPlayer.isControlledCamera</c>: false while spectating another entity.</summary>
    public bool IsControlledCamera => _client.CameraEntity == this;

    /// <summary><c>LocalPlayer.sendPosition</c>.</summary>
    private void SendPosition() {
        SendIsSprintingIfNeeded();
        if (!IsControlledCamera) {
            return;
        }

        double dx = Position.X - _xLast;
        double dy = Position.Y - _yLast;
        double dz = Position.Z - _zLast;
        double dYRot = YRot - _yRotLast;
        double dXRot = XRot - _xRotLast;
        _positionReminder++;
        bool move = dx * dx + dy * dy + dz * dz > 2.0E-4 * 2.0E-4 || _positionReminder >= 20;
        bool rot = dYRot != 0.0 || dXRot != 0.0;
        MovePlayerFlags flags = MovementFlags;
        Vec3<double> position = new(Position.X, Position.Y, Position.Z);
        if (move && rot) {
            _client.Send(new ServerBoundSetPlayerPosAndRotPacket { Position = position, Yaw = YRot, Pitch = XRot, Flags = flags });
        }
        else if (move) {
            _client.Send(new ServerBoundSetPlayerPositionPacket { Position = position, Flags = flags });
        }
        else if (rot) {
            _client.Send(new ServerBoundSetPlayerRotationPacket { Yaw = YRot, Pitch = XRot, Flags = flags });
        }
        else if (_lastOnGround != OnGround || _lastHorizontalCollision != HorizontalCollision) {
            _client.Send(new ServerBoundSetMovementFlagsPacket {
                SetFlags = (ServerBoundSetMovementFlagsPacket.Flags)(int)flags
            });
        }

        if (move) {
            _xLast = Position.X;
            _yLast = Position.Y;
            _zLast = Position.Z;
            _positionReminder = 0;
        }
        if (rot) {
            _yRotLast = YRot;
            _xRotLast = XRot;
        }
        _lastOnGround = OnGround;
        _lastHorizontalCollision = HorizontalCollision;
    }

    /// <summary><c>Entity.isSprinting</c>: shared flag 3, which the server clears on a sprint hit.</summary>
    public bool Sprinting => (SharedFlags & 1 << 3) != 0;

    private MovePlayerFlags MovementFlags =>
        (OnGround ? MovePlayerFlags.OnGround : 0) | (HorizontalCollision ? MovePlayerFlags.AgainstWall : 0);

    private void SendIsSprintingIfNeeded() {
        if (Sprinting == _wasSprinting) {
            return;
        }
        _client.Send(new ServerBoundPlayerCommandPacket {
            EntityId = Id,
            PlayAction = Sprinting ? PlayerAction.StartSprinting : PlayerAction.StopSprinting,
            JumpBoost = 0
        });
        _wasSprinting = Sprinting;
    }

    /// <summary><c>LocalPlayer.tick</c>'s input send: the packet goes out only when what is held changed.</summary>
    private void SendInputIfChanged(ServerBoundPlayerInputPacket.Input input) {
        if (input == _lastSentInput) {
            return;
        }
        _client.Send(new ServerBoundPlayerInputPacket { Flags = input });
        _lastSentInput = input;
    }
}
