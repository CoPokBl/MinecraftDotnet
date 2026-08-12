using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_lightning_rod", "block.minecraft.lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 15, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, true, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30016];

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
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 30016,
                        false => 30017,
                    },
                    false => Waterlogged switch {
                        true => 30018,
                        false => 30019,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30020,
                        false => 30021,
                    },
                    false => Waterlogged switch {
                        true => 30022,
                        false => 30023,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30024,
                        false => 30025,
                    },
                    false => Waterlogged switch {
                        true => 30026,
                        false => 30027,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30028,
                        false => 30029,
                    },
                    false => Waterlogged switch {
                        true => 30030,
                        false => 30031,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30032,
                        false => 30033,
                    },
                    false => Waterlogged switch {
                        true => 30034,
                        false => 30035,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30036,
                        false => 30037,
                    },
                    false => Waterlogged switch {
                        true => 30038,
                        false => 30039,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30016 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            30017 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            30018 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            30019 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            30020 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            30021 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            30022 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            30023 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            30024 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            30025 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            30026 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            30027 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            30028 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            30029 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            30030 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            30031 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            30032 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            30033 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            30034 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            30035 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            30036 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            30037 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            30038 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            30039 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
