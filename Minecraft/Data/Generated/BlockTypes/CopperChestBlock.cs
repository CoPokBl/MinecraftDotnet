using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CopperChestBlock(Identifier Identifier, CopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:weathering_copper_chest";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper";
    public Identifier? BlockEntity => "minecraft:chest";
    public Identifier? Item => "minecraft:copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29568,
                        false => 29569,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29574,
                        false => 29575,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29580,
                        false => 29581,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29586,
                        false => 29587,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29570,
                        false => 29571,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29576,
                        false => 29577,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29582,
                        false => 29583,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29588,
                        false => 29589,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29572,
                        false => 29573,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29578,
                        false => 29579,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29584,
                        false => 29585,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29590,
                        false => 29591,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29568 => new CopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29569 => new CopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29570 => new CopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29571 => new CopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29572 => new CopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29573 => new CopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29574 => new CopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29575 => new CopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29576 => new CopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29577 => new CopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29578 => new CopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29579 => new CopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29580 => new CopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29581 => new CopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29582 => new CopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29583 => new CopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29584 => new CopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29585 => new CopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29586 => new CopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29587 => new CopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29588 => new CopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29589 => new CopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29590 => new CopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29591 => new CopperChestBlock(Identifier, Type.Right, Direction.East, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? DirectionExtensions.FromString(properties["facing"].GetString()) : Facing,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
    public enum Type {
        Single,
        Left,
        Right,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "single" => Type.Single,
            "left" => Type.Left,
            "right" => Type.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }

    public static string TypeToName(Type value) {
        return value switch {
            Type.Single => "single",
            Type.Left => "left",
            Type.Right => "right",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type value.")
        };
    }
}
