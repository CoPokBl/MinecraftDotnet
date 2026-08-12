using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RailBlock(Identifier Identifier, RailBlock.Shape ShapeValue, bool Waterlogged) : IBlock {
    private static readonly BlockInfo Data = new("minecraft:rail", "block.minecraft.rail", 0.7f, 0.6f, 1f, 1f, 0f, false, false, BlockOffsetType.None, 0f, 0f, null, "minecraft:rail", BlockInfo.VanillaOnly);
    private static readonly BlockStateInfo I0 = new(0.7f, 0, 1, PushReaction.Normal, 0, "metal", NoteBlockInstrument.Harp, true, false, false, false, false, false, false, false, false, false, false, false, false, false, true, [], "minecraft:water", BlockShapes.S122, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1, BlockShapes.S1);
    private static readonly BlockStateInfo I1 = I0 with { LightDampening = 0, Fluid = null };
    private static readonly BlockStateInfo I2 = I0 with { BlockShape = BlockShapes.S87 };
    private static readonly BlockStateInfo I3 = I0 with { LightDampening = 0, Fluid = null, BlockShape = BlockShapes.S87 };
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
            return ShapeValue switch {
                Shape.NorthSouth => Waterlogged switch {
                    true => 5727,
                    false => 5728,
                },
                Shape.EastWest => Waterlogged switch {
                    true => 5729,
                    false => 5730,
                },
                Shape.AscendingEast => Waterlogged switch {
                    true => 5731,
                    false => 5732,
                },
                Shape.AscendingWest => Waterlogged switch {
                    true => 5733,
                    false => 5734,
                },
                Shape.AscendingNorth => Waterlogged switch {
                    true => 5735,
                    false => 5736,
                },
                Shape.AscendingSouth => Waterlogged switch {
                    true => 5737,
                    false => 5738,
                },
                Shape.SouthEast => Waterlogged switch {
                    true => 5739,
                    false => 5740,
                },
                Shape.SouthWest => Waterlogged switch {
                    true => 5741,
                    false => 5742,
                },
                Shape.NorthWest => Waterlogged switch {
                    true => 5743,
                    false => 5744,
                },
                Shape.NorthEast => Waterlogged switch {
                    true => 5745,
                    false => 5746,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ShapeValue), ShapeValue, "Unknown value for property shape.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5727 => new RailBlock(Identifier, Shape.NorthSouth, true),
            5728 => new RailBlock(Identifier, Shape.NorthSouth, false),
            5729 => new RailBlock(Identifier, Shape.EastWest, true),
            5730 => new RailBlock(Identifier, Shape.EastWest, false),
            5731 => new RailBlock(Identifier, Shape.AscendingEast, true),
            5732 => new RailBlock(Identifier, Shape.AscendingEast, false),
            5733 => new RailBlock(Identifier, Shape.AscendingWest, true),
            5734 => new RailBlock(Identifier, Shape.AscendingWest, false),
            5735 => new RailBlock(Identifier, Shape.AscendingNorth, true),
            5736 => new RailBlock(Identifier, Shape.AscendingNorth, false),
            5737 => new RailBlock(Identifier, Shape.AscendingSouth, true),
            5738 => new RailBlock(Identifier, Shape.AscendingSouth, false),
            5739 => new RailBlock(Identifier, Shape.SouthEast, true),
            5740 => new RailBlock(Identifier, Shape.SouthEast, false),
            5741 => new RailBlock(Identifier, Shape.SouthWest, true),
            5742 => new RailBlock(Identifier, Shape.SouthWest, false),
            5743 => new RailBlock(Identifier, Shape.NorthWest, true),
            5744 => new RailBlock(Identifier, Shape.NorthWest, false),
            5745 => new RailBlock(Identifier, Shape.NorthEast, true),
            5746 => new RailBlock(Identifier, Shape.NorthEast, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ShapeValue = properties.Contains("shape") ? ShapeFromString(properties["shape"].GetString()) : ShapeValue,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("shape", new StringTag(ShapeToName(ShapeValue))),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Shape {
        NorthSouth,
        EastWest,
        AscendingEast,
        AscendingWest,
        AscendingNorth,
        AscendingSouth,
        SouthEast,
        SouthWest,
        NorthWest,
        NorthEast,
    }

    public static Shape ShapeFromString(string value) {
        return value switch {
            "north_south" => Shape.NorthSouth,
            "east_west" => Shape.EastWest,
            "ascending_east" => Shape.AscendingEast,
            "ascending_west" => Shape.AscendingWest,
            "ascending_north" => Shape.AscendingNorth,
            "ascending_south" => Shape.AscendingSouth,
            "south_east" => Shape.SouthEast,
            "south_west" => Shape.SouthWest,
            "north_west" => Shape.NorthWest,
            "north_east" => Shape.NorthEast,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Shape.")
        };
    }

    public static string ShapeToName(Shape value) {
        return value switch {
            Shape.NorthSouth => "north_south",
            Shape.EastWest => "east_west",
            Shape.AscendingEast => "ascending_east",
            Shape.AscendingWest => "ascending_west",
            Shape.AscendingNorth => "ascending_north",
            Shape.AscendingSouth => "ascending_south",
            Shape.SouthEast => "south_east",
            Shape.SouthWest => "south_west",
            Shape.NorthWest => "north_west",
            Shape.NorthEast => "north_east",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Shape value.")
        };
    }
}
