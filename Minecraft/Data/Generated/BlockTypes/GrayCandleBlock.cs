using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record GrayCandleBlock(Identifier Identifier, int Candles, bool Lit, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:candle";
    public int ProtocolId => 950;
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
    public Identifier? Item => "minecraft:gray_candle";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.4375, 0.0, 0.4375] -> [0.5625, 0.375, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 21;
    public string TranslationKey => "block.minecraft.gray_candle";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Candles switch {
                1 => Lit switch {
                    true => Waterlogged switch {
                        true => 23022,
                        false => 23023,
                    },
                    false => Waterlogged switch {
                        true => 23024,
                        false => 23025,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23026,
                        false => 23027,
                    },
                    false => Waterlogged switch {
                        true => 23028,
                        false => 23029,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23030,
                        false => 23031,
                    },
                    false => Waterlogged switch {
                        true => 23032,
                        false => 23033,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23034,
                        false => 23035,
                    },
                    false => Waterlogged switch {
                        true => 23036,
                        false => 23037,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23022 => new GrayCandleBlock(Identifier, 1, true, true),
            23023 => new GrayCandleBlock(Identifier, 1, true, false),
            23024 => new GrayCandleBlock(Identifier, 1, false, true),
            23025 => new GrayCandleBlock(Identifier, 1, false, false),
            23026 => new GrayCandleBlock(Identifier, 2, true, true),
            23027 => new GrayCandleBlock(Identifier, 2, true, false),
            23028 => new GrayCandleBlock(Identifier, 2, false, true),
            23029 => new GrayCandleBlock(Identifier, 2, false, false),
            23030 => new GrayCandleBlock(Identifier, 3, true, true),
            23031 => new GrayCandleBlock(Identifier, 3, true, false),
            23032 => new GrayCandleBlock(Identifier, 3, false, true),
            23033 => new GrayCandleBlock(Identifier, 3, false, false),
            23034 => new GrayCandleBlock(Identifier, 4, true, true),
            23035 => new GrayCandleBlock(Identifier, 4, true, false),
            23036 => new GrayCandleBlock(Identifier, 4, false, true),
            23037 => new GrayCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = properties.ChildrenMap.ContainsKey("candles") ? int.Parse(properties["candles"].GetString()) : Candles,
            Lit = properties.ChildrenMap.ContainsKey("lit") ? properties["lit"].GetString() == "true" : Lit,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
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
