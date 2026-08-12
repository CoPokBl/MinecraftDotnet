using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:black_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.black_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23352,
                        false => 23353,
                    },
                    false => Waterlogged switch {
                        true => 23354,
                        false => 23355,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23356,
                        false => 23357,
                    },
                    false => Waterlogged switch {
                        true => 23358,
                        false => 23359,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23360,
                        false => 23361,
                    },
                    false => Waterlogged switch {
                        true => 23362,
                        false => 23363,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23364,
                        false => 23365,
                    },
                    false => Waterlogged switch {
                        true => 23366,
                        false => 23367,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23352 => new BlackCandleBlock(Identifier, 1, true, true),
            23353 => new BlackCandleBlock(Identifier, 1, true, false),
            23354 => new BlackCandleBlock(Identifier, 1, false, true),
            23355 => new BlackCandleBlock(Identifier, 1, false, false),
            23356 => new BlackCandleBlock(Identifier, 2, true, true),
            23357 => new BlackCandleBlock(Identifier, 2, true, false),
            23358 => new BlackCandleBlock(Identifier, 2, false, true),
            23359 => new BlackCandleBlock(Identifier, 2, false, false),
            23360 => new BlackCandleBlock(Identifier, 3, true, true),
            23361 => new BlackCandleBlock(Identifier, 3, true, false),
            23362 => new BlackCandleBlock(Identifier, 3, false, true),
            23363 => new BlackCandleBlock(Identifier, 3, false, false),
            23364 => new BlackCandleBlock(Identifier, 4, true, true),
            23365 => new BlackCandleBlock(Identifier, 4, true, false),
            23366 => new BlackCandleBlock(Identifier, 4, false, true),
            23367 => new BlackCandleBlock(Identifier, 4, false, false),
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
