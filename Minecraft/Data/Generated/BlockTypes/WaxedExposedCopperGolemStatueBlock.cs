using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperGolemStatueBlock(Identifier Identifier, WaxedExposedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_golem_statue";
    public int ProtocolId => 1092;
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27245,
                        false => 27246,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27247,
                        false => 27248,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27249,
                        false => 27250,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27251,
                        false => 27252,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27253,
                        false => 27254,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27255,
                        false => 27256,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27257,
                        false => 27258,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27259,
                        false => 27260,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27261,
                        false => 27262,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27263,
                        false => 27264,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27265,
                        false => 27266,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27267,
                        false => 27268,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27269,
                        false => 27270,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27271,
                        false => 27272,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27273,
                        false => 27274,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27275,
                        false => 27276,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27245 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27246 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27247 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27248 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27249 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27250 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27251 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27252 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27253 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27254 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27255 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27256 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27257 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27258 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27259 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27260 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27261 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27262 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27263 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27264 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27265 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27266 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27267 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27268 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27269 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27270 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27271 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27272 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27273 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27274 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27275 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27276 => new WaxedExposedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
