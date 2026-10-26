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
    private static readonly BlockInfo Data = new("block.minecraft.big_dripleaf", 0.1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:big_dripleaf", BlockInfo.VanillaOnly, "minecraft:blocks/big_dripleaf");
    private static readonly BlockStateInfo I0 = new(0.1f, 0, 1, PushReaction.Popped, 7, "big_dripleaf", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S344, BlockShapes.S345, BlockShapes.S1, BlockShapes.S344, BlockShapes.S345, BlockShapes.S345);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S346, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S346, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S346, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S346, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S348, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S348, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S348, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S348, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S349, OcclusionShape = BlockShapes.S349 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S349, OcclusionShape = BlockShapes.S349 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S350, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S350, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I9 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S350, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S350, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S351, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S351, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I11 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S351, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S351, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S352, OcclusionShape = BlockShapes.S352 };
    private static readonly BlockStateInfo I13 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S352, OcclusionShape = BlockShapes.S352 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S353, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S353, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I15 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S353, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S353, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S354, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S354, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I17 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S354, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S354, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S355, OcclusionShape = BlockShapes.S355 };
    private static readonly BlockStateInfo I19 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S355, OcclusionShape = BlockShapes.S355 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S356, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S356, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I21 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S356, CollisionShape = BlockShapes.S347, OcclusionShape = BlockShapes.S356, VisualShape = BlockShapes.S347, SupportShape = BlockShapes.S347 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S357, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S357, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo I23 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S357, CollisionShape = BlockShapes.S1, OcclusionShape = BlockShapes.S357, VisualShape = BlockShapes.S1, SupportShape = BlockShapes.S1 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I4, I5, I6, I7, I6, I7, I8, I9, I10, I11, I12, I13, I12, I13, I14, I15, I16, I17, I18, I19, I18, I19, I20, I21, I22, I23
    ];

    public BlockStateInfo StateInfo => States[StateId - 33713];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 33713,
                        false => 33714,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 33715,
                        false => 33716,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 33717,
                        false => 33718,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 33719,
                        false => 33720,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.South => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 33721,
                        false => 33722,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 33723,
                        false => 33724,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 33725,
                        false => 33726,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 33727,
                        false => 33728,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.West => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 33729,
                        false => 33730,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 33731,
                        false => 33732,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 33733,
                        false => 33734,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 33735,
                        false => 33736,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                Direction.East => TiltValue switch {
                    Tilt.None => Waterlogged switch {
                        true => 33737,
                        false => 33738,
                    },
                    Tilt.Unstable => Waterlogged switch {
                        true => 33739,
                        false => 33740,
                    },
                    Tilt.Partial => Waterlogged switch {
                        true => 33741,
                        false => 33742,
                    },
                    Tilt.Full => Waterlogged switch {
                        true => 33743,
                        false => 33744,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(TiltValue), TiltValue, "Unknown value for property tilt.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33713 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, true),
            33714 => new BigDripleafBlock(Identifier, Direction.North, Tilt.None, false),
            33715 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, true),
            33716 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Unstable, false),
            33717 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, true),
            33718 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Partial, false),
            33719 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, true),
            33720 => new BigDripleafBlock(Identifier, Direction.North, Tilt.Full, false),
            33721 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, true),
            33722 => new BigDripleafBlock(Identifier, Direction.South, Tilt.None, false),
            33723 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, true),
            33724 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Unstable, false),
            33725 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, true),
            33726 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Partial, false),
            33727 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, true),
            33728 => new BigDripleafBlock(Identifier, Direction.South, Tilt.Full, false),
            33729 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, true),
            33730 => new BigDripleafBlock(Identifier, Direction.West, Tilt.None, false),
            33731 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, true),
            33732 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Unstable, false),
            33733 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, true),
            33734 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Partial, false),
            33735 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, true),
            33736 => new BigDripleafBlock(Identifier, Direction.West, Tilt.Full, false),
            33737 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, true),
            33738 => new BigDripleafBlock(Identifier, Direction.East, Tilt.None, false),
            33739 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, true),
            33740 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Unstable, false),
            33741 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, true),
            33742 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Partial, false),
            33743 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, true),
            33744 => new BigDripleafBlock(Identifier, Direction.East, Tilt.Full, false),
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
