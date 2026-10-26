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
public record ComparatorBlock(Identifier Identifier, Direction Facing, ComparatorBlock.Mode ModeValue, bool Powered) : IBlock, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.comparator", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:comparator", "minecraft:comparator", BlockInfo.VanillaOnly, "minecraft:blocks/comparator");
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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 13030,
                        false => 13031,
                    },
                    Mode.Subtract => Powered switch {
                        true => 13032,
                        false => 13033,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.South => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 13034,
                        false => 13035,
                    },
                    Mode.Subtract => Powered switch {
                        true => 13036,
                        false => 13037,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.West => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 13038,
                        false => 13039,
                    },
                    Mode.Subtract => Powered switch {
                        true => 13040,
                        false => 13041,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.East => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 13042,
                        false => 13043,
                    },
                    Mode.Subtract => Powered switch {
                        true => 13044,
                        false => 13045,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13030 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, true),
            13031 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, false),
            13032 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, true),
            13033 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, false),
            13034 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, true),
            13035 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, false),
            13036 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, true),
            13037 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, false),
            13038 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, true),
            13039 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, false),
            13040 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, true),
            13041 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, false),
            13042 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, true),
            13043 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, false),
            13044 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, true),
            13045 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            ModeValue = properties.Contains("mode") ? ModeFromString(properties["mode"].GetString()) : ModeValue,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("mode", new StringTag(ModeToName(ModeValue))),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
    public enum Mode {
        Compare,
        Subtract,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "compare" => Mode.Compare,
            "subtract" => Mode.Subtract,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }

    public static string ModeToName(Mode value) {
        return value switch {
            Mode.Compare => "compare",
            Mode.Subtract => "subtract",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Mode value.")
        };
    }
}
