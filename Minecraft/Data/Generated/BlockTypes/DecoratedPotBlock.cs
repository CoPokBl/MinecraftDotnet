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
                        true => 27634,
                        false => 27635,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27636,
                        false => 27637,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27638,
                        false => 27639,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27640,
                        false => 27641,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27642,
                        false => 27643,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27644,
                        false => 27645,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27646,
                        false => 27647,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27648,
                        false => 27649,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27634 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            27635 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            27636 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            27637 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            27638 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            27639 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            27640 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            27641 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            27642 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            27643 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            27644 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            27645 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            27646 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            27647 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            27648 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            27649 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Cracked = properties["cracked"].GetString() == "true",
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
