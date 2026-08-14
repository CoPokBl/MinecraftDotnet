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
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.oak_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:oak_sign", BlockInfo.VanillaOnly, "minecraft:blocks/oak_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5335];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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
                    true => 5335,
                    false => 5336,
                },
                1 => Waterlogged switch {
                    true => 5337,
                    false => 5338,
                },
                2 => Waterlogged switch {
                    true => 5339,
                    false => 5340,
                },
                3 => Waterlogged switch {
                    true => 5341,
                    false => 5342,
                },
                4 => Waterlogged switch {
                    true => 5343,
                    false => 5344,
                },
                5 => Waterlogged switch {
                    true => 5345,
                    false => 5346,
                },
                6 => Waterlogged switch {
                    true => 5347,
                    false => 5348,
                },
                7 => Waterlogged switch {
                    true => 5349,
                    false => 5350,
                },
                8 => Waterlogged switch {
                    true => 5351,
                    false => 5352,
                },
                9 => Waterlogged switch {
                    true => 5353,
                    false => 5354,
                },
                10 => Waterlogged switch {
                    true => 5355,
                    false => 5356,
                },
                11 => Waterlogged switch {
                    true => 5357,
                    false => 5358,
                },
                12 => Waterlogged switch {
                    true => 5359,
                    false => 5360,
                },
                13 => Waterlogged switch {
                    true => 5361,
                    false => 5362,
                },
                14 => Waterlogged switch {
                    true => 5363,
                    false => 5364,
                },
                15 => Waterlogged switch {
                    true => 5365,
                    false => 5366,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5335 => new OakSignBlock(Identifier, 0, true),
            5336 => new OakSignBlock(Identifier, 0, false),
            5337 => new OakSignBlock(Identifier, 1, true),
            5338 => new OakSignBlock(Identifier, 1, false),
            5339 => new OakSignBlock(Identifier, 2, true),
            5340 => new OakSignBlock(Identifier, 2, false),
            5341 => new OakSignBlock(Identifier, 3, true),
            5342 => new OakSignBlock(Identifier, 3, false),
            5343 => new OakSignBlock(Identifier, 4, true),
            5344 => new OakSignBlock(Identifier, 4, false),
            5345 => new OakSignBlock(Identifier, 5, true),
            5346 => new OakSignBlock(Identifier, 5, false),
            5347 => new OakSignBlock(Identifier, 6, true),
            5348 => new OakSignBlock(Identifier, 6, false),
            5349 => new OakSignBlock(Identifier, 7, true),
            5350 => new OakSignBlock(Identifier, 7, false),
            5351 => new OakSignBlock(Identifier, 8, true),
            5352 => new OakSignBlock(Identifier, 8, false),
            5353 => new OakSignBlock(Identifier, 9, true),
            5354 => new OakSignBlock(Identifier, 9, false),
            5355 => new OakSignBlock(Identifier, 10, true),
            5356 => new OakSignBlock(Identifier, 10, false),
            5357 => new OakSignBlock(Identifier, 11, true),
            5358 => new OakSignBlock(Identifier, 11, false),
            5359 => new OakSignBlock(Identifier, 12, true),
            5360 => new OakSignBlock(Identifier, 12, false),
            5361 => new OakSignBlock(Identifier, 13, true),
            5362 => new OakSignBlock(Identifier, 13, false),
            5363 => new OakSignBlock(Identifier, 14, true),
            5364 => new OakSignBlock(Identifier, 14, false),
            5365 => new OakSignBlock(Identifier, 15, true),
            5366 => new OakSignBlock(Identifier, 15, false),
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
