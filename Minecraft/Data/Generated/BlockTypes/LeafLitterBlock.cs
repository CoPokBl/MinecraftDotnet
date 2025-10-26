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
    public int ProtocolId => 1113;
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
                    1 => 27644,
                    2 => 27645,
                    3 => 27646,
                    4 => 27647,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.South => SegmentAmount switch {
                    1 => 27648,
                    2 => 27649,
                    3 => 27650,
                    4 => 27651,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.West => SegmentAmount switch {
                    1 => 27652,
                    2 => 27653,
                    3 => 27654,
                    4 => 27655,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                Direction.East => SegmentAmount switch {
                    1 => 27656,
                    2 => 27657,
                    3 => 27658,
                    4 => 27659,
                    _ => throw new ArgumentOutOfRangeException(nameof(SegmentAmount), SegmentAmount, "Unknown value for property segment_amount.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27644 => new LeafLitterBlock(Identifier, Direction.North, 1),
            27645 => new LeafLitterBlock(Identifier, Direction.North, 2),
            27646 => new LeafLitterBlock(Identifier, Direction.North, 3),
            27647 => new LeafLitterBlock(Identifier, Direction.North, 4),
            27648 => new LeafLitterBlock(Identifier, Direction.South, 1),
            27649 => new LeafLitterBlock(Identifier, Direction.South, 2),
            27650 => new LeafLitterBlock(Identifier, Direction.South, 3),
            27651 => new LeafLitterBlock(Identifier, Direction.South, 4),
            27652 => new LeafLitterBlock(Identifier, Direction.West, 1),
            27653 => new LeafLitterBlock(Identifier, Direction.West, 2),
            27654 => new LeafLitterBlock(Identifier, Direction.West, 3),
            27655 => new LeafLitterBlock(Identifier, Direction.West, 4),
            27656 => new LeafLitterBlock(Identifier, Direction.East, 1),
            27657 => new LeafLitterBlock(Identifier, Direction.East, 2),
            27658 => new LeafLitterBlock(Identifier, Direction.East, 3),
            27659 => new LeafLitterBlock(Identifier, Direction.East, 4),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.ChildrenMap.ContainsKey("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            SegmentAmount = properties.ChildrenMap.ContainsKey("segment_amount") ? int.Parse(properties["segment_amount"].GetString()) : SegmentAmount,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("segment_amount", SegmentAmount.ToString())
        );
    }
    
}
