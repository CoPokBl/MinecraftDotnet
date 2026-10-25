using ClientLib.Maths;
using Minecraft.Physics;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Text;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Direction = Minecraft.Schemas.Blocks.BlockEnums.Direction;

namespace ClientLib.Entities;

/// <summary>
/// An entity the server told the client about. Positions are moved toward what the server last said
/// over a few ticks, as <c>InterpolationHandler</c> does, rather than snapped.
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

    public int InterpolationSteps { get; set; } = 3;

    public double Width => Type.Width;
    public double Height => Type.Height;
    public double EyeHeight => Type.EyeHeight;

    /// <summary><c>Entity.getBoundingBox</c> through <c>EntityDimensions.makeBoundingBox</c>, unless the class tracks its own.</summary>
    public virtual Box BoundingBox {
        get {
            (float width, float height) = Dimensions;
            float half = width / 2.0F;
            return new Box(Position.X - half, Position.Y, Position.Z - half, Position.X + half, Position.Y + height, Position.Z + half);
        }
    }

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

    /// <summary><c>VecDeltaCodec</c>: the last position the server sent, in its quantised form.</summary>
    private long _baseX, _baseY, _baseZ;

    private int _lerpSteps;
    private Vec3d _lerpPosition;
    private float _lerpYRot, _lerpXRot;
    private int _lerpHeadSteps;
    private float _lerpHeadYRot;

    public void SetCodecBase(Vec3d position) {
        _baseX = Encode(position.X);
        _baseY = Encode(position.Y);
        _baseZ = Encode(position.Z);
    }

    private static long Encode(double value) => (long)Math.Round(value * 4096.0, MidpointRounding.AwayFromZero);

    /// <summary><c>VecDeltaCodec.decode</c>, which leaves an axis that did not move exactly where it was.</summary>
    public Vec3d DecodeDelta(long xa, long ya, long za) {
        if (xa == 0 && ya == 0 && za == 0) {
            return new Vec3d(_baseX / 4096.0, _baseY / 4096.0, _baseZ / 4096.0);
        }
        return new Vec3d((_baseX + xa) / 4096.0, (_baseY + ya) / 4096.0, (_baseZ + za) / 4096.0);
    }

    public void Snap(Vec3d position, float yRot, float xRot) {
        Position = position;
        OldPosition = position;
        YRot = YRotO = yRot;
        XRot = XRotO = xRot;
        _lerpSteps = 0;
    }

    /// <summary>
    /// <c>Entity.moveOrInterpolateTo</c> through <c>InterpolationHandler.interpolateTo</c>. A repeat of the
    /// target in progress does not restart it: a server that resends a teleport would otherwise hold the entity
    /// short of it for another three ticks, where its box pushes the local player.
    /// </summary>
    public virtual void InterpolateTo(Vec3d position, float yRot, float xRot) {
        if (InterpolationSteps == 0) {
            Position = position;
            YRot = yRot;
            XRot = xRot;
            _lerpSteps = 0;
            return;
        }
        if (_lerpSteps > 0 && InterpolationHandler.JavaEquals(_lerpYRot, yRot) && InterpolationHandler.JavaEquals(_lerpXRot, xRot)
            && InterpolationHandler.JavaEquals(_lerpPosition, position)) {
            return;
        }
        _lerpSteps = InterpolationSteps;
        _lerpPosition = position;
        _lerpYRot = yRot;
        _lerpXRot = xRot;
    }

    public virtual void InterpolateTo(Vec3d position) => InterpolateTo(position, _lerpSteps > 0 ? _lerpYRot : YRot, _lerpSteps > 0 ? _lerpXRot : XRot);

    public virtual void InterpolateRotation(float yRot, float xRot) => InterpolateTo(_lerpSteps > 0 ? _lerpPosition : Position, yRot, xRot);

    public bool IsInterpolating => _lerpSteps > 0;

    /// <summary><c>InterpolationHandler.position</c>: where the interpolation is heading, or where the entity is.</summary>
    public Vec3d InterpolationTarget => _lerpSteps > 0 ? _lerpPosition : Position;

    public void CancelInterpolation() => _lerpSteps = 0;

    protected bool StepInterpolation() {
        if (_lerpSteps <= 0) {
            return false;
        }
        double alpha = 1.0 / _lerpSteps;
        Position = new Vec3d(
            Lerp(alpha, Position.X, _lerpPosition.X),
            Lerp(alpha, Position.Y, _lerpPosition.Y),
            Lerp(alpha, Position.Z, _lerpPosition.Z));
        YRot = (float)RotLerp(alpha, YRot, _lerpYRot);
        XRot = (float)Lerp(alpha, XRot, _lerpXRot);
        _lerpSteps--;
        return true;
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

        if (!StepInterpolation() && MovesFreely) {
            Position += DeltaMovement;
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
        AttackAnimO = AttackAnim;
        UpdateSwingTime();
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
