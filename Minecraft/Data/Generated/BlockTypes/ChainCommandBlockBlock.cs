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
    public int ProtocolId => 637;
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
                    Cardinal.North => 13550,
                    Cardinal.East => 13551,
                    Cardinal.South => 13552,
                    Cardinal.West => 13553,
                    Cardinal.Up => 13554,
                    Cardinal.Down => 13555,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 13556,
                    Cardinal.East => 13557,
                    Cardinal.South => 13558,
                    Cardinal.West => 13559,
                    Cardinal.Up => 13560,
                    Cardinal.Down => 13561,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13550 => new ChainCommandBlockBlock(Identifier, true, Cardinal.North),
            13551 => new ChainCommandBlockBlock(Identifier, true, Cardinal.East),
            13552 => new ChainCommandBlockBlock(Identifier, true, Cardinal.South),
            13553 => new ChainCommandBlockBlock(Identifier, true, Cardinal.West),
            13554 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Up),
            13555 => new ChainCommandBlockBlock(Identifier, true, Cardinal.Down),
            13556 => new ChainCommandBlockBlock(Identifier, false, Cardinal.North),
            13557 => new ChainCommandBlockBlock(Identifier, false, Cardinal.East),
            13558 => new ChainCommandBlockBlock(Identifier, false, Cardinal.South),
            13559 => new ChainCommandBlockBlock(Identifier, false, Cardinal.West),
            13560 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Up),
            13561 => new ChainCommandBlockBlock(Identifier, false, Cardinal.Down),
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
