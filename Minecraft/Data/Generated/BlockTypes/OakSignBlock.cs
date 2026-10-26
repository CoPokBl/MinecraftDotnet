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
public record OakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.oak_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:oak_sign", BlockInfo.VanillaOnly, "minecraft:blocks/oak_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 6891];

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

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 6891,
                    false => 6892,
                },
                1 => Waterlogged switch {
                    true => 6893,
                    false => 6894,
                },
                2 => Waterlogged switch {
                    true => 6895,
                    false => 6896,
                },
                3 => Waterlogged switch {
                    true => 6897,
                    false => 6898,
                },
                4 => Waterlogged switch {
                    true => 6899,
                    false => 6900,
                },
                5 => Waterlogged switch {
                    true => 6901,
                    false => 6902,
                },
                6 => Waterlogged switch {
                    true => 6903,
                    false => 6904,
                },
                7 => Waterlogged switch {
                    true => 6905,
                    false => 6906,
                },
                8 => Waterlogged switch {
                    true => 6907,
                    false => 6908,
                },
                9 => Waterlogged switch {
                    true => 6909,
                    false => 6910,
                },
                10 => Waterlogged switch {
                    true => 6911,
                    false => 6912,
                },
                11 => Waterlogged switch {
                    true => 6913,
                    false => 6914,
                },
                12 => Waterlogged switch {
                    true => 6915,
                    false => 6916,
                },
                13 => Waterlogged switch {
                    true => 6917,
                    false => 6918,
                },
                14 => Waterlogged switch {
                    true => 6919,
                    false => 6920,
                },
                15 => Waterlogged switch {
                    true => 6921,
                    false => 6922,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6891 => new OakSignBlock(Identifier, 0, true),
            6892 => new OakSignBlock(Identifier, 0, false),
            6893 => new OakSignBlock(Identifier, 1, true),
            6894 => new OakSignBlock(Identifier, 1, false),
            6895 => new OakSignBlock(Identifier, 2, true),
            6896 => new OakSignBlock(Identifier, 2, false),
            6897 => new OakSignBlock(Identifier, 3, true),
            6898 => new OakSignBlock(Identifier, 3, false),
            6899 => new OakSignBlock(Identifier, 4, true),
            6900 => new OakSignBlock(Identifier, 4, false),
            6901 => new OakSignBlock(Identifier, 5, true),
            6902 => new OakSignBlock(Identifier, 5, false),
            6903 => new OakSignBlock(Identifier, 6, true),
            6904 => new OakSignBlock(Identifier, 6, false),
            6905 => new OakSignBlock(Identifier, 7, true),
            6906 => new OakSignBlock(Identifier, 7, false),
            6907 => new OakSignBlock(Identifier, 8, true),
            6908 => new OakSignBlock(Identifier, 8, false),
            6909 => new OakSignBlock(Identifier, 9, true),
            6910 => new OakSignBlock(Identifier, 9, false),
            6911 => new OakSignBlock(Identifier, 10, true),
            6912 => new OakSignBlock(Identifier, 10, false),
            6913 => new OakSignBlock(Identifier, 11, true),
            6914 => new OakSignBlock(Identifier, 11, false),
            6915 => new OakSignBlock(Identifier, 12, true),
            6916 => new OakSignBlock(Identifier, 12, false),
            6917 => new OakSignBlock(Identifier, 13, true),
            6918 => new OakSignBlock(Identifier, 13, false),
            6919 => new OakSignBlock(Identifier, 14, true),
            6920 => new OakSignBlock(Identifier, 14, false),
            6921 => new OakSignBlock(Identifier, 15, true),
            6922 => new OakSignBlock(Identifier, 15, false),
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
