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
    private static readonly BlockInfo Data = new("minecraft:small_dripleaf", "block.minecraft.small_dripleaf", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.Xyz, 0.25f, 0.1f, null, "minecraft:small_dripleaf", BlockInfo.VanillaOnly, "minecraft:blocks/small_dripleaf");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 7, "small_dripleaf", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S521, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 30396];

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
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
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
