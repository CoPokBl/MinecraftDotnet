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
public record ChestBlock(Identifier Identifier, ChestType Type, Direction Facing, bool Waterlogged) : IBlock, IChestTyped, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.chest", 2.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chest", "minecraft:chest", BlockInfo.VanillaOnly, "minecraft:blocks/chest");
    private static readonly BlockStateInfo I0 = new(2.5f, 0, 1, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S416, BlockShapes.S416, BlockShapes.S1, BlockShapes.S416, BlockShapes.S416, BlockShapes.S416);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S417, CollisionShape = BlockShapes.S417, OcclusionShape = BlockShapes.S417, VisualShape = BlockShapes.S417, SupportShape = BlockShapes.S417 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S417, CollisionShape = BlockShapes.S417, OcclusionShape = BlockShapes.S417, VisualShape = BlockShapes.S417, SupportShape = BlockShapes.S417 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S418, CollisionShape = BlockShapes.S418, OcclusionShape = BlockShapes.S418, VisualShape = BlockShapes.S418, SupportShape = BlockShapes.S418 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S418, CollisionShape = BlockShapes.S418, OcclusionShape = BlockShapes.S418, VisualShape = BlockShapes.S418, SupportShape = BlockShapes.S418 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S419, CollisionShape = BlockShapes.S419, OcclusionShape = BlockShapes.S419, VisualShape = BlockShapes.S419, SupportShape = BlockShapes.S419 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S419, CollisionShape = BlockShapes.S419, OcclusionShape = BlockShapes.S419, VisualShape = BlockShapes.S419, SupportShape = BlockShapes.S419 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S420, CollisionShape = BlockShapes.S420, OcclusionShape = BlockShapes.S420, VisualShape = BlockShapes.S420, SupportShape = BlockShapes.S420 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S420, CollisionShape = BlockShapes.S420, OcclusionShape = BlockShapes.S420, VisualShape = BlockShapes.S420, SupportShape = BlockShapes.S420 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I0, I1, I4, I5, I2, I3, I0, I1, I6, I7, I8, I9, I0, I1, I8, I9, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 5543];

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

    public IBlock WithType(ChestType type) => this with { Type = type };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Type switch {
                ChestType.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 5543,
                        false => 5544,
                    },
                    Direction.South => Waterlogged switch {
                        true => 5549,
                        false => 5550,
                    },
                    Direction.West => Waterlogged switch {
                        true => 5555,
                        false => 5556,
                    },
                    Direction.East => Waterlogged switch {
                        true => 5561,
                        false => 5562,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 5545,
                        false => 5546,
                    },
                    Direction.South => Waterlogged switch {
                        true => 5551,
                        false => 5552,
                    },
                    Direction.West => Waterlogged switch {
                        true => 5557,
                        false => 5558,
                    },
                    Direction.East => Waterlogged switch {
                        true => 5563,
                        false => 5564,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 5547,
                        false => 5548,
                    },
                    Direction.South => Waterlogged switch {
                        true => 5553,
                        false => 5554,
                    },
                    Direction.West => Waterlogged switch {
                        true => 5559,
                        false => 5560,
                    },
                    Direction.East => Waterlogged switch {
                        true => 5565,
                        false => 5566,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5543 => new ChestBlock(Identifier, ChestType.Single, Direction.North, true),
            5544 => new ChestBlock(Identifier, ChestType.Single, Direction.North, false),
            5545 => new ChestBlock(Identifier, ChestType.Left, Direction.North, true),
            5546 => new ChestBlock(Identifier, ChestType.Left, Direction.North, false),
            5547 => new ChestBlock(Identifier, ChestType.Right, Direction.North, true),
            5548 => new ChestBlock(Identifier, ChestType.Right, Direction.North, false),
            5549 => new ChestBlock(Identifier, ChestType.Single, Direction.South, true),
            5550 => new ChestBlock(Identifier, ChestType.Single, Direction.South, false),
            5551 => new ChestBlock(Identifier, ChestType.Left, Direction.South, true),
            5552 => new ChestBlock(Identifier, ChestType.Left, Direction.South, false),
            5553 => new ChestBlock(Identifier, ChestType.Right, Direction.South, true),
            5554 => new ChestBlock(Identifier, ChestType.Right, Direction.South, false),
            5555 => new ChestBlock(Identifier, ChestType.Single, Direction.West, true),
            5556 => new ChestBlock(Identifier, ChestType.Single, Direction.West, false),
            5557 => new ChestBlock(Identifier, ChestType.Left, Direction.West, true),
            5558 => new ChestBlock(Identifier, ChestType.Left, Direction.West, false),
            5559 => new ChestBlock(Identifier, ChestType.Right, Direction.West, true),
            5560 => new ChestBlock(Identifier, ChestType.Right, Direction.West, false),
            5561 => new ChestBlock(Identifier, ChestType.Single, Direction.East, true),
            5562 => new ChestBlock(Identifier, ChestType.Single, Direction.East, false),
            5563 => new ChestBlock(Identifier, ChestType.Left, Direction.East, true),
            5564 => new ChestBlock(Identifier, ChestType.Left, Direction.East, false),
            5565 => new ChestBlock(Identifier, ChestType.Right, Direction.East, true),
            5566 => new ChestBlock(Identifier, ChestType.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Type = properties.Contains("type") ? ChestTypeExtensions.FromString(properties["type"].GetString()) : Type,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(Type.ToName())),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
