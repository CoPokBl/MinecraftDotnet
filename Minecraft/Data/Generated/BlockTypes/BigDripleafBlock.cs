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
public record BigDripleafBlock(Identifier Identifier, Direction Facing, BigDripleafBlock.Tilt TiltValue, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:big_dripleaf", "block.minecraft.big_dripleaf", 0.1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:big_dripleaf", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 1, PushReaction.Destroy, 7, "big_dripleaf", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S344, BlockShapes.S345, BlockShapes.S1, BlockShapes.S344, BlockShapes.S345, BlockShapes.S345);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S346, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S346, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S346, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S346, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S348, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S348, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S348, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S348, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S349, OcclusionShape = BlockShapes.S349 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S349, OcclusionShape = BlockShapes.S349 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S350, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S350, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S350, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S350, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S351, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S351, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S351, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S351, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S352, OcclusionShape = BlockShapes.S352 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S352, OcclusionShape = BlockShapes.S352 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S353, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S353, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S353, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S353, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S354, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S354, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S354, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S354, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S355, OcclusionShape = BlockShapes.S355 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S355, OcclusionShape = BlockShapes.S355 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S356, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S356, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S356, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S356, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S357, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S357, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, Fluid = null, BlockShape = BlockShapes.S357, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S357, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I4, I5, I6, I7, I6, I7, I8, I9, I10, I11, I12, I13, I12, I13, I14, I15, I16, I17, I18, I19, I18, I19, I20, I21, I22, I23
    ];

    public BlockStateInfo StateInfo => States[StateId - 30356];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30356,
                        false => 30357,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30358,
                        false => 30359,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30360,
                        false => 30361,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30362,
                        false => 30363,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30364,
                        false => 30365,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30366,
                        false => 30367,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30368,
                        false => 30369,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30370,
                        false => 30371,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30372,
                        false => 30373,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30374,
                        false => 30375,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30376,
                        false => 30377,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30378,
                        false => 30379,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 30380,
                        false => 30381,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 30382,
                        false => 30383,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 30384,
                        false => 30385,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 30386,
                        false => 30387,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30356 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            30357 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            30358 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            30359 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            30360 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            30361 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            30362 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            30363 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            30364 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            30365 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            30366 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            30367 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            30368 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            30369 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            30370 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            30371 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            30372 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            30373 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            30374 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            30375 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            30376 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            30377 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            30378 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            30379 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            30380 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            30381 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            30382 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            30383 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            30384 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            30385 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            30386 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            30387 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            TiltValue = properties.Contains("tilt") ? TiltFromString(properties["tilt"].GetString()) : TiltValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("tilt", new StringTag(TiltToName(TiltValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Tilt {
        None,
        Unstable,
        Partial,
        Full,
    }

    public static Tilt TiltFromString(string value) {
        return value switch {
            "none" => Tilt.None,
            "unstable" => Tilt.Unstable,
            "partial" => Tilt.Partial,
            "full" => Tilt.Full,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Tilt.")
        };
    }

    public static string TiltToName(Tilt value) {
        return value switch {
            Tilt.None => "none",
            Tilt.Unstable => "unstable",
            Tilt.Partial => "partial",
            Tilt.Full => "full",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Tilt value.")
        };
    }
}
