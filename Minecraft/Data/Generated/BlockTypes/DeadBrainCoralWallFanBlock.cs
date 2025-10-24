using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DeadBrainCoralWallFanBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:base_coral_wall_fan";
    public int ProtocolId => 777;
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
    public Identifier? Item => "minecraft:dead_brain_coral_fan";
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
    public string TranslationKey => "block.minecraft.dead_brain_coral_wall_fan";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 14993,
                    false => 14994,
                },
                Direction.South => Waterlogged switch {
                    true => 14995,
                    false => 14996,
                },
                Direction.West => Waterlogged switch {
                    true => 14997,
                    false => 14998,
                },
                Direction.East => Waterlogged switch {
                    true => 14999,
                    false => 15000,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14993 => new DeadBrainCoralWallFanBlock(Identifier, Direction.North, true),
            14994 => new DeadBrainCoralWallFanBlock(Identifier, Direction.North, false),
            14995 => new DeadBrainCoralWallFanBlock(Identifier, Direction.South, true),
            14996 => new DeadBrainCoralWallFanBlock(Identifier, Direction.South, false),
            14997 => new DeadBrainCoralWallFanBlock(Identifier, Direction.West, true),
            14998 => new DeadBrainCoralWallFanBlock(Identifier, Direction.West, false),
            14999 => new DeadBrainCoralWallFanBlock(Identifier, Direction.East, true),
            15000 => new DeadBrainCoralWallFanBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
