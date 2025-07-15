using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record PaleHangingMossBlock(Identifier Identifier, bool Tip) : IBlock {

    public Identifier Category => "minecraft:hanging_moss";
    public double Hardness => 0;
    public double ExplosionResistance => 0;
    public double Friction => 0.6;
    public double SpeedFactor => 1;
    public double JumpFactor => 1;
    public bool Solid => false;
    public bool Liquid => false;
    public bool Occludes => false;
    public bool RequiresTool => false;
    public int LightEmission => 0;
    public bool Replaceable => false;
    public string SoundType => "moss_carpet";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:pale_hanging_moss";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0625, 0.125, 0.0625] -> [0.9375, 1.0, 0.9375]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 22;
    public string TranslationKey => "block.minecraft.pale_hanging_moss";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Tip switch {
                true => 27939,
                false => 27940,
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            27939 => new PaleHangingMossBlock(Identifier, true),
            27940 => new PaleHangingMossBlock(Identifier, false),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Tip = properties["tip"].GetString() == "true",
        };
    }
    
}
