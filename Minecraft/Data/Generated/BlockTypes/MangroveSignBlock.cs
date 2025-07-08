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
                    true => 4622,
                    false => 4623,
                },
                1 => Waterlogged switch {
                    true => 4624,
                    false => 4625,
                },
                2 => Waterlogged switch {
                    true => 4626,
                    false => 4627,
                },
                3 => Waterlogged switch {
                    true => 4628,
                    false => 4629,
                },
                4 => Waterlogged switch {
                    true => 4630,
                    false => 4631,
                },
                5 => Waterlogged switch {
                    true => 4632,
                    false => 4633,
                },
                6 => Waterlogged switch {
                    true => 4634,
                    false => 4635,
                },
                7 => Waterlogged switch {
                    true => 4636,
                    false => 4637,
                },
                8 => Waterlogged switch {
                    true => 4638,
                    false => 4639,
                },
                9 => Waterlogged switch {
                    true => 4640,
                    false => 4641,
                },
                10 => Waterlogged switch {
                    true => 4642,
                    false => 4643,
                },
                11 => Waterlogged switch {
                    true => 4644,
                    false => 4645,
                },
                12 => Waterlogged switch {
                    true => 4646,
                    false => 4647,
                },
                13 => Waterlogged switch {
                    true => 4648,
                    false => 4649,
                },
                14 => Waterlogged switch {
                    true => 4650,
                    false => 4651,
                },
                15 => Waterlogged switch {
                    true => 4652,
                    false => 4653,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4622 => new MangroveSignBlock(Identifier, 0, true),
            4623 => new MangroveSignBlock(Identifier, 0, false),
            4624 => new MangroveSignBlock(Identifier, 1, true),
            4625 => new MangroveSignBlock(Identifier, 1, false),
            4626 => new MangroveSignBlock(Identifier, 2, true),
            4627 => new MangroveSignBlock(Identifier, 2, false),
            4628 => new MangroveSignBlock(Identifier, 3, true),
            4629 => new MangroveSignBlock(Identifier, 3, false),
            4630 => new MangroveSignBlock(Identifier, 4, true),
            4631 => new MangroveSignBlock(Identifier, 4, false),
            4632 => new MangroveSignBlock(Identifier, 5, true),
            4633 => new MangroveSignBlock(Identifier, 5, false),
            4634 => new MangroveSignBlock(Identifier, 6, true),
            4635 => new MangroveSignBlock(Identifier, 6, false),
            4636 => new MangroveSignBlock(Identifier, 7, true),
            4637 => new MangroveSignBlock(Identifier, 7, false),
            4638 => new MangroveSignBlock(Identifier, 8, true),
            4639 => new MangroveSignBlock(Identifier, 8, false),
            4640 => new MangroveSignBlock(Identifier, 9, true),
            4641 => new MangroveSignBlock(Identifier, 9, false),
            4642 => new MangroveSignBlock(Identifier, 10, true),
            4643 => new MangroveSignBlock(Identifier, 10, false),
            4644 => new MangroveSignBlock(Identifier, 11, true),
            4645 => new MangroveSignBlock(Identifier, 11, false),
            4646 => new MangroveSignBlock(Identifier, 12, true),
            4647 => new MangroveSignBlock(Identifier, 12, false),
            4648 => new MangroveSignBlock(Identifier, 13, true),
            4649 => new MangroveSignBlock(Identifier, 13, false),
            4650 => new MangroveSignBlock(Identifier, 14, true),
            4651 => new MangroveSignBlock(Identifier, 14, false),
            4652 => new MangroveSignBlock(Identifier, 15, true),
            4653 => new MangroveSignBlock(Identifier, 15, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Rotation = int.Parse(properties["rotation"].GetString()),
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
