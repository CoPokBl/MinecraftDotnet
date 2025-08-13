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
    public int ProtocolId => 450;
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
                        true => 10129,
                        false => 10130,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 10131,
                        false => 10132,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 10133,
                        false => 10134,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 10135,
                        false => 10136,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 10137,
                        false => 10138,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 10139,
                        false => 10140,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 10141,
                        false => 10142,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 10143,
                        false => 10144,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 10145,
                        false => 10146,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 10147,
                        false => 10148,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 10149,
                        false => 10150,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 10151,
                        false => 10152,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            10129 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            10130 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            10131 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            10132 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            10133 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            10134 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            10135 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            10136 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            10137 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            10138 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            10139 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            10140 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            10141 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            10142 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            10143 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            10144 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            10145 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            10146 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            10147 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            10148 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            10149 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            10150 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            10151 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            10152 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
