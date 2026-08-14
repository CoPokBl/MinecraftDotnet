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
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.crimson_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:crimson_sign", BlockInfo.VanillaOnly, "minecraft:blocks/crimson_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 53, "nether_wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 21642];

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
                    true => 21642,
                    false => 21643,
                },
                1 => Waterlogged switch {
                    true => 21644,
                    false => 21645,
                },
                2 => Waterlogged switch {
                    true => 21646,
                    false => 21647,
                },
                3 => Waterlogged switch {
                    true => 21648,
                    false => 21649,
                },
                4 => Waterlogged switch {
                    true => 21650,
                    false => 21651,
                },
                5 => Waterlogged switch {
                    true => 21652,
                    false => 21653,
                },
                6 => Waterlogged switch {
                    true => 21654,
                    false => 21655,
                },
                7 => Waterlogged switch {
                    true => 21656,
                    false => 21657,
                },
                8 => Waterlogged switch {
                    true => 21658,
                    false => 21659,
                },
                9 => Waterlogged switch {
                    true => 21660,
                    false => 21661,
                },
                10 => Waterlogged switch {
                    true => 21662,
                    false => 21663,
                },
                11 => Waterlogged switch {
                    true => 21664,
                    false => 21665,
                },
                12 => Waterlogged switch {
                    true => 21666,
                    false => 21667,
                },
                13 => Waterlogged switch {
                    true => 21668,
                    false => 21669,
                },
                14 => Waterlogged switch {
                    true => 21670,
                    false => 21671,
                },
                15 => Waterlogged switch {
                    true => 21672,
                    false => 21673,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21642 => new CrimsonSignBlock(Identifier, 0, true),
            21643 => new CrimsonSignBlock(Identifier, 0, false),
            21644 => new CrimsonSignBlock(Identifier, 1, true),
            21645 => new CrimsonSignBlock(Identifier, 1, false),
            21646 => new CrimsonSignBlock(Identifier, 2, true),
            21647 => new CrimsonSignBlock(Identifier, 2, false),
            21648 => new CrimsonSignBlock(Identifier, 3, true),
            21649 => new CrimsonSignBlock(Identifier, 3, false),
            21650 => new CrimsonSignBlock(Identifier, 4, true),
            21651 => new CrimsonSignBlock(Identifier, 4, false),
            21652 => new CrimsonSignBlock(Identifier, 5, true),
            21653 => new CrimsonSignBlock(Identifier, 5, false),
            21654 => new CrimsonSignBlock(Identifier, 6, true),
            21655 => new CrimsonSignBlock(Identifier, 6, false),
            21656 => new CrimsonSignBlock(Identifier, 7, true),
            21657 => new CrimsonSignBlock(Identifier, 7, false),
            21658 => new CrimsonSignBlock(Identifier, 8, true),
            21659 => new CrimsonSignBlock(Identifier, 8, false),
            21660 => new CrimsonSignBlock(Identifier, 9, true),
            21661 => new CrimsonSignBlock(Identifier, 9, false),
            21662 => new CrimsonSignBlock(Identifier, 10, true),
            21663 => new CrimsonSignBlock(Identifier, 10, false),
            21664 => new CrimsonSignBlock(Identifier, 11, true),
            21665 => new CrimsonSignBlock(Identifier, 11, false),
            21666 => new CrimsonSignBlock(Identifier, 12, true),
            21667 => new CrimsonSignBlock(Identifier, 12, false),
            21668 => new CrimsonSignBlock(Identifier, 13, true),
            21669 => new CrimsonSignBlock(Identifier, 13, false),
            21670 => new CrimsonSignBlock(Identifier, 14, true),
            21671 => new CrimsonSignBlock(Identifier, 14, false),
            21672 => new CrimsonSignBlock(Identifier, 15, true),
            21673 => new CrimsonSignBlock(Identifier, 15, false),
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
