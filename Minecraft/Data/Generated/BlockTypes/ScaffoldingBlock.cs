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
    public int ProtocolId => 805;
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
                        true => 19427,
                        false => 19428,
                    },
                    1 => Waterlogged switch {
                        true => 19429,
                        false => 19430,
                    },
                    2 => Waterlogged switch {
                        true => 19431,
                        false => 19432,
                    },
                    3 => Waterlogged switch {
                        true => 19433,
                        false => 19434,
                    },
                    4 => Waterlogged switch {
                        true => 19435,
                        false => 19436,
                    },
                    5 => Waterlogged switch {
                        true => 19437,
                        false => 19438,
                    },
                    6 => Waterlogged switch {
                        true => 19439,
                        false => 19440,
                    },
                    7 => Waterlogged switch {
                        true => 19441,
                        false => 19442,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 19443,
                        false => 19444,
                    },
                    1 => Waterlogged switch {
                        true => 19445,
                        false => 19446,
                    },
                    2 => Waterlogged switch {
                        true => 19447,
                        false => 19448,
                    },
                    3 => Waterlogged switch {
                        true => 19449,
                        false => 19450,
                    },
                    4 => Waterlogged switch {
                        true => 19451,
                        false => 19452,
                    },
                    5 => Waterlogged switch {
                        true => 19453,
                        false => 19454,
                    },
                    6 => Waterlogged switch {
                        true => 19455,
                        false => 19456,
                    },
                    7 => Waterlogged switch {
                        true => 19457,
                        false => 19458,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19427 => new ScaffoldingBlock(Identifier, true, 0, true),
            19428 => new ScaffoldingBlock(Identifier, true, 0, false),
            19429 => new ScaffoldingBlock(Identifier, true, 1, true),
            19430 => new ScaffoldingBlock(Identifier, true, 1, false),
            19431 => new ScaffoldingBlock(Identifier, true, 2, true),
            19432 => new ScaffoldingBlock(Identifier, true, 2, false),
            19433 => new ScaffoldingBlock(Identifier, true, 3, true),
            19434 => new ScaffoldingBlock(Identifier, true, 3, false),
            19435 => new ScaffoldingBlock(Identifier, true, 4, true),
            19436 => new ScaffoldingBlock(Identifier, true, 4, false),
            19437 => new ScaffoldingBlock(Identifier, true, 5, true),
            19438 => new ScaffoldingBlock(Identifier, true, 5, false),
            19439 => new ScaffoldingBlock(Identifier, true, 6, true),
            19440 => new ScaffoldingBlock(Identifier, true, 6, false),
            19441 => new ScaffoldingBlock(Identifier, true, 7, true),
            19442 => new ScaffoldingBlock(Identifier, true, 7, false),
            19443 => new ScaffoldingBlock(Identifier, false, 0, true),
            19444 => new ScaffoldingBlock(Identifier, false, 0, false),
            19445 => new ScaffoldingBlock(Identifier, false, 1, true),
            19446 => new ScaffoldingBlock(Identifier, false, 1, false),
            19447 => new ScaffoldingBlock(Identifier, false, 2, true),
            19448 => new ScaffoldingBlock(Identifier, false, 2, false),
            19449 => new ScaffoldingBlock(Identifier, false, 3, true),
            19450 => new ScaffoldingBlock(Identifier, false, 3, false),
            19451 => new ScaffoldingBlock(Identifier, false, 4, true),
            19452 => new ScaffoldingBlock(Identifier, false, 4, false),
            19453 => new ScaffoldingBlock(Identifier, false, 5, true),
            19454 => new ScaffoldingBlock(Identifier, false, 5, false),
            19455 => new ScaffoldingBlock(Identifier, false, 6, true),
            19456 => new ScaffoldingBlock(Identifier, false, 6, false),
            19457 => new ScaffoldingBlock(Identifier, false, 7, true),
            19458 => new ScaffoldingBlock(Identifier, false, 7, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Bottom = properties["bottom"].GetString() == "true",
            Distance = int.Parse(properties["distance"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
