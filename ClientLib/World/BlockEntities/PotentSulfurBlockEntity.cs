using ClientLib.Maths;
using ClientLib.Physics;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Particles.Types;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Particle = Minecraft.Data.Generated.Particle;

namespace ClientLib.World.BlockEntities;

/// <summary>
/// <c>PotentSulfurBlockEntity</c>'s client tickers: a noxious gas cloud over a wet or dormant block every second,
/// and over an erupting one a geyser every second of its eruption and the lift it gives what is above it. The
/// eruption's sound is not run here.
/// </summary>
public sealed class PotentSulfurBlockEntity(IBlockEntityType type, int x, int y, int z, IBlock state) : ClientBlockEntity(type, x, y, z, state) {
    /// <summary><c>PotentSulfurBlock.ALLOWED_WATER_BLOCKS_ABOVE</c>.</summary>
    private const int AllowedWaterBlocksAbove = 4;

    // EntityTypeTags.NOT_AFFECTED_BY_GEYSERS. Entity type tags have no generated type; the server sends this one.
    private static readonly Identifier NotAffectedByGeysers = "minecraft:not_affected_by_geysers";

    /// <summary><c>eruptionTick</c>: the game time the block entity joined the level or last started erupting, which the plume counts from.</summary>
    private long _eruptionTick = -1;

    private PotentSulfurState SulfurState => State is PotentSulfurBlock sulfur ? sulfur.PotentSulfurState : PotentSulfurState.Dry;

    public override bool HasClientTicker => SulfurState != PotentSulfurState.Dry;

    /// <summary><c>PotentSulfurBlock.triggerEvent</c>, sent as the block starts erupting.</summary>
    public override bool TriggerEvent(int b0, int b1) {
        if (Level is { } level) {
            _eruptionTick = level.GameTime;
        }
        return true;
    }

    public override void Tick(BlockEntityTickContext context) {
        ClientLevel level = context.Level;
        if (_eruptionTick == -1) {
            _eruptionTick = level.GameTime;
        }
        if (FindNoxiousGasSource(level) is not { } source) {
            return;
        }
        switch (SulfurState) {
            case PotentSulfurState.Wet or PotentSulfurState.Dormant:
                // CLIENT_NOXIOUS_GAS_TICKER.
                if (level.GameTime % 20L == 0L) {
                    context.Particles?.AddParticle(Particle.NoxiousGasCloud, X + 0.5, source + 0.5, Z + 0.5, 0.0, 0.0, 0.0);
                }
                break;
            case PotentSulfurState.Erupting or PotentSulfurState.Continuous:
                // CLIENT_GEYSER_PLUME_TICKER, then LAUNCH_ENTITY_TICKER.
                if ((level.GameTime - _eruptionTick) % 20L == 0L) {
                    GeyserParticle geyser = Particle.Geyser with { WaterBlocks = source - Y - 1 };
                    context.Particles?.AddParticle(geyser, X + 0.5, source, Z + 0.5, 0.0, 0.0, 0.0);
                }
                LaunchEntities(context, source);
                break;
        }
    }

    /// <summary>
    /// <c>LAUNCH_ENTITY_TICKER</c>: each tick, whatever this client moves itself in the column over the water gets
    /// 0.2F more upward speed while it is slower than 0.3F and a tenth for each water block.
    /// </summary>
    private void LaunchEntities(BlockEntityTickContext context, int source) {
        int waterBlocks = source - Y - 1;
        int geyserForceHeight = UnobstructedBlockCount(context.Level, waterBlocks);
        Box aabb = new Box(X, Y + 1, Z, X + 1, Y + 2, Z + 1).ExpandTowards(0.0, geyserForceHeight - 1, 0.0);
        foreach (IBlockEntityMovable entity in context.Movable) {
            if (!entity.IsAliveAndNotSpectator || !entity.BoundingBox.Intersects(aabb)) {
                continue;
            }
            Vec3d entityVelocity = entity.DeltaMovement;
            entity.CheckFallDistanceAccumulation();
            if (entity.IsLocalInstanceAuthoritative
                && entity is not ClientLib.Player.LocalPlayer { Flying: true }
                && !entity.IsPassenger
                && context.Client?.InEntityTypeTag(entity.Type, NotAffectedByGeysers) != true
                && entityVelocity.Y < 0.3F + waterBlocks * 0.1) {
                entity.DeltaMovement = entity.DeltaMovement.Add(0.0, 0.2F, 0.0);
            }
        }
    }

    /// <summary><c>getUnobstructedBlockCount</c>: how far up from the block above this one the column is open, up to six blocks per water block.</summary>
    private int UnobstructedBlockCount(ClientLevel level, int waterBlocks) {
        int geyserForceHeight = 6 * waterBlocks;
        for (int i = 0; i < geyserForceHeight; i++) {
            int y = Y + 1 + i;
            if (!IsGeyserPassable(level, X, y, Z, level.GetBlock(X, y, Z))) {
                return i;
            }
        }
        return geyserForceHeight;
    }

    /// <summary>
    /// <c>findNoxiousGasSourceBlock</c>: up through at most four water sources to the open block above them, whose
    /// height this returns, or null when something solid caps the water.
    /// </summary>
    private int? FindNoxiousGasSource(ClientLevel level) {
        int maxY = Y + AllowedWaterBlocksAbove + 1;
        for (int y = Y + 1; y <= maxY; y++) {
            IBlock state = level.GetBlock(X, y, Z);
            MovementBlocks.Entry fluid = MovementBlocks.Get(level.Registry, state.StateId);
            bool isWaterLogged = fluid is { Fluid: FluidKind.Water, FluidAmount: 8, FluidFalling: false };
            if (!isWaterLogged || state is not WaterBlock && !IsGeyserPassable(level, X, y, Z, state)) {
                return state.Air || IsGeyserPassable(level, X, y, Z, state) ? y : null;
            }
        }
        return null;
    }

    /// <summary>
    /// <c>isGeyserPassableBlock</c>: air, water, or a block with no collision under <c>CollisionContext.positionContext</c>
    /// at this block's height. Every block asked about is higher than that, which no fluid, powder snow or scaffolding
    /// collides with.
    /// </summary>
    private static bool IsGeyserPassable(ClientLevel level, int x, int y, int z, IBlock state) {
        if (state.Air || state is WaterBlock) {
            return true;
        }
        MinecraftRegistry registry = level.Registry;
        return LevelCollisions.ContextShapeOf(registry, state.StateId) switch {
            LevelCollisions.ContextShape.None => BlockPhysicsData.Get(registry, state.StateId).Collision.Length == 0,
            LevelCollisions.ContextShape.MovingPiston => level.GetBlockEntity(x, y, z) is not PistonMovingBlockEntity piston
                                                         || piston.CollisionShape(registry).Length == 0,
            _ => true
        };
    }
}

/// <summary>Reading what block entities' update tags hold for their particles.</summary>
internal static class BlockEntityTags {
    /// <summary><c>UUIDUtil.CODEC</c>: four ints, most significant first.</summary>
    public static Guid? ReadUuid(NBT.INbtTag? tag) {
        if (tag is not NBT.Tags.ArrayTag<int> { Values.Length: 4 } ints) {
            return null;
        }
        Span<byte> bytes = stackalloc byte[16];
        for (int i = 0; i < 4; i++) {
            System.Buffers.Binary.BinaryPrimitives.WriteInt32BigEndian(bytes[(i * 4)..], ints.Values[i]);
        }
        return new Guid(bytes, bigEndian: true);
    }
}
