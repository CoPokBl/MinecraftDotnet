using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherryFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:cherry_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12333,
                            false => 12334,
                        },
                        false => Powered switch {
                            true => 12335,
                            false => 12336,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12337,
                            false => 12338,
                        },
                        false => Powered switch {
                            true => 12339,
                            false => 12340,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12341,
                            false => 12342,
                        },
                        false => Powered switch {
                            true => 12343,
                            false => 12344,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12345,
                            false => 12346,
                        },
                        false => Powered switch {
                            true => 12347,
                            false => 12348,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12349,
                            false => 12350,
                        },
                        false => Powered switch {
                            true => 12351,
                            false => 12352,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12353,
                            false => 12354,
                        },
                        false => Powered switch {
                            true => 12355,
                            false => 12356,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12357,
                            false => 12358,
                        },
                        false => Powered switch {
                            true => 12359,
                            false => 12360,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12361,
                            false => 12362,
                        },
                        false => Powered switch {
                            true => 12363,
                            false => 12364,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12333 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, true),
            12334 => new CherryFenceGateBlock(Identifier, Direction.North, true, true, false),
            12335 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, true),
            12336 => new CherryFenceGateBlock(Identifier, Direction.North, true, false, false),
            12337 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, true),
            12338 => new CherryFenceGateBlock(Identifier, Direction.North, false, true, false),
            12339 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, true),
            12340 => new CherryFenceGateBlock(Identifier, Direction.North, false, false, false),
            12341 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, true),
            12342 => new CherryFenceGateBlock(Identifier, Direction.South, true, true, false),
            12343 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, true),
            12344 => new CherryFenceGateBlock(Identifier, Direction.South, true, false, false),
            12345 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, true),
            12346 => new CherryFenceGateBlock(Identifier, Direction.South, false, true, false),
            12347 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, true),
            12348 => new CherryFenceGateBlock(Identifier, Direction.South, false, false, false),
            12349 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, true),
            12350 => new CherryFenceGateBlock(Identifier, Direction.West, true, true, false),
            12351 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, true),
            12352 => new CherryFenceGateBlock(Identifier, Direction.West, true, false, false),
            12353 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, true),
            12354 => new CherryFenceGateBlock(Identifier, Direction.West, false, true, false),
            12355 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, true),
            12356 => new CherryFenceGateBlock(Identifier, Direction.West, false, false, false),
            12357 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, true),
            12358 => new CherryFenceGateBlock(Identifier, Direction.East, true, true, false),
            12359 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, true),
            12360 => new CherryFenceGateBlock(Identifier, Direction.East, true, false, false),
            12361 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, true),
            12362 => new CherryFenceGateBlock(Identifier, Direction.East, false, true, false),
            12363 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, true),
            12364 => new CherryFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            InWall = properties["in_wall"].GetString() == "true",
            Open = properties["open"].GetString() == "true",
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
