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
                    Cardinal.North => 2257,
                    Cardinal.East => 2258,
                    Cardinal.South => 2259,
                    Cardinal.West => 2260,
                    Cardinal.Up => 2261,
                    Cardinal.Down => 2262,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2263,
                    Cardinal.East => 2264,
                    Cardinal.South => 2265,
                    Cardinal.West => 2266,
                    Cardinal.Up => 2267,
                    Cardinal.Down => 2268,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2257 => new PistonBlock(Identifier, true, Cardinal.North),
            2258 => new PistonBlock(Identifier, true, Cardinal.East),
            2259 => new PistonBlock(Identifier, true, Cardinal.South),
            2260 => new PistonBlock(Identifier, true, Cardinal.West),
            2261 => new PistonBlock(Identifier, true, Cardinal.Up),
            2262 => new PistonBlock(Identifier, true, Cardinal.Down),
            2263 => new PistonBlock(Identifier, false, Cardinal.North),
            2264 => new PistonBlock(Identifier, false, Cardinal.East),
            2265 => new PistonBlock(Identifier, false, Cardinal.South),
            2266 => new PistonBlock(Identifier, false, Cardinal.West),
            2267 => new PistonBlock(Identifier, false, Cardinal.Up),
            2268 => new PistonBlock(Identifier, false, Cardinal.Down),
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
