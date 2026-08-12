using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DetectorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:detector_rail", "block.minecraft.detector_rail", 0.7f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:detector_rail", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.Normal, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S122, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S87 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 2211];

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
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2211,
                        false => 2212,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2213,
                        false => 2214,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2215,
                        false => 2216,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2217,
                        false => 2218,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2219,
                        false => 2220,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2221,
                        false => 2222,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2223,
                        false => 2224,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2225,
                        false => 2226,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2227,
                        false => 2228,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2229,
                        false => 2230,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2231,
                        false => 2232,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2233,
                        false => 2234,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2211 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2212 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2213 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, true),
            2214 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, false),
            2215 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2216 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2217 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2218 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2219 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2220 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2221 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2222 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2223 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2224 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2225 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, true),
            2226 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, false),
            2227 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2228 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2229 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2230 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2231 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2232 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2233 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2234 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
