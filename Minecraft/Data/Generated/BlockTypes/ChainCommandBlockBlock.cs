using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ChainCommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock {
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
    public Identifier? Item => "minecraft:chain_command_block";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 27;
    public string TranslationKey => "block.minecraft.chain_command_block";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 14829,
                    Cardinal.East => 14830,
                    Cardinal.South => 14831,
                    Cardinal.West => 14832,
                    Cardinal.Up => 14833,
                    Cardinal.Down => 14834,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 14835,
                    Cardinal.East => 14836,
                    Cardinal.South => 14837,
                    Cardinal.West => 14838,
                    Cardinal.Up => 14839,
                    Cardinal.Down => 14840,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14829 => new ChainCommandBlockBlock(Identifier, true, Cardinal.North),
            14830 => new ChainCommandBlockBlock(Identifier, true, Cardinal.East),
            14831 => new ChainCommandBlockBlock(Identifier, true, Cardinal.South),
            14832 => new ChainCommandBlockBlock(Identifier, true, Cardinal.West),
            14833 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Up),
            14834 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Down),
            14835 => new ChainCommandBlockBlock(Identifier, false, Cardinal.North),
            14836 => new ChainCommandBlockBlock(Identifier, false, Cardinal.East),
            14837 => new ChainCommandBlockBlock(Identifier, false, Cardinal.South),
            14838 => new ChainCommandBlockBlock(Identifier, false, Cardinal.West),
            14839 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Up),
            14840 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Down),
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
