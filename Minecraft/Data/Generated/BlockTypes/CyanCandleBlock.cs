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
                        true => 21945,
                        false => 21946,
                    },
                    false => Waterlogged switch {
                        true => 21947,
                        false => 21948,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21949,
                        false => 21950,
                    },
                    false => Waterlogged switch {
                        true => 21951,
                        false => 21952,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21953,
                        false => 21954,
                    },
                    false => Waterlogged switch {
                        true => 21955,
                        false => 21956,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21957,
                        false => 21958,
                    },
                    false => Waterlogged switch {
                        true => 21959,
                        false => 21960,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21945 => new CyanCandleBlock(Identifier, 1, true, true),
            21946 => new CyanCandleBlock(Identifier, 1, true, false),
            21947 => new CyanCandleBlock(Identifier, 1, false, true),
            21948 => new CyanCandleBlock(Identifier, 1, false, false),
            21949 => new CyanCandleBlock(Identifier, 2, true, true),
            21950 => new CyanCandleBlock(Identifier, 2, true, false),
            21951 => new CyanCandleBlock(Identifier, 2, false, true),
            21952 => new CyanCandleBlock(Identifier, 2, false, false),
            21953 => new CyanCandleBlock(Identifier, 3, true, true),
            21954 => new CyanCandleBlock(Identifier, 3, true, false),
            21955 => new CyanCandleBlock(Identifier, 3, false, true),
            21956 => new CyanCandleBlock(Identifier, 3, false, false),
            21957 => new CyanCandleBlock(Identifier, 4, true, true),
            21958 => new CyanCandleBlock(Identifier, 4, true, false),
            21959 => new CyanCandleBlock(Identifier, 4, false, true),
            21960 => new CyanCandleBlock(Identifier, 4, false, false),
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
