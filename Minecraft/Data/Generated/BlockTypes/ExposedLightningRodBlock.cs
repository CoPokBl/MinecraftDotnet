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
    private static readonly BlockInfo Data = new("minecraft:weathering_lightning_rod", "block.minecraft.exposed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 44, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, true, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S527, BlockShapes.S527, BlockShapes.S1, BlockShapes.S1, BlockShapes.S527, BlockShapes.S527);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S528, CollisionShape = BlockShapes.S528, VisualShape = BlockShapes.S528, SupportShape = BlockShapes.S528 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S528, CollisionShape = BlockShapes.S528, VisualShape = BlockShapes.S528, SupportShape = BlockShapes.S528 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30040];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
                        true => 30040,
                        false => 30041,
                    },
                    false => Waterlogged switch {
                        true => 30042,
                        false => 30043,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30044,
                        false => 30045,
                    },
                    false => Waterlogged switch {
                        true => 30046,
                        false => 30047,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30048,
                        false => 30049,
                    },
                    false => Waterlogged switch {
                        true => 30050,
                        false => 30051,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30052,
                        false => 30053,
                    },
                    false => Waterlogged switch {
                        true => 30054,
                        false => 30055,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30056,
                        false => 30057,
                    },
                    false => Waterlogged switch {
                        true => 30058,
                        false => 30059,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30060,
                        false => 30061,
                    },
                    false => Waterlogged switch {
                        true => 30062,
                        false => 30063,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30040 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30041 => new ExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30042 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30043 => new ExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30044 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30045 => new ExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30046 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30047 => new ExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30048 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30049 => new ExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30050 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30051 => new ExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30052 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30053 => new ExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30054 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30055 => new ExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30056 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30057 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30058 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30059 => new ExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30060 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30061 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30062 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30063 => new ExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
