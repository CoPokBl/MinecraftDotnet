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
public record PistonBlock(Identifier Identifier, bool Extended, Cardinal Facing) : IBlock, IDirectional {
    private static readonly BlockInfo Data = new("block.minecraft.piston", 1.5f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:piston", BlockInfo.VanillaOnly, "minecraft:blocks/piston");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 0, PushReaction.Immoveable, 11, "stone", NoteBlockInstrument.Harp, false, true, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S803, BlockShapes.S803, BlockShapes.S1, BlockShapes.S803, BlockShapes.S803, BlockShapes.S803);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S804, CollisionShape = BlockShapes.S804, OcclusionShape = BlockShapes.S804, VisualShape = BlockShapes.S804, SupportShape = BlockShapes.S804 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S805, CollisionShape = BlockShapes.S805, OcclusionShape = BlockShapes.S805, VisualShape = BlockShapes.S805, SupportShape = BlockShapes.S805 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S806, CollisionShape = BlockShapes.S806, OcclusionShape = BlockShapes.S806, VisualShape = BlockShapes.S806, SupportShape = BlockShapes.S806 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S525, CollisionShape = BlockShapes.S525, OcclusionShape = BlockShapes.S525, VisualShape = BlockShapes.S525, SupportShape = BlockShapes.S525 };
    private static readonly BlockStateInfo I5 = I0 with { ValidSpawnFor = null, BlockShape = BlockShapes.S807, CollisionShape = BlockShapes.S807, OcclusionShape = BlockShapes.S807, VisualShape = BlockShapes.S807, SupportShape = BlockShapes.S807 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 15, Suffocating = true, ViewBlocking = true, ValidSpawnFor = null, BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S79, OcclusionShape = BlockShapes.S79, VisualShape = BlockShapes.S79, SupportShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I6, I6, I6, I6, I6
    ];

    public BlockStateInfo StateInfo => States[StateId - 2373];

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2373,
                    Cardinal.East => 2374,
                    Cardinal.South => 2375,
                    Cardinal.West => 2376,
                    Cardinal.Up => 2377,
                    Cardinal.Down => 2378,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2379,
                    Cardinal.East => 2380,
                    Cardinal.South => 2381,
                    Cardinal.West => 2382,
                    Cardinal.Up => 2383,
                    Cardinal.Down => 2384,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2373 => new PistonBlock(Identifier, true, Cardinal.North),
            2374 => new PistonBlock(Identifier, true, Cardinal.East),
            2375 => new PistonBlock(Identifier, true, Cardinal.South),
            2376 => new PistonBlock(Identifier, true, Cardinal.West),
            2377 => new PistonBlock(Identifier, true, Cardinal.Up),
            2378 => new PistonBlock(Identifier, true, Cardinal.Down),
            2379 => new PistonBlock(Identifier, false, Cardinal.North),
            2380 => new PistonBlock(Identifier, false, Cardinal.East),
            2381 => new PistonBlock(Identifier, false, Cardinal.South),
            2382 => new PistonBlock(Identifier, false, Cardinal.West),
            2383 => new PistonBlock(Identifier, false, Cardinal.Up),
            2384 => new PistonBlock(Identifier, false, Cardinal.Down),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Extended = properties.Contains("extended") ? properties["extended"].GetString() == "true" : Extended,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("extended", new StringTag(Extended.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName()))
        );
    }
    
}
