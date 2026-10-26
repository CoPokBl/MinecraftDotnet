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
public record PlayerWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.player_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:player_head", BlockInfo.VanillaOnly, "minecraft:blocks/player_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S516, BlockShapes.S516, BlockShapes.S1, BlockShapes.S516, BlockShapes.S516, BlockShapes.S516);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S517, CollisionShape = BlockShapes.S517, OcclusionShape = BlockShapes.S517, VisualShape = BlockShapes.S517, SupportShape = BlockShapes.S517 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S518, CollisionShape = BlockShapes.S518, OcclusionShape = BlockShapes.S518, VisualShape = BlockShapes.S518, SupportShape = BlockShapes.S518 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S519, CollisionShape = BlockShapes.S519, OcclusionShape = BlockShapes.S519, VisualShape = BlockShapes.S519, SupportShape = BlockShapes.S519 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 12834];

    public BlockInfo Info => Data;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
    public float FallDistanceReduction => Data.FallDistanceReduction;
    public bool Gravity => Data.Gravity;
    public string TranslationKey => Data.TranslationKey;
    public Identifier? BlockEntity => Data.BlockEntity;
    public Identifier? Item => Data.Item;
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

    public float Hardness => StateInfo.Hardness;
    public bool Solid => StateInfo.Solid;
    public bool Liquid => StateInfo.Liquid;
    public bool Air => StateInfo.Air;
    public bool Occludes => StateInfo.Occludes;
    public bool RequiresTool => StateInfo.RequiresTool;
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
    public bool ViewBlockingNearPlane => StateInfo.ViewBlockingNearPlane;
    public bool SpawnTerrainParticles => StateInfo.SpawnTerrainParticles;
    public bool PathfindableLand => StateInfo.PathfindableLand;
    public bool PathfindableWater => StateInfo.PathfindableWater;
    public bool PathfindableAir => StateInfo.PathfindableAir;
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Powered switch {
                    true => 12834,
                    false => 12835,
                },
                Direction.South => Powered switch {
                    true => 12836,
                    false => 12837,
                },
                Direction.West => Powered switch {
                    true => 12838,
                    false => 12839,
                },
                Direction.East => Powered switch {
                    true => 12840,
                    false => 12841,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12834 => new PlayerWallHeadBlock(Identifier, Direction.North, true),
            12835 => new PlayerWallHeadBlock(Identifier, Direction.North, false),
            12836 => new PlayerWallHeadBlock(Identifier, Direction.South, true),
            12837 => new PlayerWallHeadBlock(Identifier, Direction.South, false),
            12838 => new PlayerWallHeadBlock(Identifier, Direction.West, true),
            12839 => new PlayerWallHeadBlock(Identifier, Direction.West, false),
            12840 => new PlayerWallHeadBlock(Identifier, Direction.East, true),
            12841 => new PlayerWallHeadBlock(Identifier, Direction.East, false),
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
