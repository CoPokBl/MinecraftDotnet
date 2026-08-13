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
public record ActivatorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:powered_rail", "block.minecraft.activator_rail", 0.7f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:activator_rail", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.Normal, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 11408];

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
                        true => 11408,
                        false => 11409,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11410,
                        false => 11411,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11412,
                        false => 11413,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11414,
                        false => 11415,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11416,
                        false => 11417,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11418,
                        false => 11419,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 11420,
                        false => 11421,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11422,
                        false => 11423,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11424,
                        false => 11425,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11426,
                        false => 11427,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11428,
                        false => 11429,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11430,
                        false => 11431,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11408 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            11409 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            11410 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            11411 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            11412 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            11413 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            11414 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            11415 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            11416 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            11417 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            11418 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            11419 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            11420 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            11421 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            11422 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            11423 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            11424 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            11425 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            11426 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            11427 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            11428 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            11429 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            11430 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            11431 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
