using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeadFireCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:base_coral_wall_fan";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:dead_fire_coral_fan";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.25, 0.3125] -> [1.0, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.dead_fire_coral_wall_fan";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13900,
                    false => 13901,
                },
                Direction.South => Waterlogged switch {
                    true => 13902,
                    false => 13903,
                },
                Direction.West => Waterlogged switch {
                    true => 13904,
                    false => 13905,
                },
                Direction.East => Waterlogged switch {
                    true => 13906,
                    false => 13907,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13900 => new DeadFireCoralWallFanBlock(Identifier, Direction.North, true),
            13901 => new DeadFireCoralWallFanBlock(Identifier, Direction.North, false),
            13902 => new DeadFireCoralWallFanBlock(Identifier, Direction.South, true),
            13903 => new DeadFireCoralWallFanBlock(Identifier, Direction.South, false),
            13904 => new DeadFireCoralWallFanBlock(Identifier, Direction.West, true),
            13905 => new DeadFireCoralWallFanBlock(Identifier, Direction.West, false),
            13906 => new DeadFireCoralWallFanBlock(Identifier, Direction.East, true),
            13907 => new DeadFireCoralWallFanBlock(Identifier, Direction.East, false),
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
