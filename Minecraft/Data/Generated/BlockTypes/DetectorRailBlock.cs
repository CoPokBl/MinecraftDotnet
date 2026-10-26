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
public record DetectorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock, IPowered, IRailDirected, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.detector_rail", 0.7f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:detector_rail", BlockInfo.VanillaOnly, "minecraft:blocks/detector_rail");
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.PushPull, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 2326];

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
                        true => 2326,
                        false => 2327,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2328,
                        false => 2329,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2330,
                        false => 2331,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2332,
                        false => 2333,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2334,
                        false => 2335,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2336,
                        false => 2337,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2338,
                        false => 2339,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2340,
                        false => 2341,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2342,
                        false => 2343,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2344,
                        false => 2345,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2346,
                        false => 2347,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2348,
                        false => 2349,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2326 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2327 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2328 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, true),
            2329 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, false),
            2330 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2331 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2332 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2333 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2334 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2335 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2336 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2337 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2338 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2339 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2340 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, true),
            2341 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, false),
            2342 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2343 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2344 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2345 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2346 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2347 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2348 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2349 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
