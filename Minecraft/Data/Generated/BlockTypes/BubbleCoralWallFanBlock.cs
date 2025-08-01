using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BubbleCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:coral_wall_fan";
    public int ProtocolId => 753;
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
    public Identifier? Item => "minecraft:bubble_coral_fan";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.25, 0.3125] -> [1.0, 0.75, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.bubble_coral_wall_fan";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 13964,
                    false => 13965,
                },
                Direction.South => Waterlogged switch {
                    true => 13966,
                    false => 13967,
                },
                Direction.West => Waterlogged switch {
                    true => 13968,
                    false => 13969,
                },
                Direction.East => Waterlogged switch {
                    true => 13970,
                    false => 13971,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13964 => new BubbleCoralWallFanBlock(Identifier, Direction.North, true),
            13965 => new BubbleCoralWallFanBlock(Identifier, Direction.North, false),
            13966 => new BubbleCoralWallFanBlock(Identifier, Direction.South, true),
            13967 => new BubbleCoralWallFanBlock(Identifier, Direction.South, false),
            13968 => new BubbleCoralWallFanBlock(Identifier, Direction.West, true),
            13969 => new BubbleCoralWallFanBlock(Identifier, Direction.West, false),
            13970 => new BubbleCoralWallFanBlock(Identifier, Direction.East, true),
            13971 => new BubbleCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
