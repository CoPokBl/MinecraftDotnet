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
    public int ProtocolId => 1153;
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
                        true => 29391,
                        false => 29392,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29393,
                        false => 29394,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29395,
                        false => 29396,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29397,
                        false => 29398,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29399,
                        false => 29400,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29401,
                        false => 29402,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29403,
                        false => 29404,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29405,
                        false => 29406,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29391 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            29392 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            29393 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            29394 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            29395 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            29396 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            29397 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            29398 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            29399 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            29400 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            29401 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            29402 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            29403 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            29404 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            29405 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            29406 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
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
