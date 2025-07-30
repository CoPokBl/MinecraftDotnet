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

    public Identifier Category => "minecraft:small_dripleaf";
    public int ProtocolId => 1056;
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
                        true => 25976,
                        false => 25977,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25978,
                        false => 25979,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25980,
                        false => 25981,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25982,
                        false => 25983,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25984,
                        false => 25985,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25986,
                        false => 25987,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 25988,
                        false => 25989,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 25990,
                        false => 25991,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25976 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, true),
            25977 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, false),
            25978 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, true),
            25979 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, false),
            25980 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, true),
            25981 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, false),
            25982 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, true),
            25983 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, false),
            25984 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, true),
            25985 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, false),
            25986 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, true),
            25987 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, false),
            25988 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, true),
            25989 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, false),
            25990 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, true),
            25991 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("half", Half.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
