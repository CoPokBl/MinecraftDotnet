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
public record PoplarSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.poplar_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:poplar_sign", BlockInfo.VanillaOnly, "minecraft:blocks/poplar_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 22, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7179];

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
                    true => 7179,
                    false => 7180,
                },
                1 => Waterlogged switch {
                    true => 7181,
                    false => 7182,
                },
                2 => Waterlogged switch {
                    true => 7183,
                    false => 7184,
                },
                3 => Waterlogged switch {
                    true => 7185,
                    false => 7186,
                },
                4 => Waterlogged switch {
                    true => 7187,
                    false => 7188,
                },
                5 => Waterlogged switch {
                    true => 7189,
                    false => 7190,
                },
                6 => Waterlogged switch {
                    true => 7191,
                    false => 7192,
                },
                7 => Waterlogged switch {
                    true => 7193,
                    false => 7194,
                },
                8 => Waterlogged switch {
                    true => 7195,
                    false => 7196,
                },
                9 => Waterlogged switch {
                    true => 7197,
                    false => 7198,
                },
                10 => Waterlogged switch {
                    true => 7199,
                    false => 7200,
                },
                11 => Waterlogged switch {
                    true => 7201,
                    false => 7202,
                },
                12 => Waterlogged switch {
                    true => 7203,
                    false => 7204,
                },
                13 => Waterlogged switch {
                    true => 7205,
                    false => 7206,
                },
                14 => Waterlogged switch {
                    true => 7207,
                    false => 7208,
                },
                15 => Waterlogged switch {
                    true => 7209,
                    false => 7210,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7179 => new PoplarSignBlock(Identifier, 0, true),
            7180 => new PoplarSignBlock(Identifier, 0, false),
            7181 => new PoplarSignBlock(Identifier, 1, true),
            7182 => new PoplarSignBlock(Identifier, 1, false),
            7183 => new PoplarSignBlock(Identifier, 2, true),
            7184 => new PoplarSignBlock(Identifier, 2, false),
            7185 => new PoplarSignBlock(Identifier, 3, true),
            7186 => new PoplarSignBlock(Identifier, 3, false),
            7187 => new PoplarSignBlock(Identifier, 4, true),
            7188 => new PoplarSignBlock(Identifier, 4, false),
            7189 => new PoplarSignBlock(Identifier, 5, true),
            7190 => new PoplarSignBlock(Identifier, 5, false),
            7191 => new PoplarSignBlock(Identifier, 6, true),
            7192 => new PoplarSignBlock(Identifier, 6, false),
            7193 => new PoplarSignBlock(Identifier, 7, true),
            7194 => new PoplarSignBlock(Identifier, 7, false),
            7195 => new PoplarSignBlock(Identifier, 8, true),
            7196 => new PoplarSignBlock(Identifier, 8, false),
            7197 => new PoplarSignBlock(Identifier, 9, true),
            7198 => new PoplarSignBlock(Identifier, 9, false),
            7199 => new PoplarSignBlock(Identifier, 10, true),
            7200 => new PoplarSignBlock(Identifier, 10, false),
            7201 => new PoplarSignBlock(Identifier, 11, true),
            7202 => new PoplarSignBlock(Identifier, 11, false),
            7203 => new PoplarSignBlock(Identifier, 12, true),
            7204 => new PoplarSignBlock(Identifier, 12, false),
            7205 => new PoplarSignBlock(Identifier, 13, true),
            7206 => new PoplarSignBlock(Identifier, 13, false),
            7207 => new PoplarSignBlock(Identifier, 14, true),
            7208 => new PoplarSignBlock(Identifier, 14, false),
            7209 => new PoplarSignBlock(Identifier, 15, true),
            7210 => new PoplarSignBlock(Identifier, 15, false),
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
