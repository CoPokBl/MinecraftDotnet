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
public record GrindstoneBlock(Identifier Identifier, AttachDirection Face, Direction Facing) : IBlock, IAttachFaced, IHorizontalFacing {
    private static readonly BlockInfo Data = new("block.minecraft.grindstone", 6f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:grindstone", BlockInfo.VanillaOnly, "minecraft:blocks/grindstone");
    private static readonly BlockStateInfo I0 = new(2f, 0, 0, PushReaction.Immoveable, 6, "stone", NoteBlockInstrument.Harp, false, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S593, BlockShapes.S593, BlockShapes.S1, BlockShapes.S593, BlockShapes.S593, BlockShapes.S593);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S594, CollisionShape = BlockShapes.S594, OcclusionShape = BlockShapes.S594, VisualShape = BlockShapes.S594, SupportShape = BlockShapes.S594 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S595, CollisionShape = BlockShapes.S595, OcclusionShape = BlockShapes.S595, VisualShape = BlockShapes.S595, SupportShape = BlockShapes.S595 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S596, CollisionShape = BlockShapes.S596, OcclusionShape = BlockShapes.S596, VisualShape = BlockShapes.S596, SupportShape = BlockShapes.S596 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S597, CollisionShape = BlockShapes.S597, OcclusionShape = BlockShapes.S597, VisualShape = BlockShapes.S597, SupportShape = BlockShapes.S597 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S598, CollisionShape = BlockShapes.S598, OcclusionShape = BlockShapes.S598, VisualShape = BlockShapes.S598, SupportShape = BlockShapes.S598 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S599, CollisionShape = BlockShapes.S599, OcclusionShape = BlockShapes.S599, VisualShape = BlockShapes.S599, SupportShape = BlockShapes.S599 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S600, CollisionShape = BlockShapes.S600, OcclusionShape = BlockShapes.S600, VisualShape = BlockShapes.S600, SupportShape = BlockShapes.S600 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I3, I4, I5, I6, I6, I7, I7
    ];

    public BlockStateInfo StateInfo => States[StateId - 24129];

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

    public IBlock WithFace(AttachDirection face) => this with { Face = face };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Face switch {
                AttachDirection.Floor => Facing switch {
                    Direction.North => 24129,
                    Direction.South => 24130,
                    Direction.West => 24131,
                    Direction.East => 24132,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Wall => Facing switch {
                    Direction.North => 24133,
                    Direction.South => 24134,
                    Direction.West => 24135,
                    Direction.East => 24136,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                AttachDirection.Ceiling => Facing switch {
                    Direction.North => 24137,
                    Direction.South => 24138,
                    Direction.West => 24139,
                    Direction.East => 24140,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Face), Face, "Unknown value for property face.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24129 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.North),
            24130 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.South),
            24131 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.West),
            24132 => new GrindstoneBlock(Identifier, AttachDirection.Floor, Direction.East),
            24133 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.North),
            24134 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.South),
            24135 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.West),
            24136 => new GrindstoneBlock(Identifier, AttachDirection.Wall, Direction.East),
            24137 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.North),
            24138 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.South),
            24139 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.West),
            24140 => new GrindstoneBlock(Identifier, AttachDirection.Ceiling, Direction.East),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Face = properties.Contains("face") ? AttachDirectionExtensions.FromString(properties["face"].GetString()) : Face,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("face", new StringTag(Face.ToName())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
