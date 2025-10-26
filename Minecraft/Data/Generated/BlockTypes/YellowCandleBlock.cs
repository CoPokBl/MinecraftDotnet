using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record YellowCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 947;
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
    public Identifier? Item => "minecraft:yellow_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 18;
    public string TranslationKey => "block.minecraft.yellow_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22974,
                        false => 22975,
                    },
                    false => Waterlogged switch {
                        true => 22976,
                        false => 22977,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22978,
                        false => 22979,
                    },
                    false => Waterlogged switch {
                        true => 22980,
                        false => 22981,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22982,
                        false => 22983,
                    },
                    false => Waterlogged switch {
                        true => 22984,
                        false => 22985,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22986,
                        false => 22987,
                    },
                    false => Waterlogged switch {
                        true => 22988,
                        false => 22989,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22974 => new YellowCandleBlock(Identifier, 1, true, true),
            22975 => new YellowCandleBlock(Identifier, 1, true, false),
            22976 => new YellowCandleBlock(Identifier, 1, false, true),
            22977 => new YellowCandleBlock(Identifier, 1, false, false),
            22978 => new YellowCandleBlock(Identifier, 2, true, true),
            22979 => new YellowCandleBlock(Identifier, 2, true, false),
            22980 => new YellowCandleBlock(Identifier, 2, false, true),
            22981 => new YellowCandleBlock(Identifier, 2, false, false),
            22982 => new YellowCandleBlock(Identifier, 3, true, true),
            22983 => new YellowCandleBlock(Identifier, 3, true, false),
            22984 => new YellowCandleBlock(Identifier, 3, false, true),
            22985 => new YellowCandleBlock(Identifier, 3, false, false),
            22986 => new YellowCandleBlock(Identifier, 4, true, true),
            22987 => new YellowCandleBlock(Identifier, 4, true, false),
            22988 => new YellowCandleBlock(Identifier, 4, false, true),
            22989 => new YellowCandleBlock(Identifier, 4, false, false),
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
