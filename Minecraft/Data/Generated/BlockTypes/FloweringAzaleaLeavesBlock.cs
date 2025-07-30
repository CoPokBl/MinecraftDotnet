using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record FloweringAzaleaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:untinted_particle_leaves";
    public int ProtocolId => 98;
    public double Hardness => 0.2;
    public double ExplosionResistance => 0.2;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "azalea_leaves";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:flowering_azalea_leaves";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.flowering_azalea_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 532,
                        false => 533,
                    },
                    false => Waterlogged switch {
                        true => 534,
                        false => 535,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 536,
                        false => 537,
                    },
                    false => Waterlogged switch {
                        true => 538,
                        false => 539,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 540,
                        false => 541,
                    },
                    false => Waterlogged switch {
                        true => 542,
                        false => 543,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 544,
                        false => 545,
                    },
                    false => Waterlogged switch {
                        true => 546,
                        false => 547,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 548,
                        false => 549,
                    },
                    false => Waterlogged switch {
                        true => 550,
                        false => 551,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 552,
                        false => 553,
                    },
                    false => Waterlogged switch {
                        true => 554,
                        false => 555,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 556,
                        false => 557,
                    },
                    false => Waterlogged switch {
                        true => 558,
                        false => 559,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            532 => new FloweringAzaleaLeavesBlock(Identifier, 1, true, true),
            533 => new FloweringAzaleaLeavesBlock(Identifier, 1, true, false),
            534 => new FloweringAzaleaLeavesBlock(Identifier, 1, false, true),
            535 => new FloweringAzaleaLeavesBlock(Identifier, 1, false, false),
            536 => new FloweringAzaleaLeavesBlock(Identifier, 2, true, true),
            537 => new FloweringAzaleaLeavesBlock(Identifier, 2, true, false),
            538 => new FloweringAzaleaLeavesBlock(Identifier, 2, false, true),
            539 => new FloweringAzaleaLeavesBlock(Identifier, 2, false, false),
            540 => new FloweringAzaleaLeavesBlock(Identifier, 3, true, true),
            541 => new FloweringAzaleaLeavesBlock(Identifier, 3, true, false),
            542 => new FloweringAzaleaLeavesBlock(Identifier, 3, false, true),
            543 => new FloweringAzaleaLeavesBlock(Identifier, 3, false, false),
            544 => new FloweringAzaleaLeavesBlock(Identifier, 4, true, true),
            545 => new FloweringAzaleaLeavesBlock(Identifier, 4, true, false),
            546 => new FloweringAzaleaLeavesBlock(Identifier, 4, false, true),
            547 => new FloweringAzaleaLeavesBlock(Identifier, 4, false, false),
            548 => new FloweringAzaleaLeavesBlock(Identifier, 5, true, true),
            549 => new FloweringAzaleaLeavesBlock(Identifier, 5, true, false),
            550 => new FloweringAzaleaLeavesBlock(Identifier, 5, false, true),
            551 => new FloweringAzaleaLeavesBlock(Identifier, 5, false, false),
            552 => new FloweringAzaleaLeavesBlock(Identifier, 6, true, true),
            553 => new FloweringAzaleaLeavesBlock(Identifier, 6, true, false),
            554 => new FloweringAzaleaLeavesBlock(Identifier, 6, false, true),
            555 => new FloweringAzaleaLeavesBlock(Identifier, 6, false, false),
            556 => new FloweringAzaleaLeavesBlock(Identifier, 7, true, true),
            557 => new FloweringAzaleaLeavesBlock(Identifier, 7, true, false),
            558 => new FloweringAzaleaLeavesBlock(Identifier, 7, false, true),
            559 => new FloweringAzaleaLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = int.Parse(properties["distance"].GetString()),
            Persistent = properties["persistent"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("distance", Distance.ToString()),
            new StringTag("persistent", Persistent.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
