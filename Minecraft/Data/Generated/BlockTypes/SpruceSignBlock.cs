using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SpruceSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {

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
    public Identifier? Item => "minecraft:spruce_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 34;
    public string TranslationKey => "block.minecraft.spruce_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 4398,
                    false => 4399,
                },
                1 => Waterlogged switch {
                    true => 4400,
                    false => 4401,
                },
                2 => Waterlogged switch {
                    true => 4402,
                    false => 4403,
                },
                3 => Waterlogged switch {
                    true => 4404,
                    false => 4405,
                },
                4 => Waterlogged switch {
                    true => 4406,
                    false => 4407,
                },
                5 => Waterlogged switch {
                    true => 4408,
                    false => 4409,
                },
                6 => Waterlogged switch {
                    true => 4410,
                    false => 4411,
                },
                7 => Waterlogged switch {
                    true => 4412,
                    false => 4413,
                },
                8 => Waterlogged switch {
                    true => 4414,
                    false => 4415,
                },
                9 => Waterlogged switch {
                    true => 4416,
                    false => 4417,
                },
                10 => Waterlogged switch {
                    true => 4418,
                    false => 4419,
                },
                11 => Waterlogged switch {
                    true => 4420,
                    false => 4421,
                },
                12 => Waterlogged switch {
                    true => 4422,
                    false => 4423,
                },
                13 => Waterlogged switch {
                    true => 4424,
                    false => 4425,
                },
                14 => Waterlogged switch {
                    true => 4426,
                    false => 4427,
                },
                15 => Waterlogged switch {
                    true => 4428,
                    false => 4429,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            4398 => new SpruceSignBlock(Identifier, 0, true),
            4399 => new SpruceSignBlock(Identifier, 0, false),
            4400 => new SpruceSignBlock(Identifier, 1, true),
            4401 => new SpruceSignBlock(Identifier, 1, false),
            4402 => new SpruceSignBlock(Identifier, 2, true),
            4403 => new SpruceSignBlock(Identifier, 2, false),
            4404 => new SpruceSignBlock(Identifier, 3, true),
            4405 => new SpruceSignBlock(Identifier, 3, false),
            4406 => new SpruceSignBlock(Identifier, 4, true),
            4407 => new SpruceSignBlock(Identifier, 4, false),
            4408 => new SpruceSignBlock(Identifier, 5, true),
            4409 => new SpruceSignBlock(Identifier, 5, false),
            4410 => new SpruceSignBlock(Identifier, 6, true),
            4411 => new SpruceSignBlock(Identifier, 6, false),
            4412 => new SpruceSignBlock(Identifier, 7, true),
            4413 => new SpruceSignBlock(Identifier, 7, false),
            4414 => new SpruceSignBlock(Identifier, 8, true),
            4415 => new SpruceSignBlock(Identifier, 8, false),
            4416 => new SpruceSignBlock(Identifier, 9, true),
            4417 => new SpruceSignBlock(Identifier, 9, false),
            4418 => new SpruceSignBlock(Identifier, 10, true),
            4419 => new SpruceSignBlock(Identifier, 10, false),
            4420 => new SpruceSignBlock(Identifier, 11, true),
            4421 => new SpruceSignBlock(Identifier, 11, false),
            4422 => new SpruceSignBlock(Identifier, 12, true),
            4423 => new SpruceSignBlock(Identifier, 12, false),
            4424 => new SpruceSignBlock(Identifier, 13, true),
            4425 => new SpruceSignBlock(Identifier, 13, false),
            4426 => new SpruceSignBlock(Identifier, 14, true),
            4427 => new SpruceSignBlock(Identifier, 14, false),
            4428 => new SpruceSignBlock(Identifier, 15, true),
            4429 => new SpruceSignBlock(Identifier, 15, false),
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
