using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:tinted_particle_leaves";
    public int ProtocolId => 92;
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
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:acacia_leaves";
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
    public string TranslationKey => "block.minecraft.acacia_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 364,
                        false => 365,
                    },
                    false => Waterlogged switch {
                        true => 366,
                        false => 367,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 368,
                        false => 369,
                    },
                    false => Waterlogged switch {
                        true => 370,
                        false => 371,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 372,
                        false => 373,
                    },
                    false => Waterlogged switch {
                        true => 374,
                        false => 375,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 376,
                        false => 377,
                    },
                    false => Waterlogged switch {
                        true => 378,
                        false => 379,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 380,
                        false => 381,
                    },
                    false => Waterlogged switch {
                        true => 382,
                        false => 383,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 384,
                        false => 385,
                    },
                    false => Waterlogged switch {
                        true => 386,
                        false => 387,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 388,
                        false => 389,
                    },
                    false => Waterlogged switch {
                        true => 390,
                        false => 391,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            364 => new AcaciaLeavesBlock(Identifier, 1, true, true),
            365 => new AcaciaLeavesBlock(Identifier, 1, true, false),
            366 => new AcaciaLeavesBlock(Identifier, 1, false, true),
            367 => new AcaciaLeavesBlock(Identifier, 1, false, false),
            368 => new AcaciaLeavesBlock(Identifier, 2, true, true),
            369 => new AcaciaLeavesBlock(Identifier, 2, true, false),
            370 => new AcaciaLeavesBlock(Identifier, 2, false, true),
            371 => new AcaciaLeavesBlock(Identifier, 2, false, false),
            372 => new AcaciaLeavesBlock(Identifier, 3, true, true),
            373 => new AcaciaLeavesBlock(Identifier, 3, true, false),
            374 => new AcaciaLeavesBlock(Identifier, 3, false, true),
            375 => new AcaciaLeavesBlock(Identifier, 3, false, false),
            376 => new AcaciaLeavesBlock(Identifier, 4, true, true),
            377 => new AcaciaLeavesBlock(Identifier, 4, true, false),
            378 => new AcaciaLeavesBlock(Identifier, 4, false, true),
            379 => new AcaciaLeavesBlock(Identifier, 4, false, false),
            380 => new AcaciaLeavesBlock(Identifier, 5, true, true),
            381 => new AcaciaLeavesBlock(Identifier, 5, true, false),
            382 => new AcaciaLeavesBlock(Identifier, 5, false, true),
            383 => new AcaciaLeavesBlock(Identifier, 5, false, false),
            384 => new AcaciaLeavesBlock(Identifier, 6, true, true),
            385 => new AcaciaLeavesBlock(Identifier, 6, true, false),
            386 => new AcaciaLeavesBlock(Identifier, 6, false, true),
            387 => new AcaciaLeavesBlock(Identifier, 6, false, false),
            388 => new AcaciaLeavesBlock(Identifier, 7, true, true),
            389 => new AcaciaLeavesBlock(Identifier, 7, true, false),
            390 => new AcaciaLeavesBlock(Identifier, 7, false, true),
            391 => new AcaciaLeavesBlock(Identifier, 7, false, false),
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
    
}
