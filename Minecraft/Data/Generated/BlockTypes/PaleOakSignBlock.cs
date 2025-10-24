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
    public int ProtocolId => 216;
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
                    true => 5358,
                    false => 5359,
                },
                1 => Waterlogged switch {
                    true => 5360,
                    false => 5361,
                },
                2 => Waterlogged switch {
                    true => 5362,
                    false => 5363,
                },
                3 => Waterlogged switch {
                    true => 5364,
                    false => 5365,
                },
                4 => Waterlogged switch {
                    true => 5366,
                    false => 5367,
                },
                5 => Waterlogged switch {
                    true => 5368,
                    false => 5369,
                },
                6 => Waterlogged switch {
                    true => 5370,
                    false => 5371,
                },
                7 => Waterlogged switch {
                    true => 5372,
                    false => 5373,
                },
                8 => Waterlogged switch {
                    true => 5374,
                    false => 5375,
                },
                9 => Waterlogged switch {
                    true => 5376,
                    false => 5377,
                },
                10 => Waterlogged switch {
                    true => 5378,
                    false => 5379,
                },
                11 => Waterlogged switch {
                    true => 5380,
                    false => 5381,
                },
                12 => Waterlogged switch {
                    true => 5382,
                    false => 5383,
                },
                13 => Waterlogged switch {
                    true => 5384,
                    false => 5385,
                },
                14 => Waterlogged switch {
                    true => 5386,
                    false => 5387,
                },
                15 => Waterlogged switch {
                    true => 5388,
                    false => 5389,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5358 => new PaleOakSignBlock(Identifier, 0, true),
            5359 => new PaleOakSignBlock(Identifier, 0, false),
            5360 => new PaleOakSignBlock(Identifier, 1, true),
            5361 => new PaleOakSignBlock(Identifier, 1, false),
            5362 => new PaleOakSignBlock(Identifier, 2, true),
            5363 => new PaleOakSignBlock(Identifier, 2, false),
            5364 => new PaleOakSignBlock(Identifier, 3, true),
            5365 => new PaleOakSignBlock(Identifier, 3, false),
            5366 => new PaleOakSignBlock(Identifier, 4, true),
            5367 => new PaleOakSignBlock(Identifier, 4, false),
            5368 => new PaleOakSignBlock(Identifier, 5, true),
            5369 => new PaleOakSignBlock(Identifier, 5, false),
            5370 => new PaleOakSignBlock(Identifier, 6, true),
            5371 => new PaleOakSignBlock(Identifier, 6, false),
            5372 => new PaleOakSignBlock(Identifier, 7, true),
            5373 => new PaleOakSignBlock(Identifier, 7, false),
            5374 => new PaleOakSignBlock(Identifier, 8, true),
            5375 => new PaleOakSignBlock(Identifier, 8, false),
            5376 => new PaleOakSignBlock(Identifier, 9, true),
            5377 => new PaleOakSignBlock(Identifier, 9, false),
            5378 => new PaleOakSignBlock(Identifier, 10, true),
            5379 => new PaleOakSignBlock(Identifier, 10, false),
            5380 => new PaleOakSignBlock(Identifier, 11, true),
            5381 => new PaleOakSignBlock(Identifier, 11, false),
            5382 => new PaleOakSignBlock(Identifier, 12, true),
            5383 => new PaleOakSignBlock(Identifier, 12, false),
            5384 => new PaleOakSignBlock(Identifier, 13, true),
            5385 => new PaleOakSignBlock(Identifier, 13, false),
            5386 => new PaleOakSignBlock(Identifier, 14, true),
            5387 => new PaleOakSignBlock(Identifier, 14, false),
            5388 => new PaleOakSignBlock(Identifier, 15, true),
            5389 => new PaleOakSignBlock(Identifier, 15, false),
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
