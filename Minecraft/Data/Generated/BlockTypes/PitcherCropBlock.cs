using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PitcherCropBlock(Identifier Identifier, int Age, BlockHalf Half) : IBlock {
    public Identifier Category => "minecraft:pitcher_crop";
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
    public string SoundType => "crop";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pitcher_pod";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, -0.0625, 0.3125] -> [0.6875, 0.1875, 0.6875]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, -0.0625, 0.3125] -> [0.6875, 0.1875, 0.6875]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, -0.0625, 0.3125] -> [0.6875, 0.1875, 0.6875]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.pitcher_crop";
    public bool CanRespawnIn => true;


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
