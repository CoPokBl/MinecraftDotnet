using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SculkShriekerBlock(Identifier Identifier, bool CanSummon, bool Shrieking, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:sculk_shrieker";
    public double Hardness => 3;
    public double ExplosionResistance => 3;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "sculk_shrieker";
    public Identifier? BlockEntity => "minecraft:sculk_shrieker";
    public Identifier? Item => "minecraft:sculk_shrieker";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 0.5, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 29;
    public string TranslationKey => "block.minecraft.sculk_shrieker";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return CanSummon switch {
                true => Shrieking switch {
                    true => Waterlogged switch {
                        true => 23958,
                        false => 23959,
                    },
                    false => Waterlogged switch {
                        true => 23960,
                        false => 23961,
                    },
                },
                false => Shrieking switch {
                    true => Waterlogged switch {
                        true => 23962,
                        false => 23963,
                    },
                    false => Waterlogged switch {
                        true => 23964,
                        false => 23965,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            23958 => new SculkShriekerBlock(Identifier, true, true, true),
            23959 => new SculkShriekerBlock(Identifier, true, true, false),
            23960 => new SculkShriekerBlock(Identifier, true, false, true),
            23961 => new SculkShriekerBlock(Identifier, true, false, false),
            23962 => new SculkShriekerBlock(Identifier, false, true, true),
            23963 => new SculkShriekerBlock(Identifier, false, true, false),
            23964 => new SculkShriekerBlock(Identifier, false, false, true),
            23965 => new SculkShriekerBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            CanSummon = properties["can_summon"].GetString() == "true",
            Shrieking = properties["shrieking"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
}
