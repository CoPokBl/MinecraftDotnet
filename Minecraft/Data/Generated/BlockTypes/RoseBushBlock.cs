using NBT;
using NBT.Tags;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Shapes;

namespace Minecraft.Data.Generated.BlockTypes;

// Generated using the CodeGen project. Do not edit manually.
// See Block.cs for last updated date.
public record RoseBushBlock(Identifier Identifier, BlockHalf Half) : IBlock {
    public Identifier Category => "minecraft:tall_flower";
    public int ProtocolId => 557;
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
    public string SoundType => "grass";
    public Identifier? BlockEntity => null;
    public Identifier? Item => "minecraft:rose_bush";
    public ICollisionBox BlockShape => ICollisionBox.ParseAabbArrayString("[AABB[0.0, 0.0, 0.0] -> [1.0, 1.0, 1.0]]");
    public ICollisionBox CollisionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox OcclusionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox InteractionShape => ICollisionBox.ParseAabbArrayString("[]");
    public ICollisionBox VisualShape => ICollisionBox.ParseAabbArrayString("[]");
    public bool RedstoneConductor => false;
    public bool SignalSource => false;
    public bool Flammable => true;
    public PushReaction PushReaction => PushReaction.Destroy;
    public int MapColorId => 7;
    public string TranslationKey => "block.minecraft.rose_bush";
    public bool CanRespawnIn => true;


    public uint StateId {
        get {
            return Half switch {
                BlockHalf.Upper => 12717,
                BlockHalf.Lower => 12718,
                _ => throw new ArgumentOutOfRangeException(nameof(Half), Half, "Unknown value for property half.")
            };
        }
    }
    
    public IBlock WithState(uint state) {
        return state switch {
            12717 => new RoseBushBlock(Identifier, BlockHalf.Upper),
            12718 => new RoseBushBlock(Identifier, BlockHalf.Lower),
            _ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown state id.")
        };
    }
    
    public IBlock WithState(CompoundTag properties) {
        return this with {
            Half = properties.ChildrenMap.ContainsKey("half") ? BlockHalfExtensions.FromString(properties["half"].GetString()) : Half,
        };
    }
    
    public CompoundTag ToStateNbt() {
        return new CompoundTag(null, 
            new StringTag("half", Half.ToName())
        );
    }
    
}
