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
public record WarpedSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.warped_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:warped_sign", BlockInfo.VanillaOnly, "minecraft:blocks/warped_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 56, "nether_wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 25031];

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
                    true => 25031,
                    false => 25032,
                },
                1 => Waterlogged switch {
                    true => 25033,
                    false => 25034,
                },
                2 => Waterlogged switch {
                    true => 25035,
                    false => 25036,
                },
                3 => Waterlogged switch {
                    true => 25037,
                    false => 25038,
                },
                4 => Waterlogged switch {
                    true => 25039,
                    false => 25040,
                },
                5 => Waterlogged switch {
                    true => 25041,
                    false => 25042,
                },
                6 => Waterlogged switch {
                    true => 25043,
                    false => 25044,
                },
                7 => Waterlogged switch {
                    true => 25045,
                    false => 25046,
                },
                8 => Waterlogged switch {
                    true => 25047,
                    false => 25048,
                },
                9 => Waterlogged switch {
                    true => 25049,
                    false => 25050,
                },
                10 => Waterlogged switch {
                    true => 25051,
                    false => 25052,
                },
                11 => Waterlogged switch {
                    true => 25053,
                    false => 25054,
                },
                12 => Waterlogged switch {
                    true => 25055,
                    false => 25056,
                },
                13 => Waterlogged switch {
                    true => 25057,
                    false => 25058,
                },
                14 => Waterlogged switch {
                    true => 25059,
                    false => 25060,
                },
                15 => Waterlogged switch {
                    true => 25061,
                    false => 25062,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25031 => new WarpedSignBlock(Identifier, 0, true),
            25032 => new WarpedSignBlock(Identifier, 0, false),
            25033 => new WarpedSignBlock(Identifier, 1, true),
            25034 => new WarpedSignBlock(Identifier, 1, false),
            25035 => new WarpedSignBlock(Identifier, 2, true),
            25036 => new WarpedSignBlock(Identifier, 2, false),
            25037 => new WarpedSignBlock(Identifier, 3, true),
            25038 => new WarpedSignBlock(Identifier, 3, false),
            25039 => new WarpedSignBlock(Identifier, 4, true),
            25040 => new WarpedSignBlock(Identifier, 4, false),
            25041 => new WarpedSignBlock(Identifier, 5, true),
            25042 => new WarpedSignBlock(Identifier, 5, false),
            25043 => new WarpedSignBlock(Identifier, 6, true),
            25044 => new WarpedSignBlock(Identifier, 6, false),
            25045 => new WarpedSignBlock(Identifier, 7, true),
            25046 => new WarpedSignBlock(Identifier, 7, false),
            25047 => new WarpedSignBlock(Identifier, 8, true),
            25048 => new WarpedSignBlock(Identifier, 8, false),
            25049 => new WarpedSignBlock(Identifier, 9, true),
            25050 => new WarpedSignBlock(Identifier, 9, false),
            25051 => new WarpedSignBlock(Identifier, 10, true),
            25052 => new WarpedSignBlock(Identifier, 10, false),
            25053 => new WarpedSignBlock(Identifier, 11, true),
            25054 => new WarpedSignBlock(Identifier, 11, false),
            25055 => new WarpedSignBlock(Identifier, 12, true),
            25056 => new WarpedSignBlock(Identifier, 12, false),
            25057 => new WarpedSignBlock(Identifier, 13, true),
            25058 => new WarpedSignBlock(Identifier, 13, false),
            25059 => new WarpedSignBlock(Identifier, 14, true),
            25060 => new WarpedSignBlock(Identifier, 14, false),
            25061 => new WarpedSignBlock(Identifier, 15, true),
            25062 => new WarpedSignBlock(Identifier, 15, false),
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
