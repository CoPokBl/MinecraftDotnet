using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record MangroveSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 217;
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
    public Identifier? Item => "minecraft:mangrove_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 28;
    public string TranslationKey => "block.minecraft.mangrove_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5390,
                    false => 5391,
                },
                1 => Waterlogged switch {
                    true => 5392,
                    false => 5393,
                },
                2 => Waterlogged switch {
                    true => 5394,
                    false => 5395,
                },
                3 => Waterlogged switch {
                    true => 5396,
                    false => 5397,
                },
                4 => Waterlogged switch {
                    true => 5398,
                    false => 5399,
                },
                5 => Waterlogged switch {
                    true => 5400,
                    false => 5401,
                },
                6 => Waterlogged switch {
                    true => 5402,
                    false => 5403,
                },
                7 => Waterlogged switch {
                    true => 5404,
                    false => 5405,
                },
                8 => Waterlogged switch {
                    true => 5406,
                    false => 5407,
                },
                9 => Waterlogged switch {
                    true => 5408,
                    false => 5409,
                },
                10 => Waterlogged switch {
                    true => 5410,
                    false => 5411,
                },
                11 => Waterlogged switch {
                    true => 5412,
                    false => 5413,
                },
                12 => Waterlogged switch {
                    true => 5414,
                    false => 5415,
                },
                13 => Waterlogged switch {
                    true => 5416,
                    false => 5417,
                },
                14 => Waterlogged switch {
                    true => 5418,
                    false => 5419,
                },
                15 => Waterlogged switch {
                    true => 5420,
                    false => 5421,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5390 => new MangroveSignBlock(Identifier, 0, true),
            5391 => new MangroveSignBlock(Identifier, 0, false),
            5392 => new MangroveSignBlock(Identifier, 1, true),
            5393 => new MangroveSignBlock(Identifier, 1, false),
            5394 => new MangroveSignBlock(Identifier, 2, true),
            5395 => new MangroveSignBlock(Identifier, 2, false),
            5396 => new MangroveSignBlock(Identifier, 3, true),
            5397 => new MangroveSignBlock(Identifier, 3, false),
            5398 => new MangroveSignBlock(Identifier, 4, true),
            5399 => new MangroveSignBlock(Identifier, 4, false),
            5400 => new MangroveSignBlock(Identifier, 5, true),
            5401 => new MangroveSignBlock(Identifier, 5, false),
            5402 => new MangroveSignBlock(Identifier, 6, true),
            5403 => new MangroveSignBlock(Identifier, 6, false),
            5404 => new MangroveSignBlock(Identifier, 7, true),
            5405 => new MangroveSignBlock(Identifier, 7, false),
            5406 => new MangroveSignBlock(Identifier, 8, true),
            5407 => new MangroveSignBlock(Identifier, 8, false),
            5408 => new MangroveSignBlock(Identifier, 9, true),
            5409 => new MangroveSignBlock(Identifier, 9, false),
            5410 => new MangroveSignBlock(Identifier, 10, true),
            5411 => new MangroveSignBlock(Identifier, 10, false),
            5412 => new MangroveSignBlock(Identifier, 11, true),
            5413 => new MangroveSignBlock(Identifier, 11, false),
            5414 => new MangroveSignBlock(Identifier, 12, true),
            5415 => new MangroveSignBlock(Identifier, 12, false),
            5416 => new MangroveSignBlock(Identifier, 13, true),
            5417 => new MangroveSignBlock(Identifier, 13, false),
            5418 => new MangroveSignBlock(Identifier, 14, true),
            5419 => new MangroveSignBlock(Identifier, 14, false),
            5420 => new MangroveSignBlock(Identifier, 15, true),
            5421 => new MangroveSignBlock(Identifier, 15, false),
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
