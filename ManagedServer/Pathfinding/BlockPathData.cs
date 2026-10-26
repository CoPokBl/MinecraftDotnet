using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace ManagedServer.Pathfinding;

/// <summary>
/// What the pathfinder makes of a block, resolved once per block state.
/// <p/>
/// <c>WalkNodeEvaluator.getPathTypeFromState</c> is a pure function of the state, so the whole
/// answer is cached rather than the facts it is computed from: one <see cref="PathType"/> per state
/// id, which is both smaller and faster than a struct of a dozen flags. Modelled on
/// <c>ManagedServer.Physics.BlockPhysicsData</c>, which caches the physics half the same way.
/// <p/>
/// <b>This is the part the conformance harness exists for.</b> Every rule below is a rule our own
/// tests would encode too, so they would agree with a wrong one; <c>Conformance/pathtype.sh</c> runs
/// the real evaluator over every block state and <c>PathTypeConformanceTest</c> replays it.
/// </summary>
public static class BlockPathData {
    private static readonly ConcurrentDictionary<uint, PathType> Cache = new();

    /// <summary>
    /// <c>WalkNodeEvaluator.getPathTypeFromState</c>. Note what it is not: it is not "can an entity
    /// stand here". It classifies the block alone, and the layer above
    /// (<c>WalkNodeEvaluator.GetPathTypeStatic</c>) is what turns <see cref="PathType.Open"/> into
    /// something meaningful by looking at what is underneath and beside it.
    /// </summary>
    public static PathType Of(MinecraftRegistry registry, uint stateId) {
        return Cache.GetOrAdd(stateId, static (state, reg) =>
            reg.Blocks.StatesByStateId.TryGetValue(state, out IBlock? block)
                ? Classify(reg, block.WithState(state))
                // A state id from nowhere. Blocked rather than open, since a hole in the data should
                // stop a mob rather than route it through a wall.
                : PathType.Blocked, registry);
    }

    private static readonly Identifier LilyPad = "minecraft:lily_pad";
    private static readonly Identifier BigDripleaf = "minecraft:big_dripleaf";
    private static readonly Identifier PowderSnow = "minecraft:powder_snow";
    private static readonly Identifier Cactus = "minecraft:cactus";
    private static readonly Identifier SweetBerryBush = "minecraft:sweet_berry_bush";
    private static readonly Identifier HoneyBlock = "minecraft:honey_block";
    private static readonly Identifier Cocoa = "minecraft:cocoa";
    private static readonly Identifier WitherRose = "minecraft:wither_rose";
    private static readonly Identifier Lava = "minecraft:lava";
    private static readonly Identifier MagmaBlock = "minecraft:magma_block";
    private static readonly Identifier LavaCauldron = "minecraft:lava_cauldron";

    private static readonly Identifier TrapdoorsTag = "minecraft:trapdoors";
    private static readonly Identifier SpeleothemsTag = "minecraft:speleothems";
    private static readonly Identifier FencesTag = "minecraft:fences";
    private static readonly Identifier WallsTag = "minecraft:walls";
    private static readonly Identifier FireTag = "minecraft:fire";

    /// <summary>
    /// <c>getPathTypeFromState</c>, in vanilla's order. The order is the rule: a cactus is also
    /// solid, a lily pad is also pathfindable, and a wither rose is also a plant, so the first test
    /// that matches is the answer and moving one changes what a block means.
    /// </summary>
    private static PathType Classify(MinecraftRegistry registry, IBlock block) {
        Identifier id = block.Identifier;

        if (block.Air) {
            return PathType.Open;
        }

        if (InTag(registry, TrapdoorsTag, id) || id.Equals(LilyPad) || id.Equals(BigDripleaf)) {
            return PathType.Trapdoor;
        }

        if (id.Equals(PowderSnow)) {
            return PathType.PowderSnow;
        }

        if (id.Equals(Cactus) || id.Equals(SweetBerryBush)) {
            return PathType.Damaging;
        }

        if (id.Equals(HoneyBlock)) {
            return PathType.StickyHoney;
        }

        if (id.Equals(Cocoa)) {
            return PathType.Cocoa;
        }

        if (id.Equals(WitherRose) || InTag(registry, SpeleothemsTag, id)) {
            return PathType.DamageCautious;
        }

        if (IsLava(block.Fluid)) {
            return PathType.Lava;
        }

        if (IsBurning(registry, block)) {
            return PathType.Fire;
        }

        if (BlockClasses.Is(id, BlockClass.DoorBlock)) {
            if (IsOpen(block)) {
                return PathType.DoorOpen;
            }

            // Wood and iron are the same cost by default. The difference is that a mob told it can
            // open doors turns the wooden one into a route and the iron one stays a wall, and which
            // is which comes off the block set type rather than off the material.
            return BlockClasses.DoorOpensByHand(id) ? PathType.DoorWoodClosed : PathType.DoorIronClosed;
        }

        if (BlockClasses.Is(id, BlockClass.BaseRailBlock)) {
            return PathType.Rail;
        }

        if (BlockClasses.Is(id, BlockClass.LeavesBlock)) {
            return PathType.Leaves;
        }

        // A fence gate counts as a fence only while it is shut. Everything else here is a fence
        // whatever state it is in.
        if (InTag(registry, FencesTag, id) || InTag(registry, WallsTag, id) ||
            (BlockClasses.Is(id, BlockClass.FenceGateBlock) && !IsOpen(block))) {
            return PathType.Fence;
        }

        if (!block.PathfindableLand) {
            return PathType.Blocked;
        }

        return IsWater(block.Fluid) ? PathType.Water : PathType.Open;
    }

    /// <summary>
    /// <c>NodeEvaluator.isBurningBlock</c>. Campfires need the lit state as well as the class, which
    /// is why this is not simply a tag.
    /// </summary>
    private static bool IsBurning(MinecraftRegistry registry, IBlock block) {
        Identifier id = block.Identifier;

        return InTag(registry, FireTag, id)
               || id.Equals(Lava)
               || id.Equals(MagmaBlock)
               || (BlockClasses.Is(id, BlockClass.CampfireBlock) && IsLit(block))
               || id.Equals(LavaCauldron);
    }

    /// <summary>
    /// Vanilla asks <c>FluidTags.WATER</c>, whose two members are the source and the flowing form.
    /// Read off the state's fluid rather than from the tag registry, since fluid tags are not among
    /// the ones the generator keeps.
    /// </summary>
    private static bool IsWater(Identifier? fluid) {
        return fluid is not null &&
               (fluid.Value.Equals("minecraft:water") || fluid.Value.Equals("minecraft:flowing_water"));
    }

    private static bool IsLava(Identifier? fluid) {
        return fluid is not null &&
               (fluid.Value.Equals("minecraft:lava") || fluid.Value.Equals("minecraft:flowing_lava"));
    }

    /// <summary>
    /// The <c>open</c> property of a door or fence gate, read out of the state's own property map
    /// rather than by casting to one of a hundred generated block records. The names here are
    /// vanilla's property names, which is what makes this survive a block record being regenerated
    /// under a different C# shape.
    /// </summary>
    private static bool IsOpen(IBlock block) {
        return BoolProperty(block, "open");
    }

    private static bool IsLit(IBlock block) {
        return BoolProperty(block, "lit");
    }

    private static bool BoolProperty(IBlock block, string name) {
        return block.ToStateNbt()[name] is StringTag { Value: "true" };
    }

    private static bool InTag(MinecraftRegistry registry, Identifier tag, Identifier block) {
        if (!registry.Blocks.Tags.Contains(tag)) {
            return false;
        }

        foreach (Identifier value in registry.Blocks.Tags[tag].GetValueIds(registry)) {
            if (value.Equals(block)) {
                return true;
            }
        }

        return false;
    }
}
