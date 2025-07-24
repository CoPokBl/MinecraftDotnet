using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record LightBlueCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 908;
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
    public Identifier? Item => "minecraft:light_blue_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 17;
    public string TranslationKey => "block.minecraft.light_blue_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21849,
                        false => 21850,
                    },
                    false => Waterlogged switch {
                        true => 21851,
                        false => 21852,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21853,
                        false => 21854,
                    },
                    false => Waterlogged switch {
                        true => 21855,
                        false => 21856,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21857,
                        false => 21858,
                    },
                    false => Waterlogged switch {
                        true => 21859,
                        false => 21860,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21861,
                        false => 21862,
                    },
                    false => Waterlogged switch {
                        true => 21863,
                        false => 21864,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21849 => new LightBlueCandleBlock(Identifier, 1, true, true),
            21850 => new LightBlueCandleBlock(Identifier, 1, true, false),
            21851 => new LightBlueCandleBlock(Identifier, 1, false, true),
            21852 => new LightBlueCandleBlock(Identifier, 1, false, false),
            21853 => new LightBlueCandleBlock(Identifier, 2, true, true),
            21854 => new LightBlueCandleBlock(Identifier, 2, true, false),
            21855 => new LightBlueCandleBlock(Identifier, 2, false, true),
            21856 => new LightBlueCandleBlock(Identifier, 2, false, false),
            21857 => new LightBlueCandleBlock(Identifier, 3, true, true),
            21858 => new LightBlueCandleBlock(Identifier, 3, true, false),
            21859 => new LightBlueCandleBlock(Identifier, 3, false, true),
            21860 => new LightBlueCandleBlock(Identifier, 3, false, false),
            21861 => new LightBlueCandleBlock(Identifier, 4, true, true),
            21862 => new LightBlueCandleBlock(Identifier, 4, true, false),
            21863 => new LightBlueCandleBlock(Identifier, 4, false, true),
            21864 => new LightBlueCandleBlock(Identifier, 4, false, false),
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
