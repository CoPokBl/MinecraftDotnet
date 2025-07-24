using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:tinted_particle_leaves";
    public int ProtocolId => 91;
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
    public Identifier? Item => "minecraft:jungle_leaves";
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
    public string TranslationKey => "block.minecraft.jungle_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 336,
                        false => 337,
                    },
                    false => Waterlogged switch {
                        true => 338,
                        false => 339,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 340,
                        false => 341,
                    },
                    false => Waterlogged switch {
                        true => 342,
                        false => 343,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 344,
                        false => 345,
                    },
                    false => Waterlogged switch {
                        true => 346,
                        false => 347,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 348,
                        false => 349,
                    },
                    false => Waterlogged switch {
                        true => 350,
                        false => 351,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 352,
                        false => 353,
                    },
                    false => Waterlogged switch {
                        true => 354,
                        false => 355,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 356,
                        false => 357,
                    },
                    false => Waterlogged switch {
                        true => 358,
                        false => 359,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 360,
                        false => 361,
                    },
                    false => Waterlogged switch {
                        true => 362,
                        false => 363,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            336 => new JungleLeavesBlock(Identifier, 1, true, true),
            337 => new JungleLeavesBlock(Identifier, 1, true, false),
            338 => new JungleLeavesBlock(Identifier, 1, false, true),
            339 => new JungleLeavesBlock(Identifier, 1, false, false),
            340 => new JungleLeavesBlock(Identifier, 2, true, true),
            341 => new JungleLeavesBlock(Identifier, 2, true, false),
            342 => new JungleLeavesBlock(Identifier, 2, false, true),
            343 => new JungleLeavesBlock(Identifier, 2, false, false),
            344 => new JungleLeavesBlock(Identifier, 3, true, true),
            345 => new JungleLeavesBlock(Identifier, 3, true, false),
            346 => new JungleLeavesBlock(Identifier, 3, false, true),
            347 => new JungleLeavesBlock(Identifier, 3, false, false),
            348 => new JungleLeavesBlock(Identifier, 4, true, true),
            349 => new JungleLeavesBlock(Identifier, 4, true, false),
            350 => new JungleLeavesBlock(Identifier, 4, false, true),
            351 => new JungleLeavesBlock(Identifier, 4, false, false),
            352 => new JungleLeavesBlock(Identifier, 5, true, true),
            353 => new JungleLeavesBlock(Identifier, 5, true, false),
            354 => new JungleLeavesBlock(Identifier, 5, false, true),
            355 => new JungleLeavesBlock(Identifier, 5, false, false),
            356 => new JungleLeavesBlock(Identifier, 6, true, true),
            357 => new JungleLeavesBlock(Identifier, 6, true, false),
            358 => new JungleLeavesBlock(Identifier, 6, false, true),
            359 => new JungleLeavesBlock(Identifier, 6, false, false),
            360 => new JungleLeavesBlock(Identifier, 7, true, true),
            361 => new JungleLeavesBlock(Identifier, 7, true, false),
            362 => new JungleLeavesBlock(Identifier, 7, false, true),
            363 => new JungleLeavesBlock(Identifier, 7, false, false),
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
