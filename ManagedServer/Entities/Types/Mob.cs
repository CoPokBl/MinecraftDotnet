using ManagedServer.Ai.Control;
using ManagedServer.Ai.Goals;
using ManagedServer.Ai.Navigation;
using ManagedServer.Ai.Sensing;
using ManagedServer.Damage;
using ManagedServer.Fluids;
using Minecraft.Physics;
using ManagedServer.Worlds;
using Minecraft.Data.Entities;
using Minecraft.Data.Generated;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta.Types;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;
using Minecraft.Fluids;

namespace ManagedServer.Entities.Types;

/// <summary>
/// A living entity that decides things for itself, vanilla's <c>Mob</c>. Everything the AI needs hangs
/// off here: two goal selectors, a navigation, four controls, what it is fighting, and the movement
/// inputs it writes for the travel step to spend.
/// <p/>
/// <b>All of this is core rather than a feature</b>, on the same rule as <c>LivingEntity.Effects</c>
/// and <c>Entity.FallDistance</c>: the state is kept whatever is registered, and what fills it in is
/// somebody's choice. A mob nobody gave goals to stands still. <c>VanillaMobAiFeature</c> is what
/// installs vanilla's behaviour, and a game that wants its own registers nothing and fills in
/// <see cref="Goals"/> itself.
/// <p/>
/// The AI step runs from inside <c>EntityPhysics</c> rather than from a feature, because vanilla runs
/// it inside <c>LivingEntity.aiStep</c> six statements before <c>travel</c> reads the inputs it wrote.
/// Splitting those across two tick listeners would make correctness depend on which registered first.
/// </summary>
public class Mob : LivingEntity {
    public Mob(IEntityType type, LivingEntityMeta? meta = null) : base(type, meta) {
        // Entity's constructor guesses a meta from the type and lands on the plain EntityMeta for
        // anything it has no case for, which is every mob. The mob flags byte lives on MobMeta, so
        // without this NoAi and Aggressive would have nowhere to go and would silently do nothing.
        if (Meta is not MobMeta) {
            Meta = new MobMeta();
        }

        MoveControl = CreateMoveControl();
        LookControl = CreateLookControl();
        JumpControl = new JumpControl(this);
        BodyRotationControl = CreateBodyRotationControl();
        Sensing = new Sensing(this);
    }

    #region ai_apparatus

    /// <summary>
    /// What the mob is doing. Lower priority numbers win; see <see cref="GoalSelector"/> for the
    /// arbitration rules, several of which are not what they look like.
    /// </summary>
    public GoalSelector Goals { get; } = new();

    /// <summary>
    /// What the mob is fighting. Separate from <see cref="Goals"/> and arbitrated separately, so a
    /// mob can pick a target and walk somewhere unrelated in the same tick.
    /// </summary>
    public GoalSelector TargetGoals { get; } = new();

    /// <summary>
    /// Created on entering a world, since it needs one. Reading it before the mob is spawned throws,
    /// which is deliberate: a goal added before the mob has a world would otherwise silently do
    /// nothing.
    /// </summary>
    public PathNavigation Navigation {
        get => field ?? throw new InvalidOperationException(
            "Navigation does not exist until the mob is in a world; add goals after SetWorld.");
        private set;
    }

    public MoveControl MoveControl { get; }
    public LookControl LookControl { get; }
    public JumpControl JumpControl { get; }
    public BodyRotationControl BodyRotationControl { get; }
    public Sensing Sensing { get; }

    /// <summary>
    /// What the mob is trying to hurt. Setting it is all that happens here; a goal is what acts on it.
    /// <p/>
    /// Both ends go through <see cref="AsValidTarget"/>, as vanilla's <c>setTarget</c> and
    /// <c>getTarget</c> do: a target that died, left the world or went into creative reads as null
    /// without anything having to clear it, so a goal cannot end up chasing a corpse.
    /// </summary>
    public LivingEntity? Target {
        get => AsValidTarget(field);
        set => field = AsValidTarget(value);
    }

    /// <summary><c>Mob.getTargetUnchecked</c>: what was last set, valid or not.</summary>
    public LivingEntity? TargetUnchecked => field;

    /// <summary><c>Mob.asValidTarget</c>.</summary>
    protected virtual LivingEntity? AsValidTarget(LivingEntity? target) {
        if (target == null) {
            return null;
        }

        return CanAttack(target) ? target : null;
    }

    /// <summary>
    /// Turns the whole AI off without removing anything, vanilla's <c>NoAI</c>. The mob still falls and
    /// still takes damage; it just stops deciding.
    /// <p/>
    /// It rides on the mob flags byte the client also reads, so it survives a metadata resend.
    /// </summary>
    public bool NoAi {
        get => (MobFlags & MobFlag.NoAi) != 0;
        set => SetMobFlag(MobFlag.NoAi, value);
    }

    /// <summary>
    /// Vanilla's <c>isAggressive</c>, which is what makes the client hold a zombie's arms out. A melee
    /// goal sets it while it is chasing, and nothing on the server reads it.
    /// </summary>
    public bool Aggressive {
        get => (MobFlags & MobFlag.IsAggressive) != 0;
        set => SetMobFlag(MobFlag.IsAggressive, value);
    }

    public bool LeftHanded {
        get => (MobFlags & MobFlag.IsLeftHanded) != 0;
        set => SetMobFlag(MobFlag.IsLeftHanded, value);
    }

    private MobFlag MobFlags => Meta is MobMeta mob ? mob.MobFlags ?? MobFlag.None : MobFlag.None;

    /// <summary>
    /// Sets one bit of the mob flags byte and leaves the others alone. A mob whose metadata is not a
    /// <see cref="MobMeta"/> has nowhere to put the bit, so the write is dropped rather than throwing:
    /// an entity type the generator gave a narrower meta to still has to be constructible as a
    /// <see cref="Mob"/>.
    /// </summary>
    private void SetMobFlag(MobFlag flag, bool value) {
        if (Meta is not MobMeta meta) {
            return;
        }

        MobFlag current = meta.MobFlags ?? MobFlag.None;
        MobFlag updated = value ? current | flag : current & ~flag;

        if (updated == current) {
            return;
        }

        Meta = meta with {
            MobFlags = updated
        };
    }

    /// <summary>
    /// Where the mob's body points, vanilla's <c>yBodyRot</c>, as distinct from
    /// <see cref="Entity.Yaw"/> (where the move control is steering) and <see cref="Entity.HeadYaw"/>
    /// (where it is looking).
    /// <p/>
    /// It is never sent: the client runs its own body rotation control. It matters here only because
    /// the head is clamped against it.
    /// </summary>
    public Angle BodyYaw { get; set; }

    /// <summary>How far the head may turn from the body, <c>getMaxHeadYRot</c>.</summary>
    public virtual float MaxHeadYRot => 75.0f;

    /// <summary>How far the head may tilt, <c>getMaxHeadXRot</c>.</summary>
    public virtual float MaxHeadXRot => 40.0f;

    /// <summary>How fast the head turns, in degrees a tick, <c>getHeadRotSpeed</c>.</summary>
    public virtual float HeadRotSpeed => 10.0f;

    /// <summary>
    /// <c>Mob.setSpeed</c>, which is not just the field: it writes <see cref="LivingEntity.Zza"/> to
    /// the same value.
    /// <p/>
    /// <b>This is the whole of how a mob walks forwards.</b> <see cref="Control.MoveControl"/>'s MOVE_TO
    /// branch sets a yaw and a speed and never touches the forward input, so without this override a
    /// mob turns towards its destination on the spot and stays there. It is a one line override in the
    /// jar and it is easy to read past.
    /// </summary>
    public override float Speed {
        get => base.Speed;
        set {
            base.Speed = value;
            Zza = value;
        }
    }

    #endregion

    #region pathfinding

    /// <summary>
    /// What this mob thinks of each kind of block, on top of <see cref="PathTypeMalus"/>. Empty for
    /// most mobs; a zombie villager overrides doors, a spider overrides cobwebs, and a fire immune
    /// mob overrides fire.
    /// <p/>
    /// Set through <see cref="SetPathfindingMalus"/> rather than written directly, so the
    /// "unset means the default" rule stays in one place.
    /// </summary>
    private readonly Dictionary<PathType, float> _pathfindingMalus = [];

    /// <summary>
    /// <c>Mob.getPathfindingMalus</c>. <b>A negative answer means impassable</b>, and that is the
    /// only test the node evaluator makes: it never asks whether a block is solid, only what this
    /// costs. So making a mob walk through fire is setting this, not overriding a shape.
    /// <p/>
    /// Vanilla also lets a mob inherit its vehicle's answers. Nothing here rides anything, so that
    /// branch is left out.
    /// </summary>
    public float GetPathfindingMalus(PathType type) {
        return _pathfindingMalus.TryGetValue(type, out float malus) ? malus : PathTypeMalus.Of(type);
    }

    public void SetPathfindingMalus(PathType type, float malus) {
        _pathfindingMalus[type] = malus;
    }

    /// <summary>
    /// How far up the mob can step without jumping, <c>Entity.maxUpStep</c>. The
    /// <c>minecraft:step_height</c> attribute, which is 0.6 for most mobs, so a full block needs a
    /// jump and a slab does not.
    /// </summary>
    public float MaxUpStep => (float)GetAttributeValue(Attribute.StepHeight);

    /// <summary>
    /// How far the pathfinder will let the mob drop, <c>Mob.getMaxFallDistance</c>. Three blocks
    /// normally, and more when it has a target: a mob chasing something will spend health it can
    /// spare on a drop it would otherwise route around.
    /// <p/>
    /// <b>Divergence:</b> vanilla subtracts <c>(3 - difficulty) * 4</c> from what it is willing to
    /// spend, and there is no difficulty setting here. Normal (id 2) is used, which is vanilla's
    /// default and costs four points of the allowance; replace the constant with the real value if
    /// difficulty is ever modelled.
    /// </summary>
    public virtual int MaxFallDistance {
        get {
            if (Target == null) {
                return ComfortableFallDistance(0.0f);
            }

            const int normalDifficultyId = 2;
            int sacrifice = (int)(Health - (float)GetAttributeValue(Attribute.MaxHealth) * 0.33f);
            sacrifice -= (3 - normalDifficultyId) * 4;

            return ComfortableFallDistance(Math.Max(sacrifice, 0));
        }
    }

    /// <summary><c>LivingEntity.getComfortableFallDistance</c>.</summary>
    private static int ComfortableFallDistance(float allowedDamage) {
        return Mth.Floor(allowedDamage + 3.0f);
    }

    /// <summary>
    /// Whether the mob walks on top of a fluid rather than through it,
    /// <c>LivingEntity.canStandOnFluid</c>. False for everything but a strider on lava; overridden
    /// rather than read from anything, as upstream does.
    /// </summary>
    public virtual bool CanStandOnFluid(FluidKind fluid) {
        return false;
    }

    /// <summary>Hooks around a search, <c>Mob.onPathfindingStart</c>. Empty upstream too.</summary>
    public virtual void OnPathfindingStart() { }

    public virtual void OnPathfindingDone() { }

    #endregion

    #region melee

    /// <summary>
    /// How far past its own box a mob can reach, <c>Mob.DEFAULT_ATTACK_REACH</c>. Vanilla writes it as
    /// <c>Math.sqrt(2.04F) - 0.6F</c>, so the square root is taken of a float and the subtraction is
    /// done in double; written the same way here because the value is compared against a box edge.
    /// </summary>
    public static readonly double DefaultAttackReach = Math.Sqrt(2.04f) - 0.6f;

    /// <summary>
    /// <c>Mob.isWithinMeleeAttackRange</c>: whether the mob's box, grown horizontally by its reach,
    /// touches the target's.
    /// <p/>
    /// Note what this is <b>not</b>: it is not a distance between two points, so a tall target is
    /// reachable from further out in the sense that any part of it will do, and a mob standing on top
    /// of one can hit it. Vanilla also reads a <c>minecraft:attack_range</c> component off the item in
    /// use for a minimum range; nothing here holds an item in use, so only the default is modelled.
    /// </summary>
    public bool IsWithinMeleeAttackRange(LivingEntity target) {
        Box hitbox = new Box(target.BoundingBox).Translate(target.Position);
        return AttackBoundingBox(DefaultAttackReach).Intersects(hitbox);
    }

    /// <summary>
    /// <c>Mob.getAttackBoundingBox</c>. Grown on x and z only: reach does not go upwards. The vehicle
    /// branch is left out, since nothing here rides anything.
    /// </summary>
    protected Box AttackBoundingBox(double horizontalExpansion) {
        return new Box(BoundingBox).Translate(Position).Inflate(horizontalExpansion, 0.0, horizontalExpansion);
    }

    /// <summary>
    /// Hits something, <c>Mob.doHurtTarget</c>. Returns whether the hit landed, which the caller needs
    /// because the knockback only happens if it did.
    /// <p/>
    /// The damage is the <c>minecraft:attack_damage</c> attribute, so a mob with no modifier on it
    /// deals the type's default. Vanilla runs the weapon's enchantments over both the damage and the
    /// knockback through <c>EnchantmentHelper</c>; only <c>minecraft:attributes</c> and
    /// <c>minecraft:damage_protection</c> have parsers here (see <c>IEnchantmentEffect</c>), and
    /// neither is one of those, so there is nothing to run and the raw attribute values are used. That
    /// gap closes on its own when the effects are added.
    /// </summary>
    public virtual bool DoHurtTarget(World world, LivingEntity target) {
        float damage = (float)GetAttributeValue(Attribute.AttackDamage);

        DamageSource source = new(DamageType.MobAttack) {
            Attacker = this,
            // Both ends are required: the direction of the hit is read off Direct, and a shield blocks
            // nothing without one.
            Direct = this,
            Weapon = ItemStack.Air
        };

        bool hurt = target.Damage(source, damage);

        if (hurt) {
            CauseExtraKnockback(target, Knockback(), damage);
            LastHurtMob = target;
        }

        return hurt;
    }

    /// <summary>
    /// <c>LivingEntity.getKnockback</c>: the <c>minecraft:attack_knockback</c> attribute, <b>halved</b>.
    /// The halving is upstream, not a tuning choice, and it is why the default of zero means a hit
    /// still moves nothing extra beyond what the damage itself does.
    /// </summary>
    protected float Knockback() {
        return (float)GetAttributeValue(Attribute.AttackKnockback) / 2.0f;
    }

    /// <summary>
    /// <c>LivingEntity.causeExtraKnockback</c>. The direction is the attacker's <b>yaw</b>, not the
    /// line between the two, so a mob that has not finished turning shoves at an angle; that is
    /// vanilla's behaviour and the sine table is what the client agrees with.
    /// </summary>
    protected void CauseExtraKnockback(LivingEntity target, float knockback, float damage) {
        if (knockback <= 0.0f) {
            return;
        }

        float yaw = (float)Yaw.Degrees;
        target.Knockback(knockback, Mth.Sin(yaw * (float)(Math.PI / 180.0)), -Mth.Cos(yaw * (float)(Math.PI / 180.0)));

        // The attacker is slowed by the hit it landed, which is what stops a mob shoving its target
        // along in front of it forever.
        Velocity = new Vec3<double>(Velocity.X * 0.6, Velocity.Y, Velocity.Z * 0.6);
    }

    /// <summary>The last thing this mob hit, <c>LivingEntity.lastHurtMob</c>.</summary>
    public LivingEntity? LastHurtMob { get; set; }

    /// <summary><c>Mob.swingForAttack</c>: the swing of the held item's attack animation.</summary>
    public void SwingForAttack(Hand hand) {
        Swing(hand, GetItemInHand(hand).Get(DataComponent.AttackAnimation), false);
    }

    #endregion

    #region ai_step

    /// <summary>
    /// <c>Mob.serverAiStep</c>, which is <c>final</c> upstream and is effectively sealed here: override
    /// <see cref="CustomServerAiStep"/> instead. Called from <c>EntityPhysics.AiStep</c> at vanilla's
    /// position, which is what makes the controls' writes land on the same tick's travel.
    /// </summary>
    public void ServerAiStep(World world) {
        NoActionTime++;
        Sensing.Tick();

        // Reselection is halved and offset by entity id, so a crowd of mobs does not all reconsider on
        // the same tick. The tickCount > 1 exception is what lets a freshly spawned mob pick a goal
        // immediately instead of possibly waiting a tick.
        if ((TickCount + NetId) % 2 != 0 && TickCount > 1) {
            TargetGoals.TickRunningGoals(false);
            Goals.TickRunningGoals(false);
        }
        else {
            TargetGoals.Tick();
            Goals.Tick();
        }

        Navigation.Tick();
        CustomServerAiStep(world);

        MoveControl.Tick();
        LookControl.Tick();
        JumpControl.Tick();
    }

    /// <summary>
    /// The extension point <c>Mob.customServerAiStep</c> is. It runs after the navigation and before
    /// the controls, which is where anything wanting to override what a goal just decided has to sit.
    /// The brain system hangs off here.
    /// </summary>
    protected virtual void CustomServerAiStep(World world) { }

    /// <summary>
    /// <c>Mob.tickHeadTurn</c>, which runs after the move rather than inside the AI step because
    /// the body rotation is decided from how far the mob actually got.
    /// </summary>
    public void TickHeadTurn() {
        BodyRotationControl.Tick();
    }

    #endregion

    #region installation

    /// <summary>
    /// Where a subclass puts its goals. Vanilla calls the equivalent from the constructor, which does
    /// not port: a base constructor calling a virtual runs before the derived fields exist, and the
    /// navigation needs a world the entity does not have yet. It is called from
    /// <see cref="SetWorld"/> instead, once.
    /// </summary>
    protected virtual void RegisterGoals() { }

    /// <summary>
    /// Which navigation the mob uses. Override to change how it moves: the swimming, flying and
    /// climbing mobs each want a different one, and a game implementation that does not want A* at
    /// all can return something cheaper.
    /// </summary>
    protected virtual PathNavigation CreateNavigation(World world) {
        return new GroundPathNavigation(this, world);
    }

    protected virtual MoveControl CreateMoveControl() {
        return new MoveControl(this);
    }

    protected virtual LookControl CreateLookControl() {
        return new LookControl(this);
    }

    protected virtual BodyRotationControl CreateBodyRotationControl() {
        return new BodyRotationControl(this);
    }

    /// <summary>Whether <see cref="RegisterGoals"/> has run, so a mob moved between worlds keeps its goals.</summary>
    private bool _goalsRegistered;

    /// <summary>
    /// Runs from <see cref="Entity.SetWorld"/> before <c>EntitySpawnEvent</c> is called, which is what
    /// lets <c>VanillaMobAiFeature</c> add goals from that event and find the navigation already
    /// built.
    /// </summary>
    protected override void AfterEnteringWorld(World world) {
        base.AfterEnteringWorld(world);

        // The navigation is per world, so it is rebuilt on every move; the goals are not, and are
        // installed once.
        Navigation = CreateNavigation(world);

        if (_goalsRegistered) {
            return;
        }

        _goalsRegistered = true;
        RegisterGoals();
    }

    #endregion
}
