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
    public int ProtocolId => 1092;
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
                        true => 27666,
                        false => 27667,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27668,
                        false => 27669,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27670,
                        false => 27671,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27672,
                        false => 27673,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 27674,
                        false => 27675,
                    },
                    Direction.South => Waterlogged switch {
                        true => 27676,
                        false => 27677,
                    },
                    Direction.West => Waterlogged switch {
                        true => 27678,
                        false => 27679,
                    },
                    Direction.East => Waterlogged switch {
                        true => 27680,
                        false => 27681,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27666 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            27667 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            27668 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            27669 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            27670 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            27671 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            27672 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            27673 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            27674 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            27675 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            27676 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            27677 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            27678 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            27679 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            27680 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            27681 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Cracked = properties.ChildrenMap.ContainsKey("cracked") ? properties["cracked"].GetString() == "true" : Cracked,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("cracked", Cracked.ToString().ToLower()),
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
