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
public record CreeperWallHeadBlock(Identifier Identifier, Direction Facing, bool Powered) : IBlock, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.creeper_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:creeper_head", BlockInfo.VanillaOnly, "minecraft:blocks/creeper_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Harp, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S516, BlockShapes.S516, BlockShapes.S1, BlockShapes.S516, BlockShapes.S516, BlockShapes.S516);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S517, CollisionShape = BlockShapes.S517, OcclusionShape = BlockShapes.S517, VisualShape = BlockShapes.S517, SupportShape = BlockShapes.S517 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S518, CollisionShape = BlockShapes.S518, OcclusionShape = BlockShapes.S518, VisualShape = BlockShapes.S518, SupportShape = BlockShapes.S518 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S519, CollisionShape = BlockShapes.S519, OcclusionShape = BlockShapes.S519, VisualShape = BlockShapes.S519, SupportShape = BlockShapes.S519 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 12874];

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
                    true => 12874,
                    false => 12875,
                },
                Direction.South => Powered switch {
                    true => 12876,
                    false => 12877,
                },
                Direction.West => Powered switch {
                    true => 12878,
                    false => 12879,
                },
                Direction.East => Powered switch {
                    true => 12880,
                    false => 12881,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12874 => new CreeperWallHeadBlock(Identifier, Direction.North, true),
            12875 => new CreeperWallHeadBlock(Identifier, Direction.North, false),
            12876 => new CreeperWallHeadBlock(Identifier, Direction.South, true),
            12877 => new CreeperWallHeadBlock(Identifier, Direction.South, false),
            12878 => new CreeperWallHeadBlock(Identifier, Direction.West, true),
            12879 => new CreeperWallHeadBlock(Identifier, Direction.West, false),
            12880 => new CreeperWallHeadBlock(Identifier, Direction.East, true),
            12881 => new CreeperWallHeadBlock(Identifier, Direction.East, false),
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
