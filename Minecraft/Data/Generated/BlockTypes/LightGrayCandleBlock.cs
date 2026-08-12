using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:light_gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.light_gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23240,
                        false => 23241,
                    },
                    false => Waterlogged switch {
                        true => 23242,
                        false => 23243,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23244,
                        false => 23245,
                    },
                    false => Waterlogged switch {
                        true => 23246,
                        false => 23247,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23248,
                        false => 23249,
                    },
                    false => Waterlogged switch {
                        true => 23250,
                        false => 23251,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23252,
                        false => 23253,
                    },
                    false => Waterlogged switch {
                        true => 23254,
                        false => 23255,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23240 => new LightGrayCandleBlock(Identifier, 1, true, true),
            23241 => new LightGrayCandleBlock(Identifier, 1, true, false),
            23242 => new LightGrayCandleBlock(Identifier, 1, false, true),
            23243 => new LightGrayCandleBlock(Identifier, 1, false, false),
            23244 => new LightGrayCandleBlock(Identifier, 2, true, true),
            23245 => new LightGrayCandleBlock(Identifier, 2, true, false),
            23246 => new LightGrayCandleBlock(Identifier, 2, false, true),
            23247 => new LightGrayCandleBlock(Identifier, 2, false, false),
            23248 => new LightGrayCandleBlock(Identifier, 3, true, true),
            23249 => new LightGrayCandleBlock(Identifier, 3, true, false),
            23250 => new LightGrayCandleBlock(Identifier, 3, false, true),
            23251 => new LightGrayCandleBlock(Identifier, 3, false, false),
            23252 => new LightGrayCandleBlock(Identifier, 4, true, true),
            23253 => new LightGrayCandleBlock(Identifier, 4, true, false),
            23254 => new LightGrayCandleBlock(Identifier, 4, false, true),
            23255 => new LightGrayCandleBlock(Identifier, 4, false, false),
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
