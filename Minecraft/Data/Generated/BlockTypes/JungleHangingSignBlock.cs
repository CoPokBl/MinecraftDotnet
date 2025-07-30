using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 226;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:jungle_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5258,
                        false => 5259,
                    },
                    1 => Waterlogged switch {
                        true => 5260,
                        false => 5261,
                    },
                    2 => Waterlogged switch {
                        true => 5262,
                        false => 5263,
                    },
                    3 => Waterlogged switch {
                        true => 5264,
                        false => 5265,
                    },
                    4 => Waterlogged switch {
                        true => 5266,
                        false => 5267,
                    },
                    5 => Waterlogged switch {
                        true => 5268,
                        false => 5269,
                    },
                    6 => Waterlogged switch {
                        true => 5270,
                        false => 5271,
                    },
                    7 => Waterlogged switch {
                        true => 5272,
                        false => 5273,
                    },
                    8 => Waterlogged switch {
                        true => 5274,
                        false => 5275,
                    },
                    9 => Waterlogged switch {
                        true => 5276,
                        false => 5277,
                    },
                    10 => Waterlogged switch {
                        true => 5278,
                        false => 5279,
                    },
                    11 => Waterlogged switch {
                        true => 5280,
                        false => 5281,
                    },
                    12 => Waterlogged switch {
                        true => 5282,
                        false => 5283,
                    },
                    13 => Waterlogged switch {
                        true => 5284,
                        false => 5285,
                    },
                    14 => Waterlogged switch {
                        true => 5286,
                        false => 5287,
                    },
                    15 => Waterlogged switch {
                        true => 5288,
                        false => 5289,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 5290,
                        false => 5291,
                    },
                    1 => Waterlogged switch {
                        true => 5292,
                        false => 5293,
                    },
                    2 => Waterlogged switch {
                        true => 5294,
                        false => 5295,
                    },
                    3 => Waterlogged switch {
                        true => 5296,
                        false => 5297,
                    },
                    4 => Waterlogged switch {
                        true => 5298,
                        false => 5299,
                    },
                    5 => Waterlogged switch {
                        true => 5300,
                        false => 5301,
                    },
                    6 => Waterlogged switch {
                        true => 5302,
                        false => 5303,
                    },
                    7 => Waterlogged switch {
                        true => 5304,
                        false => 5305,
                    },
                    8 => Waterlogged switch {
                        true => 5306,
                        false => 5307,
                    },
                    9 => Waterlogged switch {
                        true => 5308,
                        false => 5309,
                    },
                    10 => Waterlogged switch {
                        true => 5310,
                        false => 5311,
                    },
                    11 => Waterlogged switch {
                        true => 5312,
                        false => 5313,
                    },
                    12 => Waterlogged switch {
                        true => 5314,
                        false => 5315,
                    },
                    13 => Waterlogged switch {
                        true => 5316,
                        false => 5317,
                    },
                    14 => Waterlogged switch {
                        true => 5318,
                        false => 5319,
                    },
                    15 => Waterlogged switch {
                        true => 5320,
                        false => 5321,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5258 => new JungleHangingSignBlock(Identifier, true, 0, true),
            5259 => new JungleHangingSignBlock(Identifier, true, 0, false),
            5260 => new JungleHangingSignBlock(Identifier, true, 1, true),
            5261 => new JungleHangingSignBlock(Identifier, true, 1, false),
            5262 => new JungleHangingSignBlock(Identifier, true, 2, true),
            5263 => new JungleHangingSignBlock(Identifier, true, 2, false),
            5264 => new JungleHangingSignBlock(Identifier, true, 3, true),
            5265 => new JungleHangingSignBlock(Identifier, true, 3, false),
            5266 => new JungleHangingSignBlock(Identifier, true, 4, true),
            5267 => new JungleHangingSignBlock(Identifier, true, 4, false),
            5268 => new JungleHangingSignBlock(Identifier, true, 5, true),
            5269 => new JungleHangingSignBlock(Identifier, true, 5, false),
            5270 => new JungleHangingSignBlock(Identifier, true, 6, true),
            5271 => new JungleHangingSignBlock(Identifier, true, 6, false),
            5272 => new JungleHangingSignBlock(Identifier, true, 7, true),
            5273 => new JungleHangingSignBlock(Identifier, true, 7, false),
            5274 => new JungleHangingSignBlock(Identifier, true, 8, true),
            5275 => new JungleHangingSignBlock(Identifier, true, 8, false),
            5276 => new JungleHangingSignBlock(Identifier, true, 9, true),
            5277 => new JungleHangingSignBlock(Identifier, true, 9, false),
            5278 => new JungleHangingSignBlock(Identifier, true, 10, true),
            5279 => new JungleHangingSignBlock(Identifier, true, 10, false),
            5280 => new JungleHangingSignBlock(Identifier, true, 11, true),
            5281 => new JungleHangingSignBlock(Identifier, true, 11, false),
            5282 => new JungleHangingSignBlock(Identifier, true, 12, true),
            5283 => new JungleHangingSignBlock(Identifier, true, 12, false),
            5284 => new JungleHangingSignBlock(Identifier, true, 13, true),
            5285 => new JungleHangingSignBlock(Identifier, true, 13, false),
            5286 => new JungleHangingSignBlock(Identifier, true, 14, true),
            5287 => new JungleHangingSignBlock(Identifier, true, 14, false),
            5288 => new JungleHangingSignBlock(Identifier, true, 15, true),
            5289 => new JungleHangingSignBlock(Identifier, true, 15, false),
            5290 => new JungleHangingSignBlock(Identifier, false, 0, true),
            5291 => new JungleHangingSignBlock(Identifier, false, 0, false),
            5292 => new JungleHangingSignBlock(Identifier, false, 1, true),
            5293 => new JungleHangingSignBlock(Identifier, false, 1, false),
            5294 => new JungleHangingSignBlock(Identifier, false, 2, true),
            5295 => new JungleHangingSignBlock(Identifier, false, 2, false),
            5296 => new JungleHangingSignBlock(Identifier, false, 3, true),
            5297 => new JungleHangingSignBlock(Identifier, false, 3, false),
            5298 => new JungleHangingSignBlock(Identifier, false, 4, true),
            5299 => new JungleHangingSignBlock(Identifier, false, 4, false),
            5300 => new JungleHangingSignBlock(Identifier, false, 5, true),
            5301 => new JungleHangingSignBlock(Identifier, false, 5, false),
            5302 => new JungleHangingSignBlock(Identifier, false, 6, true),
            5303 => new JungleHangingSignBlock(Identifier, false, 6, false),
            5304 => new JungleHangingSignBlock(Identifier, false, 7, true),
            5305 => new JungleHangingSignBlock(Identifier, false, 7, false),
            5306 => new JungleHangingSignBlock(Identifier, false, 8, true),
            5307 => new JungleHangingSignBlock(Identifier, false, 8, false),
            5308 => new JungleHangingSignBlock(Identifier, false, 9, true),
            5309 => new JungleHangingSignBlock(Identifier, false, 9, false),
            5310 => new JungleHangingSignBlock(Identifier, false, 10, true),
            5311 => new JungleHangingSignBlock(Identifier, false, 10, false),
            5312 => new JungleHangingSignBlock(Identifier, false, 11, true),
            5313 => new JungleHangingSignBlock(Identifier, false, 11, false),
            5314 => new JungleHangingSignBlock(Identifier, false, 12, true),
            5315 => new JungleHangingSignBlock(Identifier, false, 12, false),
            5316 => new JungleHangingSignBlock(Identifier, false, 13, true),
            5317 => new JungleHangingSignBlock(Identifier, false, 13, false),
            5318 => new JungleHangingSignBlock(Identifier, false, 14, true),
            5319 => new JungleHangingSignBlock(Identifier, false, 14, false),
            5320 => new JungleHangingSignBlock(Identifier, false, 15, true),
            5321 => new JungleHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties["attached"].GetString() == "true",
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
                        new StringTag("attached", Attached.ToString().ToLower()),
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
