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
public record EndPortalFrameBlock(Identifier Identifier, bool Eye, Direction Facing) : IBlock, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.end_portal_frame", 3600000f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:end_portal_frame", BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 1, 0, PushReaction.PushPull, 27, "glass", NoteBlockInstrument.Basedrum, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S527, BlockShapes.S527, BlockShapes.S1, BlockShapes.S527, BlockShapes.S527, BlockShapes.S527);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S400, CollisionShape = BlockShapes.S400, OcclusionShape = BlockShapes.S400, VisualShape = BlockShapes.S400, SupportShape = BlockShapes.S400 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I0, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 11203];

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


    public uint StateId {
        get {
            return Eye switch {
                true => Facing switch {
                    Direction.North => 11203,
                    Direction.South => 11204,
                    Direction.West => 11205,
                    Direction.East => 11206,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => 11207,
                    Direction.South => 11208,
                    Direction.West => 11209,
                    Direction.East => 11210,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11203 => new EndPortalFrameBlock(Identifier, true, Direction.North),
            11204 => new EndPortalFrameBlock(Identifier, true, Direction.South),
            11205 => new EndPortalFrameBlock(Identifier, true, Direction.West),
            11206 => new EndPortalFrameBlock(Identifier, true, Direction.East),
            11207 => new EndPortalFrameBlock(Identifier, false, Direction.North),
            11208 => new EndPortalFrameBlock(Identifier, false, Direction.South),
            11209 => new EndPortalFrameBlock(Identifier, false, Direction.West),
            11210 => new EndPortalFrameBlock(Identifier, false, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eye = properties.Contains("eye") ? properties["eye"].GetString() == "true" : Eye,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("eye", new StringTag(Eye.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
