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
    private static readonly BlockInfo Data = new("block.minecraft.cherry_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:cherry_sign", BlockInfo.VanillaOnly, "minecraft:blocks/cherry_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 36, "cherry_wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7019];

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
                    true => 7019,
                    false => 7020,
                },
                1 => Waterlogged switch {
                    true => 7021,
                    false => 7022,
                },
                2 => Waterlogged switch {
                    true => 7023,
                    false => 7024,
                },
                3 => Waterlogged switch {
                    true => 7025,
                    false => 7026,
                },
                4 => Waterlogged switch {
                    true => 7027,
                    false => 7028,
                },
                5 => Waterlogged switch {
                    true => 7029,
                    false => 7030,
                },
                6 => Waterlogged switch {
                    true => 7031,
                    false => 7032,
                },
                7 => Waterlogged switch {
                    true => 7033,
                    false => 7034,
                },
                8 => Waterlogged switch {
                    true => 7035,
                    false => 7036,
                },
                9 => Waterlogged switch {
                    true => 7037,
                    false => 7038,
                },
                10 => Waterlogged switch {
                    true => 7039,
                    false => 7040,
                },
                11 => Waterlogged switch {
                    true => 7041,
                    false => 7042,
                },
                12 => Waterlogged switch {
                    true => 7043,
                    false => 7044,
                },
                13 => Waterlogged switch {
                    true => 7045,
                    false => 7046,
                },
                14 => Waterlogged switch {
                    true => 7047,
                    false => 7048,
                },
                15 => Waterlogged switch {
                    true => 7049,
                    false => 7050,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7019 => new CherrySignBlock(Identifier, 0, true),
            7020 => new CherrySignBlock(Identifier, 0, false),
            7021 => new CherrySignBlock(Identifier, 1, true),
            7022 => new CherrySignBlock(Identifier, 1, false),
            7023 => new CherrySignBlock(Identifier, 2, true),
            7024 => new CherrySignBlock(Identifier, 2, false),
            7025 => new CherrySignBlock(Identifier, 3, true),
            7026 => new CherrySignBlock(Identifier, 3, false),
            7027 => new CherrySignBlock(Identifier, 4, true),
            7028 => new CherrySignBlock(Identifier, 4, false),
            7029 => new CherrySignBlock(Identifier, 5, true),
            7030 => new CherrySignBlock(Identifier, 5, false),
            7031 => new CherrySignBlock(Identifier, 6, true),
            7032 => new CherrySignBlock(Identifier, 6, false),
            7033 => new CherrySignBlock(Identifier, 7, true),
            7034 => new CherrySignBlock(Identifier, 7, false),
            7035 => new CherrySignBlock(Identifier, 8, true),
            7036 => new CherrySignBlock(Identifier, 8, false),
            7037 => new CherrySignBlock(Identifier, 9, true),
            7038 => new CherrySignBlock(Identifier, 9, false),
            7039 => new CherrySignBlock(Identifier, 10, true),
            7040 => new CherrySignBlock(Identifier, 10, false),
            7041 => new CherrySignBlock(Identifier, 11, true),
            7042 => new CherrySignBlock(Identifier, 11, false),
            7043 => new CherrySignBlock(Identifier, 12, true),
            7044 => new CherrySignBlock(Identifier, 12, false),
            7045 => new CherrySignBlock(Identifier, 13, true),
            7046 => new CherrySignBlock(Identifier, 13, false),
            7047 => new CherrySignBlock(Identifier, 14, true),
            7048 => new CherrySignBlock(Identifier, 14, false),
            7049 => new CherrySignBlock(Identifier, 15, true),
            7050 => new CherrySignBlock(Identifier, 15, false),
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
