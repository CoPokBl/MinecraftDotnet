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
public record DragonHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.dragon_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:dragon_head", BlockInfo.VanillaOnly, "minecraft:blocks/dragon_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Dragon, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S523, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 12882,
                    1 => 12883,
                    2 => 12884,
                    3 => 12885,
                    4 => 12886,
                    5 => 12887,
                    6 => 12888,
                    7 => 12889,
                    8 => 12890,
                    9 => 12891,
                    10 => 12892,
                    11 => 12893,
                    12 => 12894,
                    13 => 12895,
                    14 => 12896,
                    15 => 12897,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12898,
                    1 => 12899,
                    2 => 12900,
                    3 => 12901,
                    4 => 12902,
                    5 => 12903,
                    6 => 12904,
                    7 => 12905,
                    8 => 12906,
                    9 => 12907,
                    10 => 12908,
                    11 => 12909,
                    12 => 12910,
                    13 => 12911,
                    14 => 12912,
                    15 => 12913,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12882 => new DragonHeadBlock(Identifier, true, 0),
            12883 => new DragonHeadBlock(Identifier, true, 1),
            12884 => new DragonHeadBlock(Identifier, true, 2),
            12885 => new DragonHeadBlock(Identifier, true, 3),
            12886 => new DragonHeadBlock(Identifier, true, 4),
            12887 => new DragonHeadBlock(Identifier, true, 5),
            12888 => new DragonHeadBlock(Identifier, true, 6),
            12889 => new DragonHeadBlock(Identifier, true, 7),
            12890 => new DragonHeadBlock(Identifier, true, 8),
            12891 => new DragonHeadBlock(Identifier, true, 9),
            12892 => new DragonHeadBlock(Identifier, true, 10),
            12893 => new DragonHeadBlock(Identifier, true, 11),
            12894 => new DragonHeadBlock(Identifier, true, 12),
            12895 => new DragonHeadBlock(Identifier, true, 13),
            12896 => new DragonHeadBlock(Identifier, true, 14),
            12897 => new DragonHeadBlock(Identifier, true, 15),
            12898 => new DragonHeadBlock(Identifier, false, 0),
            12899 => new DragonHeadBlock(Identifier, false, 1),
            12900 => new DragonHeadBlock(Identifier, false, 2),
            12901 => new DragonHeadBlock(Identifier, false, 3),
            12902 => new DragonHeadBlock(Identifier, false, 4),
            12903 => new DragonHeadBlock(Identifier, false, 5),
            12904 => new DragonHeadBlock(Identifier, false, 6),
            12905 => new DragonHeadBlock(Identifier, false, 7),
            12906 => new DragonHeadBlock(Identifier, false, 8),
            12907 => new DragonHeadBlock(Identifier, false, 9),
            12908 => new DragonHeadBlock(Identifier, false, 10),
            12909 => new DragonHeadBlock(Identifier, false, 11),
            12910 => new DragonHeadBlock(Identifier, false, 12),
            12911 => new DragonHeadBlock(Identifier, false, 13),
            12912 => new DragonHeadBlock(Identifier, false, 14),
            12913 => new DragonHeadBlock(Identifier, false, 15),
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
