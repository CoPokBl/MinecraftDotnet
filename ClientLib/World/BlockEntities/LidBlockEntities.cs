using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Components.Types;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;

namespace ClientLib.World.BlockEntities;

/// <summary><c>ChestLidController</c>.</summary>
public sealed class ChestLidController {
    private bool _shouldBeOpen;
    private float _openness, _oOpenness;

    public void TickLid() {
        _oOpenness = _openness;
        if (!_shouldBeOpen && _openness > 0.0F) {
            _openness = Math.Max(_openness - 0.1F, 0.0F);
        }
        else if (_shouldBeOpen && _openness < 1.0F) {
            _openness = Math.Min(_openness + 0.1F, 1.0F);
        }
    }

    public float GetOpenness(float a) => _oOpenness + a * (_openness - _oOpenness);

    public void ShouldBeOpen(bool shouldBeOpen) => _shouldBeOpen = shouldBeOpen;
}

/// <summary>
/// <c>ChestBlockEntity</c>, its trapped and copper kinds, and <c>EnderChestBlockEntity</c>: the lid the
/// open count block event swings.
/// </summary>
public sealed class ChestBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    private readonly ChestLidController _lid = new();

    public bool IsEnderChest => Is(BlockEntityType.EnderChest);

    public override bool TriggerEvent(int b0, int b1) {
        if (b0 == 1) {
            _lid.ShouldBeOpen(b1 > 0);
            return true;
        }
        return false;
    }

    public override bool HasClientTicker => true;

    /// <summary><c>lidAnimateTick</c>.</summary>
    public override void Tick(BlockEntityTickContext context) => _lid.TickLid();

    public float GetOpenNess(float a) => _lid.GetOpenness(a);

    /// <summary><c>ChestBlock.getConnectedDirection</c>.</summary>
    public static Direction ConnectedDirection(Direction facing, ChestType type) =>
        type == ChestType.Left ? DirectionUtil.ClockWise(facing) : DirectionUtil.CounterClockWise(facing);

    /// <summary>
    /// <c>ChestBlock.combine(state, level, pos, true)</c>: the other half of a double chest, when its
    /// block is the same chest facing the same way as the other half; null for a single chest and an
    /// ender chest, which is not a <c>ChestBlock</c>.
    /// </summary>
    public ChestBlockEntity? Neighbour(ClientLevel level) {
        if (IsEnderChest || State is not IChestTyped { Type: not ChestType.Single } chest || State is not IHorizontalFacing facing) {
            return null;
        }
        (int dx, int dz) = DirectionUtil.Step(ConnectedDirection(facing.Facing, chest.Type));
        IBlock neighbourState = level.GetBlock(X + dx, Y, Z + dz);
        if (!neighbourState.Identifier.Equals(State.Identifier) || neighbourState is not IChestTyped neighbourChest
            || neighbourChest.Type == ChestType.Single || neighbourChest.Type == chest.Type
            || neighbourState is not IHorizontalFacing neighbourFacing || neighbourFacing.Facing != facing.Facing) {
            return null;
        }
        return level.GetBlockEntity(X + dx, Y, Z + dz) as ChestBlockEntity;
    }

    /// <summary><c>ChestBlock.opennessCombiner</c> applied to <see cref="Neighbour"/>: a double chest opens as its wider half.</summary>
    public float CombinedOpenness(ClientLevel level, float a) =>
        Neighbour(level) is { } other ? Math.Max(GetOpenNess(a), other.GetOpenNess(a)) : GetOpenNess(a);
}

/// <summary><c>ShulkerBoxBlockEntity</c>'s lid, which the same open count event drives and its <c>tick</c> runs on both sides.</summary>
public sealed class ShulkerBoxBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public enum AnimationStatus { Closed, Opening, Opened, Closing }

    private float _progress, _progressOld;

    public AnimationStatus Status { get; private set; }

    /// <summary><c>getColor</c>, from the block; null for the undyed box.</summary>
    public DyeColor? Color => DyedBlocks.ShulkerBoxColor(State);

    public override bool TriggerEvent(int b0, int b1) {
        if (b0 == 1) {
            if (b1 == 0) {
                Status = AnimationStatus.Closing;
            }
            if (b1 == 1) {
                Status = AnimationStatus.Opening;
            }
            return true;
        }
        return false;
    }

    public override bool HasClientTicker => true;

    /// <summary>
    /// <c>updateAnimation</c>. Pushing entities out of the way as the lid rises is left out: the server
    /// moves them, and the client would only predict it for the local player.
    /// </summary>
    public override void Tick(BlockEntityTickContext context) {
        _progressOld = _progress;
        switch (Status) {
            case AnimationStatus.Closed:
                _progress = 0.0F;
                break;
            case AnimationStatus.Opening:
                _progress += 0.1F;
                if (_progress >= 1.0F) {
                    Status = AnimationStatus.Opened;
                    _progress = 1.0F;
                }
                break;
            case AnimationStatus.Opened:
                _progress = 1.0F;
                break;
            case AnimationStatus.Closing:
                _progress -= 0.1F;
                if (_progress <= 0.0F) {
                    Status = AnimationStatus.Closed;
                    _progress = 0.0F;
                }
                break;
        }
    }

    public float GetProgress(float a) => _progressOld + a * (_progress - _progressOld);
}

/// <summary><c>EnchantingTableBlockEntity</c>: the book that opens and turns toward a player nearby.</summary>
public sealed class EnchantingTableBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    /// <summary>The class's own static <c>RANDOM</c>, shared by every table.</summary>
    private static readonly RandomSource Random = LegacyRandomSource.Create();

    public int Time;
    public float Flip, OFlip, FlipT, FlipA;
    public float Open, OOpen;
    public float Rot, ORot, TRot;

    public override bool HasClientTicker => true;

    /// <summary><c>bookAnimationTick</c>.</summary>
    public override void Tick(BlockEntityTickContext context) {
        OOpen = Open;
        ORot = Rot;
        if (context.NearestPlayer(X + 0.5, Y + 0.5, Z + 0.5, 3.0) is { } player) {
            double xd = player.X - (X + 0.5);
            double zd = player.Z - (Z + 0.5);
            TRot = (float)Minecraft.Schemas.Mth.Atan2(zd, xd);
            Open += 0.1F;
            if (Open < 0.5F || Random.NextInt(40) == 0) {
                float old = FlipT;
                do {
                    FlipT += Random.NextInt(4) - Random.NextInt(4);
                } while (old == FlipT);
            }
        }
        else {
            TRot += 0.02F;
            Open -= 0.1F;
        }

        while (Rot >= (float)Math.PI) {
            Rot -= (float)(Math.PI * 2);
        }
        while (Rot < (float)-Math.PI) {
            Rot += (float)(Math.PI * 2);
        }
        while (TRot >= (float)Math.PI) {
            TRot -= (float)(Math.PI * 2);
        }
        while (TRot < (float)-Math.PI) {
            TRot += (float)(Math.PI * 2);
        }
        float rotDir = TRot - Rot;
        while (rotDir >= (float)Math.PI) {
            rotDir -= (float)(Math.PI * 2);
        }
        while (rotDir < (float)-Math.PI) {
            rotDir += (float)(Math.PI * 2);
        }

        Rot += rotDir * 0.4F;
        Open = Math.Clamp(Open, 0.0F, 1.0F);
        Time++;
        OFlip = Flip;
        float diff = (FlipT - Flip) * 0.4F;
        diff = Math.Clamp(diff, -0.2F, 0.2F);
        FlipA += (diff - FlipA) * 0.9F;
        Flip += FlipA;
    }
}

/// <summary><c>BellBlockEntity</c>'s swing. The raider resonance and its particles are left out.</summary>
public sealed class BellBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    public int Ticks;
    public bool Shaking;
    public Cardinal ClickDirection = Cardinal.North;

    public override bool TriggerEvent(int b0, int b1) {
        if (b0 == 1) {
            ClickDirection = DirectionUtil.From3DDataValue(b1);
            Ticks = 0;
            Shaking = true;
            return true;
        }
        return false;
    }

    public override bool HasClientTicker => true;

    /// <summary><c>BellBlockEntity.tick</c> as far as the swing goes.</summary>
    public override void Tick(BlockEntityTickContext context) {
        if (Shaking) {
            Ticks++;
        }
        if (Ticks >= 50) {
            Shaking = false;
            Ticks = 0;
        }
    }
}

/// <summary><c>SkullBlockEntity</c>: the owner's profile, and the jaw or ears of a powered dragon or piglin head.</summary>
public sealed class SkullBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    private int _animationTickCount;
    private bool _isAnimating;

    /// <summary>The <c>profile</c> field, which a player head names its skin by.</summary>
    public ProfileComponent.Data? Profile { get; private set; }

    protected override void LoadAdditional(NBT.Tags.CompoundTag tag, Minecraft.Registry.MinecraftRegistry registry) {
        Profile = tag["profile"] is { } profile ? BannerBlockEntity.Decode<ProfileComponent.Data>(() => DataComponent.Profile.FromNbt(profile, registry)) : null;
    }

    /// <summary><c>AbstractSkullBlock.getTicker</c>: only the dragon and piglin heads animate.</summary>
    public override bool HasClientTicker => State.Identifier.Equals(Block.DragonHead.Identifier) || State.Identifier.Equals(Block.DragonWallHead.Identifier)
                                            || State.Identifier.Equals(Block.PiglinHead.Identifier) || State.Identifier.Equals(Block.PiglinWallHead.Identifier);

    /// <summary><c>SkullBlockEntity.animation</c>.</summary>
    public override void Tick(BlockEntityTickContext context) {
        if (State is IPowered { Powered: true }) {
            _isAnimating = true;
            _animationTickCount++;
        }
        else {
            _isAnimating = false;
        }
    }

    public float GetAnimation(float a) => _isAnimating ? _animationTickCount + a : _animationTickCount;
}
