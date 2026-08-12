using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public double Hardness => 0.1;
    public double ExplosionResistance => 0.1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "candle";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 25;
    public string TranslationKey => "block.minecraft.blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23288,
                        false => 23289,
                    },
                    false => Waterlogged switch {
                        true => 23290,
                        false => 23291,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23292,
                        false => 23293,
                    },
                    false => Waterlogged switch {
                        true => 23294,
                        false => 23295,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23296,
                        false => 23297,
                    },
                    false => Waterlogged switch {
                        true => 23298,
                        false => 23299,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23300,
                        false => 23301,
                    },
                    false => Waterlogged switch {
                        true => 23302,
                        false => 23303,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23288 => new BlueCandleBlock(Identifier, 1, true, true),
            23289 => new BlueCandleBlock(Identifier, 1, true, false),
            23290 => new BlueCandleBlock(Identifier, 1, false, true),
            23291 => new BlueCandleBlock(Identifier, 1, false, false),
            23292 => new BlueCandleBlock(Identifier, 2, true, true),
            23293 => new BlueCandleBlock(Identifier, 2, true, false),
            23294 => new BlueCandleBlock(Identifier, 2, false, true),
            23295 => new BlueCandleBlock(Identifier, 2, false, false),
            23296 => new BlueCandleBlock(Identifier, 3, true, true),
            23297 => new BlueCandleBlock(Identifier, 3, true, false),
            23298 => new BlueCandleBlock(Identifier, 3, false, true),
            23299 => new BlueCandleBlock(Identifier, 3, false, false),
            23300 => new BlueCandleBlock(Identifier, 4, true, true),
            23301 => new BlueCandleBlock(Identifier, 4, true, false),
            23302 => new BlueCandleBlock(Identifier, 4, false, true),
            23303 => new BlueCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = properties.Contains("candles") ? int.Parse(properties["candles"].GetString()) : Candles,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("candles", new StringTag(Candles.ToString())),
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
