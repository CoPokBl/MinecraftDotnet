using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CreeperWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:wall_skull", "block.minecraft.creeper_head", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:creeper_head", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, [], null, BlockShapes.S514, BlockShapes.S514, BlockShapes.S1, BlockShapes.S514, BlockShapes.S514);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S515, CollisionShape = BlockShapes.S515, OcclusionShape = BlockShapes.S515, VisualShape = BlockShapes.S515 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S516, CollisionShape = BlockShapes.S516, OcclusionShape = BlockShapes.S516, VisualShape = BlockShapes.S516 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S517, CollisionShape = BlockShapes.S517, OcclusionShape = BlockShapes.S517, VisualShape = BlockShapes.S517 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 11107];

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
                    true => 11107,
                    false => 11108,
                },
                Direction.South => Powered switch {
                    true => 11109,
                    false => 11110,
                },
                Direction.West => Powered switch {
                    true => 11111,
                    false => 11112,
                },
                Direction.East => Powered switch {
                    true => 11113,
                    false => 11114,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11107 => new CreeperWallHeadBlock(Identifier, Direction.North, true),
            11108 => new CreeperWallHeadBlock(Identifier, Direction.North, false),
            11109 => new CreeperWallHeadBlock(Identifier, Direction.South, true),
            11110 => new CreeperWallHeadBlock(Identifier, Direction.South, false),
            11111 => new CreeperWallHeadBlock(Identifier, Direction.West, true),
            11112 => new CreeperWallHeadBlock(Identifier, Direction.West, false),
            11113 => new CreeperWallHeadBlock(Identifier, Direction.East, true),
            11114 => new CreeperWallHeadBlock(Identifier, Direction.East, false),
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
