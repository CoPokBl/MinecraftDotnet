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
                        true => 19395,
                        false => 19396,
                    },
                    1 => Waterlogged switch {
                        true => 19397,
                        false => 19398,
                    },
                    2 => Waterlogged switch {
                        true => 19399,
                        false => 19400,
                    },
                    3 => Waterlogged switch {
                        true => 19401,
                        false => 19402,
                    },
                    4 => Waterlogged switch {
                        true => 19403,
                        false => 19404,
                    },
                    5 => Waterlogged switch {
                        true => 19405,
                        false => 19406,
                    },
                    6 => Waterlogged switch {
                        true => 19407,
                        false => 19408,
                    },
                    7 => Waterlogged switch {
                        true => 19409,
                        false => 19410,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
                false => Distance switch {
                    0 => Waterlogged switch {
                        true => 19411,
                        false => 19412,
                    },
                    1 => Waterlogged switch {
                        true => 19413,
                        false => 19414,
                    },
                    2 => Waterlogged switch {
                        true => 19415,
                        false => 19416,
                    },
                    3 => Waterlogged switch {
                        true => 19417,
                        false => 19418,
                    },
                    4 => Waterlogged switch {
                        true => 19419,
                        false => 19420,
                    },
                    5 => Waterlogged switch {
                        true => 19421,
                        false => 19422,
                    },
                    6 => Waterlogged switch {
                        true => 19423,
                        false => 19424,
                    },
                    7 => Waterlogged switch {
                        true => 19425,
                        false => 19426,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19395 => new ScaffoldingBlock(Identifier, true, 0, true),
            19396 => new ScaffoldingBlock(Identifier, true, 0, false),
            19397 => new ScaffoldingBlock(Identifier, true, 1, true),
            19398 => new ScaffoldingBlock(Identifier, true, 1, false),
            19399 => new ScaffoldingBlock(Identifier, true, 2, true),
            19400 => new ScaffoldingBlock(Identifier, true, 2, false),
            19401 => new ScaffoldingBlock(Identifier, true, 3, true),
            19402 => new ScaffoldingBlock(Identifier, true, 3, false),
            19403 => new ScaffoldingBlock(Identifier, true, 4, true),
            19404 => new ScaffoldingBlock(Identifier, true, 4, false),
            19405 => new ScaffoldingBlock(Identifier, true, 5, true),
            19406 => new ScaffoldingBlock(Identifier, true, 5, false),
            19407 => new ScaffoldingBlock(Identifier, true, 6, true),
            19408 => new ScaffoldingBlock(Identifier, true, 6, false),
            19409 => new ScaffoldingBlock(Identifier, true, 7, true),
            19410 => new ScaffoldingBlock(Identifier, true, 7, false),
            19411 => new ScaffoldingBlock(Identifier, false, 0, true),
            19412 => new ScaffoldingBlock(Identifier, false, 0, false),
            19413 => new ScaffoldingBlock(Identifier, false, 1, true),
            19414 => new ScaffoldingBlock(Identifier, false, 1, false),
            19415 => new ScaffoldingBlock(Identifier, false, 2, true),
            19416 => new ScaffoldingBlock(Identifier, false, 2, false),
            19417 => new ScaffoldingBlock(Identifier, false, 3, true),
            19418 => new ScaffoldingBlock(Identifier, false, 3, false),
            19419 => new ScaffoldingBlock(Identifier, false, 4, true),
            19420 => new ScaffoldingBlock(Identifier, false, 4, false),
            19421 => new ScaffoldingBlock(Identifier, false, 5, true),
            19422 => new ScaffoldingBlock(Identifier, false, 5, false),
            19423 => new ScaffoldingBlock(Identifier, false, 6, true),
            19424 => new ScaffoldingBlock(Identifier, false, 6, false),
            19425 => new ScaffoldingBlock(Identifier, false, 7, true),
            19426 => new ScaffoldingBlock(Identifier, false, 7, false),
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
    
}
