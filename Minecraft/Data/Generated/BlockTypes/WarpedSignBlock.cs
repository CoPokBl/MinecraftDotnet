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
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.warped_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:warped_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 56, "nether_wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 21674];

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
                    true => 21674,
                    false => 21675,
                },
                1 => Waterlogged switch {
                    true => 21676,
                    false => 21677,
                },
                2 => Waterlogged switch {
                    true => 21678,
                    false => 21679,
                },
                3 => Waterlogged switch {
                    true => 21680,
                    false => 21681,
                },
                4 => Waterlogged switch {
                    true => 21682,
                    false => 21683,
                },
                5 => Waterlogged switch {
                    true => 21684,
                    false => 21685,
                },
                6 => Waterlogged switch {
                    true => 21686,
                    false => 21687,
                },
                7 => Waterlogged switch {
                    true => 21688,
                    false => 21689,
                },
                8 => Waterlogged switch {
                    true => 21690,
                    false => 21691,
                },
                9 => Waterlogged switch {
                    true => 21692,
                    false => 21693,
                },
                10 => Waterlogged switch {
                    true => 21694,
                    false => 21695,
                },
                11 => Waterlogged switch {
                    true => 21696,
                    false => 21697,
                },
                12 => Waterlogged switch {
                    true => 21698,
                    false => 21699,
                },
                13 => Waterlogged switch {
                    true => 21700,
                    false => 21701,
                },
                14 => Waterlogged switch {
                    true => 21702,
                    false => 21703,
                },
                15 => Waterlogged switch {
                    true => 21704,
                    false => 21705,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21674 => new WarpedSignBlock(Identifier, 0, true),
            21675 => new WarpedSignBlock(Identifier, 0, false),
            21676 => new WarpedSignBlock(Identifier, 1, true),
            21677 => new WarpedSignBlock(Identifier, 1, false),
            21678 => new WarpedSignBlock(Identifier, 2, true),
            21679 => new WarpedSignBlock(Identifier, 2, false),
            21680 => new WarpedSignBlock(Identifier, 3, true),
            21681 => new WarpedSignBlock(Identifier, 3, false),
            21682 => new WarpedSignBlock(Identifier, 4, true),
            21683 => new WarpedSignBlock(Identifier, 4, false),
            21684 => new WarpedSignBlock(Identifier, 5, true),
            21685 => new WarpedSignBlock(Identifier, 5, false),
            21686 => new WarpedSignBlock(Identifier, 6, true),
            21687 => new WarpedSignBlock(Identifier, 6, false),
            21688 => new WarpedSignBlock(Identifier, 7, true),
            21689 => new WarpedSignBlock(Identifier, 7, false),
            21690 => new WarpedSignBlock(Identifier, 8, true),
            21691 => new WarpedSignBlock(Identifier, 8, false),
            21692 => new WarpedSignBlock(Identifier, 9, true),
            21693 => new WarpedSignBlock(Identifier, 9, false),
            21694 => new WarpedSignBlock(Identifier, 10, true),
            21695 => new WarpedSignBlock(Identifier, 10, false),
            21696 => new WarpedSignBlock(Identifier, 11, true),
            21697 => new WarpedSignBlock(Identifier, 11, false),
            21698 => new WarpedSignBlock(Identifier, 12, true),
            21699 => new WarpedSignBlock(Identifier, 12, false),
            21700 => new WarpedSignBlock(Identifier, 13, true),
            21701 => new WarpedSignBlock(Identifier, 13, false),
            21702 => new WarpedSignBlock(Identifier, 14, true),
            21703 => new WarpedSignBlock(Identifier, 14, false),
            21704 => new WarpedSignBlock(Identifier, 15, true),
            21705 => new WarpedSignBlock(Identifier, 15, false),
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
