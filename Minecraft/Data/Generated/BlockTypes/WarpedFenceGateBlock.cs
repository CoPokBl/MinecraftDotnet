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
    public int ProtocolId => 854;
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
                            true => 19963,
                            false => 19964,
                        },
                        false => Powered switch {
                            true => 19965,
                            false => 19966,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19967,
                            false => 19968,
                        },
                        false => Powered switch {
                            true => 19969,
                            false => 19970,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19971,
                            false => 19972,
                        },
                        false => Powered switch {
                            true => 19973,
                            false => 19974,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19975,
                            false => 19976,
                        },
                        false => Powered switch {
                            true => 19977,
                            false => 19978,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19979,
                            false => 19980,
                        },
                        false => Powered switch {
                            true => 19981,
                            false => 19982,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19983,
                            false => 19984,
                        },
                        false => Powered switch {
                            true => 19985,
                            false => 19986,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 19987,
                            false => 19988,
                        },
                        false => Powered switch {
                            true => 19989,
                            false => 19990,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 19991,
                            false => 19992,
                        },
                        false => Powered switch {
                            true => 19993,
                            false => 19994,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19963 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, true),
            19964 => new WarpedFenceGateBlock(Identifier, Direction.North, true, true, false),
            19965 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, true),
            19966 => new WarpedFenceGateBlock(Identifier, Direction.North, true, false, false),
            19967 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, true),
            19968 => new WarpedFenceGateBlock(Identifier, Direction.North, false, true, false),
            19969 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, true),
            19970 => new WarpedFenceGateBlock(Identifier, Direction.North, false, false, false),
            19971 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, true),
            19972 => new WarpedFenceGateBlock(Identifier, Direction.South, true, true, false),
            19973 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, true),
            19974 => new WarpedFenceGateBlock(Identifier, Direction.South, true, false, false),
            19975 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, true),
            19976 => new WarpedFenceGateBlock(Identifier, Direction.South, false, true, false),
            19977 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, true),
            19978 => new WarpedFenceGateBlock(Identifier, Direction.South, false, false, false),
            19979 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, true),
            19980 => new WarpedFenceGateBlock(Identifier, Direction.West, true, true, false),
            19981 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, true),
            19982 => new WarpedFenceGateBlock(Identifier, Direction.West, true, false, false),
            19983 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, true),
            19984 => new WarpedFenceGateBlock(Identifier, Direction.West, false, true, false),
            19985 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, true),
            19986 => new WarpedFenceGateBlock(Identifier, Direction.West, false, false, false),
            19987 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, true),
            19988 => new WarpedFenceGateBlock(Identifier, Direction.East, true, true, false),
            19989 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, true),
            19990 => new WarpedFenceGateBlock(Identifier, Direction.East, true, false, false),
            19991 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, true),
            19992 => new WarpedFenceGateBlock(Identifier, Direction.East, false, true, false),
            19993 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, true),
            19994 => new WarpedFenceGateBlock(Identifier, Direction.East, false, false, false),
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
