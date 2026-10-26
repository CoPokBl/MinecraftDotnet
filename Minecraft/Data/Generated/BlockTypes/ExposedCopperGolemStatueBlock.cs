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
public record ExposedCopperGolemStatueBlock(Identifier Identifier, ExposedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.exposed_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:exposed_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/exposed_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Popped, 44, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, true, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33149];

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
                        true => 33149,
                        false => 33150,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33151,
                        false => 33152,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33153,
                        false => 33154,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33155,
                        false => 33156,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33157,
                        false => 33158,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33159,
                        false => 33160,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33161,
                        false => 33162,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33163,
                        false => 33164,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33165,
                        false => 33166,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33167,
                        false => 33168,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33169,
                        false => 33170,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33171,
                        false => 33172,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33173,
                        false => 33174,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33175,
                        false => 33176,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33177,
                        false => 33178,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33179,
                        false => 33180,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33149 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            33150 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            33151 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            33152 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            33153 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            33154 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            33155 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            33156 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            33157 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            33158 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            33159 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            33160 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            33161 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            33162 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            33163 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            33164 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            33165 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            33166 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            33167 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            33168 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            33169 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            33170 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            33171 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            33172 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            33173 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            33174 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            33175 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            33176 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            33177 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            33178 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            33179 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            33180 => new ExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
