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
public record ScaffoldingBlock(Identifier Identifier, bool Bottom, int Distance, bool Waterlogged) : IBlock, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:scaffolding", "block.minecraft.scaffolding", 0f, 0.6f, 1f, 1f, 0f, false, true, BlockOffsetType.None, 0f, 0f, null, "minecraft:scaffolding", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 2, "scaffolding", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S909, BlockShapes.S910, BlockShapes.S79, BlockShapes.S1, BlockShapes.S910, BlockShapes.S910);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S910 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S910 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 20706];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Bottom switch {
                true => Distance switch {
                    0 => Waterlogged switch {
                        true => 20706,
                        false => 20707,
                    },
                    1 => Waterlogged switch {
                        true => 20708,
                        false => 20709,
                    },
                    2 => Waterlogged switch {
                        true => 20710,
                        false => 20711,
                    },
                    3 => Waterlogged switch {
                        true => 20712,
                        false => 20713,
                    },
                    4 => Waterlogged switch {
                        true => 20714,
                        false => 20715,
                    },
                    5 => Waterlogged switch {
                        true => 20716,
                        false => 20717,
                    },
                    6 => Waterlogged switch {
                        true => 20718,
                        false => 20719,
                    },
                    7 => Waterlogged switch {
                        true => 20720,
                        false => 20721,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 20722,
                        false => 20723,
                    },
                    1 => Waterlogged switch {
                        true => 20724,
                        false => 20725,
                    },
                    2 => Waterlogged switch {
                        true => 20726,
                        false => 20727,
                    },
                    3 => Waterlogged switch {
                        true => 20728,
                        false => 20729,
                    },
                    4 => Waterlogged switch {
                        true => 20730,
                        false => 20731,
                    },
                    5 => Waterlogged switch {
                        true => 20732,
                        false => 20733,
                    },
                    6 => Waterlogged switch {
                        true => 20734,
                        false => 20735,
                    },
                    7 => Waterlogged switch {
                        true => 20736,
                        false => 20737,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20706 => new ScaffoldingBlock(Identifier, true, 0, true),
            20707 => new ScaffoldingBlock(Identifier, true, 0, false),
            20708 => new ScaffoldingBlock(Identifier, true, 1, true),
            20709 => new ScaffoldingBlock(Identifier, true, 1, false),
            20710 => new ScaffoldingBlock(Identifier, true, 2, true),
            20711 => new ScaffoldingBlock(Identifier, true, 2, false),
            20712 => new ScaffoldingBlock(Identifier, true, 3, true),
            20713 => new ScaffoldingBlock(Identifier, true, 3, false),
            20714 => new ScaffoldingBlock(Identifier, true, 4, true),
            20715 => new ScaffoldingBlock(Identifier, true, 4, false),
            20716 => new ScaffoldingBlock(Identifier, true, 5, true),
            20717 => new ScaffoldingBlock(Identifier, true, 5, false),
            20718 => new ScaffoldingBlock(Identifier, true, 6, true),
            20719 => new ScaffoldingBlock(Identifier, true, 6, false),
            20720 => new ScaffoldingBlock(Identifier, true, 7, true),
            20721 => new ScaffoldingBlock(Identifier, true, 7, false),
            20722 => new ScaffoldingBlock(Identifier, false, 0, true),
            20723 => new ScaffoldingBlock(Identifier, false, 0, false),
            20724 => new ScaffoldingBlock(Identifier, false, 1, true),
            20725 => new ScaffoldingBlock(Identifier, false, 1, false),
            20726 => new ScaffoldingBlock(Identifier, false, 2, true),
            20727 => new ScaffoldingBlock(Identifier, false, 2, false),
            20728 => new ScaffoldingBlock(Identifier, false, 3, true),
            20729 => new ScaffoldingBlock(Identifier, false, 3, false),
            20730 => new ScaffoldingBlock(Identifier, false, 4, true),
            20731 => new ScaffoldingBlock(Identifier, false, 4, false),
            20732 => new ScaffoldingBlock(Identifier, false, 5, true),
            20733 => new ScaffoldingBlock(Identifier, false, 5, false),
            20734 => new ScaffoldingBlock(Identifier, false, 6, true),
            20735 => new ScaffoldingBlock(Identifier, false, 6, false),
            20736 => new ScaffoldingBlock(Identifier, false, 7, true),
            20737 => new ScaffoldingBlock(Identifier, false, 7, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.Contains("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            Distance = properties.Contains("distance") ? int.Parse(properties["distance"].GetString()) : Distance,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bottom", new StringTag(Bottom.ToString().ToLower())),
            ("distance", new StringTag(Distance.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
