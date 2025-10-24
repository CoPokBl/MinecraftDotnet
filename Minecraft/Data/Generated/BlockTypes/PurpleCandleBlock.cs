using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 953;
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
    public Identifier? Item => "minecraft:purple_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.purple_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23070,
                        false => 23071,
                    },
                    false => Waterlogged switch {
                        true => 23072,
                        false => 23073,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23074,
                        false => 23075,
                    },
                    false => Waterlogged switch {
                        true => 23076,
                        false => 23077,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23078,
                        false => 23079,
                    },
                    false => Waterlogged switch {
                        true => 23080,
                        false => 23081,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23082,
                        false => 23083,
                    },
                    false => Waterlogged switch {
                        true => 23084,
                        false => 23085,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23070 => new PurpleCandleBlock(Identifier, 1, true, true),
            23071 => new PurpleCandleBlock(Identifier, 1, true, false),
            23072 => new PurpleCandleBlock(Identifier, 1, false, true),
            23073 => new PurpleCandleBlock(Identifier, 1, false, false),
            23074 => new PurpleCandleBlock(Identifier, 2, true, true),
            23075 => new PurpleCandleBlock(Identifier, 2, true, false),
            23076 => new PurpleCandleBlock(Identifier, 2, false, true),
            23077 => new PurpleCandleBlock(Identifier, 2, false, false),
            23078 => new PurpleCandleBlock(Identifier, 3, true, true),
            23079 => new PurpleCandleBlock(Identifier, 3, true, false),
            23080 => new PurpleCandleBlock(Identifier, 3, false, true),
            23081 => new PurpleCandleBlock(Identifier, 3, false, false),
            23082 => new PurpleCandleBlock(Identifier, 4, true, true),
            23083 => new PurpleCandleBlock(Identifier, 4, true, false),
            23084 => new PurpleCandleBlock(Identifier, 4, false, true),
            23085 => new PurpleCandleBlock(Identifier, 4, false, false),
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
