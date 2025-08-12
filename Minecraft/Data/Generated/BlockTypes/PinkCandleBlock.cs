using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PinkCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 911;
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
    public Identifier? Item => "minecraft:pink_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 20;
    public string TranslationKey => "block.minecraft.pink_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21897,
                        false => 21898,
                    },
                    false => Waterlogged switch {
                        true => 21899,
                        false => 21900,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21901,
                        false => 21902,
                    },
                    false => Waterlogged switch {
                        true => 21903,
                        false => 21904,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21905,
                        false => 21906,
                    },
                    false => Waterlogged switch {
                        true => 21907,
                        false => 21908,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21909,
                        false => 21910,
                    },
                    false => Waterlogged switch {
                        true => 21911,
                        false => 21912,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21897 => new PinkCandleBlock(Identifier, 1, true, true),
            21898 => new PinkCandleBlock(Identifier, 1, true, false),
            21899 => new PinkCandleBlock(Identifier, 1, false, true),
            21900 => new PinkCandleBlock(Identifier, 1, false, false),
            21901 => new PinkCandleBlock(Identifier, 2, true, true),
            21902 => new PinkCandleBlock(Identifier, 2, true, false),
            21903 => new PinkCandleBlock(Identifier, 2, false, true),
            21904 => new PinkCandleBlock(Identifier, 2, false, false),
            21905 => new PinkCandleBlock(Identifier, 3, true, true),
            21906 => new PinkCandleBlock(Identifier, 3, true, false),
            21907 => new PinkCandleBlock(Identifier, 3, false, true),
            21908 => new PinkCandleBlock(Identifier, 3, false, false),
            21909 => new PinkCandleBlock(Identifier, 4, true, true),
            21910 => new PinkCandleBlock(Identifier, 4, true, false),
            21911 => new PinkCandleBlock(Identifier, 4, false, true),
            21912 => new PinkCandleBlock(Identifier, 4, false, false),
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
