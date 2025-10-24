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
    public int ProtocolId => 667;
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
                    Cardinal.North => 14627,
                    Cardinal.East => 14628,
                    Cardinal.South => 14629,
                    Cardinal.West => 14630,
                    Cardinal.Up => 14631,
                    Cardinal.Down => 14632,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 14633,
                    Cardinal.East => 14634,
                    Cardinal.South => 14635,
                    Cardinal.West => 14636,
                    Cardinal.Up => 14637,
                    Cardinal.Down => 14638,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14627 => new ChainCommandBlockBlock(Identifier, true, Cardinal.North),
            14628 => new ChainCommandBlockBlock(Identifier, true, Cardinal.East),
            14629 => new ChainCommandBlockBlock(Identifier, true, Cardinal.South),
            14630 => new ChainCommandBlockBlock(Identifier, true, Cardinal.West),
            14631 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Up),
            14632 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Down),
            14633 => new ChainCommandBlockBlock(Identifier, false, Cardinal.North),
            14634 => new ChainCommandBlockBlock(Identifier, false, Cardinal.East),
            14635 => new ChainCommandBlockBlock(Identifier, false, Cardinal.South),
            14636 => new ChainCommandBlockBlock(Identifier, false, Cardinal.West),
            14637 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Up),
            14638 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Down),
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
