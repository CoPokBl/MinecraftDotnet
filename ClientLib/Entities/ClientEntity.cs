using ClientLib.Maths;
using Minecraft.Physics;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Text;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Vec;
using Minecraft.Packets.Play.ClientBound;
using Direction = Minecraft.Schemas.Blocks.BlockEnums.Direction;

namespace ClientLib.Entities;

/// <summary>
/// An entity the server told the client about. Positions from the server reach it through its
/// <see cref="Interpolation"/>, as vanilla's <c>moveOrInterpolateTo</c> does.
/// </summary>
public partial class ClientEntity {
    public int Id { get; set; }
    public Guid Uuid { get; internal set; }
    public IEntityType Type { get; internal set; } = null!;
    public int SpawnData { get; internal set; }

    public Vec3d Position { get; set; }
    /// <summary>Where the entity was at the start of the tick, for interpolating frames between ticks.</summary>
    public Vec3d OldPosition { get; set; }
    public Vec3d DeltaMovement { get; set; }
    public float YRot { get; set; }
    public float XRot { get; set; }
    public float YRotO { get; set; }
    public float XRotO { get; set; }
    public float YHeadRot { get; set; }
    public float YHeadRotO { get; set; }
    public bool OnGround { get; set; }
    public int TickCount { get; protected set; }

    /// <summary>Every metadata field received so far, by index.</summary>
    public Dictionary<int, MetaField> Metadata { get; } = new();

    /// <summary>
    /// Whatever the renderer drawing this entity keeps between frames: a creeper's swell, an animation's
    /// start tick. Vanilla keeps these as fields on its client side entity classes.
    /// </summary>
    public object? RendererData { get; set; }

    /// <summary><c>Leashable.LeashData.delayedLeashHolderId</c>: the entity holding this one's lead, 0 for none.</summary>
    public int LeashHolderId { get; set; }

    /// <summary>
    /// Entities the client moves by their velocity between server updates instead of only
    /// interpolating, which vanilla does by running their physics; projectiles mostly.
    /// </summary>
    public bool MovesFreely { get; set; }

    public double Width => Type.Width;
    public double Height => Type.Height;
    public double EyeHeight => Type.EyeHeight;

    /// <summary><c>Entity.getBoundingBox</c> through <c>EntityDimensions.makeBoundingBox</c>, unless the class tracks its own.</summary>
    public virtual Box BoundingBox => MakeBoundingBox(Position);

    /// <summary>
    /// <c>Entity.getDimensions</c> for the current pose: an interaction's own synced size, <c>LivingEntity.getDimensions</c>
    /// over <c>Avatar</c>'s poses and a cube mob's size. The other living classes that override <c>getDefaultDimensions</c>,
    /// <c>getAgeScale</c> or <c>sanitizeScale</c> (an armor stand, a phantom, a baby turtle) are sized as any other mob.
    /// </summary>
    public virtual (float Width, float Height) Dimensions {
        get {
            if (Is(EntityClass.Interaction)) {
                return (Get(EntityDataFields.Interaction.Width, 1.0F), Get(EntityDataFields.Interaction.Height, 1.0F));
            }
            (float width, float height) = ((float)Width, (float)Height);
            if (!IsLiving) {
                return (width, height);
            }
            EntityPose pose = Get(EntityDataFields.Entity.Pose, EntityPose.Standing);
            // SLEEPING_DIMENSIONS and an avatar's dying ones are fixed, which no scale changes.
            if (pose == EntityPose.Sleeping || pose == EntityPose.Dying && Is(EntityClass.Avatar)) {
                return (0.2F, 0.2F);
            }
            if (Is(EntityClass.Avatar)) {
                (width, height) = pose switch {
                    EntityPose.FallFlying or EntityPose.Swimming or EntityPose.SpinAttack => (0.6F, 0.6F),
                    EntityPose.Sneaking => (0.6F, 1.5F),
                    _ => (0.6F, 1.8F)
                };
            }
            else if (Is(EntityClass.AbstractCubeMob)) {
                int size = Get(EntityDataFields.AbstractCubeMob.IdSize, 1);
                (width, height) = (width * size, height * size);
            }
            else if (IsBaby) {
                (width, height) = (width * 0.5F, height * 0.5F);
            }
            float scale = (float)Attributes.Value(Minecraft.Data.Generated.Attribute.Scale);
            return (width * scale, height * scale);
        }
    }

    /// <summary>Whether the type's vanilla class is, or extends, <paramref name="vanillaClass"/>.</summary>
    public bool Is(EntityClass vanillaClass) {
        // Renderers ask this several times an entity a frame; the chain is looked up once per type.
        if (!ReferenceEquals(_classesOf, Type)) {
            _classes = EntityClasses.Of(Type.Identifier);
            _classesOf = Type;
        }
        foreach (EntityClass name in _classes) {
            if (name == vanillaClass) {
                return true;
            }
        }
        return false;
    }

    private IEntityType? _classesOf;
    private EntityClass[] _classes = [];

    private int _lerpHeadSteps;
    private float _lerpHeadYRot;

    /// <summary><c>VecDeltaCodec.base</c>: the last position the server sent, as it was sent.</summary>
    private Vec3d _codecBase;

    public Vec3d CodecBase => _codecBase;

    public void SetCodecBase(Vec3d position) => _codecBase = position;

    private static long Encode(double value) => Minecraft.Schemas.Mth.JavaRound(value * 4096.0);

    private static double Decode(long value) => value / 4096.0;

    /// <summary><c>VecDeltaCodec.decode</c>, which leaves an axis that did not move exactly where it was.</summary>
    public Vec3d DecodeDelta(long xa, long ya, long za) {
        if (xa == 0 && ya == 0 && za == 0) {
            return _codecBase;
        }
        double x = xa == 0 ? _codecBase.X : Decode(Encode(_codecBase.X) + xa);
        double y = ya == 0 ? _codecBase.Y : Decode(Encode(_codecBase.Y) + ya);
        double z = za == 0 ? _codecBase.Z : Decode(Encode(_codecBase.Z) + za);
        return new Vec3d(x, y, z);
    }

    /// <summary>
    /// <c>VecDelta.decode</c>: each step of a stepped delta is relative to the one before it, and the base
    /// is left where it was for the caller to move.
    /// </summary>
    public PositionPath DecodeDelta(MovementDelta.Step[]? steps, Vec3<float> delta) {
        if (steps is not { Length: > 0 }) {
            return PositionPath.Of(DecodeDelta(Shorts(delta.X), Shorts(delta.Y), Shorts(delta.Z)));
        }
        PositionStep[] output = new PositionStep[steps.Length];
        Vec3d originalBase = _codecBase;
        for (int i = 0; i < steps.Length; i++) {
            MovementDelta.Step step = steps[i];
            Vec3d position = DecodeDelta(Shorts(step.Delta.X), Shorts(step.Delta.Y), Shorts(step.Delta.Z));
            output[i] = new PositionStep(position, step.Ticks);
            _codecBase = position;
        }
        _codecBase = originalBase;
        return new PositionPath.Stepped(output);

        // The protocol layer hands the shorts back divided by 4096, which a float holds exactly.
        static long Shorts(float blocks) => (long)Math.Round(blocks * 4096.0);
    }

    /// <summary>
    /// <c>Entity.interpolationHandler</c>, from <c>createInterpolationHandler</c>. Nothing interpolates until
    /// <see cref="InterpolationHandlers.For"/> gives the entity its class's handler.
    /// </summary>
    public IInterpolationHandler Interpolation { get; set; } = NoOpInterpolationHandler.Instance;

    /// <summary><c>Entity.snapTo</c>, which leaves an interpolation in progress running from the new position.</summary>
    public void SnapTo(Vec3d position, float yRot, float xRot) {
        Position = position;
        SetYRot(yRot);
        SetXRot(xRot);
        OldPosition = position;
        YRotO = YRot;
        XRotO = XRot;
    }

    /// <summary>
    /// The spawn's placement, as <c>recreateFromPacket</c> makes it: nothing of an earlier interpolation
    /// survives, since there was none.
    /// </summary>
    public void Snap(Vec3d position, float yRot, float xRot) {
        SnapTo(position, yRot, xRot);
        Interpolation.Cancel();
    }

    /// <summary><c>Entity.setRot</c>.</summary>
    public void SetRot(float yRot, float xRot) {
        SetYRot(yRot % 360.0F);
        SetXRot(xRot % 360.0F);
    }

    /// <summary><c>Entity.setYRot</c>, which drops a rotation that is not finite.</summary>
    public void SetYRot(float yRot) {
        if (float.IsFinite(yRot)) {
            YRot = yRot;
        }
    }

    /// <summary><c>Entity.setXRot</c>.</summary>
    public void SetXRot(float xRot) {
        if (float.IsFinite(xRot)) {
            XRot = Math.Clamp(xRot % 360.0F, -90.0F, 90.0F);
        }
    }

    /// <summary><c>Entity.storePositionAndRotation</c>.</summary>
    public PositionAndRotation StorePositionAndRotation() => new(Position, YRot, XRot);

    /// <summary><c>Entity.getClientPositionAndRotation</c>: where the interpolation is heading, or where the entity is.</summary>
    public PositionAndRotation ClientPositionAndRotation => Interpolation.Target ?? StorePositionAndRotation();

    /// <summary><c>Entity.getClientPosition</c>.</summary>
    public Vec3d ClientPosition => Interpolation.Target?.Position ?? Position;

    public bool IsInterpolating => Interpolation.HasActiveInterpolation;

    /// <summary><c>Entity.moveOrInterpolateTo</c>: an entity that does not interpolate takes the position at once.</summary>
    public void MoveOrInterpolateTo(PositionPath? position, float yRot, float xRot, bool hasRotation) {
        if (!Interpolation.InterpolateTo(position, yRot, xRot, hasRotation)) {
            if (position != null) {
                Position = position.EndPosition;
            }
            if (hasRotation) {
                SetRot(yRot, xRot);
            }
        }
    }

    public void MoveOrInterpolateTo(Vec3d position, float yRot, float xRot) => MoveOrInterpolateTo(PositionPath.Of(position), yRot, xRot, true);

    /// <summary><c>Entity.onInterpolationStart</c>.</summary>
    public virtual void OnInterpolationStart(IInterpolationHandler interpolation) {
    }

    /// <summary><c>Entity.makeBoundingBox</c> through <c>EntityDimensions.makeBoundingBox</c>: the half width is a float before it is widened.</summary>
    public virtual Box MakeBoundingBox(Vec3d position) {
        (float width, float height) = Dimensions;
        float half = width / 2.0F;
        return new Box(position.X - half, position.Y, position.Z - half, position.X + half, position.Y + height, position.Z + half);
    }

    /// <summary>
    /// <c>Entity.handleEntityEvent</c>, for what an event changes in the entity's own state. The particles
    /// and sounds of events are <see cref="Particles.EntityParticles"/>' and the audio's.
    /// </summary>
    public virtual void HandleEntityEvent(ClientBoundEntityEventPacket.EntityEventType status) {
    }

    /// <summary><c>Entity.setOnGround</c>, as a server position update calls it.</summary>
    public virtual void SetOnGroundFromServer(bool onGround) => OnGround = onGround;

    /// <summary><c>LivingEntity.lerpHeadTo</c>.</summary>
    public void InterpolateHead(float yHeadRot, int steps) {
        _lerpHeadYRot = yHeadRot;
        _lerpHeadSteps = steps;
    }

    public virtual void Tick() {
        TickCount++;
        OldPosition = Position;
        YRotO = YRot;
        XRotO = XRot;
        YHeadRotO = YHeadRot;

        Interpolation.Interpolate();
        if (MovesFreely) {
            // Projectile.getMoveSimulationType is SERVER_AND_CLIENT, so the move is recorded as predicted.
            Position += DeltaMovement;
            Interpolation.ApplyPredictedMovement(DeltaMovement);
        }

        if (_lerpHeadSteps > 0) {
            YHeadRot += Wrap(_lerpHeadYRot - YHeadRot) / _lerpHeadSteps;
            _lerpHeadSteps--;
        }

        UpdateWalkAnimation();
        if (IsLiving) {
            TickBodyRotation();
        }

        TickHurtAndDeath();
    }

    public static double Lerp(double alpha, double from, double to) => from + alpha * (to - from);

    public static double RotLerp(double alpha, double from, double to) => from + alpha * Wrap(to - from);

    public static float Wrap(float degrees) {
        float wrapped = degrees % 360.0F;
        if (wrapped >= 180.0F) {
            wrapped -= 360.0F;
        }
        if (wrapped < -180.0F) {
            wrapped += 360.0F;
        }
        return wrapped;
    }

    public static double Wrap(double degrees) {
        double wrapped = degrees % 360.0;
        if (wrapped >= 180.0) {
            wrapped -= 360.0;
        }
        if (wrapped < -180.0) {
            wrapped += 360.0;
        }
        return wrapped;
    }

    /// <summary><c>Direction.toYRot</c>.</summary>
    public static float ToYRot(Direction direction) => direction switch {
        Direction.South => 0.0F,
        Direction.West => 90.0F,
        Direction.North => 180.0F,
        _ => 270.0F
    };

    /// <summary>
    /// The value the server last sent for a field, or <paramref name="fallback"/> until it has. A field
    /// from another class's table reads whatever this entity's class keeps at that index, so the caller
    /// has to know the entity is one.
    /// </summary>
    public T Get<T>(EntityDataField<T> field, T fallback) {
        return Metadata.TryGetValue(field.Index, out MetaField? value) && value is MetaField<T> typed ? typed.Value : fallback;
    }

    public T? Get<T>(EntityDataField<T> field) => Get(field, default(T)!);

    public bool Has<T>(EntityDataField<T> field) => Metadata.TryGetValue(field.Index, out MetaField? value) && value is MetaField<T>;

    /// <summary>Writes the client's own copy of a synced field, as vanilla's <c>entityData.set</c> on the client does.</summary>
    protected void Set<T>(EntityDataField<T> field, MetaFieldType type, T value) => Metadata[field.Index] = new MetaField<T>(type, value);

    /// <summary><c>Entity.DATA_SHARED_FLAGS_ID</c>: on fire, crouching, sprinting, swimming, invisible, glowing, gliding.</summary>
    public byte SharedFlags => (byte)Get(EntityDataFields.Entity.SharedFlags);

    /// <summary><c>Entity.setSharedFlag</c>, on the client's copy, which the server's next update overwrites.</summary>
    protected void SetSharedFlag(int flag, bool value) {
        int flags = value ? SharedFlags | 1 << flag : SharedFlags & ~(1 << flag);
        Set(EntityDataFields.Entity.SharedFlags, MetaFieldType.Byte, (sbyte)flags);
    }

    public bool IsCrouching => (SharedFlags & 0x02) != 0;
    public bool IsInvisible => (SharedFlags & 0x20) != 0;

    /// <summary><c>Entity.isCurrentlyGlowing</c> on the client: the shared flag the server keeps for the glowing effect and tag.</summary>
    public bool IsCurrentlyGlowing => (SharedFlags & 0x40) != 0;

    /// <summary>
    /// <c>Entity.remainingFireTicks</c>. On the client only the local player's own block effects move
    /// it, and only for the tick between catching and the next <c>clearFire</c>.
    /// </summary>
    public int RemainingFireTicks { get; set; }

    /// <summary>
    /// <c>Entity.fireImmune</c>, with <c>Creaking</c>'s heart bound override. <c>ItemEntity</c>'s, an item
    /// whose <c>damage_resistant</c> tag holds <c>in_fire</c>, is left out: the client cannot resolve
    /// damage type tags, and a server never flags such an item as burning.
    /// </summary>
    public bool FireImmune => Type.FireImmune || Is(EntityClass.Creaking) && Get(EntityDataFields.Creaking.HomePos) is { Present: true };

    /// <summary><c>Entity.isOnFire</c> on the client.</summary>
    public bool IsOnFire => !FireImmune && (RemainingFireTicks > 0 || (SharedFlags & 0x01) != 0);

    /// <summary><c>Entity.getTicksFrozen</c>: <c>DATA_TICKS_FROZEN</c>, which only the local player's own powder snow also moves.</summary>
    public int TicksFrozen => Get(EntityDataFields.Entity.TicksFrozen);

    /// <summary><c>Entity.getTicksRequiredToFreeze</c>.</summary>
    public const int TicksRequiredToFreeze = 140;

    /// <summary><c>Entity.getPercentFrozen</c>.</summary>
    public float PercentFrozen => (float)Math.Min(TicksFrozen, TicksRequiredToFreeze) / TicksRequiredToFreeze;

    /// <summary><c>Entity.isFullyFrozen</c>.</summary>
    public bool IsFullyFrozen => TicksFrozen >= TicksRequiredToFreeze;

    public string? CustomName {
        get {
            Optional<TextComponent>? name = Get(EntityDataFields.Entity.CustomName);
            return name is { Present: true } ? TextFlattener.Plain(name.Value) : null;
        }
    }
}
