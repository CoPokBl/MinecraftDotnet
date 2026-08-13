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
public record PitcherCropBlock(Identifier Identifier, int Age, BlockHalf Half) : IBlock, IDoubleHalved {
    private static readonly BlockInfo Data = new("minecraft:pitcher_crop", "block.minecraft.pitcher_crop", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pitcher_pod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 7, "crop", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = true, BlockShape = BlockShapes.S819, CollisionShape = BlockShapes.S819, VisualShape = BlockShapes.S819, SupportShape = BlockShapes.S819 };
    private static readonly BlockStateInfo I2 = I0 with { RandomlyTicking = true, BlockShape = BlockShapes.S820, CollisionShape = BlockShapes.S821, VisualShape = BlockShapes.S821, SupportShape = BlockShapes.S821 };
    private static readonly BlockStateInfo I3 = I0 with { RandomlyTicking = true, BlockShape = BlockShapes.S822, CollisionShape = BlockShapes.S821, VisualShape = BlockShapes.S821, SupportShape = BlockShapes.S821 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S823 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S824 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S822, CollisionShape = BlockShapes.S821, VisualShape = BlockShapes.S821, SupportShape = BlockShapes.S821 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I2, I0, I3, I4, I3, I5, I6
    ];

    public BlockStateInfo StateInfo => States[StateId - 14799];

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

    public IBlock WithHalf(BlockHalf half) => this with { Half = half };


    public uint StateId {
        get {
            return Age switch {
                0 => Half switch {
                    BlockHalf.Upper => 14799,
                    BlockHalf.Lower => 14800,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                1 => Half switch {
                    BlockHalf.Upper => 14801,
                    BlockHalf.Lower => 14802,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                2 => Half switch {
                    BlockHalf.Upper => 14803,
                    BlockHalf.Lower => 14804,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                3 => Half switch {
                    BlockHalf.Upper => 14805,
                    BlockHalf.Lower => 14806,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                4 => Half switch {
                    BlockHalf.Upper => 14807,
                    BlockHalf.Lower => 14808,
                    _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14799 => new PitcherCropBlock(Identifier, 0, BlockHalf.Upper),
            14800 => new PitcherCropBlock(Identifier, 0, BlockHalf.Lower),
            14801 => new PitcherCropBlock(Identifier, 1, BlockHalf.Upper),
            14802 => new PitcherCropBlock(Identifier, 1, BlockHalf.Lower),
            14803 => new PitcherCropBlock(Identifier, 2, BlockHalf.Upper),
            14804 => new PitcherCropBlock(Identifier, 2, BlockHalf.Lower),
            14805 => new PitcherCropBlock(Identifier, 3, BlockHalf.Upper),
            14806 => new PitcherCropBlock(Identifier, 3, BlockHalf.Lower),
            14807 => new PitcherCropBlock(Identifier, 4, BlockHalf.Upper),
            14808 => new PitcherCropBlock(Identifier, 4, BlockHalf.Lower),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            Half = properties.Contains("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("half", new StringTag(Half.ToName()))
        );
    }
    
}
