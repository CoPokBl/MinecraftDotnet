using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public double Hardness => 2;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:warped_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21274,
                            false => 21275,
                        },
                        false => Powered switch {
                            true => 21276,
                            false => 21277,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21278,
                            false => 21279,
                        },
                        false => Powered switch {
                            true => 21280,
                            false => 21281,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21282,
                            false => 21283,
                        },
                        false => Powered switch {
                            true => 21284,
                            false => 21285,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21286,
                            false => 21287,
                        },
                        false => Powered switch {
                            true => 21288,
                            false => 21289,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21290,
                            false => 21291,
                        },
                        false => Powered switch {
                            true => 21292,
                            false => 21293,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21294,
                            false => 21295,
                        },
                        false => Powered switch {
                            true => 21296,
                            false => 21297,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21298,
                            false => 21299,
                        },
                        false => Powered switch {
                            true => 21300,
                            false => 21301,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21302,
                            false => 21303,
                        },
                        false => Powered switch {
                            true => 21304,
                            false => 21305,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21274 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, true),
            21275 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, false),
            21276 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, true),
            21277 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, false),
            21278 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, true),
            21279 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, false),
            21280 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, true),
            21281 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, false),
            21282 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, true),
            21283 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, false),
            21284 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, true),
            21285 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, false),
            21286 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, true),
            21287 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, false),
            21288 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, true),
            21289 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, false),
            21290 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, true),
            21291 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, false),
            21292 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, true),
            21293 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, false),
            21294 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, true),
            21295 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, false),
            21296 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, true),
            21297 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, false),
            21298 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, true),
            21299 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, false),
            21300 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, true),
            21301 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, false),
            21302 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, true),
            21303 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, false),
            21304 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, true),
            21305 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.Contains("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("in_wall", new StringTag(InWall.ToString().ToLower())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
