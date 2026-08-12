using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperChestBlock(Identifier Identifier, CopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_chest", "block.minecraft.copper_chest", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chest", "minecraft:copper_chest", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "copper", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, false, false, true, false, false, true, [], "minecraft:water", BlockShapes.S414, BlockShapes.S414, BlockShapes.S1, BlockShapes.S414, BlockShapes.S414);
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

    public BlockStateInfo StateInfo => States[StateId - 29568];

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
                        true => 29568,
                        false => 29569,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29574,
                        false => 29575,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29580,
                        false => 29581,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29586,
                        false => 29587,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29570,
                        false => 29571,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29576,
                        false => 29577,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29582,
                        false => 29583,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29588,
                        false => 29589,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29572,
                        false => 29573,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29578,
                        false => 29579,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29584,
                        false => 29585,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29590,
                        false => 29591,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29568 => new CopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29569 => new CopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29570 => new CopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29571 => new CopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29572 => new CopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29573 => new CopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29574 => new CopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29575 => new CopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29576 => new CopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29577 => new CopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29578 => new CopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29579 => new CopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29580 => new CopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29581 => new CopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29582 => new CopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29583 => new CopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29584 => new CopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29585 => new CopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29586 => new CopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29587 => new CopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29588 => new CopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29589 => new CopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29590 => new CopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29591 => new CopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
