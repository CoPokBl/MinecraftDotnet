using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23224,
                        false => 23225,
                    },
                    false => Waterlogged switch {
                        true => 23226,
                        false => 23227,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23228,
                        false => 23229,
                    },
                    false => Waterlogged switch {
                        true => 23230,
                        false => 23231,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23232,
                        false => 23233,
                    },
                    false => Waterlogged switch {
                        true => 23234,
                        false => 23235,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23236,
                        false => 23237,
                    },
                    false => Waterlogged switch {
                        true => 23238,
                        false => 23239,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23224 => new GrayCandleBlock(Identifier, 1, true, true),
            23225 => new GrayCandleBlock(Identifier, 1, true, false),
            23226 => new GrayCandleBlock(Identifier, 1, false, true),
            23227 => new GrayCandleBlock(Identifier, 1, false, false),
            23228 => new GrayCandleBlock(Identifier, 2, true, true),
            23229 => new GrayCandleBlock(Identifier, 2, true, false),
            23230 => new GrayCandleBlock(Identifier, 2, false, true),
            23231 => new GrayCandleBlock(Identifier, 2, false, false),
            23232 => new GrayCandleBlock(Identifier, 3, true, true),
            23233 => new GrayCandleBlock(Identifier, 3, true, false),
            23234 => new GrayCandleBlock(Identifier, 3, false, true),
            23235 => new GrayCandleBlock(Identifier, 3, false, false),
            23236 => new GrayCandleBlock(Identifier, 4, true, true),
            23237 => new GrayCandleBlock(Identifier, 4, true, false),
            23238 => new GrayCandleBlock(Identifier, 4, false, true),
            23239 => new GrayCandleBlock(Identifier, 4, false, false),
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
