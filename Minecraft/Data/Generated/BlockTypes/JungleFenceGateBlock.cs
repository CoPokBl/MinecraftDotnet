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
    public int ProtocolId => 598;
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
                            true => 12269,
                            false => 12270,
                        },
                        false => Powered switch {
                            true => 12271,
                            false => 12272,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12273,
                            false => 12274,
                        },
                        false => Powered switch {
                            true => 12275,
                            false => 12276,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12277,
                            false => 12278,
                        },
                        false => Powered switch {
                            true => 12279,
                            false => 12280,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12281,
                            false => 12282,
                        },
                        false => Powered switch {
                            true => 12283,
                            false => 12284,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12285,
                            false => 12286,
                        },
                        false => Powered switch {
                            true => 12287,
                            false => 12288,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12289,
                            false => 12290,
                        },
                        false => Powered switch {
                            true => 12291,
                            false => 12292,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 12293,
                            false => 12294,
                        },
                        false => Powered switch {
                            true => 12295,
                            false => 12296,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 12297,
                            false => 12298,
                        },
                        false => Powered switch {
                            true => 12299,
                            false => 12300,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12269 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, true),
            12270 => new JungleFenceGateBlock(Identifier, Direction.North, true, true, false),
            12271 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, true),
            12272 => new JungleFenceGateBlock(Identifier, Direction.North, true, false, false),
            12273 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, true),
            12274 => new JungleFenceGateBlock(Identifier, Direction.North, false, true, false),
            12275 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, true),
            12276 => new JungleFenceGateBlock(Identifier, Direction.North, false, false, false),
            12277 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, true),
            12278 => new JungleFenceGateBlock(Identifier, Direction.South, true, true, false),
            12279 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, true),
            12280 => new JungleFenceGateBlock(Identifier, Direction.South, true, false, false),
            12281 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, true),
            12282 => new JungleFenceGateBlock(Identifier, Direction.South, false, true, false),
            12283 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, true),
            12284 => new JungleFenceGateBlock(Identifier, Direction.South, false, false, false),
            12285 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, true),
            12286 => new JungleFenceGateBlock(Identifier, Direction.West, true, true, false),
            12287 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, true),
            12288 => new JungleFenceGateBlock(Identifier, Direction.West, true, false, false),
            12289 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, true),
            12290 => new JungleFenceGateBlock(Identifier, Direction.West, false, true, false),
            12291 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, true),
            12292 => new JungleFenceGateBlock(Identifier, Direction.West, false, false, false),
            12293 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, true),
            12294 => new JungleFenceGateBlock(Identifier, Direction.East, true, true, false),
            12295 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, true),
            12296 => new JungleFenceGateBlock(Identifier, Direction.East, true, false, false),
            12297 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, true),
            12298 => new JungleFenceGateBlock(Identifier, Direction.East, false, true, false),
            12299 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, true),
            12300 => new JungleFenceGateBlock(Identifier, Direction.East, false, false, false),
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
