using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WhiteCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 905;
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
    public Identifier? Item => "minecraft:white_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 3;
    public string TranslationKey => "block.minecraft.white_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21801,
                        false => 21802,
                    },
                    false => Waterlogged switch {
                        true => 21803,
                        false => 21804,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21805,
                        false => 21806,
                    },
                    false => Waterlogged switch {
                        true => 21807,
                        false => 21808,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21809,
                        false => 21810,
                    },
                    false => Waterlogged switch {
                        true => 21811,
                        false => 21812,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21813,
                        false => 21814,
                    },
                    false => Waterlogged switch {
                        true => 21815,
                        false => 21816,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21801 => new WhiteCandleBlock(Identifier, 1, true, true),
            21802 => new WhiteCandleBlock(Identifier, 1, true, false),
            21803 => new WhiteCandleBlock(Identifier, 1, false, true),
            21804 => new WhiteCandleBlock(Identifier, 1, false, false),
            21805 => new WhiteCandleBlock(Identifier, 2, true, true),
            21806 => new WhiteCandleBlock(Identifier, 2, true, false),
            21807 => new WhiteCandleBlock(Identifier, 2, false, true),
            21808 => new WhiteCandleBlock(Identifier, 2, false, false),
            21809 => new WhiteCandleBlock(Identifier, 3, true, true),
            21810 => new WhiteCandleBlock(Identifier, 3, true, false),
            21811 => new WhiteCandleBlock(Identifier, 3, false, true),
            21812 => new WhiteCandleBlock(Identifier, 3, false, false),
            21813 => new WhiteCandleBlock(Identifier, 4, true, true),
            21814 => new WhiteCandleBlock(Identifier, 4, true, false),
            21815 => new WhiteCandleBlock(Identifier, 4, false, true),
            21816 => new WhiteCandleBlock(Identifier, 4, false, false),
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
