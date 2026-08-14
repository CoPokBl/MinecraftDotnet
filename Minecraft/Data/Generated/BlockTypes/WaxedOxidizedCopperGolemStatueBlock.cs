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
    private static readonly BlockInfo Data = new("minecraft:copper_golem_statue", "block.minecraft.waxed_oxidized_copper_golem_statue", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:copper_golem_statue", "minecraft:waxed_oxidized_copper_golem_statue", BlockInfo.VanillaOnly, "minecraft:blocks/waxed_oxidized_copper_golem_statue");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Destroy, 55, "copper_golem_statue", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S507, BlockShapes.S507, BlockShapes.S1, BlockShapes.S1, BlockShapes.S507, BlockShapes.S507);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29984];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29984,
                        false => 29985,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29986,
                        false => 29987,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29988,
                        false => 29989,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29990,
                        false => 29991,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29992,
                        false => 29993,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29994,
                        false => 29995,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29996,
                        false => 29997,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29998,
                        false => 29999,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 30000,
                        false => 30001,
                    },
                    Direction.South => Waterlogged switch {
                        true => 30002,
                        false => 30003,
                    },
                    Direction.West => Waterlogged switch {
                        true => 30004,
                        false => 30005,
                    },
                    Direction.East => Waterlogged switch {
                        true => 30006,
                        false => 30007,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 30008,
                        false => 30009,
                    },
                    Direction.South => Waterlogged switch {
                        true => 30010,
                        false => 30011,
                    },
                    Direction.West => Waterlogged switch {
                        true => 30012,
                        false => 30013,
                    },
                    Direction.East => Waterlogged switch {
                        true => 30014,
                        false => 30015,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29984 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            29985 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            29986 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            29987 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            29988 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            29989 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            29990 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            29991 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            29992 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            29993 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            29994 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            29995 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            29996 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            29997 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            29998 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            29999 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            30000 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            30001 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            30002 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            30003 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            30004 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            30005 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            30006 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            30007 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            30008 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            30009 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            30010 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            30011 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            30012 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            30013 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            30014 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            30015 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
