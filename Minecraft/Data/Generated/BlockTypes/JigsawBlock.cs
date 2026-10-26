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
public record JigsawBlock(Identifier Identifier, Orientation Orientation) : IBlock, IOriented {
    private static readonly BlockInfo Data = new("block.minecraft.jigsaw", 3600000f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:jigsaw", "minecraft:jigsaw", BlockInfo.VanillaOnly, null);
    private static readonly BlockStateInfo I0 = new(-1f, 0, 15, PushReaction.PushPull, 22, "stone", NoteBlockInstrument.Harp, false, true, true, false, false, false, false, true, true, false, false, true, true, false, true, false, false, false, null, null, BlockShapes.S79, BlockShapes.S79, BlockShapes.S1, BlockShapes.S79, BlockShapes.S79, BlockShapes.S79);

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

    public IBlock WithOrientation(Orientation orientation) => this with { Orientation = orientation };


    public uint StateId {
        get {
            return Orientation switch {
                Orientation.DownEast => 25083,
                Orientation.DownNorth => 25084,
                Orientation.DownSouth => 25085,
                Orientation.DownWest => 25086,
                Orientation.UpEast => 25087,
                Orientation.UpNorth => 25088,
                Orientation.UpSouth => 25089,
                Orientation.UpWest => 25090,
                Orientation.WestUp => 25091,
                Orientation.EastUp => 25092,
                Orientation.NorthUp => 25093,
                Orientation.SouthUp => 25094,
                _ => throw new ArgumentOutOfRangeException(nameof(Orientation), Orientation, "Unknown value for property orientation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25083 => new JigsawBlock(Identifier, Orientation.DownEast),
            25084 => new JigsawBlock(Identifier, Orientation.DownNorth),
            25085 => new JigsawBlock(Identifier, Orientation.DownSouth),
            25086 => new JigsawBlock(Identifier, Orientation.DownWest),
            25087 => new JigsawBlock(Identifier, Orientation.UpEast),
            25088 => new JigsawBlock(Identifier, Orientation.UpNorth),
            25089 => new JigsawBlock(Identifier, Orientation.UpSouth),
            25090 => new JigsawBlock(Identifier, Orientation.UpWest),
            25091 => new JigsawBlock(Identifier, Orientation.WestUp),
            25092 => new JigsawBlock(Identifier, Orientation.EastUp),
            25093 => new JigsawBlock(Identifier, Orientation.NorthUp),
            25094 => new JigsawBlock(Identifier, Orientation.SouthUp),
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
