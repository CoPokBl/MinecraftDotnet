using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightGrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:light_gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.light_gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21929,
                        false => 21930,
                    },
                    false => Waterlogged switch {
                        true => 21931,
                        false => 21932,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21933,
                        false => 21934,
                    },
                    false => Waterlogged switch {
                        true => 21935,
                        false => 21936,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21937,
                        false => 21938,
                    },
                    false => Waterlogged switch {
                        true => 21939,
                        false => 21940,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21941,
                        false => 21942,
                    },
                    false => Waterlogged switch {
                        true => 21943,
                        false => 21944,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21929 => new LightGrayCandleBlock(Identifier, 1, true, true),
            21930 => new LightGrayCandleBlock(Identifier, 1, true, false),
            21931 => new LightGrayCandleBlock(Identifier, 1, false, true),
            21932 => new LightGrayCandleBlock(Identifier, 1, false, false),
            21933 => new LightGrayCandleBlock(Identifier, 2, true, true),
            21934 => new LightGrayCandleBlock(Identifier, 2, true, false),
            21935 => new LightGrayCandleBlock(Identifier, 2, false, true),
            21936 => new LightGrayCandleBlock(Identifier, 2, false, false),
            21937 => new LightGrayCandleBlock(Identifier, 3, true, true),
            21938 => new LightGrayCandleBlock(Identifier, 3, true, false),
            21939 => new LightGrayCandleBlock(Identifier, 3, false, true),
            21940 => new LightGrayCandleBlock(Identifier, 3, false, false),
            21941 => new LightGrayCandleBlock(Identifier, 4, true, true),
            21942 => new LightGrayCandleBlock(Identifier, 4, true, false),
            21943 => new LightGrayCandleBlock(Identifier, 4, false, true),
            21944 => new LightGrayCandleBlock(Identifier, 4, false, false),
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
