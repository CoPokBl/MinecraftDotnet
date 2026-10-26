using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SmallDripleafBlock(Identifier Identifier, Direction Facing, BlockHalf Half, bool Waterlogged) : IBlock, IHorizontalFacing, IDoubleHalved, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.small_dripleaf", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.Xyz, 0.25f, 0.1f, null, "minecraft:small_dripleaf", BlockInfo.VanillaOnly, "minecraft:blocks/small_dripleaf");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 7, "small_dripleaf", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S521, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 33753];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
    public int LightEmission => StateInfo.LightEmission;
    public int LightDampening => StateInfo.LightDampening;
    public bool Replaceable => StateInfo.Replaceable;
    public string SoundType => StateInfo.SoundType;
    public ICollisionBox BlockShape => StateInfo.BlockShape;
    public ICollisionBox CollisionShape => StateInfo.CollisionShape;
    public ICollisionBox OcclusionShape => StateInfo.OcclusionShape;
    public ICollisionBox InteractionShape => StateInfo.InteractionShape;
    public ICollisionBox VisualShape => StateInfo.VisualShape;
    public ICollisionBox SupportShape => StateInfo.SupportShape;
    public bool RedstoneConductor => StateInfo.RedstoneConductor;
    public bool SignalSource => StateInfo.SignalSource;
    public bool Flammable => StateInfo.Flammable;
    public PushReaction PushReaction => StateInfo.PushReaction;
    public int MapColorId => StateInfo.MapColorId;
    public bool CanRespawnIn => StateInfo.CanRespawnIn;
    public bool RandomlyTicking => StateInfo.RandomlyTicking;
    public bool Suffocating => StateInfo.Suffocating;
    public bool ViewBlocking => StateInfo.ViewBlocking;
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithHalf(BlockHalf half) => this with { Half = half };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 33753,
                        false => 33754,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 33755,
                        false => 33756,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.South => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 33757,
                        false => 33758,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 33759,
                        false => 33760,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.West => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 33761,
                        false => 33762,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 33763,
                        false => 33764,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                Direction.East => Half switch {
                    BlockHalf.Upper => Waterlogged switch {
                        true => 33765,
                        false => 33766,
                    },
                    BlockHalf.Lower => Waterlogged switch {
                        true => 33767,
                        false => 33768,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33753 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, true),
            33754 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Upper, false),
            33755 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, true),
            33756 => new SmallDripleafBlock(Identifier, Direction.North, BlockHalf.Lower, false),
            33757 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, true),
            33758 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Upper, false),
            33759 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, true),
            33760 => new SmallDripleafBlock(Identifier, Direction.South, BlockHalf.Lower, false),
            33761 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, true),
            33762 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Upper, false),
            33763 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, true),
            33764 => new SmallDripleafBlock(Identifier, Direction.West, BlockHalf.Lower, false),
            33765 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, true),
            33766 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Upper, false),
            33767 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, true),
            33768 => new SmallDripleafBlock(Identifier, Direction.East, BlockHalf.Lower, false),
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
