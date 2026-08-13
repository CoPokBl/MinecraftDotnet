using ManagedServer.Entities.Types;
using ManagedServer.Worlds;
using Minecraft;
using Minecraft.Implementations.Tags;
using Minecraft.Registry;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Shapes;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Fluids;

/// <summary>
/// The parts of vanilla's <c>Entity</c> that deal with standing in a fluid and with being on fire.
/// Both features that use them need the same state, so it lives here rather than on one of them.
/// </summary>
public static class EntityFluids {
    /// <summary>
    /// Vanilla's <c>remainingFireTicks</c>. Fire outlives the block that started it, so it cannot be
    /// derived from where the entity is standing.
    /// </summary>
    public static readonly Tag<int> FireTicksTag = new("minecraftdotnet:entity:fire_ticks");

    /// <summary>What <c>Entity.lavaIgnite</c> sets, in ticks.</summary>
    public const int LavaFireTicks = 15 * 20;

    /// <summary>
    /// <c>EntityFluidInteraction.update</c>, reduced to the question it is asked for: whether the
    /// entity is standing in the fluid at all. The box is deflated the way
    /// <c>Entity.getFluidInteractionBox</c> deflates it, so touching the side of a fluid block does not
    /// count.
    /// <p/>
    /// This is a question about the whole box, not about the block the entity's feet are in: a landing
    /// half over the edge of a pool is in water in vanilla, and the two disagree wherever a fluid the
    /// box overlaps is not the one the position is over.
    /// </summary>
    public static bool IsIn(World world, Entity entity, FluidKind kind) {
        MinecraftRegistry registry = world.Server.Registry;
        Aabb box = (Aabb)entity.BoundingBox.Add(entity.Position);
        Vec3<double> min = box.Position + 0.001;
        Vec3<double> max = box.End - 0.001;

        for (int x = (int)Math.Floor(min.X); x <= (int)Math.Ceiling(max.X) - 1; x++) {
            for (int y = (int)Math.Floor(min.Y); y <= (int)Math.Ceiling(max.Y) - 1; y++) {
                for (int z = (int)Math.Floor(min.Z); z <= (int)Math.Ceiling(max.Z) - 1; z++) {
                    Vec3<int> pos = new(x, y, z);
                    FluidState fluid = StateAt(registry, world, pos).Fluid;
                    if (!fluid.IsSame(kind)) {
                        continue;
                    }

                    // Vanilla measures from the top of the fluid down to the bottom of the entity.
                    double top = y + Height(registry, world, fluid, pos);
                    if (top >= min.Y) {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    /// <summary>The same question against a world's simulation, which reads the same blocks.</summary>
    public static bool IsIn(FluidSimulation fluids, Entity entity, FluidKind kind) {
        return IsIn(fluids.World, entity, kind);
    }

    private static double Height(MinecraftRegistry registry, World world, FluidState fluid, Vec3<int> pos) {
        return StateAt(registry, world, FluidDirections.Above(pos)).Fluid.Kind == fluid.Kind ? 1.0 : fluid.OwnHeight;
    }

    /// <summary><c>FluidSimulation.GetState</c>, which the simulation owns nothing extra for.</summary>
    private static FluidBlockData.Entry StateAt(MinecraftRegistry registry, World world, Vec3<int> pos) {
        return FluidBlockData.Get(registry, world.GetBlockStateIdOr(pos.X, pos.Y, pos.Z, uint.MaxValue));
    }

    public static int FireTicks(Entity entity) => entity.GetTagOrDefault(FireTicksTag, 0);

    /// <summary><c>Entity.igniteForTicks</c>: a longer burn wins, a shorter one is ignored.</summary>
    public static void IgniteForTicks(Entity entity, int ticks) {
        if (FireTicks(entity) < ticks) {
            SetFireTicks(entity, ticks);
        }
    }

    /// <summary><c>Entity.clearFire</c>.</summary>
    public static void ClearFire(Entity entity) {
        if (FireTicks(entity) > 0) {
            SetFireTicks(entity, 0);
        }
    }

    public static void SetFireTicks(Entity entity, int ticks) {
        entity.SetTag(FireTicksTag, ticks);
        SetOnFireFlag(entity, ticks > 0);
    }

    /// <summary><c>Entity.setSharedFlagOnFire</c>, leaving the rest of the status byte alone.</summary>
    private static void SetOnFireFlag(Entity entity, bool onFire) {
        EntityStatus status = entity.Meta.Status ?? EntityStatus.None;
        EntityStatus updated = onFire
            ? status | EntityStatus.OnFire
            : status & ~EntityStatus.OnFire;

        if (updated != status) {
            entity.Meta = entity.Meta with { Status = updated };
        }
    }
}
