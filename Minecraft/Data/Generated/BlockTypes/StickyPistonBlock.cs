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
                    Cardinal.North => 2235,
                    Cardinal.East => 2236,
                    Cardinal.South => 2237,
                    Cardinal.West => 2238,
                    Cardinal.Up => 2239,
                    Cardinal.Down => 2240,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2241,
                    Cardinal.East => 2242,
                    Cardinal.South => 2243,
                    Cardinal.West => 2244,
                    Cardinal.Up => 2245,
                    Cardinal.Down => 2246,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2235 => new StickyPistonBlock(Identifier, true, Cardinal.North),
            2236 => new StickyPistonBlock(Identifier, true, Cardinal.East),
            2237 => new StickyPistonBlock(Identifier, true, Cardinal.South),
            2238 => new StickyPistonBlock(Identifier, true, Cardinal.West),
            2239 => new StickyPistonBlock(Identifier, true, Cardinal.Up),
            2240 => new StickyPistonBlock(Identifier, true, Cardinal.Down),
            2241 => new StickyPistonBlock(Identifier, false, Cardinal.North),
            2242 => new StickyPistonBlock(Identifier, false, Cardinal.East),
            2243 => new StickyPistonBlock(Identifier, false, Cardinal.South),
            2244 => new StickyPistonBlock(Identifier, false, Cardinal.West),
            2245 => new StickyPistonBlock(Identifier, false, Cardinal.Up),
            2246 => new StickyPistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Extended = properties.Contains("extended") ? properties["extended"].GetString() == "true" : Extended,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("extended", new StringTag(Extended.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
