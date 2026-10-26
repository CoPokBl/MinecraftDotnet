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
public record AcaciaSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.acacia_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:acacia_sign", BlockInfo.VanillaOnly, "minecraft:blocks/acacia_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 15, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 6987];

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
                    true => 6987,
                    false => 6988,
                },
                1 => Waterlogged switch {
                    true => 6989,
                    false => 6990,
                },
                2 => Waterlogged switch {
                    true => 6991,
                    false => 6992,
                },
                3 => Waterlogged switch {
                    true => 6993,
                    false => 6994,
                },
                4 => Waterlogged switch {
                    true => 6995,
                    false => 6996,
                },
                5 => Waterlogged switch {
                    true => 6997,
                    false => 6998,
                },
                6 => Waterlogged switch {
                    true => 6999,
                    false => 7000,
                },
                7 => Waterlogged switch {
                    true => 7001,
                    false => 7002,
                },
                8 => Waterlogged switch {
                    true => 7003,
                    false => 7004,
                },
                9 => Waterlogged switch {
                    true => 7005,
                    false => 7006,
                },
                10 => Waterlogged switch {
                    true => 7007,
                    false => 7008,
                },
                11 => Waterlogged switch {
                    true => 7009,
                    false => 7010,
                },
                12 => Waterlogged switch {
                    true => 7011,
                    false => 7012,
                },
                13 => Waterlogged switch {
                    true => 7013,
                    false => 7014,
                },
                14 => Waterlogged switch {
                    true => 7015,
                    false => 7016,
                },
                15 => Waterlogged switch {
                    true => 7017,
                    false => 7018,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6987 => new AcaciaSignBlock(Identifier, 0, true),
            6988 => new AcaciaSignBlock(Identifier, 0, false),
            6989 => new AcaciaSignBlock(Identifier, 1, true),
            6990 => new AcaciaSignBlock(Identifier, 1, false),
            6991 => new AcaciaSignBlock(Identifier, 2, true),
            6992 => new AcaciaSignBlock(Identifier, 2, false),
            6993 => new AcaciaSignBlock(Identifier, 3, true),
            6994 => new AcaciaSignBlock(Identifier, 3, false),
            6995 => new AcaciaSignBlock(Identifier, 4, true),
            6996 => new AcaciaSignBlock(Identifier, 4, false),
            6997 => new AcaciaSignBlock(Identifier, 5, true),
            6998 => new AcaciaSignBlock(Identifier, 5, false),
            6999 => new AcaciaSignBlock(Identifier, 6, true),
            7000 => new AcaciaSignBlock(Identifier, 6, false),
            7001 => new AcaciaSignBlock(Identifier, 7, true),
            7002 => new AcaciaSignBlock(Identifier, 7, false),
            7003 => new AcaciaSignBlock(Identifier, 8, true),
            7004 => new AcaciaSignBlock(Identifier, 8, false),
            7005 => new AcaciaSignBlock(Identifier, 9, true),
            7006 => new AcaciaSignBlock(Identifier, 9, false),
            7007 => new AcaciaSignBlock(Identifier, 10, true),
            7008 => new AcaciaSignBlock(Identifier, 10, false),
            7009 => new AcaciaSignBlock(Identifier, 11, true),
            7010 => new AcaciaSignBlock(Identifier, 11, false),
            7011 => new AcaciaSignBlock(Identifier, 12, true),
            7012 => new AcaciaSignBlock(Identifier, 12, false),
            7013 => new AcaciaSignBlock(Identifier, 13, true),
            7014 => new AcaciaSignBlock(Identifier, 13, false),
            7015 => new AcaciaSignBlock(Identifier, 14, true),
            7016 => new AcaciaSignBlock(Identifier, 14, false),
            7017 => new AcaciaSignBlock(Identifier, 15, true),
            7018 => new AcaciaSignBlock(Identifier, 15, false),
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
