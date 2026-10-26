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
public record DaylightDetectorBlock(Identifier Identifier, bool Inverted, int Power) : IBlock {
    private static readonly BlockInfo Data = new("block.minecraft.daylight_detector", 0.2f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:daylight_detector", "minecraft:daylight_detector", BlockInfo.VanillaOnly, "minecraft:blocks/daylight_detector");
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S334, BlockShapes.S334, BlockShapes.S1, BlockShapes.S334, BlockShapes.S334, BlockShapes.S334);

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
            return Inverted switch {
                true => Power switch {
                    0 => 13046,
                    1 => 13047,
                    2 => 13048,
                    3 => 13049,
                    4 => 13050,
                    5 => 13051,
                    6 => 13052,
                    7 => 13053,
                    8 => 13054,
                    9 => 13055,
                    10 => 13056,
                    11 => 13057,
                    12 => 13058,
                    13 => 13059,
                    14 => 13060,
                    15 => 13061,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                false => Power switch {
                    0 => 13062,
                    1 => 13063,
                    2 => 13064,
                    3 => 13065,
                    4 => 13066,
                    5 => 13067,
                    6 => 13068,
                    7 => 13069,
                    8 => 13070,
                    9 => 13071,
                    10 => 13072,
                    11 => 13073,
                    12 => 13074,
                    13 => 13075,
                    14 => 13076,
                    15 => 13077,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13046 => new DaylightDetectorBlock(Identifier, true, 0),
            13047 => new DaylightDetectorBlock(Identifier, true, 1),
            13048 => new DaylightDetectorBlock(Identifier, true, 2),
            13049 => new DaylightDetectorBlock(Identifier, true, 3),
            13050 => new DaylightDetectorBlock(Identifier, true, 4),
            13051 => new DaylightDetectorBlock(Identifier, true, 5),
            13052 => new DaylightDetectorBlock(Identifier, true, 6),
            13053 => new DaylightDetectorBlock(Identifier, true, 7),
            13054 => new DaylightDetectorBlock(Identifier, true, 8),
            13055 => new DaylightDetectorBlock(Identifier, true, 9),
            13056 => new DaylightDetectorBlock(Identifier, true, 10),
            13057 => new DaylightDetectorBlock(Identifier, true, 11),
            13058 => new DaylightDetectorBlock(Identifier, true, 12),
            13059 => new DaylightDetectorBlock(Identifier, true, 13),
            13060 => new DaylightDetectorBlock(Identifier, true, 14),
            13061 => new DaylightDetectorBlock(Identifier, true, 15),
            13062 => new DaylightDetectorBlock(Identifier, false, 0),
            13063 => new DaylightDetectorBlock(Identifier, false, 1),
            13064 => new DaylightDetectorBlock(Identifier, false, 2),
            13065 => new DaylightDetectorBlock(Identifier, false, 3),
            13066 => new DaylightDetectorBlock(Identifier, false, 4),
            13067 => new DaylightDetectorBlock(Identifier, false, 5),
            13068 => new DaylightDetectorBlock(Identifier, false, 6),
            13069 => new DaylightDetectorBlock(Identifier, false, 7),
            13070 => new DaylightDetectorBlock(Identifier, false, 8),
            13071 => new DaylightDetectorBlock(Identifier, false, 9),
            13072 => new DaylightDetectorBlock(Identifier, false, 10),
            13073 => new DaylightDetectorBlock(Identifier, false, 11),
            13074 => new DaylightDetectorBlock(Identifier, false, 12),
            13075 => new DaylightDetectorBlock(Identifier, false, 13),
            13076 => new DaylightDetectorBlock(Identifier, false, 14),
            13077 => new DaylightDetectorBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Inverted = properties.Contains("inverted") ? properties["inverted"].GetString() == "true" : Inverted,
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("inverted", new StringTag(Inverted.ToString().ToLower())),
            ("power", new StringTag(Power.ToString()))
        );
    }
    
}
