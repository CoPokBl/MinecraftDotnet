using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {

    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 601;
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
    public Identifier? Item => "minecraft:dark_oak_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12365,
                            false => 12366,
                        },
                        false => Powered switch {
                            true => 12367,
                            false => 12368,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12369,
                            false => 12370,
                        },
                        false => Powered switch {
                            true => 12371,
                            false => 12372,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12373,
                            false => 12374,
                        },
                        false => Powered switch {
                            true => 12375,
                            false => 12376,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12377,
                            false => 12378,
                        },
                        false => Powered switch {
                            true => 12379,
                            false => 12380,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12381,
                            false => 12382,
                        },
                        false => Powered switch {
                            true => 12383,
                            false => 12384,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12385,
                            false => 12386,
                        },
                        false => Powered switch {
                            true => 12387,
                            false => 12388,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12389,
                            false => 12390,
                        },
                        false => Powered switch {
                            true => 12391,
                            false => 12392,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12393,
                            false => 12394,
                        },
                        false => Powered switch {
                            true => 12395,
                            false => 12396,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12365 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            12366 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            12367 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            12368 => new DarkOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            12369 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            12370 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            12371 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            12372 => new DarkOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            12373 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            12374 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            12375 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            12376 => new DarkOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            12377 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            12378 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            12379 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            12380 => new DarkOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            12381 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            12382 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            12383 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            12384 => new DarkOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            12385 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            12386 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            12387 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            12388 => new DarkOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            12389 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            12390 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            12391 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            12392 => new DarkOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            12393 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            12394 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            12395 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            12396 => new DarkOakFenceGateBlock(Identifier, Direction.East, false, false, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("facing", Facing.ToName()),
            new StringTag("in_wall", InWall.ToString().ToLower()),
            new StringTag("open", Open.ToString().ToLower()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
