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
public record PoweredRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:powered_rail", "block.minecraft.powered_rail", 0.7f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:powered_rail", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.Normal, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 2187];

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2187,
                        false => 2188,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2189,
                        false => 2190,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2191,
                        false => 2192,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2193,
                        false => 2194,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2195,
                        false => 2196,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2197,
                        false => 2198,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2199,
                        false => 2200,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2201,
                        false => 2202,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2203,
                        false => 2204,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2205,
                        false => 2206,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2207,
                        false => 2208,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2209,
                        false => 2210,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2187 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2188 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2189 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, true),
            2190 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, false),
            2191 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2192 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2193 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2194 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2195 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2196 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2197 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2198 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2199 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2200 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2201 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, true),
            2202 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, false),
            2203 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2204 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2205 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2206 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2207 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2208 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2209 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2210 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
