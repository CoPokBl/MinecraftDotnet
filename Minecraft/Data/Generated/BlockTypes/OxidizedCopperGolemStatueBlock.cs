using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperGolemStatueBlock(Identifier Identifier, OxidizedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_golem_statue";
    public int ProtocolId => 1090;
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
    public Identifier? Item => "minecraft:oxidized_copper_golem_statue";
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
    public string TranslationKey => "block.minecraft.oxidized_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27181,
                        false => 27182,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27183,
                        false => 27184,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27185,
                        false => 27186,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27187,
                        false => 27188,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27189,
                        false => 27190,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27191,
                        false => 27192,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27193,
                        false => 27194,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27195,
                        false => 27196,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27197,
                        false => 27198,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27199,
                        false => 27200,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27201,
                        false => 27202,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27203,
                        false => 27204,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27205,
                        false => 27206,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27207,
                        false => 27208,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27209,
                        false => 27210,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27211,
                        false => 27212,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27181 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27182 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27183 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27184 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27185 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27186 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27187 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27188 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27189 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27190 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27191 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27192 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27193 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27194 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27195 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27196 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27197 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27198 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27199 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27200 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27201 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27202 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27203 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27204 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27205 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27206 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27207 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27208 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27209 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27210 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27211 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27212 => new OxidizedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
