using ManagedServer.Entities.Types;
using ManagedServer.Pathfinding;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Attribute = Minecraft.Data.Generated.Attribute;
using Path = ManagedServer.Pathfinding.Path;

namespace ManagedServer.Ai.Navigation;

/// <summary>
/// How a mob gets from where it is to where it wants to be, vanilla's <c>PathNavigation</c>. A goal
/// asks for a destination and then leaves it alone; the navigation searches for a route, walks it a
/// node at a time by driving <see cref="Control.MoveControl"/>, and decides when it has given up.
/// <p/>
/// The single most important thing it does is hand the move control <b>the next node</b> rather than
/// the destination. That is not a detail: the move control's jump test is
/// <c>dy &gt; stepHeight &amp;&amp; dx*dx + dz*dz &lt; max(1, width)</c>, so a wanted position more
/// than a block away can never make a mob jump. Give it the destination and the mob walks into every
/// step and stops.
/// <p/>
/// Two independent give-up mechanisms run side by side and mean different things.
/// <see cref="DoStuckDetection"/>'s hundred tick check asks whether the mob has covered the ground
/// its speed says it should, and is what catches a mob wedged against geometry. The timeout beside
/// it asks whether <b>this one node</b> is taking more than three times as long as it should, and is
/// what catches a route that is fine except for one node the mob cannot actually make.
/// </summary>
public abstract class PathNavigation {
    /// <summary>How long a recompute has to wait after the last one, <c>MAX_TIME_RECOMPUTE</c>.</summary>
    private const int MaxTimeRecompute = 20;

    private const int StuckCheckInterval = 100;
    private const float StuckThresholdDistanceFactor = 0.25f;

    protected readonly Mob Mob;
    protected readonly World World;

    protected PathNavigation(Mob mob, World world) {
        Mob = mob;
        World = world;
        NodeEvaluator = null!;
        _pathFinder = CreatePathFinder(Mth.Floor(mob.GetAttributeBaseValue(Attribute.FollowRange) * 16.0));
    }

    private readonly PathFinder _pathFinder;

    /// <summary>
    /// The graph the search runs over, <c>getNodeEvaluator</c>. Public because the move control asks
    /// it directly what a block is, without going through a search.
    /// </summary>
    public NodeEvaluator NodeEvaluator { get; protected set; }

    protected Path? CurrentPath;

    /// <summary>How much of the mob's <c>minecraft:movement_speed</c> to travel at.</summary>
    public double SpeedModifier { get; protected set; } = 1.0;

    protected int Tick_;
    protected int LastStuckCheck;
    protected Vec3<double> LastStuckCheckPos = Vec3<double>.Zero;
    protected Vec3<int> TimeoutCachedNode = Vec3<int>.Zero;
    protected long TimeoutTimer;
    protected long LastTimeoutCheck;
    protected double TimeoutLimit;

    /// <summary>
    /// How close counts as standing on a node. Recomputed every tick from the mob's width, which is
    /// why a wide mob is allowed to be further from the centre of a node than a narrow one.
    /// </summary>
    public float MaxDistanceToWaypoint { get; protected set; } = 0.5f;

    protected bool HasDelayedRecomputation;
    protected long TimeLastRecompute;

    private Vec3<int>? _targetPos;
    private int _reachRange;
    private float _maxVisitedNodesMultiplier = 1.0f;
    private float _requiredPathLength = 16.0f;

    /// <summary>Whether the last stuck check decided the mob was going nowhere.</summary>
    public bool IsStuck { get; private set; }

    protected abstract PathFinder CreatePathFinder(int maxVisitedNodes);

    /// <summary>Whether the mob is in a state where a fresh search is worth doing at all.</summary>
    protected abstract bool CanUpdatePath();

    /// <summary>Where the mob counts as being, which is not always its position: see the ground one.</summary>
    protected abstract Vec3<double> GetTempMobPos();

    public abstract bool CanNavigateGround { get; }

    /// <summary>Whether there is nothing left to do, vanilla's <c>isDone</c>.</summary>
    public bool IsDone => CurrentPath == null || CurrentPath.IsDone;

    public bool IsInProgress => !IsDone;

    public Path? Path => CurrentPath;

    public Vec3<int>? TargetPos => _targetPos;

    public bool CanFloat {
        get => NodeEvaluator.CanFloat;
        set => NodeEvaluator.CanFloat = value;
    }

    public bool CanOpenDoors {
        get => NodeEvaluator.CanOpenDoors;
        set => NodeEvaluator.CanOpenDoors = value;
    }

    public void SetMaxVisitedNodesMultiplier(float multiplier) {
        _maxVisitedNodesMultiplier = multiplier;
    }

    public void ResetMaxVisitedNodesMultiplier() {
        _maxVisitedNodesMultiplier = 1.0f;
    }

    /// <summary>
    /// How long a route may be, and so how far the search spreads. The follow range attribute or a
    /// caller's minimum, whichever is larger, which is why a mob with a short follow range still
    /// paths a reasonable distance to somewhere it was told to go.
    /// </summary>
    protected float MaxPathLength =>
        Math.Max((float)Mob.GetAttributeValue(Attribute.FollowRange), _requiredPathLength);

    public void SetRequiredPathLength(float length) {
        _requiredPathLength = length;
        UpdatePathfinderMaxVisitedNodes();
    }

    public void UpdatePathfinderMaxVisitedNodes() {
        _pathFinder.MaxVisitedNodes = Mth.Floor(MaxPathLength * 16.0f);
    }

    #region searching

    /// <summary>
    /// Redoes the search towards the same target. Rate limited to once every
    /// <see cref="MaxTimeRecompute"/> ticks; an attempt inside that window is remembered and run on
    /// the next tick instead of being dropped, which is what stops a mob chasing a moving target
    /// from pathfinding every tick.
    /// </summary>
    public void RecomputePath() {
        if ((long)World.Server.CurrentTick - TimeLastRecompute <= MaxTimeRecompute || !CanUpdatePath()) {
            HasDelayedRecomputation = true;
            return;
        }

        if (_targetPos == null) {
            return;
        }

        CurrentPath = null;
        CurrentPath = CreatePath(_targetPos.Value, _reachRange);
        TimeLastRecompute = (long)World.Server.CurrentTick;
        HasDelayedRecomputation = false;
    }

    public Path? CreatePath(double x, double y, double z, int reachRange) {
        return CreatePath(new Vec3<double>(x, y, z).ToBlockPos(), reachRange);
    }

    public virtual Path? CreatePath(Vec3<int> pos, int reachRange) {
        return CreatePath([pos], 8, false, reachRange);
    }

    public virtual Path? CreatePath(Entity target, int reachRange) {
        return CreatePath([target.Position.ToBlockPos()], 16, true, reachRange);
    }

    protected Path? CreatePath(HashSet<Vec3<int>> targets, int radiusOffset, bool above, int reachRange) {
        return CreatePath(targets, radiusOffset, above, reachRange, MaxPathLength);
    }

    protected Path? CreatePath(HashSet<Vec3<int>> targets, int radiusOffset, bool above, int reachRange,
        float maxPathLength) {
        if (targets.Count == 0 || Mob.Position.Y < World.MinY || !CanUpdatePath()) {
            return null;
        }

        // An unfinished path to somewhere already being asked for is reused rather than recomputed,
        // which is what makes calling MoveTo every tick towards a fixed point cheap.
        if (CurrentPath is { IsDone: false } && _targetPos != null && targets.Contains(_targetPos.Value)) {
            return CurrentPath;
        }

        Path? path = _pathFinder.FindPath(World, Mob, targets, maxPathLength, reachRange,
            _maxVisitedNodesMultiplier);

        if (path != null) {
            _targetPos = path.Target;
            _reachRange = reachRange;
            ResetStuckTimeout();
        }

        return path;
    }

    #endregion

    #region driving

    public bool MoveTo(double x, double y, double z, double speedModifier) {
        return MoveTo(CreatePath(x, y, z, 1), speedModifier);
    }

    public bool MoveTo(Vec3<double> target, double speedModifier) {
        return MoveTo(target.X, target.Y, target.Z, speedModifier);
    }

    /// <summary>
    /// Heads for an entity. Vanilla recomputes towards a moving target every few ticks rather than
    /// following a stale route, which is what a chasing goal relies on.
    /// </summary>
    public virtual bool MoveTo(Entity target, double speedModifier) {
        Path? path = CreatePath(target, 1);
        return path != null && MoveTo(path, speedModifier);
    }

    /// <summary>
    /// Takes a route. Returns false for no route and for one already walked, which is what a goal
    /// reads to decide whether it can run at all.
    /// </summary>
    public bool MoveTo(Path? newPath, double speedModifier) {
        if (newPath == null) {
            CurrentPath = null;
            return false;
        }

        // An identical route is left in place rather than swapped in, so the cursor along it is not
        // reset and the mob does not walk back to a node it has passed.
        if (!newPath.SameAs(CurrentPath)) {
            CurrentPath = newPath;
        }

        if (IsDone) {
            return false;
        }

        TrimPath();

        if (CurrentPath!.NodeCount <= 0) {
            return false;
        }

        SpeedModifier = speedModifier;
        LastStuckCheck = Tick_;
        LastStuckCheckPos = GetTempMobPos();
        return true;
    }

    /// <summary>Gives up on wherever it was going.</summary>
    public virtual void Stop() {
        CurrentPath = null;
    }

    /// <summary>One step. Called from <c>Mob.ServerAiStep</c>, after the goals and before the controls.</summary>
    public virtual void Tick() {
        Tick_++;

        if (HasDelayedRecomputation) {
            RecomputePath();
        }

        if (IsDone) {
            return;
        }

        if (CanUpdatePath()) {
            FollowThePath();
        }
        else if (CurrentPath is { IsDone: false }) {
            // Airborne, so nothing is being followed. The one thing that still happens is advancing
            // past a node the mob has fallen below, so it does not try to walk back up to it on
            // landing.
            Vec3<double> mobPos = GetTempMobPos();
            Vec3<double> nodePos = CurrentPath.GetNextEntityPos(Mob);

            if (mobPos.Y > nodePos.Y && !Mob.OnGround &&
                Mth.Floor(mobPos.X) == Mth.Floor(nodePos.X) &&
                Mth.Floor(mobPos.Z) == Mth.Floor(nodePos.Z)) {
                CurrentPath.Advance();
            }
        }

        if (IsDone) {
            return;
        }

        Vec3<double> target = CurrentPath!.GetNextEntityPos(Mob);
        Mob.MoveControl.SetWantedPosition(target.X, GroundY(target), target.Z, SpeedModifier);
    }

    /// <summary>
    /// The height to aim at for a node. The node's own y over thin air, and otherwise the top of
    /// whatever is under it: that is what makes <c>dy</c> in the move control the height of the step
    /// rather than the height of the block the node sits in.
    /// </summary>
    protected double GroundY(Vec3<double> target) {
        Vec3<int> pos = target.ToBlockPos();
        return World.GetBlockOr(new Vec3<int>(pos.X, pos.Y - 1, pos.Z), Block.Air).Air
            ? target.Y
            : WalkNodeEvaluator.GetFloorLevel(new PathfindingContext(World, Mob), pos.X, pos.Y, pos.Z);
    }

    /// <summary>
    /// Advances the cursor when the mob has arrived at the current node, or when it can usefully
    /// skip to the next one, then runs the two stuck checks.
    /// </summary>
    protected void FollowThePath() {
        Vec3<double> mobPos = GetTempMobPos();

        // A mob wider than 0.75 uses half its width; a narrower one gets the remainder, so a small
        // mob needs to be closer to the centre of a node and a tiny one needs to be closest of all.
        MaxDistanceToWaypoint = Mob.BbWidth > 0.75f ? Mob.BbWidth / 2.0f : 0.75f - Mob.BbWidth / 2.0f;

        Vec3<int> node = CurrentPath!.NextNodePos;
        double dx = Math.Abs(Mob.Position.X - (node.X + 0.5));
        double dy = Math.Abs(Mob.Position.Y - node.Y);
        double dz = Math.Abs(Mob.Position.Z - (node.Z + 0.5));

        bool closeEnough = dx < MaxDistanceToWaypoint && dz < MaxDistanceToWaypoint &&
                           dy < MaxVerticalDistanceToWaypoint;

        if (closeEnough || (CanCutCorner(CurrentPath.NextNode.Type) && ShouldTargetNextNodeInDirection(mobPos))) {
            CurrentPath.Advance();
        }

        DoStuckDetection(mobPos);
    }

    /// <summary>
    /// Whether to skip to the node after this one. The test that matters is the last: the mob has
    /// walked <b>past</b> the current node when the directions to it and to the next one point
    /// opposite ways. Without it a mob overshooting a corner turns around to touch the node it
    /// missed.
    /// </summary>
    private bool ShouldTargetNextNodeInDirection(Vec3<double> mobPos) {
        if (CurrentPath!.NextNodeIndex + 1 >= CurrentPath.NodeCount) {
            return false;
        }

        Vec3<int> nodePos = CurrentPath.NextNodePos;
        Vec3<double> currentNode = new(nodePos.X + 0.5, nodePos.Y, nodePos.Z + 0.5);

        if (!CloserThan(mobPos, currentNode, 2.0)) {
            return false;
        }

        if (CanMoveDirectly(mobPos, CurrentPath.GetNextEntityPos(Mob))) {
            return true;
        }

        Vec3<int> afterPos = CurrentPath.GetNodePos(CurrentPath.NextNodeIndex + 1);
        Vec3<double> nextNode = new(afterPos.X + 0.5, afterPos.Y, afterPos.Z + 0.5);

        Vec3<double> mobToCurrent = currentNode - mobPos;
        Vec3<double> mobToNext = nextNode - mobPos;

        double toCurrentSqr = LengthSqr(mobToCurrent);
        double toNextSqr = LengthSqr(mobToNext);

        bool closerToNext = toNextSqr < toCurrentSqr;
        bool withinCurrentBlock = toCurrentSqr < 0.5;

        if (!closerToNext && !withinCurrentBlock) {
            return false;
        }

        return Dot(Normalise(mobToNext), Normalise(mobToCurrent)) < 0.0;
    }

    /// <summary>
    /// The two give-up checks. See the class summary for why there are two; the important thing is
    /// that the first one <b>stops</b> the navigation, so a goal reading <see cref="IsDone"/> is
    /// what actually notices.
    /// </summary>
    protected void DoStuckDetection(Vec3<double> mobPos) {
        if (Tick_ - LastStuckCheck > StuckCheckInterval) {
            // Squared below one, so a slow mob is held to a much lower bar than a linear scaling
            // would give it. That is deliberate: a mob at 0.1 speed genuinely covers very little.
            float effectiveSpeed = Mob.Speed >= 1.0f ? Mob.Speed : Mob.Speed * Mob.Speed;
            float threshold = effectiveSpeed * StuckCheckInterval * StuckThresholdDistanceFactor;

            if (DistanceSqr(mobPos, LastStuckCheckPos) < threshold * threshold) {
                IsStuck = true;
                Stop();
            }
            else {
                IsStuck = false;
            }

            LastStuckCheck = Tick_;
            LastStuckCheckPos = mobPos;
        }

        if (CurrentPath is not { IsDone: false }) {
            return;
        }

        Vec3<int> node = CurrentPath.NextNodePos;
        long time = (long)World.Server.CurrentTick;

        if (node.Equals(TimeoutCachedNode)) {
            TimeoutTimer += time - LastTimeoutCheck;
        }
        else {
            TimeoutCachedNode = node;
            double distance = Distance(mobPos, new Vec3<double>(node.X + 0.5, node.Y, node.Z + 0.5));
            TimeoutLimit = Mob.Speed > 0.0f ? distance / Mob.Speed * 20.0 : 0.0;
        }

        if (TimeoutLimit > 0.0 && TimeoutTimer > TimeoutLimit * 3.0) {
            ResetStuckTimeout();
            Stop();
        }

        LastTimeoutCheck = time;
    }

    private void ResetStuckTimeout() {
        TimeoutCachedNode = Vec3<int>.Zero;
        TimeoutTimer = 0L;
        TimeoutLimit = 0.0;
        IsStuck = false;
    }

    #endregion

    #region path shaping

    /// <summary>
    /// Fixes up a freshly found route. Vanilla lifts nodes out of cauldrons, whose collision shape
    /// leaves a hole a mob would otherwise be routed into.
    /// </summary>
    protected virtual void TrimPath() {
        if (CurrentPath == null) {
            return;
        }

        for (int i = 0; i < CurrentPath.NodeCount; i++) {
            Node node = CurrentPath.GetNode(i);
            Node? next = i + 1 < CurrentPath.NodeCount ? CurrentPath.GetNode(i + 1) : null;

            if (!IsCauldron(node)) {
                continue;
            }

            CurrentPath.ReplaceNode(i, node.CloneAndMove(node.X, node.Y + 1, node.Z));

            if (next != null && node.Y >= next.Y) {
                CurrentPath.ReplaceNode(i + 1, node.CloneAndMove(next.X, node.Y + 1, next.Z));
            }
        }
    }

    private static readonly Identifier CauldronsTag = "minecraft:cauldrons";

    private bool IsCauldron(Node node) {
        Identifier block = World.GetBlockOr(new Vec3<int>(node.X, node.Y, node.Z), Block.Air).Identifier;

        if (!World.Server.Registry.Blocks.Tags.Contains(CauldronsTag)) {
            return false;
        }

        foreach (Identifier value in World.Server.Registry.Blocks.Tags[CauldronsTag].GetValueIds(World.Server.Registry)) {
            if (value.Equals(block)) {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Whether the mob can head straight for a point instead of following the route. False here, and
    /// overridden only by the flying and water navigations; a walking mob always follows its nodes.
    /// </summary>
    protected virtual bool CanMoveDirectly(Vec3<double> from, Vec3<double> to) {
        return false;
    }

    /// <summary>
    /// Whether the mob may skip past a node of this kind rather than standing on it. Anything next
    /// to danger is excluded, because the node exists precisely to keep the mob on the safe square,
    /// and so is a door, which has to be walked through rather than cut.
    /// </summary>
    public bool CanCutCorner(PathType type) {
        return type != PathType.FireInNeighbor && type != PathType.DamagingInNeighbor &&
               type != PathType.WalkableDoor;
    }

    /// <summary>How far off a node's y the mob may be and still count as on it.</summary>
    public virtual float MaxVerticalDistanceToWaypoint => 1.0f;

    /// <summary>
    /// Whether a block change near the route is worth recomputing for, <c>shouldRecomputePath</c>.
    /// The radius is the number of nodes left, so a change close to the end of a long route counts
    /// and the same change beside a nearly finished one does not.
    /// </summary>
    public bool ShouldRecomputePath(Vec3<int> pos) {
        if (HasDelayedRecomputation) {
            return false;
        }

        if (CurrentPath is not { IsDone: false } || CurrentPath.NodeCount == 0) {
            return false;
        }

        Node end = CurrentPath.EndNode!;
        Vec3<double> middle = new(
            (end.X + Mob.Position.X) / 2.0,
            (end.Y + Mob.Position.Y) / 2.0,
            (end.Z + Mob.Position.Z) / 2.0);

        int radius = CurrentPath.NodeCount - CurrentPath.NextNodeIndex;
        Vec3<double> centre = new(pos.X + 0.5, pos.Y + 0.5, pos.Z + 0.5);
        return DistanceSqr(centre, middle) < (double)radius * radius;
    }

    /// <summary>Whether a position is somewhere a mob could be left standing.</summary>
    public virtual bool IsStableDestination(Vec3<int> pos) {
        return World.GetBlockOr(new Vec3<int>(pos.X, pos.Y - 1, pos.Z), Block.Air).Solid;
    }

    #endregion

    private static double LengthSqr(Vec3<double> v) => v.X * v.X + v.Y * v.Y + v.Z * v.Z;

    private static double Dot(Vec3<double> a, Vec3<double> b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

    private static Vec3<double> Normalise(Vec3<double> v) {
        double length = Math.Sqrt(LengthSqr(v));
        return length < 1.0E-4 ? Vec3<double>.Zero : new Vec3<double>(v.X / length, v.Y / length, v.Z / length);
    }

    private static double DistanceSqr(Vec3<double> a, Vec3<double> b) {
        double dx = a.X - b.X, dy = a.Y - b.Y, dz = a.Z - b.Z;
        return dx * dx + dy * dy + dz * dz;
    }

    private static double Distance(Vec3<double> a, Vec3<double> b) => Math.Sqrt(DistanceSqr(a, b));

    private static bool CloserThan(Vec3<double> a, Vec3<double> b, double distance) {
        return DistanceSqr(a, b) < distance * distance;
    }
}
