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
public record BirchSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.birch_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:birch_sign", BlockInfo.VanillaOnly, "minecraft:blocks/birch_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 2, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 6955];

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
                    true => 6955,
                    false => 6956,
                },
                1 => Waterlogged switch {
                    true => 6957,
                    false => 6958,
                },
                2 => Waterlogged switch {
                    true => 6959,
                    false => 6960,
                },
                3 => Waterlogged switch {
                    true => 6961,
                    false => 6962,
                },
                4 => Waterlogged switch {
                    true => 6963,
                    false => 6964,
                },
                5 => Waterlogged switch {
                    true => 6965,
                    false => 6966,
                },
                6 => Waterlogged switch {
                    true => 6967,
                    false => 6968,
                },
                7 => Waterlogged switch {
                    true => 6969,
                    false => 6970,
                },
                8 => Waterlogged switch {
                    true => 6971,
                    false => 6972,
                },
                9 => Waterlogged switch {
                    true => 6973,
                    false => 6974,
                },
                10 => Waterlogged switch {
                    true => 6975,
                    false => 6976,
                },
                11 => Waterlogged switch {
                    true => 6977,
                    false => 6978,
                },
                12 => Waterlogged switch {
                    true => 6979,
                    false => 6980,
                },
                13 => Waterlogged switch {
                    true => 6981,
                    false => 6982,
                },
                14 => Waterlogged switch {
                    true => 6983,
                    false => 6984,
                },
                15 => Waterlogged switch {
                    true => 6985,
                    false => 6986,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6955 => new BirchSignBlock(Identifier, 0, true),
            6956 => new BirchSignBlock(Identifier, 0, false),
            6957 => new BirchSignBlock(Identifier, 1, true),
            6958 => new BirchSignBlock(Identifier, 1, false),
            6959 => new BirchSignBlock(Identifier, 2, true),
            6960 => new BirchSignBlock(Identifier, 2, false),
            6961 => new BirchSignBlock(Identifier, 3, true),
            6962 => new BirchSignBlock(Identifier, 3, false),
            6963 => new BirchSignBlock(Identifier, 4, true),
            6964 => new BirchSignBlock(Identifier, 4, false),
            6965 => new BirchSignBlock(Identifier, 5, true),
            6966 => new BirchSignBlock(Identifier, 5, false),
            6967 => new BirchSignBlock(Identifier, 6, true),
            6968 => new BirchSignBlock(Identifier, 6, false),
            6969 => new BirchSignBlock(Identifier, 7, true),
            6970 => new BirchSignBlock(Identifier, 7, false),
            6971 => new BirchSignBlock(Identifier, 8, true),
            6972 => new BirchSignBlock(Identifier, 8, false),
            6973 => new BirchSignBlock(Identifier, 9, true),
            6974 => new BirchSignBlock(Identifier, 9, false),
            6975 => new BirchSignBlock(Identifier, 10, true),
            6976 => new BirchSignBlock(Identifier, 10, false),
            6977 => new BirchSignBlock(Identifier, 11, true),
            6978 => new BirchSignBlock(Identifier, 11, false),
            6979 => new BirchSignBlock(Identifier, 12, true),
            6980 => new BirchSignBlock(Identifier, 12, false),
            6981 => new BirchSignBlock(Identifier, 13, true),
            6982 => new BirchSignBlock(Identifier, 13, false),
            6983 => new BirchSignBlock(Identifier, 14, true),
            6984 => new BirchSignBlock(Identifier, 14, false),
            6985 => new BirchSignBlock(Identifier, 15, true),
            6986 => new BirchSignBlock(Identifier, 15, false),
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
