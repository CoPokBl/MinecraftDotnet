using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:light_blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 17;
    public string TranslationKey => "block.minecraft.light_blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23160,
                        false => 23161,
                    },
                    false => Waterlogged switch {
                        true => 23162,
                        false => 23163,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23164,
                        false => 23165,
                    },
                    false => Waterlogged switch {
                        true => 23166,
                        false => 23167,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23168,
                        false => 23169,
                    },
                    false => Waterlogged switch {
                        true => 23170,
                        false => 23171,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23172,
                        false => 23173,
                    },
                    false => Waterlogged switch {
                        true => 23174,
                        false => 23175,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23160 => new LightBlueCandleBlock(Identifier, 1, true, true),
            23161 => new LightBlueCandleBlock(Identifier, 1, true, false),
            23162 => new LightBlueCandleBlock(Identifier, 1, false, true),
            23163 => new LightBlueCandleBlock(Identifier, 1, false, false),
            23164 => new LightBlueCandleBlock(Identifier, 2, true, true),
            23165 => new LightBlueCandleBlock(Identifier, 2, true, false),
            23166 => new LightBlueCandleBlock(Identifier, 2, false, true),
            23167 => new LightBlueCandleBlock(Identifier, 2, false, false),
            23168 => new LightBlueCandleBlock(Identifier, 3, true, true),
            23169 => new LightBlueCandleBlock(Identifier, 3, true, false),
            23170 => new LightBlueCandleBlock(Identifier, 3, false, true),
            23171 => new LightBlueCandleBlock(Identifier, 3, false, false),
            23172 => new LightBlueCandleBlock(Identifier, 4, true, true),
            23173 => new LightBlueCandleBlock(Identifier, 4, true, false),
            23174 => new LightBlueCandleBlock(Identifier, 4, false, true),
            23175 => new LightBlueCandleBlock(Identifier, 4, false, false),
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
