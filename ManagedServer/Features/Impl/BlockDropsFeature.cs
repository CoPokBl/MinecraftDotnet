using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Loot;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using NBT.Tags;

namespace ManagedServer.Features.Impl;

/// <summary>
/// Drops what a block is worth when it is broken, from the vanilla loot tables.
/// <p/>
/// Everything the feature reads comes in through <paramref name="loot"/>, which defaults to
/// <see cref="VanillaBlockLoot"/>. There is no registry on the server to fill: see
/// <see cref="IBlockLootSource"/> for why the seam is here instead.
/// <p/>
/// Two paths reach a broken block and both are covered:
/// <list type="bullet">
/// <item><c>PlayerBreakBlockEvent</c>, which is the one carrying the tool and so the only one that
/// can answer silk touch and fortune.</item>
/// <item><c>WorldChangeEvent</c> going to air or to a fluid, which is <c>World.DestroyBlock</c> and
/// so the shape cascade: a torch whose wall was taken away. Toolless, as vanilla's
/// <c>dropResources</c> without a tool is.</item>
/// </list>
/// The player path fires first and the write that follows it fires the second, so the position it
/// handled is remembered for the rest of that tick and skipped, the same guard
/// <c>LuckyBlocksFeature</c> gets for free from its own dictionary.
/// </summary>
public class BlockDropsFeature(IBlockLootSource? loot = null, bool dropOnDestroy = true) : ScopedFeature {
    private readonly IBlockLootSource _loot = loot ?? VanillaBlockLoot.Instance;

    /// <summary>
    /// Positions the player path has taken responsibility for, and the tick it did so. Read by the
    /// destroy path within the same tick, so an entry older than the current tick is spent.
    /// </summary>
    private readonly Dictionary<(World World, Vec3<int> Position), ulong> _handled = [];
    private readonly Lock _handledLock = new();

    public override void Register() {
        AddEventHandler<PlayerBreakBlockEvent>(e => {
            Player player = e.Player;
            IBlock block = e.Block;

            MarkHandled(e.World, e.Position);

            // Nothing is dropped for a creative break, and nothing at all if the tool cannot harvest
            // the block: both are gates in Player.destroyBlock, before playerDestroy is ever called.
            if (player.GameMode == GameMode.Creative) {
                return;
            }

            ItemStack tool = player.HeldItem;
            if (!BlockUtils.CanHarvest(tool, block, player.Server.Registry)) {
                return;
            }

            // The event is still being dispatched, and BlockBreakingFeature only reads Cancelled once
            // every listener has run. Dropping inline would hand out items for a break a later listener
            // vetoes, so the roll waits until the answer is settled.
            Scope.Server.Scheduler.ScheduleNextTick(() => {
                if (e.Cancelled) {
                    return;
                }

                DropLoot(e.World, e.Position, block, tool, player);
            });
        });

        if (!dropOnDestroy) {
            return;
        }

        AddEventHandler<WorldChangeEvent>(e => {
            // DropResources is both halves of the question: that this was a destroy rather than a
            // plain write, and that the caller did not suppress drops. A consumer clearing an area with
            // SetBlock is not breaking those blocks and gets nothing.
            if (e.Cancelled || !e.DropResources || e.OldState.Air) {
                return;
            }

            if (WasHandledThisTick(e.World, e.Position)) {
                return;
            }

            IBlock block = e.OldState;
            Vec3<int> position = e.Position;
            World world = e.World;

            // Same reason as above: this fires before the write, and cancelling is still open.
            Scope.Server.Scheduler.ScheduleNextTick(() => {
                if (e.Cancelled) {
                    return;
                }

                DropLoot(world, position, block, null, null);
            });
        });
    }

    /// <summary>
    /// <c>Block.dropResources</c>: roll the table and pop each stack. A block with no table drops
    /// nothing, which is not the same as a table that happened to roll nothing.
    /// </summary>
    private void DropLoot(World world, Vec3<int> position, IBlock block, ItemStack? tool, Player? breaker) {
        if (_loot.TableFor(block) is not { } table) {
            return;
        }

        LootContext context = new(block, position, breaker?.Random ?? world.Random, world.Server.Registry) {
            Tool = tool,
            HasBreaker = breaker != null,
            BlockAt = pos => world.GetBlockOr(pos, Block.Air),
            BlockEntityData = world.GetBlockData(position)?.Data as CompoundTag
        };

        foreach (ItemStack stack in table.GetRandomItems(context)) {
            PopResource(world, position, stack);
        }
    }

    /// <summary>
    /// <c>Block.popResource</c>: the stack lands somewhere in the middle half of the block with a
    /// small random push, rather than dead centre and at rest. The item's own height is taken off the
    /// y so the entity sits on the block's centre rather than above it.
    /// </summary>
    public static Entity? PopResource(World world, Vec3<int> position, ItemStack stack) {
        if (stack.IsAir()) {
            return null;
        }

        RandomSource random = world.Random;
        double halfHeight = EntityType.Item.Height / 2.0;

        Vec3<double> pos = new(
            position.X + 0.5 + Mth.NextDouble(random, -0.25, 0.25),
            position.Y + 0.5 + Mth.NextDouble(random, -0.25, 0.25) - halfHeight,
            position.Z + 0.5 + Mth.NextDouble(random, -0.25, 0.25));

        Entity item = world.DropItem(pos, stack);

        // ItemEntity's constructor, not popResource's: the pop only decides where it appears.
        item.Velocity = new Vec3<double>(
            random.NextDouble() * 0.2 - 0.1,
            0.2,
            random.NextDouble() * 0.2 - 0.1);

        return item;
    }

    private void MarkHandled(World world, Vec3<int> position) {
        ulong tick = Scope.Server.CurrentTick;
        lock (_handledLock) {
            // Anything from an earlier tick can never be read again, so a write is also the prune.
            if (_handled.Count > 64) {
                foreach ((World World, Vec3<int> Position) key in _handled
                             .Where(kvp => kvp.Value != tick).Select(kvp => kvp.Key).ToArray()) {
                    _handled.Remove(key);
                }
            }

            _handled[(world, position)] = tick;
        }
    }

    private bool WasHandledThisTick(World world, Vec3<int> position) {
        lock (_handledLock) {
            return _handled.TryGetValue((world, position), out ulong tick)
                   && tick == Scope.Server.CurrentTick;
        }
    }
}
