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
public record DispenserBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.dispenser", 3.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:dispenser", "minecraft:dispenser", BlockInfo.VanillaOnly, "minecraft:blocks/dispenser");
    private static readonly BlockStateInfo I0 = new(3.5f, 0, 15, PushReaction.PushPull, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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
            return Facing switch {
                Cardinal.North => Triggered switch {
                    true => 665,
                    false => 666,
                },
                Cardinal.East => Triggered switch {
                    true => 667,
                    false => 668,
                },
                Cardinal.South => Triggered switch {
                    true => 669,
                    false => 670,
                },
                Cardinal.West => Triggered switch {
                    true => 671,
                    false => 672,
                },
                Cardinal.Up => Triggered switch {
                    true => 673,
                    false => 674,
                },
                Cardinal.Down => Triggered switch {
                    true => 675,
                    false => 676,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            665 => new DispenserBlock(Identifier, Cardinal.North, true),
            666 => new DispenserBlock(Identifier, Cardinal.North, false),
            667 => new DispenserBlock(Identifier, Cardinal.East, true),
            668 => new DispenserBlock(Identifier, Cardinal.East, false),
            669 => new DispenserBlock(Identifier, Cardinal.South, true),
            670 => new DispenserBlock(Identifier, Cardinal.South, false),
            671 => new DispenserBlock(Identifier, Cardinal.West, true),
            672 => new DispenserBlock(Identifier, Cardinal.West, false),
            673 => new DispenserBlock(Identifier, Cardinal.Up, true),
            674 => new DispenserBlock(Identifier, Cardinal.Up, false),
            675 => new DispenserBlock(Identifier, Cardinal.Down, true),
            676 => new DispenserBlock(Identifier, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Triggered = properties.Contains("triggered") ? properties["triggered"].GetString() == "true" : Triggered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("triggered", new StringTag(Triggered.ToString().ToLower()))
        );
    }
    
}
