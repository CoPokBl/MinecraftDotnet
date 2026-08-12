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
                    true => 5495,
                    false => 5496,
                },
                1 => Waterlogged switch {
                    true => 5497,
                    false => 5498,
                },
                2 => Waterlogged switch {
                    true => 5499,
                    false => 5500,
                },
                3 => Waterlogged switch {
                    true => 5501,
                    false => 5502,
                },
                4 => Waterlogged switch {
                    true => 5503,
                    false => 5504,
                },
                5 => Waterlogged switch {
                    true => 5505,
                    false => 5506,
                },
                6 => Waterlogged switch {
                    true => 5507,
                    false => 5508,
                },
                7 => Waterlogged switch {
                    true => 5509,
                    false => 5510,
                },
                8 => Waterlogged switch {
                    true => 5511,
                    false => 5512,
                },
                9 => Waterlogged switch {
                    true => 5513,
                    false => 5514,
                },
                10 => Waterlogged switch {
                    true => 5515,
                    false => 5516,
                },
                11 => Waterlogged switch {
                    true => 5517,
                    false => 5518,
                },
                12 => Waterlogged switch {
                    true => 5519,
                    false => 5520,
                },
                13 => Waterlogged switch {
                    true => 5521,
                    false => 5522,
                },
                14 => Waterlogged switch {
                    true => 5523,
                    false => 5524,
                },
                15 => Waterlogged switch {
                    true => 5525,
                    false => 5526,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5495 => new JungleSignBlock(Identifier, 0, true),
            5496 => new JungleSignBlock(Identifier, 0, false),
            5497 => new JungleSignBlock(Identifier, 1, true),
            5498 => new JungleSignBlock(Identifier, 1, false),
            5499 => new JungleSignBlock(Identifier, 2, true),
            5500 => new JungleSignBlock(Identifier, 2, false),
            5501 => new JungleSignBlock(Identifier, 3, true),
            5502 => new JungleSignBlock(Identifier, 3, false),
            5503 => new JungleSignBlock(Identifier, 4, true),
            5504 => new JungleSignBlock(Identifier, 4, false),
            5505 => new JungleSignBlock(Identifier, 5, true),
            5506 => new JungleSignBlock(Identifier, 5, false),
            5507 => new JungleSignBlock(Identifier, 6, true),
            5508 => new JungleSignBlock(Identifier, 6, false),
            5509 => new JungleSignBlock(Identifier, 7, true),
            5510 => new JungleSignBlock(Identifier, 7, false),
            5511 => new JungleSignBlock(Identifier, 8, true),
            5512 => new JungleSignBlock(Identifier, 8, false),
            5513 => new JungleSignBlock(Identifier, 9, true),
            5514 => new JungleSignBlock(Identifier, 9, false),
            5515 => new JungleSignBlock(Identifier, 10, true),
            5516 => new JungleSignBlock(Identifier, 10, false),
            5517 => new JungleSignBlock(Identifier, 11, true),
            5518 => new JungleSignBlock(Identifier, 11, false),
            5519 => new JungleSignBlock(Identifier, 12, true),
            5520 => new JungleSignBlock(Identifier, 12, false),
            5521 => new JungleSignBlock(Identifier, 13, true),
            5522 => new JungleSignBlock(Identifier, 13, false),
            5523 => new JungleSignBlock(Identifier, 14, true),
            5524 => new JungleSignBlock(Identifier, 14, false),
            5525 => new JungleSignBlock(Identifier, 15, true),
            5526 => new JungleSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = properties.Contains("rotation") ? int.Parse(properties["rotation"].GetString()) : Rotation,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("rotation", new StringTag(Rotation.ToString())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
