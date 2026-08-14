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
public record ChorusPlantBlock(Identifier Identifier, bool Down, bool East, bool North, bool South, bool Up, bool West) : IBlock, IFaceConnected {
    private static readonly BlockInfo Data = new("minecraft:chorus_plant", "block.minecraft.chorus_plant", 0.4f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:chorus_plant", BlockInfo.VanillaOnly, "minecraft:blocks/chorus_plant");
    private static readonly BlockStateInfo I0 = new(0.4f, 0, 1, PushReaction.Destroy, 24, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S421, BlockShapes.S421, BlockShapes.S1, BlockShapes.S1, BlockShapes.S421, BlockShapes.S421);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S422, CollisionShape = BlockShapes.S422, VisualShape = BlockShapes.S422, SupportShape = BlockShapes.S422 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S423, CollisionShape = BlockShapes.S423, VisualShape = BlockShapes.S423, SupportShape = BlockShapes.S423 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S424, CollisionShape = BlockShapes.S424, VisualShape = BlockShapes.S424, SupportShape = BlockShapes.S424 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S425, CollisionShape = BlockShapes.S425, VisualShape = BlockShapes.S425, SupportShape = BlockShapes.S425 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S426, CollisionShape = BlockShapes.S426, VisualShape = BlockShapes.S426, SupportShape = BlockShapes.S426 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S427, CollisionShape = BlockShapes.S427, VisualShape = BlockShapes.S427, SupportShape = BlockShapes.S427 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S428, CollisionShape = BlockShapes.S428, VisualShape = BlockShapes.S428, SupportShape = BlockShapes.S428 };
    private static readonly BlockStateInfo I8 = I0 with { BlockShape = BlockShapes.S429, CollisionShape = BlockShapes.S429, VisualShape = BlockShapes.S429, SupportShape = BlockShapes.S429 };
    private static readonly BlockStateInfo I9 = I0 with { BlockShape = BlockShapes.S430, CollisionShape = BlockShapes.S430, VisualShape = BlockShapes.S430, SupportShape = BlockShapes.S430 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S431, CollisionShape = BlockShapes.S431, VisualShape = BlockShapes.S431, SupportShape = BlockShapes.S431 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S432, CollisionShape = BlockShapes.S432, VisualShape = BlockShapes.S432, SupportShape = BlockShapes.S432 };
    private static readonly BlockStateInfo I12 = I0 with { BlockShape = BlockShapes.S433, CollisionShape = BlockShapes.S433, VisualShape = BlockShapes.S433, SupportShape = BlockShapes.S433 };
    private static readonly BlockStateInfo I13 = I0 with { BlockShape = BlockShapes.S434, CollisionShape = BlockShapes.S434, VisualShape = BlockShapes.S434, SupportShape = BlockShapes.S434 };
    private static readonly BlockStateInfo I14 = I0 with { BlockShape = BlockShapes.S435, CollisionShape = BlockShapes.S435, VisualShape = BlockShapes.S435, SupportShape = BlockShapes.S435 };
    private static readonly BlockStateInfo I15 = I0 with { BlockShape = BlockShapes.S436, CollisionShape = BlockShapes.S436, VisualShape = BlockShapes.S436, SupportShape = BlockShapes.S436 };
    private static readonly BlockStateInfo I16 = I0 with { BlockShape = BlockShapes.S437, CollisionShape = BlockShapes.S437, VisualShape = BlockShapes.S437, SupportShape = BlockShapes.S437 };
    private static readonly BlockStateInfo I17 = I0 with { BlockShape = BlockShapes.S438, CollisionShape = BlockShapes.S438, VisualShape = BlockShapes.S438, SupportShape = BlockShapes.S438 };
    private static readonly BlockStateInfo I18 = I0 with { BlockShape = BlockShapes.S439, CollisionShape = BlockShapes.S439, VisualShape = BlockShapes.S439, SupportShape = BlockShapes.S439 };
    private static readonly BlockStateInfo I19 = I0 with { BlockShape = BlockShapes.S440, CollisionShape = BlockShapes.S440, VisualShape = BlockShapes.S440, SupportShape = BlockShapes.S440 };
    private static readonly BlockStateInfo I20 = I0 with { BlockShape = BlockShapes.S441, CollisionShape = BlockShapes.S441, VisualShape = BlockShapes.S441, SupportShape = BlockShapes.S441 };
    private static readonly BlockStateInfo I21 = I0 with { BlockShape = BlockShapes.S442, CollisionShape = BlockShapes.S442, VisualShape = BlockShapes.S442, SupportShape = BlockShapes.S442 };
    private static readonly BlockStateInfo I22 = I0 with { BlockShape = BlockShapes.S443, CollisionShape = BlockShapes.S443, VisualShape = BlockShapes.S443, SupportShape = BlockShapes.S443 };
    private static readonly BlockStateInfo I23 = I0 with { BlockShape = BlockShapes.S444, CollisionShape = BlockShapes.S444, VisualShape = BlockShapes.S444, SupportShape = BlockShapes.S444 };
    private static readonly BlockStateInfo I24 = I0 with { BlockShape = BlockShapes.S445, CollisionShape = BlockShapes.S445, VisualShape = BlockShapes.S445, SupportShape = BlockShapes.S445 };
    private static readonly BlockStateInfo I25 = I0 with { BlockShape = BlockShapes.S446, CollisionShape = BlockShapes.S446, VisualShape = BlockShapes.S446, SupportShape = BlockShapes.S446 };
    private static readonly BlockStateInfo I26 = I0 with { BlockShape = BlockShapes.S447, CollisionShape = BlockShapes.S447, VisualShape = BlockShapes.S447, SupportShape = BlockShapes.S447 };
    private static readonly BlockStateInfo I27 = I0 with { BlockShape = BlockShapes.S448, CollisionShape = BlockShapes.S448, VisualShape = BlockShapes.S448, SupportShape = BlockShapes.S448 };
    private static readonly BlockStateInfo I28 = I0 with { BlockShape = BlockShapes.S449, CollisionShape = BlockShapes.S449, VisualShape = BlockShapes.S449, SupportShape = BlockShapes.S449 };
    private static readonly BlockStateInfo I29 = I0 with { BlockShape = BlockShapes.S77, CollisionShape = BlockShapes.S77, VisualShape = BlockShapes.S77, SupportShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I30 = I0 with { BlockShape = BlockShapes.S450, CollisionShape = BlockShapes.S450, VisualShape = BlockShapes.S450, SupportShape = BlockShapes.S450 };
    private static readonly BlockStateInfo I31 = I0 with { BlockShape = BlockShapes.S451, CollisionShape = BlockShapes.S451, VisualShape = BlockShapes.S451, SupportShape = BlockShapes.S451 };
    private static readonly BlockStateInfo I32 = I0 with { BlockShape = BlockShapes.S452, CollisionShape = BlockShapes.S452, VisualShape = BlockShapes.S452, SupportShape = BlockShapes.S452 };
    private static readonly BlockStateInfo I33 = I0 with { BlockShape = BlockShapes.S453, CollisionShape = BlockShapes.S453, VisualShape = BlockShapes.S453, SupportShape = BlockShapes.S453 };
    private static readonly BlockStateInfo I34 = I0 with { BlockShape = BlockShapes.S454, CollisionShape = BlockShapes.S454, VisualShape = BlockShapes.S454, SupportShape = BlockShapes.S454 };
    private static readonly BlockStateInfo I35 = I0 with { BlockShape = BlockShapes.S455, CollisionShape = BlockShapes.S455, VisualShape = BlockShapes.S455, SupportShape = BlockShapes.S455 };
    private static readonly BlockStateInfo I36 = I0 with { BlockShape = BlockShapes.S456, CollisionShape = BlockShapes.S456, VisualShape = BlockShapes.S456, SupportShape = BlockShapes.S456 };
    private static readonly BlockStateInfo I37 = I0 with { BlockShape = BlockShapes.S457, CollisionShape = BlockShapes.S457, VisualShape = BlockShapes.S457, SupportShape = BlockShapes.S457 };
    private static readonly BlockStateInfo I38 = I0 with { BlockShape = BlockShapes.S458, CollisionShape = BlockShapes.S458, VisualShape = BlockShapes.S458, SupportShape = BlockShapes.S458 };
    private static readonly BlockStateInfo I39 = I0 with { BlockShape = BlockShapes.S459, CollisionShape = BlockShapes.S459, VisualShape = BlockShapes.S459, SupportShape = BlockShapes.S459 };
    private static readonly BlockStateInfo I40 = I0 with { BlockShape = BlockShapes.S460, CollisionShape = BlockShapes.S460, VisualShape = BlockShapes.S460, SupportShape = BlockShapes.S460 };
    private static readonly BlockStateInfo I41 = I0 with { BlockShape = BlockShapes.S461, CollisionShape = BlockShapes.S461, VisualShape = BlockShapes.S461, SupportShape = BlockShapes.S461 };
    private static readonly BlockStateInfo I42 = I0 with { BlockShape = BlockShapes.S462, CollisionShape = BlockShapes.S462, VisualShape = BlockShapes.S462, SupportShape = BlockShapes.S462 };
    private static readonly BlockStateInfo I43 = I0 with { BlockShape = BlockShapes.S463, CollisionShape = BlockShapes.S463, VisualShape = BlockShapes.S463, SupportShape = BlockShapes.S463 };
    private static readonly BlockStateInfo I44 = I0 with { BlockShape = BlockShapes.S464, CollisionShape = BlockShapes.S464, VisualShape = BlockShapes.S464, SupportShape = BlockShapes.S464 };
    private static readonly BlockStateInfo I45 = I0 with { BlockShape = BlockShapes.S465, CollisionShape = BlockShapes.S465, VisualShape = BlockShapes.S465, SupportShape = BlockShapes.S465 };
    private static readonly BlockStateInfo I46 = I0 with { BlockShape = BlockShapes.S466, CollisionShape = BlockShapes.S466, VisualShape = BlockShapes.S466, SupportShape = BlockShapes.S466 };
    private static readonly BlockStateInfo I47 = I0 with { BlockShape = BlockShapes.S467, CollisionShape = BlockShapes.S467, VisualShape = BlockShapes.S467, SupportShape = BlockShapes.S467 };
    private static readonly BlockStateInfo I48 = I0 with { BlockShape = BlockShapes.S468, CollisionShape = BlockShapes.S468, VisualShape = BlockShapes.S468, SupportShape = BlockShapes.S468 };
    private static readonly BlockStateInfo I49 = I0 with { BlockShape = BlockShapes.S469, CollisionShape = BlockShapes.S469, VisualShape = BlockShapes.S469, SupportShape = BlockShapes.S469 };
    private static readonly BlockStateInfo I50 = I0 with { BlockShape = BlockShapes.S470, CollisionShape = BlockShapes.S470, VisualShape = BlockShapes.S470, SupportShape = BlockShapes.S470 };
    private static readonly BlockStateInfo I51 = I0 with { BlockShape = BlockShapes.S471, CollisionShape = BlockShapes.S471, VisualShape = BlockShapes.S471, SupportShape = BlockShapes.S471 };
    private static readonly BlockStateInfo I52 = I0 with { BlockShape = BlockShapes.S472, CollisionShape = BlockShapes.S472, VisualShape = BlockShapes.S472, SupportShape = BlockShapes.S472 };
    private static readonly BlockStateInfo I53 = I0 with { BlockShape = BlockShapes.S473, CollisionShape = BlockShapes.S473, VisualShape = BlockShapes.S473, SupportShape = BlockShapes.S473 };
    private static readonly BlockStateInfo I54 = I0 with { BlockShape = BlockShapes.S474, CollisionShape = BlockShapes.S474, VisualShape = BlockShapes.S474, SupportShape = BlockShapes.S474 };
    private static readonly BlockStateInfo I55 = I0 with { BlockShape = BlockShapes.S475, CollisionShape = BlockShapes.S475, VisualShape = BlockShapes.S475, SupportShape = BlockShapes.S475 };
    private static readonly BlockStateInfo I56 = I0 with { BlockShape = BlockShapes.S476, CollisionShape = BlockShapes.S476, VisualShape = BlockShapes.S476, SupportShape = BlockShapes.S476 };
    private static readonly BlockStateInfo I57 = I0 with { BlockShape = BlockShapes.S477, CollisionShape = BlockShapes.S477, VisualShape = BlockShapes.S477, SupportShape = BlockShapes.S477 };
    private static readonly BlockStateInfo I58 = I0 with { BlockShape = BlockShapes.S478, CollisionShape = BlockShapes.S478, VisualShape = BlockShapes.S478, SupportShape = BlockShapes.S478 };
    private static readonly BlockStateInfo I59 = I0 with { BlockShape = BlockShapes.S479, CollisionShape = BlockShapes.S479, VisualShape = BlockShapes.S479, SupportShape = BlockShapes.S479 };
    private static readonly BlockStateInfo I60 = I0 with { BlockShape = BlockShapes.S480, CollisionShape = BlockShapes.S480, VisualShape = BlockShapes.S480, SupportShape = BlockShapes.S480 };
    private static readonly BlockStateInfo I61 = I0 with { BlockShape = BlockShapes.S481, CollisionShape = BlockShapes.S481, VisualShape = BlockShapes.S481, SupportShape = BlockShapes.S481 };
    private static readonly BlockStateInfo I62 = I0 with { BlockShape = BlockShapes.S482, CollisionShape = BlockShapes.S482, VisualShape = BlockShapes.S482, SupportShape = BlockShapes.S482 };
    private static readonly BlockStateInfo I63 = I0 with { BlockShape = BlockShapes.S483, CollisionShape = BlockShapes.S483, VisualShape = BlockShapes.S483, SupportShape = BlockShapes.S483 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10, I11, I12, I13, I14, I15, I16, I17, I18, I19, I20, I21, I22, I23, I24, I25, I26, I27, I28, I29, I30, I31, I32, I33, I34, I35, I36, I37, I38, I39, I40, I41, I42, I43, I44, I45, I46, I47, I48, I49, I50, I51, I52, I53, I54, I55, I56, I57, I58, I59, I60, I61, I62, I63
    ];

    public BlockStateInfo StateInfo => States[StateId - 14642];

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

    public bool HasFace(BlockFace face) => face is BlockFace.NegY or BlockFace.PosY or BlockFace.NegZ or BlockFace.PosZ or BlockFace.NegX or BlockFace.PosX;

    public bool Connected(BlockFace face) => face switch {
        BlockFace.NegY => Down,
        BlockFace.PosY => Up,
        BlockFace.NegZ => North,
        BlockFace.PosZ => South,
        BlockFace.NegX => West,
        BlockFace.PosX => East,
        _ => false
    };

    public IBlock WithConnection(BlockFace face, bool connected) => face switch {
        BlockFace.NegY => this with { Down = connected },
        BlockFace.PosY => this with { Up = connected },
        BlockFace.NegZ => this with { North = connected },
        BlockFace.PosZ => this with { South = connected },
        BlockFace.NegX => this with { West = connected },
        BlockFace.PosX => this with { East = connected },
        _ => this
    };


    public uint StateId {
        get {
            return Down switch {
                true => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14642,
                                    false => 14643,
                                },
                                false => West switch {
                                    true => 14644,
                                    false => 14645,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14646,
                                    false => 14647,
                                },
                                false => West switch {
                                    true => 14648,
                                    false => 14649,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14650,
                                    false => 14651,
                                },
                                false => West switch {
                                    true => 14652,
                                    false => 14653,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14654,
                                    false => 14655,
                                },
                                false => West switch {
                                    true => 14656,
                                    false => 14657,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14658,
                                    false => 14659,
                                },
                                false => West switch {
                                    true => 14660,
                                    false => 14661,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14662,
                                    false => 14663,
                                },
                                false => West switch {
                                    true => 14664,
                                    false => 14665,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14666,
                                    false => 14667,
                                },
                                false => West switch {
                                    true => 14668,
                                    false => 14669,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14670,
                                    false => 14671,
                                },
                                false => West switch {
                                    true => 14672,
                                    false => 14673,
                                },
                            },
                        },
                    },
                },
                false => East switch {
                    true => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14674,
                                    false => 14675,
                                },
                                false => West switch {
                                    true => 14676,
                                    false => 14677,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14678,
                                    false => 14679,
                                },
                                false => West switch {
                                    true => 14680,
                                    false => 14681,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14682,
                                    false => 14683,
                                },
                                false => West switch {
                                    true => 14684,
                                    false => 14685,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14686,
                                    false => 14687,
                                },
                                false => West switch {
                                    true => 14688,
                                    false => 14689,
                                },
                            },
                        },
                    },
                    false => North switch {
                        true => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14690,
                                    false => 14691,
                                },
                                false => West switch {
                                    true => 14692,
                                    false => 14693,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14694,
                                    false => 14695,
                                },
                                false => West switch {
                                    true => 14696,
                                    false => 14697,
                                },
                            },
                        },
                        false => South switch {
                            true => Up switch {
                                true => West switch {
                                    true => 14698,
                                    false => 14699,
                                },
                                false => West switch {
                                    true => 14700,
                                    false => 14701,
                                },
                            },
                            false => Up switch {
                                true => West switch {
                                    true => 14702,
                                    false => 14703,
                                },
                                false => West switch {
                                    true => 14704,
                                    false => 14705,
                                },
                            },
                        },
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            14642 => new ChorusPlantBlock(Identifier, true, true, true, true, true, true),
            14643 => new ChorusPlantBlock(Identifier, true, true, true, true, true, false),
            14644 => new ChorusPlantBlock(Identifier, true, true, true, true, false, true),
            14645 => new ChorusPlantBlock(Identifier, true, true, true, true, false, false),
            14646 => new ChorusPlantBlock(Identifier, true, true, true, false, true, true),
            14647 => new ChorusPlantBlock(Identifier, true, true, true, false, true, false),
            14648 => new ChorusPlantBlock(Identifier, true, true, true, false, false, true),
            14649 => new ChorusPlantBlock(Identifier, true, true, true, false, false, false),
            14650 => new ChorusPlantBlock(Identifier, true, true, false, true, true, true),
            14651 => new ChorusPlantBlock(Identifier, true, true, false, true, true, false),
            14652 => new ChorusPlantBlock(Identifier, true, true, false, true, false, true),
            14653 => new ChorusPlantBlock(Identifier, true, true, false, true, false, false),
            14654 => new ChorusPlantBlock(Identifier, true, true, false, false, true, true),
            14655 => new ChorusPlantBlock(Identifier, true, true, false, false, true, false),
            14656 => new ChorusPlantBlock(Identifier, true, true, false, false, false, true),
            14657 => new ChorusPlantBlock(Identifier, true, true, false, false, false, false),
            14658 => new ChorusPlantBlock(Identifier, true, false, true, true, true, true),
            14659 => new ChorusPlantBlock(Identifier, true, false, true, true, true, false),
            14660 => new ChorusPlantBlock(Identifier, true, false, true, true, false, true),
            14661 => new ChorusPlantBlock(Identifier, true, false, true, true, false, false),
            14662 => new ChorusPlantBlock(Identifier, true, false, true, false, true, true),
            14663 => new ChorusPlantBlock(Identifier, true, false, true, false, true, false),
            14664 => new ChorusPlantBlock(Identifier, true, false, true, false, false, true),
            14665 => new ChorusPlantBlock(Identifier, true, false, true, false, false, false),
            14666 => new ChorusPlantBlock(Identifier, true, false, false, true, true, true),
            14667 => new ChorusPlantBlock(Identifier, true, false, false, true, true, false),
            14668 => new ChorusPlantBlock(Identifier, true, false, false, true, false, true),
            14669 => new ChorusPlantBlock(Identifier, true, false, false, true, false, false),
            14670 => new ChorusPlantBlock(Identifier, true, false, false, false, true, true),
            14671 => new ChorusPlantBlock(Identifier, true, false, false, false, true, false),
            14672 => new ChorusPlantBlock(Identifier, true, false, false, false, false, true),
            14673 => new ChorusPlantBlock(Identifier, true, false, false, false, false, false),
            14674 => new ChorusPlantBlock(Identifier, false, true, true, true, true, true),
            14675 => new ChorusPlantBlock(Identifier, false, true, true, true, true, false),
            14676 => new ChorusPlantBlock(Identifier, false, true, true, true, false, true),
            14677 => new ChorusPlantBlock(Identifier, false, true, true, true, false, false),
            14678 => new ChorusPlantBlock(Identifier, false, true, true, false, true, true),
            14679 => new ChorusPlantBlock(Identifier, false, true, true, false, true, false),
            14680 => new ChorusPlantBlock(Identifier, false, true, true, false, false, true),
            14681 => new ChorusPlantBlock(Identifier, false, true, true, false, false, false),
            14682 => new ChorusPlantBlock(Identifier, false, true, false, true, true, true),
            14683 => new ChorusPlantBlock(Identifier, false, true, false, true, true, false),
            14684 => new ChorusPlantBlock(Identifier, false, true, false, true, false, true),
            14685 => new ChorusPlantBlock(Identifier, false, true, false, true, false, false),
            14686 => new ChorusPlantBlock(Identifier, false, true, false, false, true, true),
            14687 => new ChorusPlantBlock(Identifier, false, true, false, false, true, false),
            14688 => new ChorusPlantBlock(Identifier, false, true, false, false, false, true),
            14689 => new ChorusPlantBlock(Identifier, false, true, false, false, false, false),
            14690 => new ChorusPlantBlock(Identifier, false, false, true, true, true, true),
            14691 => new ChorusPlantBlock(Identifier, false, false, true, true, true, false),
            14692 => new ChorusPlantBlock(Identifier, false, false, true, true, false, true),
            14693 => new ChorusPlantBlock(Identifier, false, false, true, true, false, false),
            14694 => new ChorusPlantBlock(Identifier, false, false, true, false, true, true),
            14695 => new ChorusPlantBlock(Identifier, false, false, true, false, true, false),
            14696 => new ChorusPlantBlock(Identifier, false, false, true, false, false, true),
            14697 => new ChorusPlantBlock(Identifier, false, false, true, false, false, false),
            14698 => new ChorusPlantBlock(Identifier, false, false, false, true, true, true),
            14699 => new ChorusPlantBlock(Identifier, false, false, false, true, true, false),
            14700 => new ChorusPlantBlock(Identifier, false, false, false, true, false, true),
            14701 => new ChorusPlantBlock(Identifier, false, false, false, true, false, false),
            14702 => new ChorusPlantBlock(Identifier, false, false, false, false, true, true),
            14703 => new ChorusPlantBlock(Identifier, false, false, false, false, true, false),
            14704 => new ChorusPlantBlock(Identifier, false, false, false, false, false, true),
            14705 => new ChorusPlantBlock(Identifier, false, false, false, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Down = properties.Contains("down") ? properties["down"].GetString() == "true" : Down,
            East = properties.Contains("east") ? properties["east"].GetString() == "true" : East,
            North = properties.Contains("north") ? properties["north"].GetString() == "true" : North,
            South = properties.Contains("south") ? properties["south"].GetString() == "true" : South,
            Up = properties.Contains("up") ? properties["up"].GetString() == "true" : Up,
            West = properties.Contains("west") ? properties["west"].GetString() == "true" : West,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("down", new StringTag(Down.ToString().ToLower())),
            ("east", new StringTag(East.ToString().ToLower())),
            ("north", new StringTag(North.ToString().ToLower())),
            ("south", new StringTag(South.ToString().ToLower())),
            ("up", new StringTag(Up.ToString().ToLower())),
            ("west", new StringTag(West.ToString().ToLower()))
        );
    }
    
}
