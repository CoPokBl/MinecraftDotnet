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
                        true => 23336,
                        false => 23337,
                    },
                    false => Waterlogged switch {
                        true => 23338,
                        false => 23339,
                    },
                },
                2 => Lit switch {
                    true => Waterlogged switch {
                        true => 23340,
                        false => 23341,
                    },
                    false => Waterlogged switch {
                        true => 23342,
                        false => 23343,
                    },
                },
                3 => Lit switch {
                    true => Waterlogged switch {
                        true => 23344,
                        false => 23345,
                    },
                    false => Waterlogged switch {
                        true => 23346,
                        false => 23347,
                    },
                },
                4 => Lit switch {
                    true => Waterlogged switch {
                        true => 23348,
                        false => 23349,
                    },
                    false => Waterlogged switch {
                        true => 23350,
                        false => 23351,
                    },
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Candles), Candles, "Unknown value for property candles.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23336 => new RedCandleBlock(Identifier, 1, true, true),
            23337 => new RedCandleBlock(Identifier, 1, true, false),
            23338 => new RedCandleBlock(Identifier, 1, false, true),
            23339 => new RedCandleBlock(Identifier, 1, false, false),
            23340 => new RedCandleBlock(Identifier, 2, true, true),
            23341 => new RedCandleBlock(Identifier, 2, true, false),
            23342 => new RedCandleBlock(Identifier, 2, false, true),
            23343 => new RedCandleBlock(Identifier, 2, false, false),
            23344 => new RedCandleBlock(Identifier, 3, true, true),
            23345 => new RedCandleBlock(Identifier, 3, true, false),
            23346 => new RedCandleBlock(Identifier, 3, false, true),
            23347 => new RedCandleBlock(Identifier, 3, false, false),
            23348 => new RedCandleBlock(Identifier, 4, true, true),
            23349 => new RedCandleBlock(Identifier, 4, true, false),
            23350 => new RedCandleBlock(Identifier, 4, false, true),
            23351 => new RedCandleBlock(Identifier, 4, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Candles = properties.Contains("candles") ? int.Parse(properties["candles"].GetString()) : Candles,
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("candles", new StringTag(Candles.ToString())),
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
