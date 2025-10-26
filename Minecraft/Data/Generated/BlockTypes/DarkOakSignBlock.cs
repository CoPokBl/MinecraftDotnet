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
    public int ProtocolId => 215;
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
                    true => 5326,
                    false => 5327,
                },
                1 => Waterlogged switch {
                    true => 5328,
                    false => 5329,
                },
                2 => Waterlogged switch {
                    true => 5330,
                    false => 5331,
                },
                3 => Waterlogged switch {
                    true => 5332,
                    false => 5333,
                },
                4 => Waterlogged switch {
                    true => 5334,
                    false => 5335,
                },
                5 => Waterlogged switch {
                    true => 5336,
                    false => 5337,
                },
                6 => Waterlogged switch {
                    true => 5338,
                    false => 5339,
                },
                7 => Waterlogged switch {
                    true => 5340,
                    false => 5341,
                },
                8 => Waterlogged switch {
                    true => 5342,
                    false => 5343,
                },
                9 => Waterlogged switch {
                    true => 5344,
                    false => 5345,
                },
                10 => Waterlogged switch {
                    true => 5346,
                    false => 5347,
                },
                11 => Waterlogged switch {
                    true => 5348,
                    false => 5349,
                },
                12 => Waterlogged switch {
                    true => 5350,
                    false => 5351,
                },
                13 => Waterlogged switch {
                    true => 5352,
                    false => 5353,
                },
                14 => Waterlogged switch {
                    true => 5354,
                    false => 5355,
                },
                15 => Waterlogged switch {
                    true => 5356,
                    false => 5357,
                },
                _ => throw new ArgumentOutOfRangeException(nameof(Rotation), Rotation, "Unknown value for property rotation.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            5326 => new DarkOakSignBlock(Identifier, 0, true),
            5327 => new DarkOakSignBlock(Identifier, 0, false),
            5328 => new DarkOakSignBlock(Identifier, 1, true),
            5329 => new DarkOakSignBlock(Identifier, 1, false),
            5330 => new DarkOakSignBlock(Identifier, 2, true),
            5331 => new DarkOakSignBlock(Identifier, 2, false),
            5332 => new DarkOakSignBlock(Identifier, 3, true),
            5333 => new DarkOakSignBlock(Identifier, 3, false),
            5334 => new DarkOakSignBlock(Identifier, 4, true),
            5335 => new DarkOakSignBlock(Identifier, 4, false),
            5336 => new DarkOakSignBlock(Identifier, 5, true),
            5337 => new DarkOakSignBlock(Identifier, 5, false),
            5338 => new DarkOakSignBlock(Identifier, 6, true),
            5339 => new DarkOakSignBlock(Identifier, 6, false),
            5340 => new DarkOakSignBlock(Identifier, 7, true),
            5341 => new DarkOakSignBlock(Identifier, 7, false),
            5342 => new DarkOakSignBlock(Identifier, 8, true),
            5343 => new DarkOakSignBlock(Identifier, 8, false),
            5344 => new DarkOakSignBlock(Identifier, 9, true),
            5345 => new DarkOakSignBlock(Identifier, 9, false),
            5346 => new DarkOakSignBlock(Identifier, 10, true),
            5347 => new DarkOakSignBlock(Identifier, 10, false),
            5348 => new DarkOakSignBlock(Identifier, 11, true),
            5349 => new DarkOakSignBlock(Identifier, 11, false),
            5350 => new DarkOakSignBlock(Identifier, 12, true),
            5351 => new DarkOakSignBlock(Identifier, 12, false),
            5352 => new DarkOakSignBlock(Identifier, 13, true),
            5353 => new DarkOakSignBlock(Identifier, 13, false),
            5354 => new DarkOakSignBlock(Identifier, 14, true),
            5355 => new DarkOakSignBlock(Identifier, 14, false),
            5356 => new DarkOakSignBlock(Identifier, 15, true),
            5357 => new DarkOakSignBlock(Identifier, 15, false),
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
