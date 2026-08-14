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
public record LightBlueBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock, IHorizontalFacing, IOccupied, IBedParted {
    private static readonly BlockInfo Data = new("minecraft:bed", "block.minecraft.light_blue_bed", 0.2f, 0.6f, 1f, 1f, 0.75f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:light_blue_bed", BlockInfo.VanillaOnly, "minecraft:blocks/light_blue_bed");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Destroy, 3, "wood", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S362, BlockShapes.S362, BlockShapes.S1, BlockShapes.S1, BlockShapes.S362, BlockShapes.S362);
    private static readonly BlockStateInfo I1 = I0 with { MapColorId = 17, BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I3 = I0 with { MapColorId = 17 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo I5 = I0 with { MapColorId = 17, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I7 = I0 with { MapColorId = 17, BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 1979];

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

    public IBlock WithOccupied(bool occupied) => this with { Occupied = occupied };

    public IBlock WithPart(BedPart part) => this with { Part = part };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1979,
                        BedPart.Foot => 1980,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1981,
                        BedPart.Foot => 1982,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1983,
                        BedPart.Foot => 1984,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1985,
                        BedPart.Foot => 1986,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1987,
                        BedPart.Foot => 1988,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1989,
                        BedPart.Foot => 1990,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1991,
                        BedPart.Foot => 1992,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1993,
                        BedPart.Foot => 1994,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1979 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1980 => new LightBlueBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1981 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1982 => new LightBlueBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1983 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1984 => new LightBlueBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1985 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1986 => new LightBlueBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1987 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1988 => new LightBlueBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1989 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1990 => new LightBlueBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1991 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1992 => new LightBlueBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1993 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1994 => new LightBlueBedBlock(Identifier, Direction.East, false, BedPart.Foot),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Occupied = properties.Contains("occupied") ? properties["occupied"].GetString() == "true" : Occupied,
            Part = properties.Contains("part") ? BedPartExtensions.FromString(properties["part"].GetString()) : Part,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("occupied", new StringTag(Occupied.ToString().ToLower())),
            ("part", new StringTag(Part.ToName()))
        );
    }
    
}
