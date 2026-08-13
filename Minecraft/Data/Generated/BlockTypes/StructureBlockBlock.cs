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
public record StructureBlockBlock(Identifier Identifier, StructureBlockBlock.Mode ModeValue) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:structure", "block.minecraft.structure_block", 3600000f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:structure_block", "minecraft:structure_block", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 15, PushReaction.Normal, 22, "stone", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
            return ModeValue switch {
                Mode.Save => 21722,
                Mode.Load => 21723,
                Mode.Corner => 21724,
                Mode.Data => 21725,
                _ => throw new ArgumentOutOfRangeException(nameof(ModeValue), ModeValue, "Unknown value for property mode.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21722 => new StructureBlockBlock(Identifier, Mode.Save),
            21723 => new StructureBlockBlock(Identifier, Mode.Load),
            21724 => new StructureBlockBlock(Identifier, Mode.Corner),
            21725 => new StructureBlockBlock(Identifier, Mode.Data),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ModeValue = properties.Contains("mode") ? ModeFromString(properties["mode"].GetString()) : ModeValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("mode", new StringTag(ModeToName(ModeValue)))
        );
    }
    
    public enum Mode {
        Save,
        Load,
        Corner,
        Data,
    }

    public static Mode ModeFromString(string value) {
        return value switch {
            "save" => Mode.Save,
            "load" => Mode.Load,
            "corner" => Mode.Corner,
            "data" => Mode.Data,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Mode.")
        };
    }

    public static string ModeToName(Mode value) {
        return value switch {
            Mode.Save => "save",
            Mode.Load => "load",
            Mode.Corner => "corner",
            Mode.Data => "data",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Mode value.")
        };
    }
}
