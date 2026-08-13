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
public record OrangeBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock, IHorizontalFacing, IBedParted {
    private static readonly BlockInfo Data = new("minecraft:bed", "block.minecraft.orange_bed", 0.2f, 0.6f, 1f, 1f, 0.75f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:orange_bed", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Destroy, 3, "wood", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S362, BlockShapes.S362, BlockShapes.S1, BlockShapes.S1, BlockShapes.S362, BlockShapes.S362);
    private static readonly BlockStateInfo I1 = I0 with { MapColorId = 15, BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363, SupportShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I3 = I0 with { MapColorId = 15 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo I5 = I0 with { MapColorId = 15, BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S365, CollisionShape = BlockShapes.S365, VisualShape = BlockShapes.S365, SupportShape = BlockShapes.S365 };
    private static readonly BlockStateInfo I7 = I0 with { MapColorId = 15, BlockShape = BlockShapes.S364, CollisionShape = BlockShapes.S364, VisualShape = BlockShapes.S364, SupportShape = BlockShapes.S364 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 1947];

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

    public IBlock WithPart(BedPart part) => this with { Part = part };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1947,
                        BedPart.Foot => 1948,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1949,
                        BedPart.Foot => 1950,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1951,
                        BedPart.Foot => 1952,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1953,
                        BedPart.Foot => 1954,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1955,
                        BedPart.Foot => 1956,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1957,
                        BedPart.Foot => 1958,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 1959,
                        BedPart.Foot => 1960,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 1961,
                        BedPart.Foot => 1962,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            1947 => new OrangeBedBlock(Identifier, Direction.North, true, BedPart.Head),
            1948 => new OrangeBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            1949 => new OrangeBedBlock(Identifier, Direction.North, false, BedPart.Head),
            1950 => new OrangeBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            1951 => new OrangeBedBlock(Identifier, Direction.South, true, BedPart.Head),
            1952 => new OrangeBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            1953 => new OrangeBedBlock(Identifier, Direction.South, false, BedPart.Head),
            1954 => new OrangeBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            1955 => new OrangeBedBlock(Identifier, Direction.West, true, BedPart.Head),
            1956 => new OrangeBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            1957 => new OrangeBedBlock(Identifier, Direction.West, false, BedPart.Head),
            1958 => new OrangeBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            1959 => new OrangeBedBlock(Identifier, Direction.East, true, BedPart.Head),
            1960 => new OrangeBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            1961 => new OrangeBedBlock(Identifier, Direction.East, false, BedPart.Head),
            1962 => new OrangeBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
