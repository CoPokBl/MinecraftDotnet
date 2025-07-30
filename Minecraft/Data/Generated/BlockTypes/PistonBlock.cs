using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PistonBlock(Identifier Identifier, bool Extended, Cardinal Facing) : IBlock {

    public Identifier Category => "minecraft:piston_base";
    public int ProtocolId => 138;
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:piston";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.piston";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2057,
                    Cardinal.East => 2058,
                    Cardinal.South => 2059,
                    Cardinal.West => 2060,
                    Cardinal.Up => 2061,
                    Cardinal.Down => 2062,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2063,
                    Cardinal.East => 2064,
                    Cardinal.South => 2065,
                    Cardinal.West => 2066,
                    Cardinal.Up => 2067,
                    Cardinal.Down => 2068,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2057 => new PistonBlock(Identifier, true, Cardinal.North),
            2058 => new PistonBlock(Identifier, true, Cardinal.East),
            2059 => new PistonBlock(Identifier, true, Cardinal.South),
            2060 => new PistonBlock(Identifier, true, Cardinal.West),
            2061 => new PistonBlock(Identifier, true, Cardinal.Up),
            2062 => new PistonBlock(Identifier, true, Cardinal.Down),
            2063 => new PistonBlock(Identifier, false, Cardinal.North),
            2064 => new PistonBlock(Identifier, false, Cardinal.East),
            2065 => new PistonBlock(Identifier, false, Cardinal.South),
            2066 => new PistonBlock(Identifier, false, Cardinal.West),
            2067 => new PistonBlock(Identifier, false, Cardinal.Up),
            2068 => new PistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Extended = properties["extended"].GetString() == "true",
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("extended", Extended.ToString().ToLower()),
            new StringTag("facing", Facing.ToName())
        );
    }
    
}
