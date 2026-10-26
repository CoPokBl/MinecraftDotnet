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
public record DarkOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.dark_oak_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:dark_oak_sign", BlockInfo.VanillaOnly, "minecraft:blocks/dark_oak_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 26, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7083];

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
                    true => 7083,
                    false => 7084,
                },
                1 => Waterlogged switch {
                    true => 7085,
                    false => 7086,
                },
                2 => Waterlogged switch {
                    true => 7087,
                    false => 7088,
                },
                3 => Waterlogged switch {
                    true => 7089,
                    false => 7090,
                },
                4 => Waterlogged switch {
                    true => 7091,
                    false => 7092,
                },
                5 => Waterlogged switch {
                    true => 7093,
                    false => 7094,
                },
                6 => Waterlogged switch {
                    true => 7095,
                    false => 7096,
                },
                7 => Waterlogged switch {
                    true => 7097,
                    false => 7098,
                },
                8 => Waterlogged switch {
                    true => 7099,
                    false => 7100,
                },
                9 => Waterlogged switch {
                    true => 7101,
                    false => 7102,
                },
                10 => Waterlogged switch {
                    true => 7103,
                    false => 7104,
                },
                11 => Waterlogged switch {
                    true => 7105,
                    false => 7106,
                },
                12 => Waterlogged switch {
                    true => 7107,
                    false => 7108,
                },
                13 => Waterlogged switch {
                    true => 7109,
                    false => 7110,
                },
                14 => Waterlogged switch {
                    true => 7111,
                    false => 7112,
                },
                15 => Waterlogged switch {
                    true => 7113,
                    false => 7114,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7083 => new DarkOakSignBlock(Identifier, 0, true),
            7084 => new DarkOakSignBlock(Identifier, 0, false),
            7085 => new DarkOakSignBlock(Identifier, 1, true),
            7086 => new DarkOakSignBlock(Identifier, 1, false),
            7087 => new DarkOakSignBlock(Identifier, 2, true),
            7088 => new DarkOakSignBlock(Identifier, 2, false),
            7089 => new DarkOakSignBlock(Identifier, 3, true),
            7090 => new DarkOakSignBlock(Identifier, 3, false),
            7091 => new DarkOakSignBlock(Identifier, 4, true),
            7092 => new DarkOakSignBlock(Identifier, 4, false),
            7093 => new DarkOakSignBlock(Identifier, 5, true),
            7094 => new DarkOakSignBlock(Identifier, 5, false),
            7095 => new DarkOakSignBlock(Identifier, 6, true),
            7096 => new DarkOakSignBlock(Identifier, 6, false),
            7097 => new DarkOakSignBlock(Identifier, 7, true),
            7098 => new DarkOakSignBlock(Identifier, 7, false),
            7099 => new DarkOakSignBlock(Identifier, 8, true),
            7100 => new DarkOakSignBlock(Identifier, 8, false),
            7101 => new DarkOakSignBlock(Identifier, 9, true),
            7102 => new DarkOakSignBlock(Identifier, 9, false),
            7103 => new DarkOakSignBlock(Identifier, 10, true),
            7104 => new DarkOakSignBlock(Identifier, 10, false),
            7105 => new DarkOakSignBlock(Identifier, 11, true),
            7106 => new DarkOakSignBlock(Identifier, 11, false),
            7107 => new DarkOakSignBlock(Identifier, 12, true),
            7108 => new DarkOakSignBlock(Identifier, 12, false),
            7109 => new DarkOakSignBlock(Identifier, 13, true),
            7110 => new DarkOakSignBlock(Identifier, 13, false),
            7111 => new DarkOakSignBlock(Identifier, 14, true),
            7112 => new DarkOakSignBlock(Identifier, 14, false),
            7113 => new DarkOakSignBlock(Identifier, 15, true),
            7114 => new DarkOakSignBlock(Identifier, 15, false),
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
