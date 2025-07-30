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

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 904;
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
                        true => 21785,
                        false => 21786,
                    },
                    false => Waterlogged switch {
                        true => 21787,
                        false => 21788,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21789,
                        false => 21790,
                    },
                    false => Waterlogged switch {
                        true => 21791,
                        false => 21792,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21793,
                        false => 21794,
                    },
                    false => Waterlogged switch {
                        true => 21795,
                        false => 21796,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21797,
                        false => 21798,
                    },
                    false => Waterlogged switch {
                        true => 21799,
                        false => 21800,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21785 => new CandleBlock(Identifier, 1, true, true),
            21786 => new CandleBlock(Identifier, 1, true, false),
            21787 => new CandleBlock(Identifier, 1, false, true),
            21788 => new CandleBlock(Identifier, 1, false, false),
            21789 => new CandleBlock(Identifier, 2, true, true),
            21790 => new CandleBlock(Identifier, 2, true, false),
            21791 => new CandleBlock(Identifier, 2, false, true),
            21792 => new CandleBlock(Identifier, 2, false, false),
            21793 => new CandleBlock(Identifier, 3, true, true),
            21794 => new CandleBlock(Identifier, 3, true, false),
            21795 => new CandleBlock(Identifier, 3, false, true),
            21796 => new CandleBlock(Identifier, 3, false, false),
            21797 => new CandleBlock(Identifier, 4, true, true),
            21798 => new CandleBlock(Identifier, 4, true, false),
            21799 => new CandleBlock(Identifier, 4, false, true),
            21800 => new CandleBlock(Identifier, 4, false, false),
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
