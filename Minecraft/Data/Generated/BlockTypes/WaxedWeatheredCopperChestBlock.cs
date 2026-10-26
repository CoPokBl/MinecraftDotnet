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
public record WaxedWeatheredCopperChestBlock(Identifier Identifier, ChestType Type, Direction Facing, bool Waterlogged) : IBlock, IChestTyped, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_weathered_copper_chest", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:chest", "minecraft:waxed_weathered_copper_chest", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_weathered_copper_chest");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 56, "copper", NoteBlockInstrument.Harp, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S416, BlockShapes.S416, BlockShapes.S1, BlockShapes.S416, BlockShapes.S416, BlockShapes.S416);
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

    public BlockStateInfo StateInfo => States[StateId - 33069];

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
                        true => 33069,
                        false => 33070,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33075,
                        false => 33076,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33081,
                        false => 33082,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33087,
                        false => 33088,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33071,
                        false => 33072,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33077,
                        false => 33078,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33083,
                        false => 33084,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33089,
                        false => 33090,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                ChestType.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33073,
                        false => 33074,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33079,
                        false => 33080,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33085,
                        false => 33086,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33091,
                        false => 33092,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Type), Type, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33069 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.North, true),
            33070 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.North, false),
            33071 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.North, true),
            33072 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.North, false),
            33073 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.North, true),
            33074 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.North, false),
            33075 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.South, true),
            33076 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.South, false),
            33077 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.South, true),
            33078 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.South, false),
            33079 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.South, true),
            33080 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.South, false),
            33081 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.West, true),
            33082 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.West, false),
            33083 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.West, true),
            33084 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.West, false),
            33085 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.West, true),
            33086 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.West, false),
            33087 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.East, true),
            33088 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Single, Direction.East, false),
            33089 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.East, true),
            33090 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Left, Direction.East, false),
            33091 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.East, true),
            33092 => new WaxedWeatheredCopperChestBlock(Identifier, ChestType.Right, Direction.East, false),
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
