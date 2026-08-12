using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmokerBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock {
    public Identifier Category => "minecraft:smoker";
    public double Hardness => 3.5;
    public double ExplosionResistance => 3.5;
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
    public Identifier? BlockEntity => "minecraft:smoker";
    public Identifier? Item => "minecraft:smoker";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => true;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.smoker";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 20754,
                    false => 20755,
                },
                Direction.South => Lit switch {
                    true => 20756,
                    false => 20757,
                },
                Direction.West => Lit switch {
                    true => 20758,
                    false => 20759,
                },
                Direction.East => Lit switch {
                    true => 20760,
                    false => 20761,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20754 => new SmokerBlock(Identifier, Direction.North, true),
            20755 => new SmokerBlock(Identifier, Direction.North, false),
            20756 => new SmokerBlock(Identifier, Direction.South, true),
            20757 => new SmokerBlock(Identifier, Direction.South, false),
            20758 => new SmokerBlock(Identifier, Direction.West, true),
            20759 => new SmokerBlock(Identifier, Direction.West, false),
            20760 => new SmokerBlock(Identifier, Direction.East, true),
            20761 => new SmokerBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("lit", new StringTag(Lit.ToString().ToLower()))
        );
    }
    
}
