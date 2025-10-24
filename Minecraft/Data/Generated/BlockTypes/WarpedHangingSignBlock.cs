using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedHangingSignBlock(Identifier Identifier, bool Attached, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:ceiling_hanging_sign";
    public int ProtocolId => 242;
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
    public Identifier? Item => "minecraft:warped_hanging_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.4375] -> [0.9375, 0.625, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_hanging_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Attached switch {
                true => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6282,
                        false => 6283,
                    },
                    1 => Waterlogged switch {
                        true => 6284,
                        false => 6285,
                    },
                    2 => Waterlogged switch {
                        true => 6286,
                        false => 6287,
                    },
                    3 => Waterlogged switch {
                        true => 6288,
                        false => 6289,
                    },
                    4 => Waterlogged switch {
                        true => 6290,
                        false => 6291,
                    },
                    5 => Waterlogged switch {
                        true => 6292,
                        false => 6293,
                    },
                    6 => Waterlogged switch {
                        true => 6294,
                        false => 6295,
                    },
                    7 => Waterlogged switch {
                        true => 6296,
                        false => 6297,
                    },
                    8 => Waterlogged switch {
                        true => 6298,
                        false => 6299,
                    },
                    9 => Waterlogged switch {
                        true => 6300,
                        false => 6301,
                    },
                    10 => Waterlogged switch {
                        true => 6302,
                        false => 6303,
                    },
                    11 => Waterlogged switch {
                        true => 6304,
                        false => 6305,
                    },
                    12 => Waterlogged switch {
                        true => 6306,
                        false => 6307,
                    },
                    13 => Waterlogged switch {
                        true => 6308,
                        false => 6309,
                    },
                    14 => Waterlogged switch {
                        true => 6310,
                        false => 6311,
                    },
                    15 => Waterlogged switch {
                        true => 6312,
                        false => 6313,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
                false => Rotation switch {
                    0 => Waterlogged switch {
                        true => 6314,
                        false => 6315,
                    },
                    1 => Waterlogged switch {
                        true => 6316,
                        false => 6317,
                    },
                    2 => Waterlogged switch {
                        true => 6318,
                        false => 6319,
                    },
                    3 => Waterlogged switch {
                        true => 6320,
                        false => 6321,
                    },
                    4 => Waterlogged switch {
                        true => 6322,
                        false => 6323,
                    },
                    5 => Waterlogged switch {
                        true => 6324,
                        false => 6325,
                    },
                    6 => Waterlogged switch {
                        true => 6326,
                        false => 6327,
                    },
                    7 => Waterlogged switch {
                        true => 6328,
                        false => 6329,
                    },
                    8 => Waterlogged switch {
                        true => 6330,
                        false => 6331,
                    },
                    9 => Waterlogged switch {
                        true => 6332,
                        false => 6333,
                    },
                    10 => Waterlogged switch {
                        true => 6334,
                        false => 6335,
                    },
                    11 => Waterlogged switch {
                        true => 6336,
                        false => 6337,
                    },
                    12 => Waterlogged switch {
                        true => 6338,
                        false => 6339,
                    },
                    13 => Waterlogged switch {
                        true => 6340,
                        false => 6341,
                    },
                    14 => Waterlogged switch {
                        true => 6342,
                        false => 6343,
                    },
                    15 => Waterlogged switch {
                        true => 6344,
                        false => 6345,
                    },
                    _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            6282 => new WarpedHangingSignBlock(Identifier, true, 0, true),
            6283 => new WarpedHangingSignBlock(Identifier, true, 0, false),
            6284 => new WarpedHangingSignBlock(Identifier, true, 1, true),
            6285 => new WarpedHangingSignBlock(Identifier, true, 1, false),
            6286 => new WarpedHangingSignBlock(Identifier, true, 2, true),
            6287 => new WarpedHangingSignBlock(Identifier, true, 2, false),
            6288 => new WarpedHangingSignBlock(Identifier, true, 3, true),
            6289 => new WarpedHangingSignBlock(Identifier, true, 3, false),
            6290 => new WarpedHangingSignBlock(Identifier, true, 4, true),
            6291 => new WarpedHangingSignBlock(Identifier, true, 4, false),
            6292 => new WarpedHangingSignBlock(Identifier, true, 5, true),
            6293 => new WarpedHangingSignBlock(Identifier, true, 5, false),
            6294 => new WarpedHangingSignBlock(Identifier, true, 6, true),
            6295 => new WarpedHangingSignBlock(Identifier, true, 6, false),
            6296 => new WarpedHangingSignBlock(Identifier, true, 7, true),
            6297 => new WarpedHangingSignBlock(Identifier, true, 7, false),
            6298 => new WarpedHangingSignBlock(Identifier, true, 8, true),
            6299 => new WarpedHangingSignBlock(Identifier, true, 8, false),
            6300 => new WarpedHangingSignBlock(Identifier, true, 9, true),
            6301 => new WarpedHangingSignBlock(Identifier, true, 9, false),
            6302 => new WarpedHangingSignBlock(Identifier, true, 10, true),
            6303 => new WarpedHangingSignBlock(Identifier, true, 10, false),
            6304 => new WarpedHangingSignBlock(Identifier, true, 11, true),
            6305 => new WarpedHangingSignBlock(Identifier, true, 11, false),
            6306 => new WarpedHangingSignBlock(Identifier, true, 12, true),
            6307 => new WarpedHangingSignBlock(Identifier, true, 12, false),
            6308 => new WarpedHangingSignBlock(Identifier, true, 13, true),
            6309 => new WarpedHangingSignBlock(Identifier, true, 13, false),
            6310 => new WarpedHangingSignBlock(Identifier, true, 14, true),
            6311 => new WarpedHangingSignBlock(Identifier, true, 14, false),
            6312 => new WarpedHangingSignBlock(Identifier, true, 15, true),
            6313 => new WarpedHangingSignBlock(Identifier, true, 15, false),
            6314 => new WarpedHangingSignBlock(Identifier, false, 0, true),
            6315 => new WarpedHangingSignBlock(Identifier, false, 0, false),
            6316 => new WarpedHangingSignBlock(Identifier, false, 1, true),
            6317 => new WarpedHangingSignBlock(Identifier, false, 1, false),
            6318 => new WarpedHangingSignBlock(Identifier, false, 2, true),
            6319 => new WarpedHangingSignBlock(Identifier, false, 2, false),
            6320 => new WarpedHangingSignBlock(Identifier, false, 3, true),
            6321 => new WarpedHangingSignBlock(Identifier, false, 3, false),
            6322 => new WarpedHangingSignBlock(Identifier, false, 4, true),
            6323 => new WarpedHangingSignBlock(Identifier, false, 4, false),
            6324 => new WarpedHangingSignBlock(Identifier, false, 5, true),
            6325 => new WarpedHangingSignBlock(Identifier, false, 5, false),
            6326 => new WarpedHangingSignBlock(Identifier, false, 6, true),
            6327 => new WarpedHangingSignBlock(Identifier, false, 6, false),
            6328 => new WarpedHangingSignBlock(Identifier, false, 7, true),
            6329 => new WarpedHangingSignBlock(Identifier, false, 7, false),
            6330 => new WarpedHangingSignBlock(Identifier, false, 8, true),
            6331 => new WarpedHangingSignBlock(Identifier, false, 8, false),
            6332 => new WarpedHangingSignBlock(Identifier, false, 9, true),
            6333 => new WarpedHangingSignBlock(Identifier, false, 9, false),
            6334 => new WarpedHangingSignBlock(Identifier, false, 10, true),
            6335 => new WarpedHangingSignBlock(Identifier, false, 10, false),
            6336 => new WarpedHangingSignBlock(Identifier, false, 11, true),
            6337 => new WarpedHangingSignBlock(Identifier, false, 11, false),
            6338 => new WarpedHangingSignBlock(Identifier, false, 12, true),
            6339 => new WarpedHangingSignBlock(Identifier, false, 12, false),
            6340 => new WarpedHangingSignBlock(Identifier, false, 13, true),
            6341 => new WarpedHangingSignBlock(Identifier, false, 13, false),
            6342 => new WarpedHangingSignBlock(Identifier, false, 14, true),
            6343 => new WarpedHangingSignBlock(Identifier, false, 14, false),
            6344 => new WarpedHangingSignBlock(Identifier, false, 15, true),
            6345 => new WarpedHangingSignBlock(Identifier, false, 15, false),
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
