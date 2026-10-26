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
public record OxidizedCopperGolemStatueBlock(Identifier Identifier, OxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oxidized_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:oxidized_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/oxidized_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Popped, 55, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33213];

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
                        true => 33213,
                        false => 33214,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33215,
                        false => 33216,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33217,
                        false => 33218,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33219,
                        false => 33220,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33221,
                        false => 33222,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33223,
                        false => 33224,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33225,
                        false => 33226,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33227,
                        false => 33228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33229,
                        false => 33230,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33231,
                        false => 33232,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33233,
                        false => 33234,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33235,
                        false => 33236,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33237,
                        false => 33238,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33239,
                        false => 33240,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33241,
                        false => 33242,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33243,
                        false => 33244,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33213 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            33214 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            33215 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            33216 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            33217 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            33218 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            33219 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            33220 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            33221 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            33222 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            33223 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            33224 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            33225 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            33226 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            33227 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            33228 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            33229 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            33230 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            33231 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            33232 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            33233 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            33234 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            33235 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            33236 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            33237 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            33238 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            33239 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            33240 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            33241 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            33242 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            33243 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            33244 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
