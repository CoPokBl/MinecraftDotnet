using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RepeatingCommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {
    public Identifier Category => "minecraft:command";
    public int ProtocolId => 666;
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
    public Identifier? Item => "minecraft:repeating_command_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.repeating_command_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 14615,
                    Cardinal.East => 14616,
                    Cardinal.South => 14617,
                    Cardinal.West => 14618,
                    Cardinal.Up => 14619,
                    Cardinal.Down => 14620,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 14621,
                    Cardinal.East => 14622,
                    Cardinal.South => 14623,
                    Cardinal.West => 14624,
                    Cardinal.Up => 14625,
                    Cardinal.Down => 14626,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14615 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.North),
            14616 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.East),
            14617 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.South),
            14618 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.West),
            14619 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Up),
            14620 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Down),
            14621 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.North),
            14622 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.East),
            14623 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.South),
            14624 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.West),
            14625 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Up),
            14626 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Down),
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
