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
public record WaxedWeatheredCopperGolemStatueBlock(Identifier Identifier, WaxedWeatheredCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_weathered_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_weathered_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_weathered_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Popped, 56, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33309];

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
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33309,
                        false => 33310,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33311,
                        false => 33312,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33313,
                        false => 33314,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33315,
                        false => 33316,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33317,
                        false => 33318,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33319,
                        false => 33320,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33321,
                        false => 33322,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33323,
                        false => 33324,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33325,
                        false => 33326,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33327,
                        false => 33328,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33329,
                        false => 33330,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33331,
                        false => 33332,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33333,
                        false => 33334,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33335,
                        false => 33336,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33337,
                        false => 33338,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33339,
                        false => 33340,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33309 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            33310 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            33311 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            33312 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            33313 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            33314 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            33315 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            33316 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            33317 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            33318 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            33319 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            33320 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            33321 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            33322 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            33323 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            33324 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            33325 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            33326 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            33327 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            33328 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            33329 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            33330 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            33331 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            33332 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            33333 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            33334 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            33335 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            33336 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            33337 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            33338 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            33339 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            33340 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CopperGolemPoseValue = properties.Contains("copper_golem_pose") ? CopperGolemPoseFromString(properties["copper_golem_pose"].GetString()) : CopperGolemPoseValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("copper_golem_pose", new StringTag(CopperGolemPoseToName(CopperGolemPoseValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum CopperGolemPose {
        Standing,
        Sitting,
        Running,
        Star,
    }

    public static CopperGolemPose CopperGolemPoseFromString(string value) {
        return value switch {
            "standing" => CopperGolemPose.Standing,
            "sitting" => CopperGolemPose.Sitting,
            "running" => CopperGolemPose.Running,
            "star" => CopperGolemPose.Star,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for CopperGolemPose.")
        };
    }

    public static string CopperGolemPoseToName(CopperGolemPose value) {
        return value switch {
            CopperGolemPose.Standing => "standing",
            CopperGolemPose.Sitting => "sitting",
            CopperGolemPose.Running => "running",
            CopperGolemPose.Star => "star",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CopperGolemPose value.")
        };
    }
}
