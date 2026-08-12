using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:brown_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.brown_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23304,
                        false => 23305,
                    },
                    false => Waterlogged switch {
                        true => 23306,
                        false => 23307,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23308,
                        false => 23309,
                    },
                    false => Waterlogged switch {
                        true => 23310,
                        false => 23311,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23312,
                        false => 23313,
                    },
                    false => Waterlogged switch {
                        true => 23314,
                        false => 23315,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23316,
                        false => 23317,
                    },
                    false => Waterlogged switch {
                        true => 23318,
                        false => 23319,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23304 => new BrownCandleBlock(Identifier, 1, true, true),
            23305 => new BrownCandleBlock(Identifier, 1, true, false),
            23306 => new BrownCandleBlock(Identifier, 1, false, true),
            23307 => new BrownCandleBlock(Identifier, 1, false, false),
            23308 => new BrownCandleBlock(Identifier, 2, true, true),
            23309 => new BrownCandleBlock(Identifier, 2, true, false),
            23310 => new BrownCandleBlock(Identifier, 2, false, true),
            23311 => new BrownCandleBlock(Identifier, 2, false, false),
            23312 => new BrownCandleBlock(Identifier, 3, true, true),
            23313 => new BrownCandleBlock(Identifier, 3, true, false),
            23314 => new BrownCandleBlock(Identifier, 3, false, true),
            23315 => new BrownCandleBlock(Identifier, 3, false, false),
            23316 => new BrownCandleBlock(Identifier, 4, true, true),
            23317 => new BrownCandleBlock(Identifier, 4, true, false),
            23318 => new BrownCandleBlock(Identifier, 4, false, true),
            23319 => new BrownCandleBlock(Identifier, 4, false, false),
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
