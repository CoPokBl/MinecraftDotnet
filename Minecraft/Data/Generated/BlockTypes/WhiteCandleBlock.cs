using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:white_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 3;
    public string TranslationKey => "block.minecraft.white_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23112,
                        false => 23113,
                    },
                    false => Waterlogged switch {
                        true => 23114,
                        false => 23115,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23116,
                        false => 23117,
                    },
                    false => Waterlogged switch {
                        true => 23118,
                        false => 23119,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23120,
                        false => 23121,
                    },
                    false => Waterlogged switch {
                        true => 23122,
                        false => 23123,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23124,
                        false => 23125,
                    },
                    false => Waterlogged switch {
                        true => 23126,
                        false => 23127,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23112 => new WhiteCandleBlock(Identifier, 1, true, true),
            23113 => new WhiteCandleBlock(Identifier, 1, true, false),
            23114 => new WhiteCandleBlock(Identifier, 1, false, true),
            23115 => new WhiteCandleBlock(Identifier, 1, false, false),
            23116 => new WhiteCandleBlock(Identifier, 2, true, true),
            23117 => new WhiteCandleBlock(Identifier, 2, true, false),
            23118 => new WhiteCandleBlock(Identifier, 2, false, true),
            23119 => new WhiteCandleBlock(Identifier, 2, false, false),
            23120 => new WhiteCandleBlock(Identifier, 3, true, true),
            23121 => new WhiteCandleBlock(Identifier, 3, true, false),
            23122 => new WhiteCandleBlock(Identifier, 3, false, true),
            23123 => new WhiteCandleBlock(Identifier, 3, false, false),
            23124 => new WhiteCandleBlock(Identifier, 4, true, true),
            23125 => new WhiteCandleBlock(Identifier, 4, true, false),
            23126 => new WhiteCandleBlock(Identifier, 4, false, true),
            23127 => new WhiteCandleBlock(Identifier, 4, false, false),
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
