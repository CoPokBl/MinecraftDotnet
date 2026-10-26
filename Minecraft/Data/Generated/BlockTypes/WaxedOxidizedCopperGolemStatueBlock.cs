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
public record WaxedOxidizedCopperGolemStatueBlock(Identifier Identifier, WaxedOxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.waxed_oxidized_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_oxidized_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_oxidized_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Popped, 55, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33341];

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
                        true => 33341,
                        false => 33342,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33343,
                        false => 33344,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33345,
                        false => 33346,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33347,
                        false => 33348,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33349,
                        false => 33350,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33351,
                        false => 33352,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33353,
                        false => 33354,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33355,
                        false => 33356,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33357,
                        false => 33358,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33359,
                        false => 33360,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33361,
                        false => 33362,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33363,
                        false => 33364,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 33365,
                        false => 33366,
                    },
                    Direction.South => Waterlogged switch {
                        true => 33367,
                        false => 33368,
                    },
                    Direction.West => Waterlogged switch {
                        true => 33369,
                        false => 33370,
                    },
                    Direction.East => Waterlogged switch {
                        true => 33371,
                        false => 33372,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33341 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            33342 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            33343 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            33344 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            33345 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            33346 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            33347 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            33348 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            33349 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            33350 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            33351 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            33352 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            33353 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            33354 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            33355 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            33356 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            33357 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            33358 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            33359 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            33360 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            33361 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            33362 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            33363 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            33364 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            33365 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            33366 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            33367 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            33368 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            33369 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            33370 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            33371 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            33372 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
