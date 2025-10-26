using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 957;
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
    public Identifier? Item => "minecraft:red_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.red_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23134,
                        false => 23135,
                    },
                    false => Waterlogged switch {
                        true => 23136,
                        false => 23137,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23138,
                        false => 23139,
                    },
                    false => Waterlogged switch {
                        true => 23140,
                        false => 23141,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23142,
                        false => 23143,
                    },
                    false => Waterlogged switch {
                        true => 23144,
                        false => 23145,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23146,
                        false => 23147,
                    },
                    false => Waterlogged switch {
                        true => 23148,
                        false => 23149,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23134 => new RedCandleBlock(Identifier, 1, true, true),
            23135 => new RedCandleBlock(Identifier, 1, true, false),
            23136 => new RedCandleBlock(Identifier, 1, false, true),
            23137 => new RedCandleBlock(Identifier, 1, false, false),
            23138 => new RedCandleBlock(Identifier, 2, true, true),
            23139 => new RedCandleBlock(Identifier, 2, true, false),
            23140 => new RedCandleBlock(Identifier, 2, false, true),
            23141 => new RedCandleBlock(Identifier, 2, false, false),
            23142 => new RedCandleBlock(Identifier, 3, true, true),
            23143 => new RedCandleBlock(Identifier, 3, true, false),
            23144 => new RedCandleBlock(Identifier, 3, false, true),
            23145 => new RedCandleBlock(Identifier, 3, false, false),
            23146 => new RedCandleBlock(Identifier, 4, true, true),
            23147 => new RedCandleBlock(Identifier, 4, true, false),
            23148 => new RedCandleBlock(Identifier, 4, false, true),
            23149 => new RedCandleBlock(Identifier, 4, false, false),
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
