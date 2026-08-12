using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:lightning_rod", "block.minecraft.waxed_exposed_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_exposed_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 44, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30136];

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
                        true => 30136,
                        false => 30137,
                    },
                    false => Waterlogged switch {
                        true => 30138,
                        false => 30139,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30140,
                        false => 30141,
                    },
                    false => Waterlogged switch {
                        true => 30142,
                        false => 30143,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30144,
                        false => 30145,
                    },
                    false => Waterlogged switch {
                        true => 30146,
                        false => 30147,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30148,
                        false => 30149,
                    },
                    false => Waterlogged switch {
                        true => 30150,
                        false => 30151,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30152,
                        false => 30153,
                    },
                    false => Waterlogged switch {
                        true => 30154,
                        false => 30155,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30156,
                        false => 30157,
                    },
                    false => Waterlogged switch {
                        true => 30158,
                        false => 30159,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30136 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30137 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30138 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30139 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30140 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30141 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30142 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30143 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30144 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30145 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30146 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30147 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30148 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30149 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30150 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30151 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30152 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30153 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30154 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30155 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30156 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30157 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30158 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30159 => new WaxedExposedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
