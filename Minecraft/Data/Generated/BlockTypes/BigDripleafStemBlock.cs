using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BigDripleafStemBlock(Identifier Identifier, Direction Facing, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:big_dripleaf_stem";
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "big_dripleaf";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:big_dripleaf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.5625] -> [0.6875, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.big_dripleaf_stem";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Waterlogged switch {
                    true => 25936,
                    false => 25937,
                },
                Direction.South => Waterlogged switch {
                    true => 25938,
                    false => 25939,
                },
                Direction.West => Waterlogged switch {
                    true => 25940,
                    false => 25941,
                },
                Direction.East => Waterlogged switch {
                    true => 25942,
                    false => 25943,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25936 => new BigDripleafStemBlock(Identifier, Direction.North, true),
            25937 => new BigDripleafStemBlock(Identifier, Direction.North, false),
            25938 => new BigDripleafStemBlock(Identifier, Direction.South, true),
            25939 => new BigDripleafStemBlock(Identifier, Direction.South, false),
            25940 => new BigDripleafStemBlock(Identifier, Direction.West, true),
            25941 => new BigDripleafStemBlock(Identifier, Direction.West, false),
            25942 => new BigDripleafStemBlock(Identifier, Direction.East, true),
            25943 => new BigDripleafStemBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
