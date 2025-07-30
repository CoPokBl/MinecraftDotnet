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
    public int ProtocolId => 204;
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
                    true => 4590,
                    false => 4591,
                },
                1 => Waterlogged switch {
                    true => 4592,
                    false => 4593,
                },
                2 => Waterlogged switch {
                    true => 4594,
                    false => 4595,
                },
                3 => Waterlogged switch {
                    true => 4596,
                    false => 4597,
                },
                4 => Waterlogged switch {
                    true => 4598,
                    false => 4599,
                },
                5 => Waterlogged switch {
                    true => 4600,
                    false => 4601,
                },
                6 => Waterlogged switch {
                    true => 4602,
                    false => 4603,
                },
                7 => Waterlogged switch {
                    true => 4604,
                    false => 4605,
                },
                8 => Waterlogged switch {
                    true => 4606,
                    false => 4607,
                },
                9 => Waterlogged switch {
                    true => 4608,
                    false => 4609,
                },
                10 => Waterlogged switch {
                    true => 4610,
                    false => 4611,
                },
                11 => Waterlogged switch {
                    true => 4612,
                    false => 4613,
                },
                12 => Waterlogged switch {
                    true => 4614,
                    false => 4615,
                },
                13 => Waterlogged switch {
                    true => 4616,
                    false => 4617,
                },
                14 => Waterlogged switch {
                    true => 4618,
                    false => 4619,
                },
                15 => Waterlogged switch {
                    true => 4620,
                    false => 4621,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4590 => new PaleOakSignBlock(Identifier, 0, true),
            4591 => new PaleOakSignBlock(Identifier, 0, false),
            4592 => new PaleOakSignBlock(Identifier, 1, true),
            4593 => new PaleOakSignBlock(Identifier, 1, false),
            4594 => new PaleOakSignBlock(Identifier, 2, true),
            4595 => new PaleOakSignBlock(Identifier, 2, false),
            4596 => new PaleOakSignBlock(Identifier, 3, true),
            4597 => new PaleOakSignBlock(Identifier, 3, false),
            4598 => new PaleOakSignBlock(Identifier, 4, true),
            4599 => new PaleOakSignBlock(Identifier, 4, false),
            4600 => new PaleOakSignBlock(Identifier, 5, true),
            4601 => new PaleOakSignBlock(Identifier, 5, false),
            4602 => new PaleOakSignBlock(Identifier, 6, true),
            4603 => new PaleOakSignBlock(Identifier, 6, false),
            4604 => new PaleOakSignBlock(Identifier, 7, true),
            4605 => new PaleOakSignBlock(Identifier, 7, false),
            4606 => new PaleOakSignBlock(Identifier, 8, true),
            4607 => new PaleOakSignBlock(Identifier, 8, false),
            4608 => new PaleOakSignBlock(Identifier, 9, true),
            4609 => new PaleOakSignBlock(Identifier, 9, false),
            4610 => new PaleOakSignBlock(Identifier, 10, true),
            4611 => new PaleOakSignBlock(Identifier, 10, false),
            4612 => new PaleOakSignBlock(Identifier, 11, true),
            4613 => new PaleOakSignBlock(Identifier, 11, false),
            4614 => new PaleOakSignBlock(Identifier, 12, true),
            4615 => new PaleOakSignBlock(Identifier, 12, false),
            4616 => new PaleOakSignBlock(Identifier, 13, true),
            4617 => new PaleOakSignBlock(Identifier, 13, false),
            4618 => new PaleOakSignBlock(Identifier, 14, true),
            4619 => new PaleOakSignBlock(Identifier, 14, false),
            4620 => new PaleOakSignBlock(Identifier, 15, true),
            4621 => new PaleOakSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("rotation", Rotation.ToString()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
