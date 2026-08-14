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
    private static readonly BlockInfo Data = new("minecraft:piston_base", "block.minecraft.piston", 1.5f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:piston", BlockInfo.VanillaOnly, "minecraft:blocks/piston");
    private static readonly BlockStateInfo I0 = new(1.5f, 0, 0, PushReaction.Block, 11, "stone", NoteBlockInstrument.Harp, false, true, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], null, BlockShapes.S802, BlockShapes.S802, BlockShapes.S1, BlockShapes.S802, BlockShapes.S802, BlockShapes.S802);
    private static readonly BlockStateInfo I1 = I0 with { BlockShape = BlockShapes.S803, CollisionShape = BlockShapes.S803, OcclusionShape = BlockShapes.S803, VisualShape = BlockShapes.S803, SupportShape = BlockShapes.S803 };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S804, CollisionShape = BlockShapes.S804, OcclusionShape = BlockShapes.S804, VisualShape = BlockShapes.S804, SupportShape = BlockShapes.S804 };
    private static readonly BlockStateInfo I3 = I0 with { BlockShape = BlockShapes.S805, CollisionShape = BlockShapes.S805, OcclusionShape = BlockShapes.S805, VisualShape = BlockShapes.S805, SupportShape = BlockShapes.S805 };
    private static readonly BlockStateInfo I4 = I0 with { BlockShape = BlockShapes.S524, CollisionShape = BlockShapes.S524, OcclusionShape = BlockShapes.S524, VisualShape = BlockShapes.S524, SupportShape = BlockShapes.S524 };
    private static readonly BlockStateInfo I5 = I0 with { ValidSpawnFor = null, BlockShape = BlockShapes.S806, CollisionShape = BlockShapes.S806, OcclusionShape = BlockShapes.S806, VisualShape = BlockShapes.S806, SupportShape = BlockShapes.S806 };
    private static readonly BlockStateInfo I6 = I0 with { LightDampening = 15, Suffocating = true, ViewBlocking = true, ValidSpawnFor = null, BlockShape = BlockShapes.S79, CollisionShape = BlockShapes.S79, OcclusionShape = BlockShapes.S79, VisualShape = BlockShapes.S79, SupportShape = BlockShapes.S79 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I2, I3, I4, I5, I6, I6, I6, I6, I6, I6
    ];

    public BlockStateInfo StateInfo => States[StateId - 2257];

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
    public Identifier? LootTable => Data.LootTable;
    public (int Min, int Max)? Experience => Data.Experience;

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

    public IBlock WithFacing(Cardinal facing) => this with { Facing = facing };


    public uint StateId {
        get {
            return Extended switch {
                true => Facing switch {
                    Cardinal.North => 2257,
                    Cardinal.East => 2258,
                    Cardinal.South => 2259,
                    Cardinal.West => 2260,
                    Cardinal.Up => 2261,
                    Cardinal.Down => 2262,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Cardinal.North => 2263,
                    Cardinal.East => 2264,
                    Cardinal.South => 2265,
                    Cardinal.West => 2266,
                    Cardinal.Up => 2267,
                    Cardinal.Down => 2268,
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2257 => new PistonBlock(Identifier, true, Cardinal.North),
            2258 => new PistonBlock(Identifier, true, Cardinal.East),
            2259 => new PistonBlock(Identifier, true, Cardinal.South),
            2260 => new PistonBlock(Identifier, true, Cardinal.West),
            2261 => new PistonBlock(Identifier, true, Cardinal.Up),
            2262 => new PistonBlock(Identifier, true, Cardinal.Down),
            2263 => new PistonBlock(Identifier, false, Cardinal.North),
            2264 => new PistonBlock(Identifier, false, Cardinal.East),
            2265 => new PistonBlock(Identifier, false, Cardinal.South),
            2266 => new PistonBlock(Identifier, false, Cardinal.West),
            2267 => new PistonBlock(Identifier, false, Cardinal.Up),
            2268 => new PistonBlock(Identifier, false, Cardinal.Down),
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
