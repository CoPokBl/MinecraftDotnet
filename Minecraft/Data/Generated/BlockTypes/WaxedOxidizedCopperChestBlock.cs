using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedOxidizedCopperChestBlock(Identifier Identifier, WaxedOxidizedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:copper_chest";
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
    public Identifier? Item => "minecraft:waxed_oxidized_copper_chest";
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
    public string TranslationKey => "block.minecraft.waxed_oxidized_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29736,
                        false => 29737,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29742,
                        false => 29743,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29748,
                        false => 29749,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29754,
                        false => 29755,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29738,
                        false => 29739,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29744,
                        false => 29745,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29750,
                        false => 29751,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29756,
                        false => 29757,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29740,
                        false => 29741,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29746,
                        false => 29747,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29752,
                        false => 29753,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29758,
                        false => 29759,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29736 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29737 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29738 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29739 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29740 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29741 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29742 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29743 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29744 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29745 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29746 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29747 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29748 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29749 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29750 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29751 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29752 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29753 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29754 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29755 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29756 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29757 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29758 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29759 => new WaxedOxidizedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
