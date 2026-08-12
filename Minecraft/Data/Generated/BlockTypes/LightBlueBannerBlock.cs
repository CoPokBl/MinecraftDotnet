using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueBannerBlock(Identifier Identifier, int Rotation) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:banner", "block.minecraft.light_blue_banner", 1f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:banner", "minecraft:light_blue_banner", BlockInfo.VanillaOnly);
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
                0 => 12975,
                1 => 12976,
                2 => 12977,
                3 => 12978,
                4 => 12979,
                5 => 12980,
                6 => 12981,
                7 => 12982,
                8 => 12983,
                9 => 12984,
                10 => 12985,
                11 => 12986,
                12 => 12987,
                13 => 12988,
                14 => 12989,
                15 => 12990,
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12975 => new LightBlueBannerBlock(Identifier, 0),
            12976 => new LightBlueBannerBlock(Identifier, 1),
            12977 => new LightBlueBannerBlock(Identifier, 2),
            12978 => new LightBlueBannerBlock(Identifier, 3),
            12979 => new LightBlueBannerBlock(Identifier, 4),
            12980 => new LightBlueBannerBlock(Identifier, 5),
            12981 => new LightBlueBannerBlock(Identifier, 6),
            12982 => new LightBlueBannerBlock(Identifier, 7),
            12983 => new LightBlueBannerBlock(Identifier, 8),
            12984 => new LightBlueBannerBlock(Identifier, 9),
            12985 => new LightBlueBannerBlock(Identifier, 10),
            12986 => new LightBlueBannerBlock(Identifier, 11),
            12987 => new LightBlueBannerBlock(Identifier, 12),
            12988 => new LightBlueBannerBlock(Identifier, 13),
            12989 => new LightBlueBannerBlock(Identifier, 14),
            12990 => new LightBlueBannerBlock(Identifier, 15),
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
