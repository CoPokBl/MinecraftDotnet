using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record JungleSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 214;
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
    public Identifier? Item => "minecraft:jungle_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 10;
    public string TranslationKey => "block.minecraft.jungle_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5294,
                    false => 5295,
                },
                1 => Waterlogged switch {
                    true => 5296,
                    false => 5297,
                },
                2 => Waterlogged switch {
                    true => 5298,
                    false => 5299,
                },
                3 => Waterlogged switch {
                    true => 5300,
                    false => 5301,
                },
                4 => Waterlogged switch {
                    true => 5302,
                    false => 5303,
                },
                5 => Waterlogged switch {
                    true => 5304,
                    false => 5305,
                },
                6 => Waterlogged switch {
                    true => 5306,
                    false => 5307,
                },
                7 => Waterlogged switch {
                    true => 5308,
                    false => 5309,
                },
                8 => Waterlogged switch {
                    true => 5310,
                    false => 5311,
                },
                9 => Waterlogged switch {
                    true => 5312,
                    false => 5313,
                },
                10 => Waterlogged switch {
                    true => 5314,
                    false => 5315,
                },
                11 => Waterlogged switch {
                    true => 5316,
                    false => 5317,
                },
                12 => Waterlogged switch {
                    true => 5318,
                    false => 5319,
                },
                13 => Waterlogged switch {
                    true => 5320,
                    false => 5321,
                },
                14 => Waterlogged switch {
                    true => 5322,
                    false => 5323,
                },
                15 => Waterlogged switch {
                    true => 5324,
                    false => 5325,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5294 => new JungleSignBlock(Identifier, 0, true),
            5295 => new JungleSignBlock(Identifier, 0, false),
            5296 => new JungleSignBlock(Identifier, 1, true),
            5297 => new JungleSignBlock(Identifier, 1, false),
            5298 => new JungleSignBlock(Identifier, 2, true),
            5299 => new JungleSignBlock(Identifier, 2, false),
            5300 => new JungleSignBlock(Identifier, 3, true),
            5301 => new JungleSignBlock(Identifier, 3, false),
            5302 => new JungleSignBlock(Identifier, 4, true),
            5303 => new JungleSignBlock(Identifier, 4, false),
            5304 => new JungleSignBlock(Identifier, 5, true),
            5305 => new JungleSignBlock(Identifier, 5, false),
            5306 => new JungleSignBlock(Identifier, 6, true),
            5307 => new JungleSignBlock(Identifier, 6, false),
            5308 => new JungleSignBlock(Identifier, 7, true),
            5309 => new JungleSignBlock(Identifier, 7, false),
            5310 => new JungleSignBlock(Identifier, 8, true),
            5311 => new JungleSignBlock(Identifier, 8, false),
            5312 => new JungleSignBlock(Identifier, 9, true),
            5313 => new JungleSignBlock(Identifier, 9, false),
            5314 => new JungleSignBlock(Identifier, 10, true),
            5315 => new JungleSignBlock(Identifier, 10, false),
            5316 => new JungleSignBlock(Identifier, 11, true),
            5317 => new JungleSignBlock(Identifier, 11, false),
            5318 => new JungleSignBlock(Identifier, 12, true),
            5319 => new JungleSignBlock(Identifier, 12, false),
            5320 => new JungleSignBlock(Identifier, 13, true),
            5321 => new JungleSignBlock(Identifier, 13, false),
            5322 => new JungleSignBlock(Identifier, 14, true),
            5323 => new JungleSignBlock(Identifier, 14, false),
            5324 => new JungleSignBlock(Identifier, 15, true),
            5325 => new JungleSignBlock(Identifier, 15, false),
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
