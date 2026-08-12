using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
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
    public Identifier? Item => "minecraft:pale_oak_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 14;
    public string TranslationKey => "block.minecraft.pale_oak_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 5559,
                    false => 5560,
                },
                1 => Waterlogged switch {
                    true => 5561,
                    false => 5562,
                },
                2 => Waterlogged switch {
                    true => 5563,
                    false => 5564,
                },
                3 => Waterlogged switch {
                    true => 5565,
                    false => 5566,
                },
                4 => Waterlogged switch {
                    true => 5567,
                    false => 5568,
                },
                5 => Waterlogged switch {
                    true => 5569,
                    false => 5570,
                },
                6 => Waterlogged switch {
                    true => 5571,
                    false => 5572,
                },
                7 => Waterlogged switch {
                    true => 5573,
                    false => 5574,
                },
                8 => Waterlogged switch {
                    true => 5575,
                    false => 5576,
                },
                9 => Waterlogged switch {
                    true => 5577,
                    false => 5578,
                },
                10 => Waterlogged switch {
                    true => 5579,
                    false => 5580,
                },
                11 => Waterlogged switch {
                    true => 5581,
                    false => 5582,
                },
                12 => Waterlogged switch {
                    true => 5583,
                    false => 5584,
                },
                13 => Waterlogged switch {
                    true => 5585,
                    false => 5586,
                },
                14 => Waterlogged switch {
                    true => 5587,
                    false => 5588,
                },
                15 => Waterlogged switch {
                    true => 5589,
                    false => 5590,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5559 => new PaleOakSignBlock(Identifier, 0, true),
            5560 => new PaleOakSignBlock(Identifier, 0, false),
            5561 => new PaleOakSignBlock(Identifier, 1, true),
            5562 => new PaleOakSignBlock(Identifier, 1, false),
            5563 => new PaleOakSignBlock(Identifier, 2, true),
            5564 => new PaleOakSignBlock(Identifier, 2, false),
            5565 => new PaleOakSignBlock(Identifier, 3, true),
            5566 => new PaleOakSignBlock(Identifier, 3, false),
            5567 => new PaleOakSignBlock(Identifier, 4, true),
            5568 => new PaleOakSignBlock(Identifier, 4, false),
            5569 => new PaleOakSignBlock(Identifier, 5, true),
            5570 => new PaleOakSignBlock(Identifier, 5, false),
            5571 => new PaleOakSignBlock(Identifier, 6, true),
            5572 => new PaleOakSignBlock(Identifier, 6, false),
            5573 => new PaleOakSignBlock(Identifier, 7, true),
            5574 => new PaleOakSignBlock(Identifier, 7, false),
            5575 => new PaleOakSignBlock(Identifier, 8, true),
            5576 => new PaleOakSignBlock(Identifier, 8, false),
            5577 => new PaleOakSignBlock(Identifier, 9, true),
            5578 => new PaleOakSignBlock(Identifier, 9, false),
            5579 => new PaleOakSignBlock(Identifier, 10, true),
            5580 => new PaleOakSignBlock(Identifier, 10, false),
            5581 => new PaleOakSignBlock(Identifier, 11, true),
            5582 => new PaleOakSignBlock(Identifier, 11, false),
            5583 => new PaleOakSignBlock(Identifier, 12, true),
            5584 => new PaleOakSignBlock(Identifier, 12, false),
            5585 => new PaleOakSignBlock(Identifier, 13, true),
            5586 => new PaleOakSignBlock(Identifier, 13, false),
            5587 => new PaleOakSignBlock(Identifier, 14, true),
            5588 => new PaleOakSignBlock(Identifier, 14, false),
            5589 => new PaleOakSignBlock(Identifier, 15, true),
            5590 => new PaleOakSignBlock(Identifier, 15, false),
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
