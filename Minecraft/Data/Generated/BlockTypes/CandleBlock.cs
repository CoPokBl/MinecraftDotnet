using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23096,
                        false => 23097,
                    },
                    false => Waterlogged switch {
                        true => 23098,
                        false => 23099,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23100,
                        false => 23101,
                    },
                    false => Waterlogged switch {
                        true => 23102,
                        false => 23103,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23104,
                        false => 23105,
                    },
                    false => Waterlogged switch {
                        true => 23106,
                        false => 23107,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23108,
                        false => 23109,
                    },
                    false => Waterlogged switch {
                        true => 23110,
                        false => 23111,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23096 => new CandleBlock(Identifier, 1, true, true),
            23097 => new CandleBlock(Identifier, 1, true, false),
            23098 => new CandleBlock(Identifier, 1, false, true),
            23099 => new CandleBlock(Identifier, 1, false, false),
            23100 => new CandleBlock(Identifier, 2, true, true),
            23101 => new CandleBlock(Identifier, 2, true, false),
            23102 => new CandleBlock(Identifier, 2, false, true),
            23103 => new CandleBlock(Identifier, 2, false, false),
            23104 => new CandleBlock(Identifier, 3, true, true),
            23105 => new CandleBlock(Identifier, 3, true, false),
            23106 => new CandleBlock(Identifier, 3, false, true),
            23107 => new CandleBlock(Identifier, 3, false, false),
            23108 => new CandleBlock(Identifier, 4, true, true),
            23109 => new CandleBlock(Identifier, 4, true, false),
            23110 => new CandleBlock(Identifier, 4, false, true),
            23111 => new CandleBlock(Identifier, 4, false, false),
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
