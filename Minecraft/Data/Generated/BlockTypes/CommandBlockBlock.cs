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
    public int ProtocolId => 406;
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
                    Cardinal.North => 9767,
                    Cardinal.East => 9768,
                    Cardinal.South => 9769,
                    Cardinal.West => 9770,
                    Cardinal.Up => 9771,
                    Cardinal.Down => 9772,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 9773,
                    Cardinal.East => 9774,
                    Cardinal.South => 9775,
                    Cardinal.West => 9776,
                    Cardinal.Up => 9777,
                    Cardinal.Down => 9778,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9767 => new CommandBlockBlock(Identifier, true, Cardinal.North),
            9768 => new CommandBlockBlock(Identifier, true, Cardinal.East),
            9769 => new CommandBlockBlock(Identifier, true, Cardinal.South),
            9770 => new CommandBlockBlock(Identifier, true, Cardinal.West),
            9771 => new CommandBlockBlock(Identifier, true, Cardinal.Up),
            9772 => new CommandBlockBlock(Identifier, true, Cardinal.Down),
            9773 => new CommandBlockBlock(Identifier, false, Cardinal.North),
            9774 => new CommandBlockBlock(Identifier, false, Cardinal.East),
            9775 => new CommandBlockBlock(Identifier, false, Cardinal.South),
            9776 => new CommandBlockBlock(Identifier, false, Cardinal.West),
            9777 => new CommandBlockBlock(Identifier, false, Cardinal.Up),
            9778 => new CommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties.ChildrenMap.ContainsKey("conditional") ? properties["conditional"].GetString() == "true" : Conditional,
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("conditional", Conditional.ToString().ToLower()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
