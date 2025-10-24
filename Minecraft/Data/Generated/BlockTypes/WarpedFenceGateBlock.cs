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
    public int ProtocolId => 892;
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
                            true => 21072,
                            false => 21073,
                        },
                        false => Powered switch {
                            true => 21074,
                            false => 21075,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21076,
                            false => 21077,
                        },
                        false => Powered switch {
                            true => 21078,
                            false => 21079,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21080,
                            false => 21081,
                        },
                        false => Powered switch {
                            true => 21082,
                            false => 21083,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21084,
                            false => 21085,
                        },
                        false => Powered switch {
                            true => 21086,
                            false => 21087,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21088,
                            false => 21089,
                        },
                        false => Powered switch {
                            true => 21090,
                            false => 21091,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21092,
                            false => 21093,
                        },
                        false => Powered switch {
                            true => 21094,
                            false => 21095,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 21096,
                            false => 21097,
                        },
                        false => Powered switch {
                            true => 21098,
                            false => 21099,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 21100,
                            false => 21101,
                        },
                        false => Powered switch {
                            true => 21102,
                            false => 21103,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21072 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, true),
            21073 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, false),
            21074 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, true),
            21075 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, false),
            21076 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, true),
            21077 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, false),
            21078 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, true),
            21079 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, false),
            21080 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, true),
            21081 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, false),
            21082 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, true),
            21083 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, false),
            21084 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, true),
            21085 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, false),
            21086 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, true),
            21087 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, false),
            21088 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, true),
            21089 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, false),
            21090 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, true),
            21091 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, false),
            21092 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, true),
            21093 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, false),
            21094 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, true),
            21095 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, false),
            21096 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, true),
            21097 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, false),
            21098 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, true),
            21099 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, false),
            21100 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, true),
            21101 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, false),
            21102 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, true),
            21103 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.ChildrenMap.ContainsKey("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.ChildrenMap.ContainsKey("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
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
