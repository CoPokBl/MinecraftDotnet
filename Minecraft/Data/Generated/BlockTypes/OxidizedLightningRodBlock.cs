using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_lightning_rod", "block.minecraft.oxidized_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:oxidized_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 55, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30088];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30088,
                        false => 30089,
                    },
                    false => Waterlogged switch {
                        true => 30090,
                        false => 30091,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30092,
                        false => 30093,
                    },
                    false => Waterlogged switch {
                        true => 30094,
                        false => 30095,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30096,
                        false => 30097,
                    },
                    false => Waterlogged switch {
                        true => 30098,
                        false => 30099,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30100,
                        false => 30101,
                    },
                    false => Waterlogged switch {
                        true => 30102,
                        false => 30103,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30104,
                        false => 30105,
                    },
                    false => Waterlogged switch {
                        true => 30106,
                        false => 30107,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30108,
                        false => 30109,
                    },
                    false => Waterlogged switch {
                        true => 30110,
                        false => 30111,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30088 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30089 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30090 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30091 => new OxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30092 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30093 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30094 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30095 => new OxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30096 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30097 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30098 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30099 => new OxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30100 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30101 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30102 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30103 => new OxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30104 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30105 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30106 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30107 => new OxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30108 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30109 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30110 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30111 => new OxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
