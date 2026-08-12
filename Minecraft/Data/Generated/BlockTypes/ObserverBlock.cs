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
                    true => 14852,
                    false => 14853,
                },
                Cardinal.East => Powered switch {
                    true => 14854,
                    false => 14855,
                },
                Cardinal.South => Powered switch {
                    true => 14856,
                    false => 14857,
                },
                Cardinal.West => Powered switch {
                    true => 14858,
                    false => 14859,
                },
                Cardinal.Up => Powered switch {
                    true => 14860,
                    false => 14861,
                },
                Cardinal.Down => Powered switch {
                    true => 14862,
                    false => 14863,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14852 => new ObserverBlock(Identifier, Cardinal.North, true),
            14853 => new ObserverBlock(Identifier, Cardinal.North, false),
            14854 => new ObserverBlock(Identifier, Cardinal.East, true),
            14855 => new ObserverBlock(Identifier, Cardinal.East, false),
            14856 => new ObserverBlock(Identifier, Cardinal.South, true),
            14857 => new ObserverBlock(Identifier, Cardinal.South, false),
            14858 => new ObserverBlock(Identifier, Cardinal.West, true),
            14859 => new ObserverBlock(Identifier, Cardinal.West, false),
            14860 => new ObserverBlock(Identifier, Cardinal.Up, true),
            14861 => new ObserverBlock(Identifier, Cardinal.Up, false),
            14862 => new ObserverBlock(Identifier, Cardinal.Down, true),
            14863 => new ObserverBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
