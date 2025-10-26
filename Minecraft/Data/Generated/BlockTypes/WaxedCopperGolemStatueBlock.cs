using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedCopperGolemStatueBlock(Identifier Identifier, WaxedCopperGolemStatueBlock.CopperGolemPose CopperGolemPoseValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_golem_statue";
    public int ProtocolId => 1091;
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
    public Identifier? Item => "minecraft:waxed_copper_golem_statue";
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
    public string TranslationKey => "block.minecraft.waxed_copper_golem_statue";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return CopperGolemPoseValue switch {
                CopperGolemPose.Standing => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27213,
                        false => 27214,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27215,
                        false => 27216,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27217,
                        false => 27218,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27219,
                        false => 27220,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Sitting => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27221,
                        false => 27222,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27223,
                        false => 27224,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27225,
                        false => 27226,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27227,
                        false => 27228,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Running => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27229,
                        false => 27230,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27231,
                        false => 27232,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27233,
                        false => 27234,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27235,
                        false => 27236,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                CopperGolemPose.Star => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27237,
                        false => 27238,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27239,
                        false => 27240,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27241,
                        false => 27242,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27243,
                        false => 27244,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(CopperGolemPoseValue), CopperGolemPoseValue, "Unknown value for property copper_golem_pose.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27213 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, true),
            27214 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.North, false),
            27215 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, true),
            27216 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.South, false),
            27217 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, true),
            27218 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.West, false),
            27219 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, true),
            27220 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Standing, Direction.East, false),
            27221 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, true),
            27222 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.North, false),
            27223 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, true),
            27224 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.South, false),
            27225 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, true),
            27226 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.West, false),
            27227 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, true),
            27228 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Sitting, Direction.East, false),
            27229 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, true),
            27230 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.North, false),
            27231 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, true),
            27232 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.South, false),
            27233 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, true),
            27234 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.West, false),
            27235 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, true),
            27236 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Running, Direction.East, false),
            27237 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, true),
            27238 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.North, false),
            27239 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, true),
            27240 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.South, false),
            27241 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, true),
            27242 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.West, false),
            27243 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, true),
            27244 => new WaxedCopperGolemStatueBlock(Identifier, CopperGolemPose.Star, Direction.East, false),
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
