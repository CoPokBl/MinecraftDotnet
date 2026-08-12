using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MelonStemBlock(Identifier Identifier, int Age) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:stem", "block.minecraft.melon_stem", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:melon_seeds", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Destroy, 7, "hard_crop", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, [], null, BlockShapes.S647, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S648 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S364 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S649 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S650 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S651 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S652 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S385 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 8350];

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
            return Age switch {
                0 => 8350,
                1 => 8351,
                2 => 8352,
                3 => 8353,
                4 => 8354,
                5 => 8355,
                6 => 8356,
                7 => 8357,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8350 => new MelonStemBlock(Identifier, 0),
            8351 => new MelonStemBlock(Identifier, 1),
            8352 => new MelonStemBlock(Identifier, 2),
            8353 => new MelonStemBlock(Identifier, 3),
            8354 => new MelonStemBlock(Identifier, 4),
            8355 => new MelonStemBlock(Identifier, 5),
            8356 => new MelonStemBlock(Identifier, 6),
            8357 => new MelonStemBlock(Identifier, 7),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString()))
        );
    }
    
}
