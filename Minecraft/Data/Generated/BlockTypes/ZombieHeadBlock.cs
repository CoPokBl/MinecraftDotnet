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
    private static readonly BlockInfo Data = new("minecraft:skull", "block.minecraft.zombie_head", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:zombie_head", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Zombie, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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

    public IBlock WithPowered(bool powered) => this with { Powered = powered };

    public IBlock WithRotation(int rotation) => this with { Rotation = rotation };


    public uint StateId {
        get {
            return Powered switch {
                true => Rotation switch {
                    0 => 10995,
                    1 => 10996,
                    2 => 10997,
                    3 => 10998,
                    4 => 10999,
                    5 => 11000,
                    6 => 11001,
                    7 => 11002,
                    8 => 11003,
                    9 => 11004,
                    10 => 11005,
                    11 => 11006,
                    12 => 11007,
                    13 => 11008,
                    14 => 11009,
                    15 => 11010,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11011,
                    1 => 11012,
                    2 => 11013,
                    3 => 11014,
                    4 => 11015,
                    5 => 11016,
                    6 => 11017,
                    7 => 11018,
                    8 => 11019,
                    9 => 11020,
                    10 => 11021,
                    11 => 11022,
                    12 => 11023,
                    13 => 11024,
                    14 => 11025,
                    15 => 11026,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10995 => new ZombieHeadBlock(Identifier, true, 0),
            10996 => new ZombieHeadBlock(Identifier, true, 1),
            10997 => new ZombieHeadBlock(Identifier, true, 2),
            10998 => new ZombieHeadBlock(Identifier, true, 3),
            10999 => new ZombieHeadBlock(Identifier, true, 4),
            11000 => new ZombieHeadBlock(Identifier, true, 5),
            11001 => new ZombieHeadBlock(Identifier, true, 6),
            11002 => new ZombieHeadBlock(Identifier, true, 7),
            11003 => new ZombieHeadBlock(Identifier, true, 8),
            11004 => new ZombieHeadBlock(Identifier, true, 9),
            11005 => new ZombieHeadBlock(Identifier, true, 10),
            11006 => new ZombieHeadBlock(Identifier, true, 11),
            11007 => new ZombieHeadBlock(Identifier, true, 12),
            11008 => new ZombieHeadBlock(Identifier, true, 13),
            11009 => new ZombieHeadBlock(Identifier, true, 14),
            11010 => new ZombieHeadBlock(Identifier, true, 15),
            11011 => new ZombieHeadBlock(Identifier, false, 0),
            11012 => new ZombieHeadBlock(Identifier, false, 1),
            11013 => new ZombieHeadBlock(Identifier, false, 2),
            11014 => new ZombieHeadBlock(Identifier, false, 3),
            11015 => new ZombieHeadBlock(Identifier, false, 4),
            11016 => new ZombieHeadBlock(Identifier, false, 5),
            11017 => new ZombieHeadBlock(Identifier, false, 6),
            11018 => new ZombieHeadBlock(Identifier, false, 7),
            11019 => new ZombieHeadBlock(Identifier, false, 8),
            11020 => new ZombieHeadBlock(Identifier, false, 9),
            11021 => new ZombieHeadBlock(Identifier, false, 10),
            11022 => new ZombieHeadBlock(Identifier, false, 11),
            11023 => new ZombieHeadBlock(Identifier, false, 12),
            11024 => new ZombieHeadBlock(Identifier, false, 13),
            11025 => new ZombieHeadBlock(Identifier, false, 14),
            11026 => new ZombieHeadBlock(Identifier, false, 15),
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
