using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DamagedAnvilBlock(Identifier Identifier, Direction Facing) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:anvil", "block.minecraft.damaged_anvil", 1200f, 0.6f, 1f, 1f, 0f, true, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:damaged_anvil", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(5f, 0, 0, PushReaction.Block, 6, "anvil", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S321, BlockShapes.S321, BlockShapes.S1, BlockShapes.S321, BlockShapes.S321);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S322, CollisionShape = BlockShapes.S322, OcclusionShape = BlockShapes.S322, VisualShape = BlockShapes.S322 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 11203];

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
            return Facing switch {
                Direction.North => 11203,
                Direction.South => 11204,
                Direction.West => 11205,
                Direction.East => 11206,
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11203 => new DamagedAnvilBlock(Identifier, Direction.North),
            11204 => new DamagedAnvilBlock(Identifier, Direction.South),
            11205 => new DamagedAnvilBlock(Identifier, Direction.West),
            11206 => new DamagedAnvilBlock(Identifier, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
