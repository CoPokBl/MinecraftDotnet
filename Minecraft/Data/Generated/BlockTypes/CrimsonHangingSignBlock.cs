using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CrimsonHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 241;
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
    public string SoundType => "nether_wood_hanging_sign";
    public Identifier? BlockEntity => "minecraft:hanging_sign";
    public Identifier? Item => "minecraft:crimson_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 53;
    public string TranslationKey => "block.minecraft.crimson_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6218,
                        false => 6219,
                    },
                    1 => Waterlogged switch {
                        true => 6220,
                        false => 6221,
                    },
                    2 => Waterlogged switch {
                        true => 6222,
                        false => 6223,
                    },
                    3 => Waterlogged switch {
                        true => 6224,
                        false => 6225,
                    },
                    4 => Waterlogged switch {
                        true => 6226,
                        false => 6227,
                    },
                    5 => Waterlogged switch {
                        true => 6228,
                        false => 6229,
                    },
                    6 => Waterlogged switch {
                        true => 6230,
                        false => 6231,
                    },
                    7 => Waterlogged switch {
                        true => 6232,
                        false => 6233,
                    },
                    8 => Waterlogged switch {
                        true => 6234,
                        false => 6235,
                    },
                    9 => Waterlogged switch {
                        true => 6236,
                        false => 6237,
                    },
                    10 => Waterlogged switch {
                        true => 6238,
                        false => 6239,
                    },
                    11 => Waterlogged switch {
                        true => 6240,
                        false => 6241,
                    },
                    12 => Waterlogged switch {
                        true => 6242,
                        false => 6243,
                    },
                    13 => Waterlogged switch {
                        true => 6244,
                        false => 6245,
                    },
                    14 => Waterlogged switch {
                        true => 6246,
                        false => 6247,
                    },
                    15 => Waterlogged switch {
                        true => 6248,
                        false => 6249,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6250,
                        false => 6251,
                    },
                    1 => Waterlogged switch {
                        true => 6252,
                        false => 6253,
                    },
                    2 => Waterlogged switch {
                        true => 6254,
                        false => 6255,
                    },
                    3 => Waterlogged switch {
                        true => 6256,
                        false => 6257,
                    },
                    4 => Waterlogged switch {
                        true => 6258,
                        false => 6259,
                    },
                    5 => Waterlogged switch {
                        true => 6260,
                        false => 6261,
                    },
                    6 => Waterlogged switch {
                        true => 6262,
                        false => 6263,
                    },
                    7 => Waterlogged switch {
                        true => 6264,
                        false => 6265,
                    },
                    8 => Waterlogged switch {
                        true => 6266,
                        false => 6267,
                    },
                    9 => Waterlogged switch {
                        true => 6268,
                        false => 6269,
                    },
                    10 => Waterlogged switch {
                        true => 6270,
                        false => 6271,
                    },
                    11 => Waterlogged switch {
                        true => 6272,
                        false => 6273,
                    },
                    12 => Waterlogged switch {
                        true => 6274,
                        false => 6275,
                    },
                    13 => Waterlogged switch {
                        true => 6276,
                        false => 6277,
                    },
                    14 => Waterlogged switch {
                        true => 6278,
                        false => 6279,
                    },
                    15 => Waterlogged switch {
                        true => 6280,
                        false => 6281,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6218 => new CrimsonHangingSignBlock(Identifier, true, 0, true),
            6219 => new CrimsonHangingSignBlock(Identifier, true, 0, false),
            6220 => new CrimsonHangingSignBlock(Identifier, true, 1, true),
            6221 => new CrimsonHangingSignBlock(Identifier, true, 1, false),
            6222 => new CrimsonHangingSignBlock(Identifier, true, 2, true),
            6223 => new CrimsonHangingSignBlock(Identifier, true, 2, false),
            6224 => new CrimsonHangingSignBlock(Identifier, true, 3, true),
            6225 => new CrimsonHangingSignBlock(Identifier, true, 3, false),
            6226 => new CrimsonHangingSignBlock(Identifier, true, 4, true),
            6227 => new CrimsonHangingSignBlock(Identifier, true, 4, false),
            6228 => new CrimsonHangingSignBlock(Identifier, true, 5, true),
            6229 => new CrimsonHangingSignBlock(Identifier, true, 5, false),
            6230 => new CrimsonHangingSignBlock(Identifier, true, 6, true),
            6231 => new CrimsonHangingSignBlock(Identifier, true, 6, false),
            6232 => new CrimsonHangingSignBlock(Identifier, true, 7, true),
            6233 => new CrimsonHangingSignBlock(Identifier, true, 7, false),
            6234 => new CrimsonHangingSignBlock(Identifier, true, 8, true),
            6235 => new CrimsonHangingSignBlock(Identifier, true, 8, false),
            6236 => new CrimsonHangingSignBlock(Identifier, true, 9, true),
            6237 => new CrimsonHangingSignBlock(Identifier, true, 9, false),
            6238 => new CrimsonHangingSignBlock(Identifier, true, 10, true),
            6239 => new CrimsonHangingSignBlock(Identifier, true, 10, false),
            6240 => new CrimsonHangingSignBlock(Identifier, true, 11, true),
            6241 => new CrimsonHangingSignBlock(Identifier, true, 11, false),
            6242 => new CrimsonHangingSignBlock(Identifier, true, 12, true),
            6243 => new CrimsonHangingSignBlock(Identifier, true, 12, false),
            6244 => new CrimsonHangingSignBlock(Identifier, true, 13, true),
            6245 => new CrimsonHangingSignBlock(Identifier, true, 13, false),
            6246 => new CrimsonHangingSignBlock(Identifier, true, 14, true),
            6247 => new CrimsonHangingSignBlock(Identifier, true, 14, false),
            6248 => new CrimsonHangingSignBlock(Identifier, true, 15, true),
            6249 => new CrimsonHangingSignBlock(Identifier, true, 15, false),
            6250 => new CrimsonHangingSignBlock(Identifier, false, 0, true),
            6251 => new CrimsonHangingSignBlock(Identifier, false, 0, false),
            6252 => new CrimsonHangingSignBlock(Identifier, false, 1, true),
            6253 => new CrimsonHangingSignBlock(Identifier, false, 1, false),
            6254 => new CrimsonHangingSignBlock(Identifier, false, 2, true),
            6255 => new CrimsonHangingSignBlock(Identifier, false, 2, false),
            6256 => new CrimsonHangingSignBlock(Identifier, false, 3, true),
            6257 => new CrimsonHangingSignBlock(Identifier, false, 3, false),
            6258 => new CrimsonHangingSignBlock(Identifier, false, 4, true),
            6259 => new CrimsonHangingSignBlock(Identifier, false, 4, false),
            6260 => new CrimsonHangingSignBlock(Identifier, false, 5, true),
            6261 => new CrimsonHangingSignBlock(Identifier, false, 5, false),
            6262 => new CrimsonHangingSignBlock(Identifier, false, 6, true),
            6263 => new CrimsonHangingSignBlock(Identifier, false, 6, false),
            6264 => new CrimsonHangingSignBlock(Identifier, false, 7, true),
            6265 => new CrimsonHangingSignBlock(Identifier, false, 7, false),
            6266 => new CrimsonHangingSignBlock(Identifier, false, 8, true),
            6267 => new CrimsonHangingSignBlock(Identifier, false, 8, false),
            6268 => new CrimsonHangingSignBlock(Identifier, false, 9, true),
            6269 => new CrimsonHangingSignBlock(Identifier, false, 9, false),
            6270 => new CrimsonHangingSignBlock(Identifier, false, 10, true),
            6271 => new CrimsonHangingSignBlock(Identifier, false, 10, false),
            6272 => new CrimsonHangingSignBlock(Identifier, false, 11, true),
            6273 => new CrimsonHangingSignBlock(Identifier, false, 11, false),
            6274 => new CrimsonHangingSignBlock(Identifier, false, 12, true),
            6275 => new CrimsonHangingSignBlock(Identifier, false, 12, false),
            6276 => new CrimsonHangingSignBlock(Identifier, false, 13, true),
            6277 => new CrimsonHangingSignBlock(Identifier, false, 13, false),
            6278 => new CrimsonHangingSignBlock(Identifier, false, 14, true),
            6279 => new CrimsonHangingSignBlock(Identifier, false, 14, false),
            6280 => new CrimsonHangingSignBlock(Identifier, false, 15, true),
            6281 => new CrimsonHangingSignBlock(Identifier, false, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Attached = properties.ChildrenMap.ContainsKey("attached") ? properties["attached"].GetString() == "true" : Attached,
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
