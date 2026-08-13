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
    private static readonly BlockInfo Data = new("minecraft:comparator", "block.minecraft.comparator", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:comparator", "minecraft:comparator", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S124, BlockShapes.S124, BlockShapes.S1, BlockShapes.S124, BlockShapes.S124, BlockShapes.S124);

    public BlockStateInfo StateInfo => I0;

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11263,
                        false => 11264,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11265,
                        false => 11266,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.South => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11267,
                        false => 11268,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11269,
                        false => 11270,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.West => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11271,
                        false => 11272,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11273,
                        false => 11274,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                Direction.East => ModeValue switch {
                    Mode.Compare => Powered switch {
                        true => 11275,
                        false => 11276,
                    },
                    Mode.Subtract => Powered switch {
                        true => 11277,
                        false => 11278,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11263 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, true),
            11264 => new ComparatorBlock(Identifier, Direction.North, Mode.Compare, false),
            11265 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, true),
            11266 => new ComparatorBlock(Identifier, Direction.North, Mode.Subtract, false),
            11267 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, true),
            11268 => new ComparatorBlock(Identifier, Direction.South, Mode.Compare, false),
            11269 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, true),
            11270 => new ComparatorBlock(Identifier, Direction.South, Mode.Subtract, false),
            11271 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, true),
            11272 => new ComparatorBlock(Identifier, Direction.West, Mode.Compare, false),
            11273 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, true),
            11274 => new ComparatorBlock(Identifier, Direction.West, Mode.Subtract, false),
            11275 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, true),
            11276 => new ComparatorBlock(Identifier, Direction.East, Mode.Compare, false),
            11277 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, true),
            11278 => new ComparatorBlock(Identifier, Direction.East, Mode.Subtract, false),
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
