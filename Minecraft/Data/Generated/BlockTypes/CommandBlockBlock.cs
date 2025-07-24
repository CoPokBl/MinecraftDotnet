using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {

    public Identifier Category => "minecraft:command";
    public int ProtocolId => 376;
    public double Hardness => -1;
    public double ExplosionResistance => 3600000;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:command_block";
    public Identifier? Item => "minecraft:command_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.command_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 8690,
                    Cardinal.East => 8691,
                    Cardinal.South => 8692,
                    Cardinal.West => 8693,
                    Cardinal.Up => 8694,
                    Cardinal.Down => 8695,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 8696,
                    Cardinal.East => 8697,
                    Cardinal.South => 8698,
                    Cardinal.West => 8699,
                    Cardinal.Up => 8700,
                    Cardinal.Down => 8701,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8690 => new CommandBlockBlock(Identifier, true, Cardinal.North),
            8691 => new CommandBlockBlock(Identifier, true, Cardinal.East),
            8692 => new CommandBlockBlock(Identifier, true, Cardinal.South),
            8693 => new CommandBlockBlock(Identifier, true, Cardinal.West),
            8694 => new CommandBlockBlock(Identifier, true, Cardinal.Up),
            8695 => new CommandBlockBlock(Identifier, true, Cardinal.Down),
            8696 => new CommandBlockBlock(Identifier, false, Cardinal.North),
            8697 => new CommandBlockBlock(Identifier, false, Cardinal.East),
            8698 => new CommandBlockBlock(Identifier, false, Cardinal.South),
            8699 => new CommandBlockBlock(Identifier, false, Cardinal.West),
            8700 => new CommandBlockBlock(Identifier, false, Cardinal.Up),
            8701 => new CommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties["conditional"].GetString() == "true",
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
