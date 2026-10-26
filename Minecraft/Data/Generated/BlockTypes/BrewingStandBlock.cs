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
    private static readonly BlockInfo Data = new("block.minecraft.brewing_stand", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:brewing_stand", "minecraft:brewing_stand", BlockInfo.VanillaOnly, "minecraft:blocks/brewing_stand");
    private static readonly BlockStateInfo I0 = new(0.5f, 1, 0, PushReaction.PushPull, 6, "stone", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S398, BlockShapes.S398, BlockShapes.S1, BlockShapes.S1, BlockShapes.S398, BlockShapes.S398);

    public BlockStateInfo StateInfo => I0;

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


    public uint StateId {
        get {
            return HasBottle0 switch {
                true => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 11186,
                        false => 11187,
                    },
                    false => HasBottle2 switch {
                        true => 11188,
                        false => 11189,
                    },
                },
                false => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 11190,
                        false => 11191,
                    },
                    false => HasBottle2 switch {
                        true => 11192,
                        false => 11193,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11186 => new BrewingStandBlock(Identifier, true, true, true),
            11187 => new BrewingStandBlock(Identifier, true, true, false),
            11188 => new BrewingStandBlock(Identifier, true, false, true),
            11189 => new BrewingStandBlock(Identifier, true, false, false),
            11190 => new BrewingStandBlock(Identifier, false, true, true),
            11191 => new BrewingStandBlock(Identifier, false, true, false),
            11192 => new BrewingStandBlock(Identifier, false, false, true),
            11193 => new BrewingStandBlock(Identifier, false, false, false),
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
