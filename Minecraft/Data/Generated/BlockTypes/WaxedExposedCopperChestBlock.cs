using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperChestBlock(Identifier Identifier, WaxedExposedCopperChestBlock.Type TypeValue, Direction Facing, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:waxed_exposed_copper_chest";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.875, 0.9375]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_chest";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Single => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29688,
                        false => 29689,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29694,
                        false => 29695,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29700,
                        false => 29701,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29706,
                        false => 29707,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Left => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29690,
                        false => 29691,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29696,
                        false => 29697,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29702,
                        false => 29703,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29708,
                        false => 29709,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Right => Facing switch {
                    Direction.North => Waterlogged switch {
                        true => 29692,
                        false => 29693,
                    },
                    Direction.South => Waterlogged switch {
                        true => 29698,
                        false => 29699,
                    },
                    Direction.West => Waterlogged switch {
                        true => 29704,
                        false => 29705,
                    },
                    Direction.East => Waterlogged switch {
                        true => 29710,
                        false => 29711,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29688 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.North, true),
            29689 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.North, false),
            29690 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.North, true),
            29691 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.North, false),
            29692 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.North, true),
            29693 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.North, false),
            29694 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.South, true),
            29695 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.South, false),
            29696 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.South, true),
            29697 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.South, false),
            29698 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.South, true),
            29699 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.South, false),
            29700 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.West, true),
            29701 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.West, false),
            29702 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.West, true),
            29703 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.West, false),
            29704 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.West, true),
            29705 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.West, false),
            29706 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.East, true),
            29707 => new WaxedExposedCopperChestBlock(Identifier, Type.Single, Direction.East, false),
            29708 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.East, true),
            29709 => new WaxedExposedCopperChestBlock(Identifier, Type.Left, Direction.East, false),
            29710 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.East, true),
            29711 => new WaxedExposedCopperChestBlock(Identifier, Type.Right, Direction.East, false),
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
