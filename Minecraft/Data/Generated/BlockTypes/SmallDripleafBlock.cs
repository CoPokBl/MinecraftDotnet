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
    public int ProtocolId => 1117;
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
                        true => 27701,
                        false => 27702,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 27703,
                        false => 27704,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 27705,
                        false => 27706,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 27707,
                        false => 27708,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 27709,
                        false => 27710,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 27711,
                        false => 27712,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 27713,
                        false => 27714,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 27715,
                        false => 27716,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27701 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, true),
            27702 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, false),
            27703 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, true),
            27704 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, false),
            27705 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, true),
            27706 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, false),
            27707 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, true),
            27708 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, false),
            27709 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, true),
            27710 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, false),
            27711 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, true),
            27712 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, false),
            27713 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, true),
            27714 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, false),
            27715 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, true),
            27716 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.ChildrenMap.ContainsKey("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
