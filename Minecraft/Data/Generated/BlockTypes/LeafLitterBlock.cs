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
                    1 => 30339,
                    2 => 30340,
                    3 => 30341,
                    4 => 30342,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 30343,
                    2 => 30344,
                    3 => 30345,
                    4 => 30346,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 30347,
                    2 => 30348,
                    3 => 30349,
                    4 => 30350,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 30351,
                    2 => 30352,
                    3 => 30353,
                    4 => 30354,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30339 => new LeafLitterBlock(Identifier, Direction.North, 1),
            30340 => new LeafLitterBlock(Identifier, Direction.North, 2),
            30341 => new LeafLitterBlock(Identifier, Direction.North, 3),
            30342 => new LeafLitterBlock(Identifier, Direction.North, 4),
            30343 => new LeafLitterBlock(Identifier, Direction.South, 1),
            30344 => new LeafLitterBlock(Identifier, Direction.South, 2),
            30345 => new LeafLitterBlock(Identifier, Direction.South, 3),
            30346 => new LeafLitterBlock(Identifier, Direction.South, 4),
            30347 => new LeafLitterBlock(Identifier, Direction.West, 1),
            30348 => new LeafLitterBlock(Identifier, Direction.West, 2),
            30349 => new LeafLitterBlock(Identifier, Direction.West, 3),
            30350 => new LeafLitterBlock(Identifier, Direction.West, 4),
            30351 => new LeafLitterBlock(Identifier, Direction.East, 1),
            30352 => new LeafLitterBlock(Identifier, Direction.East, 2),
            30353 => new LeafLitterBlock(Identifier, Direction.East, 3),
            30354 => new LeafLitterBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            SegmentAmount = properties.Contains("segment_amount") ? int.Parse(properties["segment_amount"].GetString()) : SegmentAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("segment_amount", new StringTag(SegmentAmount.ToString()))
        );
    }
    
}
