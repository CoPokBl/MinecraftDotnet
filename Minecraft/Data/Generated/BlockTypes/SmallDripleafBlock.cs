using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmallDripleafBlock(Identifier Identifier, Direction Facing, BlockHalf Half, bool Waterlogged) : IBlock {

    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "small_dripleaf";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:small_dripleaf";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.125, 0.0, 0.125] -> [0.875, 0.8125, 0.875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.small_dripleaf";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25944,
                        false => 25945,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25946,
                        false => 25947,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25948,
                        false => 25949,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25950,
                        false => 25951,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25952,
                        false => 25953,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25954,
                        false => 25955,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25956,
                        false => 25957,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25958,
                        false => 25959,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25944 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, true),
            25945 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, false),
            25946 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, true),
            25947 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, false),
            25948 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, true),
            25949 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, false),
            25950 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, true),
            25951 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, false),
            25952 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, true),
            25953 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, false),
            25954 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, true),
            25955 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, false),
            25956 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, true),
            25957 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, false),
            25958 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, true),
            25959 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Half = BlockHalfExtensions.FromString(properties["half"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
