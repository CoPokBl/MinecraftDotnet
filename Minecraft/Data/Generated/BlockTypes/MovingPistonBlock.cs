using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MovingPistonBlock(Identifier Identifier, MovingPistonBlock.Type TypeValue, Cardinal Facing) : IBlock {

    public Identifier Category => "minecraft:moving_piston";
    public double Hardness => -1;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:piston";
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.moving_piston";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Normal => Facing switch {
                    Cardinal.North => 2109,
                    Cardinal.East => 2111,
                    Cardinal.South => 2113,
                    Cardinal.West => 2115,
                    Cardinal.Up => 2117,
                    Cardinal.Down => 2119,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => 2110,
                    Cardinal.East => 2112,
                    Cardinal.South => 2114,
                    Cardinal.West => 2116,
                    Cardinal.Up => 2118,
                    Cardinal.Down => 2120,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2109 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.North),
            2110 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.North),
            2111 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.East),
            2112 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.East),
            2113 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.South),
            2114 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.South),
            2115 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.West),
            2116 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.West),
            2117 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Up),
            2118 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Up),
            2119 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Down),
            2120 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = TypeFromString(properties["type"].GetString()),
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
        };
    }
    
    public enum Type {
        Normal,
        Sticky,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "normal" => Type.Normal,
            "sticky" => Type.Sticky,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }
}
