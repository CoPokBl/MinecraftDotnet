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
public record CherrySignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.cherry_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:cherry_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 36, "cherry_wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5463];

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
                    true => 5463,
                    false => 5464,
                },
                1 => Waterlogged switch {
                    true => 5465,
                    false => 5466,
                },
                2 => Waterlogged switch {
                    true => 5467,
                    false => 5468,
                },
                3 => Waterlogged switch {
                    true => 5469,
                    false => 5470,
                },
                4 => Waterlogged switch {
                    true => 5471,
                    false => 5472,
                },
                5 => Waterlogged switch {
                    true => 5473,
                    false => 5474,
                },
                6 => Waterlogged switch {
                    true => 5475,
                    false => 5476,
                },
                7 => Waterlogged switch {
                    true => 5477,
                    false => 5478,
                },
                8 => Waterlogged switch {
                    true => 5479,
                    false => 5480,
                },
                9 => Waterlogged switch {
                    true => 5481,
                    false => 5482,
                },
                10 => Waterlogged switch {
                    true => 5483,
                    false => 5484,
                },
                11 => Waterlogged switch {
                    true => 5485,
                    false => 5486,
                },
                12 => Waterlogged switch {
                    true => 5487,
                    false => 5488,
                },
                13 => Waterlogged switch {
                    true => 5489,
                    false => 5490,
                },
                14 => Waterlogged switch {
                    true => 5491,
                    false => 5492,
                },
                15 => Waterlogged switch {
                    true => 5493,
                    false => 5494,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5463 => new CherrySignBlock(Identifier, 0, true),
            5464 => new CherrySignBlock(Identifier, 0, false),
            5465 => new CherrySignBlock(Identifier, 1, true),
            5466 => new CherrySignBlock(Identifier, 1, false),
            5467 => new CherrySignBlock(Identifier, 2, true),
            5468 => new CherrySignBlock(Identifier, 2, false),
            5469 => new CherrySignBlock(Identifier, 3, true),
            5470 => new CherrySignBlock(Identifier, 3, false),
            5471 => new CherrySignBlock(Identifier, 4, true),
            5472 => new CherrySignBlock(Identifier, 4, false),
            5473 => new CherrySignBlock(Identifier, 5, true),
            5474 => new CherrySignBlock(Identifier, 5, false),
            5475 => new CherrySignBlock(Identifier, 6, true),
            5476 => new CherrySignBlock(Identifier, 6, false),
            5477 => new CherrySignBlock(Identifier, 7, true),
            5478 => new CherrySignBlock(Identifier, 7, false),
            5479 => new CherrySignBlock(Identifier, 8, true),
            5480 => new CherrySignBlock(Identifier, 8, false),
            5481 => new CherrySignBlock(Identifier, 9, true),
            5482 => new CherrySignBlock(Identifier, 9, false),
            5483 => new CherrySignBlock(Identifier, 10, true),
            5484 => new CherrySignBlock(Identifier, 10, false),
            5485 => new CherrySignBlock(Identifier, 11, true),
            5486 => new CherrySignBlock(Identifier, 11, false),
            5487 => new CherrySignBlock(Identifier, 12, true),
            5488 => new CherrySignBlock(Identifier, 12, false),
            5489 => new CherrySignBlock(Identifier, 13, true),
            5490 => new CherrySignBlock(Identifier, 13, false),
            5491 => new CherrySignBlock(Identifier, 14, true),
            5492 => new CherrySignBlock(Identifier, 14, false),
            5493 => new CherrySignBlock(Identifier, 15, true),
            5494 => new CherrySignBlock(Identifier, 15, false),
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
