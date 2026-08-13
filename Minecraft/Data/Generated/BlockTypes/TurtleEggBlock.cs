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
    private static readonly BlockInfo Data = new("minecraft:turtle_egg", "block.minecraft.turtle_egg", 0.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:turtle_egg", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.5f, 0, 0, PushReaction.Destroy, 2, "metal", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, true, false, false, true, true, false, true, [], null, BlockShapes.S930, BlockShapes.S930, BlockShapes.S1, BlockShapes.S1, BlockShapes.S930, BlockShapes.S930);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S931, CollisionShape = BlockShapes.S931, VisualShape = BlockShapes.S931, SupportShape = BlockShapes.S931 };
    private static readonly BlockStateInfo[] States = [
        I0, I0, I0, I1, I1, I1, I1, I1, I1, I1, I1, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 15090];

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

    public int Count => Eggs;

    public int MaxCount => 4;

    public IBlock WithCount(int count) => this with { Eggs = count };


    public uint StateId {
        get {
            return Eggs switch {
                1 => Hatch switch {
                    0 => 15090,
                    1 => 15091,
                    2 => 15092,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                2 => Hatch switch {
                    0 => 15093,
                    1 => 15094,
                    2 => 15095,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                3 => Hatch switch {
                    0 => 15096,
                    1 => 15097,
                    2 => 15098,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                4 => Hatch switch {
                    0 => 15099,
                    1 => 15100,
                    2 => 15101,
                    _ => throw new ArgumentOutOfRangeException(nameof(Hatch), Hatch, "Unknown value for property hatch.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Eggs), Eggs, "Unknown value for property eggs.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            15090 => new TurtleEggBlock(Identifier, 1, 0),
            15091 => new TurtleEggBlock(Identifier, 1, 1),
            15092 => new TurtleEggBlock(Identifier, 1, 2),
            15093 => new TurtleEggBlock(Identifier, 2, 0),
            15094 => new TurtleEggBlock(Identifier, 2, 1),
            15095 => new TurtleEggBlock(Identifier, 2, 2),
            15096 => new TurtleEggBlock(Identifier, 3, 0),
            15097 => new TurtleEggBlock(Identifier, 3, 1),
            15098 => new TurtleEggBlock(Identifier, 3, 2),
            15099 => new TurtleEggBlock(Identifier, 4, 0),
            15100 => new TurtleEggBlock(Identifier, 4, 1),
            15101 => new TurtleEggBlock(Identifier, 4, 2),
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
