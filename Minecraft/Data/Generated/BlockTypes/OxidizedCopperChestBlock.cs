using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OxidizedCopperChestBlock(Identifier Identifier, OxidizedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:oxidized_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 55;
    public string TranslationKey => "block.minecraft.oxidized_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29640,
                        false => 29641,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29646,
                        false => 29647,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29652,
                        false => 29653,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29658,
                        false => 29659,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29642,
                        false => 29643,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29648,
                        false => 29649,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29654,
                        false => 29655,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29660,
                        false => 29661,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29644,
                        false => 29645,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29650,
                        false => 29651,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29656,
                        false => 29657,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29662,
                        false => 29663,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29640 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29641 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29642 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29643 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29644 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29645 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29646 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29647 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29648 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29649 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29650 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29651 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29652 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29653 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29654 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29655 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29656 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29657 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29658 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29659 => new OxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29660 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29661 => new OxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29662 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29663 => new OxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
