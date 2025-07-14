using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrownCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:brown_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.brown_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21993,
                        false => 21994,
                    },
                    false => Waterlogged switch {
                        true => 21995,
                        false => 21996,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21997,
                        false => 21998,
                    },
                    false => Waterlogged switch {
                        true => 21999,
                        false => 22000,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22001,
                        false => 22002,
                    },
                    false => Waterlogged switch {
                        true => 22003,
                        false => 22004,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22005,
                        false => 22006,
                    },
                    false => Waterlogged switch {
                        true => 22007,
                        false => 22008,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21993 => new BrownCandleBlock(Identifier, 1, true, true),
            21994 => new BrownCandleBlock(Identifier, 1, true, false),
            21995 => new BrownCandleBlock(Identifier, 1, false, true),
            21996 => new BrownCandleBlock(Identifier, 1, false, false),
            21997 => new BrownCandleBlock(Identifier, 2, true, true),
            21998 => new BrownCandleBlock(Identifier, 2, true, false),
            21999 => new BrownCandleBlock(Identifier, 2, false, true),
            22000 => new BrownCandleBlock(Identifier, 2, false, false),
            22001 => new BrownCandleBlock(Identifier, 3, true, true),
            22002 => new BrownCandleBlock(Identifier, 3, true, false),
            22003 => new BrownCandleBlock(Identifier, 3, false, true),
            22004 => new BrownCandleBlock(Identifier, 3, false, false),
            22005 => new BrownCandleBlock(Identifier, 4, true, true),
            22006 => new BrownCandleBlock(Identifier, 4, true, false),
            22007 => new BrownCandleBlock(Identifier, 4, false, true),
            22008 => new BrownCandleBlock(Identifier, 4, false, false),
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
