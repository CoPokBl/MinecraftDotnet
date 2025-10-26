using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LimeCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 948;
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
    public Identifier? Item => "minecraft:lime_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 19;
    public string TranslationKey => "block.minecraft.lime_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22990,
                        false => 22991,
                    },
                    false => Waterlogged switch {
                        true => 22992,
                        false => 22993,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22994,
                        false => 22995,
                    },
                    false => Waterlogged switch {
                        true => 22996,
                        false => 22997,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22998,
                        false => 22999,
                    },
                    false => Waterlogged switch {
                        true => 23000,
                        false => 23001,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23002,
                        false => 23003,
                    },
                    false => Waterlogged switch {
                        true => 23004,
                        false => 23005,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22990 => new LimeCandleBlock(Identifier, 1, true, true),
            22991 => new LimeCandleBlock(Identifier, 1, true, false),
            22992 => new LimeCandleBlock(Identifier, 1, false, true),
            22993 => new LimeCandleBlock(Identifier, 1, false, false),
            22994 => new LimeCandleBlock(Identifier, 2, true, true),
            22995 => new LimeCandleBlock(Identifier, 2, true, false),
            22996 => new LimeCandleBlock(Identifier, 2, false, true),
            22997 => new LimeCandleBlock(Identifier, 2, false, false),
            22998 => new LimeCandleBlock(Identifier, 3, true, true),
            22999 => new LimeCandleBlock(Identifier, 3, true, false),
            23000 => new LimeCandleBlock(Identifier, 3, false, true),
            23001 => new LimeCandleBlock(Identifier, 3, false, false),
            23002 => new LimeCandleBlock(Identifier, 4, true, true),
            23003 => new LimeCandleBlock(Identifier, 4, true, false),
            23004 => new LimeCandleBlock(Identifier, 4, false, true),
            23005 => new LimeCandleBlock(Identifier, 4, false, false),
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
