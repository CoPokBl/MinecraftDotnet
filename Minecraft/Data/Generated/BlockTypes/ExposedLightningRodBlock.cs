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
public record ExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock, IDirectional, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.exposed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_lightning_rod", BlockInfo.VanillaOnly, "minecraft:blocks/exposed_lightning_rod");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 44, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, true, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S528, BlockShapes.S528, BlockShapes.S1, BlockShapes.S1, BlockShapes.S528, BlockShapes.S528);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 33397];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 33397,
                        false => 33398,
                    },
                    false => Waterlogged switch {
                        true => 33399,
                        false => 33400,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 33401,
                        false => 33402,
                    },
                    false => Waterlogged switch {
                        true => 33403,
                        false => 33404,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 33405,
                        false => 33406,
                    },
                    false => Waterlogged switch {
                        true => 33407,
                        false => 33408,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 33409,
                        false => 33410,
                    },
                    false => Waterlogged switch {
                        true => 33411,
                        false => 33412,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 33413,
                        false => 33414,
                    },
                    false => Waterlogged switch {
                        true => 33415,
                        false => 33416,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 33417,
                        false => 33418,
                    },
                    false => Waterlogged switch {
                        true => 33419,
                        false => 33420,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33397 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            33398 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            33399 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            33400 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            33401 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            33402 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            33403 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            33404 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            33405 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            33406 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            33407 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            33408 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            33409 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            33410 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            33411 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            33412 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            33413 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            33414 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            33415 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            33416 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            33417 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            33418 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            33419 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            33420 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
