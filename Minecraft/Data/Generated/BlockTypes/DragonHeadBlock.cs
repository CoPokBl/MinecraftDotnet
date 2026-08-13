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
    private static readonly BlockInfo Data = new("minecraft:skull", "block.minecraft.dragon_head", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:skull", "minecraft:dragon_head", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Destroy, 0, "stone", NoteBlockInstrument.Dragon, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S515, BlockShapes.S515, BlockShapes.S1, BlockShapes.S1, BlockShapes.S515, BlockShapes.S515);

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
                    0 => 11115,
                    1 => 11116,
                    2 => 11117,
                    3 => 11118,
                    4 => 11119,
                    5 => 11120,
                    6 => 11121,
                    7 => 11122,
                    8 => 11123,
                    9 => 11124,
                    10 => 11125,
                    11 => 11126,
                    12 => 11127,
                    13 => 11128,
                    14 => 11129,
                    15 => 11130,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => 11131,
                    1 => 11132,
                    2 => 11133,
                    3 => 11134,
                    4 => 11135,
                    5 => 11136,
                    6 => 11137,
                    7 => 11138,
                    8 => 11139,
                    9 => 11140,
                    10 => 11141,
                    11 => 11142,
                    12 => 11143,
                    13 => 11144,
                    14 => 11145,
                    15 => 11146,
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11115 => new DragonHeadBlock(Identifier, true, 0),
            11116 => new DragonHeadBlock(Identifier, true, 1),
            11117 => new DragonHeadBlock(Identifier, true, 2),
            11118 => new DragonHeadBlock(Identifier, true, 3),
            11119 => new DragonHeadBlock(Identifier, true, 4),
            11120 => new DragonHeadBlock(Identifier, true, 5),
            11121 => new DragonHeadBlock(Identifier, true, 6),
            11122 => new DragonHeadBlock(Identifier, true, 7),
            11123 => new DragonHeadBlock(Identifier, true, 8),
            11124 => new DragonHeadBlock(Identifier, true, 9),
            11125 => new DragonHeadBlock(Identifier, true, 10),
            11126 => new DragonHeadBlock(Identifier, true, 11),
            11127 => new DragonHeadBlock(Identifier, true, 12),
            11128 => new DragonHeadBlock(Identifier, true, 13),
            11129 => new DragonHeadBlock(Identifier, true, 14),
            11130 => new DragonHeadBlock(Identifier, true, 15),
            11131 => new DragonHeadBlock(Identifier, false, 0),
            11132 => new DragonHeadBlock(Identifier, false, 1),
            11133 => new DragonHeadBlock(Identifier, false, 2),
            11134 => new DragonHeadBlock(Identifier, false, 3),
            11135 => new DragonHeadBlock(Identifier, false, 4),
            11136 => new DragonHeadBlock(Identifier, false, 5),
            11137 => new DragonHeadBlock(Identifier, false, 6),
            11138 => new DragonHeadBlock(Identifier, false, 7),
            11139 => new DragonHeadBlock(Identifier, false, 8),
            11140 => new DragonHeadBlock(Identifier, false, 9),
            11141 => new DragonHeadBlock(Identifier, false, 10),
            11142 => new DragonHeadBlock(Identifier, false, 11),
            11143 => new DragonHeadBlock(Identifier, false, 12),
            11144 => new DragonHeadBlock(Identifier, false, 13),
            11145 => new DragonHeadBlock(Identifier, false, 14),
            11146 => new DragonHeadBlock(Identifier, false, 15),
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
