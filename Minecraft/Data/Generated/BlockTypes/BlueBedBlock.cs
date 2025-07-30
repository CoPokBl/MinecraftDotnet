using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {

    public Identifier Category => "minecraft:bed";
    public int ProtocolId => 121;
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
    public Identifier? Item => "minecraft:blue_bed";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.8125] -> [0.1875, 0.5625, 1.0], AABB[0.8125, 0.0, 0.8125] -> [1.0, 0.5625, 1.0], AABB[0.0, 0.1875, 0.0] -> [1.0, 0.5625, 0.8125], AABB[0.1875, 0.1875, 0.8125] -> [0.8125, 0.5625, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 25;
    public string TranslationKey => "block.minecraft.blue_bed";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1907,
                        BedPart.Foot => 1908,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1909,
                        BedPart.Foot => 1910,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1911,
                        BedPart.Foot => 1912,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1913,
                        BedPart.Foot => 1914,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1915,
                        BedPart.Foot => 1916,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1917,
                        BedPart.Foot => 1918,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1919,
                        BedPart.Foot => 1920,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1921,
                        BedPart.Foot => 1922,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1907 => new BlueBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1908 => new BlueBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1909 => new BlueBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1910 => new BlueBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1911 => new BlueBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1912 => new BlueBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1913 => new BlueBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1914 => new BlueBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1915 => new BlueBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1916 => new BlueBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1917 => new BlueBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1918 => new BlueBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1919 => new BlueBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1920 => new BlueBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1921 => new BlueBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1922 => new BlueBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
