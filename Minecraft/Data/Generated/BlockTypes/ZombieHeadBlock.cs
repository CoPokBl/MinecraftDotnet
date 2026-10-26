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
public record ZombieHeadBlock(Identifier Identifier, bool Powered, int Rotation) : IBlock, IPowered, IRotated {
    private static readonly BlockInfo Data = new("block.minecraft.zombie_head", 1f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:zombie_head", BlockInfo.VanillaOnly, "minecraft:blocks/zombie_head");
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Popped, 0, "stone", NoteBlockInstrument.Zombie, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 12762,
                    1 => 12763,
                    2 => 12764,
                    3 => 12765,
                    4 => 12766,
                    5 => 12767,
                    6 => 12768,
                    7 => 12769,
                    8 => 12770,
                    9 => 12771,
                    10 => 12772,
                    11 => 12773,
                    12 => 12774,
                    13 => 12775,
                    14 => 12776,
                    15 => 12777,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 12778,
                    1 => 12779,
                    2 => 12780,
                    3 => 12781,
                    4 => 12782,
                    5 => 12783,
                    6 => 12784,
                    7 => 12785,
                    8 => 12786,
                    9 => 12787,
                    10 => 12788,
                    11 => 12789,
                    12 => 12790,
                    13 => 12791,
                    14 => 12792,
                    15 => 12793,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12762 => new ZombieHeadBlock(Identifier, true, 0),
            12763 => new ZombieHeadBlock(Identifier, true, 1),
            12764 => new ZombieHeadBlock(Identifier, true, 2),
            12765 => new ZombieHeadBlock(Identifier, true, 3),
            12766 => new ZombieHeadBlock(Identifier, true, 4),
            12767 => new ZombieHeadBlock(Identifier, true, 5),
            12768 => new ZombieHeadBlock(Identifier, true, 6),
            12769 => new ZombieHeadBlock(Identifier, true, 7),
            12770 => new ZombieHeadBlock(Identifier, true, 8),
            12771 => new ZombieHeadBlock(Identifier, true, 9),
            12772 => new ZombieHeadBlock(Identifier, true, 10),
            12773 => new ZombieHeadBlock(Identifier, true, 11),
            12774 => new ZombieHeadBlock(Identifier, true, 12),
            12775 => new ZombieHeadBlock(Identifier, true, 13),
            12776 => new ZombieHeadBlock(Identifier, true, 14),
            12777 => new ZombieHeadBlock(Identifier, true, 15),
            12778 => new ZombieHeadBlock(Identifier, false, 0),
            12779 => new ZombieHeadBlock(Identifier, false, 1),
            12780 => new ZombieHeadBlock(Identifier, false, 2),
            12781 => new ZombieHeadBlock(Identifier, false, 3),
            12782 => new ZombieHeadBlock(Identifier, false, 4),
            12783 => new ZombieHeadBlock(Identifier, false, 5),
            12784 => new ZombieHeadBlock(Identifier, false, 6),
            12785 => new ZombieHeadBlock(Identifier, false, 7),
            12786 => new ZombieHeadBlock(Identifier, false, 8),
            12787 => new ZombieHeadBlock(Identifier, false, 9),
            12788 => new ZombieHeadBlock(Identifier, false, 10),
            12789 => new ZombieHeadBlock(Identifier, false, 11),
            12790 => new ZombieHeadBlock(Identifier, false, 12),
            12791 => new ZombieHeadBlock(Identifier, false, 13),
            12792 => new ZombieHeadBlock(Identifier, false, 14),
            12793 => new ZombieHeadBlock(Identifier, false, 15),
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
