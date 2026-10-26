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
public record LeverBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.lever", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:lever", BlockInfo.VanillaOnly, "minecraft:blocks/lever");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S631, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S632 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S633 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S634 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S635 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S636 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S637 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S638 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I1, I1, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I6, I6, I7, I7, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 8439];

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
                        true => 8439,
                        false => 8440,
                    },
                    Direction.South => Powered switch {
                        true => 8441,
                        false => 8442,
                    },
                    Direction.West => Powered switch {
                        true => 8443,
                        false => 8444,
                    },
                    Direction.East => Powered switch {
                        true => 8445,
                        false => 8446,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 8447,
                        false => 8448,
                    },
                    Direction.South => Powered switch {
                        true => 8449,
                        false => 8450,
                    },
                    Direction.West => Powered switch {
                        true => 8451,
                        false => 8452,
                    },
                    Direction.East => Powered switch {
                        true => 8453,
                        false => 8454,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 8455,
                        false => 8456,
                    },
                    Direction.South => Powered switch {
                        true => 8457,
                        false => 8458,
                    },
                    Direction.West => Powered switch {
                        true => 8459,
                        false => 8460,
                    },
                    Direction.East => Powered switch {
                        true => 8461,
                        false => 8462,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8439 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            8440 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            8441 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            8442 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            8443 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            8444 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            8445 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            8446 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            8447 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            8448 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            8449 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            8450 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            8451 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            8452 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            8453 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            8454 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            8455 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            8456 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            8457 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            8458 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            8459 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            8460 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            8461 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            8462 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
