using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:banner", "block.minecraft.cyan_banner", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:banner", "minecraft:cyan_banner", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(1f, 0, 0, PushReaction.Normal, 13, "wood", NoteBlockInstrument.Bass, true, false, false, true, false, false, false, false, true, false, false, false, false, false, true, [], null, BlockShapes.S85, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);

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
    public NoteBlockInstrument Instrument => StateInfo.Instrument;
    public Identifier? Fluid => StateInfo.Fluid;


    public uint StateId {
        get {
            return Rotation switch {
                0 => 13071,
                1 => 13072,
                2 => 13073,
                3 => 13074,
                4 => 13075,
                5 => 13076,
                6 => 13077,
                7 => 13078,
                8 => 13079,
                9 => 13080,
                10 => 13081,
                11 => 13082,
                12 => 13083,
                13 => 13084,
                14 => 13085,
                15 => 13086,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            13071 => new CyanBannerBlock(Identifier, 0),
            13072 => new CyanBannerBlock(Identifier, 1),
            13073 => new CyanBannerBlock(Identifier, 2),
            13074 => new CyanBannerBlock(Identifier, 3),
            13075 => new CyanBannerBlock(Identifier, 4),
            13076 => new CyanBannerBlock(Identifier, 5),
            13077 => new CyanBannerBlock(Identifier, 6),
            13078 => new CyanBannerBlock(Identifier, 7),
            13079 => new CyanBannerBlock(Identifier, 8),
            13080 => new CyanBannerBlock(Identifier, 9),
            13081 => new CyanBannerBlock(Identifier, 10),
            13082 => new CyanBannerBlock(Identifier, 11),
            13083 => new CyanBannerBlock(Identifier, 12),
            13084 => new CyanBannerBlock(Identifier, 13),
            13085 => new CyanBannerBlock(Identifier, 14),
            13086 => new CyanBannerBlock(Identifier, 15),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString()))
        );
    }
    
}
