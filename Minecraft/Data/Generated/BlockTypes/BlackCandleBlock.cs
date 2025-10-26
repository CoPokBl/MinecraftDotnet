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
    public int ProtocolId => 958;
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
                        true => 23150,
                        false => 23151,
                    },
                    false => Waterlogged switch {
                        true => 23152,
                        false => 23153,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23154,
                        false => 23155,
                    },
                    false => Waterlogged switch {
                        true => 23156,
                        false => 23157,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23158,
                        false => 23159,
                    },
                    false => Waterlogged switch {
                        true => 23160,
                        false => 23161,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23162,
                        false => 23163,
                    },
                    false => Waterlogged switch {
                        true => 23164,
                        false => 23165,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23150 => new BlackCandleBlock(Identifier, 1, true, true),
            23151 => new BlackCandleBlock(Identifier, 1, true, false),
            23152 => new BlackCandleBlock(Identifier, 1, false, true),
            23153 => new BlackCandleBlock(Identifier, 1, false, false),
            23154 => new BlackCandleBlock(Identifier, 2, true, true),
            23155 => new BlackCandleBlock(Identifier, 2, true, false),
            23156 => new BlackCandleBlock(Identifier, 2, false, true),
            23157 => new BlackCandleBlock(Identifier, 2, false, false),
            23158 => new BlackCandleBlock(Identifier, 3, true, true),
            23159 => new BlackCandleBlock(Identifier, 3, true, false),
            23160 => new BlackCandleBlock(Identifier, 3, false, true),
            23161 => new BlackCandleBlock(Identifier, 3, false, false),
            23162 => new BlackCandleBlock(Identifier, 4, true, true),
            23163 => new BlackCandleBlock(Identifier, 4, true, false),
            23164 => new BlackCandleBlock(Identifier, 4, false, true),
            23165 => new BlackCandleBlock(Identifier, 4, false, false),
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
