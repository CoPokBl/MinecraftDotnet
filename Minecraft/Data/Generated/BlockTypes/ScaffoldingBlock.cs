using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record ScaffoldingBlock(Identifier Identifier, bool Bottom, int Distance, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:scaffolding";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "scaffolding";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:scaffolding";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.125], AABB[0.0, 0.0, 0.875] -> [0.125, 1.0, 1.0], AABB[0.875, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.875, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.0, 0.875, 0.125] -> [1.0, 1.0, 0.875], AABB[0.125, 0.875, 0.0] -> [0.875, 1.0, 0.125], AABB[0.125, 0.875, 0.875] -> [0.875, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.125], AABB[0.0, 0.0, 0.875] -> [0.125, 1.0, 1.0], AABB[0.875, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.875, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.0, 0.875, 0.125] -> [1.0, 1.0, 0.875], AABB[0.125, 0.875, 0.0] -> [0.875, 1.0, 0.125], AABB[0.125, 0.875, 0.875] -> [0.875, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [0.125, 1.0, 0.125], AABB[0.0, 0.0, 0.875] -> [0.125, 1.0, 1.0], AABB[0.875, 0.0, 0.0] -> [1.0, 1.0, 0.125], AABB[0.875, 0.0, 0.875] -> [1.0, 1.0, 1.0], AABB[0.0, 0.875, 0.125] -> [1.0, 1.0, 0.875], AABB[0.125, 0.875, 0.0] -> [0.875, 1.0, 0.125], AABB[0.125, 0.875, 0.875] -> [0.875, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.scaffolding";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Bottom switch {
                true => Distance switch {
                    0 => Waterlogged switch {
                        true => 20706,
                        false => 20707,
                    },
                    1 => Waterlogged switch {
                        true => 20708,
                        false => 20709,
                    },
                    2 => Waterlogged switch {
                        true => 20710,
                        false => 20711,
                    },
                    3 => Waterlogged switch {
                        true => 20712,
                        false => 20713,
                    },
                    4 => Waterlogged switch {
                        true => 20714,
                        false => 20715,
                    },
                    5 => Waterlogged switch {
                        true => 20716,
                        false => 20717,
                    },
                    6 => Waterlogged switch {
                        true => 20718,
                        false => 20719,
                    },
                    7 => Waterlogged switch {
                        true => 20720,
                        false => 20721,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 20722,
                        false => 20723,
                    },
                    1 => Waterlogged switch {
                        true => 20724,
                        false => 20725,
                    },
                    2 => Waterlogged switch {
                        true => 20726,
                        false => 20727,
                    },
                    3 => Waterlogged switch {
                        true => 20728,
                        false => 20729,
                    },
                    4 => Waterlogged switch {
                        true => 20730,
                        false => 20731,
                    },
                    5 => Waterlogged switch {
                        true => 20732,
                        false => 20733,
                    },
                    6 => Waterlogged switch {
                        true => 20734,
                        false => 20735,
                    },
                    7 => Waterlogged switch {
                        true => 20736,
                        false => 20737,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20706 => new ScaffoldingBlock(Identifier, true, 0, true),
            20707 => new ScaffoldingBlock(Identifier, true, 0, false),
            20708 => new ScaffoldingBlock(Identifier, true, 1, true),
            20709 => new ScaffoldingBlock(Identifier, true, 1, false),
            20710 => new ScaffoldingBlock(Identifier, true, 2, true),
            20711 => new ScaffoldingBlock(Identifier, true, 2, false),
            20712 => new ScaffoldingBlock(Identifier, true, 3, true),
            20713 => new ScaffoldingBlock(Identifier, true, 3, false),
            20714 => new ScaffoldingBlock(Identifier, true, 4, true),
            20715 => new ScaffoldingBlock(Identifier, true, 4, false),
            20716 => new ScaffoldingBlock(Identifier, true, 5, true),
            20717 => new ScaffoldingBlock(Identifier, true, 5, false),
            20718 => new ScaffoldingBlock(Identifier, true, 6, true),
            20719 => new ScaffoldingBlock(Identifier, true, 6, false),
            20720 => new ScaffoldingBlock(Identifier, true, 7, true),
            20721 => new ScaffoldingBlock(Identifier, true, 7, false),
            20722 => new ScaffoldingBlock(Identifier, false, 0, true),
            20723 => new ScaffoldingBlock(Identifier, false, 0, false),
            20724 => new ScaffoldingBlock(Identifier, false, 1, true),
            20725 => new ScaffoldingBlock(Identifier, false, 1, false),
            20726 => new ScaffoldingBlock(Identifier, false, 2, true),
            20727 => new ScaffoldingBlock(Identifier, false, 2, false),
            20728 => new ScaffoldingBlock(Identifier, false, 3, true),
            20729 => new ScaffoldingBlock(Identifier, false, 3, false),
            20730 => new ScaffoldingBlock(Identifier, false, 4, true),
            20731 => new ScaffoldingBlock(Identifier, false, 4, false),
            20732 => new ScaffoldingBlock(Identifier, false, 5, true),
            20733 => new ScaffoldingBlock(Identifier, false, 5, false),
            20734 => new ScaffoldingBlock(Identifier, false, 6, true),
            20735 => new ScaffoldingBlock(Identifier, false, 6, false),
            20736 => new ScaffoldingBlock(Identifier, false, 7, true),
            20737 => new ScaffoldingBlock(Identifier, false, 7, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.Contains("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            Distance = properties.Contains("distance") ? int.Parse(properties["distance"].GetString()) : Distance,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("bottom", new StringTag(Bottom.ToString().ToLower())),
            ("distance", new StringTag(Distance.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
