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
public record TripwireHookBlock(Identifier Identifier, bool Attached, Direction Facing, bool Powered) : IBlock, IAttached, IHorizontalFacing, IPowered {
    private static readonly BlockInfo Data = new("block.minecraft.tripwire_hook", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:tripwire_hook", BlockInfo.VanillaOnly, "minecraft:blocks/tripwire_hook");
    private static readonly BlockStateInfo I0 = new(0f, 0, 0, PushReaction.Popped, 0, "wood", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, false, true, [], null, BlockShapes.S939, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S940 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S941 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S942 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3, I0, I0, I1, I1, I2, I2, I3, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 11325];

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

    public IBlock WithAttached(bool attached) => this with { Attached = attached };

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithPowered(bool powered) => this with { Powered = powered };


    public uint StateId {
        get {
            return Attached switch {
                true => Facing switch {
                    Direction.North => Powered switch {
                        true => 11325,
                        false => 11326,
                    },
                    Direction.South => Powered switch {
                        true => 11327,
                        false => 11328,
                    },
                    Direction.West => Powered switch {
                        true => 11329,
                        false => 11330,
                    },
                    Direction.East => Powered switch {
                        true => 11331,
                        false => 11332,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Powered switch {
                        true => 11333,
                        false => 11334,
                    },
                    Direction.South => Powered switch {
                        true => 11335,
                        false => 11336,
                    },
                    Direction.West => Powered switch {
                        true => 11337,
                        false => 11338,
                    },
                    Direction.East => Powered switch {
                        true => 11339,
                        false => 11340,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11325 => new TripwireHookBlock(Identifier, true, Direction.North, true),
            11326 => new TripwireHookBlock(Identifier, true, Direction.North, false),
            11327 => new TripwireHookBlock(Identifier, true, Direction.South, true),
            11328 => new TripwireHookBlock(Identifier, true, Direction.South, false),
            11329 => new TripwireHookBlock(Identifier, true, Direction.West, true),
            11330 => new TripwireHookBlock(Identifier, true, Direction.West, false),
            11331 => new TripwireHookBlock(Identifier, true, Direction.East, true),
            11332 => new TripwireHookBlock(Identifier, true, Direction.East, false),
            11333 => new TripwireHookBlock(Identifier, false, Direction.North, true),
            11334 => new TripwireHookBlock(Identifier, false, Direction.North, false),
            11335 => new TripwireHookBlock(Identifier, false, Direction.South, true),
            11336 => new TripwireHookBlock(Identifier, false, Direction.South, false),
            11337 => new TripwireHookBlock(Identifier, false, Direction.West, true),
            11338 => new TripwireHookBlock(Identifier, false, Direction.West, false),
            11339 => new TripwireHookBlock(Identifier, false, Direction.East, true),
            11340 => new TripwireHookBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.Contains("attached") ? properties["attached"].GetString() == "true" : Attached,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("attached", new StringTag(Attached.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
