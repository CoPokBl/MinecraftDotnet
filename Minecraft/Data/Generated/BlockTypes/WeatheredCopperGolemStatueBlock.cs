using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WeatheredCopperGolemStatueBlock(Identifier Identifier, WeatheredCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_golem_statue";
    public int ProtocolId => 1089;
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
    public Identifier? Item => "minecraft:weathered_copper_golem_statue";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.875, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.weathered_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27149,
                        false => 27150,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27151,
                        false => 27152,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27153,
                        false => 27154,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27155,
                        false => 27156,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27157,
                        false => 27158,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27159,
                        false => 27160,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27161,
                        false => 27162,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27163,
                        false => 27164,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27165,
                        false => 27166,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27167,
                        false => 27168,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27169,
                        false => 27170,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27171,
                        false => 27172,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27173,
                        false => 27174,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27175,
                        false => 27176,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27177,
                        false => 27178,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27179,
                        false => 27180,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27149 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27150 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27151 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27152 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27153 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27154 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27155 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27156 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27157 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27158 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27159 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27160 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27161 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27162 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27163 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27164 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27165 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27166 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27167 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27168 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27169 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27170 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27171 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27172 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27173 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27174 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27175 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27176 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27177 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27178 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27179 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27180 => new WeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
