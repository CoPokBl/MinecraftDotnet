using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:magenta_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 16;
    public string TranslationKey => "block.minecraft.magenta_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23144,
                        false => 23145,
                    },
                    false => Waterlogged switch {
                        true => 23146,
                        false => 23147,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23148,
                        false => 23149,
                    },
                    false => Waterlogged switch {
                        true => 23150,
                        false => 23151,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23152,
                        false => 23153,
                    },
                    false => Waterlogged switch {
                        true => 23154,
                        false => 23155,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23156,
                        false => 23157,
                    },
                    false => Waterlogged switch {
                        true => 23158,
                        false => 23159,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23144 => new MagentaCandleBlock(Identifier, 1, true, true),
            23145 => new MagentaCandleBlock(Identifier, 1, true, false),
            23146 => new MagentaCandleBlock(Identifier, 1, false, true),
            23147 => new MagentaCandleBlock(Identifier, 1, false, false),
            23148 => new MagentaCandleBlock(Identifier, 2, true, true),
            23149 => new MagentaCandleBlock(Identifier, 2, true, false),
            23150 => new MagentaCandleBlock(Identifier, 2, false, true),
            23151 => new MagentaCandleBlock(Identifier, 2, false, false),
            23152 => new MagentaCandleBlock(Identifier, 3, true, true),
            23153 => new MagentaCandleBlock(Identifier, 3, true, false),
            23154 => new MagentaCandleBlock(Identifier, 3, false, true),
            23155 => new MagentaCandleBlock(Identifier, 3, false, false),
            23156 => new MagentaCandleBlock(Identifier, 4, true, true),
            23157 => new MagentaCandleBlock(Identifier, 4, true, false),
            23158 => new MagentaCandleBlock(Identifier, 4, false, true),
            23159 => new MagentaCandleBlock(Identifier, 4, false, false),
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
