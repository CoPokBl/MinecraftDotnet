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
public record WaxedExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock, IDirectional, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_exposed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_exposed_lightning_rod", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_exposed_lightning_rod");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 44, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, true, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S528, BlockShapes.S528, BlockShapes.S1, BlockShapes.S1, BlockShapes.S528, BlockShapes.S528);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 33493];

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
                        true => 33493,
                        false => 33494,
                    },
                    false => Waterlogged switch {
                        true => 33495,
                        false => 33496,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 33497,
                        false => 33498,
                    },
                    false => Waterlogged switch {
                        true => 33499,
                        false => 33500,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 33501,
                        false => 33502,
                    },
                    false => Waterlogged switch {
                        true => 33503,
                        false => 33504,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 33505,
                        false => 33506,
                    },
                    false => Waterlogged switch {
                        true => 33507,
                        false => 33508,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 33509,
                        false => 33510,
                    },
                    false => Waterlogged switch {
                        true => 33511,
                        false => 33512,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 33513,
                        false => 33514,
                    },
                    false => Waterlogged switch {
                        true => 33515,
                        false => 33516,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33493 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            33494 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            33495 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            33496 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            33497 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            33498 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            33499 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            33500 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            33501 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            33502 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            33503 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            33504 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            33505 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            33506 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            33507 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            33508 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            33509 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            33510 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            33511 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            33512 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            33513 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            33514 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            33515 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            33516 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
