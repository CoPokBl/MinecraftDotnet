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
    private static readonly BlockInfo Data = new("block.minecraft.bell", 5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:bell", "minecraft:bell", BlockInfo.VanillaOnly, "minecraft:blocks/bell");
    private static readonly BlockStateInfo I0 = new(5f, 0, 0, PushReaction.Popped, 30, "anvil", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S335, BlockShapes.S335, BlockShapes.S1, BlockShapes.S335, BlockShapes.S335, BlockShapes.S335);
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

    public BlockStateInfo StateInfo => States[StateId - 24162];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
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
                        true => 24162,
                        false => 24163,
                    },
                    Direction.South => Powered switch {
                        true => 24164,
                        false => 24165,
                    },
                    Direction.West => Powered switch {
                        true => 24166,
                        false => 24167,
                    },
                    Direction.East => Powered switch {
                        true => 24168,
                        false => 24169,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                BellAttachType.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 24170,
                        false => 24171,
                    },
                    Direction.South => Powered switch {
                        true => 24172,
                        false => 24173,
                    },
                    Direction.West => Powered switch {
                        true => 24174,
                        false => 24175,
                    },
                    Direction.East => Powered switch {
                        true => 24176,
                        false => 24177,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                BellAttachType.SingleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 24178,
                        false => 24179,
                    },
                    Direction.South => Powered switch {
                        true => 24180,
                        false => 24181,
                    },
                    Direction.West => Powered switch {
                        true => 24182,
                        false => 24183,
                    },
                    Direction.East => Powered switch {
                        true => 24184,
                        false => 24185,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                BellAttachType.DoubleWall => Facing switch {
                    Direction.North => Powered switch {
                        true => 24186,
                        false => 24187,
                    },
                    Direction.South => Powered switch {
                        true => 24188,
                        false => 24189,
                    },
                    Direction.West => Powered switch {
                        true => 24190,
                        false => 24191,
                    },
                    Direction.East => Powered switch {
                        true => 24192,
                        false => 24193,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Attachment), Attachment, "Unknown value for property attachment.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24162 => new BellBlock(Identifier, BellAttachType.Floor, Direction.North, true),
            24163 => new BellBlock(Identifier, BellAttachType.Floor, Direction.North, false),
            24164 => new BellBlock(Identifier, BellAttachType.Floor, Direction.South, true),
            24165 => new BellBlock(Identifier, BellAttachType.Floor, Direction.South, false),
            24166 => new BellBlock(Identifier, BellAttachType.Floor, Direction.West, true),
            24167 => new BellBlock(Identifier, BellAttachType.Floor, Direction.West, false),
            24168 => new BellBlock(Identifier, BellAttachType.Floor, Direction.East, true),
            24169 => new BellBlock(Identifier, BellAttachType.Floor, Direction.East, false),
            24170 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.North, true),
            24171 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.North, false),
            24172 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.South, true),
            24173 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.South, false),
            24174 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.West, true),
            24175 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.West, false),
            24176 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.East, true),
            24177 => new BellBlock(Identifier, BellAttachType.Ceiling, Direction.East, false),
            24178 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.North, true),
            24179 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.North, false),
            24180 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.South, true),
            24181 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.South, false),
            24182 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.West, true),
            24183 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.West, false),
            24184 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.East, true),
            24185 => new BellBlock(Identifier, BellAttachType.SingleWall, Direction.East, false),
            24186 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.North, true),
            24187 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.North, false),
            24188 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.South, true),
            24189 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.South, false),
            24190 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.West, true),
            24191 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.West, false),
            24192 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.East, true),
            24193 => new BellBlock(Identifier, BellAttachType.DoubleWall, Direction.East, false),
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
