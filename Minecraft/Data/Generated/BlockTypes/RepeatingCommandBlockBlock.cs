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
                    Cardinal.North => 14817,
                    Cardinal.East => 14818,
                    Cardinal.South => 14819,
                    Cardinal.West => 14820,
                    Cardinal.Up => 14821,
                    Cardinal.Down => 14822,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 14823,
                    Cardinal.East => 14824,
                    Cardinal.South => 14825,
                    Cardinal.West => 14826,
                    Cardinal.Up => 14827,
                    Cardinal.Down => 14828,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14817 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.North),
            14818 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.East),
            14819 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.South),
            14820 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.West),
            14821 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Up),
            14822 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Down),
            14823 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.North),
            14824 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.East),
            14825 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.South),
            14826 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.West),
            14827 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Up),
            14828 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties.Contains("conditional") ? properties["conditional"].GetString() == "true" : Conditional,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("conditional", new StringTag(Conditional.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
