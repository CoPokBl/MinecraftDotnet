using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record NetherPortalBlock(Identifier Identifier, NetherPortalBlock.Axis AxisValue) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:nether_portal", "block.minecraft.nether_portal", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(-1f, 11, 0, PushReaction.Block, 0, "glass", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, [], null, BlockShapes.S39, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S48 };
    private static readonly BlockStateInfo[] States = [
        I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7017];

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
            return AxisValue switch {
                Axis.X => 7017,
                Axis.Z => 7018,
                _ => throw new ArgumentOutOfRangeException(nameof(AxisValue), AxisValue, "Unknown value for property axis.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7017 => new NetherPortalBlock(Identifier, Axis.X),
            7018 => new NetherPortalBlock(Identifier, Axis.Z),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            AxisValue = properties.Contains("axis") ? AxisFromString(properties["axis"].GetString()) : AxisValue,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("axis", new StringTag(AxisToName(AxisValue)))
        );
    }
    
    public enum Axis {
        X,
        Z,
    }

    public static Axis AxisFromString(string value) {
        return value switch {
            "x" => Axis.X,
            "z" => Axis.Z,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Axis.")
        };
    }

    public static string AxisToName(Axis value) {
        return value switch {
            Axis.X => "x",
            Axis.Z => "z",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Axis value.")
        };
    }
}
