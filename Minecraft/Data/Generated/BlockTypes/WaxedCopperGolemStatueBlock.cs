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
public record WaxedCopperGolemStatueBlock(Identifier Identifier, WaxedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Popped, 15, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33245];

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
                        true => 33245,
                        false => 33246,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33247,
                        false => 33248,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33249,
                        false => 33250,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33251,
                        false => 33252,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33253,
                        false => 33254,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33255,
                        false => 33256,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33257,
                        false => 33258,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33259,
                        false => 33260,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33261,
                        false => 33262,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33263,
                        false => 33264,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33265,
                        false => 33266,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33267,
                        false => 33268,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33269,
                        false => 33270,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33271,
                        false => 33272,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33273,
                        false => 33274,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33275,
                        false => 33276,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33245 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            33246 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            33247 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            33248 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            33249 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            33250 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            33251 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            33252 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            33253 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            33254 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            33255 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            33256 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            33257 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            33258 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            33259 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            33260 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            33261 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            33262 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            33263 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            33264 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            33265 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            33266 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            33267 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            33268 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            33269 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            33270 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            33271 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            33272 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            33273 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            33274 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            33275 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            33276 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
