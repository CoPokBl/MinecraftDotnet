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
public record ScaffoldingBlock(Identifier Identifier, bool Bottom, int Distance, bool Waterlogged) : IBlock, IBottomed, IDistanced, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.scaffolding", 0f, 0.6f, 1f, 1f, 0f, 0f, false, true, BlockOffsetType.None, 0f, 0f, null, "minecraft:scaffolding", BlockInfo.VanillaOnly, "minecraft:blocks/scaffolding");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 2, "scaffolding", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S910, BlockShapes.S911, BlockShapes.S79, BlockShapes.S1, BlockShapes.S911, BlockShapes.S911);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S911 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S911 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 24063];

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

    public IBlock WithBottom(bool bottom) => this with { Bottom = bottom };

    public IBlock WithDistance(int distance) => this with { Distance = distance };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Bottom switch {
                true => Distance switch {
                    0 => Waterlogged switch {
                        true => 24063,
                        false => 24064,
                    },
                    1 => Waterlogged switch {
                        true => 24065,
                        false => 24066,
                    },
                    2 => Waterlogged switch {
                        true => 24067,
                        false => 24068,
                    },
                    3 => Waterlogged switch {
                        true => 24069,
                        false => 24070,
                    },
                    4 => Waterlogged switch {
                        true => 24071,
                        false => 24072,
                    },
                    5 => Waterlogged switch {
                        true => 24073,
                        false => 24074,
                    },
                    6 => Waterlogged switch {
                        true => 24075,
                        false => 24076,
                    },
                    7 => Waterlogged switch {
                        true => 24077,
                        false => 24078,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 24079,
                        false => 24080,
                    },
                    1 => Waterlogged switch {
                        true => 24081,
                        false => 24082,
                    },
                    2 => Waterlogged switch {
                        true => 24083,
                        false => 24084,
                    },
                    3 => Waterlogged switch {
                        true => 24085,
                        false => 24086,
                    },
                    4 => Waterlogged switch {
                        true => 24087,
                        false => 24088,
                    },
                    5 => Waterlogged switch {
                        true => 24089,
                        false => 24090,
                    },
                    6 => Waterlogged switch {
                        true => 24091,
                        false => 24092,
                    },
                    7 => Waterlogged switch {
                        true => 24093,
                        false => 24094,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24063 => new ScaffoldingBlock(Identifier, true, 0, true),
            24064 => new ScaffoldingBlock(Identifier, true, 0, false),
            24065 => new ScaffoldingBlock(Identifier, true, 1, true),
            24066 => new ScaffoldingBlock(Identifier, true, 1, false),
            24067 => new ScaffoldingBlock(Identifier, true, 2, true),
            24068 => new ScaffoldingBlock(Identifier, true, 2, false),
            24069 => new ScaffoldingBlock(Identifier, true, 3, true),
            24070 => new ScaffoldingBlock(Identifier, true, 3, false),
            24071 => new ScaffoldingBlock(Identifier, true, 4, true),
            24072 => new ScaffoldingBlock(Identifier, true, 4, false),
            24073 => new ScaffoldingBlock(Identifier, true, 5, true),
            24074 => new ScaffoldingBlock(Identifier, true, 5, false),
            24075 => new ScaffoldingBlock(Identifier, true, 6, true),
            24076 => new ScaffoldingBlock(Identifier, true, 6, false),
            24077 => new ScaffoldingBlock(Identifier, true, 7, true),
            24078 => new ScaffoldingBlock(Identifier, true, 7, false),
            24079 => new ScaffoldingBlock(Identifier, false, 0, true),
            24080 => new ScaffoldingBlock(Identifier, false, 0, false),
            24081 => new ScaffoldingBlock(Identifier, false, 1, true),
            24082 => new ScaffoldingBlock(Identifier, false, 1, false),
            24083 => new ScaffoldingBlock(Identifier, false, 2, true),
            24084 => new ScaffoldingBlock(Identifier, false, 2, false),
            24085 => new ScaffoldingBlock(Identifier, false, 3, true),
            24086 => new ScaffoldingBlock(Identifier, false, 3, false),
            24087 => new ScaffoldingBlock(Identifier, false, 4, true),
            24088 => new ScaffoldingBlock(Identifier, false, 4, false),
            24089 => new ScaffoldingBlock(Identifier, false, 5, true),
            24090 => new ScaffoldingBlock(Identifier, false, 5, false),
            24091 => new ScaffoldingBlock(Identifier, false, 6, true),
            24092 => new ScaffoldingBlock(Identifier, false, 6, false),
            24093 => new ScaffoldingBlock(Identifier, false, 7, true),
            24094 => new ScaffoldingBlock(Identifier, false, 7, false),
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
