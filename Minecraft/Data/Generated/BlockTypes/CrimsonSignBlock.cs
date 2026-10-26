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
public record CrimsonSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.crimson_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:crimson_sign", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 53, "nether_wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 24999];

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
                    true => 24999,
                    false => 25000,
                },
                1 => Waterlogged switch {
                    true => 25001,
                    false => 25002,
                },
                2 => Waterlogged switch {
                    true => 25003,
                    false => 25004,
                },
                3 => Waterlogged switch {
                    true => 25005,
                    false => 25006,
                },
                4 => Waterlogged switch {
                    true => 25007,
                    false => 25008,
                },
                5 => Waterlogged switch {
                    true => 25009,
                    false => 25010,
                },
                6 => Waterlogged switch {
                    true => 25011,
                    false => 25012,
                },
                7 => Waterlogged switch {
                    true => 25013,
                    false => 25014,
                },
                8 => Waterlogged switch {
                    true => 25015,
                    false => 25016,
                },
                9 => Waterlogged switch {
                    true => 25017,
                    false => 25018,
                },
                10 => Waterlogged switch {
                    true => 25019,
                    false => 25020,
                },
                11 => Waterlogged switch {
                    true => 25021,
                    false => 25022,
                },
                12 => Waterlogged switch {
                    true => 25023,
                    false => 25024,
                },
                13 => Waterlogged switch {
                    true => 25025,
                    false => 25026,
                },
                14 => Waterlogged switch {
                    true => 25027,
                    false => 25028,
                },
                15 => Waterlogged switch {
                    true => 25029,
                    false => 25030,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24999 => new CrimsonSignBlock(Identifier, 0, true),
            25000 => new CrimsonSignBlock(Identifier, 0, false),
            25001 => new CrimsonSignBlock(Identifier, 1, true),
            25002 => new CrimsonSignBlock(Identifier, 1, false),
            25003 => new CrimsonSignBlock(Identifier, 2, true),
            25004 => new CrimsonSignBlock(Identifier, 2, false),
            25005 => new CrimsonSignBlock(Identifier, 3, true),
            25006 => new CrimsonSignBlock(Identifier, 3, false),
            25007 => new CrimsonSignBlock(Identifier, 4, true),
            25008 => new CrimsonSignBlock(Identifier, 4, false),
            25009 => new CrimsonSignBlock(Identifier, 5, true),
            25010 => new CrimsonSignBlock(Identifier, 5, false),
            25011 => new CrimsonSignBlock(Identifier, 6, true),
            25012 => new CrimsonSignBlock(Identifier, 6, false),
            25013 => new CrimsonSignBlock(Identifier, 7, true),
            25014 => new CrimsonSignBlock(Identifier, 7, false),
            25015 => new CrimsonSignBlock(Identifier, 8, true),
            25016 => new CrimsonSignBlock(Identifier, 8, false),
            25017 => new CrimsonSignBlock(Identifier, 9, true),
            25018 => new CrimsonSignBlock(Identifier, 9, false),
            25019 => new CrimsonSignBlock(Identifier, 10, true),
            25020 => new CrimsonSignBlock(Identifier, 10, false),
            25021 => new CrimsonSignBlock(Identifier, 11, true),
            25022 => new CrimsonSignBlock(Identifier, 11, false),
            25023 => new CrimsonSignBlock(Identifier, 12, true),
            25024 => new CrimsonSignBlock(Identifier, 12, false),
            25025 => new CrimsonSignBlock(Identifier, 13, true),
            25026 => new CrimsonSignBlock(Identifier, 13, false),
            25027 => new CrimsonSignBlock(Identifier, 14, true),
            25028 => new CrimsonSignBlock(Identifier, 14, false),
            25029 => new CrimsonSignBlock(Identifier, 15, true),
            25030 => new CrimsonSignBlock(Identifier, 15, false),
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
