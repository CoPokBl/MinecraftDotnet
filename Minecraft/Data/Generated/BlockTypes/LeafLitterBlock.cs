using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LeafLitterBlock(Identifier Identifier, Direction Facing, int SegmentAmount) : IBlock {

    public Identifier Category => "minecraft:leaf_litter";
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
    public bool Replaceable => true;
    public string SoundType => "leaf_litter";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:leaf_litter";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.5, 0.0625, 0.5]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.leaf_litter";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => SegmentAmount switch {
                    1 => 25919,
                    2 => 25920,
                    3 => 25921,
                    4 => 25922,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 25923,
                    2 => 25924,
                    3 => 25925,
                    4 => 25926,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 25927,
                    2 => 25928,
                    3 => 25929,
                    4 => 25930,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 25931,
                    2 => 25932,
                    3 => 25933,
                    4 => 25934,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25919 => new LeafLitterBlock(Identifier, Direction.North, 1),
            25920 => new LeafLitterBlock(Identifier, Direction.North, 2),
            25921 => new LeafLitterBlock(Identifier, Direction.North, 3),
            25922 => new LeafLitterBlock(Identifier, Direction.North, 4),
            25923 => new LeafLitterBlock(Identifier, Direction.South, 1),
            25924 => new LeafLitterBlock(Identifier, Direction.South, 2),
            25925 => new LeafLitterBlock(Identifier, Direction.South, 3),
            25926 => new LeafLitterBlock(Identifier, Direction.South, 4),
            25927 => new LeafLitterBlock(Identifier, Direction.West, 1),
            25928 => new LeafLitterBlock(Identifier, Direction.West, 2),
            25929 => new LeafLitterBlock(Identifier, Direction.West, 3),
            25930 => new LeafLitterBlock(Identifier, Direction.West, 4),
            25931 => new LeafLitterBlock(Identifier, Direction.East, 1),
            25932 => new LeafLitterBlock(Identifier, Direction.East, 2),
            25933 => new LeafLitterBlock(Identifier, Direction.East, 3),
            25934 => new LeafLitterBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            SegmentAmount = int.Parse(properties["segment_amount"].GetString()),
        };
    }
    
}
