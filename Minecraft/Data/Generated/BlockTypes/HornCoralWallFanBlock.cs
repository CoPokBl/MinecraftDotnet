using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record HornCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:coral_wall_fan";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wet_grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:horn_coral_fan";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.25, 0.3125] -> [1.0, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.horn_coral_wall_fan";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 15259,
                    false => 15260,
                },
                Direction.South => Waterlogged switch {
                    true => 15261,
                    false => 15262,
                },
                Direction.West => Waterlogged switch {
                    true => 15263,
                    false => 15264,
                },
                Direction.East => Waterlogged switch {
                    true => 15265,
                    false => 15266,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15259 => new HornCoralWallFanBlock(Identifier, Direction.North, true),
            15260 => new HornCoralWallFanBlock(Identifier, Direction.North, false),
            15261 => new HornCoralWallFanBlock(Identifier, Direction.South, true),
            15262 => new HornCoralWallFanBlock(Identifier, Direction.South, false),
            15263 => new HornCoralWallFanBlock(Identifier, Direction.West, true),
            15264 => new HornCoralWallFanBlock(Identifier, Direction.West, false),
            15265 => new HornCoralWallFanBlock(Identifier, Direction.East, true),
            15266 => new HornCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
