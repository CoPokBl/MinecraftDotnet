using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RedCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:red_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.red_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22025,
                        false => 22026,
                    },
                    false => Waterlogged switch {
                        true => 22027,
                        false => 22028,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22029,
                        false => 22030,
                    },
                    false => Waterlogged switch {
                        true => 22031,
                        false => 22032,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22033,
                        false => 22034,
                    },
                    false => Waterlogged switch {
                        true => 22035,
                        false => 22036,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22037,
                        false => 22038,
                    },
                    false => Waterlogged switch {
                        true => 22039,
                        false => 22040,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22025 => new RedCandleBlock(Identifier, 1, true, true),
            22026 => new RedCandleBlock(Identifier, 1, true, false),
            22027 => new RedCandleBlock(Identifier, 1, false, true),
            22028 => new RedCandleBlock(Identifier, 1, false, false),
            22029 => new RedCandleBlock(Identifier, 2, true, true),
            22030 => new RedCandleBlock(Identifier, 2, true, false),
            22031 => new RedCandleBlock(Identifier, 2, false, true),
            22032 => new RedCandleBlock(Identifier, 2, false, false),
            22033 => new RedCandleBlock(Identifier, 3, true, true),
            22034 => new RedCandleBlock(Identifier, 3, true, false),
            22035 => new RedCandleBlock(Identifier, 3, false, true),
            22036 => new RedCandleBlock(Identifier, 3, false, false),
            22037 => new RedCandleBlock(Identifier, 4, true, true),
            22038 => new RedCandleBlock(Identifier, 4, true, false),
            22039 => new RedCandleBlock(Identifier, 4, false, true),
            22040 => new RedCandleBlock(Identifier, 4, false, false),
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
