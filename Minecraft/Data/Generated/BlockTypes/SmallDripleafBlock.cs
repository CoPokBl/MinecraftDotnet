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
                        true => 30396,
                        false => 30397,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 30398,
                        false => 30399,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 30400,
                        false => 30401,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 30402,
                        false => 30403,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 30404,
                        false => 30405,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 30406,
                        false => 30407,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 30408,
                        false => 30409,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 30410,
                        false => 30411,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30396 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, true),
            30397 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, false),
            30398 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, true),
            30399 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, false),
            30400 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, true),
            30401 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, false),
            30402 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, true),
            30403 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, false),
            30404 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, true),
            30405 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, false),
            30406 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, true),
            30407 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, false),
            30408 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, true),
            30409 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, false),
            30410 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, true),
            30411 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("half", new StringTag(Half.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
