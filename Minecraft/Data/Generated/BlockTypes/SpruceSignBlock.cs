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
public record SpruceSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.spruce_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:spruce_sign", BlockInfo.VanillaOnly, "minecraft:blocks/spruce_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 34, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 6923];

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
                    true => 6923,
                    false => 6924,
                },
                1 => Waterlogged switch {
                    true => 6925,
                    false => 6926,
                },
                2 => Waterlogged switch {
                    true => 6927,
                    false => 6928,
                },
                3 => Waterlogged switch {
                    true => 6929,
                    false => 6930,
                },
                4 => Waterlogged switch {
                    true => 6931,
                    false => 6932,
                },
                5 => Waterlogged switch {
                    true => 6933,
                    false => 6934,
                },
                6 => Waterlogged switch {
                    true => 6935,
                    false => 6936,
                },
                7 => Waterlogged switch {
                    true => 6937,
                    false => 6938,
                },
                8 => Waterlogged switch {
                    true => 6939,
                    false => 6940,
                },
                9 => Waterlogged switch {
                    true => 6941,
                    false => 6942,
                },
                10 => Waterlogged switch {
                    true => 6943,
                    false => 6944,
                },
                11 => Waterlogged switch {
                    true => 6945,
                    false => 6946,
                },
                12 => Waterlogged switch {
                    true => 6947,
                    false => 6948,
                },
                13 => Waterlogged switch {
                    true => 6949,
                    false => 6950,
                },
                14 => Waterlogged switch {
                    true => 6951,
                    false => 6952,
                },
                15 => Waterlogged switch {
                    true => 6953,
                    false => 6954,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6923 => new SpruceSignBlock(Identifier, 0, true),
            6924 => new SpruceSignBlock(Identifier, 0, false),
            6925 => new SpruceSignBlock(Identifier, 1, true),
            6926 => new SpruceSignBlock(Identifier, 1, false),
            6927 => new SpruceSignBlock(Identifier, 2, true),
            6928 => new SpruceSignBlock(Identifier, 2, false),
            6929 => new SpruceSignBlock(Identifier, 3, true),
            6930 => new SpruceSignBlock(Identifier, 3, false),
            6931 => new SpruceSignBlock(Identifier, 4, true),
            6932 => new SpruceSignBlock(Identifier, 4, false),
            6933 => new SpruceSignBlock(Identifier, 5, true),
            6934 => new SpruceSignBlock(Identifier, 5, false),
            6935 => new SpruceSignBlock(Identifier, 6, true),
            6936 => new SpruceSignBlock(Identifier, 6, false),
            6937 => new SpruceSignBlock(Identifier, 7, true),
            6938 => new SpruceSignBlock(Identifier, 7, false),
            6939 => new SpruceSignBlock(Identifier, 8, true),
            6940 => new SpruceSignBlock(Identifier, 8, false),
            6941 => new SpruceSignBlock(Identifier, 9, true),
            6942 => new SpruceSignBlock(Identifier, 9, false),
            6943 => new SpruceSignBlock(Identifier, 10, true),
            6944 => new SpruceSignBlock(Identifier, 10, false),
            6945 => new SpruceSignBlock(Identifier, 11, true),
            6946 => new SpruceSignBlock(Identifier, 11, false),
            6947 => new SpruceSignBlock(Identifier, 12, true),
            6948 => new SpruceSignBlock(Identifier, 12, false),
            6949 => new SpruceSignBlock(Identifier, 13, true),
            6950 => new SpruceSignBlock(Identifier, 13, false),
            6951 => new SpruceSignBlock(Identifier, 14, true),
            6952 => new SpruceSignBlock(Identifier, 14, false),
            6953 => new SpruceSignBlock(Identifier, 15, true),
            6954 => new SpruceSignBlock(Identifier, 15, false),
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
