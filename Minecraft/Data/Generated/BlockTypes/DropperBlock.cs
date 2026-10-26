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
public record DropperBlock(Identifier Identifier, Cardinal Facing, bool Triggered) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.dropper", 3.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:dropper", "minecraft:dropper", BlockInfo.VanillaOnly, "minecraft:blocks/dropper");
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
                    true => 13199,
                    false => 13200,
                },
                Cardinal.East => Triggered switch {
                    true => 13201,
                    false => 13202,
                },
                Cardinal.South => Triggered switch {
                    true => 13203,
                    false => 13204,
                },
                Cardinal.West => Triggered switch {
                    true => 13205,
                    false => 13206,
                },
                Cardinal.Up => Triggered switch {
                    true => 13207,
                    false => 13208,
                },
                Cardinal.Down => Triggered switch {
                    true => 13209,
                    false => 13210,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13199 => new DropperBlock(Identifier, Cardinal.North, true),
            13200 => new DropperBlock(Identifier, Cardinal.North, false),
            13201 => new DropperBlock(Identifier, Cardinal.East, true),
            13202 => new DropperBlock(Identifier, Cardinal.East, false),
            13203 => new DropperBlock(Identifier, Cardinal.South, true),
            13204 => new DropperBlock(Identifier, Cardinal.South, false),
            13205 => new DropperBlock(Identifier, Cardinal.West, true),
            13206 => new DropperBlock(Identifier, Cardinal.West, false),
            13207 => new DropperBlock(Identifier, Cardinal.Up, true),
            13208 => new DropperBlock(Identifier, Cardinal.Up, false),
            13209 => new DropperBlock(Identifier, Cardinal.Down, true),
            13210 => new DropperBlock(Identifier, Cardinal.Down, false),
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
