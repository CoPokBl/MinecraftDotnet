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
public record AcaciaButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("minecraft:button", "block.minecraft.acacia_button", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:acacia_button", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Destroy, 0, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S0, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S2 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S3 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S4 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S5 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S6 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S7 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S8 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S9 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S10 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S11 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S12 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S13 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S14 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S15 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S16 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I12, I13, I14, I15, I14, I15
    ];

    public BlockStateInfo StateInfo => States[StateId - 10771];

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

    public IBlock WithFace(AttachDirection face) => this with { Face = face };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 10771,
                        false => 10772,
                    },
                    Direction.South => Powered switch {
                        true => 10773,
                        false => 10774,
                    },
                    Direction.West => Powered switch {
                        true => 10775,
                        false => 10776,
                    },
                    Direction.East => Powered switch {
                        true => 10777,
                        false => 10778,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 10779,
                        false => 10780,
                    },
                    Direction.South => Powered switch {
                        true => 10781,
                        false => 10782,
                    },
                    Direction.West => Powered switch {
                        true => 10783,
                        false => 10784,
                    },
                    Direction.East => Powered switch {
                        true => 10785,
                        false => 10786,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 10787,
                        false => 10788,
                    },
                    Direction.South => Powered switch {
                        true => 10789,
                        false => 10790,
                    },
                    Direction.West => Powered switch {
                        true => 10791,
                        false => 10792,
                    },
                    Direction.East => Powered switch {
                        true => 10793,
                        false => 10794,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10771 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            10772 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            10773 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            10774 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            10775 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            10776 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            10777 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            10778 => new AcaciaButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            10779 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            10780 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            10781 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            10782 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            10783 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            10784 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            10785 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            10786 => new AcaciaButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            10787 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            10788 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            10789 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            10790 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            10791 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            10792 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            10793 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            10794 => new AcaciaButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.Contains("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("face", new StringTag(Face.ToName())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
