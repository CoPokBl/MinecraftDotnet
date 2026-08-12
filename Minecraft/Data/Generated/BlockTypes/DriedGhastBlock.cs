using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DriedGhastBlock(Identifier Identifier, Direction Facing, int Hydration, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:dried_ghast";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "dried_ghast";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:dried_ghast";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.8125, 0.625, 0.8125]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.dried_ghast";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15105,
                        false => 15106,
                    },
                    1 => Waterlogged switch {
                        true => 15107,
                        false => 15108,
                    },
                    2 => Waterlogged switch {
                        true => 15109,
                        false => 15110,
                    },
                    3 => Waterlogged switch {
                        true => 15111,
                        false => 15112,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.South => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15113,
                        false => 15114,
                    },
                    1 => Waterlogged switch {
                        true => 15115,
                        false => 15116,
                    },
                    2 => Waterlogged switch {
                        true => 15117,
                        false => 15118,
                    },
                    3 => Waterlogged switch {
                        true => 15119,
                        false => 15120,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.West => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15121,
                        false => 15122,
                    },
                    1 => Waterlogged switch {
                        true => 15123,
                        false => 15124,
                    },
                    2 => Waterlogged switch {
                        true => 15125,
                        false => 15126,
                    },
                    3 => Waterlogged switch {
                        true => 15127,
                        false => 15128,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.East => Hydration switch {
                    0 => Waterlogged switch {
                        true => 15129,
                        false => 15130,
                    },
                    1 => Waterlogged switch {
                        true => 15131,
                        false => 15132,
                    },
                    2 => Waterlogged switch {
                        true => 15133,
                        false => 15134,
                    },
                    3 => Waterlogged switch {
                        true => 15135,
                        false => 15136,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15105 => new DriedGhastBlock(Identifier, Direction.North, 0, true),
            15106 => new DriedGhastBlock(Identifier, Direction.North, 0, false),
            15107 => new DriedGhastBlock(Identifier, Direction.North, 1, true),
            15108 => new DriedGhastBlock(Identifier, Direction.North, 1, false),
            15109 => new DriedGhastBlock(Identifier, Direction.North, 2, true),
            15110 => new DriedGhastBlock(Identifier, Direction.North, 2, false),
            15111 => new DriedGhastBlock(Identifier, Direction.North, 3, true),
            15112 => new DriedGhastBlock(Identifier, Direction.North, 3, false),
            15113 => new DriedGhastBlock(Identifier, Direction.South, 0, true),
            15114 => new DriedGhastBlock(Identifier, Direction.South, 0, false),
            15115 => new DriedGhastBlock(Identifier, Direction.South, 1, true),
            15116 => new DriedGhastBlock(Identifier, Direction.South, 1, false),
            15117 => new DriedGhastBlock(Identifier, Direction.South, 2, true),
            15118 => new DriedGhastBlock(Identifier, Direction.South, 2, false),
            15119 => new DriedGhastBlock(Identifier, Direction.South, 3, true),
            15120 => new DriedGhastBlock(Identifier, Direction.South, 3, false),
            15121 => new DriedGhastBlock(Identifier, Direction.West, 0, true),
            15122 => new DriedGhastBlock(Identifier, Direction.West, 0, false),
            15123 => new DriedGhastBlock(Identifier, Direction.West, 1, true),
            15124 => new DriedGhastBlock(Identifier, Direction.West, 1, false),
            15125 => new DriedGhastBlock(Identifier, Direction.West, 2, true),
            15126 => new DriedGhastBlock(Identifier, Direction.West, 2, false),
            15127 => new DriedGhastBlock(Identifier, Direction.West, 3, true),
            15128 => new DriedGhastBlock(Identifier, Direction.West, 3, false),
            15129 => new DriedGhastBlock(Identifier, Direction.East, 0, true),
            15130 => new DriedGhastBlock(Identifier, Direction.East, 0, false),
            15131 => new DriedGhastBlock(Identifier, Direction.East, 1, true),
            15132 => new DriedGhastBlock(Identifier, Direction.East, 1, false),
            15133 => new DriedGhastBlock(Identifier, Direction.East, 2, true),
            15134 => new DriedGhastBlock(Identifier, Direction.East, 2, false),
            15135 => new DriedGhastBlock(Identifier, Direction.East, 3, true),
            15136 => new DriedGhastBlock(Identifier, Direction.East, 3, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Hydration = properties.Contains("hydration") ? int.Parse(properties["hydration"].GetString()) : Hydration,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("hydration", new StringTag(Hydration.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
