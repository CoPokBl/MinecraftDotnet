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
public record DecoratedPotBlock(Identifier Identifier, bool Cracked, Direction Facing, bool Waterlogged) : IBlock, IHorizontalFacing, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.decorated_pot", 0f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:decorated_pot", "minecraft:decorated_pot", BlockInfo.VanillaOnly, "minecraft:blocks/decorated_pot");
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Popped, 50, "decorated_pot_cracked", NoteBlockInstrument.Harp, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S401, BlockShapes.S401, BlockShapes.S1, BlockShapes.S1, BlockShapes.S401, BlockShapes.S401);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { SoundType = "decorated_pot" };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, SoundType = "decorated_pot", Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 35443];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Cracked switch {
                true => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 35443,
                        false => 35444,
                    },
                    Direction.South => Waterlogged switch {
                        true => 35445,
                        false => 35446,
                    },
                    Direction.West => Waterlogged switch {
                        true => 35447,
                        false => 35448,
                    },
                    Direction.East => Waterlogged switch {
                        true => 35449,
                        false => 35450,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 35451,
                        false => 35452,
                    },
                    Direction.South => Waterlogged switch {
                        true => 35453,
                        false => 35454,
                    },
                    Direction.West => Waterlogged switch {
                        true => 35455,
                        false => 35456,
                    },
                    Direction.East => Waterlogged switch {
                        true => 35457,
                        false => 35458,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            35443 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            35444 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            35445 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            35446 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            35447 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            35448 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            35449 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            35450 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            35451 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            35452 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            35453 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            35454 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            35455 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            35456 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            35457 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            35458 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Cracked = properties.Contains("cracked") ? properties["cracked"].GetString() == "true" : Cracked,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("cracked", new StringTag(Cracked.ToString().ToLower())),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
