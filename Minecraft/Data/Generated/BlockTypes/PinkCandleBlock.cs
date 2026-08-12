using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:pink_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 20;
    public string TranslationKey => "block.minecraft.pink_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23208,
                        false => 23209,
                    },
                    false => Waterlogged switch {
                        true => 23210,
                        false => 23211,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23212,
                        false => 23213,
                    },
                    false => Waterlogged switch {
                        true => 23214,
                        false => 23215,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23216,
                        false => 23217,
                    },
                    false => Waterlogged switch {
                        true => 23218,
                        false => 23219,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23220,
                        false => 23221,
                    },
                    false => Waterlogged switch {
                        true => 23222,
                        false => 23223,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23208 => new PinkCandleBlock(Identifier, 1, true, true),
            23209 => new PinkCandleBlock(Identifier, 1, true, false),
            23210 => new PinkCandleBlock(Identifier, 1, false, true),
            23211 => new PinkCandleBlock(Identifier, 1, false, false),
            23212 => new PinkCandleBlock(Identifier, 2, true, true),
            23213 => new PinkCandleBlock(Identifier, 2, true, false),
            23214 => new PinkCandleBlock(Identifier, 2, false, true),
            23215 => new PinkCandleBlock(Identifier, 2, false, false),
            23216 => new PinkCandleBlock(Identifier, 3, true, true),
            23217 => new PinkCandleBlock(Identifier, 3, true, false),
            23218 => new PinkCandleBlock(Identifier, 3, false, true),
            23219 => new PinkCandleBlock(Identifier, 3, false, false),
            23220 => new PinkCandleBlock(Identifier, 4, true, true),
            23221 => new PinkCandleBlock(Identifier, 4, true, false),
            23222 => new PinkCandleBlock(Identifier, 4, false, true),
            23223 => new PinkCandleBlock(Identifier, 4, false, false),
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
