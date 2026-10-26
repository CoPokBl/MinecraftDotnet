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
public record StoneButtonBlock(Identifier Identifier, AttachDirection Face, Direction Facing, bool Powered) : IBlock, IAttachFaced, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.stone_button", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:stone_button", BlockInfo.VanillaOnly, "minecraft:blocks/stone_button");
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

    public BlockStateInfo StateInfo => States[StateId - 8565];

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
                        true => 8565,
                        false => 8566,
                    },
                    Direction.South => Powered switch {
                        true => 8567,
                        false => 8568,
                    },
                    Direction.West => Powered switch {
                        true => 8569,
                        false => 8570,
                    },
                    Direction.East => Powered switch {
                        true => 8571,
                        false => 8572,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => Powered switch {
                        true => 8573,
                        false => 8574,
                    },
                    Direction.South => Powered switch {
                        true => 8575,
                        false => 8576,
                    },
                    Direction.West => Powered switch {
                        true => 8577,
                        false => 8578,
                    },
                    Direction.East => Powered switch {
                        true => 8579,
                        false => 8580,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => Powered switch {
                        true => 8581,
                        false => 8582,
                    },
                    Direction.South => Powered switch {
                        true => 8583,
                        false => 8584,
                    },
                    Direction.West => Powered switch {
                        true => 8585,
                        false => 8586,
                    },
                    Direction.East => Powered switch {
                        true => 8587,
                        false => 8588,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8565 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, true),
            8566 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.North, false),
            8567 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, true),
            8568 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.South, false),
            8569 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, true),
            8570 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.West, false),
            8571 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, true),
            8572 => new StoneButtonBlock(Identifier, AttachDirection.Floor, Direction.East, false),
            8573 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, true),
            8574 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.North, false),
            8575 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, true),
            8576 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.South, false),
            8577 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, true),
            8578 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.West, false),
            8579 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, true),
            8580 => new StoneButtonBlock(Identifier, AttachDirection.Wall, Direction.East, false),
            8581 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, true),
            8582 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.North, false),
            8583 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, true),
            8584 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.South, false),
            8585 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, true),
            8586 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.West, false),
            8587 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, true),
            8588 => new StoneButtonBlock(Identifier, AttachDirection.Ceiling, Direction.East, false),
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
