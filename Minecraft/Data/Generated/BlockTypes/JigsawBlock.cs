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
public record JigsawBlock(Identifier Identifier, Orientation Orientation) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:jigsaw", "block.minecraft.jigsaw", 3600000f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:jigsaw", "minecraft:jigsaw", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 15, PushReaction.Normal, 22, "stone", NoteBlockInstrument.Harp, false, true, true, true, false, false, false, false, true, true, false, false, true, true, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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


    public uint StateId {
        get {
            return Orientation switch {
                Orientation.DownEast => 21726,
                Orientation.DownNorth => 21727,
                Orientation.DownSouth => 21728,
                Orientation.DownWest => 21729,
                Orientation.UpEast => 21730,
                Orientation.UpNorth => 21731,
                Orientation.UpSouth => 21732,
                Orientation.UpWest => 21733,
                Orientation.WestUp => 21734,
                Orientation.EastUp => 21735,
                Orientation.NorthUp => 21736,
                Orientation.SouthUp => 21737,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21726 => new JigsawBlock(Identifier, Orientation.DownEast),
            21727 => new JigsawBlock(Identifier, Orientation.DownNorth),
            21728 => new JigsawBlock(Identifier, Orientation.DownSouth),
            21729 => new JigsawBlock(Identifier, Orientation.DownWest),
            21730 => new JigsawBlock(Identifier, Orientation.UpEast),
            21731 => new JigsawBlock(Identifier, Orientation.UpNorth),
            21732 => new JigsawBlock(Identifier, Orientation.UpSouth),
            21733 => new JigsawBlock(Identifier, Orientation.UpWest),
            21734 => new JigsawBlock(Identifier, Orientation.WestUp),
            21735 => new JigsawBlock(Identifier, Orientation.EastUp),
            21736 => new JigsawBlock(Identifier, Orientation.NorthUp),
            21737 => new JigsawBlock(Identifier, Orientation.SouthUp),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Orientation = properties.Contains("orientation") ? OrientationExtensions.FromString(properties["orientation"].GetString()) : Orientation,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("orientation", new StringTag(Orientation.ToName()))
        );
    }
    
}
