using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperGolemStatueBlock(Identifier Identifier, CopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_golem_statue";
    public int ProtocolId => 1087;
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper_golem_statue";
    public Identifier? BlockEntity => "minecraft:copper_golem_statue";
    public Identifier? Item => "minecraft:copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27085,
                        false => 27086,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27087,
                        false => 27088,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27089,
                        false => 27090,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27091,
                        false => 27092,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27093,
                        false => 27094,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27095,
                        false => 27096,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27097,
                        false => 27098,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27099,
                        false => 27100,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27101,
                        false => 27102,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27103,
                        false => 27104,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27105,
                        false => 27106,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27107,
                        false => 27108,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27109,
                        false => 27110,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27111,
                        false => 27112,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27113,
                        false => 27114,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27115,
                        false => 27116,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27085 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27086 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27087 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27088 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27089 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27090 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27091 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27092 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27093 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27094 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27095 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27096 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27097 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27098 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27099 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27100 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27101 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27102 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27103 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27104 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27105 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27106 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27107 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27108 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27109 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27110 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27111 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27112 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27113 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27114 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27115 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27116 => new CopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
