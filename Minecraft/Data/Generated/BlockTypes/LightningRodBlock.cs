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
public record LightningRodBlock(Identifier Identifier, Cardinal Facing, bool Powered, bool Waterlogged) : IBlock, IDirectional, IPowered, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.lightning_rod", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:lightning_rod", BlockInfo.VanillaOnly, "minecraft:blocks/lightning_rod");
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.PushPull, 15, "copper", NoteBlockInstrument.Harp, false, false, true, false, false, false, false, true, false, true, true, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S528, BlockShapes.S528, BlockShapes.S1, BlockShapes.S1, BlockShapes.S528, BlockShapes.S528);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S529, CollisionShape = BlockShapes.S529, VisualShape = BlockShapes.S529, SupportShape = BlockShapes.S529 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo I5 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S66, CollisionShape = BlockShapes.S66, VisualShape = BlockShapes.S66, SupportShape = BlockShapes.S66 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I0, I1, I0, I1, I2, I3, I2, I3, I4, I5, I4, I5, I4, I5, I4, I5
    ];

    public BlockStateInfo StateInfo => States[StateId - 33373];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Powered switch {
                    true => Waterlogged switch {
                        true => 33373,
                        false => 33374,
                    },
                    false => Waterlogged switch {
                        true => 33375,
                        false => 33376,
                    },
                },
                Cardinal.East => Powered switch {
                    true => Waterlogged switch {
                        true => 33377,
                        false => 33378,
                    },
                    false => Waterlogged switch {
                        true => 33379,
                        false => 33380,
                    },
                },
                Cardinal.South => Powered switch {
                    true => Waterlogged switch {
                        true => 33381,
                        false => 33382,
                    },
                    false => Waterlogged switch {
                        true => 33383,
                        false => 33384,
                    },
                },
                Cardinal.West => Powered switch {
                    true => Waterlogged switch {
                        true => 33385,
                        false => 33386,
                    },
                    false => Waterlogged switch {
                        true => 33387,
                        false => 33388,
                    },
                },
                Cardinal.Up => Powered switch {
                    true => Waterlogged switch {
                        true => 33389,
                        false => 33390,
                    },
                    false => Waterlogged switch {
                        true => 33391,
                        false => 33392,
                    },
                },
                Cardinal.Down => Powered switch {
                    true => Waterlogged switch {
                        true => 33393,
                        false => 33394,
                    },
                    false => Waterlogged switch {
                        true => 33395,
                        false => 33396,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            33373 => new LightningRodBlock(Identifier, Cardinal.North, true, true),
            33374 => new LightningRodBlock(Identifier, Cardinal.North, true, false),
            33375 => new LightningRodBlock(Identifier, Cardinal.North, false, true),
            33376 => new LightningRodBlock(Identifier, Cardinal.North, false, false),
            33377 => new LightningRodBlock(Identifier, Cardinal.East, true, true),
            33378 => new LightningRodBlock(Identifier, Cardinal.East, true, false),
            33379 => new LightningRodBlock(Identifier, Cardinal.East, false, true),
            33380 => new LightningRodBlock(Identifier, Cardinal.East, false, false),
            33381 => new LightningRodBlock(Identifier, Cardinal.South, true, true),
            33382 => new LightningRodBlock(Identifier, Cardinal.South, true, false),
            33383 => new LightningRodBlock(Identifier, Cardinal.South, false, true),
            33384 => new LightningRodBlock(Identifier, Cardinal.South, false, false),
            33385 => new LightningRodBlock(Identifier, Cardinal.West, true, true),
            33386 => new LightningRodBlock(Identifier, Cardinal.West, true, false),
            33387 => new LightningRodBlock(Identifier, Cardinal.West, false, true),
            33388 => new LightningRodBlock(Identifier, Cardinal.West, false, false),
            33389 => new LightningRodBlock(Identifier, Cardinal.Up, true, true),
            33390 => new LightningRodBlock(Identifier, Cardinal.Up, true, false),
            33391 => new LightningRodBlock(Identifier, Cardinal.Up, false, true),
            33392 => new LightningRodBlock(Identifier, Cardinal.Up, false, false),
            33393 => new LightningRodBlock(Identifier, Cardinal.Down, true, true),
            33394 => new LightningRodBlock(Identifier, Cardinal.Down, true, false),
            33395 => new LightningRodBlock(Identifier, Cardinal.Down, false, true),
            33396 => new LightningRodBlock(Identifier, Cardinal.Down, false, false),
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
