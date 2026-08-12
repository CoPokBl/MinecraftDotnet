using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_lightning_rod", "block.minecraft.weathered_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:weathered_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, true, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30064];

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
                        true => 30064,
                        false => 30065,
                    },
                    false => Waterlogged switch {
                        true => 30066,
                        false => 30067,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30068,
                        false => 30069,
                    },
                    false => Waterlogged switch {
                        true => 30070,
                        false => 30071,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30072,
                        false => 30073,
                    },
                    false => Waterlogged switch {
                        true => 30074,
                        false => 30075,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30076,
                        false => 30077,
                    },
                    false => Waterlogged switch {
                        true => 30078,
                        false => 30079,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30080,
                        false => 30081,
                    },
                    false => Waterlogged switch {
                        true => 30082,
                        false => 30083,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30084,
                        false => 30085,
                    },
                    false => Waterlogged switch {
                        true => 30086,
                        false => 30087,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30064 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            30065 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            30066 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            30067 => new WeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            30068 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            30069 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            30070 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            30071 => new WeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            30072 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            30073 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            30074 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            30075 => new WeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            30076 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            30077 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            30078 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            30079 => new WeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            30080 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30081 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30082 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30083 => new WeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30084 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30085 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30086 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30087 => new WeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
