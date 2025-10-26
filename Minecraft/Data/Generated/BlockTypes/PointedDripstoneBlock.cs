using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PointedDripstoneBlock(Identifier Identifier, PointedDripstoneBlock.Thickness ThicknessValue, PointedDripstoneBlock.VerticalDirection VerticalDirectionValue, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:pointed_dripstone";
    public int ProtocolId => 1103;
    public double Hardness => 1.5;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "pointed_dripstone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pointed_dripstone";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.1875, 0.0, 0.1875] -> [0.5625, 0.6875, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 48;
    public string TranslationKey => "block.minecraft.pointed_dripstone";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return ThicknessValue switch {
                Thickness.TipMerge => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 27533,
                        false => 27534,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 27535,
                        false => 27536,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Tip => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 27537,
                        false => 27538,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 27539,
                        false => 27540,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Frustum => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 27541,
                        false => 27542,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 27543,
                        false => 27544,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Middle => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 27545,
                        false => 27546,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 27547,
                        false => 27548,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Base => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 27549,
                        false => 27550,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 27551,
                        false => 27552,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ThicknessValue), ThicknessValue, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27533 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, true),
            27534 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, false),
            27535 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, true),
            27536 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, false),
            27537 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, true),
            27538 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, false),
            27539 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, true),
            27540 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, false),
            27541 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, true),
            27542 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, false),
            27543 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, true),
            27544 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, false),
            27545 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, true),
            27546 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, false),
            27547 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, true),
            27548 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, false),
            27549 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, true),
            27550 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, false),
            27551 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, true),
            27552 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ThicknessValue = properties.ChildrenMap.ContainsKey("thickness") ? ThicknessFromString(properties["thickness"].GetString()) : ThicknessValue,
            VerticalDirectionValue = properties.ChildrenMap.ContainsKey("vertical_direction") ? VerticalDirectionFromString(properties["vertical_direction"].GetString()) : VerticalDirectionValue,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("thickness", ThicknessToName(ThicknessValue)),
            new StringTag("vertical_direction", VerticalDirectionToName(VerticalDirectionValue)),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
    public enum Thickness {
        TipMerge,
        Tip,
        Frustum,
        Middle,
        Base,
    }

    public static Thickness ThicknessFromString(string value) {
        return value switch {
            "tip_merge" => Thickness.TipMerge,
            "tip" => Thickness.Tip,
            "frustum" => Thickness.Frustum,
            "middle" => Thickness.Middle,
            "base" => Thickness.Base,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Thickness.")
        };
    }

    public static string ThicknessToName(Thickness value) {
        return value switch {
            Thickness.TipMerge => "tip_merge",
            Thickness.Tip => "tip",
            Thickness.Frustum => "frustum",
            Thickness.Middle => "middle",
            Thickness.Base => "base",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Thickness value.")
        };
    }
    public enum VerticalDirection {
        Up,
        Down,
    }

    public static VerticalDirection VerticalDirectionFromString(string value) {
        return value switch {
            "up" => VerticalDirection.Up,
            "down" => VerticalDirection.Down,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for VerticalDirection.")
        };
    }

    public static string VerticalDirectionToName(VerticalDirection value) {
        return value switch {
            VerticalDirection.Up => "up",
            VerticalDirection.Down => "down",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown VerticalDirection value.")
        };
    }
}
