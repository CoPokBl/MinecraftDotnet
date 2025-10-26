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
    public Identifier Category => "minecraft:rail";
    public int ProtocolId => 221;
    public double Hardness => 0.7;
    public double ExplosionResistance => 0.7;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "metal";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:rail";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.rail";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return ShapeValue switch {
                Shape.NorthSouth => Waterlogged switch {
                    true => 5526,
                    false => 5527,
                },
                Shape.EastWest => Waterlogged switch {
                    true => 5528,
                    false => 5529,
                },
                Shape.AscendingEast => Waterlogged switch {
                    true => 5530,
                    false => 5531,
                },
                Shape.AscendingWest => Waterlogged switch {
                    true => 5532,
                    false => 5533,
                },
                Shape.AscendingNorth => Waterlogged switch {
                    true => 5534,
                    false => 5535,
                },
                Shape.AscendingSouth => Waterlogged switch {
                    true => 5536,
                    false => 5537,
                },
                Shape.SouthEast => Waterlogged switch {
                    true => 5538,
                    false => 5539,
                },
                Shape.SouthWest => Waterlogged switch {
                    true => 5540,
                    false => 5541,
                },
                Shape.NorthWest => Waterlogged switch {
                    true => 5542,
                    false => 5543,
                },
                Shape.NorthEast => Waterlogged switch {
                    true => 5544,
                    false => 5545,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ShapeValue), ShapeValue, "Unknown value for property shape.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5526 => new RailBlock(Identifier, Shape.NorthSouth, true),
            5527 => new RailBlock(Identifier, Shape.NorthSouth, false),
            5528 => new RailBlock(Identifier, Shape.EastWest, true),
            5529 => new RailBlock(Identifier, Shape.EastWest, false),
            5530 => new RailBlock(Identifier, Shape.AscendingEast, true),
            5531 => new RailBlock(Identifier, Shape.AscendingEast, false),
            5532 => new RailBlock(Identifier, Shape.AscendingWest, true),
            5533 => new RailBlock(Identifier, Shape.AscendingWest, false),
            5534 => new RailBlock(Identifier, Shape.AscendingNorth, true),
            5535 => new RailBlock(Identifier, Shape.AscendingNorth, false),
            5536 => new RailBlock(Identifier, Shape.AscendingSouth, true),
            5537 => new RailBlock(Identifier, Shape.AscendingSouth, false),
            5538 => new RailBlock(Identifier, Shape.SouthEast, true),
            5539 => new RailBlock(Identifier, Shape.SouthEast, false),
            5540 => new RailBlock(Identifier, Shape.SouthWest, true),
            5541 => new RailBlock(Identifier, Shape.SouthWest, false),
            5542 => new RailBlock(Identifier, Shape.NorthWest, true),
            5543 => new RailBlock(Identifier, Shape.NorthWest, false),
            5544 => new RailBlock(Identifier, Shape.NorthEast, true),
            5545 => new RailBlock(Identifier, Shape.NorthEast, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ShapeValue = properties.ChildrenMap.ContainsKey("shape") ? ShapeFromString(properties["shape"].GetString()) : ShapeValue,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("shape", ShapeToName(ShapeValue)),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
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
