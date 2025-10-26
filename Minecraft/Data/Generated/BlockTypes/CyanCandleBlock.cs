using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CyanCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 952;
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
    public Identifier? Item => "minecraft:cyan_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 23;
    public string TranslationKey => "block.minecraft.cyan_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23054,
                        false => 23055,
                    },
                    false => Waterlogged switch {
                        true => 23056,
                        false => 23057,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23058,
                        false => 23059,
                    },
                    false => Waterlogged switch {
                        true => 23060,
                        false => 23061,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23062,
                        false => 23063,
                    },
                    false => Waterlogged switch {
                        true => 23064,
                        false => 23065,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23066,
                        false => 23067,
                    },
                    false => Waterlogged switch {
                        true => 23068,
                        false => 23069,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23054 => new CyanCandleBlock(Identifier, 1, true, true),
            23055 => new CyanCandleBlock(Identifier, 1, true, false),
            23056 => new CyanCandleBlock(Identifier, 1, false, true),
            23057 => new CyanCandleBlock(Identifier, 1, false, false),
            23058 => new CyanCandleBlock(Identifier, 2, true, true),
            23059 => new CyanCandleBlock(Identifier, 2, true, false),
            23060 => new CyanCandleBlock(Identifier, 2, false, true),
            23061 => new CyanCandleBlock(Identifier, 2, false, false),
            23062 => new CyanCandleBlock(Identifier, 3, true, true),
            23063 => new CyanCandleBlock(Identifier, 3, true, false),
            23064 => new CyanCandleBlock(Identifier, 3, false, true),
            23065 => new CyanCandleBlock(Identifier, 3, false, false),
            23066 => new CyanCandleBlock(Identifier, 4, true, true),
            23067 => new CyanCandleBlock(Identifier, 4, true, false),
            23068 => new CyanCandleBlock(Identifier, 4, false, true),
            23069 => new CyanCandleBlock(Identifier, 4, false, false),
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
