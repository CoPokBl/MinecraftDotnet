using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ActivatorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:powered_rail";
    public int ProtocolId => 480;
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
    public Identifier? Item => "minecraft:activator_rail";
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
    public string TranslationKey => "block.minecraft.activator_rail";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 11206,
                        false => 11207,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11208,
                        false => 11209,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11210,
                        false => 11211,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11212,
                        false => 11213,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11214,
                        false => 11215,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11216,
                        false => 11217,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 11218,
                        false => 11219,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11220,
                        false => 11221,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11222,
                        false => 11223,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11224,
                        false => 11225,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11226,
                        false => 11227,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11228,
                        false => 11229,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11206 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            11207 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            11208 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            11209 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            11210 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            11211 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            11212 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            11213 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            11214 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            11215 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            11216 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            11217 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            11218 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            11219 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            11220 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            11221 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            11222 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            11223 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            11224 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            11225 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            11226 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            11227 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            11228 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            11229 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Powered = properties.ChildrenMap.ContainsKey("powered") ? properties["powered"].GetString() == "true" : Powered,
            Shape = properties.ChildrenMap.ContainsKey("shape") ? RailDirectionExtensions.FromString(properties["shape"].GetString()) : Shape,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("powered", Powered.ToString().ToLower()),
            new StringTag("shape", Shape.ToName()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
