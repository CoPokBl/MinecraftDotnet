using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:banner", "block.minecraft.yellow_banner", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:banner", "minecraft:yellow_banner", BlockInfo.VanillaOnly);
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
                0 => 12991,
                1 => 12992,
                2 => 12993,
                3 => 12994,
                4 => 12995,
                5 => 12996,
                6 => 12997,
                7 => 12998,
                8 => 12999,
                9 => 13000,
                10 => 13001,
                11 => 13002,
                12 => 13003,
                13 => 13004,
                14 => 13005,
                15 => 13006,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12991 => new YellowBannerBlock(Identifier, 0),
            12992 => new YellowBannerBlock(Identifier, 1),
            12993 => new YellowBannerBlock(Identifier, 2),
            12994 => new YellowBannerBlock(Identifier, 3),
            12995 => new YellowBannerBlock(Identifier, 4),
            12996 => new YellowBannerBlock(Identifier, 5),
            12997 => new YellowBannerBlock(Identifier, 6),
            12998 => new YellowBannerBlock(Identifier, 7),
            12999 => new YellowBannerBlock(Identifier, 8),
            13000 => new YellowBannerBlock(Identifier, 9),
            13001 => new YellowBannerBlock(Identifier, 10),
            13002 => new YellowBannerBlock(Identifier, 11),
            13003 => new YellowBannerBlock(Identifier, 12),
            13004 => new YellowBannerBlock(Identifier, 13),
            13005 => new YellowBannerBlock(Identifier, 14),
            13006 => new YellowBannerBlock(Identifier, 15),
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
