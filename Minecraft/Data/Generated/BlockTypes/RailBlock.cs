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
    private static readonly BlockInfo Data = new("minecraft:rail", "block.minecraft.rail", 0.7f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:rail", BlockInfo.VanillaOnly, "minecraft:blocks/rail");
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.Normal, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, true, [], "minecraft:water", BlockShapes.S124, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S89 };
    private static readonly BlockStateInfo[] States = [
        I0, I1, I0, I1, I2, I3, I2, I3, I2, I3, I2, I3, I0, I1, I0, I1, I0, I1, I0, I1
    ];

    public BlockStateInfo StateInfo => States[StateId - 5727];

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

    public IBlock WithShape(RailShape shape) => this with { Shape = shape };

    public IBlock WithWaterlogged(bool waterlogged) => this with { Waterlogged = waterlogged };


    public uint StateId {
        get {
            return Shape switch {
                RailShape.NorthSouth => Waterlogged switch {
                    true => 5727,
                    false => 5728,
                },
                RailShape.EastWest => Waterlogged switch {
                    true => 5729,
                    false => 5730,
                },
                RailShape.AscendingEast => Waterlogged switch {
                    true => 5731,
                    false => 5732,
                },
                RailShape.AscendingWest => Waterlogged switch {
                    true => 5733,
                    false => 5734,
                },
                RailShape.AscendingNorth => Waterlogged switch {
                    true => 5735,
                    false => 5736,
                },
                RailShape.AscendingSouth => Waterlogged switch {
                    true => 5737,
                    false => 5738,
                },
                RailShape.SouthEast => Waterlogged switch {
                    true => 5739,
                    false => 5740,
                },
                RailShape.SouthWest => Waterlogged switch {
                    true => 5741,
                    false => 5742,
                },
                RailShape.NorthWest => Waterlogged switch {
                    true => 5743,
                    false => 5744,
                },
                RailShape.NorthEast => Waterlogged switch {
                    true => 5745,
                    false => 5746,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5727 => new RailBlock(Identifier, RailShape.NorthSouth, true),
            5728 => new RailBlock(Identifier, RailShape.NorthSouth, false),
            5729 => new RailBlock(Identifier, RailShape.EastWest, true),
            5730 => new RailBlock(Identifier, RailShape.EastWest, false),
            5731 => new RailBlock(Identifier, RailShape.AscendingEast, true),
            5732 => new RailBlock(Identifier, RailShape.AscendingEast, false),
            5733 => new RailBlock(Identifier, RailShape.AscendingWest, true),
            5734 => new RailBlock(Identifier, RailShape.AscendingWest, false),
            5735 => new RailBlock(Identifier, RailShape.AscendingNorth, true),
            5736 => new RailBlock(Identifier, RailShape.AscendingNorth, false),
            5737 => new RailBlock(Identifier, RailShape.AscendingSouth, true),
            5738 => new RailBlock(Identifier, RailShape.AscendingSouth, false),
            5739 => new RailBlock(Identifier, RailShape.SouthEast, true),
            5740 => new RailBlock(Identifier, RailShape.SouthEast, false),
            5741 => new RailBlock(Identifier, RailShape.SouthWest, true),
            5742 => new RailBlock(Identifier, RailShape.SouthWest, false),
            5743 => new RailBlock(Identifier, RailShape.NorthWest, true),
            5744 => new RailBlock(Identifier, RailShape.NorthWest, false),
            5745 => new RailBlock(Identifier, RailShape.NorthEast, true),
            5746 => new RailBlock(Identifier, RailShape.NorthEast, false),
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
