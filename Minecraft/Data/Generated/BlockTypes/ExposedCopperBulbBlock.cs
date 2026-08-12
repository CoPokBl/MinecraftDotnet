using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ExposedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:weathering_copper_bulb", "block.minecraft.exposed_copper_bulb", 6f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:exposed_copper_bulb", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(3f, 12, 15, PushReaction.Normal, 44, "copper_bulb", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, false, false, true, true, true, true, null, null, BlockShapes.S77, BlockShapes.S77, BlockShapes.S1, BlockShapes.S77, BlockShapes.S77);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 29540];

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
            return Lit switch {
                true => Powered switch {
                    true => 29540,
                    false => 29541,
                },
                false => Powered switch {
                    true => 29542,
                    false => 29543,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29540 => new ExposedCopperBulbBlock(Identifier, true, true),
            29541 => new ExposedCopperBulbBlock(Identifier, true, false),
            29542 => new ExposedCopperBulbBlock(Identifier, false, true),
            29543 => new ExposedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
