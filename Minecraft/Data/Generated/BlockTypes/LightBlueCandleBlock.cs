using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 946;
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
    public Identifier? Item => "minecraft:light_blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 17;
    public string TranslationKey => "block.minecraft.light_blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22958,
                        false => 22959,
                    },
                    false => Waterlogged switch {
                        true => 22960,
                        false => 22961,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22962,
                        false => 22963,
                    },
                    false => Waterlogged switch {
                        true => 22964,
                        false => 22965,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22966,
                        false => 22967,
                    },
                    false => Waterlogged switch {
                        true => 22968,
                        false => 22969,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22970,
                        false => 22971,
                    },
                    false => Waterlogged switch {
                        true => 22972,
                        false => 22973,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22958 => new LightBlueCandleBlock(Identifier, 1, true, true),
            22959 => new LightBlueCandleBlock(Identifier, 1, true, false),
            22960 => new LightBlueCandleBlock(Identifier, 1, false, true),
            22961 => new LightBlueCandleBlock(Identifier, 1, false, false),
            22962 => new LightBlueCandleBlock(Identifier, 2, true, true),
            22963 => new LightBlueCandleBlock(Identifier, 2, true, false),
            22964 => new LightBlueCandleBlock(Identifier, 2, false, true),
            22965 => new LightBlueCandleBlock(Identifier, 2, false, false),
            22966 => new LightBlueCandleBlock(Identifier, 3, true, true),
            22967 => new LightBlueCandleBlock(Identifier, 3, true, false),
            22968 => new LightBlueCandleBlock(Identifier, 3, false, true),
            22969 => new LightBlueCandleBlock(Identifier, 3, false, false),
            22970 => new LightBlueCandleBlock(Identifier, 4, true, true),
            22971 => new LightBlueCandleBlock(Identifier, 4, true, false),
            22972 => new LightBlueCandleBlock(Identifier, 4, false, true),
            22973 => new LightBlueCandleBlock(Identifier, 4, false, false),
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
