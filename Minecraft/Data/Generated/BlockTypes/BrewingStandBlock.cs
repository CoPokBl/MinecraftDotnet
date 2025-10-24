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
    public int ProtocolId => 385;
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
                        true => 9251,
                        false => 9252,
                    },
                    false => HasBottle2 switch {
                        true => 9253,
                        false => 9254,
                    },
                },
                false => HasBottle1 switch {
                    true => HasBottle2 switch {
                        true => 9255,
                        false => 9256,
                    },
                    false => HasBottle2 switch {
                        true => 9257,
                        false => 9258,
                    },
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            9251 => new BrewingStandBlock(Identifier, true, true, true),
            9252 => new BrewingStandBlock(Identifier, true, true, false),
            9253 => new BrewingStandBlock(Identifier, true, false, true),
            9254 => new BrewingStandBlock(Identifier, true, false, false),
            9255 => new BrewingStandBlock(Identifier, false, true, true),
            9256 => new BrewingStandBlock(Identifier, false, true, false),
            9257 => new BrewingStandBlock(Identifier, false, false, true),
            9258 => new BrewingStandBlock(Identifier, false, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            HasBottle0 = properties.ChildrenMap.ContainsKey("has_bottle_0") ? properties["has_bottle_0"].GetString() == "true" : HasBottle0,
            HasBottle1 = properties.ChildrenMap.ContainsKey("has_bottle_1") ? properties["has_bottle_1"].GetString() == "true" : HasBottle1,
            HasBottle2 = properties.ChildrenMap.ContainsKey("has_bottle_2") ? properties["has_bottle_2"].GetString() == "true" : HasBottle2,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("has_bottle_0", HasBottle0.ToString().ToLower()),
            new StringTag("has_bottle_1", HasBottle1.ToString().ToLower()),
            new StringTag("has_bottle_2", HasBottle2.ToString().ToLower())
        );
    }
    
}
