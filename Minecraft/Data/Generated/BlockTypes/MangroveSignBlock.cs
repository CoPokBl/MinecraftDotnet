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
public record MangroveSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.mangrove_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:mangrove_sign", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 28, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7147];

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
                    true => 7147,
                    false => 7148,
                },
                1 => Waterlogged switch {
                    true => 7149,
                    false => 7150,
                },
                2 => Waterlogged switch {
                    true => 7151,
                    false => 7152,
                },
                3 => Waterlogged switch {
                    true => 7153,
                    false => 7154,
                },
                4 => Waterlogged switch {
                    true => 7155,
                    false => 7156,
                },
                5 => Waterlogged switch {
                    true => 7157,
                    false => 7158,
                },
                6 => Waterlogged switch {
                    true => 7159,
                    false => 7160,
                },
                7 => Waterlogged switch {
                    true => 7161,
                    false => 7162,
                },
                8 => Waterlogged switch {
                    true => 7163,
                    false => 7164,
                },
                9 => Waterlogged switch {
                    true => 7165,
                    false => 7166,
                },
                10 => Waterlogged switch {
                    true => 7167,
                    false => 7168,
                },
                11 => Waterlogged switch {
                    true => 7169,
                    false => 7170,
                },
                12 => Waterlogged switch {
                    true => 7171,
                    false => 7172,
                },
                13 => Waterlogged switch {
                    true => 7173,
                    false => 7174,
                },
                14 => Waterlogged switch {
                    true => 7175,
                    false => 7176,
                },
                15 => Waterlogged switch {
                    true => 7177,
                    false => 7178,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7147 => new MangroveSignBlock(Identifier, 0, true),
            7148 => new MangroveSignBlock(Identifier, 0, false),
            7149 => new MangroveSignBlock(Identifier, 1, true),
            7150 => new MangroveSignBlock(Identifier, 1, false),
            7151 => new MangroveSignBlock(Identifier, 2, true),
            7152 => new MangroveSignBlock(Identifier, 2, false),
            7153 => new MangroveSignBlock(Identifier, 3, true),
            7154 => new MangroveSignBlock(Identifier, 3, false),
            7155 => new MangroveSignBlock(Identifier, 4, true),
            7156 => new MangroveSignBlock(Identifier, 4, false),
            7157 => new MangroveSignBlock(Identifier, 5, true),
            7158 => new MangroveSignBlock(Identifier, 5, false),
            7159 => new MangroveSignBlock(Identifier, 6, true),
            7160 => new MangroveSignBlock(Identifier, 6, false),
            7161 => new MangroveSignBlock(Identifier, 7, true),
            7162 => new MangroveSignBlock(Identifier, 7, false),
            7163 => new MangroveSignBlock(Identifier, 8, true),
            7164 => new MangroveSignBlock(Identifier, 8, false),
            7165 => new MangroveSignBlock(Identifier, 9, true),
            7166 => new MangroveSignBlock(Identifier, 9, false),
            7167 => new MangroveSignBlock(Identifier, 10, true),
            7168 => new MangroveSignBlock(Identifier, 10, false),
            7169 => new MangroveSignBlock(Identifier, 11, true),
            7170 => new MangroveSignBlock(Identifier, 11, false),
            7171 => new MangroveSignBlock(Identifier, 12, true),
            7172 => new MangroveSignBlock(Identifier, 12, false),
            7173 => new MangroveSignBlock(Identifier, 13, true),
            7174 => new MangroveSignBlock(Identifier, 13, false),
            7175 => new MangroveSignBlock(Identifier, 14, true),
            7176 => new MangroveSignBlock(Identifier, 14, false),
            7177 => new MangroveSignBlock(Identifier, 15, true),
            7178 => new MangroveSignBlock(Identifier, 15, false),
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
