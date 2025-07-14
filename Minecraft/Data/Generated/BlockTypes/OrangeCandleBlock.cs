using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record OrangeCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:orange_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.orange_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21817,
                        false => 21818,
                    },
                    false => Waterlogged switch {
                        true => 21819,
                        false => 21820,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21821,
                        false => 21822,
                    },
                    false => Waterlogged switch {
                        true => 21823,
                        false => 21824,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21825,
                        false => 21826,
                    },
                    false => Waterlogged switch {
                        true => 21827,
                        false => 21828,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21829,
                        false => 21830,
                    },
                    false => Waterlogged switch {
                        true => 21831,
                        false => 21832,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21817 => new OrangeCandleBlock(Identifier, 1, true, true),
            21818 => new OrangeCandleBlock(Identifier, 1, true, false),
            21819 => new OrangeCandleBlock(Identifier, 1, false, true),
            21820 => new OrangeCandleBlock(Identifier, 1, false, false),
            21821 => new OrangeCandleBlock(Identifier, 2, true, true),
            21822 => new OrangeCandleBlock(Identifier, 2, true, false),
            21823 => new OrangeCandleBlock(Identifier, 2, false, true),
            21824 => new OrangeCandleBlock(Identifier, 2, false, false),
            21825 => new OrangeCandleBlock(Identifier, 3, true, true),
            21826 => new OrangeCandleBlock(Identifier, 3, true, false),
            21827 => new OrangeCandleBlock(Identifier, 3, false, true),
            21828 => new OrangeCandleBlock(Identifier, 3, false, false),
            21829 => new OrangeCandleBlock(Identifier, 4, true, true),
            21830 => new OrangeCandleBlock(Identifier, 4, true, false),
            21831 => new OrangeCandleBlock(Identifier, 4, false, true),
            21832 => new OrangeCandleBlock(Identifier, 4, false, false),
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
