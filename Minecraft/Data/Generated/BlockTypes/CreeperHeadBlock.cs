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
    private static readonly BlockInfo Data = new("minecraft:skull", "block.minecraft.creeper_head", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:creeper_head", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Creeper, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 11075,
                    1 => 11076,
                    2 => 11077,
                    3 => 11078,
                    4 => 11079,
                    5 => 11080,
                    6 => 11081,
                    7 => 11082,
                    8 => 11083,
                    9 => 11084,
                    10 => 11085,
                    11 => 11086,
                    12 => 11087,
                    13 => 11088,
                    14 => 11089,
                    15 => 11090,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11091,
                    1 => 11092,
                    2 => 11093,
                    3 => 11094,
                    4 => 11095,
                    5 => 11096,
                    6 => 11097,
                    7 => 11098,
                    8 => 11099,
                    9 => 11100,
                    10 => 11101,
                    11 => 11102,
                    12 => 11103,
                    13 => 11104,
                    14 => 11105,
                    15 => 11106,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11075 => new CreeperHeadBlock(Identifier, true, 0),
            11076 => new CreeperHeadBlock(Identifier, true, 1),
            11077 => new CreeperHeadBlock(Identifier, true, 2),
            11078 => new CreeperHeadBlock(Identifier, true, 3),
            11079 => new CreeperHeadBlock(Identifier, true, 4),
            11080 => new CreeperHeadBlock(Identifier, true, 5),
            11081 => new CreeperHeadBlock(Identifier, true, 6),
            11082 => new CreeperHeadBlock(Identifier, true, 7),
            11083 => new CreeperHeadBlock(Identifier, true, 8),
            11084 => new CreeperHeadBlock(Identifier, true, 9),
            11085 => new CreeperHeadBlock(Identifier, true, 10),
            11086 => new CreeperHeadBlock(Identifier, true, 11),
            11087 => new CreeperHeadBlock(Identifier, true, 12),
            11088 => new CreeperHeadBlock(Identifier, true, 13),
            11089 => new CreeperHeadBlock(Identifier, true, 14),
            11090 => new CreeperHeadBlock(Identifier, true, 15),
            11091 => new CreeperHeadBlock(Identifier, false, 0),
            11092 => new CreeperHeadBlock(Identifier, false, 1),
            11093 => new CreeperHeadBlock(Identifier, false, 2),
            11094 => new CreeperHeadBlock(Identifier, false, 3),
            11095 => new CreeperHeadBlock(Identifier, false, 4),
            11096 => new CreeperHeadBlock(Identifier, false, 5),
            11097 => new CreeperHeadBlock(Identifier, false, 6),
            11098 => new CreeperHeadBlock(Identifier, false, 7),
            11099 => new CreeperHeadBlock(Identifier, false, 8),
            11100 => new CreeperHeadBlock(Identifier, false, 9),
            11101 => new CreeperHeadBlock(Identifier, false, 10),
            11102 => new CreeperHeadBlock(Identifier, false, 11),
            11103 => new CreeperHeadBlock(Identifier, false, 12),
            11104 => new CreeperHeadBlock(Identifier, false, 13),
            11105 => new CreeperHeadBlock(Identifier, false, 14),
            11106 => new CreeperHeadBlock(Identifier, false, 15),
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
