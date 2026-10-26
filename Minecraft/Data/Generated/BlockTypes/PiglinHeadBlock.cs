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
public record PiglinHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.piglin_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:piglin_head", BlockInfo.VanillaOnly, "minecraft:blocks/piglin_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Piglin, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S790, BlockShapes.S790, BlockShapes.S1, BlockShapes.S1, BlockShapes.S790, BlockShapes.S790);

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 12922,
                    1 => 12923,
                    2 => 12924,
                    3 => 12925,
                    4 => 12926,
                    5 => 12927,
                    6 => 12928,
                    7 => 12929,
                    8 => 12930,
                    9 => 12931,
                    10 => 12932,
                    11 => 12933,
                    12 => 12934,
                    13 => 12935,
                    14 => 12936,
                    15 => 12937,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12938,
                    1 => 12939,
                    2 => 12940,
                    3 => 12941,
                    4 => 12942,
                    5 => 12943,
                    6 => 12944,
                    7 => 12945,
                    8 => 12946,
                    9 => 12947,
                    10 => 12948,
                    11 => 12949,
                    12 => 12950,
                    13 => 12951,
                    14 => 12952,
                    15 => 12953,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12922 => new PiglinHeadBlock(Identifier, true, 0),
            12923 => new PiglinHeadBlock(Identifier, true, 1),
            12924 => new PiglinHeadBlock(Identifier, true, 2),
            12925 => new PiglinHeadBlock(Identifier, true, 3),
            12926 => new PiglinHeadBlock(Identifier, true, 4),
            12927 => new PiglinHeadBlock(Identifier, true, 5),
            12928 => new PiglinHeadBlock(Identifier, true, 6),
            12929 => new PiglinHeadBlock(Identifier, true, 7),
            12930 => new PiglinHeadBlock(Identifier, true, 8),
            12931 => new PiglinHeadBlock(Identifier, true, 9),
            12932 => new PiglinHeadBlock(Identifier, true, 10),
            12933 => new PiglinHeadBlock(Identifier, true, 11),
            12934 => new PiglinHeadBlock(Identifier, true, 12),
            12935 => new PiglinHeadBlock(Identifier, true, 13),
            12936 => new PiglinHeadBlock(Identifier, true, 14),
            12937 => new PiglinHeadBlock(Identifier, true, 15),
            12938 => new PiglinHeadBlock(Identifier, false, 0),
            12939 => new PiglinHeadBlock(Identifier, false, 1),
            12940 => new PiglinHeadBlock(Identifier, false, 2),
            12941 => new PiglinHeadBlock(Identifier, false, 3),
            12942 => new PiglinHeadBlock(Identifier, false, 4),
            12943 => new PiglinHeadBlock(Identifier, false, 5),
            12944 => new PiglinHeadBlock(Identifier, false, 6),
            12945 => new PiglinHeadBlock(Identifier, false, 7),
            12946 => new PiglinHeadBlock(Identifier, false, 8),
            12947 => new PiglinHeadBlock(Identifier, false, 9),
            12948 => new PiglinHeadBlock(Identifier, false, 10),
            12949 => new PiglinHeadBlock(Identifier, false, 11),
            12950 => new PiglinHeadBlock(Identifier, false, 12),
            12951 => new PiglinHeadBlock(Identifier, false, 13),
            12952 => new PiglinHeadBlock(Identifier, false, 14),
            12953 => new PiglinHeadBlock(Identifier, false, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("rotation", new StringTag(Rotation.ToString()))
        );
    }
    
}
