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
public record BambooSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.bamboo_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:bamboo_sign", BlockInfo.VanillaOnly, "minecraft:blocks/bamboo_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 18, "bamboo_wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7211];

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
                    true => 7211,
                    false => 7212,
                },
                1 => Waterlogged switch {
                    true => 7213,
                    false => 7214,
                },
                2 => Waterlogged switch {
                    true => 7215,
                    false => 7216,
                },
                3 => Waterlogged switch {
                    true => 7217,
                    false => 7218,
                },
                4 => Waterlogged switch {
                    true => 7219,
                    false => 7220,
                },
                5 => Waterlogged switch {
                    true => 7221,
                    false => 7222,
                },
                6 => Waterlogged switch {
                    true => 7223,
                    false => 7224,
                },
                7 => Waterlogged switch {
                    true => 7225,
                    false => 7226,
                },
                8 => Waterlogged switch {
                    true => 7227,
                    false => 7228,
                },
                9 => Waterlogged switch {
                    true => 7229,
                    false => 7230,
                },
                10 => Waterlogged switch {
                    true => 7231,
                    false => 7232,
                },
                11 => Waterlogged switch {
                    true => 7233,
                    false => 7234,
                },
                12 => Waterlogged switch {
                    true => 7235,
                    false => 7236,
                },
                13 => Waterlogged switch {
                    true => 7237,
                    false => 7238,
                },
                14 => Waterlogged switch {
                    true => 7239,
                    false => 7240,
                },
                15 => Waterlogged switch {
                    true => 7241,
                    false => 7242,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7211 => new BambooSignBlock(Identifier, 0, true),
            7212 => new BambooSignBlock(Identifier, 0, false),
            7213 => new BambooSignBlock(Identifier, 1, true),
            7214 => new BambooSignBlock(Identifier, 1, false),
            7215 => new BambooSignBlock(Identifier, 2, true),
            7216 => new BambooSignBlock(Identifier, 2, false),
            7217 => new BambooSignBlock(Identifier, 3, true),
            7218 => new BambooSignBlock(Identifier, 3, false),
            7219 => new BambooSignBlock(Identifier, 4, true),
            7220 => new BambooSignBlock(Identifier, 4, false),
            7221 => new BambooSignBlock(Identifier, 5, true),
            7222 => new BambooSignBlock(Identifier, 5, false),
            7223 => new BambooSignBlock(Identifier, 6, true),
            7224 => new BambooSignBlock(Identifier, 6, false),
            7225 => new BambooSignBlock(Identifier, 7, true),
            7226 => new BambooSignBlock(Identifier, 7, false),
            7227 => new BambooSignBlock(Identifier, 8, true),
            7228 => new BambooSignBlock(Identifier, 8, false),
            7229 => new BambooSignBlock(Identifier, 9, true),
            7230 => new BambooSignBlock(Identifier, 9, false),
            7231 => new BambooSignBlock(Identifier, 10, true),
            7232 => new BambooSignBlock(Identifier, 10, false),
            7233 => new BambooSignBlock(Identifier, 11, true),
            7234 => new BambooSignBlock(Identifier, 11, false),
            7235 => new BambooSignBlock(Identifier, 12, true),
            7236 => new BambooSignBlock(Identifier, 12, false),
            7237 => new BambooSignBlock(Identifier, 13, true),
            7238 => new BambooSignBlock(Identifier, 13, false),
            7239 => new BambooSignBlock(Identifier, 14, true),
            7240 => new BambooSignBlock(Identifier, 14, false),
            7241 => new BambooSignBlock(Identifier, 15, true),
            7242 => new BambooSignBlock(Identifier, 15, false),
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
