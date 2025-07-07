using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_oak_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12397,
                            false => 12398,
                        },
                        false => Powered switch {
                            true => 12399,
                            false => 12400,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12401,
                            false => 12402,
                        },
                        false => Powered switch {
                            true => 12403,
                            false => 12404,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12405,
                            false => 12406,
                        },
                        false => Powered switch {
                            true => 12407,
                            false => 12408,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12409,
                            false => 12410,
                        },
                        false => Powered switch {
                            true => 12411,
                            false => 12412,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12413,
                            false => 12414,
                        },
                        false => Powered switch {
                            true => 12415,
                            false => 12416,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12417,
                            false => 12418,
                        },
                        false => Powered switch {
                            true => 12419,
                            false => 12420,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12421,
                            false => 12422,
                        },
                        false => Powered switch {
                            true => 12423,
                            false => 12424,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12425,
                            false => 12426,
                        },
                        false => Powered switch {
                            true => 12427,
                            false => 12428,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12397 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            12398 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            12399 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            12400 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            12401 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            12402 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            12403 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            12404 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            12405 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            12406 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            12407 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            12408 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            12409 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            12410 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            12411 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            12412 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            12413 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            12414 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            12415 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            12416 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            12417 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            12418 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            12419 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            12420 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            12421 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            12422 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            12423 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            12424 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            12425 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            12426 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            12427 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            12428 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
