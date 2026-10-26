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
public record GrayBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock, IHorizontalFacing, IOccupied, IBedParted {
    private static readonly BlockInfo Data = new("block.minecraft.gray_bed", 0.2f, 0.6f, 1f, 1f, 0.75f, 0.5f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:gray_bed", BlockInfo.VanillaOnly, "minecraft:blocks/gray_bed");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Popped, 3, "wood", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S362, BlockShapes.S362, BlockShapes.S1, BlockShapes.S1, BlockShapes.S362, BlockShapes.S362);
    private static readonly BlockStateInfo I1 = I0 with { MapColorId = 21, BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I3 = I0 with { MapColorId = 21 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo I5 = I0 with { MapColorId = 21, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I7 = I0 with { MapColorId = 21, BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 2142];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
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
                        BedPart.Head => 2142,
                        BedPart.Foot => 2143,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2144,
                        BedPart.Foot => 2145,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2146,
                        BedPart.Foot => 2147,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2148,
                        BedPart.Foot => 2149,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2150,
                        BedPart.Foot => 2151,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2152,
                        BedPart.Foot => 2153,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2154,
                        BedPart.Foot => 2155,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2156,
                        BedPart.Foot => 2157,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2142 => new GrayBedBlock(Identifier, Direction.North, true, BedPart.Head),
            2143 => new GrayBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            2144 => new GrayBedBlock(Identifier, Direction.North, false, BedPart.Head),
            2145 => new GrayBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            2146 => new GrayBedBlock(Identifier, Direction.South, true, BedPart.Head),
            2147 => new GrayBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            2148 => new GrayBedBlock(Identifier, Direction.South, false, BedPart.Head),
            2149 => new GrayBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            2150 => new GrayBedBlock(Identifier, Direction.West, true, BedPart.Head),
            2151 => new GrayBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            2152 => new GrayBedBlock(Identifier, Direction.West, false, BedPart.Head),
            2153 => new GrayBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            2154 => new GrayBedBlock(Identifier, Direction.East, true, BedPart.Head),
            2155 => new GrayBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            2156 => new GrayBedBlock(Identifier, Direction.East, false, BedPart.Head),
            2157 => new GrayBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
