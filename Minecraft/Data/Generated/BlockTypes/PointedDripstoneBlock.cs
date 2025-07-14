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
                        true => 25808,
                        false => 25809,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25810,
                        false => 25811,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Tip => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25812,
                        false => 25813,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25814,
                        false => 25815,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Frustum => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25816,
                        false => 25817,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25818,
                        false => 25819,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Middle => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25820,
                        false => 25821,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25822,
                        false => 25823,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                Thickness.Base => VerticalDirectionValue switch {
                    VerticalDirection.Up => Waterlogged switch {
                        true => 25824,
                        false => 25825,
                    },
                    VerticalDirection.Down => Waterlogged switch {
                        true => 25826,
                        false => 25827,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(VerticalDirectionValue), VerticalDirectionValue, "Unknown value for property vertical_direction.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(ThicknessValue), ThicknessValue, "Unknown value for property thickness.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            25808 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, true),
            25809 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Up, false),
            25810 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, true),
            25811 => new PointedDripstoneBlock(Identifier, Thickness.TipMerge, VerticalDirection.Down, false),
            25812 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, true),
            25813 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Up, false),
            25814 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, true),
            25815 => new PointedDripstoneBlock(Identifier, Thickness.Tip, VerticalDirection.Down, false),
            25816 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, true),
            25817 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Up, false),
            25818 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, true),
            25819 => new PointedDripstoneBlock(Identifier, Thickness.Frustum, VerticalDirection.Down, false),
            25820 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, true),
            25821 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Up, false),
            25822 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, true),
            25823 => new PointedDripstoneBlock(Identifier, Thickness.Middle, VerticalDirection.Down, false),
            25824 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, true),
            25825 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Up, false),
            25826 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, true),
            25827 => new PointedDripstoneBlock(Identifier, Thickness.Base, VerticalDirection.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            ThicknessValue = ThicknessFromString(properties["thickness"].GetString()),
            VerticalDirectionValue = VerticalDirectionFromString(properties["vertical_direction"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
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
}
