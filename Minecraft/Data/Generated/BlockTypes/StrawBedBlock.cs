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
public record StrawBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock, IHorizontalFacing, IOccupied, IBedParted {
    private static readonly BlockInfo Data = new("block.minecraft.straw_bed", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:straw_bed", BlockInfo.VanillaOnly, "minecraft:blocks/straw_bed");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Popped, 18, "straw_bed", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S934, BlockShapes.S934, BlockShapes.S1, BlockShapes.S1, BlockShapes.S934, BlockShapes.S934);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S333, CollisionShape = BlockShapes.S333, VisualShape = BlockShapes.S333, SupportShape = BlockShapes.S333 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S935, CollisionShape = BlockShapes.S935, VisualShape = BlockShapes.S935, SupportShape = BlockShapes.S935 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S936, CollisionShape = BlockShapes.S936, VisualShape = BlockShapes.S936, SupportShape = BlockShapes.S936 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S937, CollisionShape = BlockShapes.S937, VisualShape = BlockShapes.S937, SupportShape = BlockShapes.S937 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I1, I2, I1, I3, I1, I3, I1, I4, I1, I4, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 2286];

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
                        BedPart.Head => 2286,
                        BedPart.Foot => 2287,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2288,
                        BedPart.Foot => 2289,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2290,
                        BedPart.Foot => 2291,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2292,
                        BedPart.Foot => 2293,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2294,
                        BedPart.Foot => 2295,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2296,
                        BedPart.Foot => 2297,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2298,
                        BedPart.Foot => 2299,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2300,
                        BedPart.Foot => 2301,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2286 => new StrawBedBlock(Identifier, Direction.North, true, BedPart.Head),
            2287 => new StrawBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            2288 => new StrawBedBlock(Identifier, Direction.North, false, BedPart.Head),
            2289 => new StrawBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            2290 => new StrawBedBlock(Identifier, Direction.South, true, BedPart.Head),
            2291 => new StrawBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            2292 => new StrawBedBlock(Identifier, Direction.South, false, BedPart.Head),
            2293 => new StrawBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            2294 => new StrawBedBlock(Identifier, Direction.West, true, BedPart.Head),
            2295 => new StrawBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            2296 => new StrawBedBlock(Identifier, Direction.West, false, BedPart.Head),
            2297 => new StrawBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            2298 => new StrawBedBlock(Identifier, Direction.East, true, BedPart.Head),
            2299 => new StrawBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            2300 => new StrawBedBlock(Identifier, Direction.East, false, BedPart.Head),
            2301 => new StrawBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
