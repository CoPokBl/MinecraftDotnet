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
public record CreeperHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.creeper_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:creeper_head", BlockInfo.VanillaOnly, "minecraft:blocks/creeper_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Creeper, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 12842,
                    1 => 12843,
                    2 => 12844,
                    3 => 12845,
                    4 => 12846,
                    5 => 12847,
                    6 => 12848,
                    7 => 12849,
                    8 => 12850,
                    9 => 12851,
                    10 => 12852,
                    11 => 12853,
                    12 => 12854,
                    13 => 12855,
                    14 => 12856,
                    15 => 12857,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12858,
                    1 => 12859,
                    2 => 12860,
                    3 => 12861,
                    4 => 12862,
                    5 => 12863,
                    6 => 12864,
                    7 => 12865,
                    8 => 12866,
                    9 => 12867,
                    10 => 12868,
                    11 => 12869,
                    12 => 12870,
                    13 => 12871,
                    14 => 12872,
                    15 => 12873,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12842 => new CreeperHeadBlock(Identifier, true, 0),
            12843 => new CreeperHeadBlock(Identifier, true, 1),
            12844 => new CreeperHeadBlock(Identifier, true, 2),
            12845 => new CreeperHeadBlock(Identifier, true, 3),
            12846 => new CreeperHeadBlock(Identifier, true, 4),
            12847 => new CreeperHeadBlock(Identifier, true, 5),
            12848 => new CreeperHeadBlock(Identifier, true, 6),
            12849 => new CreeperHeadBlock(Identifier, true, 7),
            12850 => new CreeperHeadBlock(Identifier, true, 8),
            12851 => new CreeperHeadBlock(Identifier, true, 9),
            12852 => new CreeperHeadBlock(Identifier, true, 10),
            12853 => new CreeperHeadBlock(Identifier, true, 11),
            12854 => new CreeperHeadBlock(Identifier, true, 12),
            12855 => new CreeperHeadBlock(Identifier, true, 13),
            12856 => new CreeperHeadBlock(Identifier, true, 14),
            12857 => new CreeperHeadBlock(Identifier, true, 15),
            12858 => new CreeperHeadBlock(Identifier, false, 0),
            12859 => new CreeperHeadBlock(Identifier, false, 1),
            12860 => new CreeperHeadBlock(Identifier, false, 2),
            12861 => new CreeperHeadBlock(Identifier, false, 3),
            12862 => new CreeperHeadBlock(Identifier, false, 4),
            12863 => new CreeperHeadBlock(Identifier, false, 5),
            12864 => new CreeperHeadBlock(Identifier, false, 6),
            12865 => new CreeperHeadBlock(Identifier, false, 7),
            12866 => new CreeperHeadBlock(Identifier, false, 8),
            12867 => new CreeperHeadBlock(Identifier, false, 9),
            12868 => new CreeperHeadBlock(Identifier, false, 10),
            12869 => new CreeperHeadBlock(Identifier, false, 11),
            12870 => new CreeperHeadBlock(Identifier, false, 12),
            12871 => new CreeperHeadBlock(Identifier, false, 13),
            12872 => new CreeperHeadBlock(Identifier, false, 14),
            12873 => new CreeperHeadBlock(Identifier, false, 15),
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
