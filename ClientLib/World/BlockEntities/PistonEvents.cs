using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Pos = (int X, int Y, int Z);

namespace ClientLib.World.BlockEntities;

/// <summary>
/// <c>PistonBaseBlock.triggerEvent</c> on the client: the server's block event starts the move, and the
/// client turns the moving blocks into moving pistons itself, which is the only way a moving piston's
/// block entity comes to exist on a client. Neighbour updates and shape updates are the server's, whose
/// block updates follow.
/// </summary>
public static class PistonEvents {
    /// <summary><c>PistonStructureResolver.MAX_PUSH_DEPTH</c>.</summary>
    private const int MaxPushDepth = 12;

    private static Pos Relative(Pos pos, Cardinal direction, int distance = 1) {
        (int dx, int dy, int dz) = DirectionUtil.Step(direction);
        return (pos.X + dx * distance, pos.Y + dy * distance, pos.Z + dz * distance);
    }

    private static Cardinal FacingOf(IBlock state) => state is IDirectional directional ? directional.Facing : Cardinal.Down;

    private static bool IsSticky(IBlock piston) => piston is StickyPistonBlock;

    private static bool Is(IBlock state, IBlock block) => state.Identifier.Equals(block.Identifier);

    private static IBlock MovingPiston(Cardinal facing, bool sticky) =>
        Block.MovingPiston with { Facing = facing, TypeValue = sticky ? MovingPistonBlock.Type.Sticky : MovingPistonBlock.Type.Normal };

    private static void SetBlock(ClientLevel level, Pos pos, IBlock state) => level.SetState(pos.X, pos.Y, pos.Z, (ushort)state.StateId);

    private static void SetMovingBlockEntity(ClientLevel level, Pos pos, IBlock state, IBlock movedState, Cardinal direction, bool extending, bool source) =>
        level.SetBlockEntity(PistonMovingBlockEntity.Moving(level.Registry.BlockEntityTypes[BlockEntityType.Piston.Identifier], pos.X, pos.Y, pos.Z, state,
            movedState, direction, extending, source));

    /// <returns>Whether the event did anything, as vanilla's return value says.</returns>
    public static bool TriggerEvent(ClientLevel level, int x, int y, int z, IBlock state, int b0, int b1) {
        Pos pos = (x, y, z);
        Cardinal direction = FacingOf(state);
        bool sticky = IsSticky(state);
        if (b0 == 0) {
            if (!MoveBlocks(level, pos, direction, true, sticky)) {
                return false;
            }
            SetBlock(level, pos, state switch {
                PistonBlock piston => piston with { Extended = true },
                StickyPistonBlock piston => piston with { Extended = true },
                _ => state
            });
        }
        else if (b0 is 1 or 2) {
            Pos arm = Relative(pos, direction);
            if (level.GetBlockEntity(arm.X, arm.Y, arm.Z) is PistonMovingBlockEntity moving) {
                moving.FinalTick(level);
            }
            IBlock movingPistonState = MovingPiston(direction, sticky);
            SetBlock(level, pos, movingPistonState);
            Cardinal movedFacing = DirectionUtil.From3DDataValue(b1 & 7);
            IBlock moved = sticky ? Block.StickyPiston with { Facing = movedFacing } : Block.Piston with { Facing = movedFacing };
            SetMovingBlockEntity(level, pos, movingPistonState, moved, direction, false, true);
            if (sticky) {
                Pos twoPos = Relative(pos, direction, 2);
                IBlock movingState = level.GetBlock(twoPos.X, twoPos.Y, twoPos.Z);
                bool pistonPiece = false;
                if (Is(movingState, Block.MovingPiston) && level.GetBlockEntity(twoPos.X, twoPos.Y, twoPos.Z) is PistonMovingBlockEntity entity
                    && entity.Direction == direction && entity.Extending) {
                    entity.FinalTick(level);
                    pistonPiece = true;
                }
                if (!pistonPiece) {
                    if (b0 != 1 || movingState.Air || !IsPushable(movingState, level, twoPos, PistonMovingBlockEntity.Opposite(direction), false, direction)
                        || movingState.PushReaction != PushReaction.Normal && !Is(movingState, Block.Piston) && !Is(movingState, Block.StickyPiston)) {
                        SetBlock(level, arm, Block.Air);
                    }
                    else {
                        MoveBlocks(level, pos, direction, false, sticky);
                    }
                }
            }
            else {
                SetBlock(level, arm, Block.Air);
            }
        }
        return true;
    }

    /// <summary><c>PistonBaseBlock.isPushable</c>, without the world border.</summary>
    public static bool IsPushable(IBlock state, ClientLevel level, Pos pos, Cardinal direction, bool allowDestroyable, Cardinal connectionDirection) {
        if (pos.Y < level.MinY || pos.Y > level.MaxY) {
            return false;
        }
        if (state.Air) {
            return true;
        }
        if (Is(state, Block.Obsidian) || Is(state, Block.CryingObsidian) || Is(state, Block.RespawnAnchor) || Is(state, Block.ReinforcedDeepslate)) {
            return false;
        }
        if (direction == Cardinal.Down && pos.Y == level.MinY || direction == Cardinal.Up && pos.Y == level.MaxY) {
            return false;
        }
        if (state is PistonBlock { Extended: true } or StickyPistonBlock { Extended: true }) {
            return false;
        }
        if (state is not PistonBlock and not StickyPistonBlock) {
            if (state.Hardness == -1.0F) {
                return false;
            }
            switch (state.PushReaction) {
                case PushReaction.Block:
                    return false;
                case PushReaction.Destroy:
                    return allowDestroyable;
                case PushReaction.PushOnly:
                    return direction == connectionDirection;
            }
        }
        return state.BlockEntity == null;
    }

    /// <summary>
    /// <c>PistonBaseBlock.moveBlocks</c>. A destroyed block raises level event 2001 for its break effects;
    /// its drops are the server's.
    /// </summary>
    private static bool MoveBlocks(ClientLevel level, Pos pistonPos, Cardinal direction, bool extending, bool sticky) {
        Pos armPos = Relative(pistonPos, direction);
        if (!extending && Is(level.GetBlock(armPos.X, armPos.Y, armPos.Z), Block.PistonHead)) {
            SetBlock(level, armPos, Block.Air);
        }
        Resolver resolver = new(level, pistonPos, direction, extending);
        if (!resolver.Resolve()) {
            return false;
        }
        Dictionary<Pos, IBlock> deleteAfterMove = new();
        List<IBlock> toPushShapes = [];
        foreach (Pos pos in resolver.ToPush) {
            IBlock state = level.GetBlock(pos.X, pos.Y, pos.Z);
            toPushShapes.Add(state);
            deleteAfterMove[pos] = state;
        }
        Cardinal pushDirection = extending ? direction : PistonMovingBlockEntity.Opposite(direction);
        for (int i = resolver.ToDestroy.Count - 1; i >= 0; i--) {
            Pos pos = resolver.ToDestroy[i];
            IBlock state = level.GetBlock(pos.X, pos.Y, pos.Z);
            if (!BlockClasses.Is(state.Identifier, BlockClass.BaseFireBlock)) {
                level.RaiseLevelEvent(2001, pos.X, pos.Y, pos.Z, (int)state.StateId);
            }
            SetBlock(level, pos, Block.Air);
        }
        for (int i = resolver.ToPush.Count - 1; i >= 0; i--) {
            Pos pos = Relative(resolver.ToPush[i], pushDirection);
            deleteAfterMove.Remove(pos);
            IBlock actualState = MovingPiston(direction, false);
            SetBlock(level, pos, actualState);
            SetMovingBlockEntity(level, pos, actualState, toPushShapes[i], direction, extending, false);
        }
        if (extending) {
            IBlock head = Block.PistonHead with { Facing = direction, TypeValue = sticky ? PistonHeadBlock.Type.Sticky : PistonHeadBlock.Type.Normal };
            IBlock movingState = MovingPiston(direction, sticky);
            deleteAfterMove.Remove(armPos);
            SetBlock(level, armPos, movingState);
            SetMovingBlockEntity(level, armPos, movingState, head, direction, true, true);
        }
        foreach (Pos pos in deleteAfterMove.Keys) {
            SetBlock(level, pos, Block.Air);
        }
        return true;
    }

    /// <summary><c>PistonStructureResolver</c>.</summary>
    private sealed class Resolver {
        private readonly ClientLevel _level;
        private readonly Pos _pistonPos, _startPos;
        private readonly bool _extending;
        private readonly Cardinal _pushDirection, _pistonDirection;

        public List<Pos> ToPush { get; } = [];
        public List<Pos> ToDestroy { get; } = [];

        public Resolver(ClientLevel level, Pos pistonPos, Cardinal direction, bool extending) {
            _level = level;
            _pistonPos = pistonPos;
            _pistonDirection = direction;
            _extending = extending;
            if (extending) {
                _pushDirection = direction;
                _startPos = Relative(pistonPos, direction);
            }
            else {
                _pushDirection = PistonMovingBlockEntity.Opposite(direction);
                _startPos = Relative(pistonPos, direction, 2);
            }
        }

        private IBlock At(Pos pos) => _level.GetBlock(pos.X, pos.Y, pos.Z);

        public bool Resolve() {
            ToPush.Clear();
            ToDestroy.Clear();
            IBlock nextState = At(_startPos);
            if (!IsPushable(nextState, _level, _startPos, _pushDirection, false, _pistonDirection)) {
                if (_extending && nextState.PushReaction == PushReaction.Destroy) {
                    ToDestroy.Add(_startPos);
                    return true;
                }
                return false;
            }
            if (!AddBlockLine(_startPos, _pushDirection)) {
                return false;
            }
            for (int i = 0; i < ToPush.Count; i++) {
                Pos pos = ToPush[i];
                if (IsSticky(At(pos)) && !AddBranchingBlocks(pos)) {
                    return false;
                }
            }
            return true;
        }

        private static bool IsSticky(IBlock state) => Is(state, Block.SlimeBlock) || Is(state, Block.HoneyBlock);

        private static bool CanStickToEachOther(IBlock state1, IBlock state2) {
            if (Is(state1, Block.HoneyBlock) && Is(state2, Block.SlimeBlock)) {
                return false;
            }
            return !(Is(state1, Block.SlimeBlock) && Is(state2, Block.HoneyBlock)) && (IsSticky(state1) || IsSticky(state2));
        }

        private bool AddBlockLine(Pos start, Cardinal direction) {
            IBlock nextState = At(start);
            if (nextState.Air || !IsPushable(nextState, _level, start, _pushDirection, false, direction) || start == _pistonPos || ToPush.Contains(start)) {
                return true;
            }
            int blockCount = 1;
            if (blockCount + ToPush.Count > MaxPushDepth) {
                return false;
            }
            Cardinal back = PistonMovingBlockEntity.Opposite(_pushDirection);
            while (IsSticky(nextState)) {
                Pos pos = Relative(start, back, blockCount);
                IBlock previousState = nextState;
                nextState = At(pos);
                if (nextState.Air || !CanStickToEachOther(previousState, nextState) || !IsPushable(nextState, _level, pos, _pushDirection, false, back)
                    || pos == _pistonPos) {
                    break;
                }
                if (++blockCount + ToPush.Count > MaxPushDepth) {
                    return false;
                }
            }
            int blocksAdded = 0;
            for (int i = blockCount - 1; i >= 0; i--) {
                ToPush.Add(Relative(start, back, i));
                blocksAdded++;
            }
            for (int i = 1;; i++) {
                Pos pos = Relative(start, _pushDirection, i);
                int collisionPos = ToPush.IndexOf(pos);
                if (collisionPos > -1) {
                    ReorderListAtCollision(blocksAdded, collisionPos);
                    for (int j = 0; j <= collisionPos + blocksAdded; j++) {
                        Pos blockPos = ToPush[j];
                        if (IsSticky(At(blockPos)) && !AddBranchingBlocks(blockPos)) {
                            return false;
                        }
                    }
                    return true;
                }
                nextState = At(pos);
                if (nextState.Air) {
                    return true;
                }
                if (!IsPushable(nextState, _level, pos, _pushDirection, true, _pushDirection) || pos == _pistonPos) {
                    return false;
                }
                if (nextState.PushReaction == PushReaction.Destroy) {
                    ToDestroy.Add(pos);
                    return true;
                }
                if (ToPush.Count >= MaxPushDepth) {
                    return false;
                }
                ToPush.Add(pos);
                blocksAdded++;
            }
        }

        private void ReorderListAtCollision(int blocksAdded, int collisionPos) {
            List<Pos> head = ToPush.GetRange(0, collisionPos);
            List<Pos> lastLineAdded = ToPush.GetRange(ToPush.Count - blocksAdded, blocksAdded);
            List<Pos> collisionToLine = ToPush.GetRange(collisionPos, ToPush.Count - blocksAdded - collisionPos);
            ToPush.Clear();
            ToPush.AddRange(head);
            ToPush.AddRange(lastLineAdded);
            ToPush.AddRange(collisionToLine);
        }

        /// <summary>Every direction off the push axis, in <c>Direction.values()</c> order: down, up, north, south, west, east.</summary>
        private bool AddBranchingBlocks(Pos fromPos) {
            IBlock fromState = At(fromPos);
            foreach (Cardinal direction in (ReadOnlySpan<Cardinal>)[Cardinal.Down, Cardinal.Up, Cardinal.North, Cardinal.South, Cardinal.West, Cardinal.East]) {
                if (Axis(direction) != Axis(_pushDirection)) {
                    Pos neighbourPos = Relative(fromPos, direction);
                    if (CanStickToEachOther(At(neighbourPos), fromState) && !AddBlockLine(neighbourPos, direction)) {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int Axis(Cardinal direction) => direction switch {
            Cardinal.Down or Cardinal.Up => 1,
            Cardinal.North or Cardinal.South => 2,
            _ => 0
        };
    }
}
