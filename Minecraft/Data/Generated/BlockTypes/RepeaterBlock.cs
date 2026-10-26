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
public record RepeaterBlock(Identifier Identifier, int Delay, Direction Facing, bool Locked, bool Powered) : IBlock, IHorizontalFacing, ILocked, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.repeater", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:repeater", BlockInfo.VanillaOnly, "minecraft:blocks/repeater");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S124, BlockShapes.S124, BlockShapes.S1, BlockShapes.S124, BlockShapes.S124, BlockShapes.S124);

    public BlockStateInfo StateInfo => I0;

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

    public IBlock WithLocked(bool locked) => this with { Locked = locked };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Delay switch {
                1 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 8704,
                            false => 8705,
                        },
                        false => Powered switch {
                            true => 8706,
                            false => 8707,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 8708,
                            false => 8709,
                        },
                        false => Powered switch {
                            true => 8710,
                            false => 8711,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 8712,
                            false => 8713,
                        },
                        false => Powered switch {
                            true => 8714,
                            false => 8715,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 8716,
                            false => 8717,
                        },
                        false => Powered switch {
                            true => 8718,
                            false => 8719,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                2 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 8720,
                            false => 8721,
                        },
                        false => Powered switch {
                            true => 8722,
                            false => 8723,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 8724,
                            false => 8725,
                        },
                        false => Powered switch {
                            true => 8726,
                            false => 8727,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 8728,
                            false => 8729,
                        },
                        false => Powered switch {
                            true => 8730,
                            false => 8731,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 8732,
                            false => 8733,
                        },
                        false => Powered switch {
                            true => 8734,
                            false => 8735,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                3 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 8736,
                            false => 8737,
                        },
                        false => Powered switch {
                            true => 8738,
                            false => 8739,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 8740,
                            false => 8741,
                        },
                        false => Powered switch {
                            true => 8742,
                            false => 8743,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 8744,
                            false => 8745,
                        },
                        false => Powered switch {
                            true => 8746,
                            false => 8747,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 8748,
                            false => 8749,
                        },
                        false => Powered switch {
                            true => 8750,
                            false => 8751,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                4 => Facing switch {
                    Direction.North => Locked switch {
                        true => Powered switch {
                            true => 8752,
                            false => 8753,
                        },
                        false => Powered switch {
                            true => 8754,
                            false => 8755,
                        },
                    },
                    Direction.South => Locked switch {
                        true => Powered switch {
                            true => 8756,
                            false => 8757,
                        },
                        false => Powered switch {
                            true => 8758,
                            false => 8759,
                        },
                    },
                    Direction.West => Locked switch {
                        true => Powered switch {
                            true => 8760,
                            false => 8761,
                        },
                        false => Powered switch {
                            true => 8762,
                            false => 8763,
                        },
                    },
                    Direction.East => Locked switch {
                        true => Powered switch {
                            true => 8764,
                            false => 8765,
                        },
                        false => Powered switch {
                            true => 8766,
                            false => 8767,
                        },
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Delay), Delay, "Unknown value for property delay.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8704 => new RepeaterBlock(Identifier, 1, Direction.North, true, true),
            8705 => new RepeaterBlock(Identifier, 1, Direction.North, true, false),
            8706 => new RepeaterBlock(Identifier, 1, Direction.North, false, true),
            8707 => new RepeaterBlock(Identifier, 1, Direction.North, false, false),
            8708 => new RepeaterBlock(Identifier, 1, Direction.South, true, true),
            8709 => new RepeaterBlock(Identifier, 1, Direction.South, true, false),
            8710 => new RepeaterBlock(Identifier, 1, Direction.South, false, true),
            8711 => new RepeaterBlock(Identifier, 1, Direction.South, false, false),
            8712 => new RepeaterBlock(Identifier, 1, Direction.West, true, true),
            8713 => new RepeaterBlock(Identifier, 1, Direction.West, true, false),
            8714 => new RepeaterBlock(Identifier, 1, Direction.West, false, true),
            8715 => new RepeaterBlock(Identifier, 1, Direction.West, false, false),
            8716 => new RepeaterBlock(Identifier, 1, Direction.East, true, true),
            8717 => new RepeaterBlock(Identifier, 1, Direction.East, true, false),
            8718 => new RepeaterBlock(Identifier, 1, Direction.East, false, true),
            8719 => new RepeaterBlock(Identifier, 1, Direction.East, false, false),
            8720 => new RepeaterBlock(Identifier, 2, Direction.North, true, true),
            8721 => new RepeaterBlock(Identifier, 2, Direction.North, true, false),
            8722 => new RepeaterBlock(Identifier, 2, Direction.North, false, true),
            8723 => new RepeaterBlock(Identifier, 2, Direction.North, false, false),
            8724 => new RepeaterBlock(Identifier, 2, Direction.South, true, true),
            8725 => new RepeaterBlock(Identifier, 2, Direction.South, true, false),
            8726 => new RepeaterBlock(Identifier, 2, Direction.South, false, true),
            8727 => new RepeaterBlock(Identifier, 2, Direction.South, false, false),
            8728 => new RepeaterBlock(Identifier, 2, Direction.West, true, true),
            8729 => new RepeaterBlock(Identifier, 2, Direction.West, true, false),
            8730 => new RepeaterBlock(Identifier, 2, Direction.West, false, true),
            8731 => new RepeaterBlock(Identifier, 2, Direction.West, false, false),
            8732 => new RepeaterBlock(Identifier, 2, Direction.East, true, true),
            8733 => new RepeaterBlock(Identifier, 2, Direction.East, true, false),
            8734 => new RepeaterBlock(Identifier, 2, Direction.East, false, true),
            8735 => new RepeaterBlock(Identifier, 2, Direction.East, false, false),
            8736 => new RepeaterBlock(Identifier, 3, Direction.North, true, true),
            8737 => new RepeaterBlock(Identifier, 3, Direction.North, true, false),
            8738 => new RepeaterBlock(Identifier, 3, Direction.North, false, true),
            8739 => new RepeaterBlock(Identifier, 3, Direction.North, false, false),
            8740 => new RepeaterBlock(Identifier, 3, Direction.South, true, true),
            8741 => new RepeaterBlock(Identifier, 3, Direction.South, true, false),
            8742 => new RepeaterBlock(Identifier, 3, Direction.South, false, true),
            8743 => new RepeaterBlock(Identifier, 3, Direction.South, false, false),
            8744 => new RepeaterBlock(Identifier, 3, Direction.West, true, true),
            8745 => new RepeaterBlock(Identifier, 3, Direction.West, true, false),
            8746 => new RepeaterBlock(Identifier, 3, Direction.West, false, true),
            8747 => new RepeaterBlock(Identifier, 3, Direction.West, false, false),
            8748 => new RepeaterBlock(Identifier, 3, Direction.East, true, true),
            8749 => new RepeaterBlock(Identifier, 3, Direction.East, true, false),
            8750 => new RepeaterBlock(Identifier, 3, Direction.East, false, true),
            8751 => new RepeaterBlock(Identifier, 3, Direction.East, false, false),
            8752 => new RepeaterBlock(Identifier, 4, Direction.North, true, true),
            8753 => new RepeaterBlock(Identifier, 4, Direction.North, true, false),
            8754 => new RepeaterBlock(Identifier, 4, Direction.North, false, true),
            8755 => new RepeaterBlock(Identifier, 4, Direction.North, false, false),
            8756 => new RepeaterBlock(Identifier, 4, Direction.South, true, true),
            8757 => new RepeaterBlock(Identifier, 4, Direction.South, true, false),
            8758 => new RepeaterBlock(Identifier, 4, Direction.South, false, true),
            8759 => new RepeaterBlock(Identifier, 4, Direction.South, false, false),
            8760 => new RepeaterBlock(Identifier, 4, Direction.West, true, true),
            8761 => new RepeaterBlock(Identifier, 4, Direction.West, true, false),
            8762 => new RepeaterBlock(Identifier, 4, Direction.West, false, true),
            8763 => new RepeaterBlock(Identifier, 4, Direction.West, false, false),
            8764 => new RepeaterBlock(Identifier, 4, Direction.East, true, true),
            8765 => new RepeaterBlock(Identifier, 4, Direction.East, true, false),
            8766 => new RepeaterBlock(Identifier, 4, Direction.East, false, true),
            8767 => new RepeaterBlock(Identifier, 4, Direction.East, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Delay = properties.Contains("delay") ? int.Parse(properties["delay"].GetString()) : Delay,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Locked = properties.Contains("locked") ? properties["locked"].GetString() == "true" : Locked,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("delay", new StringTag(Delay.ToString())),
            ("facing", new StringTag(Facing.ToName())),
            ("locked", new StringTag(Locked.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
