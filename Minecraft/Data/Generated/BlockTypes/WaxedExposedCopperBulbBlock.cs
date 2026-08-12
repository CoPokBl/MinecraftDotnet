using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record WaxedExposedCopperBulbBlock(Identifier Identifier, bool Lit, bool Powered) : IBlock {
    public Identifier Category => "minecraft:copper_bulb_block";
    public double Hardness => 3;
    public double ExplosionResistance => 6;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => true;
    public bool RequiresTool => true;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "copper_bulb";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:waxed_exposed_copper_bulb";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => false;
    public PushReaction PushReaction => PushReaction.Normal;
    public int MapColorId => 44;
    public string TranslationKey => "block.minecraft.waxed_exposed_copper_bulb";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Lit switch {
                true => Powered switch {
                    true => 29556,
                    false => 29557,
                },
                false => Powered switch {
                    true => 29558,
                    false => 29559,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            29556 => new WaxedExposedCopperBulbBlock(Identifier, true, true),
            29557 => new WaxedExposedCopperBulbBlock(Identifier, true, false),
            29558 => new WaxedExposedCopperBulbBlock(Identifier, false, true),
            29559 => new WaxedExposedCopperBulbBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Lit = properties.Contains("lit") ? properties["lit"].GetString() == "true" : Lit,
            Powered = properties.Contains("powered") ? properties["powered"].GetString() == "true" : Powered,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(
            ("lit", new StringTag(Lit.ToString().ToLower())),
            ("powered", new StringTag(Powered.ToString().ToLower()))
        );
    }
    
}
