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
    private static readonly BlockInfo Data = new("minecraft:decorated_pot", "block.minecraft.decorated_pot", 0f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, "minecraft:decorated_pot", "minecraft:decorated_pot", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0f, 0, 1, PushReaction.Destroy, 50, "decorated_pot_cracked", NoteBlockInstrument.Harp, false, false, false, true, false, false, false, false, true, false, false, false, false, false, true, false, false, false, [], "minecraft:water", BlockShapes.S401, BlockShapes.S401, BlockShapes.S1, BlockShapes.S1, BlockShapes.S401, BlockShapes.S401);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { SoundType = "decorated_pot" };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, SoundType = "decorated_pot", Fluid = null };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3
    ];

    public BlockStateInfo StateInfo => States[StateId - 32086];

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

    public IBlock WithFacing(Direction facing) => this with { Facing = facing };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Cracked switch {
                true => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32086,
                        false => 32087,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32088,
                        false => 32089,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32090,
                        false => 32091,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32092,
                        false => 32093,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                false => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 32094,
                        false => 32095,
                    },
                    Direction.South => Waterlogged switch {
                        true => 32096,
                        false => 32097,
                    },
                    Direction.West => Waterlogged switch {
                        true => 32098,
                        false => 32099,
                    },
                    Direction.East => Waterlogged switch {
                        true => 32100,
                        false => 32101,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            32086 => new DecoratedPotBlock(Identifier, true, Direction.North, true),
            32087 => new DecoratedPotBlock(Identifier, true, Direction.North, false),
            32088 => new DecoratedPotBlock(Identifier, true, Direction.South, true),
            32089 => new DecoratedPotBlock(Identifier, true, Direction.South, false),
            32090 => new DecoratedPotBlock(Identifier, true, Direction.West, true),
            32091 => new DecoratedPotBlock(Identifier, true, Direction.West, false),
            32092 => new DecoratedPotBlock(Identifier, true, Direction.East, true),
            32093 => new DecoratedPotBlock(Identifier, true, Direction.East, false),
            32094 => new DecoratedPotBlock(Identifier, false, Direction.North, true),
            32095 => new DecoratedPotBlock(Identifier, false, Direction.North, false),
            32096 => new DecoratedPotBlock(Identifier, false, Direction.South, true),
            32097 => new DecoratedPotBlock(Identifier, false, Direction.South, false),
            32098 => new DecoratedPotBlock(Identifier, false, Direction.West, true),
            32099 => new DecoratedPotBlock(Identifier, false, Direction.West, false),
            32100 => new DecoratedPotBlock(Identifier, false, Direction.East, true),
            32101 => new DecoratedPotBlock(Identifier, false, Direction.East, false),
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
