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
    public int ProtocolId => 835;
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
                        true => 20504,
                        false => 20505,
                    },
                    1 => Waterlogged switch {
                        true => 20506,
                        false => 20507,
                    },
                    2 => Waterlogged switch {
                        true => 20508,
                        false => 20509,
                    },
                    3 => Waterlogged switch {
                        true => 20510,
                        false => 20511,
                    },
                    4 => Waterlogged switch {
                        true => 20512,
                        false => 20513,
                    },
                    5 => Waterlogged switch {
                        true => 20514,
                        false => 20515,
                    },
                    6 => Waterlogged switch {
                        true => 20516,
                        false => 20517,
                    },
                    7 => Waterlogged switch {
                        true => 20518,
                        false => 20519,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 20520,
                        false => 20521,
                    },
                    1 => Waterlogged switch {
                        true => 20522,
                        false => 20523,
                    },
                    2 => Waterlogged switch {
                        true => 20524,
                        false => 20525,
                    },
                    3 => Waterlogged switch {
                        true => 20526,
                        false => 20527,
                    },
                    4 => Waterlogged switch {
                        true => 20528,
                        false => 20529,
                    },
                    5 => Waterlogged switch {
                        true => 20530,
                        false => 20531,
                    },
                    6 => Waterlogged switch {
                        true => 20532,
                        false => 20533,
                    },
                    7 => Waterlogged switch {
                        true => 20534,
                        false => 20535,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20504 => new ScaffoldingBlock(Identifier, true, 0, true),
            20505 => new ScaffoldingBlock(Identifier, true, 0, false),
            20506 => new ScaffoldingBlock(Identifier, true, 1, true),
            20507 => new ScaffoldingBlock(Identifier, true, 1, false),
            20508 => new ScaffoldingBlock(Identifier, true, 2, true),
            20509 => new ScaffoldingBlock(Identifier, true, 2, false),
            20510 => new ScaffoldingBlock(Identifier, true, 3, true),
            20511 => new ScaffoldingBlock(Identifier, true, 3, false),
            20512 => new ScaffoldingBlock(Identifier, true, 4, true),
            20513 => new ScaffoldingBlock(Identifier, true, 4, false),
            20514 => new ScaffoldingBlock(Identifier, true, 5, true),
            20515 => new ScaffoldingBlock(Identifier, true, 5, false),
            20516 => new ScaffoldingBlock(Identifier, true, 6, true),
            20517 => new ScaffoldingBlock(Identifier, true, 6, false),
            20518 => new ScaffoldingBlock(Identifier, true, 7, true),
            20519 => new ScaffoldingBlock(Identifier, true, 7, false),
            20520 => new ScaffoldingBlock(Identifier, false, 0, true),
            20521 => new ScaffoldingBlock(Identifier, false, 0, false),
            20522 => new ScaffoldingBlock(Identifier, false, 1, true),
            20523 => new ScaffoldingBlock(Identifier, false, 1, false),
            20524 => new ScaffoldingBlock(Identifier, false, 2, true),
            20525 => new ScaffoldingBlock(Identifier, false, 2, false),
            20526 => new ScaffoldingBlock(Identifier, false, 3, true),
            20527 => new ScaffoldingBlock(Identifier, false, 3, false),
            20528 => new ScaffoldingBlock(Identifier, false, 4, true),
            20529 => new ScaffoldingBlock(Identifier, false, 4, false),
            20530 => new ScaffoldingBlock(Identifier, false, 5, true),
            20531 => new ScaffoldingBlock(Identifier, false, 5, false),
            20532 => new ScaffoldingBlock(Identifier, false, 6, true),
            20533 => new ScaffoldingBlock(Identifier, false, 6, false),
            20534 => new ScaffoldingBlock(Identifier, false, 7, true),
            20535 => new ScaffoldingBlock(Identifier, false, 7, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties.ChildrenMap.ContainsKey("bottom") ? properties["bottom"].GetString() == "true" : Bottom,
            Distance = properties.ChildrenMap.ContainsKey("distance") ? int.Parse(properties["distance"].GetString()) : Distance,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("bottom", Bottom.ToString().ToLower()),
            new StringTag("distance", Distance.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
