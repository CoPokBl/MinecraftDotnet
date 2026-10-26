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
public record PaleOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.pale_oak_sign", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:pale_oak_sign", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.PushPull, 14, "wood", NoteBlockInstrument.Bass, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7115];

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
                    true => 7115,
                    false => 7116,
                },
                1 => Waterlogged switch {
                    true => 7117,
                    false => 7118,
                },
                2 => Waterlogged switch {
                    true => 7119,
                    false => 7120,
                },
                3 => Waterlogged switch {
                    true => 7121,
                    false => 7122,
                },
                4 => Waterlogged switch {
                    true => 7123,
                    false => 7124,
                },
                5 => Waterlogged switch {
                    true => 7125,
                    false => 7126,
                },
                6 => Waterlogged switch {
                    true => 7127,
                    false => 7128,
                },
                7 => Waterlogged switch {
                    true => 7129,
                    false => 7130,
                },
                8 => Waterlogged switch {
                    true => 7131,
                    false => 7132,
                },
                9 => Waterlogged switch {
                    true => 7133,
                    false => 7134,
                },
                10 => Waterlogged switch {
                    true => 7135,
                    false => 7136,
                },
                11 => Waterlogged switch {
                    true => 7137,
                    false => 7138,
                },
                12 => Waterlogged switch {
                    true => 7139,
                    false => 7140,
                },
                13 => Waterlogged switch {
                    true => 7141,
                    false => 7142,
                },
                14 => Waterlogged switch {
                    true => 7143,
                    false => 7144,
                },
                15 => Waterlogged switch {
                    true => 7145,
                    false => 7146,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7115 => new PaleOakSignBlock(Identifier, 0, true),
            7116 => new PaleOakSignBlock(Identifier, 0, false),
            7117 => new PaleOakSignBlock(Identifier, 1, true),
            7118 => new PaleOakSignBlock(Identifier, 1, false),
            7119 => new PaleOakSignBlock(Identifier, 2, true),
            7120 => new PaleOakSignBlock(Identifier, 2, false),
            7121 => new PaleOakSignBlock(Identifier, 3, true),
            7122 => new PaleOakSignBlock(Identifier, 3, false),
            7123 => new PaleOakSignBlock(Identifier, 4, true),
            7124 => new PaleOakSignBlock(Identifier, 4, false),
            7125 => new PaleOakSignBlock(Identifier, 5, true),
            7126 => new PaleOakSignBlock(Identifier, 5, false),
            7127 => new PaleOakSignBlock(Identifier, 6, true),
            7128 => new PaleOakSignBlock(Identifier, 6, false),
            7129 => new PaleOakSignBlock(Identifier, 7, true),
            7130 => new PaleOakSignBlock(Identifier, 7, false),
            7131 => new PaleOakSignBlock(Identifier, 8, true),
            7132 => new PaleOakSignBlock(Identifier, 8, false),
            7133 => new PaleOakSignBlock(Identifier, 9, true),
            7134 => new PaleOakSignBlock(Identifier, 9, false),
            7135 => new PaleOakSignBlock(Identifier, 10, true),
            7136 => new PaleOakSignBlock(Identifier, 10, false),
            7137 => new PaleOakSignBlock(Identifier, 11, true),
            7138 => new PaleOakSignBlock(Identifier, 11, false),
            7139 => new PaleOakSignBlock(Identifier, 12, true),
            7140 => new PaleOakSignBlock(Identifier, 12, false),
            7141 => new PaleOakSignBlock(Identifier, 13, true),
            7142 => new PaleOakSignBlock(Identifier, 13, false),
            7143 => new PaleOakSignBlock(Identifier, 14, true),
            7144 => new PaleOakSignBlock(Identifier, 14, false),
            7145 => new PaleOakSignBlock(Identifier, 15, true),
            7146 => new PaleOakSignBlock(Identifier, 15, false),
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
