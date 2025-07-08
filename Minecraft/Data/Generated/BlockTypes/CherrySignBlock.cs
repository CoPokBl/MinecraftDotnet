using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record CherrySignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

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
    public string SoundType => "cherry_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:cherry_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 36;
    public string TranslationKey => "block.minecraft.cherry_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4494,
                    false => 4495,
                },
                1 => Waterlogged switch {
                    true => 4496,
                    false => 4497,
                },
                2 => Waterlogged switch {
                    true => 4498,
                    false => 4499,
                },
                3 => Waterlogged switch {
                    true => 4500,
                    false => 4501,
                },
                4 => Waterlogged switch {
                    true => 4502,
                    false => 4503,
                },
                5 => Waterlogged switch {
                    true => 4504,
                    false => 4505,
                },
                6 => Waterlogged switch {
                    true => 4506,
                    false => 4507,
                },
                7 => Waterlogged switch {
                    true => 4508,
                    false => 4509,
                },
                8 => Waterlogged switch {
                    true => 4510,
                    false => 4511,
                },
                9 => Waterlogged switch {
                    true => 4512,
                    false => 4513,
                },
                10 => Waterlogged switch {
                    true => 4514,
                    false => 4515,
                },
                11 => Waterlogged switch {
                    true => 4516,
                    false => 4517,
                },
                12 => Waterlogged switch {
                    true => 4518,
                    false => 4519,
                },
                13 => Waterlogged switch {
                    true => 4520,
                    false => 4521,
                },
                14 => Waterlogged switch {
                    true => 4522,
                    false => 4523,
                },
                15 => Waterlogged switch {
                    true => 4524,
                    false => 4525,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4494 => new CherrySignBlock(Identifier, 0, true),
            4495 => new CherrySignBlock(Identifier, 0, false),
            4496 => new CherrySignBlock(Identifier, 1, true),
            4497 => new CherrySignBlock(Identifier, 1, false),
            4498 => new CherrySignBlock(Identifier, 2, true),
            4499 => new CherrySignBlock(Identifier, 2, false),
            4500 => new CherrySignBlock(Identifier, 3, true),
            4501 => new CherrySignBlock(Identifier, 3, false),
            4502 => new CherrySignBlock(Identifier, 4, true),
            4503 => new CherrySignBlock(Identifier, 4, false),
            4504 => new CherrySignBlock(Identifier, 5, true),
            4505 => new CherrySignBlock(Identifier, 5, false),
            4506 => new CherrySignBlock(Identifier, 6, true),
            4507 => new CherrySignBlock(Identifier, 6, false),
            4508 => new CherrySignBlock(Identifier, 7, true),
            4509 => new CherrySignBlock(Identifier, 7, false),
            4510 => new CherrySignBlock(Identifier, 8, true),
            4511 => new CherrySignBlock(Identifier, 8, false),
            4512 => new CherrySignBlock(Identifier, 9, true),
            4513 => new CherrySignBlock(Identifier, 9, false),
            4514 => new CherrySignBlock(Identifier, 10, true),
            4515 => new CherrySignBlock(Identifier, 10, false),
            4516 => new CherrySignBlock(Identifier, 11, true),
            4517 => new CherrySignBlock(Identifier, 11, false),
            4518 => new CherrySignBlock(Identifier, 12, true),
            4519 => new CherrySignBlock(Identifier, 12, false),
            4520 => new CherrySignBlock(Identifier, 13, true),
            4521 => new CherrySignBlock(Identifier, 13, false),
            4522 => new CherrySignBlock(Identifier, 14, true),
            4523 => new CherrySignBlock(Identifier, 14, false),
            4524 => new CherrySignBlock(Identifier, 15, true),
            4525 => new CherrySignBlock(Identifier, 15, false),
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
