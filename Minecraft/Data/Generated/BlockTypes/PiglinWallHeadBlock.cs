using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PiglinWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:piglinwallskull", "block.minecraft.piglin_head", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:piglin_head", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, [], null, BlockShapes.S788, BlockShapes.S788, BlockShapes.S1, BlockShapes.S788, BlockShapes.S788);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S789, CollisionShape = BlockShapes.S789, OcclusionShape = BlockShapes.S789, VisualShape = BlockShapes.S789 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S790, CollisionShape = BlockShapes.S790, OcclusionShape = BlockShapes.S790, VisualShape = BlockShapes.S790 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S791, CollisionShape = BlockShapes.S791, OcclusionShape = BlockShapes.S791, VisualShape = BlockShapes.S791 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 11187];

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
                Direction.North => Powered switch {
                    true => 11187,
                    false => 11188,
                },
                Direction.South => Powered switch {
                    true => 11189,
                    false => 11190,
                },
                Direction.West => Powered switch {
                    true => 11191,
                    false => 11192,
                },
                Direction.East => Powered switch {
                    true => 11193,
                    false => 11194,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11187 => new PiglinWallHeadBlock(Identifier, Direction.North, true),
            11188 => new PiglinWallHeadBlock(Identifier, Direction.North, false),
            11189 => new PiglinWallHeadBlock(Identifier, Direction.South, true),
            11190 => new PiglinWallHeadBlock(Identifier, Direction.South, false),
            11191 => new PiglinWallHeadBlock(Identifier, Direction.West, true),
            11192 => new PiglinWallHeadBlock(Identifier, Direction.West, false),
            11193 => new PiglinWallHeadBlock(Identifier, Direction.East, true),
            11194 => new PiglinWallHeadBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
