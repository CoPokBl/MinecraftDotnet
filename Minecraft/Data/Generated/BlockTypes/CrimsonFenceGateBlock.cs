using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 853;
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
    public Identifier? Item => "minecraft:crimson_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19931,
                            false => 19932,
                        },
                        false => Powered switch {
                            true => 19933,
                            false => 19934,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19935,
                            false => 19936,
                        },
                        false => Powered switch {
                            true => 19937,
                            false => 19938,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19939,
                            false => 19940,
                        },
                        false => Powered switch {
                            true => 19941,
                            false => 19942,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19943,
                            false => 19944,
                        },
                        false => Powered switch {
                            true => 19945,
                            false => 19946,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19947,
                            false => 19948,
                        },
                        false => Powered switch {
                            true => 19949,
                            false => 19950,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19951,
                            false => 19952,
                        },
                        false => Powered switch {
                            true => 19953,
                            false => 19954,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19955,
                            false => 19956,
                        },
                        false => Powered switch {
                            true => 19957,
                            false => 19958,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19959,
                            false => 19960,
                        },
                        false => Powered switch {
                            true => 19961,
                            false => 19962,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19931 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, true),
            19932 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, true, false),
            19933 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, true),
            19934 => new CrimsonFenceGateBlock(Identifier, Direction.North, true, false, false),
            19935 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, true),
            19936 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, true, false),
            19937 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, true),
            19938 => new CrimsonFenceGateBlock(Identifier, Direction.North, false, false, false),
            19939 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, true),
            19940 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, true, false),
            19941 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, true),
            19942 => new CrimsonFenceGateBlock(Identifier, Direction.South, true, false, false),
            19943 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, true),
            19944 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, true, false),
            19945 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, true),
            19946 => new CrimsonFenceGateBlock(Identifier, Direction.South, false, false, false),
            19947 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, true),
            19948 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, true, false),
            19949 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, true),
            19950 => new CrimsonFenceGateBlock(Identifier, Direction.West, true, false, false),
            19951 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, true),
            19952 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, true, false),
            19953 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, true),
            19954 => new CrimsonFenceGateBlock(Identifier, Direction.West, false, false, false),
            19955 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, true),
            19956 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, true, false),
            19957 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, true),
            19958 => new CrimsonFenceGateBlock(Identifier, Direction.East, true, false, false),
            19959 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, true),
            19960 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, true, false),
            19961 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, true),
            19962 => new CrimsonFenceGateBlock(Identifier, Direction.East, false, false, false),
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
