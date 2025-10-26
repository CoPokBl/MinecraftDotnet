using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperGolemStatueBlock(Identifier Identifier, WaxedWeatheredCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_golem_statue";
    public int ProtocolId => 1093;
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
    public Identifier? Item => "minecraft:waxed_weathered_copper_golem_statue";
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
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27277,
                        false => 27278,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27279,
                        false => 27280,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27281,
                        false => 27282,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27283,
                        false => 27284,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27285,
                        false => 27286,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27287,
                        false => 27288,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27289,
                        false => 27290,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27291,
                        false => 27292,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27293,
                        false => 27294,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27295,
                        false => 27296,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27297,
                        false => 27298,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27299,
                        false => 27300,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27301,
                        false => 27302,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27303,
                        false => 27304,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27305,
                        false => 27306,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27307,
                        false => 27308,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27277 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27278 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27279 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27280 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27281 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27282 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27283 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27284 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27285 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27286 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27287 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27288 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27289 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27290 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27291 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27292 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27293 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27294 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27295 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27296 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27297 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27298 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27299 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27300 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27301 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27302 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27303 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27304 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27305 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27306 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27307 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27308 => new WaxedWeatheredCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
