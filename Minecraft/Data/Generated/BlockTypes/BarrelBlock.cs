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
public record BarrelBlock(Identifier Identifier, Cardinal Facing, bool Open) : IBlock, IDirectional, IOpenable {
    private static readonly BlockInfo Data = new("block.minecraft.barrel", 2.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:barrel", "minecraft:barrel", BlockInfo.VanillaOnly, "minecraft:blocks/barrel");
    private static readonly BlockStateInfo I0 = new(2.5f, 0, 15, PushReaction.PushPull, 13, "wood", NoteBlockInstrument.Bass, false, true, false, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithOpen(bool open) => this with { Open = open };


    public uint StateId {
        get {
            return Facing switch {
                Cardinal.North => Open switch {
                    true => 24099,
                    false => 24100,
                },
                Cardinal.East => Open switch {
                    true => 24101,
                    false => 24102,
                },
                Cardinal.South => Open switch {
                    true => 24103,
                    false => 24104,
                },
                Cardinal.West => Open switch {
                    true => 24105,
                    false => 24106,
                },
                Cardinal.Up => Open switch {
                    true => 24107,
                    false => 24108,
                },
                Cardinal.Down => Open switch {
                    true => 24109,
                    false => 24110,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            24099 => new BarrelBlock(Identifier, Cardinal.North, true),
            24100 => new BarrelBlock(Identifier, Cardinal.North, false),
            24101 => new BarrelBlock(Identifier, Cardinal.East, true),
            24102 => new BarrelBlock(Identifier, Cardinal.East, false),
            24103 => new BarrelBlock(Identifier, Cardinal.South, true),
            24104 => new BarrelBlock(Identifier, Cardinal.South, false),
            24105 => new BarrelBlock(Identifier, Cardinal.West, true),
            24106 => new BarrelBlock(Identifier, Cardinal.West, false),
            24107 => new BarrelBlock(Identifier, Cardinal.Up, true),
            24108 => new BarrelBlock(Identifier, Cardinal.Up, false),
            24109 => new BarrelBlock(Identifier, Cardinal.Down, true),
            24110 => new BarrelBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Open = properties.Contains("open") ? properties["open"].GetString() == "true" : Open,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("open", new StringTag(Open.ToString().ToLower()))
        );
    }
    
}
