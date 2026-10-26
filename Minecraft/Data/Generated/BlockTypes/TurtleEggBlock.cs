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
public record TurtleEggBlock(Identifier Identifier, int Eggs, int Hatch) : IBlock, IStackable {
    private static readonly BlockInfo Data = new("block.minecraft.turtle_egg", 0.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:turtle_egg", BlockInfo.VanillaOnly, "minecraft:blocks/turtle_egg");
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Popped, 2, "metal", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, true, false, false, false, true, true, false, true, [], null, BlockShapes.S943, BlockShapes.S943, BlockShapes.S1, BlockShapes.S1, BlockShapes.S943, BlockShapes.S943);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S944, CollisionShape = BlockShapes.S944, VisualShape = BlockShapes.S944, SupportShape = BlockShapes.S944 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 18447];

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

    public int Count => Eggs;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { Eggs = count };


    public uint StateId {
        get {
            return Eggs switch {
                1 => Hatch switch {
                    0 => 18447,
                    1 => 18448,
                    2 => 18449,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                2 => Hatch switch {
                    0 => 18450,
                    1 => 18451,
                    2 => 18452,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                3 => Hatch switch {
                    0 => 18453,
                    1 => 18454,
                    2 => 18455,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                4 => Hatch switch {
                    0 => 18456,
                    1 => 18457,
                    2 => 18458,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Eggs), Eggs, "Unknown value for property eggs.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            18447 => new TurtleEggBlock(Identifier, 1, 0),
            18448 => new TurtleEggBlock(Identifier, 1, 1),
            18449 => new TurtleEggBlock(Identifier, 1, 2),
            18450 => new TurtleEggBlock(Identifier, 2, 0),
            18451 => new TurtleEggBlock(Identifier, 2, 1),
            18452 => new TurtleEggBlock(Identifier, 2, 2),
            18453 => new TurtleEggBlock(Identifier, 3, 0),
            18454 => new TurtleEggBlock(Identifier, 3, 1),
            18455 => new TurtleEggBlock(Identifier, 3, 2),
            18456 => new TurtleEggBlock(Identifier, 4, 0),
            18457 => new TurtleEggBlock(Identifier, 4, 1),
            18458 => new TurtleEggBlock(Identifier, 4, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Eggs = properties.Contains("eggs") ? int.Parse(properties["eggs"].GetString()) : Eggs,
            Hatch = properties.Contains("hatch") ? int.Parse(properties["hatch"].GetString()) : Hatch,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("eggs", new StringTag(Eggs.ToString())),
            ("hatch", new StringTag(Hatch.ToString()))
        );
    }
    
}
