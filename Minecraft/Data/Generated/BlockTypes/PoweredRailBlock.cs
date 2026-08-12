using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PoweredRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:powered_rail";
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
    public Identifier? Item => "minecraft:powered_rail";
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
    public string TranslationKey => "block.minecraft.powered_rail";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2187,
                        false => 2188,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2189,
                        false => 2190,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2191,
                        false => 2192,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2193,
                        false => 2194,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2195,
                        false => 2196,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2197,
                        false => 2198,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2199,
                        false => 2200,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2201,
                        false => 2202,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2203,
                        false => 2204,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2205,
                        false => 2206,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2207,
                        false => 2208,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2209,
                        false => 2210,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2187 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2188 => new PoweredRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2189 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, true),
            2190 => new PoweredRailBlock(Identifier, true, RailDirection.EastWest, false),
            2191 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2192 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2193 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2194 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2195 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2196 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2197 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2198 => new PoweredRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2199 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2200 => new PoweredRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2201 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, true),
            2202 => new PoweredRailBlock(Identifier, false, RailDirection.EastWest, false),
            2203 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2204 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2205 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2206 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2207 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2208 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2209 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2210 => new PoweredRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
            Shape = properties.Contains("shape") ? RailDirectionExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("powered", new StringTag(Powered.ToString().ToLower())),
            ("shape", new StringTag(Shape.ToName())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
