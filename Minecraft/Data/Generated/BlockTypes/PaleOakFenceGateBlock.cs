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
public record PaleOakFenceGateBlock(Identifier Identifier, Direction Facing, bool InWall, bool Open, bool Powered) : IBlock, IHorizontalFacing, IOpenable, IPowered {
    private static readonly BlockInfo Data = new("minecraft:fence_gate", "block.minecraft.pale_oak_fence_gate", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:pale_oak_fence_gate", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Normal, 14, "wood", NoteBlockInstrument.Bass, false, true, false, true, true, false, false, false, true, false, false, false, false, false, true, true, false, true, [], null, BlockShapes.S68, BlockShapes.S1, BlockShapes.S1, BlockShapes.S69, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { PathfindableLand = false, PathfindableAir = false, CollisionShape = BlockShapes.S40, VisualShape = BlockShapes.S40, SupportShape = BlockShapes.S70 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S39, OcclusionShape = BlockShapes.S71 };
    private static readonly BlockStateInfo I3 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S39, CollisionShape = BlockShapes.S40, OcclusionShape = BlockShapes.S71, VisualShape = BlockShapes.S40, SupportShape = BlockShapes.S70 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S72, OcclusionShape = BlockShapes.S73 };
    private static readonly BlockStateInfo I5 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S72, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S73, VisualShape = BlockShapes.S49, SupportShape = BlockShapes.S74 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S48, OcclusionShape = BlockShapes.S75 };
    private static readonly BlockStateInfo I7 = I0 with { PathfindableLand = false, PathfindableAir = false, BlockShape = BlockShapes.S48, CollisionShape = BlockShapes.S49, OcclusionShape = BlockShapes.S75, VisualShape = BlockShapes.S49, SupportShape = BlockShapes.S74 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3, I0, I0, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I7, I7, I4, I4, I5, I5, I6, I6, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 13676];

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

    public IBlock WithOpen(bool open) => this with { Open = open };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13676,
                            false => 13677,
                        },
                        false => Powered switch {
                            true => 13678,
                            false => 13679,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13680,
                            false => 13681,
                        },
                        false => Powered switch {
                            true => 13682,
                            false => 13683,
                        },
                    },
                },
                Direction.South => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13684,
                            false => 13685,
                        },
                        false => Powered switch {
                            true => 13686,
                            false => 13687,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13688,
                            false => 13689,
                        },
                        false => Powered switch {
                            true => 13690,
                            false => 13691,
                        },
                    },
                },
                Direction.West => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13692,
                            false => 13693,
                        },
                        false => Powered switch {
                            true => 13694,
                            false => 13695,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13696,
                            false => 13697,
                        },
                        false => Powered switch {
                            true => 13698,
                            false => 13699,
                        },
                    },
                },
                Direction.East => InWall switch {
                    true => Open switch {
                        true => Powered switch {
                            true => 13700,
                            false => 13701,
                        },
                        false => Powered switch {
                            true => 13702,
                            false => 13703,
                        },
                    },
                    false => Open switch {
                        true => Powered switch {
                            true => 13704,
                            false => 13705,
                        },
                        false => Powered switch {
                            true => 13706,
                            false => 13707,
                        },
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13676 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, true),
            13677 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, true, false),
            13678 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, true),
            13679 => new PaleOakFenceGateBlock(Identifier, Direction.North, true, false, false),
            13680 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, true),
            13681 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, true, false),
            13682 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, true),
            13683 => new PaleOakFenceGateBlock(Identifier, Direction.North, false, false, false),
            13684 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, true),
            13685 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, true, false),
            13686 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, true),
            13687 => new PaleOakFenceGateBlock(Identifier, Direction.South, true, false, false),
            13688 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, true),
            13689 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, true, false),
            13690 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, true),
            13691 => new PaleOakFenceGateBlock(Identifier, Direction.South, false, false, false),
            13692 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, true),
            13693 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, true, false),
            13694 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, true),
            13695 => new PaleOakFenceGateBlock(Identifier, Direction.West, true, false, false),
            13696 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, true),
            13697 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, true, false),
            13698 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, true),
            13699 => new PaleOakFenceGateBlock(Identifier, Direction.West, false, false, false),
            13700 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, true),
            13701 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, true, false),
            13702 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, true),
            13703 => new PaleOakFenceGateBlock(Identifier, Direction.East, true, false, false),
            13704 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, true),
            13705 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, true, false),
            13706 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, true),
            13707 => new PaleOakFenceGateBlock(Identifier, Direction.East, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            InWall = properties.Contains("in_wall") ? properties["in_wall"].GetString() == "true" : InWall,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("in_wall", new StringTag(InWall.ToString().ToLower())),
            ("open", new StringTag(Open.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
