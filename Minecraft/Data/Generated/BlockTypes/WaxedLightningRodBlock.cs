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
public record WaxedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock, IDirectional, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_lightning_rod", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_lightning_rod");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, true, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S528, BlockShapes.S528, BlockShapes.S1, BlockShapes.S1, BlockShapes.S528, BlockShapes.S528);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 33469];

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
                        true => 33469,
                        false => 33470,
                    },
                    false => Waterlogged switch {
                        true => 33471,
                        false => 33472,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 33473,
                        false => 33474,
                    },
                    false => Waterlogged switch {
                        true => 33475,
                        false => 33476,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 33477,
                        false => 33478,
                    },
                    false => Waterlogged switch {
                        true => 33479,
                        false => 33480,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 33481,
                        false => 33482,
                    },
                    false => Waterlogged switch {
                        true => 33483,
                        false => 33484,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 33485,
                        false => 33486,
                    },
                    false => Waterlogged switch {
                        true => 33487,
                        false => 33488,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 33489,
                        false => 33490,
                    },
                    false => Waterlogged switch {
                        true => 33491,
                        false => 33492,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33469 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, true),
            33470 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, false),
            33471 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, true),
            33472 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, false),
            33473 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, true),
            33474 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, false),
            33475 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, true),
            33476 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, false),
            33477 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, true),
            33478 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, false),
            33479 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, true),
            33480 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, false),
            33481 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, true),
            33482 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, false),
            33483 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, true),
            33484 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, false),
            33485 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            33486 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            33487 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            33488 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            33489 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            33490 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            33491 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            33492 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
