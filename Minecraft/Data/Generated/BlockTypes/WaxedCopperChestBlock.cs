using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperChestBlock(Identifier Identifier, WaxedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:copper_chest", "block.minecraft.waxed_copper_chest", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chest", "minecraft:waxed_copper_chest", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "copper", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S414, BlockShapes.S414, BlockShapes.S1, BlockShapes.S414, BlockShapes.S414);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S415, CollisionShape = BlockShapes.S415, OcclusionShape = BlockShapes.S415, VisualShape = BlockShapes.S415 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S415, CollisionShape = BlockShapes.S415, OcclusionShape = BlockShapes.S415, VisualShape = BlockShapes.S415 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S416, CollisionShape = BlockShapes.S416, OcclusionShape = BlockShapes.S416, VisualShape = BlockShapes.S416 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S416, CollisionShape = BlockShapes.S416, OcclusionShape = BlockShapes.S416, VisualShape = BlockShapes.S416 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S417, CollisionShape = BlockShapes.S417, OcclusionShape = BlockShapes.S417, VisualShape = BlockShapes.S417 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S417, CollisionShape = BlockShapes.S417, OcclusionShape = BlockShapes.S417, VisualShape = BlockShapes.S417 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S418, CollisionShape = BlockShapes.S418, OcclusionShape = BlockShapes.S418, VisualShape = BlockShapes.S418 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S418, CollisionShape = BlockShapes.S418, OcclusionShape = BlockShapes.S418, VisualShape = BlockShapes.S418 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I0, I1, I4, I5, I2, I3, I0, I1, I6, I7, I8, I9, I0, I1, I8, I9, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 29664];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29664,
                        false => 29665,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29670,
                        false => 29671,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29676,
                        false => 29677,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29682,
                        false => 29683,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29666,
                        false => 29667,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29672,
                        false => 29673,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29678,
                        false => 29679,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29684,
                        false => 29685,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29668,
                        false => 29669,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29674,
                        false => 29675,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29680,
                        false => 29681,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29686,
                        false => 29687,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29664 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29665 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29666 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29667 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29668 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29669 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29670 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29671 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29672 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29673 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29674 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29675 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29676 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29677 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29678 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29679 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29680 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29681 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29682 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29683 => new WaxedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29684 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29685 => new WaxedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29686 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29687 => new WaxedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Type {
        Single,
        Left,
        Right,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "single" => Type.Single,
            "left" => Type.Left,
            "right" => Type.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }

    public static string TypeToName(Type value) {
        return value switch {
            Type.Single => "single",
            Type.Left => "left",
            Type.Right => "right",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type value.")
        };
    }
}
