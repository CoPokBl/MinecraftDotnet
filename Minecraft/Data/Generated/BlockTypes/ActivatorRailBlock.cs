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
                        true => 11408,
                        false => 11409,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11410,
                        false => 11411,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11412,
                        false => 11413,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11414,
                        false => 11415,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11416,
                        false => 11417,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11418,
                        false => 11419,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
                false => Shape switch {
                    RailDirection.NorthSouth => Waterlogged switch {
                        true => 11420,
                        false => 11421,
                    },
                    RailDirection.EastWest => Waterlogged switch {
                        true => 11422,
                        false => 11423,
                    },
                    RailDirection.AscendingEast => Waterlogged switch {
                        true => 11424,
                        false => 11425,
                    },
                    RailDirection.AscendingWest => Waterlogged switch {
                        true => 11426,
                        false => 11427,
                    },
                    RailDirection.AscendingNorth => Waterlogged switch {
                        true => 11428,
                        false => 11429,
                    },
                    RailDirection.AscendingSouth => Waterlogged switch {
                        true => 11430,
                        false => 11431,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Shape), Shape, "Unknown value for property shape.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            11408 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, true),
            11409 => new ActivatorRailBlock(Identifier, true, RailDirection.NorthSouth, false),
            11410 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, true),
            11411 => new ActivatorRailBlock(Identifier, true, RailDirection.EastWest, false),
            11412 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, true),
            11413 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingEast, false),
            11414 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, true),
            11415 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingWest, false),
            11416 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, true),
            11417 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingNorth, false),
            11418 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, true),
            11419 => new ActivatorRailBlock(Identifier, true, RailDirection.AscendingSouth, false),
            11420 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, true),
            11421 => new ActivatorRailBlock(Identifier, false, RailDirection.NorthSouth, false),
            11422 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, true),
            11423 => new ActivatorRailBlock(Identifier, false, RailDirection.EastWest, false),
            11424 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, true),
            11425 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingEast, false),
            11426 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, true),
            11427 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingWest, false),
            11428 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, true),
            11429 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingNorth, false),
            11430 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, true),
            11431 => new ActivatorRailBlock(Identifier, false, RailDirection.AscendingSouth, false),
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
