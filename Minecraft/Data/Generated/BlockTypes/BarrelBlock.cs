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
    private static readonly BlockInfo Data = new("minecraft:barrel", "block.minecraft.barrel", 2.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:barrel", "minecraft:barrel", BlockInfo.VanillaOnly, "minecraft:blocks/barrel");
    private static readonly BlockStateInfo I0 = new(2.5f, 0, 15, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, false, true, false, true, false, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

    public BlockStateInfo StateInfo => I0;

    public BlockInfo Info => Data;
    public Identifier Category => Data.Category;
    public float ExplosionResistance => Data.ExplosionResistance;
    public float Friction => Data.Friction;
    public float SpeedFactor => Data.SpeedFactor;
    public float JumpFactor => Data.JumpFactor;
    public float BounceRestitution => Data.BounceRestitution;
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
    public bool BlocksMotion => StateInfo.BlocksMotion;
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
                    true => 20742,
                    false => 20743,
                },
                Cardinal.East => Open switch {
                    true => 20744,
                    false => 20745,
                },
                Cardinal.South => Open switch {
                    true => 20746,
                    false => 20747,
                },
                Cardinal.West => Open switch {
                    true => 20748,
                    false => 20749,
                },
                Cardinal.Up => Open switch {
                    true => 20750,
                    false => 20751,
                },
                Cardinal.Down => Open switch {
                    true => 20752,
                    false => 20753,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20742 => new BarrelBlock(Identifier, Cardinal.North, true),
            20743 => new BarrelBlock(Identifier, Cardinal.North, false),
            20744 => new BarrelBlock(Identifier, Cardinal.East, true),
            20745 => new BarrelBlock(Identifier, Cardinal.East, false),
            20746 => new BarrelBlock(Identifier, Cardinal.South, true),
            20747 => new BarrelBlock(Identifier, Cardinal.South, false),
            20748 => new BarrelBlock(Identifier, Cardinal.West, true),
            20749 => new BarrelBlock(Identifier, Cardinal.West, false),
            20750 => new BarrelBlock(Identifier, Cardinal.Up, true),
            20751 => new BarrelBlock(Identifier, Cardinal.Up, false),
            20752 => new BarrelBlock(Identifier, Cardinal.Down, true),
            20753 => new BarrelBlock(Identifier, Cardinal.Down, false),
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
