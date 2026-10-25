using ClientLib.Maths;
using ClientLib.Physics;
using ClientLib.World.BlockEntities;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;

namespace ClientLib.Player;

/// <summary>
/// The moves of a tick as <c>Entity</c> records them, what the blocks they pass through do to the player,
/// and the pistons that move it.
/// </summary>
public sealed partial class LocalPlayer : IBlockEntityMovable {
    private readonly TickMovements _movements = new();
    private readonly PistonMovementLimit _pistonLimit = new();

    // InsideBlockEffectApplier.StepBasedCollector: one set per step, in step order.
    private readonly List<InsideEffect> _effectSteps = [];
    private InsideEffect _effectsInStep;
    private int _lastStep = -1;

    /// <summary><c>Entity.applyEffectsFromBlocks</c>.</summary>
    private void ApplyEffectsFromBlocks() => ApplyEffectsFromBlocks(_movements.TakeFinal(OldPosition, Position));

    private void ApplyEffectsFromBlocks(IReadOnlyList<EntityMovement> movements) {
        if (NoPhysics) {
            return;
        }
        if (OnGround) {
            (int X, int Y, int Z) effectPos = OnPos(0.2F);
            StepOn(Level.GetBlock(effectPos.X, effectPos.Y, effectPos.Z));
        }
        if (!IsDead) {
            InsideBlocks.Check(Level, movements, position => MakeBoundingBox(Pose, position), InsideShape, EntityInside);
        }
        AdvanceStep(-1);
        foreach (InsideEffect effects in _effectSteps) {
            ApplyInsideEffects(effects);
        }
        _effectSteps.Clear();
        if (IsInRain) {
            ClearFire();
        }
    }

    /// <summary><c>Block.stepOn</c>: a slime block slows what walks on it.</summary>
    private void StepOn(IBlock block) {
        if (!BlockClasses.Is(block.Identifier, BlockClass.SlimeBlock)) {
            return;
        }
        double absDeltaY = Math.Abs(DeltaMovement.Y);
        if (absDeltaY < 0.1 && !KeyPresses.Shift) {
            double scale = 0.4 + absDeltaY * 0.2;
            DeltaMovement = DeltaMovement.Multiply(scale, 1.0, scale);
        }
    }

    /// <summary><c>StepBasedCollector.advanceStep</c>: a new step closes the set of the one before.</summary>
    private void AdvanceStep(int step) {
        if (_lastStep == step) {
            return;
        }
        _lastStep = step;
        if (_effectsInStep != InsideEffect.None) {
            _effectSteps.Add(_effectsInStep);
            _effectsInStep = InsideEffect.None;
        }
    }

    /// <summary>
    /// <c>getEntityInsideCollisionShape</c>: powder snow's is the shape it collides with when it has one, which
    /// is full but for the shorter one a long fall meets. An end portal's is its outline.
    /// </summary>
    private Box[]? InsideShape(int x, int y, int z, uint stateId) {
        IBlock block = Level.Registry.Blocks.GetByStateId(stateId);
        if (block.Identifier.Equals(Block.PowderSnow.Identifier)) {
            return CollisionContext.ShapeOf(Level, Level.Registry, stateId, x, y, z) is { Length: > 0 } shape && shape != LevelCollisions.Block ? shape : null;
        }
        if (block.Identifier.Equals(Block.EndPortal.Identifier)) {
            return BlockPhysicsData.ShapeBoxesOf(block.BlockShape);
        }
        return InsideBlocks.CauldronShape(block);
    }

    /// <summary>
    /// <c>BlockState.entityInside</c> and <c>FluidState.entityInside</c> for the blocks that move the player,
    /// set it on fire or take it through a portal.
    /// </summary>
    private void EntityInside(int x, int y, int z, uint stateId, int step, bool insideBlock, bool insideFluid, bool isPrecise) {
        IBlock block = Level.Registry.Blocks.GetByStateId(stateId);
        MovementBlocks.Entry state = MovementBlocks.Get(Level.Registry, stateId);
        AdvanceStep(step);
        if (insideBlock) {
            BlockInside(block, state, x, y, z, isPrecise);
        }
        if (insideFluid) {
            _effectsInStep |= state.Fluid == FluidKind.Lava ? InsideEffect.ClearFreeze | InsideEffect.LavaIgnite : InsideEffect.Extinguish;
        }
    }

    private void BlockInside(IBlock block, MovementBlocks.Entry state, int x, int y, int z, bool isPrecise) {
        _effectsInStep |= InsideEffectOf(block);
        if (block is BubbleColumnBlock column) {
            // Player.onAboveBubbleColumn and onInsideBubbleColumn do nothing while flying.
            if (isPrecise && !Flying) {
                if (InsideBlockMovement.NothingAboveBubbleColumn(Level, x, y, z)) {
                    DeltaMovement = InsideBlockMovement.AboveBubbleColumn(DeltaMovement, column.Drag);
                }
                else {
                    DeltaMovement = InsideBlockMovement.InsideBubbleColumn(DeltaMovement, column.Drag);
                    FallDistance = 0.0;
                }
            }
        }
        else if (BlockClasses.Is(block.Identifier, BlockClass.HoneyBlock)) {
            if (InsideBlockMovement.IsSlidingDown(x, y, z, OnGround, Position, DeltaMovement, DimensionsOf(Pose).Width)) {
                DeltaMovement = InsideBlockMovement.SlideMovement(DeltaMovement);
                FallDistance = 0.0;
            }
        }
        else if (block.Identifier.Equals(Block.NetherPortal.Identifier) || block.Identifier.Equals(Block.EndPortal.Identifier)) {
            // EndGatewayBlock.entityInside is the server's alone.
            if (CanUsePortal) {
                SetAsInsidePortal(block.Identifier);
            }
        }
        else if (state.StuckMultiplier is { } multiplier) {
            bool powderSnow = block.Identifier.Equals(Block.PowderSnow.Identifier);
            // PowderSnowBlock.entityInside catches a living entity only in the block it stands in.
            if (!powderSnow || Level.GetBlock(BlockX, BlockY, BlockZ).Identifier.Equals(Block.PowderSnow.Identifier)) {
                if (block.Identifier.Equals(Block.Cobweb.Identifier) && HasEffect(PotionEffectType.Weaving)) {
                    multiplier = new Vec3d(0.5, 0.25, 0.5);
                }
                MakeStuckInBlock(multiplier);
            }
        }
    }

    /// <summary><c>Entity.makeStuckInBlock</c>.</summary>
    private void MakeStuckInBlock(Vec3d speedMultiplier) {
        FallDistance = 0.0;
        _stuckSpeedMultiplier = speedMultiplier;
    }

    public bool IsSupportedBy(int x, int y, int z) => _mainSupportingBlock == (x, y, z);

    public void MoveByPiston(Vec3d delta) {
        Vec3d previousPos = Position;
        Move(delta, MoverType.Piston);
        ApplyEffectsFromBlocks([new EntityMovement(previousPos, Position)]);
        _movements.RemoveLatest();
    }

    public void MoveByShulkerBox(Vec3d delta) => Move(delta, MoverType.ShulkerBox);

    public bool IsAliveAndNotSpectator => !IsRemoved && !IsDead && !IsSpectator;

    public void CheckFallDistanceAccumulation() {
        if (DeltaMovement.Y > -0.5 && FallDistance > 1.0) {
            FallDistance = 1.0;
        }
    }
}
