using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Physics;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Shapes;

namespace ClientLib.Physics;

public enum FluidKind : byte {
    Empty,
    Water,
    Lava
}

/// <summary>
/// Everything the player's movement asks of a block state on top of <see cref="BlockPhysicsData"/>,
/// resolved once per state.
/// </summary>
public static class MovementBlocks {
    /// <param name="FluidAmount">Ninths of a block the state's fluid fills on its own, <c>getOwnHeight * 9</c>.</param>
    /// <param name="SourceLiquidBlock">
    /// A water or lava block at level 0, the only <c>LiquidBlock</c> state <c>getCollisionShape</c> can
    /// give a shape to; a waterlogged block's fluid never collides.
    /// </param>
    /// <param name="SturdyFaces">
    /// Bit per <see cref="Face"/>: whether <c>isFaceSturdy</c> holds for that face, which is what a
    /// falling fluid's flow is turned downwards by.
    /// </param>
    /// <param name="StuckMultiplier">
    /// What <c>entityInside</c> passes to <c>makeStuckInBlock</c>, or null for a block that does not
    /// slow what is inside it.
    /// </param>
    public readonly record struct Entry(
        bool Climbable,
        bool Suffocating,
        bool BlocksFluidFlow,
        FluidKind Fluid,
        int FluidAmount,
        bool FluidFalling,
        bool SourceLiquidBlock,
        byte SturdyFaces,
        bool Trapdoor,
        bool TrapdoorOpen,
        Direction Facing,
        bool Ladder,
        bool Scaffolding,
        Maths.Vec3d? StuckMultiplier);

    private static readonly ConcurrentDictionary<uint, Entry> Cache = new();
    private static readonly Identifier ClimbableTag = "minecraft:climbable";
    private static readonly Identifier BlocksFluidFlowTag = "minecraft:blocks_fluid_flow";

    /// <summary><c>LivingEntity.onClimbable</c> for an entity whose block position is given, before the spectator check.</summary>
    public static bool OnClimbable(World.ClientLevel level, int x, int y, int z) {
        Entry state = Get(level.Registry, level.GetState(x, y, z));
        if (state.Climbable) {
            return true;
        }
        if (state.Trapdoor && state.TrapdoorOpen) {
            Entry below = Get(level.Registry, level.GetState(x, y - 1, z));
            return below.Ladder && below.Facing == state.Facing;
        }
        return false;
    }

    public static Entry Get(MinecraftRegistry registry, uint stateId) {
        return Cache.GetOrAdd(stateId, static (state, reg) => Build(reg, state), registry);
    }

    private static Entry Build(MinecraftRegistry registry, uint stateId) {
        IBlock block = registry.Blocks.GetByStateId(stateId);
        (FluidKind fluid, int amount, bool falling) = FluidOf(block);
        bool trapdoor = BlockClasses.Is(block.Identifier, BlockClass.TrapDoorBlock);
        return new Entry(
            InTag(registry, ClimbableTag, block.Identifier),
            block.StateInfo.Suffocating,
            InTag(registry, BlocksFluidFlowTag, block.Identifier),
            fluid,
            amount,
            falling,
            block is WaterBlock { Level: 0 } or LavaBlock { Level: 0 },
            SturdyFacesOf(block.SupportShape),
            trapdoor,
            trapdoor && block is IOpenable { Open: true },
            block is IHorizontalFacing facing ? facing.Facing : Direction.North,
            block is LadderBlock,
            block is ScaffoldingBlock,
            StuckOf(block));
    }

    /// <summary>
    /// <c>BlockState.getFluidState</c>: water and lava from their legacy level, as <c>LiquidBlock</c>
    /// caches them, and a waterlogged block as a still source.
    /// </summary>
    private static (FluidKind, int, bool) FluidOf(IBlock block) {
        switch (block) {
            case WaterBlock water:
                return FromLegacyLevel(FluidKind.Water, water.Level);
            case LavaBlock lava:
                return FromLegacyLevel(FluidKind.Lava, lava.Level);
        }
        if (block.Fluid == null) {
            return (FluidKind.Empty, 0, false);
        }
        string path = block.Fluid.Value.Key;
        return (path.Contains("lava") ? FluidKind.Lava : FluidKind.Water, 8, false);
    }

    private static (FluidKind, int, bool) FromLegacyLevel(FluidKind kind, int level) {
        int index = Math.Min(level, 8);
        return index switch {
            0 => (kind, 8, false),
            8 => (kind, 8, true),
            _ => (kind, 8 - index, false)
        };
    }

    /// <summary>
    /// The blocks whose <c>entityInside</c> calls <c>makeStuckInBlock</c>. Powder snow catches a living
    /// entity only from the block it stands in, which the callers check.
    /// </summary>
    private static Maths.Vec3d? StuckOf(IBlock block) {
        if (block.Identifier.Equals(Block.Cobweb.Identifier)) {
            return new Maths.Vec3d(0.25, 0.05F, 0.25);
        }
        if (block is SweetBerryBushBlock) {
            return new Maths.Vec3d(0.8F, 0.75, 0.8F);
        }
        if (block.Identifier.Equals(Block.PowderSnow.Identifier)) {
            return new Maths.Vec3d(0.9F, 1.5, 0.9F);
        }
        return null;
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

    /// <summary>
    /// <c>Block.isFaceFull(getBlockSupportShape().getFaceShape(direction))</c> for each face: the boxes
    /// touching the face, projected onto it, must cover the whole square.
    /// </summary>
    private static byte SturdyFacesOf(ICollisionBox shape) {
        Box[] boxes = BlockPhysicsData.ShapeBoxesOf(shape);
        byte faces = 0;
        for (int face = 0; face < 6; face++) {
            if (FaceFull(boxes, (Face)face)) {
                faces |= (byte)(1 << face);
            }
        }
        return faces;
    }

    private static bool FaceFull(Box[] boxes, Face face) {
        int axis = Faces.Axis(face);
        bool positive = Faces.Positive(face);
        int u = axis == 0 ? 1 : 0;
        int v = axis == 2 ? 1 : 2;

        List<Box> touching = [];
        foreach (Box box in boxes) {
            double edge = positive ? box.Max(axis) : box.Min(axis);
            if (Math.Abs(edge - (positive ? 1.0 : 0.0)) < 1.0E-7) {
                touching.Add(box);
            }
        }
        if (touching.Count == 0) {
            return false;
        }

        SortedSet<double> us = [0.0, 1.0];
        SortedSet<double> vs = [0.0, 1.0];
        foreach (Box box in touching) {
            us.Add(Math.Clamp(box.Min(u), 0, 1));
            us.Add(Math.Clamp(box.Max(u), 0, 1));
            vs.Add(Math.Clamp(box.Min(v), 0, 1));
            vs.Add(Math.Clamp(box.Max(v), 0, 1));
        }
        double[] uc = us.ToArray();
        double[] vc = vs.ToArray();
        for (int i = 0; i < uc.Length - 1; i++) {
            for (int j = 0; j < vc.Length - 1; j++) {
                double cu = (uc[i] + uc[i + 1]) / 2;
                double cv = (vc[j] + vc[j + 1]) / 2;
                bool covered = false;
                foreach (Box box in touching) {
                    if (box.Min(u) <= cu && cu <= box.Max(u) && box.Min(v) <= cv && cv <= box.Max(v)) {
                        covered = true;
                        break;
                    }
                }
                if (!covered) {
                    return false;
                }
            }
        }
        return true;
    }
}

/// <summary>Vanilla's six <c>Direction</c>s, in its declaration order.</summary>
public enum Face : byte {
    Down,
    Up,
    North,
    South,
    West,
    East
}

public static class Faces {
    /// <summary><c>Direction.Plane.HORIZONTAL</c>, which is compass order and not declaration order.</summary>
    public static readonly Face[] Horizontal = [Face.North, Face.East, Face.South, Face.West];

    public static int Axis(Face face) => face switch {
        Face.Down or Face.Up => 1,
        Face.North or Face.South => 2,
        _ => 0
    };

    public static bool Positive(Face face) => face is Face.Up or Face.South or Face.East;

    public static int StepX(Face face) => face == Face.East ? 1 : face == Face.West ? -1 : 0;
    public static int StepZ(Face face) => face == Face.South ? 1 : face == Face.North ? -1 : 0;
}
