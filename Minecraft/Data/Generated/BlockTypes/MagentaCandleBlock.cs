using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MagentaCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 945;
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
    public Identifier? Item => "minecraft:magenta_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 16;
    public string TranslationKey => "block.minecraft.magenta_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22942,
                        false => 22943,
                    },
                    false => Waterlogged switch {
                        true => 22944,
                        false => 22945,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22946,
                        false => 22947,
                    },
                    false => Waterlogged switch {
                        true => 22948,
                        false => 22949,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22950,
                        false => 22951,
                    },
                    false => Waterlogged switch {
                        true => 22952,
                        false => 22953,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22954,
                        false => 22955,
                    },
                    false => Waterlogged switch {
                        true => 22956,
                        false => 22957,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22942 => new MagentaCandleBlock(Identifier, 1, true, true),
            22943 => new MagentaCandleBlock(Identifier, 1, true, false),
            22944 => new MagentaCandleBlock(Identifier, 1, false, true),
            22945 => new MagentaCandleBlock(Identifier, 1, false, false),
            22946 => new MagentaCandleBlock(Identifier, 2, true, true),
            22947 => new MagentaCandleBlock(Identifier, 2, true, false),
            22948 => new MagentaCandleBlock(Identifier, 2, false, true),
            22949 => new MagentaCandleBlock(Identifier, 2, false, false),
            22950 => new MagentaCandleBlock(Identifier, 3, true, true),
            22951 => new MagentaCandleBlock(Identifier, 3, true, false),
            22952 => new MagentaCandleBlock(Identifier, 3, false, true),
            22953 => new MagentaCandleBlock(Identifier, 3, false, false),
            22954 => new MagentaCandleBlock(Identifier, 4, true, true),
            22955 => new MagentaCandleBlock(Identifier, 4, true, false),
            22956 => new MagentaCandleBlock(Identifier, 4, false, true),
            22957 => new MagentaCandleBlock(Identifier, 4, false, false),
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
