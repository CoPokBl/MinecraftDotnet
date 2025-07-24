using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ObserverBlock(Identifier Identifier, Cardinal Facing, bool Powered) : IBlock {

    public Identifier Category => "minecraft:observer";
    public int ProtocolId => 644;
    public double Hardness => 3;
    public double ExplosionResistance => 3;
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
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:observer";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.observer";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => 13573,
                    false => 13574,
                },
                Cardinal.East => Powered switch {
                    true => 13575,
                    false => 13576,
                },
                Cardinal.South => Powered switch {
                    true => 13577,
                    false => 13578,
                },
                Cardinal.West => Powered switch {
                    true => 13579,
                    false => 13580,
                },
                Cardinal.Up => Powered switch {
                    true => 13581,
                    false => 13582,
                },
                Cardinal.Down => Powered switch {
                    true => 13583,
                    false => 13584,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13573 => new ObserverBlock(Identifier, Cardinal.North, true),
            13574 => new ObserverBlock(Identifier, Cardinal.North, false),
            13575 => new ObserverBlock(Identifier, Cardinal.East, true),
            13576 => new ObserverBlock(Identifier, Cardinal.East, false),
            13577 => new ObserverBlock(Identifier, Cardinal.South, true),
            13578 => new ObserverBlock(Identifier, Cardinal.South, false),
            13579 => new ObserverBlock(Identifier, Cardinal.West, true),
            13580 => new ObserverBlock(Identifier, Cardinal.West, false),
            13581 => new ObserverBlock(Identifier, Cardinal.Up, true),
            13582 => new ObserverBlock(Identifier, Cardinal.Up, false),
            13583 => new ObserverBlock(Identifier, Cardinal.Down, true),
            13584 => new ObserverBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = CardinalExtensions.FromString(properties["facing"].GetString()),
            Powered = properties["powered"].GetString() == "true",
        };
    }
    
}
