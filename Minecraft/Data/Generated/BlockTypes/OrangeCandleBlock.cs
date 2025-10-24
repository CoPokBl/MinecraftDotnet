using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 944;
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
    public Identifier? Item => "minecraft:orange_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.orange_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22926,
                        false => 22927,
                    },
                    false => Waterlogged switch {
                        true => 22928,
                        false => 22929,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22930,
                        false => 22931,
                    },
                    false => Waterlogged switch {
                        true => 22932,
                        false => 22933,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22934,
                        false => 22935,
                    },
                    false => Waterlogged switch {
                        true => 22936,
                        false => 22937,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22938,
                        false => 22939,
                    },
                    false => Waterlogged switch {
                        true => 22940,
                        false => 22941,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22926 => new OrangeCandleBlock(Identifier, 1, true, true),
            22927 => new OrangeCandleBlock(Identifier, 1, true, false),
            22928 => new OrangeCandleBlock(Identifier, 1, false, true),
            22929 => new OrangeCandleBlock(Identifier, 1, false, false),
            22930 => new OrangeCandleBlock(Identifier, 2, true, true),
            22931 => new OrangeCandleBlock(Identifier, 2, true, false),
            22932 => new OrangeCandleBlock(Identifier, 2, false, true),
            22933 => new OrangeCandleBlock(Identifier, 2, false, false),
            22934 => new OrangeCandleBlock(Identifier, 3, true, true),
            22935 => new OrangeCandleBlock(Identifier, 3, true, false),
            22936 => new OrangeCandleBlock(Identifier, 3, false, true),
            22937 => new OrangeCandleBlock(Identifier, 3, false, false),
            22938 => new OrangeCandleBlock(Identifier, 4, true, true),
            22939 => new OrangeCandleBlock(Identifier, 4, true, false),
            22940 => new OrangeCandleBlock(Identifier, 4, false, true),
            22941 => new OrangeCandleBlock(Identifier, 4, false, false),
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
