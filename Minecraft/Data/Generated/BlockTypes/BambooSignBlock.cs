using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BambooSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.bamboo_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:bamboo_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 18, "bamboo_wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5623];

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5623,
                    false => 5624,
                },
                1 => Waterlogged switch {
                    true => 5625,
                    false => 5626,
                },
                2 => Waterlogged switch {
                    true => 5627,
                    false => 5628,
                },
                3 => Waterlogged switch {
                    true => 5629,
                    false => 5630,
                },
                4 => Waterlogged switch {
                    true => 5631,
                    false => 5632,
                },
                5 => Waterlogged switch {
                    true => 5633,
                    false => 5634,
                },
                6 => Waterlogged switch {
                    true => 5635,
                    false => 5636,
                },
                7 => Waterlogged switch {
                    true => 5637,
                    false => 5638,
                },
                8 => Waterlogged switch {
                    true => 5639,
                    false => 5640,
                },
                9 => Waterlogged switch {
                    true => 5641,
                    false => 5642,
                },
                10 => Waterlogged switch {
                    true => 5643,
                    false => 5644,
                },
                11 => Waterlogged switch {
                    true => 5645,
                    false => 5646,
                },
                12 => Waterlogged switch {
                    true => 5647,
                    false => 5648,
                },
                13 => Waterlogged switch {
                    true => 5649,
                    false => 5650,
                },
                14 => Waterlogged switch {
                    true => 5651,
                    false => 5652,
                },
                15 => Waterlogged switch {
                    true => 5653,
                    false => 5654,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5623 => new BambooSignBlock(Identifier, 0, true),
            5624 => new BambooSignBlock(Identifier, 0, false),
            5625 => new BambooSignBlock(Identifier, 1, true),
            5626 => new BambooSignBlock(Identifier, 1, false),
            5627 => new BambooSignBlock(Identifier, 2, true),
            5628 => new BambooSignBlock(Identifier, 2, false),
            5629 => new BambooSignBlock(Identifier, 3, true),
            5630 => new BambooSignBlock(Identifier, 3, false),
            5631 => new BambooSignBlock(Identifier, 4, true),
            5632 => new BambooSignBlock(Identifier, 4, false),
            5633 => new BambooSignBlock(Identifier, 5, true),
            5634 => new BambooSignBlock(Identifier, 5, false),
            5635 => new BambooSignBlock(Identifier, 6, true),
            5636 => new BambooSignBlock(Identifier, 6, false),
            5637 => new BambooSignBlock(Identifier, 7, true),
            5638 => new BambooSignBlock(Identifier, 7, false),
            5639 => new BambooSignBlock(Identifier, 8, true),
            5640 => new BambooSignBlock(Identifier, 8, false),
            5641 => new BambooSignBlock(Identifier, 9, true),
            5642 => new BambooSignBlock(Identifier, 9, false),
            5643 => new BambooSignBlock(Identifier, 10, true),
            5644 => new BambooSignBlock(Identifier, 10, false),
            5645 => new BambooSignBlock(Identifier, 11, true),
            5646 => new BambooSignBlock(Identifier, 11, false),
            5647 => new BambooSignBlock(Identifier, 12, true),
            5648 => new BambooSignBlock(Identifier, 12, false),
            5649 => new BambooSignBlock(Identifier, 13, true),
            5650 => new BambooSignBlock(Identifier, 13, false),
            5651 => new BambooSignBlock(Identifier, 14, true),
            5652 => new BambooSignBlock(Identifier, 14, false),
            5653 => new BambooSignBlock(Identifier, 15, true),
            5654 => new BambooSignBlock(Identifier, 15, false),
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
