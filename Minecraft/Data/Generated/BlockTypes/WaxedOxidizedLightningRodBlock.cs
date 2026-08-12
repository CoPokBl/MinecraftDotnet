using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedLightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:lightning_rod", "block.minecraft.waxed_oxidized_lightning_rod", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:waxed_oxidized_lightning_rod", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 55, "copper", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, true, false, false, false, true, [], "minecraft:water", BlockShapes.S525, BlockShapes.S525, BlockShapes.S1, BlockShapes.S1, BlockShapes.S525);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S526, CollisionShape = BlockShapes.S526, VisualShape = BlockShapes.S526 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 30184];

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
                        true => 30184,
                        false => 30185,
                    },
                    false => Waterlogged switch {
                        true => 30186,
                        false => 30187,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 30188,
                        false => 30189,
                    },
                    false => Waterlogged switch {
                        true => 30190,
                        false => 30191,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 30192,
                        false => 30193,
                    },
                    false => Waterlogged switch {
                        true => 30194,
                        false => 30195,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 30196,
                        false => 30197,
                    },
                    false => Waterlogged switch {
                        true => 30198,
                        false => 30199,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 30200,
                        false => 30201,
                    },
                    false => Waterlogged switch {
                        true => 30202,
                        false => 30203,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 30204,
                        false => 30205,
                    },
                    false => Waterlogged switch {
                        true => 30206,
                        false => 30207,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            30184 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, true),
            30185 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, true, false),
            30186 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, true),
            30187 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.North, false, false),
            30188 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, true),
            30189 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, true, false),
            30190 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, true),
            30191 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.East, false, false),
            30192 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, true),
            30193 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, true, false),
            30194 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, true),
            30195 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.South, false, false),
            30196 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, true),
            30197 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, true, false),
            30198 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, true),
            30199 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.West, false, false),
            30200 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, true),
            30201 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, true, false),
            30202 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, true),
            30203 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Up, false, false),
            30204 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, true),
            30205 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, true, false),
            30206 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, true),
            30207 => new WaxedOxidizedLightningRodBlock(Identifier, Cardinal.Down, false, false),
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
