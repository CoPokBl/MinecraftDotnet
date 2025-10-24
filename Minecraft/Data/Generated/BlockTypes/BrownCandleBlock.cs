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
    public int ProtocolId => 955;
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
                        true => 23102,
                        false => 23103,
                    },
                    false => Waterlogged switch {
                        true => 23104,
                        false => 23105,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23106,
                        false => 23107,
                    },
                    false => Waterlogged switch {
                        true => 23108,
                        false => 23109,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23110,
                        false => 23111,
                    },
                    false => Waterlogged switch {
                        true => 23112,
                        false => 23113,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23114,
                        false => 23115,
                    },
                    false => Waterlogged switch {
                        true => 23116,
                        false => 23117,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23102 => new BrownCandleBlock(Identifier, 1, true, true),
            23103 => new BrownCandleBlock(Identifier, 1, true, false),
            23104 => new BrownCandleBlock(Identifier, 1, false, true),
            23105 => new BrownCandleBlock(Identifier, 1, false, false),
            23106 => new BrownCandleBlock(Identifier, 2, true, true),
            23107 => new BrownCandleBlock(Identifier, 2, true, false),
            23108 => new BrownCandleBlock(Identifier, 2, false, true),
            23109 => new BrownCandleBlock(Identifier, 2, false, false),
            23110 => new BrownCandleBlock(Identifier, 3, true, true),
            23111 => new BrownCandleBlock(Identifier, 3, true, false),
            23112 => new BrownCandleBlock(Identifier, 3, false, true),
            23113 => new BrownCandleBlock(Identifier, 3, false, false),
            23114 => new BrownCandleBlock(Identifier, 4, true, true),
            23115 => new BrownCandleBlock(Identifier, 4, true, false),
            23116 => new BrownCandleBlock(Identifier, 4, false, true),
            23117 => new BrownCandleBlock(Identifier, 4, false, false),
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
