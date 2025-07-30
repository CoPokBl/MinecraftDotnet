using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BlackCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 920;
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
    public Identifier? Item => "minecraft:black_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.black_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 22041,
                        false => 22042,
                    },
                    false => Waterlogged switch {
                        true => 22043,
                        false => 22044,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 22045,
                        false => 22046,
                    },
                    false => Waterlogged switch {
                        true => 22047,
                        false => 22048,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 22049,
                        false => 22050,
                    },
                    false => Waterlogged switch {
                        true => 22051,
                        false => 22052,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 22053,
                        false => 22054,
                    },
                    false => Waterlogged switch {
                        true => 22055,
                        false => 22056,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            22041 => new BlackCandleBlock(Identifier, 1, true, true),
            22042 => new BlackCandleBlock(Identifier, 1, true, false),
            22043 => new BlackCandleBlock(Identifier, 1, false, true),
            22044 => new BlackCandleBlock(Identifier, 1, false, false),
            22045 => new BlackCandleBlock(Identifier, 2, true, true),
            22046 => new BlackCandleBlock(Identifier, 2, true, false),
            22047 => new BlackCandleBlock(Identifier, 2, false, true),
            22048 => new BlackCandleBlock(Identifier, 2, false, false),
            22049 => new BlackCandleBlock(Identifier, 3, true, true),
            22050 => new BlackCandleBlock(Identifier, 3, true, false),
            22051 => new BlackCandleBlock(Identifier, 3, false, true),
            22052 => new BlackCandleBlock(Identifier, 3, false, false),
            22053 => new BlackCandleBlock(Identifier, 4, true, true),
            22054 => new BlackCandleBlock(Identifier, 4, true, false),
            22055 => new BlackCandleBlock(Identifier, 4, false, true),
            22056 => new BlackCandleBlock(Identifier, 4, false, false),
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
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("candles", Candles.ToString()),
            new StringTag("lit", Lit.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
