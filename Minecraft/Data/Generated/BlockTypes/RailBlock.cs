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
public record RailBlock(Identifier Identifier, RailShape Shape, bool Waterlogged) : IBlock, IRailShaped, IWaterlogged {
    private static readonly BlockInfo Data = new("block.minecraft.rail", 0.7f, 0.6f, 1f, 1f, 0f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:rail", BlockInfo.VanillaOnly, "minecraft:blocks/rail");
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.PushPull, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, PathfindableWater = false, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 7315];

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

    public IBlock WithShape(RailShape shape) => this with { Shape = shape };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Shape switch {
                RailShape.NorthSouth => Waterlogged switch {
                    true => 7315,
                    false => 7316,
                },
                RailShape.EastWest => Waterlogged switch {
                    true => 7317,
                    false => 7318,
                },
                RailShape.AscendingEast => Waterlogged switch {
                    true => 7319,
                    false => 7320,
                },
                RailShape.AscendingWest => Waterlogged switch {
                    true => 7321,
                    false => 7322,
                },
                RailShape.AscendingNorth => Waterlogged switch {
                    true => 7323,
                    false => 7324,
                },
                RailShape.AscendingSouth => Waterlogged switch {
                    true => 7325,
                    false => 7326,
                },
                RailShape.SouthEast => Waterlogged switch {
                    true => 7327,
                    false => 7328,
                },
                RailShape.SouthWest => Waterlogged switch {
                    true => 7329,
                    false => 7330,
                },
                RailShape.NorthWest => Waterlogged switch {
                    true => 7331,
                    false => 7332,
                },
                RailShape.NorthEast => Waterlogged switch {
                    true => 7333,
                    false => 7334,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            7315 => new RailBlock(Identifier, RailShape.NorthSouth, true),
            7316 => new RailBlock(Identifier, RailShape.NorthSouth, false),
            7317 => new RailBlock(Identifier, RailShape.EastWest, true),
            7318 => new RailBlock(Identifier, RailShape.EastWest, false),
            7319 => new RailBlock(Identifier, RailShape.AscendingEast, true),
            7320 => new RailBlock(Identifier, RailShape.AscendingEast, false),
            7321 => new RailBlock(Identifier, RailShape.AscendingWest, true),
            7322 => new RailBlock(Identifier, RailShape.AscendingWest, false),
            7323 => new RailBlock(Identifier, RailShape.AscendingNorth, true),
            7324 => new RailBlock(Identifier, RailShape.AscendingNorth, false),
            7325 => new RailBlock(Identifier, RailShape.AscendingSouth, true),
            7326 => new RailBlock(Identifier, RailShape.AscendingSouth, false),
            7327 => new RailBlock(Identifier, RailShape.SouthEast, true),
            7328 => new RailBlock(Identifier, RailShape.SouthEast, false),
            7329 => new RailBlock(Identifier, RailShape.SouthWest, true),
            7330 => new RailBlock(Identifier, RailShape.SouthWest, false),
            7331 => new RailBlock(Identifier, RailShape.NorthWest, true),
            7332 => new RailBlock(Identifier, RailShape.NorthWest, false),
            7333 => new RailBlock(Identifier, RailShape.NorthEast, true),
            7334 => new RailBlock(Identifier, RailShape.NorthEast, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Shape = properties.Contains("shape") ? RailShapeExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
