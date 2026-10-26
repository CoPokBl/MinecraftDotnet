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
public record FurnaceBlock(Identifier Identifier, Direction Facing, bool Lit) : IBlock, IHorizontalFacing, ILit {
    private static readonly BlockInfo Data = new("block.minecraft.furnace", 3.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:furnace", "minecraft:furnace", BlockInfo.VanillaOnly, "minecraft:blocks/furnace");
    private static readonly BlockStateInfo I0 = new(3.5f, 13, 15, PushReaction.PushPull, 11, "stone", NoteBlockInstrument.Basedrum, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);
    private static readonly BlockStateInfo I1 = I0 with { LightEmission = 0 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 6883];

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

    public IBlock WithLit(bool lit) => this with { Lit = lit };


    public uint StateId {
        get {
            return Facing switch {
                Direction.North => Lit switch {
                    true => 6883,
                    false => 6884,
                },
                Direction.South => Lit switch {
                    true => 6885,
                    false => 6886,
                },
                Direction.West => Lit switch {
                    true => 6887,
                    false => 6888,
                },
                Direction.East => Lit switch {
                    true => 6889,
                    false => 6890,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6883 => new FurnaceBlock(Identifier, Direction.North, true),
            6884 => new FurnaceBlock(Identifier, Direction.North, false),
            6885 => new FurnaceBlock(Identifier, Direction.South, true),
            6886 => new FurnaceBlock(Identifier, Direction.South, false),
            6887 => new FurnaceBlock(Identifier, Direction.West, true),
            6888 => new FurnaceBlock(Identifier, Direction.West, false),
            6889 => new FurnaceBlock(Identifier, Direction.East, true),
            6890 => new FurnaceBlock(Identifier, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("facing", new StringTag(Facing.ToName())),
            ("lit", new StringTag(Lit.ToString().ToLower()))
        );
    }
    
}
