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
public record BambooButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:bamboo_button", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_button");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 0, "bamboo_wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S0, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 12658];

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
                        true => 12658,
                        false => 12659,
                    },
                    Direction.South => Powered switch {
                        true => 12660,
                        false => 12661,
                    },
                    Direction.West => Powered switch {
                        true => 12662,
                        false => 12663,
                    },
                    Direction.East => Powered switch {
                        true => 12664,
                        false => 12665,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 12666,
                        false => 12667,
                    },
                    Direction.South => Powered switch {
                        true => 12668,
                        false => 12669,
                    },
                    Direction.West => Powered switch {
                        true => 12670,
                        false => 12671,
                    },
                    Direction.East => Powered switch {
                        true => 12672,
                        false => 12673,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 12674,
                        false => 12675,
                    },
                    Direction.South => Powered switch {
                        true => 12676,
                        false => 12677,
                    },
                    Direction.West => Powered switch {
                        true => 12678,
                        false => 12679,
                    },
                    Direction.East => Powered switch {
                        true => 12680,
                        false => 12681,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12658 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            12659 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            12660 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            12661 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            12662 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            12663 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            12664 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            12665 => new BambooButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            12666 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            12667 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            12668 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            12669 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            12670 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            12671 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            12672 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            12673 => new BambooButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            12674 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            12675 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            12676 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            12677 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            12678 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            12679 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            12680 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            12681 => new BambooButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
