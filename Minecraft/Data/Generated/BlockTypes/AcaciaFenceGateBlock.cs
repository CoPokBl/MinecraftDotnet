using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
    public Identifier Category => "minecraft:fence_gate";
    public int ProtocolId => 599;
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
    public Identifier? Item => "minecraft:acacia_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12301,
                            false => 12302,
                        },
                        false => Powered switch {
                            true => 12303,
                            false => 12304,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12305,
                            false => 12306,
                        },
                        false => Powered switch {
                            true => 12307,
                            false => 12308,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12309,
                            false => 12310,
                        },
                        false => Powered switch {
                            true => 12311,
                            false => 12312,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12313,
                            false => 12314,
                        },
                        false => Powered switch {
                            true => 12315,
                            false => 12316,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12317,
                            false => 12318,
                        },
                        false => Powered switch {
                            true => 12319,
                            false => 12320,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12321,
                            false => 12322,
                        },
                        false => Powered switch {
                            true => 12323,
                            false => 12324,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12325,
                            false => 12326,
                        },
                        false => Powered switch {
                            true => 12327,
                            false => 12328,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12329,
                            false => 12330,
                        },
                        false => Powered switch {
                            true => 12331,
                            false => 12332,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12301 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, true),
            12302 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, true, false),
            12303 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, true),
            12304 => new AcaciaFenceGateBlock(Identifier, Direction.North, true, false, false),
            12305 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, true),
            12306 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, true, false),
            12307 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, true),
            12308 => new AcaciaFenceGateBlock(Identifier, Direction.North, false, false, false),
            12309 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, true),
            12310 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, true, false),
            12311 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, true),
            12312 => new AcaciaFenceGateBlock(Identifier, Direction.South, true, false, false),
            12313 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, true),
            12314 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, true, false),
            12315 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, true),
            12316 => new AcaciaFenceGateBlock(Identifier, Direction.South, false, false, false),
            12317 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, true),
            12318 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, true, false),
            12319 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, true),
            12320 => new AcaciaFenceGateBlock(Identifier, Direction.West, true, false, false),
            12321 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, true),
            12322 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, true, false),
            12323 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, true),
            12324 => new AcaciaFenceGateBlock(Identifier, Direction.West, false, false, false),
            12325 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, true),
            12326 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, true, false),
            12327 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, true),
            12328 => new AcaciaFenceGateBlock(Identifier, Direction.East, true, false, false),
            12329 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, true),
            12330 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, true, false),
            12331 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, true),
            12332 => new AcaciaFenceGateBlock(Identifier, Direction.East, false, false, false),
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
