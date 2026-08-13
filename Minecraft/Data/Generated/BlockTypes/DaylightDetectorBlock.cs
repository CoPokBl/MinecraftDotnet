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
    private static readonly BlockInfo Data = new("minecraft:daylight_detector", "block.minecraft.daylight_detector", 0.2f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:daylight_detector", "minecraft:daylight_detector", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.2f, 0, 0, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S334, BlockShapes.S334, BlockShapes.S1, BlockShapes.S334, BlockShapes.S334, BlockShapes.S334);

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
            return Inverted switch {
                true => Power switch {
                    0 => 11279,
                    1 => 11280,
                    2 => 11281,
                    3 => 11282,
                    4 => 11283,
                    5 => 11284,
                    6 => 11285,
                    7 => 11286,
                    8 => 11287,
                    9 => 11288,
                    10 => 11289,
                    11 => 11290,
                    12 => 11291,
                    13 => 11292,
                    14 => 11293,
                    15 => 11294,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
                false => Power switch {
                    0 => 11295,
                    1 => 11296,
                    2 => 11297,
                    3 => 11298,
                    4 => 11299,
                    5 => 11300,
                    6 => 11301,
                    7 => 11302,
                    8 => 11303,
                    9 => 11304,
                    10 => 11305,
                    11 => 11306,
                    12 => 11307,
                    13 => 11308,
                    14 => 11309,
                    15 => 11310,
                    _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11279 => new DaylightDetectorBlock(Identifier, true, 0),
            11280 => new DaylightDetectorBlock(Identifier, true, 1),
            11281 => new DaylightDetectorBlock(Identifier, true, 2),
            11282 => new DaylightDetectorBlock(Identifier, true, 3),
            11283 => new DaylightDetectorBlock(Identifier, true, 4),
            11284 => new DaylightDetectorBlock(Identifier, true, 5),
            11285 => new DaylightDetectorBlock(Identifier, true, 6),
            11286 => new DaylightDetectorBlock(Identifier, true, 7),
            11287 => new DaylightDetectorBlock(Identifier, true, 8),
            11288 => new DaylightDetectorBlock(Identifier, true, 9),
            11289 => new DaylightDetectorBlock(Identifier, true, 10),
            11290 => new DaylightDetectorBlock(Identifier, true, 11),
            11291 => new DaylightDetectorBlock(Identifier, true, 12),
            11292 => new DaylightDetectorBlock(Identifier, true, 13),
            11293 => new DaylightDetectorBlock(Identifier, true, 14),
            11294 => new DaylightDetectorBlock(Identifier, true, 15),
            11295 => new DaylightDetectorBlock(Identifier, false, 0),
            11296 => new DaylightDetectorBlock(Identifier, false, 1),
            11297 => new DaylightDetectorBlock(Identifier, false, 2),
            11298 => new DaylightDetectorBlock(Identifier, false, 3),
            11299 => new DaylightDetectorBlock(Identifier, false, 4),
            11300 => new DaylightDetectorBlock(Identifier, false, 5),
            11301 => new DaylightDetectorBlock(Identifier, false, 6),
            11302 => new DaylightDetectorBlock(Identifier, false, 7),
            11303 => new DaylightDetectorBlock(Identifier, false, 8),
            11304 => new DaylightDetectorBlock(Identifier, false, 9),
            11305 => new DaylightDetectorBlock(Identifier, false, 10),
            11306 => new DaylightDetectorBlock(Identifier, false, 11),
            11307 => new DaylightDetectorBlock(Identifier, false, 12),
            11308 => new DaylightDetectorBlock(Identifier, false, 13),
            11309 => new DaylightDetectorBlock(Identifier, false, 14),
            11310 => new DaylightDetectorBlock(Identifier, false, 15),
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
