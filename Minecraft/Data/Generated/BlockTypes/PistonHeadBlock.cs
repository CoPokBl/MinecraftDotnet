using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PistonHeadBlock(Identifier Identifier, PistonHeadBlock.Type TypeValue, Cardinal Facing, bool Short) : IBlock {
    public Identifier Category => "minecraft:piston_head";
    public double Hardness => 1.5;
    public double ExplosionResistance => 1.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => null;
    public Identifier? Item => null;
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 0.25], AABB[0.375, 0.375, 0.25] -> [0.625, 0.625, 1.25]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 0.25], AABB[0.375, 0.375, 0.25] -> [0.625, 0.625, 1.25]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 0.25], AABB[0.375, 0.375, 0.25] -> [0.625, 0.625, 1.25]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 0.25], AABB[0.375, 0.375, 0.25] -> [0.625, 0.625, 1.25]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Block;
    public int MapColorId => 11;
    public string TranslationKey => "block.minecraft.piston_head";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return TypeValue switch {
                Type.Normal => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2269,
                        false => 2271,
                    },
                    Cardinal.East => Short switch {
                        true => 2273,
                        false => 2275,
                    },
                    Cardinal.South => Short switch {
                        true => 2277,
                        false => 2279,
                    },
                    Cardinal.West => Short switch {
                        true => 2281,
                        false => 2283,
                    },
                    Cardinal.Up => Short switch {
                        true => 2285,
                        false => 2287,
                    },
                    Cardinal.Down => Short switch {
                        true => 2289,
                        false => 2291,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                Type.Sticky => Facing switch {
                    Cardinal.North => Short switch {
                        true => 2270,
                        false => 2272,
                    },
                    Cardinal.East => Short switch {
                        true => 2274,
                        false => 2276,
                    },
                    Cardinal.South => Short switch {
                        true => 2278,
                        false => 2280,
                    },
                    Cardinal.West => Short switch {
                        true => 2282,
                        false => 2284,
                    },
                    Cardinal.Up => Short switch {
                        true => 2286,
                        false => 2288,
                    },
                    Cardinal.Down => Short switch {
                        true => 2290,
                        false => 2292,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Facing), Facing, "Unknown value for property facing.")
                },
                _ => throw new ArgumentOutOfRangeException(nameof(TypeValue), TypeValue, "Unknown value for property type.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2269 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, true),
            2270 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, true),
            2271 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.North, false),
            2272 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.North, false),
            2273 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, true),
            2274 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, true),
            2275 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.East, false),
            2276 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.East, false),
            2277 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, true),
            2278 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, true),
            2279 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.South, false),
            2280 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.South, false),
            2281 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, true),
            2282 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, true),
            2283 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.West, false),
            2284 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.West, false),
            2285 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, true),
            2286 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, true),
            2287 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Up, false),
            2288 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Up, false),
            2289 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, true),
            2290 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, true),
            2291 => new PistonHeadBlock(Identifier, Type.Normal, Cardinal.Down, false),
            2292 => new PistonHeadBlock(Identifier, Type.Sticky, Cardinal.Down, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            TypeValue = properties.Contains("type") ? TypeFromString(properties["type"].GetString()) : TypeValue,
            Facing = properties.Contains("facing") ? CardinalExtensions.FromString(properties["facing"].GetString()) : Facing,
            Short = properties.Contains("short") ? properties["short"].GetString() == "true" : Short,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("type", new StringTag(TypeToName(TypeValue))),
            ("facing", new StringTag(Facing.ToName())),
            ("short", new StringTag(Short.ToString().ToLower()))
        );
    }
    
    public enum Type {
        Normal,
        Sticky,
    }

    public static Type TypeFromString(string value) {
        return value switch {
            "normal" => Type.Normal,
            "sticky" => Type.Sticky,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown value for Type.")
        };
    }

    public static string TypeToName(Type value) {
        return value switch {
            Type.Normal => "normal",
            Type.Sticky => "sticky",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown Type value.")
        };
    }
}
