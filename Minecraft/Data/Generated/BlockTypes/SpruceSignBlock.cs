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
                    true => 5367,
                    false => 5368,
                },
                1 => Waterlogged switch {
                    true => 5369,
                    false => 5370,
                },
                2 => Waterlogged switch {
                    true => 5371,
                    false => 5372,
                },
                3 => Waterlogged switch {
                    true => 5373,
                    false => 5374,
                },
                4 => Waterlogged switch {
                    true => 5375,
                    false => 5376,
                },
                5 => Waterlogged switch {
                    true => 5377,
                    false => 5378,
                },
                6 => Waterlogged switch {
                    true => 5379,
                    false => 5380,
                },
                7 => Waterlogged switch {
                    true => 5381,
                    false => 5382,
                },
                8 => Waterlogged switch {
                    true => 5383,
                    false => 5384,
                },
                9 => Waterlogged switch {
                    true => 5385,
                    false => 5386,
                },
                10 => Waterlogged switch {
                    true => 5387,
                    false => 5388,
                },
                11 => Waterlogged switch {
                    true => 5389,
                    false => 5390,
                },
                12 => Waterlogged switch {
                    true => 5391,
                    false => 5392,
                },
                13 => Waterlogged switch {
                    true => 5393,
                    false => 5394,
                },
                14 => Waterlogged switch {
                    true => 5395,
                    false => 5396,
                },
                15 => Waterlogged switch {
                    true => 5397,
                    false => 5398,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5367 => new SpruceSignBlock(Identifier, 0, true),
            5368 => new SpruceSignBlock(Identifier, 0, false),
            5369 => new SpruceSignBlock(Identifier, 1, true),
            5370 => new SpruceSignBlock(Identifier, 1, false),
            5371 => new SpruceSignBlock(Identifier, 2, true),
            5372 => new SpruceSignBlock(Identifier, 2, false),
            5373 => new SpruceSignBlock(Identifier, 3, true),
            5374 => new SpruceSignBlock(Identifier, 3, false),
            5375 => new SpruceSignBlock(Identifier, 4, true),
            5376 => new SpruceSignBlock(Identifier, 4, false),
            5377 => new SpruceSignBlock(Identifier, 5, true),
            5378 => new SpruceSignBlock(Identifier, 5, false),
            5379 => new SpruceSignBlock(Identifier, 6, true),
            5380 => new SpruceSignBlock(Identifier, 6, false),
            5381 => new SpruceSignBlock(Identifier, 7, true),
            5382 => new SpruceSignBlock(Identifier, 7, false),
            5383 => new SpruceSignBlock(Identifier, 8, true),
            5384 => new SpruceSignBlock(Identifier, 8, false),
            5385 => new SpruceSignBlock(Identifier, 9, true),
            5386 => new SpruceSignBlock(Identifier, 9, false),
            5387 => new SpruceSignBlock(Identifier, 10, true),
            5388 => new SpruceSignBlock(Identifier, 10, false),
            5389 => new SpruceSignBlock(Identifier, 11, true),
            5390 => new SpruceSignBlock(Identifier, 11, false),
            5391 => new SpruceSignBlock(Identifier, 12, true),
            5392 => new SpruceSignBlock(Identifier, 12, false),
            5393 => new SpruceSignBlock(Identifier, 13, true),
            5394 => new SpruceSignBlock(Identifier, 13, false),
            5395 => new SpruceSignBlock(Identifier, 14, true),
            5396 => new SpruceSignBlock(Identifier, 14, false),
            5397 => new SpruceSignBlock(Identifier, 15, true),
            5398 => new SpruceSignBlock(Identifier, 15, false),
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
