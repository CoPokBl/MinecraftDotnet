using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record TargetBlock(Identifier Identifier, int Power) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:target", "block.minecraft.target", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:target", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 15, PushReaction.Normal, 14, "grass", NoteBlockInstrument.Harp, false, true, false, true, true, false, false, false, true, true, true, false, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);

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
            return Power switch {
                0 => 21752,
                1 => 21753,
                2 => 21754,
                3 => 21755,
                4 => 21756,
                5 => 21757,
                6 => 21758,
                7 => 21759,
                8 => 21760,
                9 => 21761,
                10 => 21762,
                11 => 21763,
                12 => 21764,
                13 => 21765,
                14 => 21766,
                15 => 21767,
                _ => throw new ArgumentOutOfRangeException(nameof(Power), Power, "Unknown value for property power.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21752 => new TargetBlock(Identifier, 0),
            21753 => new TargetBlock(Identifier, 1),
            21754 => new TargetBlock(Identifier, 2),
            21755 => new TargetBlock(Identifier, 3),
            21756 => new TargetBlock(Identifier, 4),
            21757 => new TargetBlock(Identifier, 5),
            21758 => new TargetBlock(Identifier, 6),
            21759 => new TargetBlock(Identifier, 7),
            21760 => new TargetBlock(Identifier, 8),
            21761 => new TargetBlock(Identifier, 9),
            21762 => new TargetBlock(Identifier, 10),
            21763 => new TargetBlock(Identifier, 11),
            21764 => new TargetBlock(Identifier, 12),
            21765 => new TargetBlock(Identifier, 13),
            21766 => new TargetBlock(Identifier, 14),
            21767 => new TargetBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Power = properties.Contains("power") ? int.Parse(properties["power"].GetString()) : Power,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("power", new StringTag(Power.ToString()))
        );
    }
    
}
