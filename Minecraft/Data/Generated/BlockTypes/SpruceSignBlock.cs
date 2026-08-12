using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:standing_sign", "block.minecraft.spruce_sign", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sign", "minecraft:spruce_sign", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 1, PushReaction.Normal, 34, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S85, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5367];

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
                    true => 5367,
                    false => 5368,
                },
                1 => Waterlogged switch {
                    true => 5369,
                    false => 5370,
                },
                2 => Waterlogged switch {
                    true => 5371,
                    false => 5372,
                },
                3 => Waterlogged switch {
                    true => 5373,
                    false => 5374,
                },
                4 => Waterlogged switch {
                    true => 5375,
                    false => 5376,
                },
                5 => Waterlogged switch {
                    true => 5377,
                    false => 5378,
                },
                6 => Waterlogged switch {
                    true => 5379,
                    false => 5380,
                },
                7 => Waterlogged switch {
                    true => 5381,
                    false => 5382,
                },
                8 => Waterlogged switch {
                    true => 5383,
                    false => 5384,
                },
                9 => Waterlogged switch {
                    true => 5385,
                    false => 5386,
                },
                10 => Waterlogged switch {
                    true => 5387,
                    false => 5388,
                },
                11 => Waterlogged switch {
                    true => 5389,
                    false => 5390,
                },
                12 => Waterlogged switch {
                    true => 5391,
                    false => 5392,
                },
                13 => Waterlogged switch {
                    true => 5393,
                    false => 5394,
                },
                14 => Waterlogged switch {
                    true => 5395,
                    false => 5396,
                },
                15 => Waterlogged switch {
                    true => 5397,
                    false => 5398,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5367 => new SpruceSignBlock(Identifier, 0, true),
            5368 => new SpruceSignBlock(Identifier, 0, false),
            5369 => new SpruceSignBlock(Identifier, 1, true),
            5370 => new SpruceSignBlock(Identifier, 1, false),
            5371 => new SpruceSignBlock(Identifier, 2, true),
            5372 => new SpruceSignBlock(Identifier, 2, false),
            5373 => new SpruceSignBlock(Identifier, 3, true),
            5374 => new SpruceSignBlock(Identifier, 3, false),
            5375 => new SpruceSignBlock(Identifier, 4, true),
            5376 => new SpruceSignBlock(Identifier, 4, false),
            5377 => new SpruceSignBlock(Identifier, 5, true),
            5378 => new SpruceSignBlock(Identifier, 5, false),
            5379 => new SpruceSignBlock(Identifier, 6, true),
            5380 => new SpruceSignBlock(Identifier, 6, false),
            5381 => new SpruceSignBlock(Identifier, 7, true),
            5382 => new SpruceSignBlock(Identifier, 7, false),
            5383 => new SpruceSignBlock(Identifier, 8, true),
            5384 => new SpruceSignBlock(Identifier, 8, false),
            5385 => new SpruceSignBlock(Identifier, 9, true),
            5386 => new SpruceSignBlock(Identifier, 9, false),
            5387 => new SpruceSignBlock(Identifier, 10, true),
            5388 => new SpruceSignBlock(Identifier, 10, false),
            5389 => new SpruceSignBlock(Identifier, 11, true),
            5390 => new SpruceSignBlock(Identifier, 11, false),
            5391 => new SpruceSignBlock(Identifier, 12, true),
            5392 => new SpruceSignBlock(Identifier, 12, false),
            5393 => new SpruceSignBlock(Identifier, 13, true),
            5394 => new SpruceSignBlock(Identifier, 13, false),
            5395 => new SpruceSignBlock(Identifier, 14, true),
            5396 => new SpruceSignBlock(Identifier, 14, false),
            5397 => new SpruceSignBlock(Identifier, 15, true),
            5398 => new SpruceSignBlock(Identifier, 15, false),
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
