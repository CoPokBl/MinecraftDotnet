using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
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
    public Identifier? Item => "minecraft:blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 25;
    public string TranslationKey => "block.minecraft.blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21977,
                        false => 21978,
                    },
                    false => Waterlogged switch {
                        true => 21979,
                        false => 21980,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21981,
                        false => 21982,
                    },
                    false => Waterlogged switch {
                        true => 21983,
                        false => 21984,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21985,
                        false => 21986,
                    },
                    false => Waterlogged switch {
                        true => 21987,
                        false => 21988,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21989,
                        false => 21990,
                    },
                    false => Waterlogged switch {
                        true => 21991,
                        false => 21992,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21977 => new BlueCandleBlock(Identifier, 1, true, true),
            21978 => new BlueCandleBlock(Identifier, 1, true, false),
            21979 => new BlueCandleBlock(Identifier, 1, false, true),
            21980 => new BlueCandleBlock(Identifier, 1, false, false),
            21981 => new BlueCandleBlock(Identifier, 2, true, true),
            21982 => new BlueCandleBlock(Identifier, 2, true, false),
            21983 => new BlueCandleBlock(Identifier, 2, false, true),
            21984 => new BlueCandleBlock(Identifier, 2, false, false),
            21985 => new BlueCandleBlock(Identifier, 3, true, true),
            21986 => new BlueCandleBlock(Identifier, 3, true, false),
            21987 => new BlueCandleBlock(Identifier, 3, false, true),
            21988 => new BlueCandleBlock(Identifier, 3, false, false),
            21989 => new BlueCandleBlock(Identifier, 4, true, true),
            21990 => new BlueCandleBlock(Identifier, 4, true, false),
            21991 => new BlueCandleBlock(Identifier, 4, false, true),
            21992 => new BlueCandleBlock(Identifier, 4, false, false),
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
    
}
