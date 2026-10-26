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
public record DarkOakButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dark_oak_button", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_button");
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

    public BlockStateInfo StateInfo => States[StateId - 12562];

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
                        true => 12562,
                        false => 12563,
                    },
                    Direction.South => Powered switch {
                        true => 12564,
                        false => 12565,
                    },
                    Direction.West => Powered switch {
                        true => 12566,
                        false => 12567,
                    },
                    Direction.East => Powered switch {
                        true => 12568,
                        false => 12569,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 12570,
                        false => 12571,
                    },
                    Direction.South => Powered switch {
                        true => 12572,
                        false => 12573,
                    },
                    Direction.West => Powered switch {
                        true => 12574,
                        false => 12575,
                    },
                    Direction.East => Powered switch {
                        true => 12576,
                        false => 12577,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 12578,
                        false => 12579,
                    },
                    Direction.South => Powered switch {
                        true => 12580,
                        false => 12581,
                    },
                    Direction.West => Powered switch {
                        true => 12582,
                        false => 12583,
                    },
                    Direction.East => Powered switch {
                        true => 12584,
                        false => 12585,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12562 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            12563 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            12564 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            12565 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            12566 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            12567 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            12568 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            12569 => new DarkOakButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            12570 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            12571 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            12572 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            12573 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            12574 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            12575 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            12576 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            12577 => new DarkOakButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            12578 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            12579 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            12580 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            12581 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            12582 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            12583 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            12584 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            12585 => new DarkOakButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
