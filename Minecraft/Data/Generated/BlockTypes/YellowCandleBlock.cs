using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:yellow_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.yellow_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23176,
                        false => 23177,
                    },
                    false => Waterlogged switch {
                        true => 23178,
                        false => 23179,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23180,
                        false => 23181,
                    },
                    false => Waterlogged switch {
                        true => 23182,
                        false => 23183,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23184,
                        false => 23185,
                    },
                    false => Waterlogged switch {
                        true => 23186,
                        false => 23187,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23188,
                        false => 23189,
                    },
                    false => Waterlogged switch {
                        true => 23190,
                        false => 23191,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23176 => new YellowCandleBlock(Identifier, 1, true, true),
            23177 => new YellowCandleBlock(Identifier, 1, true, false),
            23178 => new YellowCandleBlock(Identifier, 1, false, true),
            23179 => new YellowCandleBlock(Identifier, 1, false, false),
            23180 => new YellowCandleBlock(Identifier, 2, true, true),
            23181 => new YellowCandleBlock(Identifier, 2, true, false),
            23182 => new YellowCandleBlock(Identifier, 2, false, true),
            23183 => new YellowCandleBlock(Identifier, 2, false, false),
            23184 => new YellowCandleBlock(Identifier, 3, true, true),
            23185 => new YellowCandleBlock(Identifier, 3, true, false),
            23186 => new YellowCandleBlock(Identifier, 3, false, true),
            23187 => new YellowCandleBlock(Identifier, 3, false, false),
            23188 => new YellowCandleBlock(Identifier, 4, true, true),
            23189 => new YellowCandleBlock(Identifier, 4, true, false),
            23190 => new YellowCandleBlock(Identifier, 4, false, true),
            23191 => new YellowCandleBlock(Identifier, 4, false, false),
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
