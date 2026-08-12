using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BellBlock(Identifier Identifier, BellBlock.Attachment AttachmentValue, Direction Facing, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:bell", "block.minecraft.bell", 5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:bell", "minecraft:bell", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(5f, 0, 0, PushReaction.Destroy, 30, "anvil", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S333, BlockShapes.S333, BlockShapes.S1, BlockShapes.S333, BlockShapes.S333);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S334, CollisionShape = BlockShapes.S334, OcclusionShape = BlockShapes.S334, VisualShape = BlockShapes.S334 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S335, CollisionShape = BlockShapes.S335, OcclusionShape = BlockShapes.S335, VisualShape = BlockShapes.S335 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S336, CollisionShape = BlockShapes.S336, OcclusionShape = BlockShapes.S336, VisualShape = BlockShapes.S336 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S337, CollisionShape = BlockShapes.S337, OcclusionShape = BlockShapes.S337, VisualShape = BlockShapes.S337 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S338, CollisionShape = BlockShapes.S338, OcclusionShape = BlockShapes.S338, VisualShape = BlockShapes.S338 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S339, CollisionShape = BlockShapes.S339, OcclusionShape = BlockShapes.S339, VisualShape = BlockShapes.S339 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S340, CollisionShape = BlockShapes.S340, OcclusionShape = BlockShapes.S340, VisualShape = BlockShapes.S340 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S341, CollisionShape = BlockShapes.S341, OcclusionShape = BlockShapes.S341, VisualShape = BlockShapes.S341 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I1, I1, I1, I1, I2, I2, I2, I2, I2, I2, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I7, I7, I7, I7, I8, I8, I8, I8
    ];

    public BlockStateInfo StateInfo => States[StateId - 20805];

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
            return AttachmentValue switch {
                Attachment.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 20805,
                        false => 20806,
                    },
                    Direction.South => Powered switch {
                        true => 20807,
                        false => 20808,
                    },
                    Direction.West => Powered switch {
                        true => 20809,
                        false => 20810,
                    },
                    Direction.East => Powered switch {
                        true => 20811,
                        false => 20812,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 20813,
                        false => 20814,
                    },
                    Direction.South => Powered switch {
                        true => 20815,
                        false => 20816,
                    },
                    Direction.West => Powered switch {
                        true => 20817,
                        false => 20818,
                    },
                    Direction.East => Powered switch {
                        true => 20819,
                        false => 20820,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20821,
                        false => 20822,
                    },
                    Direction.South => Powered switch {
                        true => 20823,
                        false => 20824,
                    },
                    Direction.West => Powered switch {
                        true => 20825,
                        false => 20826,
                    },
                    Direction.East => Powered switch {
                        true => 20827,
                        false => 20828,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Attachment.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 20829,
                        false => 20830,
                    },
                    Direction.South => Powered switch {
                        true => 20831,
                        false => 20832,
                    },
                    Direction.West => Powered switch {
                        true => 20833,
                        false => 20834,
                    },
                    Direction.East => Powered switch {
                        true => 20835,
                        false => 20836,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(AttachmentValue), AttachmentValue, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20805 => new BellBlock(Identifier, Attachment.Floor, Direction.North, true),
            20806 => new BellBlock(Identifier, Attachment.Floor, Direction.North, false),
            20807 => new BellBlock(Identifier, Attachment.Floor, Direction.South, true),
            20808 => new BellBlock(Identifier, Attachment.Floor, Direction.South, false),
            20809 => new BellBlock(Identifier, Attachment.Floor, Direction.West, true),
            20810 => new BellBlock(Identifier, Attachment.Floor, Direction.West, false),
            20811 => new BellBlock(Identifier, Attachment.Floor, Direction.East, true),
            20812 => new BellBlock(Identifier, Attachment.Floor, Direction.East, false),
            20813 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, true),
            20814 => new BellBlock(Identifier, Attachment.Ceiling, Direction.North, false),
            20815 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, true),
            20816 => new BellBlock(Identifier, Attachment.Ceiling, Direction.South, false),
            20817 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, true),
            20818 => new BellBlock(Identifier, Attachment.Ceiling, Direction.West, false),
            20819 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, true),
            20820 => new BellBlock(Identifier, Attachment.Ceiling, Direction.East, false),
            20821 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, true),
            20822 => new BellBlock(Identifier, Attachment.SingleWall, Direction.North, false),
            20823 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, true),
            20824 => new BellBlock(Identifier, Attachment.SingleWall, Direction.South, false),
            20825 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, true),
            20826 => new BellBlock(Identifier, Attachment.SingleWall, Direction.West, false),
            20827 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, true),
            20828 => new BellBlock(Identifier, Attachment.SingleWall, Direction.East, false),
            20829 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, true),
            20830 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.North, false),
            20831 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, true),
            20832 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.South, false),
            20833 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, true),
            20834 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.West, false),
            20835 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, true),
            20836 => new BellBlock(Identifier, Attachment.DoubleWall, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AttachmentValue = properties.Contains("attachment") ? AttachmentFromString(properties["attachment"].GetString()) : AttachmentValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attachment", new StringTag(AttachmentToName(AttachmentValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
    public enum Attachment {
        Floor,
        Ceiling,
        SingleWall,
        DoubleWall,
    }

    public static Attachment AttachmentFromString(string value) {
        return value switch {
            "floor" => Attachment.Floor,
            "ceiling" => Attachment.Ceiling,
            "single_wall" => Attachment.SingleWall,
            "double_wall" => Attachment.DoubleWall,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Attachment.")
        };
    }

    public static string AttachmentToName(Attachment value) {
        return value switch {
            Attachment.Floor => "floor",
            Attachment.Ceiling => "ceiling",
            Attachment.SingleWall => "single_wall",
            Attachment.DoubleWall => "double_wall",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Attachment value.")
        };
    }
}
