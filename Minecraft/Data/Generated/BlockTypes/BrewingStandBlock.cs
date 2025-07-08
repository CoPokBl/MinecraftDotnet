using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record BrewingStandBlock(Identifier Identifier, bool HasBottle0, bool HasBottle1, bool HasBottle2) : IBlock {

    public Identifier Category => "minecraft:brewing_stand";
    public double Hardness => 0.5;
    public double ExplosionResistance => 0.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 1;
    public bool Replaceable => false;
    public string SoundType => "stone";
    public Identifier? BlockEntity => "minecraft:brewing_stand";
    public Identifier? Item => "minecraft:brewing_stand";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.125, 0.9375], AABB[0.4375, 0.125, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.125, 0.9375], AABB[0.4375, 0.125, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.0, 0.0625] -> [0.9375, 0.125, 0.9375], AABB[0.4375, 0.125, 0.4375] -> [0.5625, 0.875, 0.5625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.brewing_stand";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return HasBottle0 switch {
                true => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 8174,
                        false => 8175,
                    },
                    false => HasBottle2 switch {
                        true => 8176,
                        false => 8177,
                    },
                },
                false => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 8178,
                        false => 8179,
                    },
                    false => HasBottle2 switch {
                        true => 8180,
                        false => 8181,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            8174 => new BrewingStandBlock(Identifier, true, true, true),
            8175 => new BrewingStandBlock(Identifier, true, true, false),
            8176 => new BrewingStandBlock(Identifier, true, false, true),
            8177 => new BrewingStandBlock(Identifier, true, false, false),
            8178 => new BrewingStandBlock(Identifier, false, true, true),
            8179 => new BrewingStandBlock(Identifier, false, true, false),
            8180 => new BrewingStandBlock(Identifier, false, false, true),
            8181 => new BrewingStandBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            HasBottle0 = properties["has_bottle_0"].GetString() == "true",
            HasBottle1 = properties["has_bottle_1"].GetString() == "true",
            HasBottle2 = properties["has_bottle_2"].GetString() == "true",
        };
    }
    
}
