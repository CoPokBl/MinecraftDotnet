using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperGolemStatueBlock(Identifier Identifier, WaxedOxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_golem_statue";
    public int ProtocolId => 1094;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper_golem_statue";
    public Identifier? BlockEntity => "minecraft:copper_golem_statue";
    public Identifier? Item => "minecraft:waxed_oxidized_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27309,
                        false => 27310,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27311,
                        false => 27312,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27313,
                        false => 27314,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27315,
                        false => 27316,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27317,
                        false => 27318,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27319,
                        false => 27320,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27321,
                        false => 27322,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27323,
                        false => 27324,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27325,
                        false => 27326,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27327,
                        false => 27328,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27329,
                        false => 27330,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27331,
                        false => 27332,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27333,
                        false => 27334,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27335,
                        false => 27336,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27337,
                        false => 27338,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27339,
                        false => 27340,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27309 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27310 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27311 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27312 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27313 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27314 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27315 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27316 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27317 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27318 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27319 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27320 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27321 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27322 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27323 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27324 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27325 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27326 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27327 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27328 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27329 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27330 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27331 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27332 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27333 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27334 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27335 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27336 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27337 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27338 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27339 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27340 => new WaxedOxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CopperGolemPoseValue = properties.ChildrenMap.ContainsKey("copper_golem_pose") ? CopperGolemPoseFromString(properties["copper_golem_pose"].GetString()) : CopperGolemPoseValue,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("copper_golem_pose", CopperGolemPoseToName(CopperGolemPoseValue)),
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
