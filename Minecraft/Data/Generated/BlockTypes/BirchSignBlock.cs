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
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.birch_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:birch_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 2, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5399];

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
                    true => 5399,
                    false => 5400,
                },
                1 => Waterlogged switch {
                    true => 5401,
                    false => 5402,
                },
                2 => Waterlogged switch {
                    true => 5403,
                    false => 5404,
                },
                3 => Waterlogged switch {
                    true => 5405,
                    false => 5406,
                },
                4 => Waterlogged switch {
                    true => 5407,
                    false => 5408,
                },
                5 => Waterlogged switch {
                    true => 5409,
                    false => 5410,
                },
                6 => Waterlogged switch {
                    true => 5411,
                    false => 5412,
                },
                7 => Waterlogged switch {
                    true => 5413,
                    false => 5414,
                },
                8 => Waterlogged switch {
                    true => 5415,
                    false => 5416,
                },
                9 => Waterlogged switch {
                    true => 5417,
                    false => 5418,
                },
                10 => Waterlogged switch {
                    true => 5419,
                    false => 5420,
                },
                11 => Waterlogged switch {
                    true => 5421,
                    false => 5422,
                },
                12 => Waterlogged switch {
                    true => 5423,
                    false => 5424,
                },
                13 => Waterlogged switch {
                    true => 5425,
                    false => 5426,
                },
                14 => Waterlogged switch {
                    true => 5427,
                    false => 5428,
                },
                15 => Waterlogged switch {
                    true => 5429,
                    false => 5430,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5399 => new BirchSignBlock(Identifier, 0, true),
            5400 => new BirchSignBlock(Identifier, 0, false),
            5401 => new BirchSignBlock(Identifier, 1, true),
            5402 => new BirchSignBlock(Identifier, 1, false),
            5403 => new BirchSignBlock(Identifier, 2, true),
            5404 => new BirchSignBlock(Identifier, 2, false),
            5405 => new BirchSignBlock(Identifier, 3, true),
            5406 => new BirchSignBlock(Identifier, 3, false),
            5407 => new BirchSignBlock(Identifier, 4, true),
            5408 => new BirchSignBlock(Identifier, 4, false),
            5409 => new BirchSignBlock(Identifier, 5, true),
            5410 => new BirchSignBlock(Identifier, 5, false),
            5411 => new BirchSignBlock(Identifier, 6, true),
            5412 => new BirchSignBlock(Identifier, 6, false),
            5413 => new BirchSignBlock(Identifier, 7, true),
            5414 => new BirchSignBlock(Identifier, 7, false),
            5415 => new BirchSignBlock(Identifier, 8, true),
            5416 => new BirchSignBlock(Identifier, 8, false),
            5417 => new BirchSignBlock(Identifier, 9, true),
            5418 => new BirchSignBlock(Identifier, 9, false),
            5419 => new BirchSignBlock(Identifier, 10, true),
            5420 => new BirchSignBlock(Identifier, 10, false),
            5421 => new BirchSignBlock(Identifier, 11, true),
            5422 => new BirchSignBlock(Identifier, 11, false),
            5423 => new BirchSignBlock(Identifier, 12, true),
            5424 => new BirchSignBlock(Identifier, 12, false),
            5425 => new BirchSignBlock(Identifier, 13, true),
            5426 => new BirchSignBlock(Identifier, 13, false),
            5427 => new BirchSignBlock(Identifier, 14, true),
            5428 => new BirchSignBlock(Identifier, 14, false),
            5429 => new BirchSignBlock(Identifier, 15, true),
            5430 => new BirchSignBlock(Identifier, 15, false),
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
