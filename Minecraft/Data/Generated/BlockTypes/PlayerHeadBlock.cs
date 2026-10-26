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
public record PlayerHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.player_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:player_head", BlockInfo.VanillaOnly, "minecraft:blocks/player_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.CustomHead, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 12802,
                    1 => 12803,
                    2 => 12804,
                    3 => 12805,
                    4 => 12806,
                    5 => 12807,
                    6 => 12808,
                    7 => 12809,
                    8 => 12810,
                    9 => 12811,
                    10 => 12812,
                    11 => 12813,
                    12 => 12814,
                    13 => 12815,
                    14 => 12816,
                    15 => 12817,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12818,
                    1 => 12819,
                    2 => 12820,
                    3 => 12821,
                    4 => 12822,
                    5 => 12823,
                    6 => 12824,
                    7 => 12825,
                    8 => 12826,
                    9 => 12827,
                    10 => 12828,
                    11 => 12829,
                    12 => 12830,
                    13 => 12831,
                    14 => 12832,
                    15 => 12833,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12802 => new PlayerHeadBlock(Identifier, true, 0),
            12803 => new PlayerHeadBlock(Identifier, true, 1),
            12804 => new PlayerHeadBlock(Identifier, true, 2),
            12805 => new PlayerHeadBlock(Identifier, true, 3),
            12806 => new PlayerHeadBlock(Identifier, true, 4),
            12807 => new PlayerHeadBlock(Identifier, true, 5),
            12808 => new PlayerHeadBlock(Identifier, true, 6),
            12809 => new PlayerHeadBlock(Identifier, true, 7),
            12810 => new PlayerHeadBlock(Identifier, true, 8),
            12811 => new PlayerHeadBlock(Identifier, true, 9),
            12812 => new PlayerHeadBlock(Identifier, true, 10),
            12813 => new PlayerHeadBlock(Identifier, true, 11),
            12814 => new PlayerHeadBlock(Identifier, true, 12),
            12815 => new PlayerHeadBlock(Identifier, true, 13),
            12816 => new PlayerHeadBlock(Identifier, true, 14),
            12817 => new PlayerHeadBlock(Identifier, true, 15),
            12818 => new PlayerHeadBlock(Identifier, false, 0),
            12819 => new PlayerHeadBlock(Identifier, false, 1),
            12820 => new PlayerHeadBlock(Identifier, false, 2),
            12821 => new PlayerHeadBlock(Identifier, false, 3),
            12822 => new PlayerHeadBlock(Identifier, false, 4),
            12823 => new PlayerHeadBlock(Identifier, false, 5),
            12824 => new PlayerHeadBlock(Identifier, false, 6),
            12825 => new PlayerHeadBlock(Identifier, false, 7),
            12826 => new PlayerHeadBlock(Identifier, false, 8),
            12827 => new PlayerHeadBlock(Identifier, false, 9),
            12828 => new PlayerHeadBlock(Identifier, false, 10),
            12829 => new PlayerHeadBlock(Identifier, false, 11),
            12830 => new PlayerHeadBlock(Identifier, false, 12),
            12831 => new PlayerHeadBlock(Identifier, false, 13),
            12832 => new PlayerHeadBlock(Identifier, false, 14),
            12833 => new PlayerHeadBlock(Identifier, false, 15),
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
