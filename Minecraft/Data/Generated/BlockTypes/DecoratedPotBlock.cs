using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DecoratedPotBlock(Identifier Identifier, bool Cracked, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:decorated_pot";
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
    public string SoundType => "decorated_pot";
    public Identifier? BlockEntity => "minecraft:decorated_pot";
    public Identifier? Item => "minecraft:decorated_pot";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 50;
    public string TranslationKey => "block.minecraft.decorated_pot";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Cracked switch {
                true => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32086,
                        false => 32087,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32088,
                        false => 32089,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32090,
                        false => 32091,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32092,
                        false => 32093,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32094,
                        false => 32095,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32096,
                        false => 32097,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32098,
                        false => 32099,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32100,
                        false => 32101,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32086 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            32087 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            32088 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            32089 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            32090 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            32091 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            32092 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            32093 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            32094 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            32095 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            32096 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            32097 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            32098 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            32099 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            32100 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            32101 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Cracked = properties.Contains("cracked") ? properties["cracked"].GetString() == "true" : Cracked,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("cracked", new StringTag(Cracked.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
