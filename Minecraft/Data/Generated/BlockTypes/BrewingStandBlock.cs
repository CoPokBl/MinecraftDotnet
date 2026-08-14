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
public record BrewingStandBlock(Identifier Identifier, bool HasBottle0, bool HasBottle1, bool HasBottle2) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:brewing_stand", "block.minecraft.brewing_stand", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:brewing_stand", "minecraft:brewing_stand", BlockInfo.VanillaOnly, "minecraft:blocks/brewing_stand");
    private static readonly BlockStateInfo I0 = new(0.5f, 1, 0, PushReaction.Normal, 6, "stone", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S398, BlockShapes.S398, BlockShapes.S1, BlockShapes.S1, BlockShapes.S398, BlockShapes.S398);

    public BlockStateInfo StateInfo => I0;

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


    public uint StateId {
        get {
            return HasBottle0 switch {
                true => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 9452,
                        false => 9453,
                    },
                    false => HasBottle2 switch {
                        true => 9454,
                        false => 9455,
                    },
                },
                false => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 9456,
                        false => 9457,
                    },
                    false => HasBottle2 switch {
                        true => 9458,
                        false => 9459,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9452 => new BrewingStandBlock(Identifier, true, true, true),
            9453 => new BrewingStandBlock(Identifier, true, true, false),
            9454 => new BrewingStandBlock(Identifier, true, false, true),
            9455 => new BrewingStandBlock(Identifier, true, false, false),
            9456 => new BrewingStandBlock(Identifier, false, true, true),
            9457 => new BrewingStandBlock(Identifier, false, true, false),
            9458 => new BrewingStandBlock(Identifier, false, false, true),
            9459 => new BrewingStandBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            HasBottle0 = properties.Contains("has_bottle_0") ? properties["has_bottle_0"].GetString() == "true" : HasBottle0,
            HasBottle1 = properties.Contains("has_bottle_1") ? properties["has_bottle_1"].GetString() == "true" : HasBottle1,
            HasBottle2 = properties.Contains("has_bottle_2") ? properties["has_bottle_2"].GetString() == "true" : HasBottle2,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("has_bottle_0", new StringTag(HasBottle0.ToString().ToLower())),
            ("has_bottle_1", new StringTag(HasBottle1.ToString().ToLower())),
            ("has_bottle_2", new StringTag(HasBottle2.ToString().ToLower()))
        );
    }
    
}
