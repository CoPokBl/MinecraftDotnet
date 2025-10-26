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
    public int ProtocolId => 949;
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
                        true => 23006,
                        false => 23007,
                    },
                    false => Waterlogged switch {
                        true => 23008,
                        false => 23009,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23010,
                        false => 23011,
                    },
                    false => Waterlogged switch {
                        true => 23012,
                        false => 23013,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23014,
                        false => 23015,
                    },
                    false => Waterlogged switch {
                        true => 23016,
                        false => 23017,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23018,
                        false => 23019,
                    },
                    false => Waterlogged switch {
                        true => 23020,
                        false => 23021,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23006 => new PinkCandleBlock(Identifier, 1, true, true),
            23007 => new PinkCandleBlock(Identifier, 1, true, false),
            23008 => new PinkCandleBlock(Identifier, 1, false, true),
            23009 => new PinkCandleBlock(Identifier, 1, false, false),
            23010 => new PinkCandleBlock(Identifier, 2, true, true),
            23011 => new PinkCandleBlock(Identifier, 2, true, false),
            23012 => new PinkCandleBlock(Identifier, 2, false, true),
            23013 => new PinkCandleBlock(Identifier, 2, false, false),
            23014 => new PinkCandleBlock(Identifier, 3, true, true),
            23015 => new PinkCandleBlock(Identifier, 3, true, false),
            23016 => new PinkCandleBlock(Identifier, 3, false, true),
            23017 => new PinkCandleBlock(Identifier, 3, false, false),
            23018 => new PinkCandleBlock(Identifier, 4, true, true),
            23019 => new PinkCandleBlock(Identifier, 4, true, false),
            23020 => new PinkCandleBlock(Identifier, 4, false, true),
            23021 => new PinkCandleBlock(Identifier, 4, false, false),
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
