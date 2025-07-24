using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record StickyPistonBlock(Identifier Identifier, bool Extended, Cardinal Facing) : IBlock {

    public Identifier Category => "minecraft:piston_base";
    public int ProtocolId => 128;
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
    public Identifier? Item => "minecraft:sticky_piston";
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
    public string TranslationKey => "block.minecraft.sticky_piston";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2035,
                    Cardinal.East => 2036,
                    Cardinal.South => 2037,
                    Cardinal.West => 2038,
                    Cardinal.Up => 2039,
                    Cardinal.Down => 2040,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2041,
                    Cardinal.East => 2042,
                    Cardinal.South => 2043,
                    Cardinal.West => 2044,
                    Cardinal.Up => 2045,
                    Cardinal.Down => 2046,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2035 => new StickyPistonBlock(Identifier, true, Cardinal.North),
            2036 => new StickyPistonBlock(Identifier, true, Cardinal.East),
            2037 => new StickyPistonBlock(Identifier, true, Cardinal.South),
            2038 => new StickyPistonBlock(Identifier, true, Cardinal.West),
            2039 => new StickyPistonBlock(Identifier, true, Cardinal.Up),
            2040 => new StickyPistonBlock(Identifier, true, Cardinal.Down),
            2041 => new StickyPistonBlock(Identifier, false, Cardinal.North),
            2042 => new StickyPistonBlock(Identifier, false, Cardinal.East),
            2043 => new StickyPistonBlock(Identifier, false, Cardinal.South),
            2044 => new StickyPistonBlock(Identifier, false, Cardinal.West),
            2045 => new StickyPistonBlock(Identifier, false, Cardinal.Up),
            2046 => new StickyPistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Extended = properties["extended"].GetString() == "true",
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
}
