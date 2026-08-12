using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeBedBlock(Identifier Identifier, Direction Facing, bool Occupied, BedPart Part) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:bed", "block.minecraft.lime_bed", 0.2f, 0.6f, 1f, 1f, 0.75f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:lime_bed", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Destroy, 3, "wood", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S360, BlockShapes.S360, BlockShapes.S1, BlockShapes.S1, BlockShapes.S360);
    private static readonly BlockStateInfo I1 = I0 with { MapColorId = 19, BlockShape = BlockShapes.S361, CollisionShape = BlockShapes.S361, VisualShape = BlockShapes.S361 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S361, CollisionShape = BlockShapes.S361, VisualShape = BlockShapes.S361 };
    private static readonly BlockStateInfo I3 = I0 with { MapColorId = 19 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S362, CollisionShape = BlockShapes.S362, VisualShape = BlockShapes.S362 };
    private static readonly BlockStateInfo I5 = I0 with { MapColorId = 19, BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S363, CollisionShape = BlockShapes.S363, VisualShape = BlockShapes.S363 };
    private static readonly BlockStateInfo I7 = I0 with { MapColorId = 19, BlockShape = BlockShapes.S362, CollisionShape = BlockShapes.S362, VisualShape = BlockShapes.S362 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 2011];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2011,
                        BedPart.Foot => 2012,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2013,
                        BedPart.Foot => 2014,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.South => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2015,
                        BedPart.Foot => 2016,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2017,
                        BedPart.Foot => 2018,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.West => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2019,
                        BedPart.Foot => 2020,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2021,
                        BedPart.Foot => 2022,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                Direction.East => Occupied switch {
                    true => Part switch {
                        BedPart.Head => 2023,
                        BedPart.Foot => 2024,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                    false => Part switch {
                        BedPart.Head => 2025,
                        BedPart.Foot => 2026,
                        _ => throw new ArgumentOutOfRangeException(nameof(Part), Part, "Unknown value for property part.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2011 => new LimeBedBlock(Identifier, Direction.North, true, BedPart.Head),
            2012 => new LimeBedBlock(Identifier, Direction.North, true, BedPart.Foot),
            2013 => new LimeBedBlock(Identifier, Direction.North, false, BedPart.Head),
            2014 => new LimeBedBlock(Identifier, Direction.North, false, BedPart.Foot),
            2015 => new LimeBedBlock(Identifier, Direction.South, true, BedPart.Head),
            2016 => new LimeBedBlock(Identifier, Direction.South, true, BedPart.Foot),
            2017 => new LimeBedBlock(Identifier, Direction.South, false, BedPart.Head),
            2018 => new LimeBedBlock(Identifier, Direction.South, false, BedPart.Foot),
            2019 => new LimeBedBlock(Identifier, Direction.West, true, BedPart.Head),
            2020 => new LimeBedBlock(Identifier, Direction.West, true, BedPart.Foot),
            2021 => new LimeBedBlock(Identifier, Direction.West, false, BedPart.Head),
            2022 => new LimeBedBlock(Identifier, Direction.West, false, BedPart.Foot),
            2023 => new LimeBedBlock(Identifier, Direction.East, true, BedPart.Head),
            2024 => new LimeBedBlock(Identifier, Direction.East, true, BedPart.Foot),
            2025 => new LimeBedBlock(Identifier, Direction.East, false, BedPart.Head),
            2026 => new LimeBedBlock(Identifier, Direction.East, false, BedPart.Foot),
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
