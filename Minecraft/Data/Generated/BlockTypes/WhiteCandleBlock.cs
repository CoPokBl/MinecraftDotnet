using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 943;
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
    public Identifier? Item => "minecraft:white_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 3;
    public string TranslationKey => "block.minecraft.white_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22910,
                        false => 22911,
                    },
                    false => Waterlogged switch {
                        true => 22912,
                        false => 22913,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22914,
                        false => 22915,
                    },
                    false => Waterlogged switch {
                        true => 22916,
                        false => 22917,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22918,
                        false => 22919,
                    },
                    false => Waterlogged switch {
                        true => 22920,
                        false => 22921,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22922,
                        false => 22923,
                    },
                    false => Waterlogged switch {
                        true => 22924,
                        false => 22925,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22910 => new WhiteCandleBlock(Identifier, 1, true, true),
            22911 => new WhiteCandleBlock(Identifier, 1, true, false),
            22912 => new WhiteCandleBlock(Identifier, 1, false, true),
            22913 => new WhiteCandleBlock(Identifier, 1, false, false),
            22914 => new WhiteCandleBlock(Identifier, 2, true, true),
            22915 => new WhiteCandleBlock(Identifier, 2, true, false),
            22916 => new WhiteCandleBlock(Identifier, 2, false, true),
            22917 => new WhiteCandleBlock(Identifier, 2, false, false),
            22918 => new WhiteCandleBlock(Identifier, 3, true, true),
            22919 => new WhiteCandleBlock(Identifier, 3, true, false),
            22920 => new WhiteCandleBlock(Identifier, 3, false, true),
            22921 => new WhiteCandleBlock(Identifier, 3, false, false),
            22922 => new WhiteCandleBlock(Identifier, 4, true, true),
            22923 => new WhiteCandleBlock(Identifier, 4, true, false),
            22924 => new WhiteCandleBlock(Identifier, 4, false, true),
            22925 => new WhiteCandleBlock(Identifier, 4, false, false),
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
