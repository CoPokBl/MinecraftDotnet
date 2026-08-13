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
public record HopperBlock(Identifier Identifier, bool Enabled, HopperBlock.Facing FacingValue) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:hopper", "block.minecraft.hopper", 4.8f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:hopper", "minecraft:hopper", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 0, 0, PushReaction.Normal, 11, "metal", NoteBlockInstrument.Harp, false, false, true, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S601, BlockShapes.S601, BlockShapes.S602, BlockShapes.S1, BlockShapes.S601, BlockShapes.S601);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S603, CollisionShape = BlockShapes.S603, InteractionShape = BlockShapes.S604, VisualShape = BlockShapes.S603, SupportShape = BlockShapes.S603 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S605, CollisionShape = BlockShapes.S605, InteractionShape = BlockShapes.S606, VisualShape = BlockShapes.S605, SupportShape = BlockShapes.S605 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S607, CollisionShape = BlockShapes.S607, InteractionShape = BlockShapes.S608, VisualShape = BlockShapes.S607, SupportShape = BlockShapes.S607 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S609, CollisionShape = BlockShapes.S609, InteractionShape = BlockShapes.S610, VisualShape = BlockShapes.S609, SupportShape = BlockShapes.S609 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I0, I1, I2, I3, I4
    ];

    public BlockStateInfo StateInfo => States[StateId - 11313];

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
            return Enabled switch {
                true => FacingValue switch {
                    Facing.Down => 11313,
                    Facing.North => 11314,
                    Facing.South => 11315,
                    Facing.West => 11316,
                    Facing.East => 11317,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
                false => FacingValue switch {
                    Facing.Down => 11318,
                    Facing.North => 11319,
                    Facing.South => 11320,
                    Facing.West => 11321,
                    Facing.East => 11322,
                    _ => throw new ArgumentOutOfRangeException(nameof(FacingValue), FacingValue, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11313 => new HopperBlock(Identifier, true, Facing.Down),
            11314 => new HopperBlock(Identifier, true, Facing.North),
            11315 => new HopperBlock(Identifier, true, Facing.South),
            11316 => new HopperBlock(Identifier, true, Facing.West),
            11317 => new HopperBlock(Identifier, true, Facing.East),
            11318 => new HopperBlock(Identifier, false, Facing.Down),
            11319 => new HopperBlock(Identifier, false, Facing.North),
            11320 => new HopperBlock(Identifier, false, Facing.South),
            11321 => new HopperBlock(Identifier, false, Facing.West),
            11322 => new HopperBlock(Identifier, false, Facing.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Enabled = properties.Contains("enabled") ? properties["enabled"].GetString() == "true" : Enabled,
            FacingValue = properties.Contains("facing") ? FacingFromString(properties["facing"].GetString()) : FacingValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("enabled", new StringTag(Enabled.ToString().ToLower())),
            ("facing", new StringTag(FacingToName(FacingValue)))
        );
    }
    
    public enum Facing {
        Down,
        North,
        South,
        West,
        East,
    }

    public static Facing FacingFromString(string value) {
        return value switch {
            "down" => Facing.Down,
            "north" => Facing.North,
            "south" => Facing.South,
            "west" => Facing.West,
            "east" => Facing.East,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Facing.")
        };
    }

    public static string FacingToName(Facing value) {
        return value switch {
            Facing.Down => "down",
            Facing.North => "north",
            Facing.South => "south",
            Facing.West => "west",
            Facing.East => "east",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Facing value.")
        };
    }
}
