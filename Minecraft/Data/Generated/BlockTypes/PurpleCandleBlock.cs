using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PurpleCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 915;
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
    public Identifier? Item => "minecraft:purple_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 24;
    public string TranslationKey => "block.minecraft.purple_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 21961,
                        false => 21962,
                    },
                    false => Waterlogged switch {
                        true => 21963,
                        false => 21964,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 21965,
                        false => 21966,
                    },
                    false => Waterlogged switch {
                        true => 21967,
                        false => 21968,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 21969,
                        false => 21970,
                    },
                    false => Waterlogged switch {
                        true => 21971,
                        false => 21972,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 21973,
                        false => 21974,
                    },
                    false => Waterlogged switch {
                        true => 21975,
                        false => 21976,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21961 => new PurpleCandleBlock(Identifier, 1, true, true),
            21962 => new PurpleCandleBlock(Identifier, 1, true, false),
            21963 => new PurpleCandleBlock(Identifier, 1, false, true),
            21964 => new PurpleCandleBlock(Identifier, 1, false, false),
            21965 => new PurpleCandleBlock(Identifier, 2, true, true),
            21966 => new PurpleCandleBlock(Identifier, 2, true, false),
            21967 => new PurpleCandleBlock(Identifier, 2, false, true),
            21968 => new PurpleCandleBlock(Identifier, 2, false, false),
            21969 => new PurpleCandleBlock(Identifier, 3, true, true),
            21970 => new PurpleCandleBlock(Identifier, 3, true, false),
            21971 => new PurpleCandleBlock(Identifier, 3, false, true),
            21972 => new PurpleCandleBlock(Identifier, 3, false, false),
            21973 => new PurpleCandleBlock(Identifier, 4, true, true),
            21974 => new PurpleCandleBlock(Identifier, 4, true, false),
            21975 => new PurpleCandleBlock(Identifier, 4, false, true),
            21976 => new PurpleCandleBlock(Identifier, 4, false, false),
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
