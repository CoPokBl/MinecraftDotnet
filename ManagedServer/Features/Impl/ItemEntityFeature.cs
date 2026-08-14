using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Physics;
using ManagedServer.Worlds;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Features.Impl;

/// <summary>
/// The rest of <c>ItemEntity.tick</c>: the pickup delay counting down, nearby stacks merging, and the
/// five minute despawn.
/// <p/>
/// The movement half already runs in <c>EntityPhysics.TickGeneric</c>, which is a port of the same
/// method, and picking a stack up is <c>ItemPickupFeature</c>'s. This is deliberately none of those:
/// a minigame may want drops that never expire, or expiry without merging, and turning one off should
/// not take the others with it.
/// </summary>
public class ItemEntityFeature(bool merge = true, bool despawn = true) : ScopedFeature {
    /// <summary>
    /// <c>ItemEntity.mergeWithNeighbours</c> searches half a block horizontally and not at all
    /// vertically, so a stack on a slab does not swallow the one on the floor below it.
    /// </summary>
    private const double MergeRange = 0.5;

    public override void Register() {
        AddEventHandler<ServerTickEvent>(_ => {
            foreach (World world in ScopedWorlds()) {
                TickWorld(world);
            }
        });
    }

    /// <summary>
    /// The worlds this instance is responsible for. A world scoped feature ticks its own world only:
    /// the tick event reaches every node, so without this a per world registration would quietly tick
    /// the whole server and two of them would tick everything twice.
    /// </summary>
    private World[] ScopedWorlds() {
        return Scope is World world ? [world] : Scope.Server.Worlds.ToArray();
    }

    private void TickWorld(World world) {
        ItemEntity[] items = world.Entities.GetEntities().OfType<ItemEntity>().ToArray();

        foreach (ItemEntity item in items) {
            if (item.World == null) {
                continue;  // despawned earlier in this pass, by a merge
            }

            if (item.PickupDelay is > 0 and not ItemEntity.InfinitePickupDelay) {
                item.PickupDelay--;
            }

            if (item.Age != ItemEntity.InfiniteLifetime) {
                item.Age++;
            }

            if (merge && item.TickCount % 40 == 0) {
                // Vanilla merges every other tick while the stack is crossing block boundaries and
                // every fortieth otherwise. Only the settled rate is kept: the fast one exists so two
                // stacks thrown at each other combine before they separate again, and nothing here
                // throws items at each other.
                MergeWithNeighbours(world, item);
            }

            if (despawn && item.Age >= ItemEntity.Lifetime && item.Age != ItemEntity.InfiniteLifetime) {
                item.Despawn();
            }
        }
    }

    /// <summary><c>ItemEntity.mergeWithNeighbours</c>.</summary>
    private static void MergeWithNeighbours(World world, ItemEntity item) {
        if (!item.Mergeable) {
            return;
        }

        Vec3<double> position = item.Position;
        Entity[] nearby = world.Entities.GetEntitiesInBox(
            new Box(
                position.X - MergeRange, position.Y, position.Z - MergeRange,
                position.X + MergeRange, position.Y + item.Type.Height, position.Z + MergeRange),
            other => other != item && other is ItemEntity { Mergeable: true });

        foreach (Entity other in nearby) {
            TryToMerge(item, (ItemEntity)other);
            if (item.World == null) {
                break;  // this one was the smaller stack and has gone into the other
            }
        }
    }

    /// <summary>
    /// <c>ItemEntity.tryToMerge</c>: the <b>smaller</b> stack is the one that goes away, so the
    /// surviving entity is the one that was already carrying more.
    /// </summary>
    private static void TryToMerge(ItemEntity item, ItemEntity other) {
        if (item.Item is not { } itemStack || other.Item is not { } otherStack) {
            return;
        }

        if (!AreMergeable(itemStack, otherStack)) {
            return;
        }

        if (otherStack.Count < itemStack.Count) {
            Merge(item, itemStack, other, otherStack);
        }
        else {
            Merge(other, otherStack, item, itemStack);
        }
    }

    /// <summary>
    /// <c>ItemEntity.areMergable</c>. Two stacks that would overflow a full stack between them are
    /// <b>not</b> merged at all rather than partly merged, which is why a pile of drops settles into
    /// several full stacks and one remainder rather than churning.
    /// </summary>
    private static bool AreMergeable(ItemStack a, ItemStack b) {
        if (a.Count + b.Count > b.GetMaxStackSize()) {
            return false;
        }

        // Equality here is the stack's whole identity, components and custom data included, so a
        // Knockback Stick never merges into a plain stick.
        return a.WithCount(1).Equals(b.WithCount(1));
    }

    private static void Merge(ItemEntity to, ItemStack toStack, ItemEntity from, ItemStack fromStack) {
        int delta = Math.Min(Math.Min(toStack.GetMaxStackSize(), 64) - toStack.Count, fromStack.Count);
        if (delta <= 0) {
            return;
        }

        to.Item = toStack.WithCount(toStack.Count + delta);
        from.Item = fromStack.WithCount(fromStack.Count - delta);

        to.PickupDelay = Math.Max(to.PickupDelay, from.PickupDelay);
        to.Age = Math.Min(to.Age, from.Age);

        if (from.Item is { Count: <= 0 }) {
            from.Despawn();
        }
    }
}
