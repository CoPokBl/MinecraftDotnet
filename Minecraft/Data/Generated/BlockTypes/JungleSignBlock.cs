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
    public int ProtocolId => 202;
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
                    true => 4526,
                    false => 4527,
                },
                1 => Waterlogged switch {
                    true => 4528,
                    false => 4529,
                },
                2 => Waterlogged switch {
                    true => 4530,
                    false => 4531,
                },
                3 => Waterlogged switch {
                    true => 4532,
                    false => 4533,
                },
                4 => Waterlogged switch {
                    true => 4534,
                    false => 4535,
                },
                5 => Waterlogged switch {
                    true => 4536,
                    false => 4537,
                },
                6 => Waterlogged switch {
                    true => 4538,
                    false => 4539,
                },
                7 => Waterlogged switch {
                    true => 4540,
                    false => 4541,
                },
                8 => Waterlogged switch {
                    true => 4542,
                    false => 4543,
                },
                9 => Waterlogged switch {
                    true => 4544,
                    false => 4545,
                },
                10 => Waterlogged switch {
                    true => 4546,
                    false => 4547,
                },
                11 => Waterlogged switch {
                    true => 4548,
                    false => 4549,
                },
                12 => Waterlogged switch {
                    true => 4550,
                    false => 4551,
                },
                13 => Waterlogged switch {
                    true => 4552,
                    false => 4553,
                },
                14 => Waterlogged switch {
                    true => 4554,
                    false => 4555,
                },
                15 => Waterlogged switch {
                    true => 4556,
                    false => 4557,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4526 => new JungleSignBlock(Identifier, 0, true),
            4527 => new JungleSignBlock(Identifier, 0, false),
            4528 => new JungleSignBlock(Identifier, 1, true),
            4529 => new JungleSignBlock(Identifier, 1, false),
            4530 => new JungleSignBlock(Identifier, 2, true),
            4531 => new JungleSignBlock(Identifier, 2, false),
            4532 => new JungleSignBlock(Identifier, 3, true),
            4533 => new JungleSignBlock(Identifier, 3, false),
            4534 => new JungleSignBlock(Identifier, 4, true),
            4535 => new JungleSignBlock(Identifier, 4, false),
            4536 => new JungleSignBlock(Identifier, 5, true),
            4537 => new JungleSignBlock(Identifier, 5, false),
            4538 => new JungleSignBlock(Identifier, 6, true),
            4539 => new JungleSignBlock(Identifier, 6, false),
            4540 => new JungleSignBlock(Identifier, 7, true),
            4541 => new JungleSignBlock(Identifier, 7, false),
            4542 => new JungleSignBlock(Identifier, 8, true),
            4543 => new JungleSignBlock(Identifier, 8, false),
            4544 => new JungleSignBlock(Identifier, 9, true),
            4545 => new JungleSignBlock(Identifier, 9, false),
            4546 => new JungleSignBlock(Identifier, 10, true),
            4547 => new JungleSignBlock(Identifier, 10, false),
            4548 => new JungleSignBlock(Identifier, 11, true),
            4549 => new JungleSignBlock(Identifier, 11, false),
            4550 => new JungleSignBlock(Identifier, 12, true),
            4551 => new JungleSignBlock(Identifier, 12, false),
            4552 => new JungleSignBlock(Identifier, 13, true),
            4553 => new JungleSignBlock(Identifier, 13, false),
            4554 => new JungleSignBlock(Identifier, 14, true),
            4555 => new JungleSignBlock(Identifier, 14, false),
            4556 => new JungleSignBlock(Identifier, 15, true),
            4557 => new JungleSignBlock(Identifier, 15, false),
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
