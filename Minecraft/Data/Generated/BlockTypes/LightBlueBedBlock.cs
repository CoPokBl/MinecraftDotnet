using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public Identifier Category => "minecraft:bed";
    public int ProtocolId => 113;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:bed";
    public Identifier? Item => "minecraft:light_blue_bed";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 17;
    public string TranslationKey => "block.minecraft.light_blue_bed";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1779,
                        BedPart.Foot => 1780,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1781,
                        BedPart.Foot => 1782,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1783,
                        BedPart.Foot => 1784,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1785,
                        BedPart.Foot => 1786,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1787,
                        BedPart.Foot => 1788,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1789,
                        BedPart.Foot => 1790,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1791,
                        BedPart.Foot => 1792,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1793,
                        BedPart.Foot => 1794,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1779 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1780 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1781 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1782 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1783 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1784 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1785 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1786 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1787 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1788 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1789 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1790 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1791 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1792 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1793 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1794 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = DirectionExtensions.FromString(properties["facing"].GetString()),
            Occupied = properties["occupied"].GetString() == "true",
            Part = BedPartExtensions.FromString(properties["part"].GetString()),
        };
    }
    
}
