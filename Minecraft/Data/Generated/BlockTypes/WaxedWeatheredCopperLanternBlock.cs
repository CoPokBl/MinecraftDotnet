using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedWeatheredCopperLanternBlock(Identifier Identifier, bool Hanging, bool Waterlogged) : IBlock {
    public Identifier Category => "minecraft:lantern";
    public double Hardness => 3.5;
    public double ExplosionResistance => 3.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 15;
    public bool Replaceable => false;
    public string SoundType => "lantern";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_weathered_copper_lantern";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.3125] -> [0.6875, 0.4375, 0.6875], AABB[0.375, 0.4375, 0.375] -> [0.625, 0.5625, 0.625]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.3125] -> [0.6875, 0.4375, 0.6875], AABB[0.375, 0.4375, 0.375] -> [0.625, 0.5625, 0.625]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.3125, 0.0, 0.3125] -> [0.6875, 0.4375, 0.6875], AABB[0.375, 0.4375, 0.375] -> [0.625, 0.5625, 0.625]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 6;
    public string TranslationKey => "block.minecraft.waxed_weathered_copper_lantern";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Hanging switch {
                true => Waterlogged switch {
                    true => 20869,
                    false => 20870,
                },
                false => Waterlogged switch {
                    true => 20871,
                    false => 20872,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            20869 => new WaxedWeatheredCopperLanternBlock(Identifier, true, true),
            20870 => new WaxedWeatheredCopperLanternBlock(Identifier, true, false),
            20871 => new WaxedWeatheredCopperLanternBlock(Identifier, false, true),
            20872 => new WaxedWeatheredCopperLanternBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Hanging = properties.Contains("hanging") ? properties["hanging"].GetString() == "true" : Hanging,
            Waterlogged = properties.Contains("waterlogged") ? properties["waterlogged"].GetString() == "true" : Waterlogged,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("hanging", new StringTag(Hanging.ToString().ToLower())),
            ("waterlogged", new StringTag(Waterlogged.ToString().ToLower()))
        );
    }
    
}
