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
public record CactusBlock(Identifier Identifier, int Age) : IBlock, IAged {
    private static readonly BlockInfo Data = new("block.minecraft.cactus", 0.4f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:cactus", BlockInfo.VanillaOnly, "minecraft:blocks/cactus");
    private static readonly BlockStateInfo I0 = new(0.4f, 0, 0, PushReaction.Popped, 7, "wool", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, false, true, false, false, false, true, false, false, false, [], null, BlockShapes.S401, BlockShapes.S402, BlockShapes.S1, BlockShapes.S401, BlockShapes.S402, BlockShapes.S402);

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

    public IBlock WithAge(int age) => this with { Age = age };


    public uint StateId {
        get {
            return Age switch {
                0 => 8599,
                1 => 8600,
                2 => 8601,
                3 => 8602,
                4 => 8603,
                5 => 8604,
                6 => 8605,
                7 => 8606,
                8 => 8607,
                9 => 8608,
                10 => 8609,
                11 => 8610,
                12 => 8611,
                13 => 8612,
                14 => 8613,
                15 => 8614,
                _ => throw new ArgumentOutOfRangeException(nameof(Age), Age, "Unknown value for property age.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8599 => new CactusBlock(Identifier, 0),
            8600 => new CactusBlock(Identifier, 1),
            8601 => new CactusBlock(Identifier, 2),
            8602 => new CactusBlock(Identifier, 3),
            8603 => new CactusBlock(Identifier, 4),
            8604 => new CactusBlock(Identifier, 5),
            8605 => new CactusBlock(Identifier, 6),
            8606 => new CactusBlock(Identifier, 7),
            8607 => new CactusBlock(Identifier, 8),
            8608 => new CactusBlock(Identifier, 9),
            8609 => new CactusBlock(Identifier, 10),
            8610 => new CactusBlock(Identifier, 11),
            8611 => new CactusBlock(Identifier, 12),
            8612 => new CactusBlock(Identifier, 13),
            8613 => new CactusBlock(Identifier, 14),
            8614 => new CactusBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Age = properties.Contains("age") ? int.Parse(properties["age"].GetString()) : Age,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("age", new StringTag(Age.ToString()))
        );
    }
    
}
