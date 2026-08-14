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
public record BambooBlock(Identifier Identifier, int Age, BambooBlock.Leaves LeavesValue, int Stage) : IBlock, IAged {
    private static readonly BlockInfo Data = new("minecraft:bamboo_stalk", "block.minecraft.bamboo", 1f, 0.6f, 1f, 1f, 0f, false, true, BlockOffsetType.Xz, 0.25f, 0f, null, "minecraft:bamboo", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo") { ShapeOffsets = BlockShapeOffsets.Block | BlockShapeOffsets.Collision | BlockShapeOffsets.Visual };
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 7, "bamboo", NoteBlockInstrument.Harp, false, false, false, true, true, false, false, false, true, false, false, true, false, false, true, false, false, false, [], null, BlockShapes.S330, BlockShapes.S331, BlockShapes.S1, BlockShapes.S1, BlockShapes.S331, BlockShapes.S331);
    private static readonly BlockStateInfo I1 = I0 with { RandomlyTicking = false };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S77 };
    private static readonly BlockStateInfo I3 = I0 with { RandomlyTicking = false, BlockShape = BlockShapes.S77 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I0, I1, I0, I1, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 15279];

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

    public IBlock WithAge(int age) => this with { Age = age };


    public uint StateId {
        get {
            return Age switch {
                0 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 15279,
                        1 => 15280,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15281,
                        1 => 15282,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15283,
                        1 => 15284,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                1 => LeavesValue switch {
                    Leaves.None => Stage switch {
                        0 => 15285,
                        1 => 15286,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Small => Stage switch {
                        0 => 15287,
                        1 => 15288,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    Leaves.Large => Stage switch {
                        0 => 15289,
                        1 => 15290,
                        _ => throw new ArgumentOutOfRangeException(nameof(Stage), Stage, "Unknown value for property stage.")
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(LeavesValue), LeavesValue, "Unknown value for property leaves.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15279 => new BambooBlock(Identifier, 0, Leaves.None, 0),
            15280 => new BambooBlock(Identifier, 0, Leaves.None, 1),
            15281 => new BambooBlock(Identifier, 0, Leaves.Small, 0),
            15282 => new BambooBlock(Identifier, 0, Leaves.Small, 1),
            15283 => new BambooBlock(Identifier, 0, Leaves.Large, 0),
            15284 => new BambooBlock(Identifier, 0, Leaves.Large, 1),
            15285 => new BambooBlock(Identifier, 1, Leaves.None, 0),
            15286 => new BambooBlock(Identifier, 1, Leaves.None, 1),
            15287 => new BambooBlock(Identifier, 1, Leaves.Small, 0),
            15288 => new BambooBlock(Identifier, 1, Leaves.Small, 1),
            15289 => new BambooBlock(Identifier, 1, Leaves.Large, 0),
            15290 => new BambooBlock(Identifier, 1, Leaves.Large, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
            LeavesValue = properties.Contains("leaves") ? LeavesFromString(properties["leaves"].GetString()) : LeavesValue,
            Stage = properties.Contains("stage") ? int.Parse(properties["stage"].GetString()) : Stage,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString())),
            ("leaves", new StringTag(LeavesToName(LeavesValue))),
            ("stage", new StringTag(Stage.ToString()))
        );
    }
    
    public enum Leaves {
        None,
        Small,
        Large,
    }

    public static Leaves LeavesFromString(string value) {
        return value switch {
            "none" => Leaves.None,
            "small" => Leaves.Small,
            "large" => Leaves.Large,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Leaves.")
        };
    }

    public static string LeavesToName(Leaves value) {
        return value switch {
            Leaves.None => "none",
            Leaves.Small => "small",
            Leaves.Large => "large",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Leaves value.")
        };
    }
}
