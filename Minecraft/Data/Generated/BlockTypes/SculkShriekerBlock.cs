using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkShriekerBlock(Identifier Identifier, bool CanSummon, bool Shrieking, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:sculk_shrieker", "block.minecraft.sculk_shrieker", 3f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:sculk_shrieker", "minecraft:sculk_shrieker", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 1, PushReaction.Normal, 29, "sculk_shrieker", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S77, BlockShapes.S87, BlockShapes.S1, BlockShapes.S87, BlockShapes.S87);
    private static readonly BlockStateInfo I1 = I0 with { Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 27774];

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
            return CanSummon switch {
                true => Shrieking switch {
                    true => Waterlogged switch {
                        true => 27774,
                        false => 27775,
                    },
                    false => Waterlogged switch {
                        true => 27776,
                        false => 27777,
                    },
                },
                false => Shrieking switch {
                    true => Waterlogged switch {
                        true => 27778,
                        false => 27779,
                    },
                    false => Waterlogged switch {
                        true => 27780,
                        false => 27781,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27774 => new SculkShriekerBlock(Identifier, true, true, true),
            27775 => new SculkShriekerBlock(Identifier, true, true, false),
            27776 => new SculkShriekerBlock(Identifier, true, false, true),
            27777 => new SculkShriekerBlock(Identifier, true, false, false),
            27778 => new SculkShriekerBlock(Identifier, false, true, true),
            27779 => new SculkShriekerBlock(Identifier, false, true, false),
            27780 => new SculkShriekerBlock(Identifier, false, false, true),
            27781 => new SculkShriekerBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CanSummon = properties.Contains("can_summon") ? properties["can_summon"].GetString() == "true" : CanSummon,
            Shrieking = properties.Contains("shrieking") ? properties["shrieking"].GetString() == "true" : Shrieking,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("can_summon", new StringTag(CanSummon.ToString().ToLower())),
            ("shrieking", new StringTag(Shrieking.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
