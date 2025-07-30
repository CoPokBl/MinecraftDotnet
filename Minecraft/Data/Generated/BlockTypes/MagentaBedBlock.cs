using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public Identifier Category => "minecraft:bed";
    public int ProtocolId => 112;
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
    public Identifier? Item => "minecraft:magenta_bed";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 16;
    public string TranslationKey => "block.minecraft.magenta_bed";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1763,
                        BedPart.Foot => 1764,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1765,
                        BedPart.Foot => 1766,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1767,
                        BedPart.Foot => 1768,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1769,
                        BedPart.Foot => 1770,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1771,
                        BedPart.Foot => 1772,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1773,
                        BedPart.Foot => 1774,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1775,
                        BedPart.Foot => 1776,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1777,
                        BedPart.Foot => 1778,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1763 => new MagentaBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1764 => new MagentaBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1765 => new MagentaBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1766 => new MagentaBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1767 => new MagentaBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1768 => new MagentaBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1769 => new MagentaBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1770 => new MagentaBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1771 => new MagentaBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1772 => new MagentaBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1773 => new MagentaBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1774 => new MagentaBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1775 => new MagentaBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1776 => new MagentaBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1777 => new MagentaBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1778 => new MagentaBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("facing", Facing.ToName()),
            new StringTag("occupied", Occupied.ToString().ToLower()),
            new StringTag("part", Part.ToName())
        );
    }
    
}
