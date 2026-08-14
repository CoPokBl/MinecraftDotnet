using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BellBlock(Identifier Identifier, BellAttachType Attachment, Direction Facing, bool Powered) : IBlock, IBellAttached, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("minecraft:bell", "block.minecraft.bell", 5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:bell", "minecraft:bell", BlockInfo.VanillaOnly, "minecraft:blocks/bell");
    private static readonly BlockStateInfo I0 = new(5f, 0, 0, PushReaction.Destroy, 30, "anvil", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S335, BlockShapes.S335, BlockShapes.S1, BlockShapes.S335, BlockShapes.S335, BlockShapes.S335);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S336, CollisionShape = BlockShapes.S336, OcclusionShape = BlockShapes.S336, VisualShape = BlockShapes.S336, SupportShape = BlockShapes.S336 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S337, CollisionShape = BlockShapes.S337, OcclusionShape = BlockShapes.S337, VisualShape = BlockShapes.S337, SupportShape = BlockShapes.S337 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S338, CollisionShape = BlockShapes.S338, OcclusionShape = BlockShapes.S338, VisualShape = BlockShapes.S338, SupportShape = BlockShapes.S338 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S339, CollisionShape = BlockShapes.S339, OcclusionShape = BlockShapes.S339, VisualShape = BlockShapes.S339, SupportShape = BlockShapes.S339 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S340, CollisionShape = BlockShapes.S340, OcclusionShape = BlockShapes.S340, VisualShape = BlockShapes.S340, SupportShape = BlockShapes.S340 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S341, CollisionShape = BlockShapes.S341, OcclusionShape = BlockShapes.S341, VisualShape = BlockShapes.S341, SupportShape = BlockShapes.S341 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S342, CollisionShape = BlockShapes.S342, OcclusionShape = BlockShapes.S342, VisualShape = BlockShapes.S342, SupportShape = BlockShapes.S342 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S343, CollisionShape = BlockShapes.S343, OcclusionShape = BlockShapes.S343, VisualShape = BlockShapes.S343, SupportShape = BlockShapes.S343 };
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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
    public ICollisionBox SupportShape => StateInfo.SupportShape;
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
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithAttachment(BellAttachType attachment) => this with { Attachment = attachment };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Attachment switch {
                BellAttachType.Floor => Facing switch {
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
                BellAttachType.Ceiling => Facing switch {
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
                BellAttachType.SingleWall => Facing switch {
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
                BellAttachType.DoubleWall => Facing switch {
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
                _ => throw new ArgumentOutOfRangeException(nameof(Attachment), Attachment, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20805 => new BellBlock(Identifier, BellAttachType.Floor, Direction.North, true),
            20806 => new BellBlock(Identifier, BellAttachType.Floor, Direction.North, false),
            20807 => new BellBlock(Identifier, BellAttachType.Floor, Direction.South, true),
            20808 => new BellBlock(Identifier, BellAttachType.Floor, Direction.South, false),
            20809 => new BellBlock(Identifier, BellAttachType.Floor, Direction.West, true),
            20810 => new BellBlock(Identifier, BellAttachType.Floor, Direction.West, false),
            20811 => new BellBlock(Identifier, BellAttachType.Floor, Direction.East, true),
            20812 => new BellBlock(Identifier, BellAttachType.Floor, Direction.East, false),
            20813 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.North, true),
            20814 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.North, false),
            20815 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.South, true),
            20816 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.South, false),
            20817 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.West, true),
            20818 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.West, false),
            20819 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.East, true),
            20820 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.East, false),
            20821 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.North, true),
            20822 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.North, false),
            20823 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.South, true),
            20824 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.South, false),
            20825 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.West, true),
            20826 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.West, false),
            20827 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.East, true),
            20828 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.East, false),
            20829 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.North, true),
            20830 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.North, false),
            20831 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.South, true),
            20832 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.South, false),
            20833 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.West, true),
            20834 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.West, false),
            20835 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.East, true),
            20836 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attachment = properties.Contains("attachment") ? BellAttachTypeExtensions.FromString(properties["attachment"].GetString()) : Attachment,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attachment", new StringTag(Attachment.ToName())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
