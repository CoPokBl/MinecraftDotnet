using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WarpedSignBlock(Identifier Identifier, int Rotation, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:standing_sign";
    public int ProtocolId => 900;
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
    public string SoundType => "nether_wood";
    public Identifier? BlockEntity => "minecraft:sign";
    public Identifier? Item => "minecraft:warped_sign";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.25, 0.0, 0.25] -> [0.75, 1.0, 0.75]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 56;
    public string TranslationKey => "block.minecraft.warped_sign";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Rotation switch {
                0 => Waterlogged switch {
                    true => 21472,
                    false => 21473,
                },
                1 => Waterlogged switch {
                    true => 21474,
                    false => 21475,
                },
                2 => Waterlogged switch {
                    true => 21476,
                    false => 21477,
                },
                3 => Waterlogged switch {
                    true => 21478,
                    false => 21479,
                },
                4 => Waterlogged switch {
                    true => 21480,
                    false => 21481,
                },
                5 => Waterlogged switch {
                    true => 21482,
                    false => 21483,
                },
                6 => Waterlogged switch {
                    true => 21484,
                    false => 21485,
                },
                7 => Waterlogged switch {
                    true => 21486,
                    false => 21487,
                },
                8 => Waterlogged switch {
                    true => 21488,
                    false => 21489,
                },
                9 => Waterlogged switch {
                    true => 21490,
                    false => 21491,
                },
                10 => Waterlogged switch {
                    true => 21492,
                    false => 21493,
                },
                11 => Waterlogged switch {
                    true => 21494,
                    false => 21495,
                },
                12 => Waterlogged switch {
                    true => 21496,
                    false => 21497,
                },
                13 => Waterlogged switch {
                    true => 21498,
                    false => 21499,
                },
                14 => Waterlogged switch {
                    true => 21500,
                    false => 21501,
                },
                15 => Waterlogged switch {
                    true => 21502,
                    false => 21503,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            21472 => new WarpedSignBlock(Identifier, 0, true),
            21473 => new WarpedSignBlock(Identifier, 0, false),
            21474 => new WarpedSignBlock(Identifier, 1, true),
            21475 => new WarpedSignBlock(Identifier, 1, false),
            21476 => new WarpedSignBlock(Identifier, 2, true),
            21477 => new WarpedSignBlock(Identifier, 2, false),
            21478 => new WarpedSignBlock(Identifier, 3, true),
            21479 => new WarpedSignBlock(Identifier, 3, false),
            21480 => new WarpedSignBlock(Identifier, 4, true),
            21481 => new WarpedSignBlock(Identifier, 4, false),
            21482 => new WarpedSignBlock(Identifier, 5, true),
            21483 => new WarpedSignBlock(Identifier, 5, false),
            21484 => new WarpedSignBlock(Identifier, 6, true),
            21485 => new WarpedSignBlock(Identifier, 6, false),
            21486 => new WarpedSignBlock(Identifier, 7, true),
            21487 => new WarpedSignBlock(Identifier, 7, false),
            21488 => new WarpedSignBlock(Identifier, 8, true),
            21489 => new WarpedSignBlock(Identifier, 8, false),
            21490 => new WarpedSignBlock(Identifier, 9, true),
            21491 => new WarpedSignBlock(Identifier, 9, false),
            21492 => new WarpedSignBlock(Identifier, 10, true),
            21493 => new WarpedSignBlock(Identifier, 10, false),
            21494 => new WarpedSignBlock(Identifier, 11, true),
            21495 => new WarpedSignBlock(Identifier, 11, false),
            21496 => new WarpedSignBlock(Identifier, 12, true),
            21497 => new WarpedSignBlock(Identifier, 12, false),
            21498 => new WarpedSignBlock(Identifier, 13, true),
            21499 => new WarpedSignBlock(Identifier, 13, false),
            21500 => new WarpedSignBlock(Identifier, 14, true),
            21501 => new WarpedSignBlock(Identifier, 14, false),
            21502 => new WarpedSignBlock(Identifier, 15, true),
            21503 => new WarpedSignBlock(Identifier, 15, false),
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
