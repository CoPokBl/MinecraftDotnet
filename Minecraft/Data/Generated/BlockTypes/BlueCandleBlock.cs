using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 954;
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
    public Identifier? Item => "minecraft:blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 25;
    public string TranslationKey => "block.minecraft.blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23086,
                        false => 23087,
                    },
                    false => Waterlogged switch {
                        true => 23088,
                        false => 23089,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23090,
                        false => 23091,
                    },
                    false => Waterlogged switch {
                        true => 23092,
                        false => 23093,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23094,
                        false => 23095,
                    },
                    false => Waterlogged switch {
                        true => 23096,
                        false => 23097,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23098,
                        false => 23099,
                    },
                    false => Waterlogged switch {
                        true => 23100,
                        false => 23101,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23086 => new BlueCandleBlock(Identifier, 1, true, true),
            23087 => new BlueCandleBlock(Identifier, 1, true, false),
            23088 => new BlueCandleBlock(Identifier, 1, false, true),
            23089 => new BlueCandleBlock(Identifier, 1, false, false),
            23090 => new BlueCandleBlock(Identifier, 2, true, true),
            23091 => new BlueCandleBlock(Identifier, 2, true, false),
            23092 => new BlueCandleBlock(Identifier, 2, false, true),
            23093 => new BlueCandleBlock(Identifier, 2, false, false),
            23094 => new BlueCandleBlock(Identifier, 3, true, true),
            23095 => new BlueCandleBlock(Identifier, 3, true, false),
            23096 => new BlueCandleBlock(Identifier, 3, false, true),
            23097 => new BlueCandleBlock(Identifier, 3, false, false),
            23098 => new BlueCandleBlock(Identifier, 4, true, true),
            23099 => new BlueCandleBlock(Identifier, 4, true, false),
            23100 => new BlueCandleBlock(Identifier, 4, false, true),
            23101 => new BlueCandleBlock(Identifier, 4, false, false),
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
