using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:cyan_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.cyan_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23256,
                        false => 23257,
                    },
                    false => Waterlogged switch {
                        true => 23258,
                        false => 23259,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23260,
                        false => 23261,
                    },
                    false => Waterlogged switch {
                        true => 23262,
                        false => 23263,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23264,
                        false => 23265,
                    },
                    false => Waterlogged switch {
                        true => 23266,
                        false => 23267,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23268,
                        false => 23269,
                    },
                    false => Waterlogged switch {
                        true => 23270,
                        false => 23271,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23256 => new CyanCandleBlock(Identifier, 1, true, true),
            23257 => new CyanCandleBlock(Identifier, 1, true, false),
            23258 => new CyanCandleBlock(Identifier, 1, false, true),
            23259 => new CyanCandleBlock(Identifier, 1, false, false),
            23260 => new CyanCandleBlock(Identifier, 2, true, true),
            23261 => new CyanCandleBlock(Identifier, 2, true, false),
            23262 => new CyanCandleBlock(Identifier, 2, false, true),
            23263 => new CyanCandleBlock(Identifier, 2, false, false),
            23264 => new CyanCandleBlock(Identifier, 3, true, true),
            23265 => new CyanCandleBlock(Identifier, 3, true, false),
            23266 => new CyanCandleBlock(Identifier, 3, false, true),
            23267 => new CyanCandleBlock(Identifier, 3, false, false),
            23268 => new CyanCandleBlock(Identifier, 4, true, true),
            23269 => new CyanCandleBlock(Identifier, 4, true, false),
            23270 => new CyanCandleBlock(Identifier, 4, false, true),
            23271 => new CyanCandleBlock(Identifier, 4, false, false),
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
