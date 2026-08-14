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
    private static readonly BlockInfo Data = new("minecraft:lightning_rod", "block.minecraft.waxed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_lightning_rod", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_lightning_rod");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S527, BlockShapes.S527, BlockShapes.S1, BlockShapes.S1, BlockShapes.S527, BlockShapes.S527);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S528, CollisionShape = BlockShapes.S528, VisualShape = BlockShapes.S528, SupportShape = BlockShapes.S528 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S528, CollisionShape = BlockShapes.S528, VisualShape = BlockShapes.S528, SupportShape = BlockShapes.S528 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30112];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                        true => 30112,
                        false => 30113,
                    },
                    false => Waterlogged switch {
                        true => 30114,
                        false => 30115,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30116,
                        false => 30117,
                    },
                    false => Waterlogged switch {
                        true => 30118,
                        false => 30119,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30120,
                        false => 30121,
                    },
                    false => Waterlogged switch {
                        true => 30122,
                        false => 30123,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30124,
                        false => 30125,
                    },
                    false => Waterlogged switch {
                        true => 30126,
                        false => 30127,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30128,
                        false => 30129,
                    },
                    false => Waterlogged switch {
                        true => 30130,
                        false => 30131,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30132,
                        false => 30133,
                    },
                    false => Waterlogged switch {
                        true => 30134,
                        false => 30135,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30112 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30113 => new WaxedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30114 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30115 => new WaxedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30116 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30117 => new WaxedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30118 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30119 => new WaxedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30120 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30121 => new WaxedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30122 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30123 => new WaxedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30124 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30125 => new WaxedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30126 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30127 => new WaxedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30128 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30129 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30130 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30131 => new WaxedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30132 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30133 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30134 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30135 => new WaxedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
