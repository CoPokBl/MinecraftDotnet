using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DetectorRailBlock(Identifier Identifier, bool Powered, RailDirection Shape, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:detector_rail";
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
    public Identifier? Item => "minecraft:detector_rail";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.125, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => true;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 0;
    public string TranslationKey => "block.minecraft.detector_rail";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Powered switch {
                true => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2211,
                        false => 2212,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2213,
                        false => 2214,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2215,
                        false => 2216,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2217,
                        false => 2218,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2219,
                        false => 2220,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2221,
                        false => 2222,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 2223,
                        false => 2224,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 2225,
                        false => 2226,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 2227,
                        false => 2228,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 2229,
                        false => 2230,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 2231,
                        false => 2232,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 2233,
                        false => 2234,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            2211 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            2212 => new DetectorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            2213 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, true),
            2214 => new DetectorRailBlock(Identifier, true, RailDirection.EastWest, false),
            2215 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            2216 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            2217 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            2218 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            2219 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            2220 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            2221 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            2222 => new DetectorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            2223 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            2224 => new DetectorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            2225 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, true),
            2226 => new DetectorRailBlock(Identifier, false, RailDirection.EastWest, false),
            2227 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            2228 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            2229 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            2230 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            2231 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            2232 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            2233 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            2234 => new DetectorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
