using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record AcaciaSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 212;
    public double Hardness => 1;
    public double ExplosionResistance => 1;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:acacia_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 15;
    public string TranslationKey => "block.minecraft.acacia_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5230,
                    false => 5231,
                },
                1 => Waterlogged switch {
                    true => 5232,
                    false => 5233,
                },
                2 => Waterlogged switch {
                    true => 5234,
                    false => 5235,
                },
                3 => Waterlogged switch {
                    true => 5236,
                    false => 5237,
                },
                4 => Waterlogged switch {
                    true => 5238,
                    false => 5239,
                },
                5 => Waterlogged switch {
                    true => 5240,
                    false => 5241,
                },
                6 => Waterlogged switch {
                    true => 5242,
                    false => 5243,
                },
                7 => Waterlogged switch {
                    true => 5244,
                    false => 5245,
                },
                8 => Waterlogged switch {
                    true => 5246,
                    false => 5247,
                },
                9 => Waterlogged switch {
                    true => 5248,
                    false => 5249,
                },
                10 => Waterlogged switch {
                    true => 5250,
                    false => 5251,
                },
                11 => Waterlogged switch {
                    true => 5252,
                    false => 5253,
                },
                12 => Waterlogged switch {
                    true => 5254,
                    false => 5255,
                },
                13 => Waterlogged switch {
                    true => 5256,
                    false => 5257,
                },
                14 => Waterlogged switch {
                    true => 5258,
                    false => 5259,
                },
                15 => Waterlogged switch {
                    true => 5260,
                    false => 5261,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5230 => new AcaciaSignBlock(Identifier, 0, true),
            5231 => new AcaciaSignBlock(Identifier, 0, false),
            5232 => new AcaciaSignBlock(Identifier, 1, true),
            5233 => new AcaciaSignBlock(Identifier, 1, false),
            5234 => new AcaciaSignBlock(Identifier, 2, true),
            5235 => new AcaciaSignBlock(Identifier, 2, false),
            5236 => new AcaciaSignBlock(Identifier, 3, true),
            5237 => new AcaciaSignBlock(Identifier, 3, false),
            5238 => new AcaciaSignBlock(Identifier, 4, true),
            5239 => new AcaciaSignBlock(Identifier, 4, false),
            5240 => new AcaciaSignBlock(Identifier, 5, true),
            5241 => new AcaciaSignBlock(Identifier, 5, false),
            5242 => new AcaciaSignBlock(Identifier, 6, true),
            5243 => new AcaciaSignBlock(Identifier, 6, false),
            5244 => new AcaciaSignBlock(Identifier, 7, true),
            5245 => new AcaciaSignBlock(Identifier, 7, false),
            5246 => new AcaciaSignBlock(Identifier, 8, true),
            5247 => new AcaciaSignBlock(Identifier, 8, false),
            5248 => new AcaciaSignBlock(Identifier, 9, true),
            5249 => new AcaciaSignBlock(Identifier, 9, false),
            5250 => new AcaciaSignBlock(Identifier, 10, true),
            5251 => new AcaciaSignBlock(Identifier, 10, false),
            5252 => new AcaciaSignBlock(Identifier, 11, true),
            5253 => new AcaciaSignBlock(Identifier, 11, false),
            5254 => new AcaciaSignBlock(Identifier, 12, true),
            5255 => new AcaciaSignBlock(Identifier, 12, false),
            5256 => new AcaciaSignBlock(Identifier, 13, true),
            5257 => new AcaciaSignBlock(Identifier, 13, false),
            5258 => new AcaciaSignBlock(Identifier, 14, true),
            5259 => new AcaciaSignBlock(Identifier, 14, false),
            5260 => new AcaciaSignBlock(Identifier, 15, true),
            5261 => new AcaciaSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.ChildrenMap.ContainsKey("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.ChildrenMap.ContainsKey("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
