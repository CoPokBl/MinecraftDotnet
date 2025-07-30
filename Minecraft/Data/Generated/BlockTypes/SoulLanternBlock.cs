using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record SoulLanternBlock(Identifier Identifier, bool Hanging, bool Waterlogged) : IBlock {

    public Identifier Category => "minecraft:lantern";
    public int ProtocolId => 818;
    public double Hardness => 3.5;
    public double ExplosionResistance => 3.5;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => true;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 10;
    public bool Replaceable => false;
    public string SoundType => "lantern";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:soul_lantern";
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
    public string TranslationKey => "block.minecraft.soul_lantern";
    public bool CanRespawnIn => false;


    public uint StateId {
        get {
            return Hanging switch {
                true => Waterlogged switch {
                    true => 19562,
                    false => 19563,
                },
                false => Waterlogged switch {
                    true => 19564,
                    false => 19565,
                },
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            19562 => new SoulLanternBlock(Identifier, true, true),
            19563 => new SoulLanternBlock(Identifier, true, false),
            19564 => new SoulLanternBlock(Identifier, false, true),
            19565 => new SoulLanternBlock(Identifier, false, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Hanging = properties["hanging"].GetString() == "true",
            Waterlogged = properties["waterlogged"].GetString() == "true",
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("hanging", Hanging.ToString().ToLower()),
            new StringTag("waterlogged", Waterlogged.ToString().ToLower())
        );
    }
    
}
