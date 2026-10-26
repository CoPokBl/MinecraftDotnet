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
public record PistonHeadBlock(Identifier Identifier, PistonHeadBlock.Type TypeValue, Cardinal Facing, bool Short) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.piston_head", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, null, BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 0, PushReaction.Immoveable, 11, "stone", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S808, BlockShapes.S808, BlockShapes.S1, BlockShapes.S808, BlockShapes.S808, BlockShapes.S808);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S809, CollisionShape = BlockShapes.S809, OcclusionShape = BlockShapes.S809, VisualShape = BlockShapes.S809, SupportShape = BlockShapes.S809 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S810, CollisionShape = BlockShapes.S810, OcclusionShape = BlockShapes.S810, VisualShape = BlockShapes.S810, SupportShape = BlockShapes.S810 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S811, CollisionShape = BlockShapes.S811, OcclusionShape = BlockShapes.S811, VisualShape = BlockShapes.S811, SupportShape = BlockShapes.S811 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S812, CollisionShape = BlockShapes.S812, OcclusionShape = BlockShapes.S812, VisualShape = BlockShapes.S812, SupportShape = BlockShapes.S812 };
    private static readonly BlockStateInfo I5 = I0 with { BlockShape = BlockShapes.S813, CollisionShape = BlockShapes.S813, OcclusionShape = BlockShapes.S813, VisualShape = BlockShapes.S813, SupportShape = BlockShapes.S813 };
    private static readonly BlockStateInfo I6 = I0 with { BlockShape = BlockShapes.S814, CollisionShape = BlockShapes.S814, OcclusionShape = BlockShapes.S814, VisualShape = BlockShapes.S814, SupportShape = BlockShapes.S814 };
    private static readonly BlockStateInfo I7 = I0 with { BlockShape = BlockShapes.S815, CollisionShape = BlockShapes.S815, OcclusionShape = BlockShapes.S815, VisualShape = BlockShapes.S815, SupportShape = BlockShapes.S815 };
    private static readonly BlockStateInfo I8 = I0 with { ValidSpawnFor = null, BlockShape = BlockShapes.S816, CollisionShape = BlockShapes.S816, OcclusionShape = BlockShapes.S816, VisualShape = BlockShapes.S816, SupportShape = BlockShapes.S816 };
    private static readonly BlockStateInfo I9 = I0 with { ValidSpawnFor = null, BlockShape = BlockShapes.S817, CollisionShape = BlockShapes.S817, OcclusionShape = BlockShapes.S817, VisualShape = BlockShapes.S817, SupportShape = BlockShapes.S817 };
    private static readonly BlockStateInfo I10 = I0 with { BlockShape = BlockShapes.S818, CollisionShape = BlockShapes.S818, OcclusionShape = BlockShapes.S818, VisualShape = BlockShapes.S818, SupportShape = BlockShapes.S818 };
    private static readonly BlockStateInfo I11 = I0 with { BlockShape = BlockShapes.S819, CollisionShape = BlockShapes.S819, OcclusionShape = BlockShapes.S819, VisualShape = BlockShapes.S819, SupportShape = BlockShapes.S819 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I1, I1, I2, I2, I3, I3, I4, I4, I5, I5, I6, I6, I7, I7, I8, I8, I9, I9, I10, I10, I11, I11
    ];

    public BlockStateInfo StateInfo => States[StateId - 2385];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Normal => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2385,
                        false => 2387,
                    },
                    Cardinal.East => Short switch {
                        true => 2389,
                        false => 2391,
                    },
                    Cardinal.South => Short switch {
                        true => 2393,
                        false => 2395,
                    },
                    Cardinal.West => Short switch {
                        true => 2397,
                        false => 2399,
                    },
                    Cardinal.Up => Short switch {
                        true => 2401,
                        false => 2403,
                    },
                    Cardinal.Down => Short switch {
                        true => 2405,
                        false => 2407,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2386,
                        false => 2388,
                    },
                    Cardinal.East => Short switch {
                        true => 2390,
                        false => 2392,
                    },
                    Cardinal.South => Short switch {
                        true => 2394,
                        false => 2396,
                    },
                    Cardinal.West => Short switch {
                        true => 2398,
                        false => 2400,
                    },
                    Cardinal.Up => Short switch {
                        true => 2402,
                        false => 2404,
                    },
                    Cardinal.Down => Short switch {
                        true => 2406,
                        false => 2408,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2385 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, true),
            2386 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, true),
            2387 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, false),
            2388 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, false),
            2389 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, true),
            2390 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, true),
            2391 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, false),
            2392 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, false),
            2393 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, true),
            2394 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, true),
            2395 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, false),
            2396 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, false),
            2397 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, true),
            2398 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, true),
            2399 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, false),
            2400 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, false),
            2401 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, true),
            2402 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, true),
            2403 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, false),
            2404 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, false),
            2405 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, true),
            2406 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, true),
            2407 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, false),
            2408 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Short = properties.Contains("short") ? properties["short"].GetString() == "true" : Short,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("short", new StringTag(Short.ToString().ToLower()))
        );
    }
    
    public enum Type {
        Normal,
        Sticky,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "normal" => Type.Normal,
            "sticky" => Type.Sticky,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }

    public static string TypeToName(Type value) {
        return value switch {
            Type.Normal => "normal",
            Type.Sticky => "sticky",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type value.")
        };
    }
}
