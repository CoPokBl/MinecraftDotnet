using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock {
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
    public string SoundType => "wood";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:spruce_fence_gate";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.0, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.3125, 0.4375] -> [0.125, 1.0, 0.5625], AABB[0.875, 0.3125, 0.4375] -> [1.0, 1.0, 0.5625]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.375] -> [1.0, 1.5, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_fence_gate";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13484,
                            false => 13485,
                        },
                        false => Powered switch {
                            true => 13486,
                            false => 13487,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13488,
                            false => 13489,
                        },
                        false => Powered switch {
                            true => 13490,
                            false => 13491,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13492,
                            false => 13493,
                        },
                        false => Powered switch {
                            true => 13494,
                            false => 13495,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13496,
                            false => 13497,
                        },
                        false => Powered switch {
                            true => 13498,
                            false => 13499,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13500,
                            false => 13501,
                        },
                        false => Powered switch {
                            true => 13502,
                            false => 13503,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13504,
                            false => 13505,
                        },
                        false => Powered switch {
                            true => 13506,
                            false => 13507,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13508,
                            false => 13509,
                        },
                        false => Powered switch {
                            true => 13510,
                            false => 13511,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13512,
                            false => 13513,
                        },
                        false => Powered switch {
                            true => 13514,
                            false => 13515,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13484 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, true),
            13485 => new SpruceFenceGateBlock(Identifier, Direction.North, true, true, false),
            13486 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, true),
            13487 => new SpruceFenceGateBlock(Identifier, Direction.North, true, false, false),
            13488 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, true),
            13489 => new SpruceFenceGateBlock(Identifier, Direction.North, false, true, false),
            13490 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, true),
            13491 => new SpruceFenceGateBlock(Identifier, Direction.North, false, false, false),
            13492 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, true),
            13493 => new SpruceFenceGateBlock(Identifier, Direction.South, true, true, false),
            13494 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, true),
            13495 => new SpruceFenceGateBlock(Identifier, Direction.South, true, false, false),
            13496 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, true),
            13497 => new SpruceFenceGateBlock(Identifier, Direction.South, false, true, false),
            13498 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, true),
            13499 => new SpruceFenceGateBlock(Identifier, Direction.South, false, false, false),
            13500 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, true),
            13501 => new SpruceFenceGateBlock(Identifier, Direction.West, true, true, false),
            13502 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, true),
            13503 => new SpruceFenceGateBlock(Identifier, Direction.West, true, false, false),
            13504 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, true),
            13505 => new SpruceFenceGateBlock(Identifier, Direction.West, false, true, false),
            13506 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, true),
            13507 => new SpruceFenceGateBlock(Identifier, Direction.West, false, false, false),
            13508 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, true),
            13509 => new SpruceFenceGateBlock(Identifier, Direction.East, true, true, false),
            13510 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, true),
            13511 => new SpruceFenceGateBlock(Identifier, Direction.East, true, false, false),
            13512 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, true),
            13513 => new SpruceFenceGateBlock(Identifier, Direction.East, false, true, false),
            13514 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, true),
            13515 => new SpruceFenceGateBlock(Identifier, Direction.East, false, false, false),
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
