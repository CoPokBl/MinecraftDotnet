using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:lightning_rod", "block.minecraft.waxed_weathered_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_weathered_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 56, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30160];

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
                        true => 30160,
                        false => 30161,
                    },
                    false => Waterlogged switch {
                        true => 30162,
                        false => 30163,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30164,
                        false => 30165,
                    },
                    false => Waterlogged switch {
                        true => 30166,
                        false => 30167,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30168,
                        false => 30169,
                    },
                    false => Waterlogged switch {
                        true => 30170,
                        false => 30171,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30172,
                        false => 30173,
                    },
                    false => Waterlogged switch {
                        true => 30174,
                        false => 30175,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30176,
                        false => 30177,
                    },
                    false => Waterlogged switch {
                        true => 30178,
                        false => 30179,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30180,
                        false => 30181,
                    },
                    false => Waterlogged switch {
                        true => 30182,
                        false => 30183,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30160 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, true),
            30161 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, true, false),
            30162 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, true),
            30163 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.North, false, false),
            30164 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, true),
            30165 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, true, false),
            30166 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, true),
            30167 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.East, false, false),
            30168 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, true),
            30169 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, true, false),
            30170 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, true),
            30171 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.South, false, false),
            30172 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, true),
            30173 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, true, false),
            30174 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, true),
            30175 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.West, false, false),
            30176 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30177 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30178 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30179 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30180 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30181 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30182 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30183 => new WaxedWeatheredLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
