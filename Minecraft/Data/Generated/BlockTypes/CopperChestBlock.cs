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
public record CopperChestBlock(Identifier Identifier, ChestType Type, Direction Facing, bool Waterlogged) : IBlock, IChestTyped, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.copper_chest", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chest", "minecraft:copper_chest", BlockInfo.VanillaOnly, "minecraft:blocks/copper_chest");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Harp, false, true, true, false, false, false, false, true, false, false, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S416, BlockShapes.S416, BlockShapes.S1, BlockShapes.S416, BlockShapes.S416, BlockShapes.S416);
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

    public BlockStateInfo StateInfo => States[StateId - 32925];

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
                        true => 32925,
                        false => 32926,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32931,
                        false => 32932,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32937,
                        false => 32938,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32943,
                        false => 32944,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32927,
                        false => 32928,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32933,
                        false => 32934,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32939,
                        false => 32940,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32945,
                        false => 32946,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32929,
                        false => 32930,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32935,
                        false => 32936,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32941,
                        false => 32942,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32947,
                        false => 32948,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32925 => new CopperChestBlock(Identifier, ChestType.Single, Direction.North, true),
            32926 => new CopperChestBlock(Identifier, ChestType.Single, Direction.North, false),
            32927 => new CopperChestBlock(Identifier, ChestType.Left, Direction.North, true),
            32928 => new CopperChestBlock(Identifier, ChestType.Left, Direction.North, false),
            32929 => new CopperChestBlock(Identifier, ChestType.Right, Direction.North, true),
            32930 => new CopperChestBlock(Identifier, ChestType.Right, Direction.North, false),
            32931 => new CopperChestBlock(Identifier, ChestType.Single, Direction.South, true),
            32932 => new CopperChestBlock(Identifier, ChestType.Single, Direction.South, false),
            32933 => new CopperChestBlock(Identifier, ChestType.Left, Direction.South, true),
            32934 => new CopperChestBlock(Identifier, ChestType.Left, Direction.South, false),
            32935 => new CopperChestBlock(Identifier, ChestType.Right, Direction.South, true),
            32936 => new CopperChestBlock(Identifier, ChestType.Right, Direction.South, false),
            32937 => new CopperChestBlock(Identifier, ChestType.Single, Direction.West, true),
            32938 => new CopperChestBlock(Identifier, ChestType.Single, Direction.West, false),
            32939 => new CopperChestBlock(Identifier, ChestType.Left, Direction.West, true),
            32940 => new CopperChestBlock(Identifier, ChestType.Left, Direction.West, false),
            32941 => new CopperChestBlock(Identifier, ChestType.Right, Direction.West, true),
            32942 => new CopperChestBlock(Identifier, ChestType.Right, Direction.West, false),
            32943 => new CopperChestBlock(Identifier, ChestType.Single, Direction.East, true),
            32944 => new CopperChestBlock(Identifier, ChestType.Single, Direction.East, false),
            32945 => new CopperChestBlock(Identifier, ChestType.Left, Direction.East, true),
            32946 => new CopperChestBlock(Identifier, ChestType.Left, Direction.East, false),
            32947 => new CopperChestBlock(Identifier, ChestType.Right, Direction.East, true),
            32948 => new CopperChestBlock(Identifier, ChestType.Right, Direction.East, false),
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
