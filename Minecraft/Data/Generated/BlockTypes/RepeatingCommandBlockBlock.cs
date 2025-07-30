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
    public int ProtocolId => 636;
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
                    Cardinal.North => 13538,
                    Cardinal.East => 13539,
                    Cardinal.South => 13540,
                    Cardinal.West => 13541,
                    Cardinal.Up => 13542,
                    Cardinal.Down => 13543,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 13544,
                    Cardinal.East => 13545,
                    Cardinal.South => 13546,
                    Cardinal.West => 13547,
                    Cardinal.Up => 13548,
                    Cardinal.Down => 13549,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13538 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.North),
            13539 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.East),
            13540 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.South),
            13541 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.West),
            13542 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Up),
            13543 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Down),
            13544 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.North),
            13545 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.East),
            13546 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.South),
            13547 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.West),
            13548 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Up),
            13549 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties["conditional"].GetString() == "true",
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("conditional", Conditional.ToString().ToLower()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
