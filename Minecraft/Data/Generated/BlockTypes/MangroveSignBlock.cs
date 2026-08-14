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
public record MangroveSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock, IRotated, IWaterlogged {
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.mangrove_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:mangrove_sign", BlockInfo.VanillaOnly, "minecraft:blocks/mangrove_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 28, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5591];

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
                    true => 5591,
                    false => 5592,
                },
                1 => Waterlogged switch {
                    true => 5593,
                    false => 5594,
                },
                2 => Waterlogged switch {
                    true => 5595,
                    false => 5596,
                },
                3 => Waterlogged switch {
                    true => 5597,
                    false => 5598,
                },
                4 => Waterlogged switch {
                    true => 5599,
                    false => 5600,
                },
                5 => Waterlogged switch {
                    true => 5601,
                    false => 5602,
                },
                6 => Waterlogged switch {
                    true => 5603,
                    false => 5604,
                },
                7 => Waterlogged switch {
                    true => 5605,
                    false => 5606,
                },
                8 => Waterlogged switch {
                    true => 5607,
                    false => 5608,
                },
                9 => Waterlogged switch {
                    true => 5609,
                    false => 5610,
                },
                10 => Waterlogged switch {
                    true => 5611,
                    false => 5612,
                },
                11 => Waterlogged switch {
                    true => 5613,
                    false => 5614,
                },
                12 => Waterlogged switch {
                    true => 5615,
                    false => 5616,
                },
                13 => Waterlogged switch {
                    true => 5617,
                    false => 5618,
                },
                14 => Waterlogged switch {
                    true => 5619,
                    false => 5620,
                },
                15 => Waterlogged switch {
                    true => 5621,
                    false => 5622,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5591 => new MangroveSignBlock(Identifier, 0, true),
            5592 => new MangroveSignBlock(Identifier, 0, false),
            5593 => new MangroveSignBlock(Identifier, 1, true),
            5594 => new MangroveSignBlock(Identifier, 1, false),
            5595 => new MangroveSignBlock(Identifier, 2, true),
            5596 => new MangroveSignBlock(Identifier, 2, false),
            5597 => new MangroveSignBlock(Identifier, 3, true),
            5598 => new MangroveSignBlock(Identifier, 3, false),
            5599 => new MangroveSignBlock(Identifier, 4, true),
            5600 => new MangroveSignBlock(Identifier, 4, false),
            5601 => new MangroveSignBlock(Identifier, 5, true),
            5602 => new MangroveSignBlock(Identifier, 5, false),
            5603 => new MangroveSignBlock(Identifier, 6, true),
            5604 => new MangroveSignBlock(Identifier, 6, false),
            5605 => new MangroveSignBlock(Identifier, 7, true),
            5606 => new MangroveSignBlock(Identifier, 7, false),
            5607 => new MangroveSignBlock(Identifier, 8, true),
            5608 => new MangroveSignBlock(Identifier, 8, false),
            5609 => new MangroveSignBlock(Identifier, 9, true),
            5610 => new MangroveSignBlock(Identifier, 9, false),
            5611 => new MangroveSignBlock(Identifier, 10, true),
            5612 => new MangroveSignBlock(Identifier, 10, false),
            5613 => new MangroveSignBlock(Identifier, 11, true),
            5614 => new MangroveSignBlock(Identifier, 11, false),
            5615 => new MangroveSignBlock(Identifier, 12, true),
            5616 => new MangroveSignBlock(Identifier, 12, false),
            5617 => new MangroveSignBlock(Identifier, 13, true),
            5618 => new MangroveSignBlock(Identifier, 13, false),
            5619 => new MangroveSignBlock(Identifier, 14, true),
            5620 => new MangroveSignBlock(Identifier, 14, false),
            5621 => new MangroveSignBlock(Identifier, 15, true),
            5622 => new MangroveSignBlock(Identifier, 15, false),
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
