using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GreenCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 918;
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
    public Identifier? Item => "minecraft:green_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 27;
    public string TranslationKey => "block.minecraft.green_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22009,
                        false => 22010,
                    },
                    false => Waterlogged switch {
                        true => 22011,
                        false => 22012,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22013,
                        false => 22014,
                    },
                    false => Waterlogged switch {
                        true => 22015,
                        false => 22016,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22017,
                        false => 22018,
                    },
                    false => Waterlogged switch {
                        true => 22019,
                        false => 22020,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22021,
                        false => 22022,
                    },
                    false => Waterlogged switch {
                        true => 22023,
                        false => 22024,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22009 => new GreenCandleBlock(Identifier, 1, true, true),
            22010 => new GreenCandleBlock(Identifier, 1, true, false),
            22011 => new GreenCandleBlock(Identifier, 1, false, true),
            22012 => new GreenCandleBlock(Identifier, 1, false, false),
            22013 => new GreenCandleBlock(Identifier, 2, true, true),
            22014 => new GreenCandleBlock(Identifier, 2, true, false),
            22015 => new GreenCandleBlock(Identifier, 2, false, true),
            22016 => new GreenCandleBlock(Identifier, 2, false, false),
            22017 => new GreenCandleBlock(Identifier, 3, true, true),
            22018 => new GreenCandleBlock(Identifier, 3, true, false),
            22019 => new GreenCandleBlock(Identifier, 3, false, true),
            22020 => new GreenCandleBlock(Identifier, 3, false, false),
            22021 => new GreenCandleBlock(Identifier, 4, true, true),
            22022 => new GreenCandleBlock(Identifier, 4, true, false),
            22023 => new GreenCandleBlock(Identifier, 4, false, true),
            22024 => new GreenCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = int.Parse(properties["candles"].GetString()),
            Lit = properties["lit"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
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
