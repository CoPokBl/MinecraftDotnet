using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21913,
                        false => 21914,
                    },
                    false => Waterlogged switch {
                        true => 21915,
                        false => 21916,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21917,
                        false => 21918,
                    },
                    false => Waterlogged switch {
                        true => 21919,
                        false => 21920,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21921,
                        false => 21922,
                    },
                    false => Waterlogged switch {
                        true => 21923,
                        false => 21924,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21925,
                        false => 21926,
                    },
                    false => Waterlogged switch {
                        true => 21927,
                        false => 21928,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21913 => new GrayCandleBlock(Identifier, 1, true, true),
            21914 => new GrayCandleBlock(Identifier, 1, true, false),
            21915 => new GrayCandleBlock(Identifier, 1, false, true),
            21916 => new GrayCandleBlock(Identifier, 1, false, false),
            21917 => new GrayCandleBlock(Identifier, 2, true, true),
            21918 => new GrayCandleBlock(Identifier, 2, true, false),
            21919 => new GrayCandleBlock(Identifier, 2, false, true),
            21920 => new GrayCandleBlock(Identifier, 2, false, false),
            21921 => new GrayCandleBlock(Identifier, 3, true, true),
            21922 => new GrayCandleBlock(Identifier, 3, true, false),
            21923 => new GrayCandleBlock(Identifier, 3, false, true),
            21924 => new GrayCandleBlock(Identifier, 3, false, false),
            21925 => new GrayCandleBlock(Identifier, 4, true, true),
            21926 => new GrayCandleBlock(Identifier, 4, true, false),
            21927 => new GrayCandleBlock(Identifier, 4, false, true),
            21928 => new GrayCandleBlock(Identifier, 4, false, false),
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
