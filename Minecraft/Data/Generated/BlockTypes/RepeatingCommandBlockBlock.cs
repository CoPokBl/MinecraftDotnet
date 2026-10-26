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
public record RepeatingCommandBlockBlock(Identifier Identifier, bool Conditional, Cardinal Facing) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.repeating_command_block", 3600000f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:command_block", "minecraft:repeating_command_block", BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 15, PushReaction.PushPull, 24, "stone", NoteBlockInstrument.Harp, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
            return Conditional switch {
                true => Facing switch {
                    Cardinal.North => 16798,
                    Cardinal.East => 16799,
                    Cardinal.South => 16800,
                    Cardinal.West => 16801,
                    Cardinal.Up => 16802,
                    Cardinal.Down => 16803,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 16804,
                    Cardinal.East => 16805,
                    Cardinal.South => 16806,
                    Cardinal.West => 16807,
                    Cardinal.Up => 16808,
                    Cardinal.Down => 16809,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            16798 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.North),
            16799 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.East),
            16800 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.South),
            16801 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.West),
            16802 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Up),
            16803 => new RepeatingCommandBlockBlock(Identifier, true, Cardinal.Down),
            16804 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.North),
            16805 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.East),
            16806 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.South),
            16807 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.West),
            16808 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Up),
            16809 => new RepeatingCommandBlockBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Conditional = properties.Contains("conditional") ? properties["conditional"].GetString() == "true" : Conditional,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("conditional", new StringTag(Conditional.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
