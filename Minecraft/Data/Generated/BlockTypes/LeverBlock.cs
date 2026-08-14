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
    private static readonly BlockInfo Data = new("minecraft:lever", "block.minecraft.lever", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:lever", BlockInfo.VanillaOnly, "minecraft:blocks/lever");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S630, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S631 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S632 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S633 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S634 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S635 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S636 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S637 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I1, I1, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I6, I6, I7, I7, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 6771];

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

    public IBlock WithFace(AttachDirection face) => this with { Face = face };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => Powered switch {
                        true => 6771,
                        false => 6772,
                    },
                    Direction.South => Powered switch {
                        true => 6773,
                        false => 6774,
                    },
                    Direction.West => Powered switch {
                        true => 6775,
                        false => 6776,
                    },
                    Direction.East => Powered switch {
                        true => 6777,
                        false => 6778,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 6779,
                        false => 6780,
                    },
                    Direction.South => Powered switch {
                        true => 6781,
                        false => 6782,
                    },
                    Direction.West => Powered switch {
                        true => 6783,
                        false => 6784,
                    },
                    Direction.East => Powered switch {
                        true => 6785,
                        false => 6786,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 6787,
                        false => 6788,
                    },
                    Direction.South => Powered switch {
                        true => 6789,
                        false => 6790,
                    },
                    Direction.West => Powered switch {
                        true => 6791,
                        false => 6792,
                    },
                    Direction.East => Powered switch {
                        true => 6793,
                        false => 6794,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6771 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            6772 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            6773 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            6774 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            6775 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            6776 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            6777 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            6778 => new LeverBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            6779 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            6780 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            6781 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            6782 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            6783 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            6784 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            6785 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            6786 => new LeverBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            6787 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            6788 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            6789 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            6790 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            6791 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            6792 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            6793 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            6794 => new LeverBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
