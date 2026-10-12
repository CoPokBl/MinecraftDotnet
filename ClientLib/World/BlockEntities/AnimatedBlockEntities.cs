using ClientLib.Maths;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace ClientLib.World.BlockEntities;

/// <summary>
/// What a spawner shows turning inside its cage: the <c>entity</c> compound of its spawn data. A new
/// tag is a new display entity, as <c>BaseSpawner.load</c> drops the one it had.
/// </summary>
public interface ISpinningMobHolder {
    /// <summary>Null when there is no mob to show, as an entity tag without an <c>id</c> is.</summary>
    CompoundTag? DisplayEntity { get; }

    /// <summary>The spin this tick and the last, in the units <c>extractSpawnerData</c> multiplies by ten.</summary>
    double Spin { get; }

    double OSpin { get; }
}

/// <summary><c>SpawnerBlockEntity</c> and its <c>BaseSpawner</c>.</summary>
public sealed class SpawnerBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state), ISpinningMobHolder {
    private int _spawnDelay = 20, _minSpawnDelay = 200, _requiredPlayerRange = 16;

    public CompoundTag? DisplayEntity { get; private set; }
    public double Spin { get; private set; }
    public double OSpin { get; private set; }

    /// <summary><c>BaseSpawner.load</c>, as far as the client reads it.</summary>
    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        _spawnDelay = tag["Delay"] is { } delay ? delay.GetShort() : 20;
        if (tag["SpawnData"] is CompoundTag spawnData) {
            DisplayEntity = EntityToSpawn(spawnData);
        }
        _minSpawnDelay = tag["MinSpawnDelay"] is { } min ? min.GetShort() : 200;
        _requiredPlayerRange = tag["RequiredPlayerRange"] is { } range ? range.GetShort() : 16;
    }

    internal static CompoundTag? EntityToSpawn(CompoundTag spawnData) =>
        spawnData["entity"] is CompoundTag entity && entity["id"] is StringTag { Value.Length: > 0 } ? entity : null;

    /// <summary><c>BaseSpawner.onEventTriggered</c>.</summary>
    public override bool TriggerEvent(int b0, int b1) {
        if (b0 == 1) {
            _spawnDelay = _minSpawnDelay;
            return true;
        }
        return false;
    }

    public override bool HasClientTicker => true;

    /// <summary><c>BaseSpawner.clientTick</c>, without its smoke and flame.</summary>
    public override void Tick(BlockEntityTickContext context) {
        if (!context.HasNearbyAlivePlayer(X + 0.5, Y + 0.5, Z + 0.5, _requiredPlayerRange)) {
            OSpin = Spin;
        }
        else if (DisplayEntity != null) {
            if (_spawnDelay > 0) {
                _spawnDelay--;
            }
            OSpin = Spin;
            Spin = (Spin + 1000.0F / (_spawnDelay + 200.0F)) % 360.0;
        }
    }
}

/// <summary><c>TrialSpawnerBlockEntity</c>: the mob it shows while waiting for or fighting players.</summary>
public sealed class TrialSpawnerBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state), ISpinningMobHolder {
    private long _nextMobSpawnsAt;
    private CompoundTag? _entity;

    public double Spin { get; private set; }
    public double OSpin { get; private set; }

    /// <summary><c>getOrCreateDisplayEntity</c>: nothing in a state without a spinning mob.</summary>
    public CompoundTag? DisplayEntity => HasSpinningMob(SpawnerState) ? _entity : null;

    public TrialSpawnerBlock.TrialSpawnerState SpawnerState =>
        State is TrialSpawnerBlock spawner ? spawner.TrialSpawnerStateValue : TrialSpawnerBlock.TrialSpawnerState.Inactive;

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        _nextMobSpawnsAt = tag["next_mob_spawns_at"] is { } at ? at.GetLong() : 0;
        _entity = tag["spawn_data"] is CompoundTag spawnData ? SpawnerBlockEntity.EntityToSpawn(spawnData) : null;
    }

    /// <summary><c>TrialSpawnerState.hasSpinningMob</c>.</summary>
    public static bool HasSpinningMob(TrialSpawnerBlock.TrialSpawnerState state) =>
        state is TrialSpawnerBlock.TrialSpawnerState.WaitingForPlayers or TrialSpawnerBlock.TrialSpawnerState.Active;

    /// <summary><c>TrialSpawnerState.spinningMobSpeed</c>.</summary>
    private static double SpinningMobSpeed(TrialSpawnerBlock.TrialSpawnerState state) => state switch {
        TrialSpawnerBlock.TrialSpawnerState.WaitingForPlayers => 200.0,
        TrialSpawnerBlock.TrialSpawnerState.Active => 1000.0,
        _ => -1.0
    };

    public override bool HasClientTicker => true;

    /// <summary><c>TrialSpawner.tickClient</c>, without its particles and sounds.</summary>
    public override void Tick(BlockEntityTickContext context) {
        TrialSpawnerBlock.TrialSpawnerState current = SpawnerState;
        if (HasSpinningMob(current)) {
            double spawnDelay = Math.Max(0L, _nextMobSpawnsAt - context.Level.GameTime);
            OSpin = Spin;
            Spin = (Spin + SpinningMobSpeed(current) / (spawnDelay + 200.0)) % 360.0;
        }
    }
}

/// <summary><c>VaultBlockEntity</c>: the shared data's display item, and <c>VaultClientData</c>'s spin.</summary>
public sealed class VaultBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public ItemStack DisplayItem { get; private set; } = ItemStack.Air;
    public float CurrentSpin { get; private set; }
    public float PreviousSpin { get; private set; }

    protected override void LoadAdditional(CompoundTag tag, MinecraftRegistry registry) {
        if (tag["shared_data"] is CompoundTag shared) {
            DisplayItem = shared["display_item"] is { } item ? ItemDisplayBlockEntity.ReadStack(item, registry) ?? ItemStack.Air : ItemStack.Air;
        }
    }

    public override bool HasClientTicker => true;

    /// <summary><c>VaultBlockEntity.Client.tick</c>: <c>updateDisplayItemSpin</c>; the particles and sounds are left out.</summary>
    public override void Tick(BlockEntityTickContext context) {
        PreviousSpin = CurrentSpin;
        CurrentSpin = Minecraft.Schemas.Mth.WrapDegrees(CurrentSpin + 10.0F);
    }
}

/// <summary>An entity a moving piston on this client moves: one whose movement the client runs itself.</summary>
public interface IPistonPushable {
    Box BoundingBox { get; }
    Vec3d Position { get; }
    Vec3d DeltaMovement { get; set; }
    bool OnGround { get; }

    /// <summary><c>Entity.isSupportedBy</c>.</summary>
    bool IsSupportedBy(int x, int y, int z);

    /// <summary>
    /// What <c>PistonMovingBlockEntity.moveEntityByPiston</c> calls on the entity: <c>move(MoverType.PISTON)</c>,
    /// then <c>applyEffectsFromBlocks</c> from where it was, then <c>removeLatestMovementRecording</c>.
    /// </summary>
    void MoveByPiston(Vec3d delta);
}

/// <summary>
/// <c>PistonMovingBlockEntity</c>: a block on its way somewhere, drawn offset by the progress, which
/// collides where it is drawn and pushes what it runs into. The client only ever has the ones its own
/// <see cref="PistonEvents"/> make, as <c>MovingPistonBlock.newBlockEntity</c> makes none.
/// </summary>
public sealed class PistonMovingBlockEntity : ClientBlockEntity {
    /// <summary><c>NOCLIP</c>: the push under way, whose own moving blocks do not collide with what they push.</summary>
    [ThreadStatic] private static Cardinal? _noClip;

    private float _progress, _progressO;
    private int _deathTicks;

    public IBlock MovedState { get; }
    public Cardinal Direction { get; }
    public bool Extending { get; }
    public bool IsSourcePiston { get; }

    private PistonMovingBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state, IBlock movedState, Cardinal direction, bool extending,
        bool isSourcePiston) : base(type, x, y, z, state) {
        MovedState = movedState;
        Direction = direction;
        Extending = extending;
        IsSourcePiston = isSourcePiston;
    }

    /// <summary><c>MovingPistonBlock.newMovingBlockEntity</c>.</summary>
    public static PistonMovingBlockEntity Moving(IBlockEntityType type, int x, int y, int z, IBlock state, IBlock movedState, Cardinal direction, bool extending,
        bool isSourcePiston) => new(type, x, y, z, state, movedState, direction, extending, isSourcePiston);

    public float GetProgress(float a) {
        if (a > 1.0F) {
            a = 1.0F;
        }
        return _progressO + a * (_progress - _progressO);
    }

    /// <summary><c>getXOff</c>, <c>getYOff</c> and <c>getZOff</c> together.</summary>
    public (float X, float Y, float Z) GetOffset(float a) {
        (int sx, int sy, int sz) = DirectionUtil.Step(Direction);
        float extended = GetExtendedProgress(GetProgress(a));
        return (sx * extended, sy * extended, sz * extended);
    }

    private float GetExtendedProgress(float progress) => Extending ? progress - 1.0F : 1.0F - progress;

    /// <summary><c>getMovementDirection</c>.</summary>
    public Cardinal MovementDirection => Extending ? Direction : Opposite(Direction);

    public static Cardinal Opposite(Cardinal direction) => direction switch {
        Cardinal.Down => Cardinal.Up,
        Cardinal.Up => Cardinal.Down,
        Cardinal.North => Cardinal.South,
        Cardinal.South => Cardinal.North,
        Cardinal.West => Cardinal.East,
        _ => Cardinal.West
    };

    public override bool HasClientTicker => true;

    /// <summary>
    /// <c>PistonMovingBlockEntity.tick</c> on the client. The block left behind is not reshaped against
    /// its new neighbours (<c>updateFromNeighbourShapes</c>): the server's block update that follows does that.
    /// </summary>
    public override void Tick(BlockEntityTickContext context) {
        _progressO = _progress;
        if (_progressO >= 1.0F) {
            if (_deathTicks < 5) {
                _deathTicks++;
                return;
            }
            ClientLevel level = context.Level;
            level.RemoveBlockEntity(X, Y, Z);
            if (level.GetBlock(X, Y, Z).Identifier.Equals(Block.MovingPiston.Identifier)) {
                IBlock newState = MovedState is IWaterlogged { Waterlogged: true } waterlogged ? waterlogged.WithWaterlogged(false) : MovedState;
                level.SetState(X, Y, Z, (ushort)newState.StateId);
            }
            return;
        }
        float newProgress = _progress + 0.5F;
        MoveCollidedEntities(context, newProgress);
        MoveStuckEntities(context, newProgress);
        _progress = newProgress;
        if (_progress >= 1.0F) {
            _progress = 1.0F;
        }
    }

    private static bool IsPistonBase(IBlock state) => state is PistonBlock or StickyPistonBlock;

    private static Cardinal FacingOf(IBlock state) => state is IDirectional directional ? directional.Facing : Cardinal.Down;

    private static Box[] CollisionOf(MinecraftRegistry registry, IBlock state) => BlockPhysicsData.Get(registry, state.StateId).Collision;

    /// <summary><c>getCollisionShape</c>, in the block's own coordinates.</summary>
    public Box[] CollisionShape(MinecraftRegistry registry) {
        Box[] pistonHead = !Extending && IsSourcePiston && IsPistonBase(MovedState)
            ? CollisionOf(registry, MovedState switch {
                PistonBlock piston => piston with { Extended = true },
                StickyPistonBlock piston => piston with { Extended = true },
                _ => MovedState
            })
            : [];
        if (_progress < 1.0 && _noClip == MovementDirection) {
            return pistonHead;
        }
        IBlock blockState = IsSourcePiston ? Block.PistonHead with { Facing = Direction, Short = Extending != 1.0F - _progress < 0.25F } : MovedState;
        Box[] moved = CollisionOf(registry, blockState);
        (int sx, int sy, int sz) = DirectionUtil.Step(Direction);
        float extendedProgress = GetExtendedProgress(_progress);
        double dx = sx * extendedProgress, dy = sy * extendedProgress, dz = sz * extendedProgress;
        Box[] shape = new Box[pistonHead.Length + moved.Length];
        pistonHead.CopyTo(shape, 0);
        for (int i = 0; i < moved.Length; i++) {
            shape[pistonHead.Length + i] = moved[i].Translate(dx, dy, dz);
        }
        return shape;
    }

    /// <summary><c>getCollisionRelatedBlockState</c>: a retracting piston's head, shortened once it is under way.</summary>
    private IBlock CollisionRelatedBlockState => !Extending && IsSourcePiston && IsPistonBase(MovedState)
        ? Block.PistonHead with {
            Short = _progress > 0.25F,
            TypeValue = MovedState is StickyPistonBlock ? PistonHeadBlock.Type.Sticky : PistonHeadBlock.Type.Normal,
            Facing = FacingOf(MovedState)
        }
        : MovedState;

    /// <summary><c>moveCollidedEntities</c>. The local player is never a <c>ServerPlayer</c>, so a slime block flings it too.</summary>
    private void MoveCollidedEntities(BlockEntityTickContext context, float newProgress) {
        Cardinal movement = MovementDirection;
        double deltaProgress = newProgress - _progress;
        // VoxelShape.toAabbs: the shape's boxes before they are split for collisions.
        Box[] shapeAabbs = BlockPhysicsData.ShapeBoxesOf(CollisionRelatedBlockState.CollisionShape);
        if (shapeAabbs.Length == 0) {
            return;
        }
        Box aabb = MoveByPositionAndProgress(Bounds(shapeAabbs));
        Box area = MinMax(MovementArea(aabb, movement, deltaProgress), aabb);
        List<IPistonPushable> entities = context.PistonPushable.Where(entity => entity.BoundingBox.Intersects(area)).ToList();
        bool causeBounce = MovedState.Identifier.Equals(Block.SlimeBlock.Identifier);
        foreach (IPistonPushable entity in entities) {
            if (causeBounce) {
                Vec3d deltaMovement = entity.DeltaMovement;
                (int sx, int sy, int sz) = DirectionUtil.Step(movement);
                entity.DeltaMovement = movement switch {
                    Cardinal.West or Cardinal.East => deltaMovement.WithX(sx),
                    Cardinal.Down or Cardinal.Up => deltaMovement.WithY(sy),
                    _ => deltaMovement.WithZ(sz)
                };
            }

            double delta = 0.0;
            foreach (Box shapeAabb in shapeAabbs) {
                Box movingAabb = MovementArea(MoveByPositionAndProgress(shapeAabb), movement, deltaProgress);
                Box entityAabb = entity.BoundingBox;
                if (movingAabb.Intersects(entityAabb)) {
                    delta = Math.Max(delta, GetMovement(movingAabb, movement, entityAabb));
                    if (delta >= deltaProgress) {
                        break;
                    }
                }
            }

            if (!(delta <= 0.0)) {
                delta = Math.Min(delta, deltaProgress) + 0.01;
                MoveEntityByPiston(movement, entity, delta, movement);
                if (!Extending && IsSourcePiston) {
                    FixEntityWithinPistonBase(entity, movement, deltaProgress);
                }
            }
        }
    }

    private static void MoveEntityByPiston(Cardinal pistonDirection, IPistonPushable entity, double delta, Cardinal movement) {
        _noClip = pistonDirection;
        (int sx, int sy, int sz) = DirectionUtil.Step(movement);
        try {
            entity.MoveByPiston(new Vec3d(delta * sx, delta * sy, delta * sz));
        }
        finally {
            _noClip = null;
        }
    }

    /// <summary><c>moveStuckEntities</c>: a honey block carries what stands on it sideways.</summary>
    private void MoveStuckEntities(BlockEntityTickContext context, float newProgress) {
        if (!MovedState.Identifier.Equals(Block.HoneyBlock.Identifier)) {
            return;
        }
        Cardinal movement = MovementDirection;
        if (movement is Cardinal.Up or Cardinal.Down) {
            return;
        }
        double stickyTop = Bounds(CollisionOf(context.Level.Registry, MovedState)).MaxY;
        Box aabb = MoveByPositionAndProgress(new Box(0.0, stickyTop, 0.0, 1.0, 1.5000010000000001, 1.0));
        double deltaProgress = newProgress - _progress;
        List<IPistonPushable> entities = context.PistonPushable.Where(entity => entity.BoundingBox.Intersects(aabb) && MatchesStickyCriteria(aabb, entity)).ToList();
        foreach (IPistonPushable entity in entities) {
            MoveEntityByPiston(movement, entity, deltaProgress, movement);
        }
    }

    private bool MatchesStickyCriteria(Box aabb, IPistonPushable entity) {
        return entity.OnGround && (entity.IsSupportedBy(X, Y, Z) ||
                                   entity.Position.X >= aabb.MinX && entity.Position.X <= aabb.MaxX && entity.Position.Z >= aabb.MinZ && entity.Position.Z <= aabb.MaxZ);
    }

    /// <summary><c>fixEntityWithinPistonBase</c>: a retracting head drags back out what it would leave inside the base.</summary>
    private void FixEntityWithinPistonBase(IPistonPushable entity, Cardinal direction, double deltaProgress) {
        Box entityAabb = entity.BoundingBox;
        Box box = new(X, Y, Z, X + 1.0, Y + 1.0, Z + 1.0);
        if (!entityAabb.Intersects(box)) {
            return;
        }
        Cardinal opposite = Opposite(direction);
        double delta = GetMovement(box, opposite, entityAabb) + 0.01;
        Box intersection = new(Math.Max(entityAabb.MinX, box.MinX), Math.Max(entityAabb.MinY, box.MinY), Math.Max(entityAabb.MinZ, box.MinZ),
            Math.Min(entityAabb.MaxX, box.MaxX), Math.Min(entityAabb.MaxY, box.MaxY), Math.Min(entityAabb.MaxZ, box.MaxZ));
        double deltaIntersected = GetMovement(box, opposite, intersection) + 0.01;
        if (Math.Abs(delta - deltaIntersected) < 0.01) {
            delta = Math.Min(delta, deltaProgress) + 0.01;
            MoveEntityByPiston(direction, entity, delta, opposite);
        }
    }

    private static double GetMovement(Box aabbToBeOutsideOf, Cardinal movement, Box aabb) => movement switch {
        Cardinal.East => aabbToBeOutsideOf.MaxX - aabb.MinX,
        Cardinal.West => aabb.MaxX - aabbToBeOutsideOf.MinX,
        Cardinal.Down => aabb.MaxY - aabbToBeOutsideOf.MinY,
        Cardinal.South => aabbToBeOutsideOf.MaxZ - aabb.MinZ,
        Cardinal.North => aabb.MaxZ - aabbToBeOutsideOf.MinZ,
        _ => aabbToBeOutsideOf.MaxY - aabb.MinY
    };

    private Box MoveByPositionAndProgress(Box aabb) {
        double currentPosition = GetExtendedProgress(_progress);
        (int sx, int sy, int sz) = DirectionUtil.Step(Direction);
        return aabb.Translate(X + currentPosition * sx, Y + currentPosition * sy, Z + currentPosition * sz);
    }

    /// <summary><c>PistonMath.getMovementArea</c>.</summary>
    private static Box MovementArea(Box aabb, Cardinal direction, double amount) {
        double delta = direction is Cardinal.East or Cardinal.Up or Cardinal.South ? amount : -amount;
        double min = Math.Min(delta, 0.0);
        double max = Math.Max(delta, 0.0);
        return direction switch {
            Cardinal.West => new Box(aabb.MinX + min, aabb.MinY, aabb.MinZ, aabb.MinX + max, aabb.MaxY, aabb.MaxZ),
            Cardinal.East => new Box(aabb.MaxX + min, aabb.MinY, aabb.MinZ, aabb.MaxX + max, aabb.MaxY, aabb.MaxZ),
            Cardinal.Down => new Box(aabb.MinX, aabb.MinY + min, aabb.MinZ, aabb.MaxX, aabb.MinY + max, aabb.MaxZ),
            Cardinal.North => new Box(aabb.MinX, aabb.MinY, aabb.MinZ + min, aabb.MaxX, aabb.MaxY, aabb.MinZ + max),
            Cardinal.South => new Box(aabb.MinX, aabb.MinY, aabb.MaxZ + min, aabb.MaxX, aabb.MaxY, aabb.MaxZ + max),
            _ => new Box(aabb.MinX, aabb.MaxY + min, aabb.MinZ, aabb.MaxX, aabb.MaxY + max, aabb.MaxZ)
        };
    }

    /// <summary><c>VoxelShape.bounds</c>.</summary>
    private static Box Bounds(Box[] boxes) {
        Box bounds = boxes[0];
        foreach (Box box in boxes) {
            bounds = MinMax(bounds, box);
        }
        return bounds;
    }

    /// <summary><c>AABB.minmax</c>.</summary>
    private static Box MinMax(Box a, Box b) => new(Math.Min(a.MinX, b.MinX), Math.Min(a.MinY, b.MinY), Math.Min(a.MinZ, b.MinZ),
        Math.Max(a.MaxX, b.MaxX), Math.Max(a.MaxY, b.MaxY), Math.Max(a.MaxZ, b.MaxZ));

    /// <summary><c>finalTick</c>: the move cut short, as a piston retracting mid push does.</summary>
    public void FinalTick(ClientLevel level) {
        _progress = 1.0F;
        _progressO = _progress;
        level.RemoveBlockEntity(X, Y, Z);
        if (level.GetBlock(X, Y, Z).Identifier.Equals(Block.MovingPiston.Identifier)) {
            level.SetState(X, Y, Z, (ushort)(IsSourcePiston ? Block.Air : MovedState).StateId);
        }
    }
}

/// <summary><c>BeaconBlockEntity</c>: the beam's coloured sections, rebuilt ten blocks a tick, and the pyramid under it.</summary>
public sealed class BeaconBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    /// <summary><c>BeaconBeamOwner.Section</c>.</summary>
    public sealed class Section(uint color) {
        public uint Color { get; } = color;
        public int Height { get; private set; } = 1;

        public void IncreaseHeight() => Height++;
    }

    /// <summary>What vanilla's <c>beacon_base_blocks</c> tag holds.</summary>
    private static readonly IBlock[] BaseBlocks = [Block.IronBlock, Block.GoldBlock, Block.EmeraldBlock, Block.DiamondBlock, Block.NetheriteBlock];

    private List<Section> _beamSections = [], _checkingBeamSections = [];
    private int _lastCheckY = int.MinValue, _levels;

    /// <summary><c>getBeamSections</c>: none without a pyramid.</summary>
    public IReadOnlyList<Section> BeamSections => _levels == 0 ? [] : _beamSections;

    public override bool HasClientTicker => true;

    /// <summary><c>BeaconBlockEntity.tick</c>, without the effects and sounds the server gives.</summary>
    public override void Tick(BlockEntityTickContext context) {
        ClientLevel level = context.Level;
        int checkY;
        if (_lastCheckY < Y) {
            checkY = Y;
            _checkingBeamSections = [];
            _lastCheckY = Y - 1;
        }
        else {
            checkY = _lastCheckY + 1;
        }

        Section? lastBeamSection = _checkingBeamSections.Count == 0 ? null : _checkingBeamSections[^1];
        int lastSetBlock = level.GetHeight(Minecraft.Schemas.Chunks.HeightmapType.WorldSurface, X, Z);
        for (int i = 0; i < 10 && checkY <= lastSetBlock; i++) {
            IBlock state = level.GetBlock(X, checkY, Z);
            if (BeamColor(state) is { } dye) {
                uint color = TextureDiffuseColor(dye);
                if (_checkingBeamSections.Count <= 1) {
                    lastBeamSection = new Section(color);
                    _checkingBeamSections.Add(lastBeamSection);
                }
                else if (lastBeamSection != null) {
                    if (color == lastBeamSection.Color) {
                        lastBeamSection.IncreaseHeight();
                    }
                    else {
                        lastBeamSection = new Section(Average(lastBeamSection.Color, color));
                        _checkingBeamSections.Add(lastBeamSection);
                    }
                }
            }
            else {
                if (lastBeamSection == null || state.LightDampening >= 15 && !state.Identifier.Equals(Block.Bedrock.Identifier)) {
                    _checkingBeamSections.Clear();
                    _lastCheckY = lastSetBlock;
                    break;
                }
                lastBeamSection.IncreaseHeight();
            }
            checkY++;
            _lastCheckY++;
        }

        if (level.GameTime % 80L == 0L && _beamSections.Count > 0) {
            _levels = UpdateBase(level, X, Y, Z);
        }
        if (_lastCheckY >= lastSetBlock) {
            _lastCheckY = level.MinY - 1;
            _beamSections = _checkingBeamSections;
        }
    }

    /// <summary><c>updateBase</c>: how many full layers of beacon base blocks are under it.</summary>
    private static int UpdateBase(ClientLevel level, int x, int y, int z) {
        int levels = 0;
        for (int step = 1; step <= 4; levels = step++) {
            int ly = y - step;
            if (ly < level.MinY) {
                break;
            }
            bool isOk = true;
            for (int lx = x - step; lx <= x + step && isOk; lx++) {
                for (int lz = z - step; lz <= z + step; lz++) {
                    IBlock block = level.GetBlock(lx, ly, lz);
                    if (!BaseBlocks.Any(b => b.Identifier.Equals(block.Identifier))) {
                        isOk = false;
                        break;
                    }
                }
            }
            if (!isOk) {
                break;
            }
        }
        return levels;
    }

    /// <summary><c>BeaconBeamBlock.getColor</c>: stained glass and panes by their dye, and the beacon itself white.</summary>
    private static DyeColor? BeamColor(IBlock state) {
        if (state.Identifier.Equals(Block.Beacon.Identifier)) {
            return DyeColor.White;
        }
        return DyedBlocks.StainedGlassColor(state);
    }

    /// <summary><c>DyeColor.getTextureDiffuseColor</c>.</summary>
    public static uint TextureDiffuseColor(DyeColor color) => 0xFF000000 | color switch {
        DyeColor.White => 16383998u,
        DyeColor.Orange => 16351261u,
        DyeColor.Magenta => 13061821u,
        DyeColor.LightBlue => 3847130u,
        DyeColor.Yellow => 16701501u,
        DyeColor.Lime => 8439583u,
        DyeColor.Pink => 15961002u,
        DyeColor.Gray => 4673362u,
        DyeColor.LightGray => 10329495u,
        DyeColor.Cyan => 1481884u,
        DyeColor.Purple => 8991416u,
        DyeColor.Blue => 3949738u,
        DyeColor.Brown => 8606770u,
        DyeColor.Green => 6192150u,
        DyeColor.Red => 11546150u,
        _ => 1908001u
    };

    /// <summary><c>ARGB.average</c>.</summary>
    private static uint Average(uint a, uint b) {
        uint Channel(int shift) => (((a >> shift) & 0xFF) + ((b >> shift) & 0xFF)) / 2;
        return Channel(24) << 24 | Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }
}
