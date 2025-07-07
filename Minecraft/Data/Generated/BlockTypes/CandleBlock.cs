using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 2;
    public string TranslationKey => "block.minecraft.candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21753,
                        false => 21754,
                    },
                    false => Waterlogged switch {
                        true => 21755,
                        false => 21756,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21757,
                        false => 21758,
                    },
                    false => Waterlogged switch {
                        true => 21759,
                        false => 21760,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21761,
                        false => 21762,
                    },
                    false => Waterlogged switch {
                        true => 21763,
                        false => 21764,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21765,
                        false => 21766,
                    },
                    false => Waterlogged switch {
                        true => 21767,
                        false => 21768,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21753 => new CandleBlock(Identifier, 1, true, true),
            21754 => new CandleBlock(Identifier, 1, true, false),
            21755 => new CandleBlock(Identifier, 1, false, true),
            21756 => new CandleBlock(Identifier, 1, false, false),
            21757 => new CandleBlock(Identifier, 2, true, true),
            21758 => new CandleBlock(Identifier, 2, true, false),
            21759 => new CandleBlock(Identifier, 2, false, true),
            21760 => new CandleBlock(Identifier, 2, false, false),
            21761 => new CandleBlock(Identifier, 3, true, true),
            21762 => new CandleBlock(Identifier, 3, true, false),
            21763 => new CandleBlock(Identifier, 3, false, true),
            21764 => new CandleBlock(Identifier, 3, false, false),
            21765 => new CandleBlock(Identifier, 4, true, true),
            21766 => new CandleBlock(Identifier, 4, true, false),
            21767 => new CandleBlock(Identifier, 4, false, true),
            21768 => new CandleBlock(Identifier, 4, false, false),
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
