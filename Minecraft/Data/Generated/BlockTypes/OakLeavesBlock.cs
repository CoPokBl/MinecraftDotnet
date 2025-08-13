using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OakLeavesBlock(Identifier Identifier, int Distance, bool Persistent, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:tinted_particle_leaves";
    public int ProtocolId => 88;
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
    public Identifier? Item => "minecraft:oak_leaves";
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
    public string TranslationKey => "block.minecraft.oak_leaves";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Distance switch {
                1 => Persistent switch {
                    true => Waterlogged switch {
                        true => 252,
                        false => 253,
                    },
                    false => Waterlogged switch {
                        true => 254,
                        false => 255,
                    },
                },
                2 => Persistent switch {
                    true => Waterlogged switch {
                        true => 256,
                        false => 257,
                    },
                    false => Waterlogged switch {
                        true => 258,
                        false => 259,
                    },
                },
                3 => Persistent switch {
                    true => Waterlogged switch {
                        true => 260,
                        false => 261,
                    },
                    false => Waterlogged switch {
                        true => 262,
                        false => 263,
                    },
                },
                4 => Persistent switch {
                    true => Waterlogged switch {
                        true => 264,
                        false => 265,
                    },
                    false => Waterlogged switch {
                        true => 266,
                        false => 267,
                    },
                },
                5 => Persistent switch {
                    true => Waterlogged switch {
                        true => 268,
                        false => 269,
                    },
                    false => Waterlogged switch {
                        true => 270,
                        false => 271,
                    },
                },
                6 => Persistent switch {
                    true => Waterlogged switch {
                        true => 272,
                        false => 273,
                    },
                    false => Waterlogged switch {
                        true => 274,
                        false => 275,
                    },
                },
                7 => Persistent switch {
                    true => Waterlogged switch {
                        true => 276,
                        false => 277,
                    },
                    false => Waterlogged switch {
                        true => 278,
                        false => 279,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Distance), Distance, "Unknown value for property distance.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            252 => new OakLeavesBlock(Identifier, 1, true, true),
            253 => new OakLeavesBlock(Identifier, 1, true, false),
            254 => new OakLeavesBlock(Identifier, 1, false, true),
            255 => new OakLeavesBlock(Identifier, 1, false, false),
            256 => new OakLeavesBlock(Identifier, 2, true, true),
            257 => new OakLeavesBlock(Identifier, 2, true, false),
            258 => new OakLeavesBlock(Identifier, 2, false, true),
            259 => new OakLeavesBlock(Identifier, 2, false, false),
            260 => new OakLeavesBlock(Identifier, 3, true, true),
            261 => new OakLeavesBlock(Identifier, 3, true, false),
            262 => new OakLeavesBlock(Identifier, 3, false, true),
            263 => new OakLeavesBlock(Identifier, 3, false, false),
            264 => new OakLeavesBlock(Identifier, 4, true, true),
            265 => new OakLeavesBlock(Identifier, 4, true, false),
            266 => new OakLeavesBlock(Identifier, 4, false, true),
            267 => new OakLeavesBlock(Identifier, 4, false, false),
            268 => new OakLeavesBlock(Identifier, 5, true, true),
            269 => new OakLeavesBlock(Identifier, 5, true, false),
            270 => new OakLeavesBlock(Identifier, 5, false, true),
            271 => new OakLeavesBlock(Identifier, 5, false, false),
            272 => new OakLeavesBlock(Identifier, 6, true, true),
            273 => new OakLeavesBlock(Identifier, 6, true, false),
            274 => new OakLeavesBlock(Identifier, 6, false, true),
            275 => new OakLeavesBlock(Identifier, 6, false, false),
            276 => new OakLeavesBlock(Identifier, 7, true, true),
            277 => new OakLeavesBlock(Identifier, 7, true, false),
            278 => new OakLeavesBlock(Identifier, 7, false, true),
            279 => new OakLeavesBlock(Identifier, 7, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Distance = properties.ChildrenMap.ContainsKey("distance") ? int.Parse(properties["distance"].GetString()) : Distance,
            Persistent = properties.ChildrenMap.ContainsKey("persistent") ? properties["persistent"].GetString() == "true" : Persistent,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
