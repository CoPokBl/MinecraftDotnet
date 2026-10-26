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
public record ActivatorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock, IPowered, IRailDirected, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.activator_rail", 0.7f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:activator_rail", BlockInfo.VanillaOnly, "minecraft:blocks/activator_rail");
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.PushPull, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 13175];

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithShape(RailDirection shape) => this with { Shape = shape };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 13175,
                        false => 13176,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 13177,
                        false => 13178,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 13179,
                        false => 13180,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 13181,
                        false => 13182,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 13183,
                        false => 13184,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 13185,
                        false => 13186,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 13187,
                        false => 13188,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 13189,
                        false => 13190,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 13191,
                        false => 13192,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 13193,
                        false => 13194,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 13195,
                        false => 13196,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 13197,
                        false => 13198,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13175 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            13176 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            13177 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            13178 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            13179 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            13180 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            13181 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            13182 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            13183 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            13184 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            13185 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            13186 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            13187 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            13188 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            13189 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            13190 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            13191 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            13192 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            13193 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            13194 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            13195 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            13196 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            13197 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            13198 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Shape = properties.Contains("shape") ? RailDirectionExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
