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
public record MovingPistonBlock(Identifier Identifier, MovingPistonBlock.Type TypeValue, Cardinal Facing) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.moving_piston", 0f, 0.6f, 1f, 1f, 0f, 0f, false, true, BlockOffsetType.None, 0f, 0f, "minecraft:piston", null, BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 0, PushReaction.Immoveable, 11, "stone", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);

    public BlockStateInfo StateInfo => I0;

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
                    Cardinal.North => 3801,
                    Cardinal.East => 3803,
                    Cardinal.South => 3805,
                    Cardinal.West => 3807,
                    Cardinal.Up => 3809,
                    Cardinal.Down => 3811,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => 3802,
                    Cardinal.East => 3804,
                    Cardinal.South => 3806,
                    Cardinal.West => 3808,
                    Cardinal.Up => 3810,
                    Cardinal.Down => 3812,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            3801 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.North),
            3802 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.North),
            3803 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.East),
            3804 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.East),
            3805 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.South),
            3806 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.South),
            3807 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.West),
            3808 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.West),
            3809 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Up),
            3810 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Up),
            3811 => new MovingPistonBlock(Identifier, Type.Normal, Cardinal.Down),
            3812 => new MovingPistonBlock(Identifier, Type.Sticky, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName()))
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
