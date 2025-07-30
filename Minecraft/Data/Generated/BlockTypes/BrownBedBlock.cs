using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public Identifier Category => "minecraft:bed";
    public int ProtocolId => 122;
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
    public Identifier? Item => "minecraft:brown_bed";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.brown_bed";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1923,
                        BedPart.Foot => 1924,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1925,
                        BedPart.Foot => 1926,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1927,
                        BedPart.Foot => 1928,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1929,
                        BedPart.Foot => 1930,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1931,
                        BedPart.Foot => 1932,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1933,
                        BedPart.Foot => 1934,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1935,
                        BedPart.Foot => 1936,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1937,
                        BedPart.Foot => 1938,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1923 => new BrownBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1924 => new BrownBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1925 => new BrownBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1926 => new BrownBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1927 => new BrownBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1928 => new BrownBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1929 => new BrownBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1930 => new BrownBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1931 => new BrownBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1932 => new BrownBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1933 => new BrownBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1934 => new BrownBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1935 => new BrownBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1936 => new BrownBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1937 => new BrownBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1938 => new BrownBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
