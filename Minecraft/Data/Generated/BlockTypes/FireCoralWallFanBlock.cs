using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FireCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:fire_coral_fan";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.25, 0.3125] -> [1.0, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.fire_coral_wall_fan";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13972,
                    false => 13973,
                },
                Direction.South => Waterlogged switch {
                    true => 13974,
                    false => 13975,
                },
                Direction.West => Waterlogged switch {
                    true => 13976,
                    false => 13977,
                },
                Direction.East => Waterlogged switch {
                    true => 13978,
                    false => 13979,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13972 => new FireCoralWallFanBlock(Identifier, Direction.North, true),
            13973 => new FireCoralWallFanBlock(Identifier, Direction.North, false),
            13974 => new FireCoralWallFanBlock(Identifier, Direction.South, true),
            13975 => new FireCoralWallFanBlock(Identifier, Direction.South, false),
            13976 => new FireCoralWallFanBlock(Identifier, Direction.West, true),
            13977 => new FireCoralWallFanBlock(Identifier, Direction.West, false),
            13978 => new FireCoralWallFanBlock(Identifier, Direction.East, true),
            13979 => new FireCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
