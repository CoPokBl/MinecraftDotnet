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
public record PolishedBlackstoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.polished_blackstone_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:polished_blackstone_button", BlockInfo.VanillaOnly, "minecraft:blocks/polished_blackstone_button");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S0, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
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

    public BlockStateInfo StateInfo => States[StateId - 26102];

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
                        true => 26102,
                        false => 26103,
                    },
                    Direction.South => Powered switch {
                        true => 26104,
                        false => 26105,
                    },
                    Direction.West => Powered switch {
                        true => 26106,
                        false => 26107,
                    },
                    Direction.East => Powered switch {
                        true => 26108,
                        false => 26109,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 26110,
                        false => 26111,
                    },
                    Direction.South => Powered switch {
                        true => 26112,
                        false => 26113,
                    },
                    Direction.West => Powered switch {
                        true => 26114,
                        false => 26115,
                    },
                    Direction.East => Powered switch {
                        true => 26116,
                        false => 26117,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 26118,
                        false => 26119,
                    },
                    Direction.South => Powered switch {
                        true => 26120,
                        false => 26121,
                    },
                    Direction.West => Powered switch {
                        true => 26122,
                        false => 26123,
                    },
                    Direction.East => Powered switch {
                        true => 26124,
                        false => 26125,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            26102 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            26103 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            26104 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            26105 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            26106 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            26107 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            26108 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            26109 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            26110 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            26111 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            26112 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            26113 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            26114 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            26115 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            26116 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            26117 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            26118 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            26119 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            26120 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            26121 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            26122 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            26123 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            26124 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            26125 => new PolishedBlackstoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
