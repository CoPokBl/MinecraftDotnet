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
public record CreakingHeartBlock(Identifier Identifier, Axis Axis, CreakingHeartState CreakingHeartState, bool Natural) : IBlock, IAxisAligned, ICreakingHearted {
    private static readonly BlockInfo Data = new("block.minecraft.creaking_heart", 10f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:creaking_heart", "minecraft:creaking_heart", BlockInfo.VanillaOnly, "minecraft:blocks/creaking_heart");
    private static readonly BlockStateInfo I0 = new(10f, 0, 15, PushReaction.PushPull, 15, "creaking_heart", NoteBlockInstrument.Basedrum, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithAxis(Axis axis) => this with { Axis = axis };

    public IBlock WithCreakingHeartState(CreakingHeartState creakingHeartState) => this with { CreakingHeartState = creakingHeartState };


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 5445,
                        false => 5446,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 5447,
                        false => 5448,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 5449,
                        false => 5450,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                Axis.Y => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 5451,
                        false => 5452,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 5453,
                        false => 5454,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 5455,
                        false => 5456,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                Axis.Z => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 5457,
                        false => 5458,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 5459,
                        false => 5460,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 5461,
                        false => 5462,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5445 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, true),
            5446 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, false),
            5447 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, true),
            5448 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, false),
            5449 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, true),
            5450 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, false),
            5451 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, true),
            5452 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, false),
            5453 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, true),
            5454 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, false),
            5455 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, true),
            5456 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, false),
            5457 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, true),
            5458 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, false),
            5459 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, true),
            5460 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, false),
            5461 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, true),
            5462 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Axis = properties.Contains("axis") ? AxisExtensions.FromString(properties["axis"].GetString()) : Axis,
            CreakingHeartState = properties.Contains("creaking_heart_state") ? CreakingHeartStateExtensions.FromString(properties["creaking_heart_state"].GetString()) : CreakingHeartState,
            Natural = properties.Contains("natural") ? properties["natural"].GetString() == "true" : Natural,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("axis", new StringTag(Axis.ToName())),
            ("creaking_heart_state", new StringTag(CreakingHeartState.ToName())),
            ("natural", new StringTag(Natural.ToString().ToLower()))
        );
    }
    
}
