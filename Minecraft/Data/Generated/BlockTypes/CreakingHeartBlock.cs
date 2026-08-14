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
    private static readonly BlockInfo Data = new("minecraft:creaking_heart", "block.minecraft.creaking_heart", 10f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:creaking_heart", "minecraft:creaking_heart", BlockInfo.VanillaOnly, "minecraft:blocks/creaking_heart");
    private static readonly BlockStateInfo I0 = new(10f, 0, 15, PushReaction.Normal, 15, "creaking_heart", NoteBlockInstrument.Basedrum, false, true, false, true, false, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithAxis(Axis axis) => this with { Axis = axis };

    public IBlock WithCreakingHeartState(CreakingHeartState creakingHeartState) => this with { CreakingHeartState = creakingHeartState };


    public uint StateId {
        get {
            return Axis switch {
                Axis.X => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3889,
                        false => 3890,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3891,
                        false => 3892,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3893,
                        false => 3894,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                Axis.Y => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3895,
                        false => 3896,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3897,
                        false => 3898,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3899,
                        false => 3900,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                Axis.Z => CreakingHeartState switch {
                    CreakingHeartState.Uprooted => Natural switch {
                        true => 3901,
                        false => 3902,
                    },
                    CreakingHeartState.Dormant => Natural switch {
                        true => 3903,
                        false => 3904,
                    },
                    CreakingHeartState.Awake => Natural switch {
                        true => 3905,
                        false => 3906,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(CreakingHeartState), CreakingHeartState, "Unknown value for property creaking_heart_state.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Axis), Axis, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3889 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, true),
            3890 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Uprooted, false),
            3891 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, true),
            3892 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Dormant, false),
            3893 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, true),
            3894 => new CreakingHeartBlock(Identifier, Axis.X, CreakingHeartState.Awake, false),
            3895 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, true),
            3896 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Uprooted, false),
            3897 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, true),
            3898 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Dormant, false),
            3899 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, true),
            3900 => new CreakingHeartBlock(Identifier, Axis.Y, CreakingHeartState.Awake, false),
            3901 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, true),
            3902 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Uprooted, false),
            3903 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, true),
            3904 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Dormant, false),
            3905 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, true),
            3906 => new CreakingHeartBlock(Identifier, Axis.Z, CreakingHeartState.Awake, false),
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
