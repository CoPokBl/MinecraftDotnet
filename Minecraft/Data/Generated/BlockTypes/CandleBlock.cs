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
    public int ProtocolId => 942;
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
                        true => 22894,
                        false => 22895,
                    },
                    false => Waterlogged switch {
                        true => 22896,
                        false => 22897,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22898,
                        false => 22899,
                    },
                    false => Waterlogged switch {
                        true => 22900,
                        false => 22901,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22902,
                        false => 22903,
                    },
                    false => Waterlogged switch {
                        true => 22904,
                        false => 22905,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22906,
                        false => 22907,
                    },
                    false => Waterlogged switch {
                        true => 22908,
                        false => 22909,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22894 => new CandleBlock(Identifier, 1, true, true),
            22895 => new CandleBlock(Identifier, 1, true, false),
            22896 => new CandleBlock(Identifier, 1, false, true),
            22897 => new CandleBlock(Identifier, 1, false, false),
            22898 => new CandleBlock(Identifier, 2, true, true),
            22899 => new CandleBlock(Identifier, 2, true, false),
            22900 => new CandleBlock(Identifier, 2, false, true),
            22901 => new CandleBlock(Identifier, 2, false, false),
            22902 => new CandleBlock(Identifier, 3, true, true),
            22903 => new CandleBlock(Identifier, 3, true, false),
            22904 => new CandleBlock(Identifier, 3, false, true),
            22905 => new CandleBlock(Identifier, 3, false, false),
            22906 => new CandleBlock(Identifier, 4, true, true),
            22907 => new CandleBlock(Identifier, 4, true, false),
            22908 => new CandleBlock(Identifier, 4, false, true),
            22909 => new CandleBlock(Identifier, 4, false, false),
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
