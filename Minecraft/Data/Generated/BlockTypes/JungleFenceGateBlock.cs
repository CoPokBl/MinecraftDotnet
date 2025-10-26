using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 628;
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
    public Identifier? Item => "minecraft:jungle_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13346,
                            false => 13347,
                        },
                        false => Powered switch {
                            true => 13348,
                            false => 13349,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13350,
                            false => 13351,
                        },
                        false => Powered switch {
                            true => 13352,
                            false => 13353,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13354,
                            false => 13355,
                        },
                        false => Powered switch {
                            true => 13356,
                            false => 13357,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13358,
                            false => 13359,
                        },
                        false => Powered switch {
                            true => 13360,
                            false => 13361,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13362,
                            false => 13363,
                        },
                        false => Powered switch {
                            true => 13364,
                            false => 13365,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13366,
                            false => 13367,
                        },
                        false => Powered switch {
                            true => 13368,
                            false => 13369,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13370,
                            false => 13371,
                        },
                        false => Powered switch {
                            true => 13372,
                            false => 13373,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13374,
                            false => 13375,
                        },
                        false => Powered switch {
                            true => 13376,
                            false => 13377,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13346 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, true),
            13347 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, false),
            13348 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, true),
            13349 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, false),
            13350 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, true),
            13351 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, false),
            13352 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, true),
            13353 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, false),
            13354 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, true),
            13355 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, false),
            13356 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, true),
            13357 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, false),
            13358 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, true),
            13359 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, false),
            13360 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, true),
            13361 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, false),
            13362 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, true),
            13363 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, false),
            13364 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, true),
            13365 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, false),
            13366 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, true),
            13367 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, false),
            13368 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, true),
            13369 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, false),
            13370 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, true),
            13371 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, false),
            13372 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, true),
            13373 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, false),
            13374 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, true),
            13375 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, false),
            13376 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, true),
            13377 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, false),
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
