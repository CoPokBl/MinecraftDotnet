using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 951;
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
    public Identifier? Item => "minecraft:light_gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.light_gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23038,
                        false => 23039,
                    },
                    false => Waterlogged switch {
                        true => 23040,
                        false => 23041,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23042,
                        false => 23043,
                    },
                    false => Waterlogged switch {
                        true => 23044,
                        false => 23045,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23046,
                        false => 23047,
                    },
                    false => Waterlogged switch {
                        true => 23048,
                        false => 23049,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23050,
                        false => 23051,
                    },
                    false => Waterlogged switch {
                        true => 23052,
                        false => 23053,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23038 => new LightGrayCandleBlock(Identifier, 1, true, true),
            23039 => new LightGrayCandleBlock(Identifier, 1, true, false),
            23040 => new LightGrayCandleBlock(Identifier, 1, false, true),
            23041 => new LightGrayCandleBlock(Identifier, 1, false, false),
            23042 => new LightGrayCandleBlock(Identifier, 2, true, true),
            23043 => new LightGrayCandleBlock(Identifier, 2, true, false),
            23044 => new LightGrayCandleBlock(Identifier, 2, false, true),
            23045 => new LightGrayCandleBlock(Identifier, 2, false, false),
            23046 => new LightGrayCandleBlock(Identifier, 3, true, true),
            23047 => new LightGrayCandleBlock(Identifier, 3, true, false),
            23048 => new LightGrayCandleBlock(Identifier, 3, false, true),
            23049 => new LightGrayCandleBlock(Identifier, 3, false, false),
            23050 => new LightGrayCandleBlock(Identifier, 4, true, true),
            23051 => new LightGrayCandleBlock(Identifier, 4, true, false),
            23052 => new LightGrayCandleBlock(Identifier, 4, false, true),
            23053 => new LightGrayCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = properties.ChildrenMap.ContainsKey("candles") ? int.Parse(properties["candles"].GetString()) : Candles,
            Lit = properties.ChildrenMap.ContainsKey("lit") ? properties["lit"].GetString() == "true" : Lit,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("candles", Candles.ToString()),
            new StringTag("lit", Lit.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
