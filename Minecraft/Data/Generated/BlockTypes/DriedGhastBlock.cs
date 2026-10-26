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
public record DriedGhastBlock(Identifier Identifier, Direction Facing, int Hydration, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dried_ghast", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:dried_ghast", BlockInfo.VanillaOnly, "minecraft:blocks/dried_ghast");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.PushPull, 21, "dried_ghast", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S524, BlockShapes.S524, BlockShapes.S1, BlockShapes.S1, BlockShapes.S524, BlockShapes.S524);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 18462];

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

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Hydration switch {
                    0 => Waterlogged switch {
                        true => 18462,
                        false => 18463,
                    },
                    1 => Waterlogged switch {
                        true => 18464,
                        false => 18465,
                    },
                    2 => Waterlogged switch {
                        true => 18466,
                        false => 18467,
                    },
                    3 => Waterlogged switch {
                        true => 18468,
                        false => 18469,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.South => Hydration switch {
                    0 => Waterlogged switch {
                        true => 18470,
                        false => 18471,
                    },
                    1 => Waterlogged switch {
                        true => 18472,
                        false => 18473,
                    },
                    2 => Waterlogged switch {
                        true => 18474,
                        false => 18475,
                    },
                    3 => Waterlogged switch {
                        true => 18476,
                        false => 18477,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.West => Hydration switch {
                    0 => Waterlogged switch {
                        true => 18478,
                        false => 18479,
                    },
                    1 => Waterlogged switch {
                        true => 18480,
                        false => 18481,
                    },
                    2 => Waterlogged switch {
                        true => 18482,
                        false => 18483,
                    },
                    3 => Waterlogged switch {
                        true => 18484,
                        false => 18485,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                Direction.East => Hydration switch {
                    0 => Waterlogged switch {
                        true => 18486,
                        false => 18487,
                    },
                    1 => Waterlogged switch {
                        true => 18488,
                        false => 18489,
                    },
                    2 => Waterlogged switch {
                        true => 18490,
                        false => 18491,
                    },
                    3 => Waterlogged switch {
                        true => 18492,
                        false => 18493,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Hydration), Hydration, "Unknown value for property hydration.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            18462 => new DriedGhastBlock(Identifier, Direction.North, 0, true),
            18463 => new DriedGhastBlock(Identifier, Direction.North, 0, false),
            18464 => new DriedGhastBlock(Identifier, Direction.North, 1, true),
            18465 => new DriedGhastBlock(Identifier, Direction.North, 1, false),
            18466 => new DriedGhastBlock(Identifier, Direction.North, 2, true),
            18467 => new DriedGhastBlock(Identifier, Direction.North, 2, false),
            18468 => new DriedGhastBlock(Identifier, Direction.North, 3, true),
            18469 => new DriedGhastBlock(Identifier, Direction.North, 3, false),
            18470 => new DriedGhastBlock(Identifier, Direction.South, 0, true),
            18471 => new DriedGhastBlock(Identifier, Direction.South, 0, false),
            18472 => new DriedGhastBlock(Identifier, Direction.South, 1, true),
            18473 => new DriedGhastBlock(Identifier, Direction.South, 1, false),
            18474 => new DriedGhastBlock(Identifier, Direction.South, 2, true),
            18475 => new DriedGhastBlock(Identifier, Direction.South, 2, false),
            18476 => new DriedGhastBlock(Identifier, Direction.South, 3, true),
            18477 => new DriedGhastBlock(Identifier, Direction.South, 3, false),
            18478 => new DriedGhastBlock(Identifier, Direction.West, 0, true),
            18479 => new DriedGhastBlock(Identifier, Direction.West, 0, false),
            18480 => new DriedGhastBlock(Identifier, Direction.West, 1, true),
            18481 => new DriedGhastBlock(Identifier, Direction.West, 1, false),
            18482 => new DriedGhastBlock(Identifier, Direction.West, 2, true),
            18483 => new DriedGhastBlock(Identifier, Direction.West, 2, false),
            18484 => new DriedGhastBlock(Identifier, Direction.West, 3, true),
            18485 => new DriedGhastBlock(Identifier, Direction.West, 3, false),
            18486 => new DriedGhastBlock(Identifier, Direction.East, 0, true),
            18487 => new DriedGhastBlock(Identifier, Direction.East, 0, false),
            18488 => new DriedGhastBlock(Identifier, Direction.East, 1, true),
            18489 => new DriedGhastBlock(Identifier, Direction.East, 1, false),
            18490 => new DriedGhastBlock(Identifier, Direction.East, 2, true),
            18491 => new DriedGhastBlock(Identifier, Direction.East, 2, false),
            18492 => new DriedGhastBlock(Identifier, Direction.East, 3, true),
            18493 => new DriedGhastBlock(Identifier, Direction.East, 3, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Hydration = properties.Contains("hydration") ? int.Parse(properties["hydration"].GetString()) : Hydration,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("hydration", new StringTag(Hydration.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
