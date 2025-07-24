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
    public int ProtocolId => 907;
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
                        true => 21833,
                        false => 21834,
                    },
                    false => Waterlogged switch {
                        true => 21835,
                        false => 21836,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21837,
                        false => 21838,
                    },
                    false => Waterlogged switch {
                        true => 21839,
                        false => 21840,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21841,
                        false => 21842,
                    },
                    false => Waterlogged switch {
                        true => 21843,
                        false => 21844,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21845,
                        false => 21846,
                    },
                    false => Waterlogged switch {
                        true => 21847,
                        false => 21848,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21833 => new MagentaCandleBlock(Identifier, 1, true, true),
            21834 => new MagentaCandleBlock(Identifier, 1, true, false),
            21835 => new MagentaCandleBlock(Identifier, 1, false, true),
            21836 => new MagentaCandleBlock(Identifier, 1, false, false),
            21837 => new MagentaCandleBlock(Identifier, 2, true, true),
            21838 => new MagentaCandleBlock(Identifier, 2, true, false),
            21839 => new MagentaCandleBlock(Identifier, 2, false, true),
            21840 => new MagentaCandleBlock(Identifier, 2, false, false),
            21841 => new MagentaCandleBlock(Identifier, 3, true, true),
            21842 => new MagentaCandleBlock(Identifier, 3, true, false),
            21843 => new MagentaCandleBlock(Identifier, 3, false, true),
            21844 => new MagentaCandleBlock(Identifier, 3, false, false),
            21845 => new MagentaCandleBlock(Identifier, 4, true, true),
            21846 => new MagentaCandleBlock(Identifier, 4, true, false),
            21847 => new MagentaCandleBlock(Identifier, 4, false, true),
            21848 => new MagentaCandleBlock(Identifier, 4, false, false),
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
