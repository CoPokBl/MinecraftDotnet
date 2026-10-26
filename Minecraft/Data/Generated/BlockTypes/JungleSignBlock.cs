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
public record JungleSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.jungle_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:jungle_sign", BlockInfo.VanillaOnly, "minecraft:blocks/jungle_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 10, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7051];

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
                    true => 7051,
                    false => 7052,
                },
                1 => Waterlogged switch {
                    true => 7053,
                    false => 7054,
                },
                2 => Waterlogged switch {
                    true => 7055,
                    false => 7056,
                },
                3 => Waterlogged switch {
                    true => 7057,
                    false => 7058,
                },
                4 => Waterlogged switch {
                    true => 7059,
                    false => 7060,
                },
                5 => Waterlogged switch {
                    true => 7061,
                    false => 7062,
                },
                6 => Waterlogged switch {
                    true => 7063,
                    false => 7064,
                },
                7 => Waterlogged switch {
                    true => 7065,
                    false => 7066,
                },
                8 => Waterlogged switch {
                    true => 7067,
                    false => 7068,
                },
                9 => Waterlogged switch {
                    true => 7069,
                    false => 7070,
                },
                10 => Waterlogged switch {
                    true => 7071,
                    false => 7072,
                },
                11 => Waterlogged switch {
                    true => 7073,
                    false => 7074,
                },
                12 => Waterlogged switch {
                    true => 7075,
                    false => 7076,
                },
                13 => Waterlogged switch {
                    true => 7077,
                    false => 7078,
                },
                14 => Waterlogged switch {
                    true => 7079,
                    false => 7080,
                },
                15 => Waterlogged switch {
                    true => 7081,
                    false => 7082,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7051 => new JungleSignBlock(Identifier, 0, true),
            7052 => new JungleSignBlock(Identifier, 0, false),
            7053 => new JungleSignBlock(Identifier, 1, true),
            7054 => new JungleSignBlock(Identifier, 1, false),
            7055 => new JungleSignBlock(Identifier, 2, true),
            7056 => new JungleSignBlock(Identifier, 2, false),
            7057 => new JungleSignBlock(Identifier, 3, true),
            7058 => new JungleSignBlock(Identifier, 3, false),
            7059 => new JungleSignBlock(Identifier, 4, true),
            7060 => new JungleSignBlock(Identifier, 4, false),
            7061 => new JungleSignBlock(Identifier, 5, true),
            7062 => new JungleSignBlock(Identifier, 5, false),
            7063 => new JungleSignBlock(Identifier, 6, true),
            7064 => new JungleSignBlock(Identifier, 6, false),
            7065 => new JungleSignBlock(Identifier, 7, true),
            7066 => new JungleSignBlock(Identifier, 7, false),
            7067 => new JungleSignBlock(Identifier, 8, true),
            7068 => new JungleSignBlock(Identifier, 8, false),
            7069 => new JungleSignBlock(Identifier, 9, true),
            7070 => new JungleSignBlock(Identifier, 9, false),
            7071 => new JungleSignBlock(Identifier, 10, true),
            7072 => new JungleSignBlock(Identifier, 10, false),
            7073 => new JungleSignBlock(Identifier, 11, true),
            7074 => new JungleSignBlock(Identifier, 11, false),
            7075 => new JungleSignBlock(Identifier, 12, true),
            7076 => new JungleSignBlock(Identifier, 12, false),
            7077 => new JungleSignBlock(Identifier, 13, true),
            7078 => new JungleSignBlock(Identifier, 13, false),
            7079 => new JungleSignBlock(Identifier, 14, true),
            7080 => new JungleSignBlock(Identifier, 14, false),
            7081 => new JungleSignBlock(Identifier, 15, true),
            7082 => new JungleSignBlock(Identifier, 15, false),
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
