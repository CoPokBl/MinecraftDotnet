using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.acacia_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:acacia_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 15, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5431];

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
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5431,
                    false => 5432,
                },
                1 => Waterlogged switch {
                    true => 5433,
                    false => 5434,
                },
                2 => Waterlogged switch {
                    true => 5435,
                    false => 5436,
                },
                3 => Waterlogged switch {
                    true => 5437,
                    false => 5438,
                },
                4 => Waterlogged switch {
                    true => 5439,
                    false => 5440,
                },
                5 => Waterlogged switch {
                    true => 5441,
                    false => 5442,
                },
                6 => Waterlogged switch {
                    true => 5443,
                    false => 5444,
                },
                7 => Waterlogged switch {
                    true => 5445,
                    false => 5446,
                },
                8 => Waterlogged switch {
                    true => 5447,
                    false => 5448,
                },
                9 => Waterlogged switch {
                    true => 5449,
                    false => 5450,
                },
                10 => Waterlogged switch {
                    true => 5451,
                    false => 5452,
                },
                11 => Waterlogged switch {
                    true => 5453,
                    false => 5454,
                },
                12 => Waterlogged switch {
                    true => 5455,
                    false => 5456,
                },
                13 => Waterlogged switch {
                    true => 5457,
                    false => 5458,
                },
                14 => Waterlogged switch {
                    true => 5459,
                    false => 5460,
                },
                15 => Waterlogged switch {
                    true => 5461,
                    false => 5462,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5431 => new AcaciaSignBlock(Identifier, 0, true),
            5432 => new AcaciaSignBlock(Identifier, 0, false),
            5433 => new AcaciaSignBlock(Identifier, 1, true),
            5434 => new AcaciaSignBlock(Identifier, 1, false),
            5435 => new AcaciaSignBlock(Identifier, 2, true),
            5436 => new AcaciaSignBlock(Identifier, 2, false),
            5437 => new AcaciaSignBlock(Identifier, 3, true),
            5438 => new AcaciaSignBlock(Identifier, 3, false),
            5439 => new AcaciaSignBlock(Identifier, 4, true),
            5440 => new AcaciaSignBlock(Identifier, 4, false),
            5441 => new AcaciaSignBlock(Identifier, 5, true),
            5442 => new AcaciaSignBlock(Identifier, 5, false),
            5443 => new AcaciaSignBlock(Identifier, 6, true),
            5444 => new AcaciaSignBlock(Identifier, 6, false),
            5445 => new AcaciaSignBlock(Identifier, 7, true),
            5446 => new AcaciaSignBlock(Identifier, 7, false),
            5447 => new AcaciaSignBlock(Identifier, 8, true),
            5448 => new AcaciaSignBlock(Identifier, 8, false),
            5449 => new AcaciaSignBlock(Identifier, 9, true),
            5450 => new AcaciaSignBlock(Identifier, 9, false),
            5451 => new AcaciaSignBlock(Identifier, 10, true),
            5452 => new AcaciaSignBlock(Identifier, 10, false),
            5453 => new AcaciaSignBlock(Identifier, 11, true),
            5454 => new AcaciaSignBlock(Identifier, 11, false),
            5455 => new AcaciaSignBlock(Identifier, 12, true),
            5456 => new AcaciaSignBlock(Identifier, 12, false),
            5457 => new AcaciaSignBlock(Identifier, 13, true),
            5458 => new AcaciaSignBlock(Identifier, 13, false),
            5459 => new AcaciaSignBlock(Identifier, 14, true),
            5460 => new AcaciaSignBlock(Identifier, 14, false),
            5461 => new AcaciaSignBlock(Identifier, 15, true),
            5462 => new AcaciaSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
