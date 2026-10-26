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
public record MangroveButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:mangrove_button", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_button");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 0, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S0, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 12610];

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
                        true => 12610,
                        false => 12611,
                    },
                    Direction.South => Powered switch {
                        true => 12612,
                        false => 12613,
                    },
                    Direction.West => Powered switch {
                        true => 12614,
                        false => 12615,
                    },
                    Direction.East => Powered switch {
                        true => 12616,
                        false => 12617,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 12618,
                        false => 12619,
                    },
                    Direction.South => Powered switch {
                        true => 12620,
                        false => 12621,
                    },
                    Direction.West => Powered switch {
                        true => 12622,
                        false => 12623,
                    },
                    Direction.East => Powered switch {
                        true => 12624,
                        false => 12625,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 12626,
                        false => 12627,
                    },
                    Direction.South => Powered switch {
                        true => 12628,
                        false => 12629,
                    },
                    Direction.West => Powered switch {
                        true => 12630,
                        false => 12631,
                    },
                    Direction.East => Powered switch {
                        true => 12632,
                        false => 12633,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12610 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            12611 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            12612 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            12613 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            12614 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            12615 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            12616 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            12617 => new MangroveButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            12618 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            12619 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            12620 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            12621 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            12622 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            12623 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            12624 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            12625 => new MangroveButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            12626 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            12627 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            12628 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            12629 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            12630 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            12631 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            12632 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            12633 => new MangroveButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
