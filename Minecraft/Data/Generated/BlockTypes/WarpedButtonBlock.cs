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
public record WarpedButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.warped_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:warped_button", BlockInfo.VanillaOnly, "minecraft:blocks/warped_button");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 0, "nether_wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S0, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 24847];

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

    public IBlock WithFace(AttachDirection face) => this with { Face = face };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 24847,
                        false => 24848,
                    },
                    Direction.South => Powered switch {
                        true => 24849,
                        false => 24850,
                    },
                    Direction.West => Powered switch {
                        true => 24851,
                        false => 24852,
                    },
                    Direction.East => Powered switch {
                        true => 24853,
                        false => 24854,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 24855,
                        false => 24856,
                    },
                    Direction.South => Powered switch {
                        true => 24857,
                        false => 24858,
                    },
                    Direction.West => Powered switch {
                        true => 24859,
                        false => 24860,
                    },
                    Direction.East => Powered switch {
                        true => 24861,
                        false => 24862,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 24863,
                        false => 24864,
                    },
                    Direction.South => Powered switch {
                        true => 24865,
                        false => 24866,
                    },
                    Direction.West => Powered switch {
                        true => 24867,
                        false => 24868,
                    },
                    Direction.East => Powered switch {
                        true => 24869,
                        false => 24870,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24847 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            24848 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            24849 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            24850 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            24851 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            24852 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            24853 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            24854 => new WarpedButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            24855 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            24856 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            24857 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            24858 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            24859 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            24860 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            24861 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            24862 => new WarpedButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            24863 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            24864 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            24865 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            24866 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            24867 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            24868 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            24869 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            24870 => new WarpedButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
