using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record DarkOakSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 203;
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
    public Identifier? Item => "minecraft:dark_oak_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 26;
    public string TranslationKey => "block.minecraft.dark_oak_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4558,
                    false => 4559,
                },
                1 => Waterlogged switch {
                    true => 4560,
                    false => 4561,
                },
                2 => Waterlogged switch {
                    true => 4562,
                    false => 4563,
                },
                3 => Waterlogged switch {
                    true => 4564,
                    false => 4565,
                },
                4 => Waterlogged switch {
                    true => 4566,
                    false => 4567,
                },
                5 => Waterlogged switch {
                    true => 4568,
                    false => 4569,
                },
                6 => Waterlogged switch {
                    true => 4570,
                    false => 4571,
                },
                7 => Waterlogged switch {
                    true => 4572,
                    false => 4573,
                },
                8 => Waterlogged switch {
                    true => 4574,
                    false => 4575,
                },
                9 => Waterlogged switch {
                    true => 4576,
                    false => 4577,
                },
                10 => Waterlogged switch {
                    true => 4578,
                    false => 4579,
                },
                11 => Waterlogged switch {
                    true => 4580,
                    false => 4581,
                },
                12 => Waterlogged switch {
                    true => 4582,
                    false => 4583,
                },
                13 => Waterlogged switch {
                    true => 4584,
                    false => 4585,
                },
                14 => Waterlogged switch {
                    true => 4586,
                    false => 4587,
                },
                15 => Waterlogged switch {
                    true => 4588,
                    false => 4589,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4558 => new DarkOakSignBlock(Identifier, 0, true),
            4559 => new DarkOakSignBlock(Identifier, 0, false),
            4560 => new DarkOakSignBlock(Identifier, 1, true),
            4561 => new DarkOakSignBlock(Identifier, 1, false),
            4562 => new DarkOakSignBlock(Identifier, 2, true),
            4563 => new DarkOakSignBlock(Identifier, 2, false),
            4564 => new DarkOakSignBlock(Identifier, 3, true),
            4565 => new DarkOakSignBlock(Identifier, 3, false),
            4566 => new DarkOakSignBlock(Identifier, 4, true),
            4567 => new DarkOakSignBlock(Identifier, 4, false),
            4568 => new DarkOakSignBlock(Identifier, 5, true),
            4569 => new DarkOakSignBlock(Identifier, 5, false),
            4570 => new DarkOakSignBlock(Identifier, 6, true),
            4571 => new DarkOakSignBlock(Identifier, 6, false),
            4572 => new DarkOakSignBlock(Identifier, 7, true),
            4573 => new DarkOakSignBlock(Identifier, 7, false),
            4574 => new DarkOakSignBlock(Identifier, 8, true),
            4575 => new DarkOakSignBlock(Identifier, 8, false),
            4576 => new DarkOakSignBlock(Identifier, 9, true),
            4577 => new DarkOakSignBlock(Identifier, 9, false),
            4578 => new DarkOakSignBlock(Identifier, 10, true),
            4579 => new DarkOakSignBlock(Identifier, 10, false),
            4580 => new DarkOakSignBlock(Identifier, 11, true),
            4581 => new DarkOakSignBlock(Identifier, 11, false),
            4582 => new DarkOakSignBlock(Identifier, 12, true),
            4583 => new DarkOakSignBlock(Identifier, 12, false),
            4584 => new DarkOakSignBlock(Identifier, 13, true),
            4585 => new DarkOakSignBlock(Identifier, 13, false),
            4586 => new DarkOakSignBlock(Identifier, 14, true),
            4587 => new DarkOakSignBlock(Identifier, 14, false),
            4588 => new DarkOakSignBlock(Identifier, 15, true),
            4589 => new DarkOakSignBlock(Identifier, 15, false),
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
