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
    public int ProtocolId => 674;
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
                    true => 14650,
                    false => 14651,
                },
                Cardinal.East => Powered switch {
                    true => 14652,
                    false => 14653,
                },
                Cardinal.South => Powered switch {
                    true => 14654,
                    false => 14655,
                },
                Cardinal.West => Powered switch {
                    true => 14656,
                    false => 14657,
                },
                Cardinal.Up => Powered switch {
                    true => 14658,
                    false => 14659,
                },
                Cardinal.Down => Powered switch {
                    true => 14660,
                    false => 14661,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14650 => new ObserverBlock(Identifier, Cardinal.North, true),
            14651 => new ObserverBlock(Identifier, Cardinal.North, false),
            14652 => new ObserverBlock(Identifier, Cardinal.East, true),
            14653 => new ObserverBlock(Identifier, Cardinal.East, false),
            14654 => new ObserverBlock(Identifier, Cardinal.South, true),
            14655 => new ObserverBlock(Identifier, Cardinal.South, false),
            14656 => new ObserverBlock(Identifier, Cardinal.West, true),
            14657 => new ObserverBlock(Identifier, Cardinal.West, false),
            14658 => new ObserverBlock(Identifier, Cardinal.Up, true),
            14659 => new ObserverBlock(Identifier, Cardinal.Up, false),
            14660 => new ObserverBlock(Identifier, Cardinal.Down, true),
            14661 => new ObserverBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("powered", Powered.ToString().ToLower())
        );
    }
    
}
