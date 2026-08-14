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
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.pale_oak_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:pale_oak_sign", BlockInfo.VanillaOnly, "minecraft:blocks/pale_oak_sign");
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 14, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S87, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5559];

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
                    true => 5559,
                    false => 5560,
                },
                1 => Waterlogged switch {
                    true => 5561,
                    false => 5562,
                },
                2 => Waterlogged switch {
                    true => 5563,
                    false => 5564,
                },
                3 => Waterlogged switch {
                    true => 5565,
                    false => 5566,
                },
                4 => Waterlogged switch {
                    true => 5567,
                    false => 5568,
                },
                5 => Waterlogged switch {
                    true => 5569,
                    false => 5570,
                },
                6 => Waterlogged switch {
                    true => 5571,
                    false => 5572,
                },
                7 => Waterlogged switch {
                    true => 5573,
                    false => 5574,
                },
                8 => Waterlogged switch {
                    true => 5575,
                    false => 5576,
                },
                9 => Waterlogged switch {
                    true => 5577,
                    false => 5578,
                },
                10 => Waterlogged switch {
                    true => 5579,
                    false => 5580,
                },
                11 => Waterlogged switch {
                    true => 5581,
                    false => 5582,
                },
                12 => Waterlogged switch {
                    true => 5583,
                    false => 5584,
                },
                13 => Waterlogged switch {
                    true => 5585,
                    false => 5586,
                },
                14 => Waterlogged switch {
                    true => 5587,
                    false => 5588,
                },
                15 => Waterlogged switch {
                    true => 5589,
                    false => 5590,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5559 => new PaleOakSignBlock(Identifier, 0, true),
            5560 => new PaleOakSignBlock(Identifier, 0, false),
            5561 => new PaleOakSignBlock(Identifier, 1, true),
            5562 => new PaleOakSignBlock(Identifier, 1, false),
            5563 => new PaleOakSignBlock(Identifier, 2, true),
            5564 => new PaleOakSignBlock(Identifier, 2, false),
            5565 => new PaleOakSignBlock(Identifier, 3, true),
            5566 => new PaleOakSignBlock(Identifier, 3, false),
            5567 => new PaleOakSignBlock(Identifier, 4, true),
            5568 => new PaleOakSignBlock(Identifier, 4, false),
            5569 => new PaleOakSignBlock(Identifier, 5, true),
            5570 => new PaleOakSignBlock(Identifier, 5, false),
            5571 => new PaleOakSignBlock(Identifier, 6, true),
            5572 => new PaleOakSignBlock(Identifier, 6, false),
            5573 => new PaleOakSignBlock(Identifier, 7, true),
            5574 => new PaleOakSignBlock(Identifier, 7, false),
            5575 => new PaleOakSignBlock(Identifier, 8, true),
            5576 => new PaleOakSignBlock(Identifier, 8, false),
            5577 => new PaleOakSignBlock(Identifier, 9, true),
            5578 => new PaleOakSignBlock(Identifier, 9, false),
            5579 => new PaleOakSignBlock(Identifier, 10, true),
            5580 => new PaleOakSignBlock(Identifier, 10, false),
            5581 => new PaleOakSignBlock(Identifier, 11, true),
            5582 => new PaleOakSignBlock(Identifier, 11, false),
            5583 => new PaleOakSignBlock(Identifier, 12, true),
            5584 => new PaleOakSignBlock(Identifier, 12, false),
            5585 => new PaleOakSignBlock(Identifier, 13, true),
            5586 => new PaleOakSignBlock(Identifier, 13, false),
            5587 => new PaleOakSignBlock(Identifier, 14, true),
            5588 => new PaleOakSignBlock(Identifier, 14, false),
            5589 => new PaleOakSignBlock(Identifier, 15, true),
            5590 => new PaleOakSignBlock(Identifier, 15, false),
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
