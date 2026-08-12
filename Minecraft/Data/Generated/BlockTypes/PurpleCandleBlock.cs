using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:purple_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.purple_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23272,
                        false => 23273,
                    },
                    false => Waterlogged switch {
                        true => 23274,
                        false => 23275,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23276,
                        false => 23277,
                    },
                    false => Waterlogged switch {
                        true => 23278,
                        false => 23279,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23280,
                        false => 23281,
                    },
                    false => Waterlogged switch {
                        true => 23282,
                        false => 23283,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23284,
                        false => 23285,
                    },
                    false => Waterlogged switch {
                        true => 23286,
                        false => 23287,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23272 => new PurpleCandleBlock(Identifier, 1, true, true),
            23273 => new PurpleCandleBlock(Identifier, 1, true, false),
            23274 => new PurpleCandleBlock(Identifier, 1, false, true),
            23275 => new PurpleCandleBlock(Identifier, 1, false, false),
            23276 => new PurpleCandleBlock(Identifier, 2, true, true),
            23277 => new PurpleCandleBlock(Identifier, 2, true, false),
            23278 => new PurpleCandleBlock(Identifier, 2, false, true),
            23279 => new PurpleCandleBlock(Identifier, 2, false, false),
            23280 => new PurpleCandleBlock(Identifier, 3, true, true),
            23281 => new PurpleCandleBlock(Identifier, 3, true, false),
            23282 => new PurpleCandleBlock(Identifier, 3, false, true),
            23283 => new PurpleCandleBlock(Identifier, 3, false, false),
            23284 => new PurpleCandleBlock(Identifier, 4, true, true),
            23285 => new PurpleCandleBlock(Identifier, 4, true, false),
            23286 => new PurpleCandleBlock(Identifier, 4, false, true),
            23287 => new PurpleCandleBlock(Identifier, 4, false, false),
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
