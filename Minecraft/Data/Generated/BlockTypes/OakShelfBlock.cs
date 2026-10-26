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
public record OakShelfBlock(Identifier Identifier, Direction Facing, bool Powered, OakShelfBlock.SideChain SideChainValue, bool Waterlogged) : IBlock, IHorizontalFacing, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_shelf", 3f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:shelf", "minecraft:oak_shelf", BlockInfo.VanillaOnly, "minecraft:blocks/oak_shelf");
    private static readonly BlockStateInfo I0 = new(2f, 0, 1, PushReaction.PushPull, 13, "shelf", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, true, false, [], "minecraft:water", BlockShapes.S83, BlockShapes.S83, BlockShapes.S1, BlockShapes.S83, BlockShapes.S83, BlockShapes.S83);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S84, CollisionShape = BlockShapes.S84, OcclusionShape = BlockShapes.S84, VisualShape = BlockShapes.S84, SupportShape = BlockShapes.S84 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S85, CollisionShape = BlockShapes.S85, OcclusionShape = BlockShapes.S85, VisualShape = BlockShapes.S85, SupportShape = BlockShapes.S85 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo I7 = I0 with { LightDampening = 0, Flammable = true, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S86, CollisionShape = BlockShapes.S86, OcclusionShape = BlockShapes.S86, VisualShape = BlockShapes.S86, SupportShape = BlockShapes.S86 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I4, I5, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 4604];

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4604,
                            false => 4605,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4606,
                            false => 4607,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4608,
                            false => 4609,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4610,
                            false => 4611,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4612,
                            false => 4613,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4614,
                            false => 4615,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4616,
                            false => 4617,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4618,
                            false => 4619,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.South => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4620,
                            false => 4621,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4622,
                            false => 4623,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4624,
                            false => 4625,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4626,
                            false => 4627,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4628,
                            false => 4629,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4630,
                            false => 4631,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4632,
                            false => 4633,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4634,
                            false => 4635,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.West => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4636,
                            false => 4637,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4638,
                            false => 4639,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4640,
                            false => 4641,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4642,
                            false => 4643,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4644,
                            false => 4645,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4646,
                            false => 4647,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4648,
                            false => 4649,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4650,
                            false => 4651,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                Direction.East => Powered switch {
                    true => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4652,
                            false => 4653,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4654,
                            false => 4655,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4656,
                            false => 4657,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4658,
                            false => 4659,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                    false => SideChainValue switch {
                        SideChain.Unconnected => Waterlogged switch {
                            true => 4660,
                            false => 4661,
                        },
                        SideChain.Right => Waterlogged switch {
                            true => 4662,
                            false => 4663,
                        },
                        SideChain.Center => Waterlogged switch {
                            true => 4664,
                            false => 4665,
                        },
                        SideChain.Left => Waterlogged switch {
                            true => 4666,
                            false => 4667,
                        },
                        _ => throw new ArgumentOutOfRangeException(nameof(SideChainValue), SideChainValue, "Unknown value for property side_chain.")
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4604 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, true),
            4605 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Unconnected, false),
            4606 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, true),
            4607 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Right, false),
            4608 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, true),
            4609 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Center, false),
            4610 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, true),
            4611 => new OakShelfBlock(Identifier, Direction.North, true, SideChain.Left, false),
            4612 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, true),
            4613 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Unconnected, false),
            4614 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, true),
            4615 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Right, false),
            4616 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, true),
            4617 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Center, false),
            4618 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, true),
            4619 => new OakShelfBlock(Identifier, Direction.North, false, SideChain.Left, false),
            4620 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, true),
            4621 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Unconnected, false),
            4622 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, true),
            4623 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Right, false),
            4624 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, true),
            4625 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Center, false),
            4626 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, true),
            4627 => new OakShelfBlock(Identifier, Direction.South, true, SideChain.Left, false),
            4628 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, true),
            4629 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Unconnected, false),
            4630 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, true),
            4631 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Right, false),
            4632 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, true),
            4633 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Center, false),
            4634 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, true),
            4635 => new OakShelfBlock(Identifier, Direction.South, false, SideChain.Left, false),
            4636 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, true),
            4637 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Unconnected, false),
            4638 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, true),
            4639 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Right, false),
            4640 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, true),
            4641 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Center, false),
            4642 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, true),
            4643 => new OakShelfBlock(Identifier, Direction.West, true, SideChain.Left, false),
            4644 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, true),
            4645 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Unconnected, false),
            4646 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, true),
            4647 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Right, false),
            4648 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, true),
            4649 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Center, false),
            4650 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, true),
            4651 => new OakShelfBlock(Identifier, Direction.West, false, SideChain.Left, false),
            4652 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, true),
            4653 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Unconnected, false),
            4654 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, true),
            4655 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Right, false),
            4656 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, true),
            4657 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Center, false),
            4658 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, true),
            4659 => new OakShelfBlock(Identifier, Direction.East, true, SideChain.Left, false),
            4660 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, true),
            4661 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Unconnected, false),
            4662 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, true),
            4663 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Right, false),
            4664 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, true),
            4665 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Center, false),
            4666 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, true),
            4667 => new OakShelfBlock(Identifier, Direction.East, false, SideChain.Left, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            SideChainValue = properties.Contains("side_chain") ? SideChainFromString(properties["side_chain"].GetString()) : SideChainValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("side_chain", new StringTag(SideChainToName(SideChainValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum SideChain {
        Unconnected,
        Right,
        Center,
        Left,
    }

    public static SideChain SideChainFromString(string value) {
        return value switch {
            "unconnected" => SideChain.Unconnected,
            "right" => SideChain.Right,
            "center" => SideChain.Center,
            "left" => SideChain.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for SideChain.")
        };
    }

    public static string SideChainToName(SideChain value) {
        return value switch {
            SideChain.Unconnected => "unconnected",
            SideChain.Right => "right",
            SideChain.Center => "center",
            SideChain.Left => "left",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown SideChain value.")
        };
    }
}
